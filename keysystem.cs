using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XExecutor
{
    public partial class keysystem : Form
    {
        private readonly string[] validKeys = new string[100]; // Store generated keys (simple in-memory storage)

        public keysystem()
        {
            InitializeComponent();
        }

        private async void keysystem_Load(object sender, EventArgs e)
        {
            try
            {
                // Ensure WebView2 control is properly initialized
                if (Main == null)
                {
                    MessageBox.Show("WebView2 control 'Main' is not initialized. Check the form designer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Initialize WebView2
                await Main.EnsureCoreWebView2Async(null);

                // Log initialization success
                System.Diagnostics.Debug.WriteLine("WebView2 initialized successfully.");

                // Set up message handler
                Main.CoreWebView2.WebMessageReceived += WebView2_WebMessageReceived;

                // Set a basic user agent to avoid compatibility issues
                Main.CoreWebView2.Settings.UserAgent = "XExecutor/1.0";

                // Load HTML from wwwroot/index.html
                string htmlPath = Path.Combine(Application.StartupPath, "wwwroot", "index.html");
                if (!File.Exists(htmlPath))
                {
                    MessageBox.Show($"HTML file not found at: {htmlPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Diagnostics.Debug.WriteLine($"HTML file not found: {htmlPath}");
                    return;
                }

                Main.Source = new Uri($"file:///{htmlPath.Replace("\\", "/")}");
                System.Diagnostics.Debug.WriteLine($"Loading HTML from: {htmlPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize WebView2 or load HTML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"WebView2 initialization or HTML load error: {ex}");
            }
        }

        private void WebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            try
            {
                var message = JsonSerializer.Deserialize<JsonElement>(args.WebMessageAsJson);
                string action = message.GetProperty("action").GetString();

                switch (action)
                {
                    case "generate":
                        string newKey = GenerateKey();
                        validKeys[Array.IndexOf(validKeys, null)] = newKey; // Store key
                        SendResponse(new { key = newKey });
                        System.Diagnostics.Debug.WriteLine($"Generated key: {newKey}");
                        break;

                    case "validate":
                        string key = message.GetProperty("key").GetString();
                        bool isValid = Array.IndexOf(validKeys, key) != -1;
                        SendResponse(new { valid = isValid });
                        System.Diagnostics.Debug.WriteLine($"Validated key: {key}, Valid: {isValid}");
                        break;
                }
            }
            catch (Exception ex)
            {
                SendResponse(new { error = $"Error processing message: {ex.Message}" });
                System.Diagnostics.Debug.WriteLine($"Message processing error: {ex}");
            }
        }

        private void SendResponse(object response)
        {
            string json = JsonSerializer.Serialize(response);
            Main.CoreWebView2.PostWebMessageAsJson(json);
            System.Diagnostics.Debug.WriteLine($"Sent response: {json}");
        }

        private string GenerateKey()
        {
            byte[] randomBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes).Replace("=", "").Replace("+", "-").Replace("/", "_");
        }

        private void Main_Click(object sender, EventArgs e)
        {
        }
    }
}