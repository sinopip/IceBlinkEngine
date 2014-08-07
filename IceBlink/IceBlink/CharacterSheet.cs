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
    public partial class CharacterSheet : IBForm
    {
        public Game pc_game;
        public PC pc_character;
        public Form1 pc_frm;
        private Bitmap portraitBitmap;
        private Bitmap tokenBitmap;
        private string filenameG;
        private string filenameL;
        private string filenameM;
        private string filenameS;
        private int selectedSkillIndex = 0;
        private int selectedTraitIndex = 0;
        private int selectedSpellIndex = 0;

        public CharacterSheet()
        {
            InitializeComponent();
            //pc_game = game;
            //pc_character = character;
            //pc_items = items;
            //p_position = pos;
            //pc_selection = 0;
            //p_mouseBtn = MouseButtons.None;
            //p_oldMouseBtn = p_mouseBtn;
            //p_mousePos = new Point(0, 0);
            //p_visible = false;
            //p_lastButton = -1;

            //refreshInventory();
        }
        public void passRefs(Form1 frm, Game game, int PCindex)
        {
            pc_game = game;
            pc_frm = frm;
            pc_character = game.playerList.PCList[PCindex];
            portraitBitmap = pc_character.portraitBitmapL;
            pictureBox1.Image = (Image)portraitBitmap;
            tokenBitmap = pc_character.CharSprite.Image;
            pbToken.Image = (Image)tokenBitmap;
            setupLabels();
            refreshFonts();
            //iceBlinkGroupBoxMedium1.setupAll(pc_game);
            iceBlinkGroupBoxMedium2.setupAll(pc_game);
            iceBlinkGroupBoxMedium3.setupAll(pc_game);
            iceBlinkGroupBoxMedium4.setupAll(pc_game);
            iceBlinkGroupBoxMedium5.setupAll(pc_game);
            iceBlinkGroupBoxMedium6.setupAll(pc_game);
            iceBlinkGroupBoxMedium7.setupAll(pc_game);
            btnExportPC.setupAll(pc_game);
            //btnIcon.setupAll(pc_game);
            btnLevelUp.setupAll(pc_game);
            //btnPortrait.setupAll(pc_game);
            btnSkillsTab.setupAll(pc_game);
            btnTraitsTab.setupAll(pc_game);
            btnSpellsTab.setupAll(pc_game);
            IceBlinkButtonResize.setupAll(pc_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(pc_game);
            this.setupAll(pc_game);
            iceBlinkGroupBoxMedium4.Visible = true; //skills
            iceBlinkGroupBoxMedium7.Visible = false; //traits
            iceBlinkGroupBoxMedium5.Visible = false; //spells   
            //refreshInventory();
            // check the screen size and adjust the form as needed
            Screen scrn = Screen.FromControl(frm);
            if (scrn == null)
            {
                scrn = Screen.PrimaryScreen;
            }
            int deskHeight = scrn.Bounds.Height;
            int deskWidth = scrn.Bounds.Width;
            //MessageBox.Show("Your screen resolution is " + deskWidth + "x" + deskHeight);
            if (deskHeight < 670)
            {
                this.Size = new System.Drawing.Size(528, 585);
            }
        }
        public void refreshFonts()
        {
            dgvSkills.BackgroundColor = pc_game.module.ModuleTheme.GroupBoxBackGroundColor;
            lbxKnownSpells.BackColor = pc_game.module.ModuleTheme.GroupBoxBackGroundColor;
            lbxKnownTraits.BackColor = pc_game.module.ModuleTheme.GroupBoxBackGroundColor;
            rtxtDescription.BackColor = pc_game.module.ModuleTheme.GroupBoxBackGroundColor;
            rtxtMisc.BackColor = pc_game.module.ModuleTheme.GroupBoxBackGroundColor;
            rtxtAttributes.BackColor = pc_game.module.ModuleTheme.GroupBoxBackGroundColor;
            //iceBlinkGroupBoxMedium1.Font = pc_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium2.Font = pc_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium3.Font = pc_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium4.Font = pc_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium5.Font = pc_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium6.Font = pc_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium7.Font = pc_game.module.ModuleTheme.ModuleFont;
            btnExportPC.Font = pc_game.module.ModuleTheme.ModuleFont;
            //btnIcon.Font = pc_game.module.ModuleTheme.ModuleFont;
            btnLevelUp.Font = pc_game.module.ModuleTheme.ModuleFont;
            btnSkillsTab.Font = pc_game.module.ModuleTheme.ModuleFont;
            btnTraitsTab.Font = pc_game.module.ModuleTheme.ModuleFont;
            btnSpellsTab.Font = pc_game.module.ModuleTheme.ModuleFont;
            //btnPortrait.Font = pc_game.module.ModuleTheme.ModuleFont;
            //label1.Font = pc_game.module.ModuleTheme.ModuleFont;
            //label3.Font = pc_game.module.ModuleTheme.ModuleFont;
            //label4.Font = pc_game.module.ModuleTheme.ModuleFont;
            //label5.Font = pc_game.module.ModuleTheme.ModuleFont;
            //pcName.Font = pc_game.module.ModuleTheme.ModuleFont;
            //pcRace.Font = pc_game.module.ModuleTheme.ModuleFont;
            //pcClass.Font = pc_game.module.ModuleTheme.ModuleFont;
            //pcSex.Font = pc_game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        private void setupLabels()
        {
            //lblFunds.Text = "PARTY " + pc_game.module.LabelFunds.ToUpper() + ":";
            iceBlinkGroupBoxMedium5.Text = pc_game.module.LabelSpells.ToUpper();
        }
        private void CharacterSheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide(); 
            e.Cancel = true; // this cancels the close event.
            pc_frm.doPortraitStats();
        }
        private void btnLevelUp_Click(object sender, EventArgs e)
        {
            if (pc_character.Status != CharBase.charStatus.Dead)
            {
                LevelUp levelUp = new LevelUp(pc_game, pc_frm, pc_character);
                levelUp.BackgroundImage = pc_frm.currentTheme.StandardThemeBitmap;
                levelUp.ShowDialog();
                //pc_character.LevelUp();
                btnLevelUp.Enabled = false;
                refreshSheet();
            }
            else
            {
                IBMessageBox.Show(pc_game, "Dead characters may not level up");
            }
        }
        public void refreshSheet()
        {
            pc_character.UpdateStats(pc_frm.sf);
            if (pc_character.IsReadyToAdvanceLevel())
            {
                btnLevelUp.Enabled = true;
            }
            //pcName.Text = pc_character.Name;
            //pcRace.Text = pc_character.Race.ToString();
            //pcSex.Text = pc_character.Gender.ToString();
            //pcClass.Text = pc_character.Class.ToString();
            //pcStr.Text = pc_character.Strength.ToString();
            //pcDex.Text = pc_character.Dexterity.ToString();
            //pcInt.Text = pc_character.Intelligence.ToString();
            //pcCha.Text = pc_character.Charisma.ToString();
            //pcCon.Text = pc_character.Constitution.ToString();
            //pcWis.Text = pc_character.Wisdom.ToString();
            //pcHP.Text = pc_character.HP.ToString();
            //pcHPMax.Text = pc_character.HPMax.ToString();
            //pcSP.Text = pc_character.SP.ToString();
            //pcSPMax.Text = pc_character.SPMax.ToString();
            //pcBAB.Text = pc_character.BaseAttBonus.ToString();
            //pcAC.Text = pc_character.AC.ToString();
            //pcXp.Text = pc_character.XP.ToString();
            //pcXpNextLvl.Text = pc_character.XPNeeded.ToString();
            //pcLevel.Text = pc_character.ClassLevel.ToString();
            //pcGold.Text = pc_game.partyGold.ToString();
            foreach (Skill sk in pc_character.KnownSkillsList.skillsList)
            {
                sk.reCalculate(pc_character);
            }
            setupSkillsDataGridView();
            refreshLbxTraitsKnown();
            refreshLbxSpellsKnown();
            fillMiscTextBox();
            refreshFonts();
        }
        /*private void btnPortrait_Click(object sender, EventArgs e)
        {
            using (var sel = new PortraitSelector(pc_game, true))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    try
                    {
                        string filename = pc_game.returnSpriteFilename;
                        if (filename.Contains("_G"))
                        {
                            filenameG = filename;
                            filenameL = filename.Replace("_G", "_L");
                            filenameM = filename.Replace("_G", "_M");
                            filenameS = filename.Replace("_G", "_S");
                        }
                        if (filename.Contains("_L"))
                        {
                            filenameL = filename;
                            filenameG = filename.Replace("_L", "_G");
                            filenameM = filename.Replace("_L", "_M");
                            filenameS = filename.Replace("_L", "_S");
                        }
                        if (filename.Contains("_M"))
                        {
                            filenameM = filename;
                            filenameG = filename.Replace("_M", "_G");
                            filenameL = filename.Replace("_M", "_L");
                            filenameS = filename.Replace("_M", "_S");
                        }
                        if (filename.Contains("_S"))
                        {
                            filenameS = filename;
                            filenameG = filename.Replace("_S", "_G");
                            filenameM = filename.Replace("_S", "_M");
                            filenameL = filename.Replace("_S", "_L");
                        }

                        //IBMessageBox.Show(game, "filename selected = " + filename);
                        pc_character.PortraitFileG = filenameG;
                        pc_character.PortraitFileL = filenameL;
                        pc_character.PortraitFileM = filenameM;
                        pc_character.PortraitFileS = filenameS;
                        pc_character.LoadAllPcStuff(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName);
                        portraitBitmap = pc_character.portraitBitmapL;
                        pictureBox1.Image = (Image)portraitBitmap;
                        if (pictureBox1 == null)
                        {
                            IBMessageBox.Show(pc_game, "returned a null portrait bitmap");
                        }
                        pc_frm.refreshPartyButtons();
                    }
                    catch (Exception ex)
                    {
                        IBMessageBox.Show(pc_game, "Failed to load Portrait...try another: " + ex.ToString());
                    }
                }
            }
            /*
            openFileDialog1.InitialDirectory = pc_game.mainDirectory + "\\portraits";
            //Empty the FileName text box of the dialog
            openFileDialog1.FileName = String.Empty;
            openFileDialog1.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog1.SafeFileName;
                if (filename.Contains("_G"))
                {
                    filenameG = filename;
                    filenameL = filename.Replace("_G", "_L");
                    filenameM = filename.Replace("_G", "_M");
                    filenameS = filename.Replace("_G", "_S");
                }
                if (filename.Contains("_L"))
                {
                    filenameL = filename;
                    filenameG = filename.Replace("_L", "_G");
                    filenameM = filename.Replace("_L", "_M");
                    filenameS = filename.Replace("_L", "_S");
                }
                if (filename.Contains("_M"))
                {
                    filenameM = filename;
                    filenameG = filename.Replace("_M", "_G");
                    filenameL = filename.Replace("_M", "_L");
                    filenameS = filename.Replace("_M", "_S");
                }
                if (filename.Contains("_S"))
                {
                    filenameS = filename;
                    filenameG = filename.Replace("_S", "_G");
                    filenameM = filename.Replace("_S", "_M");
                    filenameL = filename.Replace("_S", "_L");
                }

                //IBMessageBox.Show(game, "filename selected = " + filename);
                pc_character.PortraitFileG = filenameG;
                pc_character.PortraitFileL = filenameL;
                pc_character.PortraitFileM = filenameM;
                pc_character.PortraitFileS = filenameS;
                pc_character.LoadAllPcStuff(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName);
                portraitBitmap = pc_character.portraitBitmapG;
                pictureBox1.Image = (Image)portraitBitmap;                
                if (pictureBox1 == null)
                {
                    IBMessageBox.Show(pc_game, "returned a null portrait bitmap");
                }
                //TODO: change the main screen PC button and inventory button
                pc_frm.refreshPartyButtons();
            }
        }*/
        /*private void btnIcon_Click(object sender, EventArgs e)
        {
            using (var sel = new SpriteSelector(pc_game, true))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    //string filename = sel.ReturnSpriteFilename;
                    string filename = pc_game.returnSpriteFilename;
                    //IBMessageBox.Show(pc_game, "filename selected = " + filename);
                    try
                    {
                        pc_character.SpriteFilename = filename;
                        pc_character.LoadSpriteStuff(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName);
                        tokenBitmap = pc_character.CharSprite.Image;
                        //tokenBitmap = new Bitmap(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + pc_character.CharSprite.SpriteSheetFilename);
                        pbToken.Image = (Image)tokenBitmap;

                        if (pbToken == null)
                        {
                            IBMessageBox.Show(pc_game, "returned a null icon bitmap");
                        }
                    }
                    catch
                    {
                        IBMessageBox.Show(pc_game, "failed to open the sprite selected...try another one.");
                    }
                    pc_frm.refreshPartyButtons();
                    pc_game.ChangePartySprite();
                    //pc_game.areaUpdateAll();
                    //pc_game.spritePcDraw(pc_game.playerPosition.X * pc_frm.squareSize, pc_game.playerPosition.Y * pc_frm.squareSize, 0);
                    //pc_game.Update();
                }
            }
            //SpriteSelector sel = new SpriteSelector(pc_game, true);
            //DialogResult result = sel.ShowDialog();
            /*
            openFileDialog2.InitialDirectory = pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player";
            //Empty the FileName text box of the dialog
            openFileDialog2.FileName = String.Empty;
            openFileDialog2.Filter = "Sprite files (*.spt)|*.spt|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result != DialogResult.OK) return;
            if (openFileDialog2.FileName.Length == 0) return;
            if (result == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog2.SafeFileName;
                //IBMessageBox.Show(game, "filename selected = " + filename);
                try
                {
                    pc_character.SpriteFilename = filename;
                    pc_character.LoadSpriteStuff(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName);
                    tokenBitmap = pc_character.CharSprite.Image;
                    //tokenBitmap = new Bitmap(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + pc_character.CharSprite.SpriteSheetFilename);
                    pbToken.Image = (Image)tokenBitmap;

                    if (pbToken == null)
                    {
                        IBMessageBox.Show(pc_game, "returned a null icon bitmap");
                    }
                }
                catch
                {
                    IBMessageBox.Show(pc_game, "failed to open the sprite selected...try another one.");
                }
                pc_frm.refreshPartyButtons();
            }
        }*/
        
        private void btnExportPC_Click(object sender, EventArgs e)
        {
            savePC();
        }
        private void dgvSkills_SelectionChanged(object sender, EventArgs e)
        {
            selectedSkillIndex = dgvSkills.CurrentCell.RowIndex;
            if (pc_character.KnownSkillsList.skillsList.Count > 0)
            {
                rtxtDescription.Text = pc_character.KnownSkillsList.skillsList[selectedSkillIndex].Description;
            }
        }
        private void lbxKnownTraits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxKnownTraits.SelectedIndex >= 0)
            {
                //show the description
                selectedTraitIndex = lbxKnownTraits.SelectedIndex;
                lbxKnownTraits.SelectedIndex = selectedTraitIndex;
                rtxtDescription.Text = "Trait Name: " + pc_character.KnownTraitsList.traitList[selectedTraitIndex].TraitName + Environment.NewLine +
                                        "SP Cost: " + pc_character.KnownTraitsList.traitList[selectedTraitIndex].CostSP + Environment.NewLine +
                                        "Target Range: " + pc_character.KnownTraitsList.traitList[selectedTraitIndex].Range + Environment.NewLine +
                                        "Area of Effect (square radius): " + pc_character.KnownTraitsList.traitList[selectedTraitIndex].AoeRadiusOrLength + Environment.NewLine +
                                        Environment.NewLine +
                                        "Description: " + Environment.NewLine +
                                        pc_character.KnownTraitsList.traitList[selectedTraitIndex].Description;
            }
        }
        private void lbxKnownSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxKnownSpells.SelectedIndex >= 0)
            {
                //show the description
                selectedSpellIndex = lbxKnownSpells.SelectedIndex;
                lbxKnownSpells.SelectedIndex = selectedSpellIndex;
                rtxtDescription.Text = pc_game.module.LabelSpells + " Name: " + pc_character.KnownSpellsList.spellList[selectedSpellIndex].SpellName + Environment.NewLine +
                                        "SP Cost: " + pc_character.KnownSpellsList.spellList[selectedSpellIndex].CostSP + Environment.NewLine +
                                        "Target Range: " + pc_character.KnownSpellsList.spellList[selectedSpellIndex].Range + Environment.NewLine +
                                        "Area of Effect (square radius): " + pc_character.KnownSpellsList.spellList[selectedSpellIndex].AoeRadiusOrLength + Environment.NewLine +
                                        Environment.NewLine +
                                        "Description: " + Environment.NewLine +
                                        pc_character.KnownSpellsList.spellList[selectedSpellIndex].Description;
            }
        }
        private void setupSkillsDataGridView()
        {
            dgvSkills.DataSource = pc_character.KnownSkillsList.skillsList;
            dgvSkills.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "SkillName";
            columnA.HeaderText = "Name";
            columnA.Name = "skillName";
            columnA.Width = 145;

            DataGridViewColumn columnF = new DataGridViewTextBoxColumn();
            columnF.DataPropertyName = "TotalRanks";
            columnF.HeaderText = "TotalRanks";
            columnF.Name = "totalRanks";
            columnF.Width = 80;

            dgvSkills.Columns.Clear();
            dgvSkills.Columns.Add(columnA);
            dgvSkills.Columns.Add(columnF);
        }
        private void refreshLbxTraitsKnown()
        {
            lbxKnownTraits.BeginUpdate();
            lbxKnownTraits.DataSource = null;
            lbxKnownTraits.DataSource = pc_character.KnownTraitsList.traitList;
            lbxKnownTraits.DisplayMember = "TraitName";
            lbxKnownTraits.EndUpdate();
        }
        private void refreshLbxSpellsKnown()
        {
            lbxKnownSpells.BeginUpdate();
            lbxKnownSpells.DataSource = null;
            lbxKnownSpells.DataSource = pc_character.KnownSpellsList.spellList;
            lbxKnownSpells.DisplayMember = "SpellName";
            lbxKnownSpells.EndUpdate();
        }
        private void fillMiscTextBox()
        {
            //var scriptPcSheet = prp.OnEnter;
            pc_frm.sf.currentCharacterSheet = this;
            pc_frm.doScriptBasedOnFilename("dsCharacterSheetData.cs", "", "", "", "");
        }
        private void savePC()
        {
            string jobDir = pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName + "\\characters\\player";
            for (int i = 0; i < 999; i++) // adds an incremental save option
            {
                if (!File.Exists(jobDir + "\\" + pc_character.Name + "(" + i.ToString() + ").char"))
                {
                    pc_character.savePCFile(jobDir + "\\" + pc_character.Name + "(" + i.ToString() + ").char");                    
                    break;
                }
            }
            IBMessageBox.Show(pc_game, "Character backup was saved");            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (var sel = new PortraitSelector(pc_game, true))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    try
                    {
                        string filename = pc_game.returnSpriteFilename;
                        /*if (filename.Contains("_G"))
                        {
                            filenameG = filename;
                            filenameL = filename.Replace("_G", "_L");
                            filenameM = filename.Replace("_G", "_M");
                            filenameS = filename.Replace("_G", "_S");
                        }*/
                        if (filename.Contains("_L"))
                        {
                            filenameL = filename;
                            //filenameG = filename.Replace("_L", "_G");
                            //filenameM = filename.Replace("_L", "_M");
                            filenameS = filename.Replace("_L", "_S");
                        }
                        /*if (filename.Contains("_M"))
                        {
                            filenameM = filename;
                            filenameG = filename.Replace("_M", "_G");
                            filenameL = filename.Replace("_M", "_L");
                            filenameS = filename.Replace("_M", "_S");
                        }
                        if (filename.Contains("_S"))
                        {
                            filenameS = filename;
                            filenameG = filename.Replace("_S", "_G");
                            filenameM = filename.Replace("_S", "_M");
                            filenameL = filename.Replace("_S", "_L");
                        }
                        */
                        //IBMessageBox.Show(game, "filename selected = " + filename);
                        //pc_character.PortraitFileG = filenameG;
                        pc_character.PortraitFileL = filenameL;
                        //pc_character.PortraitFileM = filenameM;
                        pc_character.PortraitFileS = filenameS;
                        pc_character.LoadAllPcStuff(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName);
                        portraitBitmap = pc_character.portraitBitmapL;
                        pictureBox1.Image = (Image)portraitBitmap;
                        if (pictureBox1 == null)
                        {
                            IBMessageBox.Show(pc_game, "returned a null portrait bitmap");
                        }
                        pc_frm.refreshPartyButtons();
                    }
                    catch (Exception ex)
                    {
                        IBMessageBox.Show(pc_game, "Failed to load Portrait...try another: " + ex.ToString());
                    }
                }
            }
        }
        private void pbToken_Click(object sender, EventArgs e)
        {
            using (var sel = new SpriteSelector(pc_game, true))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    //string filename = sel.ReturnSpriteFilename;
                    string filename = pc_game.returnSpriteFilename;
                    //IBMessageBox.Show(pc_game, "filename selected = " + filename);
                    try
                    {
                        pc_character.SpriteFilename = filename;
                        pc_character.LoadSpriteStuff(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName);
                        tokenBitmap = pc_character.CharSprite.Image;
                        //tokenBitmap = new Bitmap(pc_game.mainDirectory + "\\modules\\" + pc_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + pc_character.CharSprite.SpriteSheetFilename);
                        pbToken.Image = (Image)tokenBitmap;

                        if (pbToken == null)
                        {
                            IBMessageBox.Show(pc_game, "returned a null icon bitmap");
                        }
                    }
                    catch
                    {
                        IBMessageBox.Show(pc_game, "failed to open the sprite selected...try another one.");
                    }
                    pc_frm.refreshPartyButtons();
                    pc_game.ChangePartySprite();
                    //pc_game.areaUpdateAll();
                    //pc_game.spritePcDraw(pc_game.playerPosition.X * pc_frm.squareSize, pc_game.playerPosition.Y * pc_frm.squareSize, 0);
                    //pc_game.Update();
                }
            }
        }
        private void btnSkillsTab_Click(object sender, EventArgs e)
        {
            iceBlinkGroupBoxMedium4.Visible = true; //skills
            iceBlinkGroupBoxMedium7.Visible = false; //traits
            iceBlinkGroupBoxMedium5.Visible = false; //spells            
        }
        private void btnTraitsTab_Click(object sender, EventArgs e)
        {
            iceBlinkGroupBoxMedium4.Visible = false; //skills
            iceBlinkGroupBoxMedium7.Visible = true; //traits
            iceBlinkGroupBoxMedium5.Visible = false; //spells   
        }
        private void btnSpellsTab_Click(object sender, EventArgs e)
        {
            iceBlinkGroupBoxMedium4.Visible = false; //skills
            iceBlinkGroupBoxMedium7.Visible = false; //traits
            iceBlinkGroupBoxMedium5.Visible = true; //spells   
        }
    }
}
