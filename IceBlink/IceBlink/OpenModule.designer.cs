namespace IceBlink
{
    partial class OpenModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenModule));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new IceBlink.IceBlinkButtonLarge();
            this.iceBlinkGroupBoxMedium1 = new IceBlink.IceBlinkGroupBoxMedium();
            this.iceBlinkGroupBoxMedium2 = new IceBlink.IceBlinkGroupBoxMedium();
            this.iceBlinkGroupBoxMedium1.SuspendLayout();
            this.iceBlinkGroupBoxMedium2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(9, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(246, 166);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 36);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(279, 166);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DisabledImage = null;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.HoverImage = ((System.Drawing.Image)(resources.GetObject("button1.HoverImage")));
            this.button1.Location = new System.Drawing.Point(152, 235);
            this.button1.Name = "button1";
            this.button1.NormalImage = ((System.Drawing.Image)(resources.GetObject("button1.NormalImage")));
            this.button1.PressedImage = ((System.Drawing.Image)(resources.GetObject("button1.PressedImage")));
            this.button1.Size = new System.Drawing.Size(278, 34);
            this.button1.TabIndex = 5;
            this.button1.TextIB = "OPEN SELECTED MODULE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iceBlinkGroupBoxMedium1
            // 
            this.iceBlinkGroupBoxMedium1.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium1.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium1.Controls.Add(this.listBox1);
            this.iceBlinkGroupBoxMedium1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium1.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium1.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium1.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium1.Location = new System.Drawing.Point(12, 14);
            this.iceBlinkGroupBoxMedium1.Name = "iceBlinkGroupBoxMedium1";
            this.iceBlinkGroupBoxMedium1.Size = new System.Drawing.Size(261, 213);
            this.iceBlinkGroupBoxMedium1.TabIndex = 92;
            this.iceBlinkGroupBoxMedium1.TabStop = false;
            this.iceBlinkGroupBoxMedium1.Text = "AVAILABLE MODULES";
            this.iceBlinkGroupBoxMedium1.TextIB = "";
            // 
            // iceBlinkGroupBoxMedium2
            // 
            this.iceBlinkGroupBoxMedium2.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium2.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium2.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium2.Controls.Add(this.richTextBox1);
            this.iceBlinkGroupBoxMedium2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium2.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium2.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium2.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium2.Location = new System.Drawing.Point(279, 14);
            this.iceBlinkGroupBoxMedium2.Name = "iceBlinkGroupBoxMedium2";
            this.iceBlinkGroupBoxMedium2.Size = new System.Drawing.Size(293, 213);
            this.iceBlinkGroupBoxMedium2.TabIndex = 93;
            this.iceBlinkGroupBoxMedium2.TabStop = false;
            this.iceBlinkGroupBoxMedium2.Text = "MODULE DESCRIPTION";
            this.iceBlinkGroupBoxMedium2.TextIB = "";
            // 
            // OpenModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(583, 278);
            this.ControlBox = false;
            this.Controls.Add(this.iceBlinkGroupBoxMedium2);
            this.Controls.Add(this.iceBlinkGroupBoxMedium1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(585, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(585, 280);
            this.Name = "OpenModule";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.iceBlinkGroupBoxMedium1.ResumeLayout(false);
            this.iceBlinkGroupBoxMedium2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        //private System.Windows.Forms.Button button1;
        private IceBlink.IceBlinkButtonLarge button1;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium1;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium2;
    }
}