namespace IceBlink
{
    partial class UseItemCombat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseItemCombat));
            this.groupBox1 = new IceBlink.IceBlinkGroupBoxMedium();
            this.lbxInventory = new System.Windows.Forms.ListBox();
            this.btnUseItem = new IceBlink.IceBlinkButtonMedium();
            this.groupBox3 = new IceBlink.IceBlinkGroupBoxMedium();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnExit = new IceBlink.IceBlinkButtonMedium();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.BorderThickness = 2F;
            this.groupBox1.Controls.Add(this.lbxInventory);
            this.groupBox1.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.HeaderImage")));
            this.groupBox1.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party Inventory";
            this.groupBox1.TextIB = "iceBlinkGBMedium1";
            // 
            // lbxInventory
            // 
            this.lbxInventory.FormattingEnabled = true;
            this.lbxInventory.Location = new System.Drawing.Point(6, 32);
            this.lbxInventory.Name = "lbxInventory";
            this.lbxInventory.Size = new System.Drawing.Size(171, 199);
            this.lbxInventory.TabIndex = 0;
            this.lbxInventory.SelectedIndexChanged += new System.EventHandler(this.lbxInventory_SelectedIndexChanged);
            // 
            // btnUseItem
            // 
            this.btnUseItem.BackColor = System.Drawing.Color.Transparent;
            this.btnUseItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.BackgroundImage")));
            this.btnUseItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUseItem.DisabledImage = null;
            this.btnUseItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUseItem.FlatAppearance.BorderSize = 0;
            this.btnUseItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUseItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUseItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUseItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.HoverImage")));
            this.btnUseItem.Location = new System.Drawing.Point(201, 42);
            this.btnUseItem.Name = "btnUseItem";
            this.btnUseItem.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.NormalImage")));
            this.btnUseItem.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.PressedImage")));
            this.btnUseItem.Size = new System.Drawing.Size(191, 28);
            this.btnUseItem.TabIndex = 23;
            this.btnUseItem.TextIB = "Use Selected Item";
            this.btnUseItem.UseVisualStyleBackColor = true;
            this.btnUseItem.Click += new System.EventHandler(this.btnUseItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.BorderThickness = 2F;
            this.groupBox3.Controls.Add(this.txtDesc);
            this.groupBox3.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox3.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.HeaderImage")));
            this.groupBox3.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(201, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 166);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Item Information";
            this.groupBox3.TextIB = "iceBlinkGBMedium1";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(6, 31);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(179, 128);
            this.txtDesc.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.DisabledImage = null;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnExit.HoverImage")));
            this.btnExit.Location = new System.Drawing.Point(201, 74);
            this.btnExit.Name = "btnExit";
            this.btnExit.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnExit.NormalImage")));
            this.btnExit.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnExit.PressedImage")));
            this.btnExit.Size = new System.Drawing.Size(191, 28);
            this.btnExit.TabIndex = 25;
            this.btnExit.TextIB = "EXIT ( no item use )";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UseItemCombat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(405, 287);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnUseItem);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 287);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 287);
            this.Name = "UseItemCombat";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnUseItem, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlinkGroupBoxMedium groupBox1;
        private System.Windows.Forms.ListBox lbxInventory;
        private IceBlinkButtonMedium btnUseItem;
        private IceBlinkGroupBoxMedium groupBox3;
        private System.Windows.Forms.TextBox txtDesc;
        private IceBlinkButtonMedium btnExit;
    }
}