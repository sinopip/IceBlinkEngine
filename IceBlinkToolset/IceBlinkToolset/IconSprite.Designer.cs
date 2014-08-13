namespace IceBlinkToolset
{
    partial class IconSprite
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
            this.gbCreatureIconSelect = new System.Windows.Forms.GroupBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gbKnownTraits = new System.Windows.Forms.GroupBox();
            this.cbxKnownTraits = new System.Windows.Forms.CheckedListBox();
            this.gbKnownSpells = new System.Windows.Forms.GroupBox();
            this.cbxKnownSpells = new System.Windows.Forms.CheckedListBox();
            this.gbCreatureIconSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.gbKnownTraits.SuspendLayout();
            this.gbKnownSpells.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCreatureIconSelect
            // 
            this.gbCreatureIconSelect.Controls.Add(this.pbIcon);
            this.gbCreatureIconSelect.Controls.Add(this.btnSelectIcon);
            this.gbCreatureIconSelect.Location = new System.Drawing.Point(12, 12);
            this.gbCreatureIconSelect.Name = "gbCreatureIconSelect";
            this.gbCreatureIconSelect.Size = new System.Drawing.Size(180, 214);
            this.gbCreatureIconSelect.TabIndex = 44;
            this.gbCreatureIconSelect.TabStop = false;
            this.gbCreatureIconSelect.Text = "Icon/Sprite";
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.Silver;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIcon.Location = new System.Drawing.Point(13, 19);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Padding = new System.Windows.Forms.Padding(2);
            this.pbIcon.Size = new System.Drawing.Size(154, 154);
            this.pbIcon.TabIndex = 25;
            this.pbIcon.TabStop = false;
            // 
            // btnSelectIcon
            // 
            this.btnSelectIcon.Location = new System.Drawing.Point(13, 179);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(154, 23);
            this.btnSelectIcon.TabIndex = 26;
            this.btnSelectIcon.Text = "Select";
            this.btnSelectIcon.UseVisualStyleBackColor = true;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(414, 500);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 45;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbKnownTraits);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbKnownSpells);
            this.splitContainer2.Size = new System.Drawing.Size(414, 257);
            this.splitContainer2.SplitterDistance = 124;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gbCreatureIconSelect);
            this.splitContainer3.Size = new System.Drawing.Size(414, 239);
            this.splitContainer3.SplitterDistance = 203;
            this.splitContainer3.TabIndex = 45;
            // 
            // gbKnownTraits
            // 
            this.gbKnownTraits.Controls.Add(this.cbxKnownTraits);
            this.gbKnownTraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbKnownTraits.Location = new System.Drawing.Point(0, 0);
            this.gbKnownTraits.Name = "gbKnownTraits";
            this.gbKnownTraits.Size = new System.Drawing.Size(414, 124);
            this.gbKnownTraits.TabIndex = 3;
            this.gbKnownTraits.TabStop = false;
            this.gbKnownTraits.Text = "Known Traits";
            // 
            // cbxKnownTraits
            // 
            this.cbxKnownTraits.CheckOnClick = true;
            this.cbxKnownTraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxKnownTraits.FormattingEnabled = true;
            this.cbxKnownTraits.Items.AddRange(new object[] {
            "test1",
            "test2",
            "test3"});
            this.cbxKnownTraits.Location = new System.Drawing.Point(3, 16);
            this.cbxKnownTraits.Name = "cbxKnownTraits";
            this.cbxKnownTraits.ScrollAlwaysVisible = true;
            this.cbxKnownTraits.Size = new System.Drawing.Size(408, 105);
            this.cbxKnownTraits.TabIndex = 1;
            this.cbxKnownTraits.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbxKnownTraits_ItemCheck);
            // 
            // gbKnownSpells
            // 
            this.gbKnownSpells.Controls.Add(this.cbxKnownSpells);
            this.gbKnownSpells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbKnownSpells.Location = new System.Drawing.Point(0, 0);
            this.gbKnownSpells.Name = "gbKnownSpells";
            this.gbKnownSpells.Size = new System.Drawing.Size(414, 129);
            this.gbKnownSpells.TabIndex = 4;
            this.gbKnownSpells.TabStop = false;
            this.gbKnownSpells.Text = "Known Spells";
            // 
            // cbxKnownSpells
            // 
            this.cbxKnownSpells.CheckOnClick = true;
            this.cbxKnownSpells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxKnownSpells.FormattingEnabled = true;
            this.cbxKnownSpells.Location = new System.Drawing.Point(3, 16);
            this.cbxKnownSpells.Name = "cbxKnownSpells";
            this.cbxKnownSpells.ScrollAlwaysVisible = true;
            this.cbxKnownSpells.Size = new System.Drawing.Size(408, 110);
            this.cbxKnownSpells.TabIndex = 1;
            this.cbxKnownSpells.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbxKnownSpells_ItemCheck);
            // 
            // IconSprite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 500);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "IconSprite";
            this.Text = "IconSprite";
            this.gbCreatureIconSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.gbKnownTraits.ResumeLayout(false);
            this.gbKnownSpells.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbCreatureIconSelect;
        public System.Windows.Forms.PictureBox pbIcon;
        public System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox gbKnownTraits;
        private System.Windows.Forms.CheckedListBox cbxKnownTraits;
        private System.Windows.Forms.GroupBox gbKnownSpells;
        private System.Windows.Forms.CheckedListBox cbxKnownSpells;

    }
}