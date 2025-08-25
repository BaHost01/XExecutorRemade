using CefSharp;
using FizzWare.NBuilder;
using Microsoft.PowerBI.Api.Models;
using System;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XExecutor
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]


        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XExecutor());
        }

        public class LocalApiServer
        {
            private readonly HttpListener listener;

            public LocalApiServer(string url)
            {
                listener = new HttpListener();
                listener.Prefixes.Add(url);
            }

            public void Start()
            {
                listener.Start();
                Task.Run(() => HandleRequests());
            }

            private async Task HandleRequests()
            {
                while (listener.IsListening)
                {
                    var context = await listener.GetContextAsync();
                    if (context.Request.Url.AbsolutePath == "/api/generate")
                    {
                        var responseObj = new { key = Guid.NewGuid().ToString().ToUpper() };
                        var responseJson = JsonSerializer.Serialize(responseObj);

                        var buffer = System.Text.Encoding.UTF8.GetBytes(responseJson);
                        context.Response.ContentType = "application/json";
                        context.Response.ContentLength64 = buffer.Length;
                        await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                        context.Response.OutputStream.Close();
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                        context.Response.OutputStream.Close();
                    }
                }
            }
        }
    }
}
            
