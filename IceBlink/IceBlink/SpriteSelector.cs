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
    public partial class SpriteSelector : IBForm
    {
        private Game game;
        private bool showModuleSprites = false;
        private List<Sprite> spriteList = new List<Sprite>();
        private string returnSpriteFilename = "";
        public string ReturnSpriteFilename
        {
            get { return returnSpriteFilename; }
            set { returnSpriteFilename = value; }
        }

        public SpriteSelector(Game g, bool showModuleSprites)
        {
            InitializeComponent();
            game = g;
            //this.showModuleSprites = showModuleSprites;
            IceBlinkButtonResize.setupAll(game);
            //IceBlinkButtonResize.Enabled = false;
            //IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            this.setupAll(game);
            loadSpriteList();
            //setFormSize();
            createButtons();
        }
        private void setFormSize()
        {
            this.flowLayoutPanel1.Height = (this.flowLayoutPanel1.Controls.Count / 10) * 100;
            /*if (spriteList.Count < 8)
            {
                this.Height = 320;
            }
            else if (spriteList.Count < 12)
            {
                this.Height = 400;
            }
            else if (spriteList.Count < 16)
            {
                this.Height = 480;
            }
            else
            {
                this.Height = 560;
            }*/
        }
        private void loadSpriteList()
        {
            spriteList.Clear();
            string jobDir = "";
            jobDir = game.mainDirectory + "\\tokens";
            foreach (string f in Directory.GetFiles(jobDir, "*.spt"))
            {
                string filename = Path.GetFileName(f);
                try
                {
                    Sprite newSprite = new Sprite();
                    newSprite.passRefs(game);
                    newSprite = newSprite.loadSpriteFile(jobDir + "\\" + filename);
                    newSprite.passRefs(game);
                    newSprite.LoadSpriteSheetBitmap(jobDir + "\\" + newSprite.SpriteSheetFilename);
                    spriteList.Add(newSprite);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Failed to open the following file from the tokens\\player folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + Environment.NewLine + ex.ToString());
                    game.errorLog("Failed to open the following file from the tokens\\player folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
            jobDir = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player";
            foreach (string f in Directory.GetFiles(jobDir, "*.spt"))
            {
                string filename = Path.GetFileName(f);
                try
                {                    
                    Sprite newSprite = new Sprite();
                    newSprite.passRefs(game);
                    newSprite = newSprite.loadSpriteFile(jobDir + "\\" + filename);
                    newSprite.passRefs(game);
                    newSprite.LoadSpriteSheetBitmap(jobDir + "\\" + newSprite.SpriteSheetFilename);
                    spriteList.Add(newSprite);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Failed to open the following file from the tokens\\player folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + Environment.NewLine + ex.ToString());
                    game.errorLog("Failed to open the following file from the tokens\\player folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
            if (showModuleSprites)
            {
                jobDir = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\module";
                foreach (string f in Directory.GetFiles(jobDir, "*.spt"))
                {
                    string filename = Path.GetFileName(f);
                    try
                    {
                        Sprite newSprite = new Sprite();
                        newSprite.passRefs(game);
                        newSprite = newSprite.loadSpriteFile(jobDir + "\\" + filename);
                        newSprite.passRefs(game);
                        newSprite.LoadSpriteSheetBitmap(jobDir + "\\" + newSprite.SpriteSheetFilename);
                        spriteList.Add(newSprite);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Failed to open the following file from the tokens\\module folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + Environment.NewLine + ex.ToString());
                        game.errorLog("Failed to open the following file from the tokens\\module folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                    }
                }
            }
            jobDir = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens";
            foreach (string f in Directory.GetFiles(jobDir, "*.spt"))
            {
                string filename = Path.GetFileName(f);
                try
                {
                    Sprite newSprite = new Sprite();
                    newSprite.passRefs(game);
                    newSprite = newSprite.loadSpriteFile(jobDir + "\\" + filename);
                    newSprite.passRefs(game);
                    newSprite.LoadSpriteSheetBitmap(jobDir + "\\" + newSprite.SpriteSheetFilename);
                    spriteList.Add(newSprite);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Failed to open the following file from the ...\\graphics\\sprites\\tokens folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + Environment.NewLine + ex.ToString());
                    game.errorLog("Failed to open the following file from the ...\\graphics\\sprites\\tokens folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
            jobDir = game.mainDirectory + "\\data\\graphics\\sprites\\tokens";
            foreach (string f in Directory.GetFiles(jobDir, "*.spt"))
            {
                string filename = Path.GetFileName(f);
                try
                {
                    Sprite newSprite = new Sprite();
                    newSprite.passRefs(game);
                    newSprite = newSprite.loadSpriteFile(jobDir + "\\" + filename);
                    newSprite.passRefs(game);
                    newSprite.LoadSpriteSheetBitmap(jobDir + "\\" + newSprite.SpriteSheetFilename);
                    spriteList.Add(newSprite);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Failed to open the following file from the ...\\data\\graphics\\sprites\\tokens folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + Environment.NewLine + ex.ToString());
                    game.errorLog("Failed to open the following file from the ...\\data\\graphics\\sprites\\tokens folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }            
        }                
        private void createButtons()
        {
            //int index = 0;
            //int row = 0;
            this.flowLayoutPanel1.Controls.Clear();
            foreach (Sprite spr in spriteList)
            {               
                Button btnNew = new Button();
                /*if (index % 2 == 0) //even...place on left
                {
                    btnNew.Location = new System.Drawing.Point(10, row * 45 + 30);
                }
                else //odd...place on right
                {
                    btnNew.Location = new System.Drawing.Point(110, row * 45 + 30);
                    row++;
                }*/
                // 
                // btnOne
                // 
                btnNew.BackgroundImage = spr.Image;
                btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                btnNew.FlatAppearance.BorderSize = 2;
                btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
                btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                //btnNew.Location = new System.Drawing.Point(12, 40);
                btnNew.Name = spr.Filename;
                btnNew.Size = new System.Drawing.Size(66, 66);
                btnNew.TabIndex = 3;
                btnNew.Text = "";
                btnNew.UseVisualStyleBackColor = true;
                btnNew.Click += new System.EventHandler(this.btnSelectedSprite_Click);
                this.flowLayoutPanel1.Controls.Add(btnNew);
                //index++;
            }
            setFormSize();
        }
        private void btnSelectedSprite_Click(object sender, EventArgs e)
        {
            Button selectBtn = (Button)sender;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //string returnSpriteFilename = selectBtn.Name;
            game.returnSpriteFilename = selectBtn.Name;
        }
        private void chkShowModule_CheckedChanged(object sender, EventArgs e)
        {
            showModuleSprites = chkShowModule.Checked;
            loadSpriteList();
            setFormSize();
            createButtons();
        }
    }
}
