using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IceBlinkCore;

namespace IceBlink
{
    public partial class OpenModule : Form
    {
        public Game lm_game;
        public Form1 lm_frm;
        public List<Module> modList = new List<Module>();
        string mainDirectory;
        int _selectedLbxIndex;

        public OpenModule(Game game, Form1 frm)
        {
            lm_game = game;
            lm_frm = frm;
            InitializeComponent();
            button1.setupAll(lm_game);
            _selectedLbxIndex = 0;
            mainDirectory = Directory.GetCurrentDirectory();

            loadModuleFiles(mainDirectory + "\\modules");

            listBox1.DataSource = null;
            listBox1.DataSource = modList;
            listBox1.DisplayMember = "ModuleName";

            refreshForm();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IBMessageBox.Show(game, "listBox selected index changed");
            if (listBox1.SelectedIndex >= 0)
                _selectedLbxIndex = listBox1.SelectedIndex;
            //refresh all panel info
            refreshForm();
            //refreshListBox1();
            listBox1.SelectedIndex = _selectedLbxIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lm_game.module = modList[_selectedLbxIndex];
                //lm_game.module = lm_game.module.loadModuleFile(modList[_selectedLbxIndex].gameMapFileName);
                this.Close();
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(lm_game, "failed to open module");
                lm_game.errorLog(ex.ToString());
            }
        }

        public void loadModuleFiles(string path)
        {
            string[] files;
            //string[] directories;

            files = Directory.GetFiles(path, "*.module", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (Path.GetFileName(file) != "NewModule.module")
                {
                    // Process each file
                    Module mod = new Module();
                    mod.passRefs(lm_game, null);
                    mod = mod.loadModuleFile(file);
                    if (mod == null)
                    {
                        IBMessageBox.Show(lm_game, "returned a null module");
                    }
                    modList.Add(mod);
                }
            }

            /*directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                // Process each directory recursively
                loadModuleFiles(directory);
            }*/
        }

        public void refreshForm()
        {
            try
            {
                //IBMessageBox.Show(game, "panel selectedIndex = " + _selectedLbxIndex.ToString());
                richTextBox1.Text = modList[_selectedLbxIndex].ModuleDescription;
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(lm_game, "failed to refresh panel");
                lm_game.errorLog(ex.ToString());
            }
        }
    }
}
