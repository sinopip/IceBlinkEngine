using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using IceBlinkCore;
using IceBlink;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            IntroScreen intro = new IntroScreen(sf);
            intro.ShowDialog();
        }
    }
    public partial class IntroScreen : Form
    {
        public ScriptFunctions sf;
        public List<Image> images = new List<Image>();  //this will be the list of images that you load up for your story board intro
        public List<string> strings = new List<string>(); //this is the list of strings to show along with the images
        public int imageCounter = 0;                    //this is the current "page number" of your story board, the current index of the image list

        public IntroScreen(ScriptFunctions s)
        {
            InitializeComponent();
            sf = s;
            setupFont();
            btnNext.setupAll(sf.gm);
            LoadAllImages();                            //this will load up all the images for your intro
            LoadAllText();
            ShowNextImage(imageCounter);                //this will show the first image of your intro
            ShowNextText(imageCounter);
            imageCounter++;                             //moves the counter to the next image index
        }
        public void setupFont()
        {
            try
            {
                this.richTextBox1.Font = Form1.ChangeFontSizeStatic(sf.gm.module.ModuleTheme.ModuleFont, 2.5f);
                this.richTextBox1.ForeColor = Color.Silver;
                this.Invalidate();
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (imageCounter < images.Count) //keep showing images until there are no more to show
            {
                ShowNextImage(imageCounter);
                ShowNextText(imageCounter);
                imageCounter++;
            }
            else //if all images have been shown, close the dialog screen and return to the game
            {
                this.Close();
            }
        }
        private void LoadAllImages()
        {
            try
            {
                Image img = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\clock.png");
                images.Add(img);
            }
            catch { MessageBox.Show("Failed to find clock.png"); }
            try
            {
                Image img = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\spells.png");
                images.Add(img);
            }
            catch { MessageBox.Show("Failed to find spells.png"); }
            try
            {
                Image img = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\traits.png");
                images.Add(img);
            }
            catch { MessageBox.Show("Failed to find traits.png"); }            
        }
        private void LoadAllText()
        {
            strings.Add("This is the first page");
            strings.Add("This is the second page");
            strings.Add("This is the third and last page");
        }
        private void ShowNextImage(int index)
        {
            this.pictureBox1.BackgroundImage = images[index];
        }
        private void ShowNextText(int index)
        {
            this.richTextBox1.Text = strings[index];
        }
    }
    public partial class IntroScreen
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
            this.btnNext = new IceBlink.IceBlinkButtonSmall();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.DisabledImage = null;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(560, 452);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 25);
            this.btnNext.TabIndex = 17;
            this.btnNext.TextIB = "NEXT";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(635, 432);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(100, 397);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(635, 49);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(659, 485);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNext);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlinkButtonSmall btnNext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }    
}
