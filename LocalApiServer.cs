using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

public class LocalApiServer
{
    private readonly HttpListener listener;
    private readonly string keyStoragePath;
    private List<string> validKeys;

    public LocalApiServer(string url)
    {
        listener = new HttpListener();
        listener.Prefixes.Add(url);
        keyStoragePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keys.txt");
        validKeys = LoadKeys();
    }

    public void Start()
    {
        listener.Start();
        Task.Run(() => HandleRequests());
        Console.WriteLine("API started at: " + string.Join(", ", listener.Prefixes));
    }

    private List<string> LoadKeys()
    {
        if (File.Exists(keyStoragePath))
            return new List<string>(File.ReadAllLines(keyStoragePath));
        return new List<string>();
    }

    private void SaveKeys()
    {
        File.WriteAllLines(keyStoragePath, validKeys);
    }

    private async Task HandleRequests()
    {
        while (listener.IsListening)
        {
            var context = await listener.GetContextAsync();
            string path = context.Request.Url.AbsolutePath;

            if (path == "/api/generate")
            {
                string key = Guid.NewGuid().ToString().ToUpper();
                validKeys.Add(key);
                SaveKeys();
                await SendJson(context, new { key });
            }
            else if (path == "/api/validate")
            {
                var reader = new StreamReader(context.Request.InputStream);
                string body = await reader.ReadToEndAsync();
                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
                bool isValid = data != null && data.ContainsKey("key") && validKeys.Contains(data["key"]);
                await SendJson(context, new { valid = isValid });
            }
            else
            {
                context.Response.StatusCode = 404;
                context.Response.Close();
            }
        }
    }

    private async Task SendJson(HttpListenerContext context, object obj)
    {
        string json = JsonSerializer.Serialize(obj);
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(json);
        context.Response.ContentType = "application/json";
        context.Response.ContentLength64 = buffer.Length;
        await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        context.Response.Close();
    }
}