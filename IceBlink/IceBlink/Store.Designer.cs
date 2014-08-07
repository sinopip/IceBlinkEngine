namespace IceBlink
{
    partial class Store
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Store));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEncumbrance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbtnPc5 = new System.Windows.Forms.RadioButton();
            this.rbtnPc4 = new System.Windows.Forms.RadioButton();
            this.btnUseItem = new IceBlink.IceBlinkButtonSmall();
            this.btnDeleteItem = new IceBlink.IceBlinkButtonSmall();
            this.groupBox3 = new IceBlink.IceBlinkGroupBoxMedium();
            this.pbItemIcon = new System.Windows.Forms.PictureBox();
            this.rtxtDesc = new System.Windows.Forms.RichTextBox();
            this.rbtnPc3 = new System.Windows.Forms.RadioButton();
            this.rbtnPc2 = new System.Windows.Forms.RadioButton();
            this.rbtnPc1 = new System.Windows.Forms.RadioButton();
            this.rbtnPc0 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new IceBlink.IceBlinkGroupBoxMedium();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemoveFeet = new IceBlink.IceBlinkButtonRArrow();
            this.txtNeck = new System.Windows.Forms.TextBox();
            this.txtFeet = new System.Windows.Forms.TextBox();
            this.btnRemoveNeck = new IceBlink.IceBlinkButtonRArrow();
            this.btnRemoveHead = new IceBlink.IceBlinkButtonRArrow();
            this.txtRing2 = new System.Windows.Forms.TextBox();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.btnRemoveRing2 = new IceBlink.IceBlinkButtonRArrow();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveOffHand = new IceBlink.IceBlinkButtonRArrow();
            this.txtRing1 = new System.Windows.Forms.TextBox();
            this.txtOffHand = new System.Windows.Forms.TextBox();
            this.btnRemoveRing1 = new IceBlink.IceBlinkButtonRArrow();
            this.btnRemoveMainHand = new IceBlink.IceBlinkButtonRArrow();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.txtMainHand = new System.Windows.Forms.TextBox();
            this.btnRemoveBody = new IceBlink.IceBlinkButtonRArrow();
            this.groupBox1 = new IceBlink.IceBlinkGroupBoxMedium();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new IceBlink.IceBlinkGroupBoxMedium();
            this.dgvShopItems = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new IceBlink.IceBlinkGroupBoxMedium();
            this.pbShopItemIcon = new System.Windows.Forms.PictureBox();
            this.rtxtShopItemDesc = new System.Windows.Forms.RichTextBox();
            this.btnBuyItem = new IceBlink.IceBlinkButtonSmall();
            this.btnSellItem = new IceBlink.IceBlinkButtonSmall();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFunds = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopItems)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopItemIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtEncumbrance);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(338, 524);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 50);
            this.panel1.TabIndex = 37;
            // 
            // txtEncumbrance
            // 
            this.txtEncumbrance.AutoSize = true;
            this.txtEncumbrance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncumbrance.Location = new System.Drawing.Point(32, 25);
            this.txtEncumbrance.Name = "txtEncumbrance";
            this.txtEncumbrance.Size = new System.Drawing.Size(52, 17);
            this.txtEncumbrance.TabIndex = 24;
            this.txtEncumbrance.Text = "00/000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Encumbrance:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rbtnPc5
            // 
            this.rbtnPc5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc5.BackgroundImage")));
            this.rbtnPc5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc5.Enabled = false;
            this.rbtnPc5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc5.Location = new System.Drawing.Point(231, 35);
            this.rbtnPc5.Name = "rbtnPc5";
            this.rbtnPc5.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc5.TabIndex = 36;
            this.rbtnPc5.TabStop = true;
            this.rbtnPc5.UseVisualStyleBackColor = true;
            this.rbtnPc5.Visible = false;
            this.rbtnPc5.CheckedChanged += new System.EventHandler(this.rbtnPc5_CheckedChanged);
            // 
            // rbtnPc4
            // 
            this.rbtnPc4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc4.BackgroundImage")));
            this.rbtnPc4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc4.Enabled = false;
            this.rbtnPc4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc4.Location = new System.Drawing.Point(186, 35);
            this.rbtnPc4.Name = "rbtnPc4";
            this.rbtnPc4.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc4.TabIndex = 35;
            this.rbtnPc4.TabStop = true;
            this.rbtnPc4.UseVisualStyleBackColor = true;
            this.rbtnPc4.Visible = false;
            this.rbtnPc4.CheckedChanged += new System.EventHandler(this.rbtnPc4_CheckedChanged);
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
            this.btnUseItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.HoverImage")));
            this.btnUseItem.Location = new System.Drawing.Point(280, 524);
            this.btnUseItem.Name = "btnUseItem";
            this.btnUseItem.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.NormalImage")));
            this.btnUseItem.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.PressedImage")));
            this.btnUseItem.Size = new System.Drawing.Size(50, 50);
            this.btnUseItem.TabIndex = 34;
            this.btnUseItem.TextIB = "USE";
            this.btnUseItem.UseVisualStyleBackColor = true;
            this.btnUseItem.Click += new System.EventHandler(this.btnUseItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.BackgroundImage")));
            this.btnDeleteItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteItem.DisabledImage = null;
            this.btnDeleteItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteItem.FlatAppearance.BorderSize = 0;
            this.btnDeleteItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.HoverImage")));
            this.btnDeleteItem.Location = new System.Drawing.Point(462, 524);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.NormalImage")));
            this.btnDeleteItem.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.PressedImage")));
            this.btnDeleteItem.Size = new System.Drawing.Size(50, 50);
            this.btnDeleteItem.TabIndex = 33;
            this.btnDeleteItem.TextIB = "DROP";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.BorderThickness = 2F;
            this.groupBox3.Controls.Add(this.pbItemIcon);
            this.groupBox3.Controls.Add(this.rtxtDesc);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox3.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.HeaderImage")));
            this.groupBox3.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 201);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SELECTED ITEM INFORMATION";
            this.groupBox3.TextIB = "iceBlinkGBMedium1";
            // 
            // pbItemIcon
            // 
            this.pbItemIcon.BackColor = System.Drawing.Color.White;
            this.pbItemIcon.Location = new System.Drawing.Point(195, 33);
            this.pbItemIcon.Name = "pbItemIcon";
            this.pbItemIcon.Size = new System.Drawing.Size(64, 64);
            this.pbItemIcon.TabIndex = 25;
            this.pbItemIcon.TabStop = false;
            // 
            // rtxtDesc
            // 
            this.rtxtDesc.Location = new System.Drawing.Point(4, 31);
            this.rtxtDesc.Name = "rtxtDesc";
            this.rtxtDesc.ReadOnly = true;
            this.rtxtDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtDesc.Size = new System.Drawing.Size(186, 164);
            this.rtxtDesc.TabIndex = 26;
            this.rtxtDesc.Text = "";
            // 
            // rbtnPc3
            // 
            this.rbtnPc3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc3.BackgroundImage")));
            this.rbtnPc3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc3.Enabled = false;
            this.rbtnPc3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc3.Location = new System.Drawing.Point(141, 35);
            this.rbtnPc3.Name = "rbtnPc3";
            this.rbtnPc3.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc3.TabIndex = 31;
            this.rbtnPc3.TabStop = true;
            this.rbtnPc3.UseVisualStyleBackColor = true;
            this.rbtnPc3.Visible = false;
            this.rbtnPc3.CheckedChanged += new System.EventHandler(this.rbtnPc3_CheckedChanged);
            // 
            // rbtnPc2
            // 
            this.rbtnPc2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc2.BackgroundImage")));
            this.rbtnPc2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc2.Enabled = false;
            this.rbtnPc2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc2.Location = new System.Drawing.Point(96, 35);
            this.rbtnPc2.Name = "rbtnPc2";
            this.rbtnPc2.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc2.TabIndex = 30;
            this.rbtnPc2.TabStop = true;
            this.rbtnPc2.UseVisualStyleBackColor = true;
            this.rbtnPc2.Visible = false;
            this.rbtnPc2.CheckedChanged += new System.EventHandler(this.rbtnPc2_CheckedChanged);
            // 
            // rbtnPc1
            // 
            this.rbtnPc1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc1.BackgroundImage")));
            this.rbtnPc1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc1.Enabled = false;
            this.rbtnPc1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc1.Location = new System.Drawing.Point(51, 35);
            this.rbtnPc1.Name = "rbtnPc1";
            this.rbtnPc1.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc1.TabIndex = 29;
            this.rbtnPc1.TabStop = true;
            this.rbtnPc1.UseVisualStyleBackColor = true;
            this.rbtnPc1.Visible = false;
            this.rbtnPc1.CheckedChanged += new System.EventHandler(this.rbtnPc1_CheckedChanged);
            // 
            // rbtnPc0
            // 
            this.rbtnPc0.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc0.BackgroundImage")));
            this.rbtnPc0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc0.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc0.Location = new System.Drawing.Point(6, 35);
            this.rbtnPc0.Name = "rbtnPc0";
            this.rbtnPc0.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc0.TabIndex = 28;
            this.rbtnPc0.TabStop = true;
            this.rbtnPc0.UseVisualStyleBackColor = true;
            this.rbtnPc0.Visible = false;
            this.rbtnPc0.CheckedChanged += new System.EventHandler(this.rbtnPc0_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.BorderThickness = 2F;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnRemoveFeet);
            this.groupBox2.Controls.Add(this.txtNeck);
            this.groupBox2.Controls.Add(this.txtFeet);
            this.groupBox2.Controls.Add(this.btnRemoveNeck);
            this.groupBox2.Controls.Add(this.btnRemoveHead);
            this.groupBox2.Controls.Add(this.txtRing2);
            this.groupBox2.Controls.Add(this.txtHead);
            this.groupBox2.Controls.Add(this.btnRemoveRing2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnRemoveOffHand);
            this.groupBox2.Controls.Add(this.txtRing1);
            this.groupBox2.Controls.Add(this.txtOffHand);
            this.groupBox2.Controls.Add(this.btnRemoveRing1);
            this.groupBox2.Controls.Add(this.btnRemoveMainHand);
            this.groupBox2.Controls.Add(this.txtBody);
            this.groupBox2.Controls.Add(this.txtMainHand);
            this.groupBox2.Controls.Add(this.btnRemoveBody);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox2.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.HeaderImage")));
            this.groupBox2.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 261);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EQUIPPED ITEMS";
            this.groupBox2.TextIB = "iceBlinkGBMedium1";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(7, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 36;
            this.label5.Text = "Feet";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Neck";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(7, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "Head";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 33;
            this.label8.Text = "Ring 2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnRemoveFeet
            // 
            this.btnRemoveFeet.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveFeet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFeet.BackgroundImage")));
            this.btnRemoveFeet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveFeet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveFeet.FlatAppearance.BorderSize = 0;
            this.btnRemoveFeet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveFeet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveFeet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFeet.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFeet.HoverImage")));
            this.btnRemoveFeet.Location = new System.Drawing.Point(233, 231);
            this.btnRemoveFeet.Name = "btnRemoveFeet";
            this.btnRemoveFeet.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFeet.NormalImage")));
            this.btnRemoveFeet.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFeet.PressedImage")));
            this.btnRemoveFeet.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveFeet.TabIndex = 32;
            this.btnRemoveFeet.TextIB = "";
            this.btnRemoveFeet.UseVisualStyleBackColor = true;
            this.btnRemoveFeet.Click += new System.EventHandler(this.btnRemoveFeet_Click);
            // 
            // txtNeck
            // 
            this.txtNeck.AllowDrop = true;
            this.txtNeck.BackColor = System.Drawing.SystemColors.Window;
            this.txtNeck.Location = new System.Drawing.Point(89, 62);
            this.txtNeck.Name = "txtNeck";
            this.txtNeck.ReadOnly = true;
            this.txtNeck.Size = new System.Drawing.Size(142, 23);
            this.txtNeck.TabIndex = 29;
            this.txtNeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNeck_MouseDown);
            // 
            // txtFeet
            // 
            this.txtFeet.AllowDrop = true;
            this.txtFeet.BackColor = System.Drawing.SystemColors.Window;
            this.txtFeet.Location = new System.Drawing.Point(89, 230);
            this.txtFeet.Name = "txtFeet";
            this.txtFeet.ReadOnly = true;
            this.txtFeet.Size = new System.Drawing.Size(142, 23);
            this.txtFeet.TabIndex = 30;
            this.txtFeet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtFeet_MouseDown);
            // 
            // btnRemoveNeck
            // 
            this.btnRemoveNeck.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveNeck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveNeck.BackgroundImage")));
            this.btnRemoveNeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveNeck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveNeck.FlatAppearance.BorderSize = 0;
            this.btnRemoveNeck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveNeck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveNeck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveNeck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveNeck.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveNeck.HoverImage")));
            this.btnRemoveNeck.Location = new System.Drawing.Point(233, 63);
            this.btnRemoveNeck.Name = "btnRemoveNeck";
            this.btnRemoveNeck.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveNeck.NormalImage")));
            this.btnRemoveNeck.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveNeck.PressedImage")));
            this.btnRemoveNeck.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveNeck.TabIndex = 31;
            this.btnRemoveNeck.TextIB = "";
            this.btnRemoveNeck.UseVisualStyleBackColor = true;
            this.btnRemoveNeck.Click += new System.EventHandler(this.btnRemoveNeck_Click);
            // 
            // btnRemoveHead
            // 
            this.btnRemoveHead.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveHead.BackgroundImage")));
            this.btnRemoveHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveHead.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveHead.FlatAppearance.BorderSize = 0;
            this.btnRemoveHead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveHead.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveHead.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveHead.HoverImage")));
            this.btnRemoveHead.Location = new System.Drawing.Point(233, 35);
            this.btnRemoveHead.Name = "btnRemoveHead";
            this.btnRemoveHead.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveHead.NormalImage")));
            this.btnRemoveHead.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveHead.PressedImage")));
            this.btnRemoveHead.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveHead.TabIndex = 28;
            this.btnRemoveHead.TextIB = "";
            this.btnRemoveHead.UseVisualStyleBackColor = true;
            this.btnRemoveHead.Click += new System.EventHandler(this.btnRemoveHead_Click);
            // 
            // txtRing2
            // 
            this.txtRing2.AllowDrop = true;
            this.txtRing2.BackColor = System.Drawing.SystemColors.Window;
            this.txtRing2.Location = new System.Drawing.Point(89, 202);
            this.txtRing2.Name = "txtRing2";
            this.txtRing2.ReadOnly = true;
            this.txtRing2.Size = new System.Drawing.Size(142, 23);
            this.txtRing2.TabIndex = 25;
            this.txtRing2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRing2_MouseDown);
            // 
            // txtHead
            // 
            this.txtHead.AllowDrop = true;
            this.txtHead.BackColor = System.Drawing.SystemColors.Window;
            this.txtHead.Location = new System.Drawing.Point(89, 34);
            this.txtHead.Name = "txtHead";
            this.txtHead.ReadOnly = true;
            this.txtHead.Size = new System.Drawing.Size(142, 23);
            this.txtHead.TabIndex = 26;
            this.txtHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtHead_MouseDown);
            // 
            // btnRemoveRing2
            // 
            this.btnRemoveRing2.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveRing2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing2.BackgroundImage")));
            this.btnRemoveRing2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveRing2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveRing2.FlatAppearance.BorderSize = 0;
            this.btnRemoveRing2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveRing2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveRing2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRing2.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing2.HoverImage")));
            this.btnRemoveRing2.Location = new System.Drawing.Point(233, 203);
            this.btnRemoveRing2.Name = "btnRemoveRing2";
            this.btnRemoveRing2.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing2.NormalImage")));
            this.btnRemoveRing2.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing2.PressedImage")));
            this.btnRemoveRing2.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveRing2.TabIndex = 27;
            this.btnRemoveRing2.TextIB = "";
            this.btnRemoveRing2.UseVisualStyleBackColor = true;
            this.btnRemoveRing2.Click += new System.EventHandler(this.btnRemoveRing2_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Off Hand";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ring 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Main Hand";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Body";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnRemoveOffHand
            // 
            this.btnRemoveOffHand.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveOffHand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveOffHand.BackgroundImage")));
            this.btnRemoveOffHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveOffHand.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveOffHand.FlatAppearance.BorderSize = 0;
            this.btnRemoveOffHand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveOffHand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveOffHand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOffHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOffHand.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveOffHand.HoverImage")));
            this.btnRemoveOffHand.Location = new System.Drawing.Point(233, 147);
            this.btnRemoveOffHand.Name = "btnRemoveOffHand";
            this.btnRemoveOffHand.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveOffHand.NormalImage")));
            this.btnRemoveOffHand.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveOffHand.PressedImage")));
            this.btnRemoveOffHand.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveOffHand.TabIndex = 20;
            this.btnRemoveOffHand.TextIB = "";
            this.btnRemoveOffHand.UseVisualStyleBackColor = true;
            this.btnRemoveOffHand.Click += new System.EventHandler(this.btnRemoveOffHand_Click);
            // 
            // txtRing1
            // 
            this.txtRing1.AllowDrop = true;
            this.txtRing1.BackColor = System.Drawing.SystemColors.Window;
            this.txtRing1.Location = new System.Drawing.Point(89, 174);
            this.txtRing1.Name = "txtRing1";
            this.txtRing1.ReadOnly = true;
            this.txtRing1.Size = new System.Drawing.Size(142, 23);
            this.txtRing1.TabIndex = 17;
            this.txtRing1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRing1_MouseDown);
            // 
            // txtOffHand
            // 
            this.txtOffHand.AllowDrop = true;
            this.txtOffHand.BackColor = System.Drawing.SystemColors.Window;
            this.txtOffHand.Location = new System.Drawing.Point(89, 146);
            this.txtOffHand.Name = "txtOffHand";
            this.txtOffHand.ReadOnly = true;
            this.txtOffHand.Size = new System.Drawing.Size(142, 23);
            this.txtOffHand.TabIndex = 18;
            this.txtOffHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtOffHand_MouseDown);
            // 
            // btnRemoveRing1
            // 
            this.btnRemoveRing1.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveRing1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing1.BackgroundImage")));
            this.btnRemoveRing1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveRing1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveRing1.FlatAppearance.BorderSize = 0;
            this.btnRemoveRing1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveRing1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveRing1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveRing1.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing1.HoverImage")));
            this.btnRemoveRing1.Location = new System.Drawing.Point(233, 175);
            this.btnRemoveRing1.Name = "btnRemoveRing1";
            this.btnRemoveRing1.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing1.NormalImage")));
            this.btnRemoveRing1.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing1.PressedImage")));
            this.btnRemoveRing1.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveRing1.TabIndex = 19;
            this.btnRemoveRing1.TextIB = "";
            this.btnRemoveRing1.UseVisualStyleBackColor = true;
            this.btnRemoveRing1.Click += new System.EventHandler(this.btnRemoveRing1_Click);
            // 
            // btnRemoveMainHand
            // 
            this.btnRemoveMainHand.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveMainHand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveMainHand.BackgroundImage")));
            this.btnRemoveMainHand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveMainHand.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveMainHand.FlatAppearance.BorderSize = 0;
            this.btnRemoveMainHand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveMainHand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveMainHand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMainHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveMainHand.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveMainHand.HoverImage")));
            this.btnRemoveMainHand.Location = new System.Drawing.Point(233, 119);
            this.btnRemoveMainHand.Name = "btnRemoveMainHand";
            this.btnRemoveMainHand.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveMainHand.NormalImage")));
            this.btnRemoveMainHand.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveMainHand.PressedImage")));
            this.btnRemoveMainHand.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveMainHand.TabIndex = 5;
            this.btnRemoveMainHand.TextIB = "";
            this.btnRemoveMainHand.UseVisualStyleBackColor = true;
            this.btnRemoveMainHand.Click += new System.EventHandler(this.btnRemoveMainHand_Click);
            // 
            // txtBody
            // 
            this.txtBody.AllowDrop = true;
            this.txtBody.BackColor = System.Drawing.SystemColors.Window;
            this.txtBody.Location = new System.Drawing.Point(89, 90);
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.Size = new System.Drawing.Size(142, 23);
            this.txtBody.TabIndex = 2;
            this.txtBody.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBody_MouseDown);
            // 
            // txtMainHand
            // 
            this.txtMainHand.AllowDrop = true;
            this.txtMainHand.BackColor = System.Drawing.SystemColors.Window;
            this.txtMainHand.Location = new System.Drawing.Point(89, 118);
            this.txtMainHand.Name = "txtMainHand";
            this.txtMainHand.ReadOnly = true;
            this.txtMainHand.Size = new System.Drawing.Size(142, 23);
            this.txtMainHand.TabIndex = 3;
            this.txtMainHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtMainHand_MouseDown);
            // 
            // btnRemoveBody
            // 
            this.btnRemoveBody.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveBody.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveBody.BackgroundImage")));
            this.btnRemoveBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveBody.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveBody.FlatAppearance.BorderSize = 0;
            this.btnRemoveBody.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveBody.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveBody.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveBody.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveBody.HoverImage")));
            this.btnRemoveBody.Location = new System.Drawing.Point(233, 91);
            this.btnRemoveBody.Name = "btnRemoveBody";
            this.btnRemoveBody.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveBody.NormalImage")));
            this.btnRemoveBody.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveBody.PressedImage")));
            this.btnRemoveBody.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveBody.TabIndex = 4;
            this.btnRemoveBody.TextIB = "";
            this.btnRemoveBody.UseVisualStyleBackColor = true;
            this.btnRemoveBody.Click += new System.EventHandler(this.btnRemoveBody_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.BorderThickness = 2F;
            this.groupBox1.Controls.Add(this.dgvInventory);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.HeaderImage")));
            this.groupBox1.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(280, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 477);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INVENTORY";
            this.groupBox1.TextIB = "iceBlinkGBMedium1";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvInventory.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(6, 32);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(220, 439);
            this.dgvInventory.TabIndex = 43;
            this.dgvInventory.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvInventory_DataError);
            this.dgvInventory.SelectionChanged += new System.EventHandler(this.dgvInventory_SelectionChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox4.BorderThickness = 2F;
            this.groupBox4.Controls.Add(this.dgvShopItems);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox4.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.HeaderImage")));
            this.groupBox4.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(599, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 310);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ITEMS FOR SALE";
            this.groupBox4.TextIB = "iceBlinkGBMedium1";
            // 
            // dgvShopItems
            // 
            this.dgvShopItems.AllowUserToAddRows = false;
            this.dgvShopItems.AllowUserToDeleteRows = false;
            this.dgvShopItems.AllowUserToResizeRows = false;
            this.dgvShopItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvShopItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvShopItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvShopItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopItems.Location = new System.Drawing.Point(6, 32);
            this.dgvShopItems.MultiSelect = false;
            this.dgvShopItems.Name = "dgvShopItems";
            this.dgvShopItems.ReadOnly = true;
            this.dgvShopItems.RowHeadersVisible = false;
            this.dgvShopItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShopItems.Size = new System.Drawing.Size(220, 272);
            this.dgvShopItems.TabIndex = 42;
            this.dgvShopItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvShopItems_DataError);
            this.dgvShopItems.SelectionChanged += new System.EventHandler(this.dgvShopItems_SelectionChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.groupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.BorderThickness = 2F;
            this.groupBox5.Controls.Add(this.pbShopItemIcon);
            this.groupBox5.Controls.Add(this.rtxtShopItemDesc);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.HeaderForeColor = System.Drawing.Color.White;
            this.groupBox5.HeaderImage = ((System.Drawing.Image)(resources.GetObject("groupBox5.HeaderImage")));
            this.groupBox5.HeaderShadowColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(568, 372);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(263, 201);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SELECTED ITEM INFORMATION";
            this.groupBox5.TextIB = "iceBlinkGBMedium1";
            // 
            // pbShopItemIcon
            // 
            this.pbShopItemIcon.BackColor = System.Drawing.Color.White;
            this.pbShopItemIcon.Location = new System.Drawing.Point(194, 33);
            this.pbShopItemIcon.Name = "pbShopItemIcon";
            this.pbShopItemIcon.Size = new System.Drawing.Size(64, 64);
            this.pbShopItemIcon.TabIndex = 25;
            this.pbShopItemIcon.TabStop = false;
            // 
            // rtxtShopItemDesc
            // 
            this.rtxtShopItemDesc.Location = new System.Drawing.Point(4, 31);
            this.rtxtShopItemDesc.Name = "rtxtShopItemDesc";
            this.rtxtShopItemDesc.ReadOnly = true;
            this.rtxtShopItemDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtShopItemDesc.Size = new System.Drawing.Size(185, 164);
            this.rtxtShopItemDesc.TabIndex = 26;
            this.rtxtShopItemDesc.Text = "";
            // 
            // btnBuyItem
            // 
            this.btnBuyItem.BackColor = System.Drawing.Color.Transparent;
            this.btnBuyItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuyItem.BackgroundImage")));
            this.btnBuyItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuyItem.DisabledImage = null;
            this.btnBuyItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBuyItem.FlatAppearance.BorderSize = 0;
            this.btnBuyItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBuyItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBuyItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnBuyItem.HoverImage")));
            this.btnBuyItem.Location = new System.Drawing.Point(518, 119);
            this.btnBuyItem.Name = "btnBuyItem";
            this.btnBuyItem.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnBuyItem.NormalImage")));
            this.btnBuyItem.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnBuyItem.PressedImage")));
            this.btnBuyItem.Size = new System.Drawing.Size(75, 53);
            this.btnBuyItem.TabIndex = 40;
            this.btnBuyItem.TextIB = "BUY ITEM";
            this.btnBuyItem.UseVisualStyleBackColor = true;
            this.btnBuyItem.Click += new System.EventHandler(this.btnBuyItem_Click);
            // 
            // btnSellItem
            // 
            this.btnSellItem.BackColor = System.Drawing.Color.Transparent;
            this.btnSellItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSellItem.BackgroundImage")));
            this.btnSellItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSellItem.DisabledImage = null;
            this.btnSellItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSellItem.FlatAppearance.BorderSize = 0;
            this.btnSellItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSellItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSellItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnSellItem.HoverImage")));
            this.btnSellItem.Location = new System.Drawing.Point(518, 181);
            this.btnSellItem.Name = "btnSellItem";
            this.btnSellItem.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnSellItem.NormalImage")));
            this.btnSellItem.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnSellItem.PressedImage")));
            this.btnSellItem.Size = new System.Drawing.Size(75, 53);
            this.btnSellItem.TabIndex = 41;
            this.btnSellItem.TextIB = "SELL ITEM";
            this.btnSellItem.UseVisualStyleBackColor = true;
            this.btnSellItem.Click += new System.EventHandler(this.btnSellItem_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtFunds);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(518, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 76);
            this.panel2.TabIndex = 42;
            // 
            // txtFunds
            // 
            this.txtFunds.AutoSize = true;
            this.txtFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFunds.Location = new System.Drawing.Point(9, 45);
            this.txtFunds.Name = "txtFunds";
            this.txtFunds.Size = new System.Drawing.Size(52, 17);
            this.txtFunds.TabIndex = 24;
            this.txtFunds.Text = "00/000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 34);
            this.label11.TabIndex = 23;
            this.label11.Text = "Party\r\nFunds:";
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(845, 585);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSellItem);
            this.Controls.Add(this.btnBuyItem);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbtnPc5);
            this.Controls.Add(this.rbtnPc4);
            this.Controls.Add(this.btnUseItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.rbtnPc3);
            this.Controls.Add(this.rbtnPc2);
            this.Controls.Add(this.rbtnPc1);
            this.Controls.Add(this.rbtnPc0);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(845, 585);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(845, 585);
            this.Name = "Store";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SHOP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Store_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.rbtnPc0, 0);
            this.Controls.SetChildIndex(this.rbtnPc1, 0);
            this.Controls.SetChildIndex(this.rbtnPc2, 0);
            this.Controls.SetChildIndex(this.rbtnPc3, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnDeleteItem, 0);
            this.Controls.SetChildIndex(this.btnUseItem, 0);
            this.Controls.SetChildIndex(this.rbtnPc4, 0);
            this.Controls.SetChildIndex(this.rbtnPc5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.btnBuyItem, 0);
            this.Controls.SetChildIndex(this.btnSellItem, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopItems)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbShopItemIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtEncumbrance;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.RadioButton rbtnPc5;
        public System.Windows.Forms.RadioButton rbtnPc4;
        private IceBlinkButtonSmall btnUseItem;
        private IceBlinkButtonSmall btnDeleteItem;
        private IceBlinkGroupBoxMedium groupBox3;
        private System.Windows.Forms.PictureBox pbItemIcon;
        private System.Windows.Forms.RichTextBox rtxtDesc;
        public System.Windows.Forms.RadioButton rbtnPc3;
        public System.Windows.Forms.RadioButton rbtnPc2;
        public System.Windows.Forms.RadioButton rbtnPc1;
        public System.Windows.Forms.RadioButton rbtnPc0;
        private IceBlinkGroupBoxMedium groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private IceBlinkButtonRArrow btnRemoveFeet;
        private System.Windows.Forms.TextBox txtNeck;
        private System.Windows.Forms.TextBox txtFeet;
        private IceBlinkButtonRArrow btnRemoveNeck;
        private IceBlinkButtonRArrow btnRemoveHead;
        private System.Windows.Forms.TextBox txtRing2;
        private System.Windows.Forms.TextBox txtHead;
        private IceBlinkButtonRArrow btnRemoveRing2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private IceBlinkButtonRArrow btnRemoveOffHand;
        private System.Windows.Forms.TextBox txtRing1;
        private System.Windows.Forms.TextBox txtOffHand;
        private IceBlinkButtonRArrow btnRemoveRing1;
        private IceBlinkButtonRArrow btnRemoveMainHand;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TextBox txtMainHand;
        private IceBlinkButtonRArrow btnRemoveBody;
        private IceBlinkGroupBoxMedium groupBox1;
        private IceBlinkGroupBoxMedium groupBox4;
        private IceBlinkGroupBoxMedium groupBox5;
        private System.Windows.Forms.PictureBox pbShopItemIcon;
        private System.Windows.Forms.RichTextBox rtxtShopItemDesc;
        private IceBlinkButtonSmall btnBuyItem;
        private IceBlinkButtonSmall btnSellItem;
        private System.Windows.Forms.DataGridView dgvShopItems;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtFunds;
        private System.Windows.Forms.Label label11;
    }
}