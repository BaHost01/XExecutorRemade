using Microsoft.PowerBI.Api.Models;
using Newtonsoft.Json;
using RKOAPI_Xeno;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XExecutor
{
    public partial class XExecutor : Form
    {
        private Point lastPoint;

        public XExecutor()
        {
            InitializeComponent();
            MessageBox.Show("XExecutor is now using RKOAPI_Xeno as its backend. Please refer to the documentation for more details.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async void Attachwithapi()
        {

            if (RKOAPI_Xeno.RobloxUtils.IsRobloxRunning())
            {
                LogToConsole("Roblox Has been Detected", LogType.INFO);
                RKOAPI_Xeno.Modules.Inject();
                await ExecuteScriptAsync();

                LogToConsole("Sent Injection!", LogType.Success);
            }
            else
            {
                LogToConsole("Roblox not detected!", LogType.ERROR);
            }
        }





        private async Task CleaWhiteitor()
        {
            await webView21.CoreWebView2.ExecuteScriptAsync("window.celestiaEditor && window.celestiaEditor.clearText && window.celestiaEditor.clearText();");

        }

        private async Task SaveTextAsLua()
        {
            try
            {

                string jsResult = await webView21.CoreWebView2.ExecuteScriptAsync("window.celestiaEditor && window.celestiaEditor.editor && window.celestiaEditor.editor.getValue();");


                if (jsResult.Length >= 2 && jsResult[0] == '"' && jsResult[jsResult.Length - 1] == '"')
                {
                    jsResult = jsResult.Substring(1, jsResult.Length - 2);
                }

                string editorContent = jsResult
                    .Replace("\\n", "\n")
                    .Replace("\\r", "\r")
                    .Replace("\\t", "\t")
                    .Replace("\\\"", "\"")
                    .Replace("\\\\", "\\");

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    sfd.Title = "Save Script File";
                    sfd.FileName = "Script.lua";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, editorContent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTextFromFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All Files (*.*)|*.*|Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt";
                ofd.Title = "Open Script File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(ofd.FileName);

                        string escapedContent = fileContent
                            .Replace("\\", "\\\\")
                            .Replace("\"", "\\\"")
                            .Replace("\r", "")
                            .Replace("\n", "\\n");

                        if (webView21.CoreWebView2 != null)
                        {

                            await webView21.CoreWebView2.ExecuteScriptAsync($"window.celestiaEditor && window.celestiaEditor.setText && window.celestiaEditor.setText(\"{escapedContent}\");");
                        }
                        else
                        {
                            MessageBox.Show("Editor is not ready yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private async Task<string> GetEditorContent()
        {
            await webView21.EnsureCoreWebView2Async();
            string script = "monaco.editor.getModels()[0].getValue()";
            string result = await webView21.ExecuteScriptAsync(script);
            return JsonConvert.DeserializeObject<string>(result);
        }

        private async Task ExecuteScriptAsync()
        {
            string scriptcontent = await GetEditorContent();
            RKOAPI_Xeno.Modules.ExecuteScript(scriptcontent);

        }

        private async void Execute()
        {
            if (RKOAPI_Xeno.RobloxUtils.IsRobloxRunning())
            {


                if (RKOAPI_Xeno.Modules.InjectionCheck() == 1)
                {
                    await ExecuteScriptAsync();
                    LogToConsole("Sent Execution!", LogType.Success);
                }
                else if (RKOAPI_Xeno.Modules.InjectionCheck() == 1)
                {
                    LogToConsole("Not Injected!", LogType.ERROR);
                }
            }
            else
            {
                LogToConsole("Roblox Not Detected!", LogType.ERROR);
            }
        }

        private async void Startup()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Navigate(System.Windows.Forms.Application.StartupPath + "\\bin\\MonacoWithTabs\\monaco.html");
            try
            {
                string Exe = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string dir = Path.GetDirectoryName(Exe);
                var files = Directory.GetFiles(dir);
                string Executorn = Path.GetFileName(Exe);
                foreach (string file in files)
                {
                    string filename = Path.GetFileName(file);
                    if (filename.Equals(Executorn, StringComparison.OrdinalIgnoreCase))
                        continue;
                    try
                    {
                        File.SetAttributes(file, File.GetAttributes(file) | FileAttributes.Hidden);
                    }
                    catch { MessageBox.Show("Error on File configuration"); }
                }
            }
            catch { MessageBox.Show("Error on fetching files"); }
        }


        private void Minimize()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Exit()
        {
            System.Windows.Forms.Application.Exit();
        }

        public enum LogType
        {
            INFO,
            ERROR,
            Warning,
            Success
        }

        public static class ConsoleLogger
        {
            public static Color GetLogColor(LogType type)
            {
                if (type == LogType.INFO)
                    return Color.White;
                if (type == LogType.ERROR)
                    return Color.Red;
                if (type == LogType.Warning)
                    return Color.Yellow;
                if (type == LogType.Success)
                    return Color.Green;

                return Color.White;
            }
        }

        private void LogToConsole(string message, LogType type)
        {
            string timestamp = DateTime.Now.ToString("HH:mm");
            Color logColor = ConsoleLogger.GetLogColor(type);

            consoleBox.SelectionStart = consoleBox.TextLength;
            consoleBox.SelectionLength = 0;


            consoleBox.SelectionColor = logColor;
            consoleBox.AppendText($"[ {type} ]");


            consoleBox.SelectionColor = Color.White;
            consoleBox.AppendText($" [{timestamp}] ");


            consoleBox.SelectionColor = logColor;
            consoleBox.AppendText($"{message}\n");

            consoleBox.ScrollToCaret();
        }

        private void VersionCheck(string message)
        {
            try
            {
                // Path to local version file
                string localVerPath = Path.Combine(Application.StartupPath, "bin", "verexecutor.txt");

                // Read local version from file
                string localVer = File.Exists(localVerPath) ? File.ReadAllText(localVerPath).Trim() : "0.0.0";

                // Download remote version information
                string remoteData;
                using (var client = new System.Net.WebClient())
                {
                    remoteData = client.DownloadString("https://pastebin.com/FSg4MVXY").Trim();
                }

                // Parse remote data (assuming format: Version: X.X.X\nDownloadLink: url\nGitHub: url)
                string remoteVer = "0.0.0";
                string downloadLink = string.Empty;
                string gitHubLink = string.Empty;

                var lines = remoteData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    if (line.StartsWith("Version:", StringComparison.OrdinalIgnoreCase))
                        remoteVer = line.Substring("Version:".Length).Trim();
                    else if (line.StartsWith("DownloadLink:", StringComparison.OrdinalIgnoreCase))
                        downloadLink = line.Substring("DownloadLink:".Length).Trim();
                    else if (line.StartsWith("GitHub:", StringComparison.OrdinalIgnoreCase))
                        gitHubLink = line.Substring("GitHub:".Length).Trim();
                }

                // Compare versions
                Version localVersion = new Version(localVer);
                Version remoteVersion = new Version(remoteVer);
                int verComparison = localVersion.CompareTo(remoteVersion);

                if (verComparison < 0)
                {
                    // New version available
                    MessageBox.Show($"New version {remoteVer} available! {message}", "Update Available",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Attempt to open download link
                    try
                    {
                        if (!string.IsNullOrEmpty(downloadLink))
                        {
                            System.Diagnostics.Process.Start(downloadLink);
                        }
                        else
                        {
                            throw new Exception("Download link is empty.");
                        }
                    }
                    catch
                    {
                        // Fallback to GitHub link
                        if (!string.IsNullOrEmpty(gitHubLink))
                        {
                            MessageBox.Show("Download failed. Opening GitHub project page.", "Update Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            System.Diagnostics.Process.Start(gitHubLink);
                        }
                        else
                        {
                            MessageBox.Show("No download or GitHub link available.", "Update Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // No update needed
                    MessageBox.Show("You are running the latest version.", "No Update",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show($"Failed to check for updates: No internet connection. {ex.Message}",
                    "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastPoint = e.Location;
            }
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + e.X - lastPoint.X,
                    this.Location.Y + e.Y - lastPoint.Y
                );
            }
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // Empty, kept for consistency
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: custom painting
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Minimize();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Attachwithapi();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void Auto_CheckedChanged(object sender, EventArgs e)
        {
            RKOAPI_Xeno.Modules.UseAutoInject(Auto.Checked);
        }

        private void Killer_Click(object sender, EventArgs e)
        {
           
            
            }
    
        

        private void XExecutor_Load(object sender, EventArgs e)
        {

            Startup();
        }

 
    }
}