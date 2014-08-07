namespace IceBlink
{
    partial class FontSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontSelection));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFontSelect = new IceBlink.IceBlinkButtonMedium();
            this.btnTestFont = new IceBlink.IceBlinkButtonMedium();
            this.numFontScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new IceBlink.IBPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontScale)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 50);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "This is the new  font size ABC0123456789";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "This is the standard size ABC0123456789";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 50);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(2, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "This is the new  font size ABC0123456789";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(2, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "This is the standard size ABC0123456789";
            // 
            // btnFontSelect
            // 
            this.btnFontSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnFontSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFontSelect.BackgroundImage")));
            this.btnFontSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFontSelect.DisabledImage = null;
            this.btnFontSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFontSelect.FlatAppearance.BorderSize = 0;
            this.btnFontSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFontSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFontSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFontSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFontSelect.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnFontSelect.HoverImage")));
            this.btnFontSelect.Location = new System.Drawing.Point(12, 230);
            this.btnFontSelect.Name = "btnFontSelect";
            this.btnFontSelect.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnFontSelect.NormalImage")));
            this.btnFontSelect.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnFontSelect.PressedImage")));
            this.btnFontSelect.Size = new System.Drawing.Size(120, 26);
            this.btnFontSelect.TabIndex = 2;
            this.btnFontSelect.TextIB = "Font Selection";
            this.btnFontSelect.UseVisualStyleBackColor = true;
            this.btnFontSelect.Click += new System.EventHandler(this.btnFontSelect_Click);
            // 
            // btnTestFont
            // 
            this.btnTestFont.BackColor = System.Drawing.Color.Transparent;
            this.btnTestFont.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestFont.BackgroundImage")));
            this.btnTestFont.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTestFont.DisabledImage = null;
            this.btnTestFont.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTestFont.FlatAppearance.BorderSize = 0;
            this.btnTestFont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTestFont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTestFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestFont.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnTestFont.HoverImage")));
            this.btnTestFont.Location = new System.Drawing.Point(133, 230);
            this.btnTestFont.Name = "btnTestFont";
            this.btnTestFont.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnTestFont.NormalImage")));
            this.btnTestFont.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnTestFont.PressedImage")));
            this.btnTestFont.Size = new System.Drawing.Size(93, 26);
            this.btnTestFont.TabIndex = 3;
            this.btnTestFont.TextIB = "Test Font";
            this.btnTestFont.UseVisualStyleBackColor = true;
            this.btnTestFont.Click += new System.EventHandler(this.btnTestFont_Click);
            // 
            // numFontScale
            // 
            this.numFontScale.DecimalPlaces = 2;
            this.numFontScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFontScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFontScale.Location = new System.Drawing.Point(229, 231);
            this.numFontScale.Name = "numFontScale";
            this.numFontScale.Size = new System.Drawing.Size(56, 22);
            this.numFontScale.TabIndex = 4;
            this.numFontScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFontScale.ValueChanged += new System.EventHandler(this.numFontScale_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "scale\r\nshadow\r\nfont";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(12, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 43);
            this.panel3.TabIndex = 6;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // FontSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IceBlink.Properties.Resources.standard;
            this.ClientSize = new System.Drawing.Size(360, 283);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numFontScale);
            this.Controls.Add(this.btnTestFont);
            this.Controls.Add(this.btnFontSelect);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 283);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 283);
            this.Name = "FontSelection";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font Selection";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnFontSelect, 0);
            this.Controls.SetChildIndex(this.btnTestFont, 0);
            this.Controls.SetChildIndex(this.numFontScale, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private IceBlinkButtonMedium btnFontSelect;
        private IceBlinkButtonMedium btnTestFont;
        private System.Windows.Forms.NumericUpDown numFontScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Timer timer1;
        private IBPanel panel3;
    }
}