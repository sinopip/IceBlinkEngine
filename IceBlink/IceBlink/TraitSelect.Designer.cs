namespace IceBlink
{
    partial class TraitSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraitSelect));
            this.gbTraitSpellList = new IceBlink.IceBlinkGroupBoxMedium();
            this.groupBox1 = new IceBlink.IceBlinkGroupBoxMedium();
            this.rtxtTraitDescription = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTraitSpellList
            // 
            this.gbTraitSpellList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTraitSpellList.BackColor = System.Drawing.Color.Transparent;
            this.gbTraitSpellList.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbTraitSpellList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbTraitSpellList.BorderThickness = 2F;
            this.gbTraitSpellList.HeaderForeColor = System.Drawing.Color.White;
            this.gbTraitSpellList.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gbTraitSpellList.HeaderImage")));
            this.gbTraitSpellList.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbTraitSpellList.Location = new System.Drawing.Point(12, 35);
            this.gbTraitSpellList.Name = "gbTraitSpellList";
            this.gbTraitSpellList.Size = new System.Drawing.Size(213, 270);
            this.gbTraitSpellList.TabIndex = 7;
            this.gbTraitSpellList.TabStop = false;
            this.gbTraitSpellList.Text = "Known Traits";
            this.gbTraitSpellList.TextIB = "iceBlinkGBMedium1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.BorderThickness = 2F;
            this.groupBox1.Controls.Add(this.rtxtTraitDescription);
            this.groupBox1.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.HeaderImage")));
            this.groupBox1.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(231, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 270);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trait Description";
            this.groupBox1.TextIB = "iceBlinkGBMedium1";
            // 
            // rtxtTraitDescription
            // 
            this.rtxtTraitDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtTraitDescription.Location = new System.Drawing.Point(6, 30);
            this.rtxtTraitDescription.Name = "rtxtTraitDescription";
            this.rtxtTraitDescription.Size = new System.Drawing.Size(203, 234);
            this.rtxtTraitDescription.TabIndex = 1;
            this.rtxtTraitDescription.Text = "";
            // 
            // TraitSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(458, 318);
            this.Controls.Add(this.gbTraitSpellList);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(458, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(458, 318);
            this.Name = "TraitSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trait Select";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.gbTraitSpellList, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlinkGroupBoxMedium gbTraitSpellList;
        private IceBlinkGroupBoxMedium groupBox1;
        private System.Windows.Forms.RichTextBox rtxtTraitDescription;
    }
}