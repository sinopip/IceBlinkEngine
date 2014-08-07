namespace IceBlink
{
    partial class Debug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Debug));
            this.btnConsoleScript = new IceBlink.IceBlinkButtonMedium();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsoleScript = new System.Windows.Forms.TextBox();
            this.rtxtMainLog = new System.Windows.Forms.RichTextBox();
            this.btnResetCompiledScripts = new IceBlink.IceBlinkButtonMedium();
            this.SuspendLayout();
            // 
            // btnConsoleScript
            // 
            this.btnConsoleScript.BackColor = System.Drawing.Color.Transparent;
            this.btnConsoleScript.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsoleScript.BackgroundImage")));
            this.btnConsoleScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsoleScript.DisabledImage = null;
            this.btnConsoleScript.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConsoleScript.FlatAppearance.BorderSize = 0;
            this.btnConsoleScript.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConsoleScript.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConsoleScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsoleScript.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnConsoleScript.HoverImage")));
            this.btnConsoleScript.Location = new System.Drawing.Point(12, 400);
            this.btnConsoleScript.Name = "btnConsoleScript";
            this.btnConsoleScript.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnConsoleScript.NormalImage")));
            this.btnConsoleScript.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnConsoleScript.PressedImage")));
            this.btnConsoleScript.Size = new System.Drawing.Size(193, 23);
            this.btnConsoleScript.TabIndex = 32;
            this.btnConsoleScript.TextIB = "Run Script";
            this.btnConsoleScript.UseVisualStyleBackColor = true;
            this.btnConsoleScript.Click += new System.EventHandler(this.btnConsoleScript_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(14, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Script filename to run:";
            // 
            // txtConsoleScript
            // 
            this.txtConsoleScript.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtConsoleScript.Location = new System.Drawing.Point(12, 377);
            this.txtConsoleScript.Name = "txtConsoleScript";
            this.txtConsoleScript.Size = new System.Drawing.Size(193, 20);
            this.txtConsoleScript.TabIndex = 30;
            this.txtConsoleScript.TextChanged += new System.EventHandler(this.txtConsoleScript_TextChanged);
            // 
            // rtxtMainLog
            // 
            this.rtxtMainLog.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.rtxtMainLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtMainLog.Location = new System.Drawing.Point(12, 36);
            this.rtxtMainLog.Name = "rtxtMainLog";
            this.rtxtMainLog.ReadOnly = true;
            this.rtxtMainLog.Size = new System.Drawing.Size(193, 320);
            this.rtxtMainLog.TabIndex = 29;
            this.rtxtMainLog.Text = "";
            // 
            // btnResetCompiledScripts
            // 
            this.btnResetCompiledScripts.BackColor = System.Drawing.Color.Transparent;
            this.btnResetCompiledScripts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResetCompiledScripts.BackgroundImage")));
            this.btnResetCompiledScripts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResetCompiledScripts.DisabledImage = null;
            this.btnResetCompiledScripts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnResetCompiledScripts.FlatAppearance.BorderSize = 0;
            this.btnResetCompiledScripts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnResetCompiledScripts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnResetCompiledScripts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetCompiledScripts.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnResetCompiledScripts.HoverImage")));
            this.btnResetCompiledScripts.Location = new System.Drawing.Point(12, 430);
            this.btnResetCompiledScripts.Name = "btnResetCompiledScripts";
            this.btnResetCompiledScripts.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnResetCompiledScripts.NormalImage")));
            this.btnResetCompiledScripts.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnResetCompiledScripts.PressedImage")));
            this.btnResetCompiledScripts.Size = new System.Drawing.Size(193, 23);
            this.btnResetCompiledScripts.TabIndex = 33;
            this.btnResetCompiledScripts.TextIB = "Clear Compiled Script List";
            this.btnResetCompiledScripts.UseVisualStyleBackColor = true;
            this.btnResetCompiledScripts.Click += new System.EventHandler(this.btnResetCompiledScripts_Click);
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(216, 465);
            this.Controls.Add(this.btnResetCompiledScripts);
            this.Controls.Add(this.btnConsoleScript);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConsoleScript);
            this.Controls.Add(this.rtxtMainLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Debug";
            this.Text = "Debug";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Debug_FormClosing);
            this.Controls.SetChildIndex(this.rtxtMainLog, 0);
            this.Controls.SetChildIndex(this.txtConsoleScript, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnConsoleScript, 0);
            this.Controls.SetChildIndex(this.btnResetCompiledScripts, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IceBlinkButtonMedium btnConsoleScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConsoleScript;
        public System.Windows.Forms.RichTextBox rtxtMainLog;
        private IceBlinkButtonMedium btnResetCompiledScripts;
    }
}