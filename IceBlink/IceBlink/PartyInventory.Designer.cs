namespace IceBlink
{
    partial class PartyInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartyInventory));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUseItem = new IceBlink.IceBlinkButtonSmall();
            this.btnDeleteItem = new IceBlink.IceBlinkButtonSmall();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEncumbrance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.iceBlinkGroupBoxMedium3 = new IceBlink.IceBlinkGroupBoxMedium();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRemoveBody = new IceBlink.IceBlinkButtonRArrow();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMainHand = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnRemoveFeet = new IceBlink.IceBlinkButtonRArrow();
            this.btnRemoveMainHand = new IceBlink.IceBlinkButtonRArrow();
            this.txtNeck = new System.Windows.Forms.TextBox();
            this.btnRemoveRing1 = new IceBlink.IceBlinkButtonRArrow();
            this.txtFeet = new System.Windows.Forms.TextBox();
            this.txtOffHand = new System.Windows.Forms.TextBox();
            this.btnRemoveNeck = new IceBlink.IceBlinkButtonRArrow();
            this.txtRing1 = new System.Windows.Forms.TextBox();
            this.btnRemoveHead = new IceBlink.IceBlinkButtonRArrow();
            this.btnRemoveOffHand = new IceBlink.IceBlinkButtonRArrow();
            this.txtRing2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveRing2 = new IceBlink.IceBlinkButtonRArrow();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iceBlinkGroupBoxMedium2 = new IceBlink.IceBlinkGroupBoxMedium();
            this.lbxInventory = new System.Windows.Forms.ListBox();
            this.iceBlinkGroupBoxMedium1 = new IceBlink.IceBlinkGroupBoxMedium();
            this.pbItemIcon = new System.Windows.Forms.PictureBox();
            this.rtxtDesc = new System.Windows.Forms.RichTextBox();
            this.rbtnPc5 = new System.Windows.Forms.RadioButton();
            this.rbtnPc4 = new System.Windows.Forms.RadioButton();
            this.rbtnPc3 = new System.Windows.Forms.RadioButton();
            this.rbtnPc2 = new System.Windows.Forms.RadioButton();
            this.rbtnPc1 = new System.Windows.Forms.RadioButton();
            this.rbtnPc0 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.iceBlinkGroupBoxMedium3.SuspendLayout();
            this.iceBlinkGroupBoxMedium2.SuspendLayout();
            this.iceBlinkGroupBoxMedium1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).BeginInit();
            this.SuspendLayout();
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
            this.btnUseItem.Location = new System.Drawing.Point(278, 511);
            this.btnUseItem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUseItem.Name = "btnUseItem";
            this.btnUseItem.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.NormalImage")));
            this.btnUseItem.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnUseItem.PressedImage")));
            this.btnUseItem.Size = new System.Drawing.Size(50, 50);
            this.btnUseItem.TabIndex = 22;
            this.btnUseItem.TextIB = "USE";
            this.toolTip1.SetToolTip(this.btnUseItem, "Use Selected Item on Selected Character");
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
            this.btnDeleteItem.Location = new System.Drawing.Point(460, 511);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.NormalImage")));
            this.btnDeleteItem.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.PressedImage")));
            this.btnDeleteItem.Size = new System.Drawing.Size(50, 50);
            this.btnDeleteItem.TabIndex = 21;
            this.btnDeleteItem.TextIB = "DROP";
            this.toolTip1.SetToolTip(this.btnDeleteItem, "Delete Selected Item");
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtEncumbrance);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(335, 511);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 50);
            this.panel1.TabIndex = 25;
            // 
            // txtEncumbrance
            // 
            this.txtEncumbrance.AutoSize = true;
            this.txtEncumbrance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncumbrance.Location = new System.Drawing.Point(32, 25);
            this.txtEncumbrance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Encumbrance:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iceBlinkGroupBoxMedium3
            // 
            this.iceBlinkGroupBoxMedium3.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium3.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium3.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label5);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtHead);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label6);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveBody);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label7);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtMainHand);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label8);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtBody);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveFeet);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveMainHand);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtNeck);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveRing1);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtFeet);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtOffHand);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveNeck);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtRing1);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveHead);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveOffHand);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.txtRing2);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label1);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label2);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.btnRemoveRing2);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label3);
            this.iceBlinkGroupBoxMedium3.Controls.Add(this.label4);
            this.iceBlinkGroupBoxMedium3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium3.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium3.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium3.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium3.Location = new System.Drawing.Point(12, 108);
            this.iceBlinkGroupBoxMedium3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iceBlinkGroupBoxMedium3.Name = "iceBlinkGroupBoxMedium3";
            this.iceBlinkGroupBoxMedium3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iceBlinkGroupBoxMedium3.Size = new System.Drawing.Size(254, 259);
            this.iceBlinkGroupBoxMedium3.TabIndex = 94;
            this.iceBlinkGroupBoxMedium3.TabStop = false;
            this.iceBlinkGroupBoxMedium3.Text = "EQUIPPED ITEMS";
            this.iceBlinkGroupBoxMedium3.TextIB = "CHARACTERS";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 36;
            this.label5.Text = "Feet";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtHead
            // 
            this.txtHead.AllowDrop = true;
            this.txtHead.BackColor = System.Drawing.SystemColors.Window;
            this.txtHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHead.Location = new System.Drawing.Point(85, 32);
            this.txtHead.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHead.Name = "txtHead";
            this.txtHead.ReadOnly = true;
            this.txtHead.Size = new System.Drawing.Size(136, 20);
            this.txtHead.TabIndex = 26;
            this.txtHead.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtHead_DragDrop);
            this.txtHead.DragOver += new System.Windows.Forms.DragEventHandler(this.txtHead_DragOver);
            this.txtHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtHead_MouseDown);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Neck";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.btnRemoveBody.Location = new System.Drawing.Point(227, 87);
            this.btnRemoveBody.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveBody.Name = "btnRemoveBody";
            this.btnRemoveBody.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveBody.NormalImage")));
            this.btnRemoveBody.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveBody.PressedImage")));
            this.btnRemoveBody.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveBody.TabIndex = 4;
            this.btnRemoveBody.TextIB = "";
            this.btnRemoveBody.UseVisualStyleBackColor = true;
            this.btnRemoveBody.Click += new System.EventHandler(this.btnRemoveBody_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "Head";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMainHand
            // 
            this.txtMainHand.AllowDrop = true;
            this.txtMainHand.BackColor = System.Drawing.SystemColors.Window;
            this.txtMainHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainHand.Location = new System.Drawing.Point(85, 116);
            this.txtMainHand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMainHand.Name = "txtMainHand";
            this.txtMainHand.ReadOnly = true;
            this.txtMainHand.Size = new System.Drawing.Size(136, 20);
            this.txtMainHand.TabIndex = 3;
            this.txtMainHand.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMainHand_DragDrop);
            this.txtMainHand.DragOver += new System.Windows.Forms.DragEventHandler(this.txtMainHand_DragOver);
            this.txtMainHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtMainHand_MouseDown);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 33;
            this.label8.Text = "Ring 2";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBody
            // 
            this.txtBody.AllowDrop = true;
            this.txtBody.BackColor = System.Drawing.SystemColors.Window;
            this.txtBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.Location = new System.Drawing.Point(85, 88);
            this.txtBody.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.Size = new System.Drawing.Size(136, 20);
            this.txtBody.TabIndex = 2;
            this.txtBody.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBody_DragDrop);
            this.txtBody.DragOver += new System.Windows.Forms.DragEventHandler(this.txtBody_DragOver);
            this.txtBody.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtBody_MouseDown);
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
            this.btnRemoveFeet.Location = new System.Drawing.Point(227, 227);
            this.btnRemoveFeet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveFeet.Name = "btnRemoveFeet";
            this.btnRemoveFeet.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFeet.NormalImage")));
            this.btnRemoveFeet.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveFeet.PressedImage")));
            this.btnRemoveFeet.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveFeet.TabIndex = 32;
            this.btnRemoveFeet.TextIB = "";
            this.btnRemoveFeet.UseVisualStyleBackColor = true;
            this.btnRemoveFeet.Click += new System.EventHandler(this.btnRemoveFeet_Click);
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
            this.btnRemoveMainHand.Location = new System.Drawing.Point(227, 115);
            this.btnRemoveMainHand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveMainHand.Name = "btnRemoveMainHand";
            this.btnRemoveMainHand.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveMainHand.NormalImage")));
            this.btnRemoveMainHand.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveMainHand.PressedImage")));
            this.btnRemoveMainHand.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveMainHand.TabIndex = 5;
            this.btnRemoveMainHand.TextIB = "";
            this.btnRemoveMainHand.UseVisualStyleBackColor = true;
            this.btnRemoveMainHand.Click += new System.EventHandler(this.btnRemoveMainHand_Click);
            // 
            // txtNeck
            // 
            this.txtNeck.AllowDrop = true;
            this.txtNeck.BackColor = System.Drawing.SystemColors.Window;
            this.txtNeck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNeck.Location = new System.Drawing.Point(85, 60);
            this.txtNeck.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNeck.Name = "txtNeck";
            this.txtNeck.ReadOnly = true;
            this.txtNeck.Size = new System.Drawing.Size(136, 20);
            this.txtNeck.TabIndex = 29;
            this.txtNeck.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtNeck_DragDrop);
            this.txtNeck.DragOver += new System.Windows.Forms.DragEventHandler(this.txtNeck_DragOver);
            this.txtNeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNeck_MouseDown);
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
            this.btnRemoveRing1.Location = new System.Drawing.Point(227, 171);
            this.btnRemoveRing1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveRing1.Name = "btnRemoveRing1";
            this.btnRemoveRing1.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing1.NormalImage")));
            this.btnRemoveRing1.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing1.PressedImage")));
            this.btnRemoveRing1.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveRing1.TabIndex = 19;
            this.btnRemoveRing1.TextIB = "";
            this.btnRemoveRing1.UseVisualStyleBackColor = true;
            this.btnRemoveRing1.Click += new System.EventHandler(this.btnRemoveRing1_Click);
            // 
            // txtFeet
            // 
            this.txtFeet.AllowDrop = true;
            this.txtFeet.BackColor = System.Drawing.SystemColors.Window;
            this.txtFeet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeet.Location = new System.Drawing.Point(85, 228);
            this.txtFeet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFeet.Name = "txtFeet";
            this.txtFeet.ReadOnly = true;
            this.txtFeet.Size = new System.Drawing.Size(136, 20);
            this.txtFeet.TabIndex = 30;
            this.txtFeet.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFeet_DragDrop);
            this.txtFeet.DragOver += new System.Windows.Forms.DragEventHandler(this.txtFeet_DragOver);
            this.txtFeet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtFeet_MouseDown);
            // 
            // txtOffHand
            // 
            this.txtOffHand.AllowDrop = true;
            this.txtOffHand.BackColor = System.Drawing.SystemColors.Window;
            this.txtOffHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffHand.Location = new System.Drawing.Point(85, 144);
            this.txtOffHand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOffHand.Name = "txtOffHand";
            this.txtOffHand.ReadOnly = true;
            this.txtOffHand.Size = new System.Drawing.Size(136, 20);
            this.txtOffHand.TabIndex = 18;
            this.txtOffHand.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtOffHand_DragDrop);
            this.txtOffHand.DragOver += new System.Windows.Forms.DragEventHandler(this.txtOffHand_DragOver);
            this.txtOffHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtOffHand_MouseDown);
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
            this.btnRemoveNeck.Location = new System.Drawing.Point(227, 59);
            this.btnRemoveNeck.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveNeck.Name = "btnRemoveNeck";
            this.btnRemoveNeck.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveNeck.NormalImage")));
            this.btnRemoveNeck.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveNeck.PressedImage")));
            this.btnRemoveNeck.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveNeck.TabIndex = 31;
            this.btnRemoveNeck.TextIB = "";
            this.btnRemoveNeck.UseVisualStyleBackColor = true;
            this.btnRemoveNeck.Click += new System.EventHandler(this.btnRemoveNeck_Click);
            // 
            // txtRing1
            // 
            this.txtRing1.AllowDrop = true;
            this.txtRing1.BackColor = System.Drawing.SystemColors.Window;
            this.txtRing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRing1.Location = new System.Drawing.Point(85, 172);
            this.txtRing1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRing1.Name = "txtRing1";
            this.txtRing1.ReadOnly = true;
            this.txtRing1.Size = new System.Drawing.Size(136, 20);
            this.txtRing1.TabIndex = 17;
            this.txtRing1.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtRing1_DragDrop);
            this.txtRing1.DragOver += new System.Windows.Forms.DragEventHandler(this.txtRing1_DragOver);
            this.txtRing1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRing1_MouseDown);
            // 
            // btnRemoveHead
            // 
            this.btnRemoveHead.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveHead.BackgroundImage = global::IceBlink.Properties.Resources.b_rarw_normal;
            this.btnRemoveHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveHead.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveHead.FlatAppearance.BorderSize = 0;
            this.btnRemoveHead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveHead.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRemoveHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveHead.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveHead.HoverImage")));
            this.btnRemoveHead.Location = new System.Drawing.Point(227, 31);
            this.btnRemoveHead.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveHead.Name = "btnRemoveHead";
            this.btnRemoveHead.NormalImage = global::IceBlink.Properties.Resources.b_rarw_normal;
            this.btnRemoveHead.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveHead.PressedImage")));
            this.btnRemoveHead.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveHead.TabIndex = 28;
            this.btnRemoveHead.TextIB = "";
            this.btnRemoveHead.UseVisualStyleBackColor = true;
            this.btnRemoveHead.Click += new System.EventHandler(this.btnRemoveHead_Click);
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
            this.btnRemoveOffHand.Location = new System.Drawing.Point(227, 143);
            this.btnRemoveOffHand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveOffHand.Name = "btnRemoveOffHand";
            this.btnRemoveOffHand.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveOffHand.NormalImage")));
            this.btnRemoveOffHand.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveOffHand.PressedImage")));
            this.btnRemoveOffHand.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveOffHand.TabIndex = 20;
            this.btnRemoveOffHand.TextIB = "";
            this.btnRemoveOffHand.UseVisualStyleBackColor = true;
            this.btnRemoveOffHand.Click += new System.EventHandler(this.btnRemoveOffHand_Click);
            // 
            // txtRing2
            // 
            this.txtRing2.AllowDrop = true;
            this.txtRing2.BackColor = System.Drawing.SystemColors.Window;
            this.txtRing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRing2.Location = new System.Drawing.Point(85, 200);
            this.txtRing2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRing2.Name = "txtRing2";
            this.txtRing2.ReadOnly = true;
            this.txtRing2.Size = new System.Drawing.Size(136, 20);
            this.txtRing2.TabIndex = 25;
            this.txtRing2.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtRing2_DragDrop);
            this.txtRing2.DragOver += new System.Windows.Forms.DragEventHandler(this.txtRing2_DragOver);
            this.txtRing2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRing2_MouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Body";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Main Hand";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.btnRemoveRing2.Location = new System.Drawing.Point(227, 199);
            this.btnRemoveRing2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRemoveRing2.Name = "btnRemoveRing2";
            this.btnRemoveRing2.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing2.NormalImage")));
            this.btnRemoveRing2.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRing2.PressedImage")));
            this.btnRemoveRing2.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveRing2.TabIndex = 27;
            this.btnRemoveRing2.TextIB = "";
            this.btnRemoveRing2.UseVisualStyleBackColor = true;
            this.btnRemoveRing2.Click += new System.EventHandler(this.btnRemoveRing2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ring 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Off Hand";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iceBlinkGroupBoxMedium2
            // 
            this.iceBlinkGroupBoxMedium2.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium2.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium2.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium2.Controls.Add(this.lbxInventory);
            this.iceBlinkGroupBoxMedium2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium2.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium2.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium2.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium2.Location = new System.Drawing.Point(278, 38);
            this.iceBlinkGroupBoxMedium2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iceBlinkGroupBoxMedium2.Name = "iceBlinkGroupBoxMedium2";
            this.iceBlinkGroupBoxMedium2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iceBlinkGroupBoxMedium2.Size = new System.Drawing.Size(232, 462);
            this.iceBlinkGroupBoxMedium2.TabIndex = 93;
            this.iceBlinkGroupBoxMedium2.TabStop = false;
            this.iceBlinkGroupBoxMedium2.Text = "INVENTORY";
            this.iceBlinkGroupBoxMedium2.TextIB = "CHARACTERS";
            // 
            // lbxInventory
            // 
            this.lbxInventory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxInventory.FormattingEnabled = true;
            this.lbxInventory.ItemHeight = 16;
            this.lbxInventory.Location = new System.Drawing.Point(6, 32);
            this.lbxInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbxInventory.Name = "lbxInventory";
            this.lbxInventory.Size = new System.Drawing.Size(220, 420);
            this.lbxInventory.TabIndex = 0;
            this.lbxInventory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbxInventory_MouseDown);
            // 
            // iceBlinkGroupBoxMedium1
            // 
            this.iceBlinkGroupBoxMedium1.BackColor = System.Drawing.Color.Transparent;
            this.iceBlinkGroupBoxMedium1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.iceBlinkGroupBoxMedium1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iceBlinkGroupBoxMedium1.BorderThickness = 2F;
            this.iceBlinkGroupBoxMedium1.Controls.Add(this.pbItemIcon);
            this.iceBlinkGroupBoxMedium1.Controls.Add(this.rtxtDesc);
            this.iceBlinkGroupBoxMedium1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceBlinkGroupBoxMedium1.HeaderForeColor = System.Drawing.Color.White;
            this.iceBlinkGroupBoxMedium1.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.iceBlinkGroupBoxMedium1.HeaderShadowColor = System.Drawing.Color.Black;
            this.iceBlinkGroupBoxMedium1.Location = new System.Drawing.Point(12, 373);
            this.iceBlinkGroupBoxMedium1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iceBlinkGroupBoxMedium1.Name = "iceBlinkGroupBoxMedium1";
            this.iceBlinkGroupBoxMedium1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iceBlinkGroupBoxMedium1.Size = new System.Drawing.Size(254, 191);
            this.iceBlinkGroupBoxMedium1.TabIndex = 92;
            this.iceBlinkGroupBoxMedium1.TabStop = false;
            this.iceBlinkGroupBoxMedium1.Text = "SELECTED ITEM INFORMATION";
            this.iceBlinkGroupBoxMedium1.TextIB = "CHARACTERS";
            // 
            // pbItemIcon
            // 
            this.pbItemIcon.BackColor = System.Drawing.Color.White;
            this.pbItemIcon.Location = new System.Drawing.Point(186, 32);
            this.pbItemIcon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbItemIcon.Name = "pbItemIcon";
            this.pbItemIcon.Size = new System.Drawing.Size(64, 64);
            this.pbItemIcon.TabIndex = 25;
            this.pbItemIcon.TabStop = false;
            // 
            // rtxtDesc
            // 
            this.rtxtDesc.Location = new System.Drawing.Point(3, 30);
            this.rtxtDesc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rtxtDesc.Name = "rtxtDesc";
            this.rtxtDesc.ReadOnly = true;
            this.rtxtDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtDesc.Size = new System.Drawing.Size(179, 157);
            this.rtxtDesc.TabIndex = 26;
            this.rtxtDesc.Text = "";
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
            this.rbtnPc5.Location = new System.Drawing.Point(230, 38);
            this.rbtnPc5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc5.Name = "rbtnPc5";
            this.rbtnPc5.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc5.TabIndex = 24;
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
            this.rbtnPc4.Location = new System.Drawing.Point(185, 38);
            this.rbtnPc4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc4.Name = "rbtnPc4";
            this.rbtnPc4.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc4.TabIndex = 23;
            this.rbtnPc4.TabStop = true;
            this.rbtnPc4.UseVisualStyleBackColor = true;
            this.rbtnPc4.Visible = false;
            this.rbtnPc4.CheckedChanged += new System.EventHandler(this.rbtnPc4_CheckedChanged);
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
            this.rbtnPc3.Location = new System.Drawing.Point(140, 38);
            this.rbtnPc3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc3.Name = "rbtnPc3";
            this.rbtnPc3.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc3.TabIndex = 19;
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
            this.rbtnPc2.Location = new System.Drawing.Point(95, 38);
            this.rbtnPc2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc2.Name = "rbtnPc2";
            this.rbtnPc2.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc2.TabIndex = 18;
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
            this.rbtnPc1.Location = new System.Drawing.Point(50, 38);
            this.rbtnPc1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc1.Name = "rbtnPc1";
            this.rbtnPc1.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc1.TabIndex = 17;
            this.rbtnPc1.TabStop = true;
            this.rbtnPc1.UseVisualStyleBackColor = true;
            this.rbtnPc1.Visible = false;
            this.rbtnPc1.CheckedChanged += new System.EventHandler(this.rbtnPc1_CheckedChanged);
            // 
            // rbtnPc0
            // 
            this.rbtnPc0.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPc0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc0.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc0.Location = new System.Drawing.Point(5, 38);
            this.rbtnPc0.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc0.Name = "rbtnPc0";
            this.rbtnPc0.Size = new System.Drawing.Size(44, 66);
            this.rbtnPc0.TabIndex = 16;
            this.rbtnPc0.TabStop = true;
            this.rbtnPc0.UseVisualStyleBackColor = true;
            this.rbtnPc0.Visible = false;
            this.rbtnPc0.CheckedChanged += new System.EventHandler(this.rbtnPc0_CheckedChanged);
            // 
            // PartyInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(517, 576);
            this.Controls.Add(this.iceBlinkGroupBoxMedium3);
            this.Controls.Add(this.iceBlinkGroupBoxMedium2);
            this.Controls.Add(this.iceBlinkGroupBoxMedium1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbtnPc5);
            this.Controls.Add(this.rbtnPc4);
            this.Controls.Add(this.btnUseItem);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.rbtnPc3);
            this.Controls.Add(this.rbtnPc2);
            this.Controls.Add(this.rbtnPc1);
            this.Controls.Add(this.rbtnPc0);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(517, 576);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(517, 524);
            this.Name = "PartyInventory";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "INVENTORY";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartyInventory_FormClosing);
            this.Controls.SetChildIndex(this.rbtnPc0, 0);
            this.Controls.SetChildIndex(this.rbtnPc1, 0);
            this.Controls.SetChildIndex(this.rbtnPc2, 0);
            this.Controls.SetChildIndex(this.rbtnPc3, 0);
            this.Controls.SetChildIndex(this.btnDeleteItem, 0);
            this.Controls.SetChildIndex(this.btnUseItem, 0);
            this.Controls.SetChildIndex(this.rbtnPc4, 0);
            this.Controls.SetChildIndex(this.rbtnPc5, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium1, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium2, 0);
            this.Controls.SetChildIndex(this.iceBlinkGroupBoxMedium3, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.iceBlinkGroupBoxMedium3.ResumeLayout(false);
            this.iceBlinkGroupBoxMedium3.PerformLayout();
            this.iceBlinkGroupBoxMedium2.ResumeLayout(false);
            this.iceBlinkGroupBoxMedium1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxInventory;
        private IceBlink.IceBlinkButtonRArrow btnRemoveMainHand;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TextBox txtMainHand;
        private IceBlink.IceBlinkButtonRArrow btnRemoveBody;
        private IceBlink.IceBlinkButtonRArrow btnRemoveOffHand;
        private System.Windows.Forms.TextBox txtRing1;
        private System.Windows.Forms.TextBox txtOffHand;
        private IceBlink.IceBlinkButtonRArrow btnRemoveRing1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private IceBlink.IceBlinkButtonSmall btnDeleteItem;
        public System.Windows.Forms.RadioButton rbtnPc0;
        public System.Windows.Forms.RadioButton rbtnPc1;
        public System.Windows.Forms.RadioButton rbtnPc2;
        public System.Windows.Forms.RadioButton rbtnPc3;
        public System.Windows.Forms.RadioButton rbtnPc4;
        public System.Windows.Forms.RadioButton rbtnPc5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private IceBlink.IceBlinkButtonRArrow btnRemoveFeet;
        private System.Windows.Forms.TextBox txtNeck;
        private System.Windows.Forms.TextBox txtFeet;
        private IceBlink.IceBlinkButtonRArrow btnRemoveNeck;
        private IceBlink.IceBlinkButtonRArrow btnRemoveHead;
        private System.Windows.Forms.TextBox txtRing2;
        private System.Windows.Forms.TextBox txtHead;
        private IceBlink.IceBlinkButtonRArrow btnRemoveRing2;
        private System.Windows.Forms.PictureBox pbItemIcon;
        private System.Windows.Forms.RichTextBox rtxtDesc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtEncumbrance;
        private System.Windows.Forms.Label label9;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium1;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium2;
        private IceBlink.IceBlinkGroupBoxMedium iceBlinkGroupBoxMedium3;
        public IceBlinkButtonSmall btnUseItem;
    }
}