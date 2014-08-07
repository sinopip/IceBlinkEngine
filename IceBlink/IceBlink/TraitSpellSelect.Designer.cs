namespace IceBlink
{
    partial class TraitSpellSelect
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
            this.gbTraitSpellList = new System.Windows.Forms.GroupBox();
            this.btnSelectTS = new System.Windows.Forms.Button();
            this.lbxTS = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtTraitSpellDescription = new System.Windows.Forms.RichTextBox();
            this.gbTraitSpellList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTraitSpellList
            // 
            this.gbTraitSpellList.Controls.Add(this.btnSelectTS);
            this.gbTraitSpellList.Controls.Add(this.lbxTS);
            this.gbTraitSpellList.Location = new System.Drawing.Point(12, 12);
            this.gbTraitSpellList.Name = "gbTraitSpellList";
            this.gbTraitSpellList.Size = new System.Drawing.Size(213, 270);
            this.gbTraitSpellList.TabIndex = 5;
            this.gbTraitSpellList.TabStop = false;
            this.gbTraitSpellList.Text = "Known Traits/Spells";
            // 
            // btnSelectTS
            // 
            this.btnSelectTS.Location = new System.Drawing.Point(6, 241);
            this.btnSelectTS.Name = "btnSelectTS";
            this.btnSelectTS.Size = new System.Drawing.Size(201, 23);
            this.btnSelectTS.TabIndex = 4;
            this.btnSelectTS.Text = "Use Selected Trait/Spell";
            this.btnSelectTS.UseVisualStyleBackColor = true;
            this.btnSelectTS.Click += new System.EventHandler(this.btnSelectTS_Click);
            // 
            // lbxTS
            // 
            this.lbxTS.FormattingEnabled = true;
            this.lbxTS.Location = new System.Drawing.Point(6, 13);
            this.lbxTS.Name = "lbxTS";
            this.lbxTS.ScrollAlwaysVisible = true;
            this.lbxTS.Size = new System.Drawing.Size(201, 225);
            this.lbxTS.TabIndex = 0;
            this.lbxTS.SelectedIndexChanged += new System.EventHandler(this.lbxTS_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtTraitSpellDescription);
            this.groupBox1.Location = new System.Drawing.Point(231, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 270);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trait/Spell Description";
            // 
            // rtxtTraitSpellDescription
            // 
            this.rtxtTraitSpellDescription.Location = new System.Drawing.Point(6, 13);
            this.rtxtTraitSpellDescription.Name = "rtxtTraitSpellDescription";
            this.rtxtTraitSpellDescription.Size = new System.Drawing.Size(203, 251);
            this.rtxtTraitSpellDescription.TabIndex = 1;
            this.rtxtTraitSpellDescription.Text = "";
            // 
            // TraitSpellSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(458, 297);
            this.Controls.Add(this.gbTraitSpellList);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TraitSpellSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TraitSpellSelect";
            this.TopMost = true;
            this.gbTraitSpellList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTraitSpellList;
        private System.Windows.Forms.Button btnSelectTS;
        private System.Windows.Forms.ListBox lbxTS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtxtTraitSpellDescription;
    }
}