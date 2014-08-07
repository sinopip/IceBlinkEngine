namespace IceBlink
{
    partial class JournalScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalScreen));
            this.lbxQuests = new System.Windows.Forms.ListBox();
            this.btnQuestNext = new IceBlink.IceBlinkButtonMedium();
            this.btnQuestBack = new IceBlink.IceBlinkButtonMedium();
            this.rtxtQuests = new System.Windows.Forms.RichTextBox();
            this.lbxCompleted = new System.Windows.Forms.ListBox();
            this.btnCompletedNext = new IceBlink.IceBlinkButtonMedium();
            this.btnCompletedBack = new IceBlink.IceBlinkButtonMedium();
            this.rtxtCompleted = new System.Windows.Forms.RichTextBox();
            this.rtxtNotes = new System.Windows.Forms.RichTextBox();
            this.gbQuests = new IceBlink.IceBlinkGroupBoxMedium();
            this.gbCompleted = new IceBlink.IceBlinkGroupBoxMedium();
            this.gbNotes = new IceBlink.IceBlinkGroupBoxMedium();
            this.btnNotesTab = new IceBlink.IceBlinkButtonMedium();
            this.btnCompletedTab = new IceBlink.IceBlinkButtonMedium();
            this.btnQuestsTab = new IceBlink.IceBlinkButtonMedium();
            this.gbQuests.SuspendLayout();
            this.gbCompleted.SuspendLayout();
            this.gbNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxQuests
            // 
            this.lbxQuests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxQuests.BackColor = System.Drawing.Color.Silver;
            this.lbxQuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxQuests.FormattingEnabled = true;
            this.lbxQuests.ItemHeight = 16;
            this.lbxQuests.Location = new System.Drawing.Point(10, 34);
            this.lbxQuests.Name = "lbxQuests";
            this.lbxQuests.Size = new System.Drawing.Size(229, 372);
            this.lbxQuests.TabIndex = 4;
            this.lbxQuests.SelectedIndexChanged += new System.EventHandler(this.lbxQuests_SelectedIndexChanged);
            // 
            // btnQuestNext
            // 
            this.btnQuestNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestNext.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuestNext.BackgroundImage")));
            this.btnQuestNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuestNext.DisabledImage = null;
            this.btnQuestNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestNext.FlatAppearance.BorderSize = 0;
            this.btnQuestNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestNext.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnQuestNext.HoverImage")));
            this.btnQuestNext.Location = new System.Drawing.Point(385, 34);
            this.btnQuestNext.Name = "btnQuestNext";
            this.btnQuestNext.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnQuestNext.NormalImage")));
            this.btnQuestNext.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnQuestNext.PressedImage")));
            this.btnQuestNext.Size = new System.Drawing.Size(130, 32);
            this.btnQuestNext.TabIndex = 3;
            this.btnQuestNext.TextIB = ">>>";
            this.btnQuestNext.UseVisualStyleBackColor = true;
            this.btnQuestNext.Click += new System.EventHandler(this.btnQuestNext_Click);
            // 
            // btnQuestBack
            // 
            this.btnQuestBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuestBack.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuestBack.BackgroundImage")));
            this.btnQuestBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuestBack.DisabledImage = null;
            this.btnQuestBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestBack.FlatAppearance.BorderSize = 0;
            this.btnQuestBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestBack.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnQuestBack.HoverImage")));
            this.btnQuestBack.Location = new System.Drawing.Point(248, 34);
            this.btnQuestBack.Name = "btnQuestBack";
            this.btnQuestBack.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnQuestBack.NormalImage")));
            this.btnQuestBack.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnQuestBack.PressedImage")));
            this.btnQuestBack.Size = new System.Drawing.Size(130, 32);
            this.btnQuestBack.TabIndex = 2;
            this.btnQuestBack.TextIB = "<<<";
            this.btnQuestBack.UseVisualStyleBackColor = true;
            this.btnQuestBack.Click += new System.EventHandler(this.btnQuestBack_Click);
            // 
            // rtxtQuests
            // 
            this.rtxtQuests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtQuests.BackColor = System.Drawing.Color.Silver;
            this.rtxtQuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtQuests.Location = new System.Drawing.Point(248, 70);
            this.rtxtQuests.Name = "rtxtQuests";
            this.rtxtQuests.ReadOnly = true;
            this.rtxtQuests.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtQuests.Size = new System.Drawing.Size(267, 336);
            this.rtxtQuests.TabIndex = 1;
            this.rtxtQuests.Text = "";
            // 
            // lbxCompleted
            // 
            this.lbxCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxCompleted.BackColor = System.Drawing.Color.Silver;
            this.lbxCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxCompleted.FormattingEnabled = true;
            this.lbxCompleted.ItemHeight = 16;
            this.lbxCompleted.Location = new System.Drawing.Point(9, 34);
            this.lbxCompleted.Name = "lbxCompleted";
            this.lbxCompleted.Size = new System.Drawing.Size(230, 372);
            this.lbxCompleted.TabIndex = 6;
            this.lbxCompleted.SelectedIndexChanged += new System.EventHandler(this.lbxCompleted_SelectedIndexChanged);
            // 
            // btnCompletedNext
            // 
            this.btnCompletedNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompletedNext.BackColor = System.Drawing.Color.Transparent;
            this.btnCompletedNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedNext.BackgroundImage")));
            this.btnCompletedNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompletedNext.DisabledImage = null;
            this.btnCompletedNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedNext.FlatAppearance.BorderSize = 0;
            this.btnCompletedNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompletedNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletedNext.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedNext.HoverImage")));
            this.btnCompletedNext.Location = new System.Drawing.Point(385, 34);
            this.btnCompletedNext.Name = "btnCompletedNext";
            this.btnCompletedNext.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedNext.NormalImage")));
            this.btnCompletedNext.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedNext.PressedImage")));
            this.btnCompletedNext.Size = new System.Drawing.Size(130, 32);
            this.btnCompletedNext.TabIndex = 5;
            this.btnCompletedNext.TextIB = ">>>";
            this.btnCompletedNext.UseVisualStyleBackColor = true;
            this.btnCompletedNext.Click += new System.EventHandler(this.btnCompletedNext_Click);
            // 
            // btnCompletedBack
            // 
            this.btnCompletedBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompletedBack.BackColor = System.Drawing.Color.Transparent;
            this.btnCompletedBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedBack.BackgroundImage")));
            this.btnCompletedBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompletedBack.DisabledImage = null;
            this.btnCompletedBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedBack.FlatAppearance.BorderSize = 0;
            this.btnCompletedBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompletedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletedBack.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedBack.HoverImage")));
            this.btnCompletedBack.Location = new System.Drawing.Point(248, 34);
            this.btnCompletedBack.Name = "btnCompletedBack";
            this.btnCompletedBack.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedBack.NormalImage")));
            this.btnCompletedBack.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedBack.PressedImage")));
            this.btnCompletedBack.Size = new System.Drawing.Size(130, 32);
            this.btnCompletedBack.TabIndex = 4;
            this.btnCompletedBack.TextIB = "<<<";
            this.btnCompletedBack.UseVisualStyleBackColor = true;
            this.btnCompletedBack.Click += new System.EventHandler(this.btnCompletedBack_Click);
            // 
            // rtxtCompleted
            // 
            this.rtxtCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtCompleted.BackColor = System.Drawing.Color.Silver;
            this.rtxtCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCompleted.Location = new System.Drawing.Point(248, 70);
            this.rtxtCompleted.Name = "rtxtCompleted";
            this.rtxtCompleted.ReadOnly = true;
            this.rtxtCompleted.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtCompleted.Size = new System.Drawing.Size(267, 336);
            this.rtxtCompleted.TabIndex = 3;
            this.rtxtCompleted.Text = "";
            // 
            // rtxtNotes
            // 
            this.rtxtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtNotes.BackColor = System.Drawing.Color.Silver;
            this.rtxtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtNotes.Location = new System.Drawing.Point(7, 32);
            this.rtxtNotes.Name = "rtxtNotes";
            this.rtxtNotes.Size = new System.Drawing.Size(510, 374);
            this.rtxtNotes.TabIndex = 0;
            this.rtxtNotes.Text = "Enter any notes here";
            this.rtxtNotes.TextChanged += new System.EventHandler(this.rtxtNotes_TextChanged);
            // 
            // gbQuests
            // 
            this.gbQuests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuests.BackColor = System.Drawing.Color.Transparent;
            this.gbQuests.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbQuests.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbQuests.BorderThickness = 2F;
            this.gbQuests.Controls.Add(this.lbxQuests);
            this.gbQuests.Controls.Add(this.btnQuestNext);
            this.gbQuests.Controls.Add(this.rtxtQuests);
            this.gbQuests.Controls.Add(this.btnQuestBack);
            this.gbQuests.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbQuests.HeaderForeColor = System.Drawing.Color.White;
            this.gbQuests.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.gbQuests.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbQuests.Location = new System.Drawing.Point(25, 72);
            this.gbQuests.Name = "gbQuests";
            this.gbQuests.Size = new System.Drawing.Size(523, 413);
            this.gbQuests.TabIndex = 98;
            this.gbQuests.TabStop = false;
            this.gbQuests.Text = "QUESTS";
            this.gbQuests.TextIB = "";
            // 
            // gbCompleted
            // 
            this.gbCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCompleted.BackColor = System.Drawing.Color.Transparent;
            this.gbCompleted.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbCompleted.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbCompleted.BorderThickness = 2F;
            this.gbCompleted.Controls.Add(this.lbxCompleted);
            this.gbCompleted.Controls.Add(this.btnCompletedNext);
            this.gbCompleted.Controls.Add(this.rtxtCompleted);
            this.gbCompleted.Controls.Add(this.btnCompletedBack);
            this.gbCompleted.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCompleted.HeaderForeColor = System.Drawing.Color.White;
            this.gbCompleted.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.gbCompleted.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbCompleted.Location = new System.Drawing.Point(25, 72);
            this.gbCompleted.Name = "gbCompleted";
            this.gbCompleted.Size = new System.Drawing.Size(523, 413);
            this.gbCompleted.TabIndex = 99;
            this.gbCompleted.TabStop = false;
            this.gbCompleted.Text = "COMPLETED";
            this.gbCompleted.TextIB = "";
            // 
            // gbNotes
            // 
            this.gbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNotes.BackColor = System.Drawing.Color.Transparent;
            this.gbNotes.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbNotes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbNotes.BorderThickness = 2F;
            this.gbNotes.Controls.Add(this.rtxtNotes);
            this.gbNotes.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNotes.HeaderForeColor = System.Drawing.Color.White;
            this.gbNotes.HeaderImage = global::IceBlink.Properties.Resources.gb_med_header;
            this.gbNotes.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbNotes.Location = new System.Drawing.Point(25, 72);
            this.gbNotes.Name = "gbNotes";
            this.gbNotes.Size = new System.Drawing.Size(523, 413);
            this.gbNotes.TabIndex = 100;
            this.gbNotes.TabStop = false;
            this.gbNotes.Text = "NOTES";
            this.gbNotes.TextIB = "";
            // 
            // btnNotesTab
            // 
            this.btnNotesTab.BackColor = System.Drawing.Color.Transparent;
            this.btnNotesTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNotesTab.BackgroundImage")));
            this.btnNotesTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNotesTab.DisabledImage = null;
            this.btnNotesTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNotesTab.FlatAppearance.BorderSize = 0;
            this.btnNotesTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNotesTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNotesTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotesTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotesTab.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnNotesTab.HoverImage")));
            this.btnNotesTab.Location = new System.Drawing.Point(378, 36);
            this.btnNotesTab.Name = "btnNotesTab";
            this.btnNotesTab.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnNotesTab.NormalImage")));
            this.btnNotesTab.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnNotesTab.PressedImage")));
            this.btnNotesTab.Size = new System.Drawing.Size(170, 30);
            this.btnNotesTab.TabIndex = 103;
            this.btnNotesTab.TextIB = "NOTES";
            this.btnNotesTab.UseVisualStyleBackColor = true;
            this.btnNotesTab.Click += new System.EventHandler(this.btnNotesTab_Click);
            // 
            // btnCompletedTab
            // 
            this.btnCompletedTab.BackColor = System.Drawing.Color.Transparent;
            this.btnCompletedTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedTab.BackgroundImage")));
            this.btnCompletedTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCompletedTab.DisabledImage = null;
            this.btnCompletedTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedTab.FlatAppearance.BorderSize = 0;
            this.btnCompletedTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompletedTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompletedTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletedTab.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedTab.HoverImage")));
            this.btnCompletedTab.Location = new System.Drawing.Point(201, 36);
            this.btnCompletedTab.Name = "btnCompletedTab";
            this.btnCompletedTab.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedTab.NormalImage")));
            this.btnCompletedTab.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnCompletedTab.PressedImage")));
            this.btnCompletedTab.Size = new System.Drawing.Size(170, 30);
            this.btnCompletedTab.TabIndex = 102;
            this.btnCompletedTab.TextIB = "COMPLETED";
            this.btnCompletedTab.UseVisualStyleBackColor = true;
            this.btnCompletedTab.Click += new System.EventHandler(this.btnCompletedTab_Click);
            // 
            // btnQuestsTab
            // 
            this.btnQuestsTab.BackColor = System.Drawing.Color.Transparent;
            this.btnQuestsTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuestsTab.BackgroundImage")));
            this.btnQuestsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuestsTab.DisabledImage = null;
            this.btnQuestsTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestsTab.FlatAppearance.BorderSize = 0;
            this.btnQuestsTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestsTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnQuestsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuestsTab.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnQuestsTab.HoverImage")));
            this.btnQuestsTab.Location = new System.Drawing.Point(25, 36);
            this.btnQuestsTab.Name = "btnQuestsTab";
            this.btnQuestsTab.NormalImage = ((System.Drawing.Image)(resources.GetObject("btnQuestsTab.NormalImage")));
            this.btnQuestsTab.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnQuestsTab.PressedImage")));
            this.btnQuestsTab.Size = new System.Drawing.Size(170, 30);
            this.btnQuestsTab.TabIndex = 101;
            this.btnQuestsTab.TextIB = "QUESTS";
            this.btnQuestsTab.UseVisualStyleBackColor = true;
            this.btnQuestsTab.Click += new System.EventHandler(this.btnQuestsTab_Click);
            // 
            // JournalScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IceBlink.Properties.Resources.standard;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(575, 510);
            this.Controls.Add(this.btnNotesTab);
            this.Controls.Add(this.btnCompletedTab);
            this.Controls.Add(this.btnQuestsTab);
            this.Controls.Add(this.gbQuests);
            this.Controls.Add(this.gbCompleted);
            this.Controls.Add(this.gbNotes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 510);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(575, 510);
            this.Name = "JournalScreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JOURNAL";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JournalScreen_FormClosing);
            this.Controls.SetChildIndex(this.gbNotes, 0);
            this.Controls.SetChildIndex(this.gbCompleted, 0);
            this.Controls.SetChildIndex(this.gbQuests, 0);
            this.Controls.SetChildIndex(this.btnQuestsTab, 0);
            this.Controls.SetChildIndex(this.btnCompletedTab, 0);
            this.Controls.SetChildIndex(this.btnNotesTab, 0);
            this.gbQuests.ResumeLayout(false);
            this.gbCompleted.ResumeLayout(false);
            this.gbNotes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtQuests;
        private System.Windows.Forms.RichTextBox rtxtCompleted;
        private System.Windows.Forms.RichTextBox rtxtNotes;
        private System.Windows.Forms.ListBox lbxQuests;
        private IceBlinkButtonMedium btnQuestNext;
        private IceBlinkButtonMedium btnQuestBack;
        private System.Windows.Forms.ListBox lbxCompleted;
        private IceBlinkButtonMedium btnCompletedNext;
        private IceBlinkButtonMedium btnCompletedBack;
        private IceBlinkGroupBoxMedium gbQuests;
        private IceBlinkGroupBoxMedium gbCompleted;
        private IceBlinkGroupBoxMedium gbNotes;
        private IceBlinkButtonMedium btnNotesTab;
        private IceBlinkButtonMedium btnCompletedTab;
        private IceBlinkButtonMedium btnQuestsTab;
    }
}