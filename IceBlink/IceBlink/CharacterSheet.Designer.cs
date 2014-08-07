namespace IceBlink
{
    partial class CharacterSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterSheet));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLevelUp = new IceBlink.IceBlinkButtonMedium();
            this.pbToken = new System.Windows.Forms.PictureBox();
            this.btnExportPC = new IceBlink.IceBlinkButtonMedium();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.iceBlinkGroupBoxMedium6 = new IceBlink.IceBlinkGroupBoxMedium();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.iceBlinkGroupBoxMedium7 = new IceBlink.IceBlinkGroupBoxMedium();
            this.lbxKnownTraits = new System.Windows.Forms.ListBox();
            this.iceBlinkGroupBoxMedium5 = new IceBlink.IceBlinkGroupBoxMedium();
            this.lbxKnownSpells = new System.Windows.Forms.ListBox();
            this.iceBlinkGroupBoxMedium4 = new IceBlink.IceBlinkGroupBoxMedium();
            this.dgvSkills = new System.Windows.Forms.DataGridView();
            this.iceBlinkGroupBoxMedium3 = new IceBlink.IceBlinkGroupBoxMedium();
            this.rtxtMisc = new System.Windows.Forms.RichTextBox();
            this.iceBlinkGroupBoxMedium2 = new IceBlink.IceBlinkGroupBoxMedium();
            this.rtxtAttributes = new System.Windows.Forms.RichTextBox();
            this.btnSkillsTab = new IceBlink.IceBlinkButtonMedium();
            this.btnTraitsTab = new IceBlink.IceBlinkButtonMedium();
            this.btnSpellsTab = new IceBlink.IceBlinkButtonMedium();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToken)).BeginInit();
            this.iceBlinkGroupBoxMedium6.SuspendLayout();
            this.iceBlinkGroupBoxMedium7.SuspendLayout();
            this.iceBlinkGroupBoxMedium5.SuspendLayout();
            this.iceBlinkGroupBoxMedium4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkills)).BeginInit();
            this.iceBlinkGroupBoxMedium3.SuspendLayout();
            this.iceBlinkGroupBoxMedium2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(162, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 174);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Click to Change");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnLevelUp
            // 
            this.btnLevelUp.BackColor = System.Drawing.Color.Transparent;
            this.btnLevelUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLevelUp.BackgroundImage")));
            this.btnLevelUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLevelUp.DisabledImage = null;
            this.btnLevelUp.Enabled = false;
            this.btnLevelUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLevelUp.FlatAppearance.BorderSize = 0;
            this.btnLevelUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLevelUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLevelUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLevelUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLevelUp.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnLevelUp.HoverImage")));
            this.btnLevelUp.Location = new System.Drawing.Point(12, 273);
            this.btnLevelUp.Name = "btnLevelUp";
            this.btnLevelUp.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnLevelUp.NormalImage")));
            this.btnLevelUp.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnLevelUp.PressedImage")));
            this.btnLevelUp.Size = new System.Drawing.Size(140, 35);
            this.btnLevelUp.TabIndex = 31;
            this.btnLevelUp.TextIB = "LEVEL UP";
            this.btnLevelUp.UseVisualStyleBackColor = true;
            this.btnLevelUp.Click += new System.EventHandler(this.btnLevelUp_Click);
            // 
            // pbToken
            // 
            this.pbToken.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbToken.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbToken.Location = new System.Drawing.Point(184, 232);
            this.pbToken.Name = "pbToken";
            this.pbToken.Size = new System.Drawing.Size(68, 68);
            this.pbToken.TabIndex = 91;
            this.pbToken.TabStop = false;
            this.toolTip1.SetToolTip(this.pbToken, "Click to Change");
            this.pbToken.Click += new System.EventHandler(this.pbToken_Click);
            // 
            // btnExportPC
            // 
            this.btnExportPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportPC.BackColor = System.Drawing.Color.Transparent;
            this.btnExportPC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportPC.BackgroundImage")));
            this.btnExportPC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportPC.DisabledImage = null;
            this.btnExportPC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExportPC.FlatAppearance.BorderSize = 0;
            this.btnExportPC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExportPC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExportPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPC.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnExportPC.HoverImage")));
            this.btnExportPC.Location = new System.Drawing.Point(287, 637);
            this.btnExportPC.Name = "btnExportPC";
            this.btnExportPC.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnExportPC.NormalImage")));
            this.btnExportPC.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnExportPC.PressedImage")));
            this.btnExportPC.Size = new System.Drawing.Size(228, 35);
            this.btnExportPC.TabIndex = 92;
            this.btnExportPC.TextIB = "EXPORT CHARACTER";
            this.btnExportPC.UseVisualStyleBackColor = true;
            this.btnExportPC.Click += new System.EventHandler(this.btnExportPC_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // iceBlinkGroupBoxMedium6
            // 
            this.iceBlinkGroupBoxMedium6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.iceBlinkGroupBoxMedium6.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium6.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium6.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium6.Controls.Add(this.rtxtDescription);
            this.iceBlinkGroupBoxMedium6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium6.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium6.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium6.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium6.Location = new System.Drawing.Point(287, 419);
            this.iceBlinkGroupBoxMedium6.Name = "iceBlinkGroupBoxMedium6";
            this.iceBlinkGroupBoxMedium6.Size = new System.Drawing.Size(228, 212);
            this.iceBlinkGroupBoxMedium6.TabIndex = 97;
            this.iceBlinkGroupBoxMedium6.TabStop = false;
            this.iceBlinkGroupBoxMedium6.Text = "DESCRIPTION";
            this.iceBlinkGroupBoxMedium6.TextIB = "";
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtDescription.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rtxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtxtDescription.Location = new System.Drawing.Point(15, 31);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.ReadOnly = true;
            this.rtxtDescription.Size = new System.Drawing.Size(198, 175);
            this.rtxtDescription.TabIndex = 1;
            this.rtxtDescription.Text = "";
            // 
            // iceBlinkGroupBoxMedium7
            // 
            this.iceBlinkGroupBoxMedium7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.iceBlinkGroupBoxMedium7.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium7.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium7.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium7.Controls.Add(this.lbxKnownTraits);
            this.iceBlinkGroupBoxMedium7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium7.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium7.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium7.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium7.Location = new System.Drawing.Point(12, 346);
            this.iceBlinkGroupBoxMedium7.Name = "iceBlinkGroupBoxMedium7";
            this.iceBlinkGroupBoxMedium7.Size = new System.Drawing.Size(265, 326);
            this.iceBlinkGroupBoxMedium7.TabIndex = 97;
            this.iceBlinkGroupBoxMedium7.TabStop = false;
            this.iceBlinkGroupBoxMedium7.Text = "TRAITS";
            this.iceBlinkGroupBoxMedium7.TextIB = "";
            // 
            // lbxKnownTraits
            // 
            this.lbxKnownTraits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxKnownTraits.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbxKnownTraits.FormattingEnabled = true;
            this.lbxKnownTraits.ItemHeight = 18;
            this.lbxKnownTraits.Location = new System.Drawing.Point(4, 30);
            this.lbxKnownTraits.Name = "lbxKnownTraits";
            this.lbxKnownTraits.ScrollAlwaysVisible = true;
            this.lbxKnownTraits.Size = new System.Drawing.Size(255, 292);
            this.lbxKnownTraits.TabIndex = 81;
            this.lbxKnownTraits.SelectedIndexChanged += new System.EventHandler(this.lbxKnownTraits_SelectedIndexChanged);
            // 
            // iceBlinkGroupBoxMedium5
            // 
            this.iceBlinkGroupBoxMedium5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.iceBlinkGroupBoxMedium5.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium5.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium5.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium5.Controls.Add(this.lbxKnownSpells);
            this.iceBlinkGroupBoxMedium5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium5.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium5.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium5.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium5.Location = new System.Drawing.Point(12, 346);
            this.iceBlinkGroupBoxMedium5.Name = "iceBlinkGroupBoxMedium5";
            this.iceBlinkGroupBoxMedium5.Size = new System.Drawing.Size(265, 326);
            this.iceBlinkGroupBoxMedium5.TabIndex = 97;
            this.iceBlinkGroupBoxMedium5.TabStop = false;
            this.iceBlinkGroupBoxMedium5.Text = "SPELLS";
            this.iceBlinkGroupBoxMedium5.TextIB = "";
            // 
            // lbxKnownSpells
            // 
            this.lbxKnownSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxKnownSpells.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbxKnownSpells.FormattingEnabled = true;
            this.lbxKnownSpells.ItemHeight = 18;
            this.lbxKnownSpells.Location = new System.Drawing.Point(4, 29);
            this.lbxKnownSpells.Name = "lbxKnownSpells";
            this.lbxKnownSpells.ScrollAlwaysVisible = true;
            this.lbxKnownSpells.Size = new System.Drawing.Size(255, 292);
            this.lbxKnownSpells.TabIndex = 82;
            this.lbxKnownSpells.SelectedIndexChanged += new System.EventHandler(this.lbxKnownSpells_SelectedIndexChanged);
            // 
            // iceBlinkGroupBoxMedium4
            // 
            this.iceBlinkGroupBoxMedium4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.iceBlinkGroupBoxMedium4.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium4.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium4.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium4.Controls.Add(this.dgvSkills);
            this.iceBlinkGroupBoxMedium4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium4.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium4.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium4.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium4.Location = new System.Drawing.Point(12, 346);
            this.iceBlinkGroupBoxMedium4.Name = "iceBlinkGroupBoxMedium4";
            this.iceBlinkGroupBoxMedium4.Size = new System.Drawing.Size(265, 326);
            this.iceBlinkGroupBoxMedium4.TabIndex = 96;
            this.iceBlinkGroupBoxMedium4.TabStop = false;
            this.iceBlinkGroupBoxMedium4.Text = "SKILLS";
            this.iceBlinkGroupBoxMedium4.TextIB = "";
            // 
            // dgvSkills
            // 
            this.dgvSkills.AllowUserToAddRows = false;
            this.dgvSkills.AllowUserToDeleteRows = false;
            this.dgvSkills.AllowUserToResizeRows = false;
            this.dgvSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSkills.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSkills.Location = new System.Drawing.Point(6, 30);
            this.dgvSkills.MultiSelect = false;
            this.dgvSkills.Name = "dgvSkills";
            this.dgvSkills.ReadOnly = true;
            this.dgvSkills.RowHeadersVisible = false;
            this.dgvSkills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSkills.Size = new System.Drawing.Size(253, 290);
            this.dgvSkills.TabIndex = 85;
            this.dgvSkills.SelectionChanged += new System.EventHandler(this.dgvSkills_SelectionChanged);
            // 
            // iceBlinkGroupBoxMedium3
            // 
            this.iceBlinkGroupBoxMedium3.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium3.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium3.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.rtxtMisc);
            this.iceBlinkGroupBoxMedium3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium3.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium3.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium3.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium3.Location = new System.Drawing.Point(287, 38);
            this.iceBlinkGroupBoxMedium3.Name = "iceBlinkGroupBoxMedium3";
            this.iceBlinkGroupBoxMedium3.Size = new System.Drawing.Size(228, 375);
            this.iceBlinkGroupBoxMedium3.TabIndex = 95;
            this.iceBlinkGroupBoxMedium3.TabStop = false;
            this.iceBlinkGroupBoxMedium3.Text = "MAIN";
            this.iceBlinkGroupBoxMedium3.TextIB = "";
            // 
            // rtxtMisc
            // 
            this.rtxtMisc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtMisc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtMisc.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtxtMisc.Location = new System.Drawing.Point(15, 33);
            this.rtxtMisc.Name = "rtxtMisc";
            this.rtxtMisc.Size = new System.Drawing.Size(199, 334);
            this.rtxtMisc.TabIndex = 34;
            this.rtxtMisc.Text = "";
            // 
            // iceBlinkGroupBoxMedium2
            // 
            this.iceBlinkGroupBoxMedium2.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium2.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium2.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium2.Controls.Add(this.rtxtAttributes);
            this.iceBlinkGroupBoxMedium2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium2.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium2.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium2.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium2.Location = new System.Drawing.Point(12, 38);
            this.iceBlinkGroupBoxMedium2.Name = "iceBlinkGroupBoxMedium2";
            this.iceBlinkGroupBoxMedium2.Size = new System.Drawing.Size(140, 231);
            this.iceBlinkGroupBoxMedium2.TabIndex = 94;
            this.iceBlinkGroupBoxMedium2.TabStop = false;
            this.iceBlinkGroupBoxMedium2.Text = "ATTRIBUTES";
            this.iceBlinkGroupBoxMedium2.TextIB = "";
            // 
            // rtxtAttributes
            // 
            this.rtxtAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtAttributes.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtxtAttributes.Location = new System.Drawing.Point(12, 32);
            this.rtxtAttributes.Name = "rtxtAttributes";
            this.rtxtAttributes.Size = new System.Drawing.Size(116, 193);
            this.rtxtAttributes.TabIndex = 35;
            this.rtxtAttributes.Text = "";
            // 
            // btnSkillsTab
            // 
            this.btnSkillsTab.BackColor = System.Drawing.Color.Transparent;
            this.btnSkillsTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSkillsTab.BackgroundImage")));
            this.btnSkillsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSkillsTab.DisabledImage = null;
            this.btnSkillsTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSkillsTab.FlatAppearance.BorderSize = 0;
            this.btnSkillsTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSkillsTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSkillsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkillsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkillsTab.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnSkillsTab.HoverImage")));
            this.btnSkillsTab.Location = new System.Drawing.Point(12, 314);
            this.btnSkillsTab.Name = "btnSkillsTab";
            this.btnSkillsTab.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnSkillsTab.NormalImage")));
            this.btnSkillsTab.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnSkillsTab.PressedImage")));
            this.btnSkillsTab.Size = new System.Drawing.Size(87, 30);
            this.btnSkillsTab.TabIndex = 98;
            this.btnSkillsTab.TextIB = "SKILLS";
            this.btnSkillsTab.UseVisualStyleBackColor = true;
            this.btnSkillsTab.Click += new System.EventHandler(this.btnSkillsTab_Click);
            // 
            // btnTraitsTab
            // 
            this.btnTraitsTab.BackColor = System.Drawing.Color.Transparent;
            this.btnTraitsTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTraitsTab.BackgroundImage")));
            this.btnTraitsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTraitsTab.DisabledImage = null;
            this.btnTraitsTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTraitsTab.FlatAppearance.BorderSize = 0;
            this.btnTraitsTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTraitsTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTraitsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraitsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraitsTab.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnTraitsTab.HoverImage")));
            this.btnTraitsTab.Location = new System.Drawing.Point(101, 314);
            this.btnTraitsTab.Name = "btnTraitsTab";
            this.btnTraitsTab.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnTraitsTab.NormalImage")));
            this.btnTraitsTab.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnTraitsTab.PressedImage")));
            this.btnTraitsTab.Size = new System.Drawing.Size(87, 30);
            this.btnTraitsTab.TabIndex = 99;
            this.btnTraitsTab.TextIB = "TRAITS";
            this.btnTraitsTab.UseVisualStyleBackColor = true;
            this.btnTraitsTab.Click += new System.EventHandler(this.btnTraitsTab_Click);
            // 
            // btnSpellsTab
            // 
            this.btnSpellsTab.BackColor = System.Drawing.Color.Transparent;
            this.btnSpellsTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSpellsTab.BackgroundImage")));
            this.btnSpellsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSpellsTab.DisabledImage = null;
            this.btnSpellsTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSpellsTab.FlatAppearance.BorderSize = 0;
            this.btnSpellsTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSpellsTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSpellsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpellsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpellsTab.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnSpellsTab.HoverImage")));
            this.btnSpellsTab.Location = new System.Drawing.Point(190, 314);
            this.btnSpellsTab.Name = "btnSpellsTab";
            this.btnSpellsTab.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnSpellsTab.NormalImage")));
            this.btnSpellsTab.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnSpellsTab.PressedImage")));
            this.btnSpellsTab.Size = new System.Drawing.Size(87, 30);
            this.btnSpellsTab.TabIndex = 100;
            this.btnSpellsTab.TextIB = "SPELLS";
            this.btnSpellsTab.UseVisualStyleBackColor = true;
            this.btnSpellsTab.Click += new System.EventHandler(this.btnSpellsTab_Click);
            // 
            // CharacterSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 685);
            this.Controls.Add(this.btnSpellsTab);
            this.Controls.Add(this.btnTraitsTab);
            this.Controls.Add(this.btnSkillsTab);
            this.Controls.Add(this.iceBlinkGroupBoxMedium6);
            this.Controls.Add(this.iceBlinkGroupBoxMedium3);
            this.Controls.Add(this.iceBlinkGroupBoxMedium2);
            this.Controls.Add(this.btnExportPC);
            this.Controls.Add(this.pbToken);
            this.Controls.Add(this.btnLevelUp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.iceBlinkGroupBoxMedium4);
            this.Controls.Add(this.iceBlinkGroupBoxMedium7);
            this.Controls.Add(this.iceBlinkGroupBoxMedium5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(528, 685);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(528, 585);
            this.Name = "CharacterSheet";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHARACTER SHEET";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterSheet_FormClosing);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium5, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium7, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium4, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.btnLevelUp, 0);
            this.Controls.SetChildIndex(this.pbToken, 0);
            this.Controls.SetChildIndex(this.btnExportPC, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium2, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium3, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium6, 0);
            this.Controls.SetChildIndex(this.btnSkillsTab, 0);
            this.Controls.SetChildIndex(this.btnTraitsTab, 0);
            this.Controls.SetChildIndex(this.btnSpellsTab, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToken)).EndInit();
            this.iceBlinkGroupBoxMedium6.ResumeLayout(false);
            this.iceBlinkGroupBoxMedium7.ResumeLayout(false);
            this.iceBlinkGroupBoxMedium5.ResumeLayout(false);
            this.iceBlinkGroupBoxMedium4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkills)).EndInit();
            this.iceBlinkGroupBoxMedium3.ResumeLayout(false);
            this.iceBlinkGroupBoxMedium2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private IceBlink.IceBlinkButtonMedium btnLevelUp;
        private System.Windows.Forms.ListBox lbxKnownTraits;
        private System.Windows.Forms.ListBox lbxKnownSpells;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.DataGridView dgvSkills;
        private System.Windows.Forms.PictureBox pbToken;
        private IceBlink.IceBlinkButtonMedium btnExportPC;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium2;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium3;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium4;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium5;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium6;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium7;
        private IceBlinkButtonMedium btnSkillsTab;
        private IceBlinkButtonMedium btnTraitsTab;
        private IceBlinkButtonMedium btnSpellsTab;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.RichTextBox rtxtMisc;
        public System.Windows.Forms.RichTextBox rtxtAttributes;

    }
}