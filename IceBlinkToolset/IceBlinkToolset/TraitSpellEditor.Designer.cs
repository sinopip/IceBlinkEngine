namespace IceBlinkToolset
{
    partial class TraitSpellEditor
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
            this.btnDuplicateTraitSpell = new System.Windows.Forms.Button();
            this.btnAddTraitSpell = new System.Windows.Forms.Button();
            this.btnRemoveTraitSpell = new System.Windows.Forms.Button();
            this.lbxTraitSpells = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
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
            this.splitContainer1.Size = new System.Drawing.Size(846, 451);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnDuplicateTraitSpell);
            this.groupBox1.Controls.Add(this.btnAddTraitSpell);
            this.groupBox1.Controls.Add(this.btnRemoveTraitSpell);
            this.groupBox1.Controls.Add(this.lbxTraitSpells);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 428);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Traits/Spells";
            // 
            // btnDuplicateTraitSpell
            // 
            this.btnDuplicateTraitSpell.Location = new System.Drawing.Point(108, 17);
            this.btnDuplicateTraitSpell.Name = "btnDuplicateTraitSpell";
            this.btnDuplicateTraitSpell.Size = new System.Drawing.Size(61, 23);
            this.btnDuplicateTraitSpell.TabIndex = 87;
            this.btnDuplicateTraitSpell.Text = "Duplicate";
            this.btnDuplicateTraitSpell.UseVisualStyleBackColor = true;
            this.btnDuplicateTraitSpell.Click += new System.EventHandler(this.btnDuplicateTraitSpell_Click);
            // 
            // btnAddTraitSpell
            // 
            this.btnAddTraitSpell.Location = new System.Drawing.Point(8, 17);
            this.btnAddTraitSpell.Name = "btnAddTraitSpell";
            this.btnAddTraitSpell.Size = new System.Drawing.Size(40, 23);
            this.btnAddTraitSpell.TabIndex = 85;
            this.btnAddTraitSpell.Text = "Add";
            this.btnAddTraitSpell.UseVisualStyleBackColor = true;
            this.btnAddTraitSpell.Click += new System.EventHandler(this.btnAddTraitSpell_Click);
            // 
            // btnRemoveTraitSpell
            // 
            this.btnRemoveTraitSpell.Location = new System.Drawing.Point(48, 17);
            this.btnRemoveTraitSpell.Name = "btnRemoveTraitSpell";
            this.btnRemoveTraitSpell.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveTraitSpell.TabIndex = 86;
            this.btnRemoveTraitSpell.Text = "Remove";
            this.btnRemoveTraitSpell.UseVisualStyleBackColor = true;
            this.btnRemoveTraitSpell.Click += new System.EventHandler(this.btnRemoveTraitSpell_Click);
            // 
            // lbxTraitSpells
            // 
            this.lbxTraitSpells.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxTraitSpells.FormattingEnabled = true;
            this.lbxTraitSpells.Location = new System.Drawing.Point(10, 48);
            this.lbxTraitSpells.Name = "lbxTraitSpells";
            this.lbxTraitSpells.Size = new System.Drawing.Size(157, 355);
            this.lbxTraitSpells.TabIndex = 82;
            this.lbxTraitSpells.SelectedIndexChanged += new System.EventHandler(this.lbxTraitSpells_SelectedIndexChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(284, 451);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // TraitSpellEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 451);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TraitSpellEditor";
            this.Text = "TraitSpellEditor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDuplicateTraitSpell;
        private System.Windows.Forms.Button btnAddTraitSpell;
        private System.Windows.Forms.Button btnRemoveTraitSpell;
        private System.Windows.Forms.ListBox lbxTraitSpells;
        private System.Windows.Forms.PropertyGrid propertyGrid1;

    }
}