using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using System.IO;

namespace IceBlink
{
    public partial class PortraitSelector : IBForm
    {
        private Game game;
        private bool showModulePortraits = false;
        //private List<string> portraitList = new List<string>();
        private string returnPortraitFilename_G = "";
        public string ReturnPortraitFilename_G
        {
            get { return returnPortraitFilename_G; }
            set { returnPortraitFilename_G = value; }
        }

        public PortraitSelector(Game g, bool showModulePortraits)
        {
            InitializeComponent();
            game = g;
            //this.showModulePortraits = showModulePortraits;
            IceBlinkButtonResize.setupAll(game);
            //IceBlinkButtonResize.Enabled = false;
            //IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            this.setupAll(game);
            loadPortraitList();
            //setFormSize();
        }
        private void setFormSize()
        {
            //maybe count the number of controls on the flowpanel
            this.flowLayoutPanel1.Height = (this.flowLayoutPanel1.Controls.Count / 6) * 220;
            /*if (this.flowLayoutPanel1.Controls.Count < 8)
            {
                this.Height = 320;
            }
            else if (portraitList.Count < 12)
            {
                this.Height = 400;
            }
            else if (portraitList.Count < 16)
            {
                this.Height = 480;
            }
            else
            {
                this.Height = 560;
            }*/
        }
        private void loadPortraitList()
        {
            this.flowLayoutPanel1.Controls.Clear();
            //portraitList.Clear();
            string jobDir = "";
            if (showModulePortraits)
            {
                jobDir = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\portraits";
                foreach (string f in Directory.GetFiles(jobDir, "*L.png"))
                {
                    string filename = Path.GetFileName(f);
                    createButton(jobDir, filename);
                }
            }            
            jobDir = game.mainDirectory + "\\portraits";
            foreach (string f in Directory.GetFiles(jobDir, "*L.png"))
            {
                string filename = Path.GetFileName(f);
                createButton(jobDir, filename);
            }
            setFormSize();
        }
        private void createButton(string jobDir, string filename)
        {
            Button btnNew = new Button();
            btnNew.BackgroundImage = new Bitmap(jobDir + "\\" + filename);
            btnNew.BackgroundImageLayout = ImageLayout.Center;
            btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNew.Name = filename;
            btnNew.Size = new System.Drawing.Size(114, 174);
            btnNew.Text = "";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += new System.EventHandler(this.btnSelectedPortrait_Click);
            this.flowLayoutPanel1.Controls.Add(btnNew);
        }
        private void btnSelectedPortrait_Click(object sender, EventArgs e)
        {
            Button selectBtn = (Button)sender;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //string returnSpriteFilename = selectBtn.Name;
            game.returnSpriteFilename = selectBtn.Name;
        }
        private void chkShowModule_CheckedChanged(object sender, EventArgs e)
        {
            showModulePortraits = chkShowModule.Checked;
            loadPortraitList();
        }
    }
}
