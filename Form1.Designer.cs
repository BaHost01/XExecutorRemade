namespace XExecutor
{
    partial class XExecutor
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.Killer = new Guna.UI2.WinForms.Guna2Button();
            this.Auto = new System.Windows.Forms.CheckBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.Run = new Guna.UI2.WinForms.Guna2Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.ver = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.Maroon;
            this.guna2Panel1.Controls.Add(this.ver);
            this.guna2Panel1.Controls.Add(this.Button2);
            this.guna2Panel1.Controls.Add(this.Button1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, -3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1040, 40);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            this.guna2Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseMove);
            this.guna2Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseUp);
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.Animated = true;
            this.Button2.BackColor = System.Drawing.Color.Transparent;
            this.Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button2.FillColor = System.Drawing.Color.Empty;
            this.Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button2.ForeColor = System.Drawing.Color.Red;
            this.Button2.Location = new System.Drawing.Point(974, 3);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(30, 27);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "-";
            this.Button2.UseTransparentBackground = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Animated = true;
            this.Button1.BackColor = System.Drawing.Color.Transparent;
            this.Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button1.FillColor = System.Drawing.Color.Empty;
            this.Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button1.ForeColor = System.Drawing.Color.Red;
            this.Button1.Location = new System.Drawing.Point(1010, 3);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(30, 27);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "X";
            this.Button1.UseTransparentBackground = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "XEXECUTOR REMADE";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Panel2.BackColor = System.Drawing.Color.Maroon;
            this.guna2Panel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel2.Controls.Add(this.Killer);
            this.guna2Panel2.Controls.Add(this.Auto);
            this.guna2Panel2.Controls.Add(this.guna2Button1);
            this.guna2Panel2.Controls.Add(this.Run);
            this.guna2Panel2.FillColor = System.Drawing.Color.Maroon;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 37);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(199, 540);
            this.guna2Panel2.TabIndex = 0;
            // 
            // consoleBox
            // 
            this.consoleBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.consoleBox.BackColor = System.Drawing.Color.Maroon;
            this.consoleBox.Location = new System.Drawing.Point(199, 515);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.Size = new System.Drawing.Size(841, 55);
            this.consoleBox.TabIndex = 5;
            this.consoleBox.Text = "";
            this.consoleBox.TextChanged += new System.EventHandler(this.consoleBox_TextChanged);
            // 
            // Killer
            // 
            this.Killer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Killer.Animated = true;
            this.Killer.BackColor = System.Drawing.Color.Transparent;
            this.Killer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Killer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Killer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Killer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Killer.FillColor = System.Drawing.Color.Empty;
            this.Killer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Killer.ForeColor = System.Drawing.Color.Red;
            this.Killer.Location = new System.Drawing.Point(50, 198);
            this.Killer.Name = "Killer";
            this.Killer.Size = new System.Drawing.Size(84, 45);
            this.Killer.TabIndex = 4;
            this.Killer.Text = "Kill Roblox";
            this.Killer.UseTransparentBackground = true;
            this.Killer.Click += new System.EventHandler(this.Killer_Click);
            // 
            // Auto
            // 
            this.Auto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Auto.BackColor = System.Drawing.Color.DarkRed;
            this.Auto.ForeColor = System.Drawing.Color.Gainsboro;
            this.Auto.Location = new System.Drawing.Point(3, 463);
            this.Auto.Name = "Auto";
            this.Auto.Size = new System.Drawing.Size(85, 19);
            this.Auto.TabIndex = 2;
            this.Auto.Text = "AT Injector";
            this.Auto.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Auto.UseVisualStyleBackColor = false;
            this.Auto.CheckedChanged += new System.EventHandler(this.Auto_CheckedChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2Button1.Animated = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Empty;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(57, 119);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(84, 45);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Attach";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // Run
            // 
            this.Run.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Run.Animated = true;
            this.Run.BackColor = System.Drawing.Color.Transparent;
            this.Run.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Run.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Run.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Run.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Run.FillColor = System.Drawing.Color.Empty;
            this.Run.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Run.ForeColor = System.Drawing.Color.White;
            this.Run.Location = new System.Drawing.Point(57, 46);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(84, 45);
            this.Run.TabIndex = 2;
            this.Run.Text = "EXECUTE";
            this.Run.UseTransparentBackground = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.webView21.Location = new System.Drawing.Point(199, 33);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(841, 486);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            this.webView21.Click += new System.EventHandler(this.webView21_Click);
            // 
            // ver
            // 
            this.ver.AutoSize = true;
            this.ver.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.ver.Location = new System.Drawing.Point(0, 17);
            this.ver.Name = "ver";
            this.ver.Size = new System.Drawing.Size(22, 13);
            this.ver.TabIndex = 3;
            this.ver.Text = "ver";
            this.ver.Click += new System.EventHandler(this.ver_Click);
            // 
            // XExecutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1040, 570);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XExecutor";
            this.Load += new System.EventHandler(this.XExecutor_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button Button1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button Run;
        private System.Windows.Forms.CheckBox Auto;
        private Guna.UI2.WinForms.Guna2Button Killer;
        private System.Windows.Forms.RichTextBox consoleBox;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Label ver;
    }
}

