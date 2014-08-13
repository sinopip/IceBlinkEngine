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

namespace IceBlinkToolset
{
    public partial class ItemImageSelector : Form
    {
        private Game game;
        public Module mod = new Module();
        private List<ItemImage> itemImageList = new List<ItemImage>();
        private string returnSpriteFilename = "";
        public string ReturnSpriteFilename
        {
            get { return returnSpriteFilename; }
            set { returnSpriteFilename = value; }
        }

        public ItemImageSelector(Game g, Module m)
        {
            InitializeComponent();
            game = g;
            mod = m;
            loadImageList();
            createButtons();
        }
        private void setFormSize()
        {
            this.flowLayoutPanel1.Height = (this.flowLayoutPanel1.Controls.Count / 10) * 100;
        }
        private void loadImageList()
        {
            itemImageList.Clear();
            string jobDir = "";
            jobDir = game.mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items";
            foreach (string f in Directory.GetFiles(jobDir, "*.png"))
            {
                string filename = Path.GetFileName(f);
                try
                {
                    ItemImage newItem = new ItemImage();
                    newItem.bitmap = new Bitmap(jobDir + "\\" + filename);
                    newItem.filename = filename;
                    itemImageList.Add(newItem);
                }
                catch (Exception ex)
                {
                    game.errorLog("Failed to open the following file from the module's items folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
            jobDir = game.mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites";
            foreach (string f in Directory.GetFiles(jobDir, "*.png"))
            {
                string filename = Path.GetFileName(f);
                try
                {
                    ItemImage newItem = new ItemImage();
                    newItem.bitmap = new Bitmap(jobDir + "\\" + filename);
                    newItem.filename = filename;
                    itemImageList.Add(newItem);
                }
                catch (Exception ex)
                {
                    game.errorLog("Failed to open the following file from the module's sprites folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }                      
            jobDir = game.mainDirectory + "\\data\\graphics\\sprites\\items";
            foreach (string f in Directory.GetFiles(jobDir, "*.png"))
            {
                string filename = Path.GetFileName(f);
                try
                {
                    ItemImage newItem = new ItemImage();
                    newItem.bitmap = new Bitmap(jobDir + "\\" + filename);
                    newItem.filename = filename;
                    itemImageList.Add(newItem);
                }
                catch (Exception ex)
                {
                    game.errorLog("Failed to open the following file from the ...\\data\\graphics\\sprites\\items folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
            jobDir = game.mainDirectory + "\\data\\graphics\\sprites";
            foreach (string f in Directory.GetFiles(jobDir, "*.png"))
            {
                string filename = Path.GetFileName(f);
                try
                {
                    ItemImage newItem = new ItemImage();
                    newItem.bitmap = new Bitmap(jobDir + "\\" + filename);
                    newItem.filename = filename;
                    itemImageList.Add(newItem);
                }
                catch (Exception ex)
                {
                    game.errorLog("Failed to open the following file from the ...\\data\\graphics\\sprites folder: " + filename + " ...(image may be wrong size or corrupted): " + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
        }
        private void createButtons()
        {
            this.flowLayoutPanel1.Controls.Clear();
            foreach (ItemImage itm in itemImageList)
            {
                Button btnNew = new Button();
                // 
                // btnOne
                // 
                btnNew.BackgroundImage = itm.bitmap;
                btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                btnNew.FlatAppearance.BorderSize = 2;
                btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
                btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnNew.Name = itm.filename;
                btnNew.Size = new System.Drawing.Size(66, 66);
                btnNew.TabIndex = 3;
                btnNew.Text = "";
                btnNew.UseVisualStyleBackColor = true;
                btnNew.Click += new System.EventHandler(this.btnSelectedSprite_Click);
                this.flowLayoutPanel1.Controls.Add(btnNew);
            }
            setFormSize();
        }
        private void btnSelectedSprite_Click(object sender, EventArgs e)
        {
            Button selectBtn = (Button)sender;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            game.returnSpriteFilename = selectBtn.Name;
        }
    }

    public class ItemImage
    {
        public Bitmap bitmap;
        public string filename;

        public ItemImage()
        {
        }
    }
}
