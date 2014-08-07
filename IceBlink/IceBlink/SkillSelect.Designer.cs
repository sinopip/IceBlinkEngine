namespace IceBlink
{
    partial class SkillSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillSelect));
            this.gbSpellList = new IceBlink.IceBlinkGroupBoxMedium();
            this.gbSkillDesc = new IceBlink.IceBlinkGroupBoxMedium();
            this.rtxtSkillDescription = new System.Windows.Forms.RichTextBox();
            this.gbSkillDesc.SuspendLayout();
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
            this.gbSpellList.Location = new System.Drawing.Point(12, 37);
            this.gbSpellList.Name = "gbSpellList";
            this.gbSpellList.Size = new System.Drawing.Size(213, 270);
            this.gbSpellList.TabIndex = 9;
            this.gbSpellList.TabStop = false;
            this.gbSpellList.Text = "Known Skills";
            this.gbSpellList.TextIB = "iceBlinkGBMedium1";
            // 
            // gbSkillDesc
            // 
            this.gbSkillDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSkillDesc.BackColor = System.Drawing.Color.Transparent;
            this.gbSkillDesc.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbSkillDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbSkillDesc.BorderThickness = 2F;
            this.gbSkillDesc.Controls.Add(this.rtxtSkillDescription);
            this.gbSkillDesc.HeaderForeColor = System.Drawing.Color.White;
            this.gbSkillDesc.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gbSkillDesc.HeaderImage")));
            this.gbSkillDesc.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbSkillDesc.Location = new System.Drawing.Point(231, 37);
            this.gbSkillDesc.Name = "gbSkillDesc";
            this.gbSkillDesc.Size = new System.Drawing.Size(215, 270);
            this.gbSkillDesc.TabIndex = 8;
            this.gbSkillDesc.TabStop = false;
            this.gbSkillDesc.Text = "Skill Description";
            this.gbSkillDesc.TextIB = "iceBlinkGBMedium1";
            // 
            // rtxtSkillDescription
            // 
            this.rtxtSkillDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtSkillDescription.Location = new System.Drawing.Point(6, 30);
            this.rtxtSkillDescription.Name = "rtxtSkillDescription";
            this.rtxtSkillDescription.Size = new System.Drawing.Size(203, 234);
            this.rtxtSkillDescription.TabIndex = 1;
            this.rtxtSkillDescription.Text = "";
            // 
            // SkillSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(458, 318);
            this.Controls.Add(this.gbSpellList);
            this.Controls.Add(this.gbSkillDesc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(458, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(458, 318);
            this.Name = "SkillSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SkillSelect";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.gbSkillDesc, 0);
            this.Controls.SetChildIndex(this.gbSpellList, 0);
            this.gbSkillDesc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlinkGroupBoxMedium gbSpellList;
        private IceBlinkGroupBoxMedium gbSkillDesc;
        private System.Windows.Forms.RichTextBox rtxtSkillDescription;

    }
}