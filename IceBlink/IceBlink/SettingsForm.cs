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
    public partial class SettingsForm : IBForm
    {
        public Game set_game;
        public Form1 set_frm;

        public SettingsForm()
        {
            InitializeComponent();            
        }

        public void passRefs(Form1 frm, Game game)
        {
            set_game = game;
            set_frm = frm;
            IceBlinkButtonResize.setupAll(set_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(set_game);
            groupBox1.setupAll(set_game);
            btnFont.setupAll(set_game);
            btnLoadGame.setupAll(set_game);
            btnSaveGame.setupAll(set_game);
            btnAbout.setupAll(set_game);
            btnHotKeys.setupAll(set_game);
            this.setupAll(set_game);
            refreshFonts();
        }
        public void refreshFonts()
        {
            label1.Font = set_frm.ChangeFontSize(set_game.module.ModuleTheme.ModuleFont, 0.85f);
            label2.Font = set_game.module.ModuleTheme.ModuleFont;
            label3.Font = set_game.module.ModuleTheme.ModuleFont;
            lblMusicVolume.Font = set_frm.ChangeFontSize(set_game.module.ModuleTheme.ModuleFont, 1.25f);
            lblMusicVolume.Font = new Font(lblMusicVolume.Font, FontStyle.Bold);
            lblSoundsVolume.Font = set_frm.ChangeFontSize(set_game.module.ModuleTheme.ModuleFont, 1.25f);
            lblSoundsVolume.Font = new Font(lblSoundsVolume.Font, FontStyle.Bold);
            groupBox1.Font = set_game.module.ModuleTheme.ModuleFont;
            numMovementDelay.Font = set_game.module.ModuleTheme.ModuleFont;
            chkAutosave.Font = set_frm.ChangeFontSize(set_game.module.ModuleTheme.ModuleFont, 0.85f);
            btnFont.Font = set_game.module.ModuleTheme.ModuleFont;
            btnLoadGame.Font = set_game.module.ModuleTheme.ModuleFont;
            btnSaveGame.Font = set_game.module.ModuleTheme.ModuleFont;
            btnAbout.Font = set_game.module.ModuleTheme.ModuleFont;
            btnHotKeys.Font = set_game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        public void setupLabels()
        {
            try
            {
                tbrMusic.Value = set_frm.areaMusic.settings.volume;
                lblMusicVolume.Text = set_frm.areaMusic.settings.volume.ToString();
                tbrSounds.Value = set_frm.areaSounds.settings.volume;
                lblSoundsVolume.Text = set_frm.areaSounds.settings.volume.ToString();
            }
            catch { }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event. 
            set_frm.refreshFormControls();
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string currentDir = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "Saved Game (*.ofs)|*.ofs|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = ".ofs";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.InitialDirectory = set_game.mainDirectory + "\\saves";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                Directory.SetCurrentDirectory(currentDir);
                return;
            }
            if (saveFileDialog1.FileName.Length == 0)
            {
                Directory.SetCurrentDirectory(currentDir);
                return;
            }
            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                string filename = Path.GetFullPath(saveFileDialog1.FileName);
                IBMessageBox.Show(set_game, "filename = " + filename);
                set_game.saveGameFile(filename);
            }
            Directory.SetCurrentDirectory(currentDir);
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            IBMessageBox.Show(set_game, "Not Implemented Yet");
        }

        private void chkAutosave_CheckedChanged(object sender, EventArgs e)
        {
            set_frm.autosave = chkAutosave.Checked;
        }

        private void numMovementDelay_ValueChanged(object sender, EventArgs e)
        {
            set_frm.movementDelayInMiliseconds = (int)numMovementDelay.Value;
        }

        private void tbrMusic_Scroll(object sender, EventArgs e)
        {
            try
            {
                lblMusicVolume.Text = tbrMusic.Value.ToString();
                set_frm.areaMusic.settings.volume = tbrMusic.Value;
            }
            catch { }
        }

        private void tbrSounds_Scroll(object sender, EventArgs e)
        {
            try
            {
                lblSoundsVolume.Text = tbrSounds.Value.ToString();
                set_frm.areaSounds.settings.volume = tbrSounds.Value;
            }
            catch { }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontSelection fontScreen = new FontSelection();
            fontScreen.passRefs(set_game, set_frm);
            fontScreen.BackgroundImage = set_frm.currentTheme.StandardThemeBitmap;
            fontScreen.ShowDialog();
            refreshFonts();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.passRefs(set_frm, set_game);
            a.ShowDialog();
        }

        private void btnHotKeys_Click(object sender, EventArgs e)
        {
            HotKeys a = new HotKeys();
            a.passRefs(set_frm, set_game);
            a.ShowDialog();
        }
    }
}
