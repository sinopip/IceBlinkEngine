namespace IceBlinkCore
{
    partial class ScriptSelect
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
            this.label5 = new System.Windows.Forms.Label();
            this.gbScriptParms = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parm1 = new System.Windows.Forms.TextBox();
            this.parm2 = new System.Windows.Forms.TextBox();
            this.parm4 = new System.Windows.Forms.TextBox();
            this.parm3 = new System.Windows.Forms.TextBox();
            this.rtxtScript = new System.Windows.Forms.RichTextBox();
            this.cmbObjectTagFilename = new System.Windows.Forms.ComboBox();
            this.gbScriptParms.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Select the Script:";
            // 
            // gbScriptParms
            // 
            this.gbScriptParms.Controls.Add(this.label4);
            this.gbScriptParms.Controls.Add(this.label3);
            this.gbScriptParms.Controls.Add(this.label2);
            this.gbScriptParms.Controls.Add(this.label1);
            this.gbScriptParms.Controls.Add(this.parm1);
            this.gbScriptParms.Controls.Add(this.parm2);
            this.gbScriptParms.Controls.Add(this.parm4);
            this.gbScriptParms.Controls.Add(this.parm3);
            this.gbScriptParms.Location = new System.Drawing.Point(7, 4);
            this.gbScriptParms.Name = "gbScriptParms";
            this.gbScriptParms.Size = new System.Drawing.Size(300, 74);
            this.gbScriptParms.TabIndex = 28;
            this.gbScriptParms.TabStop = false;
            this.gbScriptParms.Text = "Script Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "#3:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "#4:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "#2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "#1:";
            // 
            // parm1
            // 
            this.parm1.Location = new System.Drawing.Point(29, 19);
            this.parm1.Name = "parm1";
            this.parm1.Size = new System.Drawing.Size(115, 20);
            this.parm1.TabIndex = 19;
            this.parm1.TextChanged += new System.EventHandler(this.parm1_TextChanged_1);
            // 
            // parm2
            // 
            this.parm2.Location = new System.Drawing.Point(175, 19);
            this.parm2.Name = "parm2";
            this.parm2.Size = new System.Drawing.Size(115, 20);
            this.parm2.TabIndex = 22;
            this.parm2.TextChanged += new System.EventHandler(this.parm2_TextChanged_1);
            // 
            // parm4
            // 
            this.parm4.Location = new System.Drawing.Point(175, 45);
            this.parm4.Name = "parm4";
            this.parm4.Size = new System.Drawing.Size(115, 20);
            this.parm4.TabIndex = 20;
            this.parm4.TextChanged += new System.EventHandler(this.parm4_TextChanged_1);
            // 
            // parm3
            // 
            this.parm3.Location = new System.Drawing.Point(29, 45);
            this.parm3.Name = "parm3";
            this.parm3.Size = new System.Drawing.Size(115, 20);
            this.parm3.TabIndex = 21;
            this.parm3.TextChanged += new System.EventHandler(this.parm3_TextChanged_1);
            // 
            // rtxtScript
            // 
            this.rtxtScript.BackColor = System.Drawing.Color.White;
            this.rtxtScript.Location = new System.Drawing.Point(6, 85);
            this.rtxtScript.Name = "rtxtScript";
            this.rtxtScript.ReadOnly = true;
            this.rtxtScript.Size = new System.Drawing.Size(457, 151);
            this.rtxtScript.TabIndex = 27;
            this.rtxtScript.Text = "";
            this.rtxtScript.WordWrap = false;
            // 
            // cmbObjectTagFilename
            // 
            this.cmbObjectTagFilename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjectTagFilename.FormattingEnabled = true;
            this.cmbObjectTagFilename.Items.AddRange(new object[] {
            "none"});
            this.cmbObjectTagFilename.Location = new System.Drawing.Point(313, 50);
            this.cmbObjectTagFilename.Name = "cmbObjectTagFilename";
            this.cmbObjectTagFilename.Size = new System.Drawing.Size(150, 21);
            this.cmbObjectTagFilename.TabIndex = 26;
            this.cmbObjectTagFilename.SelectedIndexChanged += new System.EventHandler(this.cmbObjectTagFilename_SelectedIndexChanged_1);
            // 
            // ScriptSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 242);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbScriptParms);
            this.Controls.Add(this.rtxtScript);
            this.Controls.Add(this.cmbObjectTagFilename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptSelect";
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScriptSelect_FormClosed);
            this.Load += new System.EventHandler(this.ScriptSelect_Load);
            this.gbScriptParms.ResumeLayout(false);
            this.gbScriptParms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbScriptParms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox parm1;
        public System.Windows.Forms.TextBox parm2;
        public System.Windows.Forms.TextBox parm4;
        public System.Windows.Forms.TextBox parm3;
        public System.Windows.Forms.RichTextBox rtxtScript;
        public System.Windows.Forms.ComboBox cmbObjectTagFilename;
    }
}