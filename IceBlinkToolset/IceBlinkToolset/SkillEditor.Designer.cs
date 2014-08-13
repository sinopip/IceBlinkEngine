namespace IceBlinkToolset
{
    partial class SkillEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDuplicateSkill = new System.Windows.Forms.Button();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.btnRemoveSkill = new System.Windows.Forms.Button();
            this.lbxSkills = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnSort = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(852, 460);
            this.splitContainer1.SplitterDistance = 562;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnSort);
            this.groupBox1.Controls.Add(this.btnDuplicateSkill);
            this.groupBox1.Controls.Add(this.btnAddSkill);
            this.groupBox1.Controls.Add(this.btnRemoveSkill);
            this.groupBox1.Controls.Add(this.lbxSkills);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Skills";
            // 
            // btnDuplicateSkill
            // 
            this.btnDuplicateSkill.Location = new System.Drawing.Point(108, 14);
            this.btnDuplicateSkill.Name = "btnDuplicateSkill";
            this.btnDuplicateSkill.Size = new System.Drawing.Size(61, 23);
            this.btnDuplicateSkill.TabIndex = 87;
            this.btnDuplicateSkill.Text = "Duplicate";
            this.btnDuplicateSkill.UseVisualStyleBackColor = true;
            this.btnDuplicateSkill.Click += new System.EventHandler(this.btnDuplicateSkill_Click);
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Location = new System.Drawing.Point(8, 37);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(161, 23);
            this.btnAddSkill.TabIndex = 85;
            this.btnAddSkill.Text = "Add";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // btnRemoveSkill
            // 
            this.btnRemoveSkill.Location = new System.Drawing.Point(48, 14);
            this.btnRemoveSkill.Name = "btnRemoveSkill";
            this.btnRemoveSkill.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveSkill.TabIndex = 86;
            this.btnRemoveSkill.Text = "Remove";
            this.btnRemoveSkill.UseVisualStyleBackColor = true;
            this.btnRemoveSkill.Click += new System.EventHandler(this.btnRemoveSkill_Click);
            // 
            // lbxSkills
            // 
            this.lbxSkills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxSkills.FormattingEnabled = true;
            this.lbxSkills.Location = new System.Drawing.Point(10, 61);
            this.lbxSkills.Name = "lbxSkills";
            this.lbxSkills.Size = new System.Drawing.Size(157, 355);
            this.lbxSkills.TabIndex = 82;
            this.lbxSkills.SelectedIndexChanged += new System.EventHandler(this.lbxSkills_SelectedIndexChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(286, 460);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(8, 14);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(40, 23);
            this.btnSort.TabIndex = 90;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // SkillEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 460);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SkillEditor";
            this.Text = "SkillEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SkillEditor_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDuplicateSkill;
        private System.Windows.Forms.Button btnAddSkill;
        private System.Windows.Forms.Button btnRemoveSkill;
        private System.Windows.Forms.ListBox lbxSkills;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnSort;
    }
}