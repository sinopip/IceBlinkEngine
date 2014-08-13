namespace IceBlinkToolset
{
    partial class PlayerClassEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerSkillsTS = new System.Windows.Forms.SplitContainer();
            this.gbAllowedSkills = new System.Windows.Forms.GroupBox();
            this.dgvSkillsAllowed = new System.Windows.Forms.DataGridView();
            this.splitContainerTraitsSpells = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvTraitsAllowed = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSpellsAllowed = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxItemsAllowed = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDuplicatePlayerClass = new System.Windows.Forms.Button();
            this.btnAddPlayerClass = new System.Windows.Forms.Button();
            this.btnRemovePlayerClass = new System.Windows.Forms.Button();
            this.lbxPlayerClasses = new System.Windows.Forms.ListBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainerSkillsTS.Panel1.SuspendLayout();
            this.splitContainerSkillsTS.Panel2.SuspendLayout();
            this.splitContainerSkillsTS.SuspendLayout();
            this.gbAllowedSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkillsAllowed)).BeginInit();
            this.splitContainerTraitsSpells.Panel1.SuspendLayout();
            this.splitContainerTraitsSpells.Panel2.SuspendLayout();
            this.splitContainerTraitsSpells.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraitsAllowed)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpellsAllowed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(241, 489);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerSkillsTS);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 489);
            this.splitContainer1.SplitterDistance = 812;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainerSkillsTS
            // 
            this.splitContainerSkillsTS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerSkillsTS.Location = new System.Drawing.Point(399, 12);
            this.splitContainerSkillsTS.Name = "splitContainerSkillsTS";
            this.splitContainerSkillsTS.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSkillsTS.Panel1
            // 
            this.splitContainerSkillsTS.Panel1.Controls.Add(this.gbAllowedSkills);
            // 
            // splitContainerSkillsTS.Panel2
            // 
            this.splitContainerSkillsTS.Panel2.Controls.Add(this.splitContainerTraitsSpells);
            this.splitContainerSkillsTS.Size = new System.Drawing.Size(405, 466);
            this.splitContainerSkillsTS.SplitterDistance = 161;
            this.splitContainerSkillsTS.TabIndex = 8;
            // 
            // gbAllowedSkills
            // 
            this.gbAllowedSkills.Controls.Add(this.dgvSkillsAllowed);
            this.gbAllowedSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAllowedSkills.Location = new System.Drawing.Point(0, 0);
            this.gbAllowedSkills.Name = "gbAllowedSkills";
            this.gbAllowedSkills.Size = new System.Drawing.Size(405, 161);
            this.gbAllowedSkills.TabIndex = 3;
            this.gbAllowedSkills.TabStop = false;
            this.gbAllowedSkills.Text = "Allowed Skills";
            // 
            // dgvSkillsAllowed
            // 
            this.dgvSkillsAllowed.AllowUserToAddRows = false;
            this.dgvSkillsAllowed.AllowUserToDeleteRows = false;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSkillsAllowed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvSkillsAllowed.ColumnHeadersHeight = 45;
            this.dgvSkillsAllowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSkillsAllowed.DefaultCellStyle = dataGridViewCellStyle38;
            this.dgvSkillsAllowed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSkillsAllowed.Location = new System.Drawing.Point(3, 16);
            this.dgvSkillsAllowed.MultiSelect = false;
            this.dgvSkillsAllowed.Name = "dgvSkillsAllowed";
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSkillsAllowed.RowHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dgvSkillsAllowed.RowHeadersVisible = false;
            this.dgvSkillsAllowed.Size = new System.Drawing.Size(399, 142);
            this.dgvSkillsAllowed.TabIndex = 3;
            this.dgvSkillsAllowed.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSkillsAllowed_DataError);
            // 
            // splitContainerTraitsSpells
            // 
            this.splitContainerTraitsSpells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTraitsSpells.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTraitsSpells.Name = "splitContainerTraitsSpells";
            this.splitContainerTraitsSpells.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTraitsSpells.Panel1
            // 
            this.splitContainerTraitsSpells.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainerTraitsSpells.Panel2
            // 
            this.splitContainerTraitsSpells.Panel2.Controls.Add(this.groupBox4);
            this.splitContainerTraitsSpells.Size = new System.Drawing.Size(405, 301);
            this.splitContainerTraitsSpells.SplitterDistance = 150;
            this.splitContainerTraitsSpells.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvTraitsAllowed);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(405, 150);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Allowed Traits";
            // 
            // dgvTraitsAllowed
            // 
            this.dgvTraitsAllowed.AllowUserToAddRows = false;
            this.dgvTraitsAllowed.AllowUserToDeleteRows = false;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTraitsAllowed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.dgvTraitsAllowed.ColumnHeadersHeight = 45;
            this.dgvTraitsAllowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTraitsAllowed.DefaultCellStyle = dataGridViewCellStyle41;
            this.dgvTraitsAllowed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraitsAllowed.Location = new System.Drawing.Point(3, 16);
            this.dgvTraitsAllowed.MultiSelect = false;
            this.dgvTraitsAllowed.Name = "dgvTraitsAllowed";
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTraitsAllowed.RowHeadersDefaultCellStyle = dataGridViewCellStyle42;
            this.dgvTraitsAllowed.RowHeadersVisible = false;
            this.dgvTraitsAllowed.Size = new System.Drawing.Size(399, 131);
            this.dgvTraitsAllowed.TabIndex = 2;
            this.dgvTraitsAllowed.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTraitsAllowed_DataError);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSpellsAllowed);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 147);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Allowed Spells";
            // 
            // dgvSpellsAllowed
            // 
            this.dgvSpellsAllowed.AllowUserToAddRows = false;
            this.dgvSpellsAllowed.AllowUserToDeleteRows = false;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpellsAllowed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.dgvSpellsAllowed.ColumnHeadersHeight = 45;
            this.dgvSpellsAllowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpellsAllowed.DefaultCellStyle = dataGridViewCellStyle44;
            this.dgvSpellsAllowed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpellsAllowed.Location = new System.Drawing.Point(3, 16);
            this.dgvSpellsAllowed.MultiSelect = false;
            this.dgvSpellsAllowed.Name = "dgvSpellsAllowed";
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpellsAllowed.RowHeadersDefaultCellStyle = dataGridViewCellStyle45;
            this.dgvSpellsAllowed.RowHeadersVisible = false;
            this.dgvSpellsAllowed.Size = new System.Drawing.Size(399, 128);
            this.dgvSpellsAllowed.TabIndex = 2;
            this.dgvSpellsAllowed.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSpellsAllowed_DataError);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxItemsAllowed);
            this.groupBox2.Location = new System.Drawing.Point(195, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 466);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allowed Items";
            // 
            // cbxItemsAllowed
            // 
            this.cbxItemsAllowed.CheckOnClick = true;
            this.cbxItemsAllowed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxItemsAllowed.FormattingEnabled = true;
            this.cbxItemsAllowed.Location = new System.Drawing.Point(3, 16);
            this.cbxItemsAllowed.Name = "cbxItemsAllowed";
            this.cbxItemsAllowed.ScrollAlwaysVisible = true;
            this.cbxItemsAllowed.Size = new System.Drawing.Size(192, 447);
            this.cbxItemsAllowed.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnSort);
            this.groupBox1.Controls.Add(this.btnDuplicatePlayerClass);
            this.groupBox1.Controls.Add(this.btnAddPlayerClass);
            this.groupBox1.Controls.Add(this.btnRemovePlayerClass);
            this.groupBox1.Controls.Add(this.lbxPlayerClasses);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 466);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Player Classes";
            // 
            // btnDuplicatePlayerClass
            // 
            this.btnDuplicatePlayerClass.Location = new System.Drawing.Point(105, 14);
            this.btnDuplicatePlayerClass.Name = "btnDuplicatePlayerClass";
            this.btnDuplicatePlayerClass.Size = new System.Drawing.Size(66, 23);
            this.btnDuplicatePlayerClass.TabIndex = 87;
            this.btnDuplicatePlayerClass.Text = "Duplicate";
            this.btnDuplicatePlayerClass.UseVisualStyleBackColor = true;
            this.btnDuplicatePlayerClass.Click += new System.EventHandler(this.btnDuplicatePlayerClass_Click);
            // 
            // btnAddPlayerClass
            // 
            this.btnAddPlayerClass.Location = new System.Drawing.Point(5, 37);
            this.btnAddPlayerClass.Name = "btnAddPlayerClass";
            this.btnAddPlayerClass.Size = new System.Drawing.Size(166, 23);
            this.btnAddPlayerClass.TabIndex = 85;
            this.btnAddPlayerClass.Text = "Add";
            this.btnAddPlayerClass.UseVisualStyleBackColor = true;
            this.btnAddPlayerClass.Click += new System.EventHandler(this.btnAddPlayerClass_Click);
            // 
            // btnRemovePlayerClass
            // 
            this.btnRemovePlayerClass.Location = new System.Drawing.Point(45, 14);
            this.btnRemovePlayerClass.Name = "btnRemovePlayerClass";
            this.btnRemovePlayerClass.Size = new System.Drawing.Size(60, 23);
            this.btnRemovePlayerClass.TabIndex = 86;
            this.btnRemovePlayerClass.Text = "Remove";
            this.btnRemovePlayerClass.UseVisualStyleBackColor = true;
            this.btnRemovePlayerClass.Click += new System.EventHandler(this.btnRemovePlayerClass_Click);
            // 
            // lbxPlayerClasses
            // 
            this.lbxPlayerClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxPlayerClasses.FormattingEnabled = true;
            this.lbxPlayerClasses.Location = new System.Drawing.Point(10, 61);
            this.lbxPlayerClasses.Name = "lbxPlayerClasses";
            this.lbxPlayerClasses.Size = new System.Drawing.Size(157, 394);
            this.lbxPlayerClasses.TabIndex = 82;
            this.lbxPlayerClasses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbxPlayerClasses_MouseClick);
            this.lbxPlayerClasses.SelectedIndexChanged += new System.EventHandler(this.lbxPlayerClasses_SelectedIndexChanged);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(5, 14);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(40, 23);
            this.btnSort.TabIndex = 89;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // PlayerClassEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 489);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PlayerClassEditor";
            this.Text = "Player Class Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerClassEditor_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerSkillsTS.Panel1.ResumeLayout(false);
            this.splitContainerSkillsTS.Panel2.ResumeLayout(false);
            this.splitContainerSkillsTS.ResumeLayout(false);
            this.gbAllowedSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkillsAllowed)).EndInit();
            this.splitContainerTraitsSpells.Panel1.ResumeLayout(false);
            this.splitContainerTraitsSpells.Panel2.ResumeLayout(false);
            this.splitContainerTraitsSpells.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraitsAllowed)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpellsAllowed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDuplicatePlayerClass;
        private System.Windows.Forms.Button btnAddPlayerClass;
        private System.Windows.Forms.Button btnRemovePlayerClass;
        private System.Windows.Forms.ListBox lbxPlayerClasses;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox cbxItemsAllowed;
        private System.Windows.Forms.GroupBox gbAllowedSkills;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvSpellsAllowed;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvTraitsAllowed;
        private System.Windows.Forms.SplitContainer splitContainerTraitsSpells;
        private System.Windows.Forms.SplitContainer splitContainerSkillsTS;
        private System.Windows.Forms.DataGridView dgvSkillsAllowed;
        private System.Windows.Forms.Button btnSort;

    }
}