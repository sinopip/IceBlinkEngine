namespace IceBlinkToolset
{
    partial class VariablesEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariablesEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadGlobals = new System.Windows.Forms.Button();
            this.btnGlobalClipboard = new System.Windows.Forms.Button();
            this.btnRemoveGlobal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGlobalNotes = new System.Windows.Forms.TextBox();
            this.lbxGlobals = new System.Windows.Forms.ListBox();
            this.btnGlobalAdd = new System.Windows.Forms.Button();
            this.txtGlobalAdd = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLocalClipboard = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadLocals = new System.Windows.Forms.Button();
            this.btnRemoveLocal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalNotes = new System.Windows.Forms.TextBox();
            this.lbxLocals = new System.Windows.Forms.ListBox();
            this.btnLocalAdd = new System.Windows.Forms.Button();
            this.txtLocalAdd = new System.Windows.Forms.TextBox();
            this.btnSortGlobals = new System.Windows.Forms.Button();
            this.btnSortLocals = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSortGlobals);
            this.groupBox1.Controls.Add(this.btnLoadGlobals);
            this.groupBox1.Controls.Add(this.btnGlobalClipboard);
            this.groupBox1.Controls.Add(this.btnRemoveGlobal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGlobalNotes);
            this.groupBox1.Controls.Add(this.lbxGlobals);
            this.groupBox1.Controls.Add(this.btnGlobalAdd);
            this.groupBox1.Controls.Add(this.txtGlobalAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 463);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Global Variables";
            // 
            // btnLoadGlobals
            // 
            this.btnLoadGlobals.Location = new System.Drawing.Point(6, 436);
            this.btnLoadGlobals.Name = "btnLoadGlobals";
            this.btnLoadGlobals.Size = new System.Drawing.Size(354, 23);
            this.btnLoadGlobals.TabIndex = 2;
            this.btnLoadGlobals.Text = "Automatically Add Used Global Variables to the List";
            this.toolTip1.SetToolTip(this.btnLoadGlobals, "Only imports Globals stored on\r\nthe Module. Eventually will\r\ninclude from Convers" +
                    "ations.");
            this.btnLoadGlobals.UseVisualStyleBackColor = true;
            this.btnLoadGlobals.Click += new System.EventHandler(this.btnLoadGlobals_Click);
            // 
            // btnGlobalClipboard
            // 
            this.btnGlobalClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGlobalClipboard.Location = new System.Drawing.Point(184, 49);
            this.btnGlobalClipboard.Name = "btnGlobalClipboard";
            this.btnGlobalClipboard.Size = new System.Drawing.Size(176, 85);
            this.btnGlobalClipboard.TabIndex = 6;
            this.btnGlobalClipboard.Text = "Copy Selected Global Variable to the System Clipboard";
            this.toolTip1.SetToolTip(this.btnGlobalClipboard, resources.GetString("btnGlobalClipboard.ToolTip"));
            this.btnGlobalClipboard.UseVisualStyleBackColor = true;
            this.btnGlobalClipboard.Click += new System.EventHandler(this.btnGlobalClipboard_Click);
            // 
            // btnRemoveGlobal
            // 
            this.btnRemoveGlobal.Location = new System.Drawing.Point(6, 409);
            this.btnRemoveGlobal.Name = "btnRemoveGlobal";
            this.btnRemoveGlobal.Size = new System.Drawing.Size(168, 23);
            this.btnRemoveGlobal.TabIndex = 5;
            this.btnRemoveGlobal.Text = "Remove Selected";
            this.btnRemoveGlobal.UseVisualStyleBackColor = true;
            this.btnRemoveGlobal.Click += new System.EventHandler(this.btnRemoveGlobal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Notes to Self:";
            // 
            // txtGlobalNotes
            // 
            this.txtGlobalNotes.Location = new System.Drawing.Point(184, 160);
            this.txtGlobalNotes.Multiline = true;
            this.txtGlobalNotes.Name = "txtGlobalNotes";
            this.txtGlobalNotes.Size = new System.Drawing.Size(176, 272);
            this.txtGlobalNotes.TabIndex = 3;
            this.txtGlobalNotes.TextChanged += new System.EventHandler(this.txtGlobalNotes_TextChanged);
            // 
            // lbxGlobals
            // 
            this.lbxGlobals.FormattingEnabled = true;
            this.lbxGlobals.Location = new System.Drawing.Point(6, 49);
            this.lbxGlobals.Name = "lbxGlobals";
            this.lbxGlobals.Size = new System.Drawing.Size(168, 355);
            this.lbxGlobals.TabIndex = 2;
            this.lbxGlobals.SelectedIndexChanged += new System.EventHandler(this.lbxGlobals_SelectedIndexChanged);
            // 
            // btnGlobalAdd
            // 
            this.btnGlobalAdd.Location = new System.Drawing.Point(184, 17);
            this.btnGlobalAdd.Name = "btnGlobalAdd";
            this.btnGlobalAdd.Size = new System.Drawing.Size(81, 23);
            this.btnGlobalAdd.TabIndex = 1;
            this.btnGlobalAdd.Text = "Add to List";
            this.btnGlobalAdd.UseVisualStyleBackColor = true;
            this.btnGlobalAdd.Click += new System.EventHandler(this.btnGlobalAdd_Click);
            // 
            // txtGlobalAdd
            // 
            this.txtGlobalAdd.Location = new System.Drawing.Point(6, 19);
            this.txtGlobalAdd.Name = "txtGlobalAdd";
            this.txtGlobalAdd.Size = new System.Drawing.Size(168, 20);
            this.txtGlobalAdd.TabIndex = 0;
            // 
            // btnLocalClipboard
            // 
            this.btnLocalClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalClipboard.Location = new System.Drawing.Point(184, 49);
            this.btnLocalClipboard.Name = "btnLocalClipboard";
            this.btnLocalClipboard.Size = new System.Drawing.Size(176, 85);
            this.btnLocalClipboard.TabIndex = 6;
            this.btnLocalClipboard.Text = "Copy Selected Local Variable to the System Clipboard";
            this.toolTip1.SetToolTip(this.btnLocalClipboard, resources.GetString("btnLocalClipboard.ToolTip"));
            this.btnLocalClipboard.UseVisualStyleBackColor = true;
            this.btnLocalClipboard.Click += new System.EventHandler(this.btnLocalClipboard_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSortLocals);
            this.groupBox2.Controls.Add(this.btnLoadLocals);
            this.groupBox2.Controls.Add(this.btnLocalClipboard);
            this.groupBox2.Controls.Add(this.btnRemoveLocal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtLocalNotes);
            this.groupBox2.Controls.Add(this.lbxLocals);
            this.groupBox2.Controls.Add(this.btnLocalAdd);
            this.groupBox2.Controls.Add(this.txtLocalAdd);
            this.groupBox2.Location = new System.Drawing.Point(385, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 463);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local Variables";
            // 
            // btnLoadLocals
            // 
            this.btnLoadLocals.Location = new System.Drawing.Point(6, 436);
            this.btnLoadLocals.Name = "btnLoadLocals";
            this.btnLoadLocals.Size = new System.Drawing.Size(354, 23);
            this.btnLoadLocals.TabIndex = 7;
            this.btnLoadLocals.Text = "Automatically Add Used Local Variables to the List";
            this.toolTip1.SetToolTip(this.btnLoadLocals, "Only imports Locals stored on\r\nCreatures, Items and Props.\r\nEventually will inclu" +
                    "de from\r\nConversations.");
            this.btnLoadLocals.UseVisualStyleBackColor = true;
            this.btnLoadLocals.Click += new System.EventHandler(this.btnLoadLocals_Click);
            // 
            // btnRemoveLocal
            // 
            this.btnRemoveLocal.Location = new System.Drawing.Point(6, 409);
            this.btnRemoveLocal.Name = "btnRemoveLocal";
            this.btnRemoveLocal.Size = new System.Drawing.Size(168, 23);
            this.btnRemoveLocal.TabIndex = 5;
            this.btnRemoveLocal.Text = "Remove Selected";
            this.btnRemoveLocal.UseVisualStyleBackColor = true;
            this.btnRemoveLocal.Click += new System.EventHandler(this.btnRemoveLocal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Notes to Self:";
            // 
            // txtLocalNotes
            // 
            this.txtLocalNotes.Location = new System.Drawing.Point(184, 160);
            this.txtLocalNotes.Multiline = true;
            this.txtLocalNotes.Name = "txtLocalNotes";
            this.txtLocalNotes.Size = new System.Drawing.Size(176, 272);
            this.txtLocalNotes.TabIndex = 3;
            this.txtLocalNotes.TextChanged += new System.EventHandler(this.txtLocalNotes_TextChanged);
            // 
            // lbxLocals
            // 
            this.lbxLocals.FormattingEnabled = true;
            this.lbxLocals.Location = new System.Drawing.Point(6, 49);
            this.lbxLocals.Name = "lbxLocals";
            this.lbxLocals.Size = new System.Drawing.Size(168, 355);
            this.lbxLocals.TabIndex = 2;
            this.lbxLocals.SelectedIndexChanged += new System.EventHandler(this.lbxLocals_SelectedIndexChanged);
            // 
            // btnLocalAdd
            // 
            this.btnLocalAdd.Location = new System.Drawing.Point(184, 17);
            this.btnLocalAdd.Name = "btnLocalAdd";
            this.btnLocalAdd.Size = new System.Drawing.Size(81, 23);
            this.btnLocalAdd.TabIndex = 1;
            this.btnLocalAdd.Text = "Add to List";
            this.btnLocalAdd.UseVisualStyleBackColor = true;
            this.btnLocalAdd.Click += new System.EventHandler(this.btnLocalAdd_Click);
            // 
            // txtLocalAdd
            // 
            this.txtLocalAdd.Location = new System.Drawing.Point(6, 19);
            this.txtLocalAdd.Name = "txtLocalAdd";
            this.txtLocalAdd.Size = new System.Drawing.Size(168, 20);
            this.txtLocalAdd.TabIndex = 0;
            // 
            // btnSortGlobals
            // 
            this.btnSortGlobals.Location = new System.Drawing.Point(280, 17);
            this.btnSortGlobals.Name = "btnSortGlobals";
            this.btnSortGlobals.Size = new System.Drawing.Size(80, 23);
            this.btnSortGlobals.TabIndex = 7;
            this.btnSortGlobals.Text = "Sort List";
            this.btnSortGlobals.UseVisualStyleBackColor = true;
            this.btnSortGlobals.Click += new System.EventHandler(this.btnSortGlobals_Click);
            // 
            // btnSortLocals
            // 
            this.btnSortLocals.Location = new System.Drawing.Point(280, 17);
            this.btnSortLocals.Name = "btnSortLocals";
            this.btnSortLocals.Size = new System.Drawing.Size(80, 23);
            this.btnSortLocals.TabIndex = 8;
            this.btnSortLocals.Text = "Sort List";
            this.btnSortLocals.UseVisualStyleBackColor = true;
            this.btnSortLocals.Click += new System.EventHandler(this.btnSortLocals_Click);
            // 
            // VariablesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 487);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VariablesEditor";
            this.Text = "VariablesEditor";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGlobalClipboard;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnRemoveGlobal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGlobalNotes;
        private System.Windows.Forms.ListBox lbxGlobals;
        private System.Windows.Forms.Button btnGlobalAdd;
        private System.Windows.Forms.TextBox txtGlobalAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLocalClipboard;
        private System.Windows.Forms.Button btnRemoveLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalNotes;
        private System.Windows.Forms.ListBox lbxLocals;
        private System.Windows.Forms.Button btnLocalAdd;
        private System.Windows.Forms.TextBox txtLocalAdd;
        private System.Windows.Forms.Button btnLoadGlobals;
        private System.Windows.Forms.Button btnLoadLocals;
        private System.Windows.Forms.Button btnSortGlobals;
        private System.Windows.Forms.Button btnSortLocals;
    }
}