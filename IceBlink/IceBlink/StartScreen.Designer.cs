namespace IceBlink
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnSize1 = new System.Windows.Forms.RadioButton();
            this.rbtnSize2 = new System.Windows.Forms.RadioButton();
            this.rbtnSize3 = new System.Windows.Forms.RadioButton();
            this.rbtnSize4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ibtnExit = new IceBlink.IceBlinkButtonMedium();
            this.ibtnSavedGame = new IceBlink.IceBlinkButtonMedium();
            this.ibtnNewGame = new IceBlink.IceBlinkButtonMedium();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "IceBlink Engine";
            // 
            // rbtnSize1
            // 
            this.rbtnSize1.AutoSize = true;
            this.rbtnSize1.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSize1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSize1.ForeColor = System.Drawing.Color.Black;
            this.rbtnSize1.Location = new System.Drawing.Point(6, 26);
            this.rbtnSize1.Name = "rbtnSize1";
            this.rbtnSize1.Size = new System.Drawing.Size(176, 19);
            this.rbtnSize1.TabIndex = 7;
            this.rbtnSize1.TabStop = true;
            this.rbtnSize1.Text = "1000 x 600 (12 x 7 squares)";
            this.rbtnSize1.UseVisualStyleBackColor = false;
            this.rbtnSize1.CheckedChanged += new System.EventHandler(this.rbtnSize1_CheckedChanged);
            // 
            // rbtnSize2
            // 
            this.rbtnSize2.AutoSize = true;
            this.rbtnSize2.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSize2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSize2.ForeColor = System.Drawing.Color.Black;
            this.rbtnSize2.Location = new System.Drawing.Point(6, 46);
            this.rbtnSize2.Name = "rbtnSize2";
            this.rbtnSize2.Size = new System.Drawing.Size(176, 19);
            this.rbtnSize2.TabIndex = 8;
            this.rbtnSize2.TabStop = true;
            this.rbtnSize2.Text = "1200 x 700 (16 x 9 squares)";
            this.rbtnSize2.UseVisualStyleBackColor = false;
            this.rbtnSize2.CheckedChanged += new System.EventHandler(this.rbtnSize2_CheckedChanged);
            // 
            // rbtnSize3
            // 
            this.rbtnSize3.AutoSize = true;
            this.rbtnSize3.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSize3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSize3.ForeColor = System.Drawing.Color.Black;
            this.rbtnSize3.Location = new System.Drawing.Point(6, 66);
            this.rbtnSize3.Name = "rbtnSize3";
            this.rbtnSize3.Size = new System.Drawing.Size(183, 19);
            this.rbtnSize3.TabIndex = 9;
            this.rbtnSize3.TabStop = true;
            this.rbtnSize3.Text = "1400 x 800 (19 x 10 squares)";
            this.rbtnSize3.UseVisualStyleBackColor = false;
            this.rbtnSize3.CheckedChanged += new System.EventHandler(this.rbtnSize3_CheckedChanged);
            // 
            // rbtnSize4
            // 
            this.rbtnSize4.AutoSize = true;
            this.rbtnSize4.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSize4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSize4.ForeColor = System.Drawing.Color.Black;
            this.rbtnSize4.Location = new System.Drawing.Point(6, 86);
            this.rbtnSize4.Name = "rbtnSize4";
            this.rbtnSize4.Size = new System.Drawing.Size(131, 19);
            this.rbtnSize4.TabIndex = 10;
            this.rbtnSize4.TabStop = true;
            this.rbtnSize4.Text = "Maximized Window";
            this.rbtnSize4.UseVisualStyleBackColor = false;
            this.rbtnSize4.CheckedChanged += new System.EventHandler(this.rbtnSize4_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbtnSize4);
            this.panel1.Controls.Add(this.rbtnSize2);
            this.panel1.Controls.Add(this.rbtnSize1);
            this.panel1.Controls.Add(this.rbtnSize3);
            this.panel1.Location = new System.Drawing.Point(12, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 113);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Game Window Size";
            // 
            // ibtnExit
            // 
            this.ibtnExit.BackColor = System.Drawing.Color.Transparent;
            this.ibtnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ibtnExit.BackgroundImage")));
            this.ibtnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ibtnExit.DisabledImage = null;
            this.ibtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnExit.FlatAppearance.BorderSize = 0;
            this.ibtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnExit.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ibtnExit.HoverImage = ((System.Drawing.Image)(resources.GetObject("ibtnExit.HoverImage")));
            this.ibtnExit.Location = new System.Drawing.Point(30, 141);
            this.ibtnExit.Name = "ibtnExit";
            this.ibtnExit.NormalImage = ((System.Drawing.Image)(resources.GetObject("ibtnExit.NormalImage")));
            this.ibtnExit.PressedImage = ((System.Drawing.Image)(resources.GetObject("ibtnExit.PressedImage")));
            this.ibtnExit.Size = new System.Drawing.Size(150, 30);
            this.ibtnExit.TabIndex = 6;
            this.ibtnExit.TextIB = "EXIT";
            this.ibtnExit.UseVisualStyleBackColor = false;
            this.ibtnExit.Click += new System.EventHandler(this.ibtnExit_Click);
            // 
            // ibtnSavedGame
            // 
            this.ibtnSavedGame.BackColor = System.Drawing.Color.Transparent;
            this.ibtnSavedGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ibtnSavedGame.BackgroundImage")));
            this.ibtnSavedGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ibtnSavedGame.DisabledImage = null;
            this.ibtnSavedGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnSavedGame.FlatAppearance.BorderSize = 0;
            this.ibtnSavedGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnSavedGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnSavedGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnSavedGame.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnSavedGame.HoverImage = ((System.Drawing.Image)(resources.GetObject("ibtnSavedGame.HoverImage")));
            this.ibtnSavedGame.Location = new System.Drawing.Point(30, 105);
            this.ibtnSavedGame.Name = "ibtnSavedGame";
            this.ibtnSavedGame.NormalImage = ((System.Drawing.Image)(resources.GetObject("ibtnSavedGame.NormalImage")));
            this.ibtnSavedGame.PressedImage = ((System.Drawing.Image)(resources.GetObject("ibtnSavedGame.PressedImage")));
            this.ibtnSavedGame.Size = new System.Drawing.Size(150, 30);
            this.ibtnSavedGame.TabIndex = 5;
            this.ibtnSavedGame.TextIB = "LOAD SAVED GAME";
            this.ibtnSavedGame.UseVisualStyleBackColor = false;
            this.ibtnSavedGame.Click += new System.EventHandler(this.ibtnSavedGame_Click);
            // 
            // ibtnNewGame
            // 
            this.ibtnNewGame.BackColor = System.Drawing.Color.Transparent;
            this.ibtnNewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ibtnNewGame.BackgroundImage")));
            this.ibtnNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ibtnNewGame.DisabledImage = null;
            this.ibtnNewGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnNewGame.FlatAppearance.BorderSize = 0;
            this.ibtnNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ibtnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnNewGame.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtnNewGame.HoverImage = ((System.Drawing.Image)(resources.GetObject("ibtnNewGame.HoverImage")));
            this.ibtnNewGame.Location = new System.Drawing.Point(30, 69);
            this.ibtnNewGame.Name = "ibtnNewGame";
            this.ibtnNewGame.NormalImage = ((System.Drawing.Image)(resources.GetObject("ibtnNewGame.NormalImage")));
            this.ibtnNewGame.PressedImage = ((System.Drawing.Image)(resources.GetObject("ibtnNewGame.PressedImage")));
            this.ibtnNewGame.Size = new System.Drawing.Size(150, 30);
            this.ibtnNewGame.TabIndex = 4;
            this.ibtnNewGame.TextIB = "START NEW GAME";
            this.ibtnNewGame.UseVisualStyleBackColor = false;
            this.ibtnNewGame.Click += new System.EventHandler(this.ibtnNewGame_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(59, 185);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(95, 16);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Text = "IceBlink v0.1";
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::IceBlink.Properties.Resources.standard;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(212, 334);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ibtnExit);
            this.Controls.Add(this.ibtnSavedGame);
            this.Controls.Add(this.ibtnNewGame);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(218, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(218, 199);
            this.Name = "StartScreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private IceBlink.IceBlinkButtonMedium ibtnNewGame;
        private IceBlink.IceBlinkButtonMedium ibtnSavedGame;
        private IceBlink.IceBlinkButtonMedium ibtnExit;
        private System.Windows.Forms.RadioButton rbtnSize1;
        private System.Windows.Forms.RadioButton rbtnSize2;
        private System.Windows.Forms.RadioButton rbtnSize3;
        private System.Windows.Forms.RadioButton rbtnSize4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
    }
}