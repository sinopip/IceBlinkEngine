namespace IceBlink
{
    partial class SpellSelectMainMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellSelectMainMap));
            this.gbSpellList = new IceBlink.IceBlinkGroupBoxMedium();
            this.gbSpellDesc = new IceBlink.IceBlinkGroupBoxMedium();
            this.rtxtSpellDescription = new System.Windows.Forms.RichTextBox();
            this.gbPcSelect = new IceBlink.IceBlinkGroupBoxMedium();
            this.btnSelectMapPoint = new IceBlink.IceBlinkButtonLarge();
            this.rbtnPc5 = new System.Windows.Forms.RadioButton();
            this.rbtnPc4 = new System.Windows.Forms.RadioButton();
            this.rbtnPc3 = new System.Windows.Forms.RadioButton();
            this.rbtnPc2 = new System.Windows.Forms.RadioButton();
            this.rbtnPc1 = new System.Windows.Forms.RadioButton();
            this.rbtnPc0 = new System.Windows.Forms.RadioButton();
            this.gbSpellDesc.SuspendLayout();
            this.gbPcSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSpellList
            // 
            this.gbSpellList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSpellList.BackColor = System.Drawing.Color.Transparent;
            this.gbSpellList.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbSpellList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbSpellList.BorderThickness = 2F;
            this.gbSpellList.HeaderForeColor = System.Drawing.Color.White;
            this.gbSpellList.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gbSpellList.HeaderImage")));
            this.gbSpellList.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbSpellList.Location = new System.Drawing.Point(12, 36);
            this.gbSpellList.Name = "gbSpellList";
            this.gbSpellList.Size = new System.Drawing.Size(213, 270);
            this.gbSpellList.TabIndex = 7;
            this.gbSpellList.TabStop = false;
            this.gbSpellList.Text = "Known Spells";
            this.gbSpellList.TextIB = "iceBlinkGBMedium1";
            // 
            // gbSpellDesc
            // 
            this.gbSpellDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSpellDesc.BackColor = System.Drawing.Color.Transparent;
            this.gbSpellDesc.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbSpellDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbSpellDesc.BorderThickness = 2F;
            this.gbSpellDesc.Controls.Add(this.rtxtSpellDescription);
            this.gbSpellDesc.HeaderForeColor = System.Drawing.Color.White;
            this.gbSpellDesc.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gbSpellDesc.HeaderImage")));
            this.gbSpellDesc.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbSpellDesc.Location = new System.Drawing.Point(231, 36);
            this.gbSpellDesc.Name = "gbSpellDesc";
            this.gbSpellDesc.Size = new System.Drawing.Size(215, 270);
            this.gbSpellDesc.TabIndex = 6;
            this.gbSpellDesc.TabStop = false;
            this.gbSpellDesc.Text = "Spell Description";
            this.gbSpellDesc.TextIB = "iceBlinkGBMedium1";
            // 
            // rtxtSpellDescription
            // 
            this.rtxtSpellDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtSpellDescription.Location = new System.Drawing.Point(6, 30);
            this.rtxtSpellDescription.Name = "rtxtSpellDescription";
            this.rtxtSpellDescription.Size = new System.Drawing.Size(203, 234);
            this.rtxtSpellDescription.TabIndex = 1;
            this.rtxtSpellDescription.Text = "";
            // 
            // gbPcSelect
            // 
            this.gbPcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPcSelect.BackColor = System.Drawing.Color.Transparent;
            this.gbPcSelect.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbPcSelect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbPcSelect.BorderThickness = 2F;
            this.gbPcSelect.Controls.Add(this.btnSelectMapPoint);
            this.gbPcSelect.Controls.Add(this.rbtnPc5);
            this.gbPcSelect.Controls.Add(this.rbtnPc4);
            this.gbPcSelect.Controls.Add(this.rbtnPc3);
            this.gbPcSelect.Controls.Add(this.rbtnPc2);
            this.gbPcSelect.Controls.Add(this.rbtnPc1);
            this.gbPcSelect.Controls.Add(this.rbtnPc0);
            this.gbPcSelect.HeaderForeColor = System.Drawing.Color.White;
            this.gbPcSelect.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gbPcSelect.HeaderImage")));
            this.gbPcSelect.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbPcSelect.Location = new System.Drawing.Point(70, 36);
            this.gbPcSelect.Name = "gbPcSelect";
            this.gbPcSelect.Size = new System.Drawing.Size(319, 270);
            this.gbPcSelect.TabIndex = 8;
            this.gbPcSelect.TabStop = false;
            this.gbPcSelect.Text = "SELECT THE TARGET PC";
            this.gbPcSelect.TextIB = "iceBlinkGBMedium1";
            // 
            // btnSelectMapPoint
            // 
            this.btnSelectMapPoint.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectMapPoint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectMapPoint.BackgroundImage")));
            this.btnSelectMapPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelectMapPoint.DisabledImage = null;
            this.btnSelectMapPoint.Enabled = false;
            this.btnSelectMapPoint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelectMapPoint.FlatAppearance.BorderSize = 0;
            this.btnSelectMapPoint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelectMapPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelectMapPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMapPoint.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnSelectMapPoint.HoverImage")));
            this.btnSelectMapPoint.Location = new System.Drawing.Point(79, 210);
            this.btnSelectMapPoint.Name = "btnSelectMapPoint";
            this.btnSelectMapPoint.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnSelectMapPoint.NormalImage")));
            this.btnSelectMapPoint.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnSelectMapPoint.PressedImage")));
            this.btnSelectMapPoint.Size = new System.Drawing.Size(164, 38);
            this.btnSelectMapPoint.TabIndex = 61;
            this.btnSelectMapPoint.TextIB = "SELECT TARGET ON MAP";
            this.btnSelectMapPoint.UseVisualStyleBackColor = true;
            this.btnSelectMapPoint.Click += new System.EventHandler(this.btnSelectMapPoint_Click);
            // 
            // rbtnPc5
            // 
            this.rbtnPc5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc5.BackgroundImage")));
            this.rbtnPc5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc5.Enabled = false;
            this.rbtnPc5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc5.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc5.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc5.Location = new System.Drawing.Point(199, 128);
            this.rbtnPc5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc5.Name = "rbtnPc5";
            this.rbtnPc5.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc5.TabIndex = 48;
            this.rbtnPc5.TabStop = true;
            this.rbtnPc5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc5.UseVisualStyleBackColor = true;
            this.rbtnPc5.Visible = false;
            this.rbtnPc5.CheckedChanged += new System.EventHandler(this.rbtnPc5_CheckedChanged);
            // 
            // rbtnPc4
            // 
            this.rbtnPc4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc4.BackgroundImage")));
            this.rbtnPc4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc4.Enabled = false;
            this.rbtnPc4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc4.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc4.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc4.Location = new System.Drawing.Point(139, 128);
            this.rbtnPc4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc4.Name = "rbtnPc4";
            this.rbtnPc4.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc4.TabIndex = 47;
            this.rbtnPc4.TabStop = true;
            this.rbtnPc4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc4.UseVisualStyleBackColor = true;
            this.rbtnPc4.Visible = false;
            this.rbtnPc4.CheckedChanged += new System.EventHandler(this.rbtnPc4_CheckedChanged);
            // 
            // rbtnPc3
            // 
            this.rbtnPc3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc3.BackgroundImage")));
            this.rbtnPc3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc3.Enabled = false;
            this.rbtnPc3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc3.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc3.Location = new System.Drawing.Point(79, 128);
            this.rbtnPc3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc3.Name = "rbtnPc3";
            this.rbtnPc3.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc3.TabIndex = 46;
            this.rbtnPc3.TabStop = true;
            this.rbtnPc3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc3.UseVisualStyleBackColor = true;
            this.rbtnPc3.Visible = false;
            this.rbtnPc3.CheckedChanged += new System.EventHandler(this.rbtnPc3_CheckedChanged);
            // 
            // rbtnPc2
            // 
            this.rbtnPc2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc2.BackgroundImage")));
            this.rbtnPc2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc2.Enabled = false;
            this.rbtnPc2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc2.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc2.Location = new System.Drawing.Point(199, 47);
            this.rbtnPc2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc2.Name = "rbtnPc2";
            this.rbtnPc2.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc2.TabIndex = 45;
            this.rbtnPc2.TabStop = true;
            this.rbtnPc2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc2.UseVisualStyleBackColor = true;
            this.rbtnPc2.Visible = false;
            this.rbtnPc2.CheckedChanged += new System.EventHandler(this.rbtnPc2_CheckedChanged);
            // 
            // rbtnPc1
            // 
            this.rbtnPc1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc1.BackgroundImage")));
            this.rbtnPc1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc1.Enabled = false;
            this.rbtnPc1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc1.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc1.Location = new System.Drawing.Point(139, 47);
            this.rbtnPc1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc1.Name = "rbtnPc1";
            this.rbtnPc1.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc1.TabIndex = 44;
            this.rbtnPc1.TabStop = true;
            this.rbtnPc1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc1.UseVisualStyleBackColor = true;
            this.rbtnPc1.Visible = false;
            this.rbtnPc1.CheckedChanged += new System.EventHandler(this.rbtnPc1_CheckedChanged);
            // 
            // rbtnPc0
            // 
            this.rbtnPc0.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc0.BackgroundImage")));
            this.rbtnPc0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc0.Enabled = false;
            this.rbtnPc0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc0.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc0.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc0.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc0.Location = new System.Drawing.Point(79, 47);
            this.rbtnPc0.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc0.Name = "rbtnPc0";
            this.rbtnPc0.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc0.TabIndex = 43;
            this.rbtnPc0.TabStop = true;
            this.rbtnPc0.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc0.UseVisualStyleBackColor = true;
            this.rbtnPc0.Visible = false;
            this.rbtnPc0.CheckedChanged += new System.EventHandler(this.rbtnPc0_CheckedChanged);
            // 
            // SpellSelectMainMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(458, 319);
            this.Controls.Add(this.gbPcSelect);
            this.Controls.Add(this.gbSpellList);
            this.Controls.Add(this.gbSpellDesc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(458, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(458, 319);
            this.Name = "SpellSelectMainMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spell Select";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.gbSpellDesc, 0);
            this.Controls.SetChildIndex(this.gbSpellList, 0);
            this.Controls.SetChildIndex(this.gbPcSelect, 0);
            this.gbSpellDesc.ResumeLayout(false);
            this.gbPcSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlinkGroupBoxMedium gbSpellList;
        private IceBlinkGroupBoxMedium gbSpellDesc;
        private System.Windows.Forms.RichTextBox rtxtSpellDescription;
        private IceBlinkGroupBoxMedium gbPcSelect;
        public System.Windows.Forms.RadioButton rbtnPc5;
        public System.Windows.Forms.RadioButton rbtnPc4;
        public System.Windows.Forms.RadioButton rbtnPc3;
        public System.Windows.Forms.RadioButton rbtnPc2;
        public System.Windows.Forms.RadioButton rbtnPc1;
        public System.Windows.Forms.RadioButton rbtnPc0;
        private IceBlinkButtonLarge btnSelectMapPoint;
    }
}