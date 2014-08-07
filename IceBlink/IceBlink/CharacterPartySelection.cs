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
    public partial class CharacterPartySelection : Form
    {
        private Game game;
        private Form1 prntForm;
        private PCs characters = new PCs();
        private List<PCs> parties = new List<PCs>();
        private int selectedLbxIndex = 0;
        private int selectedLbxPartyIndex = 0;

        public CharacterPartySelection(Game g, Form1 frm)
        {
            game = g;
            prntForm = frm;
            InitializeComponent();
            btnAddToParty.setupAll(game);
            btnCreateCharacter.setupAll(game);
            btnRemoveFromParty.setupAll(game);
            btnStartCharacter.setupAll(game);
            resetPCList();
            loadCharacters();
            refreshCharacterListBox();
            refreshFonts();
            iceBlinkGroupBoxMedium1.setupAll(game);
            iceBlinkGroupBoxMedium2.setupAll(game);
            iceBlinkGroupBoxMedium3.setupAll(game);
        }

        #region Handlers
        private void lbxCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLbxIndex = lbxCharacters.SelectedIndex;
            lbxCharacters.SelectedIndex = selectedLbxIndex;
            refreshPlayerInfo();
        }
        private void btnStartCharacter_Click(object sender, EventArgs e)
        {
            if (game.playerList.PCList.Count > 0)
            {
                if (game.playerList.PCList.Count > 5)
                {
                    prntForm.pc_button_5.Enabled = true;
                    prntForm.pcInventory.rbtnPc5.Enabled = true;
                    prntForm.pc_button_5.BackgroundImage = (Image)game.playerList.PCList[5].portraitBitmapM;
                    prntForm.pcSheet5.passRefs(prntForm, game, 5);
                    prntForm.pcSheet5.refreshSheet();
                }
                if (game.playerList.PCList.Count > 4)
                {
                    prntForm.pc_button_4.Enabled = true;
                    prntForm.pcInventory.rbtnPc4.Enabled = true;
                    prntForm.pc_button_4.BackgroundImage = (Image)game.playerList.PCList[4].portraitBitmapM;
                    prntForm.pcSheet4.passRefs(prntForm, game, 4);
                    prntForm.pcSheet4.refreshSheet();
                }
                if (game.playerList.PCList.Count > 3)
                {
                    prntForm.pc_button_3.Enabled = true;
                    prntForm.pcInventory.rbtnPc3.Enabled = true;
                    prntForm.pc_button_3.BackgroundImage = (Image)game.playerList.PCList[3].portraitBitmapM;
                    prntForm.pcSheet3.passRefs(prntForm, game, 3);
                    prntForm.pcSheet3.refreshSheet();
                }
                if (game.playerList.PCList.Count > 2)
                {
                    prntForm.pc_button_2.Enabled = true;
                    prntForm.pcInventory.rbtnPc2.Enabled = true;
                    prntForm.pc_button_2.BackgroundImage = (Image)game.playerList.PCList[2].portraitBitmapM;
                    prntForm.pcSheet2.passRefs(prntForm, game, 2);
                    prntForm.pcSheet2.refreshSheet();
                }
                if (game.playerList.PCList.Count > 1)
                {
                    prntForm.pc_button_1.Enabled = true;
                    prntForm.pcInventory.rbtnPc1.Enabled = true;
                    prntForm.pc_button_1.BackgroundImage = (Image)game.playerList.PCList[1].portraitBitmapM;
                    prntForm.pcSheet1.passRefs(prntForm, game, 1);
                    prntForm.pcSheet1.refreshSheet();
                }
                if (game.playerList.PCList.Count > 0)
                {
                    prntForm.pc_button_0.Enabled = true;
                    prntForm.pcInventory.rbtnPc0.Enabled = true;
                    prntForm.pc_button_0.BackgroundImage = (Image)game.playerList.PCList[0].portraitBitmapM;
                    prntForm.pcSheet0.passRefs(prntForm, game, 0);
                    prntForm.pcSheet0.refreshSheet();
                }
                //prntForm.pcInventory.refreshPanelInfo();
                prntForm.doPortraitStats();
                this.Close();
            }
        }
        private void btnCreateCharacter_Click(object sender, EventArgs e)
        {
            createNewCharacter();
            loadCharacters();
            refreshCharacterListBox();
            resetPCList();            
        }
        private void lbxParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLbxPartyIndex = lbxParty.SelectedIndex;
            lbxParty.SelectedIndex = selectedLbxPartyIndex;
        }
        private void btnAddToParty_Click(object sender, EventArgs e)
        {
            if (game.playerList.PCList.Count <= 5)
            {
                PC newCharacter = new PC();
                newCharacter.passRefs(game, null);
                newCharacter = characters.PCList[selectedLbxIndex];
                if (!game.playerList.PCList.Contains(newCharacter))
                {
                    game.playerList.PCList.Add(newCharacter);
                }
                refreshPartyListBox();
            }
        }
        private void btnRemoveFromParty_Click(object sender, EventArgs e)
        {
            if ((lbxParty.Items.Count > 0) && (game.playerList.PCList.Count > 0) && (selectedLbxPartyIndex < game.playerList.PCList.Count))
            {
                game.playerList.PCList.RemoveAt(selectedLbxPartyIndex);
                refreshPartyListBox();
            }
        }
        #endregion

        #region Methods
        public void refreshFonts()
        {
            label1.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            //label2.Font = game.module.ModuleTheme.ModuleFont;
            //label2.Font = new Font(label2.Font, FontStyle.Underline);
            //label3.Font = game.module.ModuleTheme.ModuleFont;
            //label3.Font = new Font(label3.Font, FontStyle.Underline);
            label14.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label15.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label20.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label21.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label23.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label7.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            lbxCharacters.Font = game.module.ModuleTheme.ModuleFont;
            lbxParty.Font = game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium1.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.0f);
            iceBlinkGroupBoxMedium2.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.0f);
            iceBlinkGroupBoxMedium3.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.0f);
            //groupBox4.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.80f);
            //groupBox6.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.80f);
            btnCreateCharacter.Font = game.module.ModuleTheme.ModuleFont;
            btnStartCharacter.Font = game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        private void loadCharacters()
        {
            try
            {
                characters.PCList.Clear();
                string jobDir = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\characters\\player";
                string spriteFolder = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player";
                string moduleFolder = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName;
                foreach (string f in Directory.GetFiles(jobDir, "*.char"))
                {
                    string filename = Path.GetFileName(f);
                    //load the character file
                    PC newPC = new PC();
                    newPC.passRefs(game, null);
                    newPC = newPC.loadPCFile(jobDir + "\\" + filename);
                    newPC.passRefs(game, null);
                    newPC.LoadAllPcStuff(moduleFolder);
                    // when loading characters that have a blank "raceTag" or lists are empty, create lists and tags based on current objects
                    // this "if" statement may not be necessary once everyone has converted their PCs to the new format
                    if ((newPC.RaceTag == "")|| (newPC.KnownSkillRefsTags.Count < 1))
                    {
                        newPC.RaceTag = newPC.Race.RaceTag;
                        newPC.ClassTag = newPC.Class.PlayerClassTag;
                        newPC.KnownSpellsTags.Clear();
                        foreach (Spell sp in newPC.KnownSpellsList.spellList)
                        {
                            newPC.KnownSpellsTags.Add(sp.SpellTag);
                        }
                        newPC.KnownTraitsTags.Clear();
                        foreach (Trait tr in newPC.KnownTraitsList.traitList)
                        {
                            newPC.KnownTraitsTags.Add(tr.TraitTag);
                        }
                        newPC.KnownSkillRefsTags.Clear();
                        foreach (Skill sk in newPC.KnownSkillsList.skillsList)
                        {
                            SkillRefs sr = new SkillRefs();
                            sr.SkillName = sk.SkillName;
                            sr.SkillTag = sk.SkillTag;
                            sr.SkillRanks = sk.Ranks;
                            newPC.KnownSkillRefsTags.Add(sr);
                        }
                    }
                    newPC.Race = game.module.ModuleRacesList.getRaceByTag(newPC.RaceTag).DeepCopy();
                    newPC.Class = game.module.ModulePlayerClassList.getPlayerClassByTag(newPC.ClassTag).DeepCopy();
                    newPC.KnownSpellsList.spellList.Clear();
                    foreach (SpellAllowed spA in newPC.Class.SpellsAllowed)
                    {
                        if (!newPC.KnownSpellsTags.Contains(spA.Tag))
                        {
                            //add to knownspellstag list if can have it automatically
                            if ((spA.AtWhatLevelIsAvailable <= newPC.ClassLevel) && (spA.AutomaticallyLearned))
                            {
                                Spell newTS = game.module.ModuleSpellsList.getSpellByTag(spA.Tag);
                                newTS.passRefs(game, null);
                                newPC.KnownSpellsTags.Add(newTS.SpellTag);
                            }
                        }
                    }
                    foreach (string spTag in newPC.KnownSpellsTags)
                    {
                        Spell sp = game.module.ModuleSpellsList.getSpellByTag(spTag).DeepCopy();
                        newPC.KnownSpellsList.spellList.Add(sp);
                    }                    
                    newPC.KnownTraitsList.traitList.Clear();
                    foreach (TraitAllowed trA in newPC.Class.TraitsAllowed)
                    {
                        if (!newPC.KnownTraitsTags.Contains(trA.Tag))
                        {
                            //add to knownspellstag list if can have it automatically
                            if ((trA.AtWhatLevelIsAvailable <= newPC.ClassLevel) && (trA.AutomaticallyLearned))
                            {
                                Trait newTS = game.module.ModuleTraitsList.getTraitByTag(trA.Tag);
                                newTS.passRefs(game, null);
                                newPC.KnownTraitsTags.Add(newTS.TraitTag);
                            }
                        }
                    }
                    foreach (TraitAllowed trA in newPC.Race.TraitsAllowed)
                    {
                        if (!newPC.KnownTraitsTags.Contains(trA.Tag))
                        {
                            //add to knownspellstag list if can have it automatically
                            if ((trA.AtWhatLevelIsAvailable <= newPC.ClassLevel) && (trA.AutomaticallyLearned))
                            {
                                Trait newTS = game.module.ModuleTraitsList.getTraitByTag(trA.Tag);
                                newTS.passRefs(game, null);
                                newPC.KnownTraitsTags.Add(newTS.TraitTag);
                            }
                        }
                    }
                    foreach (string trTag in newPC.KnownTraitsTags)
                    {
                        Trait tr = game.module.ModuleTraitsList.getTraitByTag(trTag).DeepCopy();
                        newPC.KnownTraitsList.traitList.Add(tr);
                    }
                    newPC.KnownSkillsList.skillsList.Clear();
                    foreach (Skill sk in game.module.ModuleSkillsList.skillsList)
                    {
                        newPC.KnownSkillsList.skillsList.Add(sk.DeepCopy());
                    }
                    foreach (SkillRefs sr in newPC.KnownSkillRefsTags)
                    {
                        foreach (Skill sk in newPC.KnownSkillsList.skillsList)
                        {
                            if (sk.SkillTag == sr.SkillTag)
                            {
                                sk.Ranks = sr.SkillRanks;
                            }
                        }
                    }
                    newPC.KnownSkillRefsTags.Clear();
                    foreach (Skill sk in newPC.KnownSkillsList.skillsList)
                    {
                        SkillRefs sr = new SkillRefs();
                        sr.SkillName = sk.SkillName;
                        sr.SkillTag = sk.SkillTag;
                        sr.SkillRanks = sk.Ranks;
                        newPC.KnownSkillRefsTags.Add(sr);
                    }
                    foreach (Skill sk in newPC.KnownSkillsList.skillsList)
                    {
                        sk.reCalculate(newPC);
                    }
                    characters.PCList.Add(newPC);
                }
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(game, "failed to load characters from characters folder");
                game.errorLog(ex.ToString());
            }
        }
        private void refreshCharacterListBox()
        {
            lbxCharacters.BeginUpdate();
            lbxCharacters.DataSource = null;
            lbxCharacters.DataSource = characters.PCList;
            lbxCharacters.DisplayMember = "Name";
            lbxCharacters.EndUpdate();
        }
        private void refreshPartyListBox()
        {
            lbxParty.BeginUpdate();
            lbxParty.DataSource = null;
            lbxParty.DataSource = game.playerList.PCList;
            lbxParty.DisplayMember = "Name";
            lbxParty.EndUpdate();
        }
        private void refreshPlayerInfo()
        {
            if (lbxCharacters.Items.Count > 0)
            {
                try
                {
                    PC pc = characters.PCList[selectedLbxIndex];
                    txtPlayerName.Text = pc.Name;
                    txtPlayerRace.Text = pc.Race.RaceName;
                    txtGender.Text = pc.Gender.ToString();
                    txtPlayerClass.Text = pc.Class.PlayerClassName;
                    txtLevel.Text = pc.ClassLevel.ToString();
                    txtHP.Text = pc.HP.ToString();
                    txtSP.Text = pc.SP.ToString();
                    pbPortrait.Image = (Image)pc.portraitBitmapM;
                }
                catch
                {
                    //IBMessageBox.Show(game, "Failed to refresh player info");
                }
            }
        }
        private void createNewCharacter()
        {
            resetPCList();
            /*PC newCharacter = new PC();
            newCharacter.passRefs(game);
            newCharacter.Name = "Rilian";
            newCharacter.BaseStr = 18;
            newCharacter.PortraitFileG = "HMF_G.png";
            newCharacter.PortraitFileL = "HMF_L.png";
            newCharacter.PortraitFileM = "HMF_M.png";
            newCharacter.PortraitFileS = "HMF_S.png";
            newCharacter.SpriteFilename = "heroA.spt";
            //newCharacter.LoadSpriteStuff(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites");
            game.playerList.PCList.Add(newCharacter);*/
            try
            {
                PartyCreation partyCreationScreen = new PartyCreation(game, prntForm);
                partyCreationScreen.BackgroundImage = prntForm.currentTheme.StandardThemeBitmap;
                partyCreationScreen.ShowDialog();
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(game, "Error: " + ex.ToString());
            }
        }
        private void resetPCList()
        {
            game.playerList = new PCs();
            game.playerList.passRefs(game);
        }
        #endregion        
    }
}
