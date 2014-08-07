namespace IceBlink
{
    partial class ContainerDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerDialogBox));
            this.btnTakeSelected = new IceBlink.IceBlinkButtonMedium();
            this.groupBox1 = new IceBlink.IceBlinkGroupBoxMedium();
            this.lbxItems = new System.Windows.Forms.ListBox();
            this.btnCloseContainer = new IceBlink.IceBlinkButtonLarge();
            this.btnLootAll = new IceBlink.IceBlinkButtonMedium();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTakeSelected
            // 
            this.btnTakeSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakeSelected.BackColor = System.Drawing.Color.Transparent;
            this.btnTakeSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTakeSelected.BackgroundImage")));
            this.btnTakeSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTakeSelected.DisabledImage = null;
            this.btnTakeSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTakeSelected.FlatAppearance.BorderSize = 0;
            this.btnTakeSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTakeSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTakeSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeSelected.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnTakeSelected.HoverImage")));
            this.btnTakeSelected.Location = new System.Drawing.Point(162, 281);
            this.btnTakeSelected.Name = "btnTakeSelected";
            this.btnTakeSelected.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnTakeSelected.NormalImage")));
            this.btnTakeSelected.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnTakeSelected.PressedImage")));
            this.btnTakeSelected.Size = new System.Drawing.Size(108, 25);
            this.btnTakeSelected.TabIndex = 20;
            this.btnTakeSelected.TextIB = "TAKE SELECTED";
            this.btnTakeSelected.UseVisualStyleBackColor = true;
            this.btnTakeSelected.Click += new System.EventHandler(this.btnTakeSelected_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.BorderThickness = 2F;
            this.groupBox1.Controls.Add(this.lbxItems);
            this.groupBox1.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.HeaderImage")));
            this.groupBox1.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 241);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ITEMS";
            this.groupBox1.TextIB = "iceBlinkGBMedium1";
            // 
            // lbxItems
            // 
            this.lbxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxItems.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbxItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxItems.FormattingEnabled = true;
            this.lbxItems.Location = new System.Drawing.Point(6, 32);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.Size = new System.Drawing.Size(246, 197);
            this.lbxItems.TabIndex = 0;
            this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.lbxItems_SelectedIndexChanged);
            // 
            // btnCloseContainer
            // 
            this.btnCloseContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseContainer.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCloseContainer.BackgroundImage")));
            this.btnCloseContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseContainer.DisabledImage = null;
            this.btnCloseContainer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCloseContainer.FlatAppearance.BorderSize = 0;
            this.btnCloseContainer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCloseContainer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCloseContainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseContainer.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnCloseContainer.HoverImage")));
            this.btnCloseContainer.Location = new System.Drawing.Point(12, 312);
            this.btnCloseContainer.Name = "btnCloseContainer";
            this.btnCloseContainer.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnCloseContainer.NormalImage")));
            this.btnCloseContainer.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnCloseContainer.PressedImage")));
            this.btnCloseContainer.Size = new System.Drawing.Size(258, 25);
            this.btnCloseContainer.TabIndex = 18;
            this.btnCloseContainer.TextIB = "CLOSE CONTAINER";
            this.btnCloseContainer.UseVisualStyleBackColor = true;
            this.btnCloseContainer.Click += new System.EventHandler(this.btnCloseContainer_Click);
            // 
            // btnLootAll
            // 
            this.btnLootAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLootAll.BackColor = System.Drawing.Color.Transparent;
            this.btnLootAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLootAll.BackgroundImage")));
            this.btnLootAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLootAll.DisabledImage = null;
            this.btnLootAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLootAll.FlatAppearance.BorderSize = 0;
            this.btnLootAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLootAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLootAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLootAll.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnLootAll.HoverImage")));
            this.btnLootAll.Location = new System.Drawing.Point(12, 281);
            this.btnLootAll.Name = "btnLootAll";
            this.btnLootAll.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnLootAll.NormalImage")));
            this.btnLootAll.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnLootAll.PressedImage")));
            this.btnLootAll.Size = new System.Drawing.Size(144, 25);
            this.btnLootAll.TabIndex = 17;
            this.btnLootAll.TextIB = "LOOT ALL";
            this.btnLootAll.UseVisualStyleBackColor = true;
            this.btnLootAll.Click += new System.EventHandler(this.btnLootAll_Click);
            // 
            // ContainerDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 350);
            this.Controls.Add(this.btnTakeSelected);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCloseContainer);
            this.Controls.Add(this.btnLootAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(227, 350);
            this.Name = "ContainerDialogBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Controls.SetChildIndex(this.btnLootAll, 0);
            this.Controls.SetChildIndex(this.btnCloseContainer, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnTakeSelected, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlinkButtonMedium btnLootAll;
        private IceBlinkButtonLarge btnCloseContainer;
        private IceBlinkGroupBoxMedium groupBox1;
        private System.Windows.Forms.ListBox lbxItems;
        private IceBlinkButtonMedium btnTakeSelected;
    }
}