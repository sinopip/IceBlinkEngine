namespace IceBlink
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnFont = new IceBlink.IceBlinkButtonMedium();
            this.btnSaveGame = new IceBlink.IceBlinkButtonMedium();
            this.btnLoadGame = new IceBlink.IceBlinkButtonMedium();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chkAutosave = new System.Windows.Forms.CheckBox();
            this.numMovementDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new IceBlink.IceBlinkGroupBoxMedium();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSoundsVolume = new System.Windows.Forms.Label();
            this.tbrSounds = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMusicVolume = new System.Windows.Forms.Label();
            this.tbrMusic = new System.Windows.Forms.TrackBar();
            this.btnAbout = new IceBlink.IceBlinkButtonMedium();
            this.btnHotKeys = new IceBlink.IceBlinkButtonMedium();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFont
            // 
            this.btnFont.BackColor = System.Drawing.Color.Transparent;
            this.btnFont.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFont.BackgroundImage")));
            this.btnFont.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFont.DisabledImage = null;
            this.btnFont.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFont.FlatAppearance.BorderSize = 0;
            this.btnFont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFont.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnFont.HoverImage")));
            this.btnFont.Location = new System.Drawing.Point(55, 43);
            this.btnFont.Name = "btnFont";
            this.btnFont.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnFont.NormalImage")));
            this.btnFont.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnFont.PressedImage")));
            this.btnFont.Size = new System.Drawing.Size(120, 23);
            this.btnFont.TabIndex = 0;
            this.btnFont.TextIB = "CHOOSE FONT";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveGame.BackgroundImage")));
            this.btnSaveGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveGame.DisabledImage = null;
            this.btnSaveGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveGame.FlatAppearance.BorderSize = 0;
            this.btnSaveGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGame.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnSaveGame.HoverImage")));
            this.btnSaveGame.Location = new System.Drawing.Point(55, 71);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnSaveGame.NormalImage")));
            this.btnSaveGame.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnSaveGame.PressedImage")));
            this.btnSaveGame.Size = new System.Drawing.Size(120, 23);
            this.btnSaveGame.TabIndex = 1;
            this.btnSaveGame.TextIB = "SAVE GAME";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadGame.BackgroundImage")));
            this.btnLoadGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadGame.DisabledImage = null;
            this.btnLoadGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoadGame.FlatAppearance.BorderSize = 0;
            this.btnLoadGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoadGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadGame.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnLoadGame.HoverImage")));
            this.btnLoadGame.Location = new System.Drawing.Point(55, 99);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnLoadGame.NormalImage")));
            this.btnLoadGame.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnLoadGame.PressedImage")));
            this.btnLoadGame.Size = new System.Drawing.Size(120, 23);
            this.btnLoadGame.TabIndex = 2;
            this.btnLoadGame.TextIB = "LOAD GAME";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // chkAutosave
            // 
            this.chkAutosave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkAutosave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutosave.Location = new System.Drawing.Point(22, 178);
            this.chkAutosave.Name = "chkAutosave";
            this.chkAutosave.Size = new System.Drawing.Size(160, 20);
            this.chkAutosave.TabIndex = 3;
            this.chkAutosave.Text = "Autosave on each move";
            this.chkAutosave.UseVisualStyleBackColor = false;
            this.chkAutosave.Visible = false;
            this.chkAutosave.CheckedChanged += new System.EventHandler(this.chkAutosave_CheckedChanged);
            // 
            // numMovementDelay
            // 
            this.numMovementDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMovementDelay.Location = new System.Drawing.Point(154, 192);
            this.numMovementDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMovementDelay.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMovementDelay.Name = "numMovementDelay";
            this.numMovementDelay.Size = new System.Drawing.Size(55, 22);
            this.numMovementDelay.TabIndex = 4;
            this.numMovementDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMovementDelay.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numMovementDelay.Visible = false;
            this.numMovementDelay.ValueChanged += new System.EventHandler(this.numMovementDelay_ValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Movement Delay (ms):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.BorderColor = System.Drawing.Color.Empty;
            this.groupBox1.BorderThickness = 1F;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblSoundsVolume);
            this.groupBox1.Controls.Add(this.tbrSounds);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblMusicVolume);
            this.groupBox1.Controls.Add(this.tbrMusic);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.HeaderImage")));
            this.groupBox1.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(19, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 170);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music/Sound";
            this.groupBox1.TextIB = "iceBlinkGBMedium1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "SOUNDS VOLUME LEVEL";
            // 
            // lblSoundsVolume
            // 
            this.lblSoundsVolume.AutoSize = true;
            this.lblSoundsVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoundsVolume.Location = new System.Drawing.Point(149, 129);
            this.lblSoundsVolume.Name = "lblSoundsVolume";
            this.lblSoundsVolume.Size = new System.Drawing.Size(36, 20);
            this.lblSoundsVolume.TabIndex = 4;
            this.lblSoundsVolume.Text = "100";
            // 
            // tbrSounds
            // 
            this.tbrSounds.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbrSounds.LargeChange = 10;
            this.tbrSounds.Location = new System.Drawing.Point(11, 118);
            this.tbrSounds.Maximum = 100;
            this.tbrSounds.Name = "tbrSounds";
            this.tbrSounds.Size = new System.Drawing.Size(137, 45);
            this.tbrSounds.SmallChange = 5;
            this.tbrSounds.TabIndex = 3;
            this.tbrSounds.TickFrequency = 10;
            this.tbrSounds.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbrSounds.Scroll += new System.EventHandler(this.tbrSounds_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "MUSIC VOLUME LEVEL";
            // 
            // lblMusicVolume
            // 
            this.lblMusicVolume.AutoSize = true;
            this.lblMusicVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicVolume.Location = new System.Drawing.Point(149, 58);
            this.lblMusicVolume.Name = "lblMusicVolume";
            this.lblMusicVolume.Size = new System.Drawing.Size(36, 20);
            this.lblMusicVolume.TabIndex = 1;
            this.lblMusicVolume.Text = "100";
            // 
            // tbrMusic
            // 
            this.tbrMusic.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbrMusic.LargeChange = 10;
            this.tbrMusic.Location = new System.Drawing.Point(11, 47);
            this.tbrMusic.Maximum = 100;
            this.tbrMusic.Name = "tbrMusic";
            this.tbrMusic.Size = new System.Drawing.Size(137, 45);
            this.tbrMusic.SmallChange = 5;
            this.tbrMusic.TabIndex = 0;
            this.tbrMusic.TickFrequency = 10;
            this.tbrMusic.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbrMusic.Scroll += new System.EventHandler(this.tbrMusic_Scroll);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbout.BackgroundImage")));
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbout.DisabledImage = null;
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnAbout.HoverImage")));
            this.btnAbout.Location = new System.Drawing.Point(55, 155);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnAbout.NormalImage")));
            this.btnAbout.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnAbout.PressedImage")));
            this.btnAbout.Size = new System.Drawing.Size(120, 23);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.TextIB = "ABOUT";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnHotKeys
            // 
            this.btnHotKeys.BackColor = System.Drawing.Color.Transparent;
            this.btnHotKeys.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHotKeys.BackgroundImage")));
            this.btnHotKeys.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHotKeys.DisabledImage = null;
            this.btnHotKeys.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHotKeys.FlatAppearance.BorderSize = 0;
            this.btnHotKeys.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHotKeys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHotKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHotKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHotKeys.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnHotKeys.HoverImage")));
            this.btnHotKeys.Location = new System.Drawing.Point(55, 127);
            this.btnHotKeys.Name = "btnHotKeys";
            this.btnHotKeys.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnHotKeys.NormalImage")));
            this.btnHotKeys.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnHotKeys.PressedImage")));
            this.btnHotKeys.Size = new System.Drawing.Size(120, 23);
            this.btnHotKeys.TabIndex = 8;
            this.btnHotKeys.TextIB = "HOT KEYS";
            this.btnHotKeys.UseVisualStyleBackColor = true;
            this.btnHotKeys.Click += new System.EventHandler(this.btnHotKeys_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(232, 388);
            this.Controls.Add(this.btnHotKeys);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMovementDelay);
            this.Controls.Add(this.chkAutosave);
            this.Controls.Add(this.btnLoadGame);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.btnFont);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(232, 388);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(232, 388);
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SETTINGS FORM";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Controls.SetChildIndex(this.btnFont, 0);
            this.Controls.SetChildIndex(this.btnSaveGame, 0);
            this.Controls.SetChildIndex(this.btnLoadGame, 0);
            this.Controls.SetChildIndex(this.chkAutosave, 0);
            this.Controls.SetChildIndex(this.numMovementDelay, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnAbout, 0);
            this.Controls.SetChildIndex(this.btnHotKeys, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numMovementDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlinkButtonMedium btnFont;
        private IceBlinkButtonMedium btnSaveGame;
        private IceBlinkButtonMedium btnLoadGame;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chkAutosave;
        private System.Windows.Forms.NumericUpDown numMovementDelay;
        private System.Windows.Forms.Label label1;
        private IceBlinkGroupBoxMedium groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSoundsVolume;
        public System.Windows.Forms.TrackBar tbrSounds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMusicVolume;
        public System.Windows.Forms.TrackBar tbrMusic;
        private IceBlinkButtonMedium btnAbout;
        private IceBlinkButtonMedium btnHotKeys;

    }
}