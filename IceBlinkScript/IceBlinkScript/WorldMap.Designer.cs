namespace openForgeScript
{
    partial class WorldMap
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
            this.pnlMap = new System.Windows.Forms.Panel();
            this.pnlFlag = new System.Windows.Forms.Panel();
            this.pnlMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMap
            // 
            this.pnlMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMap.Controls.Add(this.pnlFlag);
            this.pnlMap.Location = new System.Drawing.Point(3, 25);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(634, 482);
            this.pnlMap.TabIndex = 3;
            // 
            // pnlFlag
            // 
            this.pnlFlag.BackColor = System.Drawing.Color.Transparent;
            this.pnlFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFlag.Location = new System.Drawing.Point(365, 390);
            this.pnlFlag.Name = "pnlFlag";
            this.pnlFlag.Size = new System.Drawing.Size(40, 40);
            this.pnlFlag.TabIndex = 0;
            // 
            // WorldMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(640, 510);
            this.Controls.Add(this.pnlMap);
            this.Name = "WorldMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorldMap";
            this.Controls.SetChildIndex(this.pnlMap, 0);
            this.pnlMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Panel pnlFlag;
    }
}