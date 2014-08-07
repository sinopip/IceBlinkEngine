using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;

namespace IceBlink
{
    public partial class PartyCreation : IBForm
    {
        private Form1 prntForm;
        private Game ccr_game;
        private PC thisPC = new PC();
        private int pointsLeft;
        private int maxPoints = 68;
        private Bitmap portrait;
        private Bitmap iconGameMap;
        private int strRaceMod;
        private int dexRaceMod;
        private int intRaceMod;
        private int chaRaceMod;
        private int conRaceMod;
        private int wisRaceMod;
        private string filenameG;
        private string filenameL;
        private string filenameM;
        private string filenameS;
        private List<PlayerClass> availableClassList = new List<PlayerClass>();
        private List<Spell> availableSpellList = new List<Spell>();
        private List<Trait> availableTraitList = new List<Trait>();
        private int selectedSkillIndex = 0;
        private int selectedTraitIndex = 0;
        private int selectedSpellIndex = 0;
        private int skillPointsToSpend = 10;
        private int maxSkillPointsToSpend = 10;
        private int traitPointsToSpend = 1;
        private int spellPointsToSpend = 2;
        private int numberOfAutoReceivedTraits = 0;
        private int numberOfAutoReceivedSpells = 0;

        public PartyCreation(Game game, Form1 frm)
        {
            InitializeComponent();
            ccr_game = game;
            prntForm = frm;
            IceBlinkButtonResize.setupAll(ccr_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(ccr_game);
            gbMain.setupAll(ccr_game);
            gbSkills.setupAll(ccr_game);
            gbSpells.setupAll(ccr_game);
            gbTraits.setupAll(ccr_game);
            groupBox1.setupAll(ccr_game);
            groupBox2.setupAll(ccr_game);
            btnAddSpell.setupAll(ccr_game);
            btnAddTrait.setupAll(ccr_game);
            btnBack.setupAll(ccr_game);
            btnDecrementSkill.setupAll(ccr_game);
            btnFinish.setupAll(ccr_game);
            btnIcon.setupAll(ccr_game);
            btnIncrementSkill.setupAll(ccr_game);
            btnNext.setupAll(ccr_game);
            btnPortrait.setupAll(ccr_game);
            btnRemoveSpell.setupAll(ccr_game);
            btnRemoveTrait.setupAll(ccr_game);
            this.setupAll(ccr_game);
            setupGroupBoxes();
            changeGBBackColor();
            cmbRace.DataSource = ccr_game.module.ModuleRacesList.racesList;
            cmbRace.DisplayMember = "RaceName";
            //fill cmbClass based on race allowed list
            resetCmbClass();            
            //fill Traits available based on class, race, level and attributes
            //setupTraitsDataGridView();
            //fill Spells available based on class, race, level and attributes
            //setupSpellsDataGridView();
            cmbGender.DataSource = Enum.GetValues(typeof(IceBlinkCore.PC.gender));
            cmbAlignGE.DataSource = Enum.GetValues(typeof(IceBlinkCore.PC.AlignmentGoodEvil));
            cmbAlignLC.DataSource = Enum.GetValues(typeof(IceBlinkCore.PC.AlignmentLawChaos));
            if (!game.module.UseAlignment)
            {
                label21.Visible = false;
                cmbAlignGE.Visible = false;
                cmbAlignLC.Visible = false;
            }
            thisPC.passRefs(ccr_game, null);
            txtName.Text = thisPC.Name;
            setupLabels();
            loadDefaultProtraitAndSprite();
            refreshFonts();
            groupBox1.Visible = true;
            gbSkills.Visible = false;
            gbTraits.Visible = false;
            gbSpells.Visible = false;
        }

        #region Handlers        
        private void PartyCreation_Load(object sender, EventArgs e)
        {
            try
            {
                string _filenameSkills = ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName + "\\data\\" + ccr_game.module.SkillsFileName;
                thisPC.KnownSkillsList = ccr_game.module.ModuleSkillsList.loadSkillsFile(_filenameSkills);
                thisPC.KnownSkillsList.passRefs(ccr_game);
                foreach (Skill sk in thisPC.KnownSkillsList.skillsList)
                {
                    SkillRefs newSkillRef = new SkillRefs();
                    newSkillRef.SkillName = sk.SkillName;
                    newSkillRef.SkillTag = sk.SkillTag;
                    newSkillRef.SkillRanks = sk.Ranks;
                    thisPC.KnownSkillRefsTags.Add(newSkillRef);
                }
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to open Skills file");
                ccr_game.errorLog(ex.ToString());
            }
            //fill skills available based on class, race and attributes
            setupSkillsDataGridView();
            resetPointsToSpend();
            DgvColorChange();
            initialSkillCalcs();
            refreshSkillPanelInfo();
            refreshTraitPanelInfo();
            refreshSpellPanelInfo();
            refreshLbxTraitsKnown();
            refreshLbxSpellsKnown();
            setupLvSpellsAvailable();
            setupLvTraitsAvailable();
            refreshLvSpellsAvailable();
            refreshLvTraitsAvailable();            
        }
        private void setupLvSpellsAvailable()
        {
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "col1";
            header.Width = 160;
            lvSpellsAvailable.Columns.Add(header);
            lvSpellsAvailable.Scrollable = true;
            lvSpellsAvailable.View = View.Details;
        }
        private void setupLvTraitsAvailable()
        {
            ColumnHeader headerT = new ColumnHeader();
            headerT.Text = "";
            headerT.Name = "col1";
            headerT.Width = 160;
            lvTraitsAvailable.Columns.Add(headerT);
            lvTraitsAvailable.Scrollable = true;
            lvTraitsAvailable.View = View.Details;
        }
        //Main stuff
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.Name = txtName.Text;
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                ccr_game.errorLog(ex.ToString());
            }
        }        
        private void cmbRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.Race = ccr_game.module.ModuleRacesList.racesList[cmbRace.SelectedIndex];
                thisPC.RaceTag = thisPC.Race.RaceTag;
                setModifiers();
                refreshPanelInfo();                
                //reset all the class, skills, traits and spells available
                fillClassList();
                rtxtDescription.Text = thisPC.Race.Description;
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to change race");
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.Gender = (IceBlinkCore.PC.gender)cmbGender.SelectedIndex;
                //IBMessageBox.Show(game, "Sex = " + thisPC.Sex);
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to change sex");
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClass.SelectedIndex >= 0)
            {
                try
                {
                    thisPC.Class = availableClassList[cmbClass.SelectedIndex];
                    thisPC.ClassTag = thisPC.Class.PlayerClassTag;
                    SortAllowedLists();
                    //thisPC.Class = (IceBlinkCore.PC.charClass)cmbClass.SelectedIndex;
                    setModifiers();
                    resetPointsToSpend();
                    refreshSkillPanelInfo();
                    resetSkillRanks();
                    //IBMessageBox.Show(game, "Class = " + thisPC.Class);
                    refreshPanelInfo();                    
                    //reset skills, Traits and Spells available
                    //setupTraitsDataGridView();
                    //setupSpellsDataGridView();
                    refreshLvSpellsAvailable();
                    refreshLvTraitsAvailable();
                    DgvColorChange();
                    fillTraitsWithAutomaticallyReceived();
                    fillSpellsWithAutomaticallyReceived();
                    rtxtDescription.Text = thisPC.Class.Description;
                }
                catch (Exception ex)
                {
                    IBMessageBox.Show(ccr_game, "failed to change class");
                    ccr_game.errorLog(ex.ToString());
                }
            }
        }
        private void cmbAlignGE_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                thisPC.AlignGoodEvil = (IceBlinkCore.PC.AlignmentGoodEvil)cmbAlignGE.SelectedIndex;
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to change alignmentGoodEvil");
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void cmbAlignLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.AlignLawChaos = (IceBlinkCore.PC.AlignmentLawChaos)cmbAlignLC.SelectedIndex;
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to change alignmentLawChaos");
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void btnPortrait_Click(object sender, EventArgs e)
        {
            using (var sel = new PortraitSelector(ccr_game, true))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    try
                    {
                        string filename = ccr_game.returnSpriteFilename;
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
                        //thisPC.PortraitFileG = filenameG;
                        thisPC.PortraitFileL = filenameL;
                        //thisPC.PortraitFileM = filenameM;
                        thisPC.PortraitFileS = filenameS;
                        thisPC.LoadAllPcStuff(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName);
                        portrait = thisPC.portraitBitmapL;
                        portraitBitmap.Image = (Image)portrait;

                        //portrait = thisPC.LoadCharacterPortraitBitmapL("portraits\\" + filenameL);
                        //portraitBitmap.Image = (Image)portrait;

                        if (portraitBitmap == null)
                        {
                            IBMessageBox.Show(ccr_game, "returned a null portrait bitmap");
                        }
                    }
                    catch (Exception ex)
                    {
                        IBMessageBox.Show(ccr_game, "Failed to load Portrait...try another: " + ex.ToString());
                    }
                }
            }
            /*openFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\portraits";
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
                thisPC.PortraitFileG = filenameG;
                thisPC.PortraitFileL = filenameL;
                thisPC.PortraitFileM = filenameM;
                thisPC.PortraitFileS = filenameS;
                portrait = thisPC.LoadCharacterPortraitBitmapL("portraits\\" + filenameL);
                portraitBitmap.Image = (Image)portrait;

                if (portraitBitmap == null)
                {
                    IBMessageBox.Show(ccr_game, "returned a null portrait bitmap");
                }
            }*/
        }
        private void btnIcon_Click(object sender, EventArgs e)
        {
            using (var sel = new SpriteSelector(ccr_game, true))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    string filename = ccr_game.returnSpriteFilename;
                    //IBMessageBox.Show(game, "filename selected = " + filename);
                    try
                    {
                        thisPC.SpriteFilename = filename;
                        thisPC.LoadSpriteStuff(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName);
                        iconGameMap = (Bitmap)thisPC.CharSprite.Image.Clone();
                        //iconGameMap = new Bitmap(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + thisPC.CharSprite.SpriteSheetFilename);
                        iconBitmap.Image = (Image)iconGameMap;

                        if (iconGameMap == null)
                        {
                            IBMessageBox.Show(ccr_game, "returned a null icon bitmap");
                        }
                    }
                    catch
                    {
                        IBMessageBox.Show(ccr_game, "failed to open the sprite selected...try another one.");
                    }                    
                }
            }
            /*openFileDialog2.InitialDirectory = ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player";
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
                    thisPC.SpriteFilename = filename;
                    thisPC.LoadSpriteStuff(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName);
                    iconGameMap = (Bitmap)thisPC.CharSprite.Image.Clone();
                    //iconGameMap = new Bitmap(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + thisPC.CharSprite.SpriteSheetFilename);
                    iconBitmap.Image = (Image)iconGameMap;

                    if (iconGameMap == null)
                    {
                        IBMessageBox.Show(ccr_game, "returned a null icon bitmap");
                    }
                }
                catch
                {
                    IBMessageBox.Show(ccr_game, "failed to open the sprite selected...try another one.");
                }
            }*/
        }
        private void numStr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.BaseStr = (int)numStr.Value;
                calcPointsLeft();
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void numDex_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.BaseDex = (int)numDex.Value;
                calcPointsLeft();
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void numCon_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.BaseCon = (int)numCon.Value;
                calcPointsLeft();
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void numWis_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.BaseWis = (int)numWis.Value;
                calcPointsLeft();
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                ccr_game.errorLog(ex.ToString());
            }
        }   
        private void numInt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.BaseInt = (int)numInt.Value;
                calcPointsLeft();
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void numCha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                thisPC.BaseCha = (int)numCha.Value;
                calcPointsLeft();
                refreshPanelInfo();
            }
            catch (Exception ex)
            {
                ccr_game.errorLog(ex.ToString());
            }
        }
        //Skills
        private void dgvSkills_SelectionChanged(object sender, EventArgs e)
        {
            selectedSkillIndex = dgvSkills.CurrentCell.RowIndex;
            if (thisPC.KnownSkillsList.skillsList.Count > 0)
                rtxtDescription.Text = thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Description;
        }
        private SkillAllowed getSkillAllowedByTag(string tag)
        {
            foreach (SkillAllowed ts in thisPC.Class.SkillsAllowed)
            {
                if (ts.Tag == tag) return ts;
            }
            return null;
        }
        private void btnIncrementSkill_Click(object sender, EventArgs e)
        {
            SkillAllowed sa = getSkillAllowedByTag(thisPC.KnownSkillsList.skillsList[selectedSkillIndex].SkillTag);
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            if (sa.Allow)
            {
                if (skillPointsToSpend >= sa.PointsPerRank)
                {
                    thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks++;
                    if (thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks > sa.MaxRanksAtLevelOne)
                    {
                        thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks = sa.MaxRanksAtLevelOne;
                    }
                    thisPC.KnownSkillRefsTags[selectedSkillIndex].SkillRanks = thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks;
                    thisPC.KnownSkillsList.skillsList[selectedSkillIndex].reCalculate(thisPC);
                }
            }
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            refreshSkillPanelInfo();
        }
        private void btnDecrementSkill_Click(object sender, EventArgs e)
        {            
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks--;
            if (thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks < 0)
            {
                thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks = 0;
            }
            thisPC.KnownSkillRefsTags[selectedSkillIndex].SkillRanks = thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks;
            thisPC.KnownSkillsList.skillsList[selectedSkillIndex].reCalculate(thisPC);
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            refreshSkillPanelInfo();
        }        
        //Traits
        private void lvTraitsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Acquire SelectedItems reference.
            var selectedItem = lvTraitsAvailable.SelectedItems;
            if (selectedItem.Count > 0)
            {
                // selectedItem[0].Name is where the Spells Tag was stored
                Trait selectedTrait = ccr_game.module.ModuleTraitsList.getTraitByTag(selectedItem[0].Name);
                TraitAllowed selectedTraitAllowed = thisPC.Class.getTraitAllowedByTag(selectedItem[0].Name);
                if ((selectedTrait != null) && (selectedTraitAllowed != null))
                {
                    if (thisPC.Class.SpellsAllowed.Count > 0)
                    {
                        rtxtDescription.Text = "Trait Name: " + selectedTrait.TraitName + Environment.NewLine +
                                        "SP Cost: " + selectedTrait.CostSP + Environment.NewLine +
                                        "Target Range: " + selectedTrait.Range + Environment.NewLine +
                                        "Area of Effect (square radius): " + selectedTrait.AoeRadiusOrLength + Environment.NewLine +
                                        "Available at Level: " + selectedTraitAllowed.AtWhatLevelIsAvailable + Environment.NewLine +
                                        "Requires Specific Training: " + selectedTraitAllowed.NeedsSpecificTrainingToLearn.ToString() + Environment.NewLine +
                                        Environment.NewLine +
                                        "Description: " + Environment.NewLine +
                                        selectedTrait.Description;
                    }
                    else
                    {
                        MessageBox.Show("traits allowed is empty");
                    }
                }
                else
                {
                    MessageBox.Show("couldn't find the selected Trait or TraitAllowed");
                }
                // Display text of first item selected.
                //this.Text = selectedItem[0].Text;
            }
            else
            {
                // Display default string.
                //MessageBox.Show("selectedItems is empty");
                //this.Text = "Empty";
            }
        }
        private void dgvTraitsAvailable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTraitsAvailable.CurrentCell != null)
            {
                selectedTraitIndex = dgvTraitsAvailable.CurrentCell.RowIndex;
                if (thisPC.Class.TraitsAllowed.Count > 0)
                {
                    Trait newTS = ccr_game.module.ModuleTraitsList.getTraitByTag(thisPC.Class.TraitsAllowed[selectedTraitIndex].Tag);
                    rtxtDescription.Text = "Trait Name: " + newTS.TraitName + Environment.NewLine +
                                        "SP Cost: " + newTS.CostSP + Environment.NewLine +
                                        "Target Range: " + newTS.Range + Environment.NewLine +
                                        "Area of Effect (square radius): " + newTS.AoeRadiusOrLength + Environment.NewLine +
                                        Environment.NewLine +
                                        "Description: " + Environment.NewLine +
                                        newTS.Description;
                }
            }
        }
        private void btnAddTrait_Click(object sender, EventArgs e)
        {
            // Acquire SelectedItems reference.
            var selectedItem = lvTraitsAvailable.SelectedItems;
            if (selectedItem.Count > 0)
            {
                // selectedItem[0].Name is where the Spells Tag was stored
                Trait selectedTrait = ccr_game.module.ModuleTraitsList.getTraitByTag(selectedItem[0].Name);
                TraitAllowed selectedTraitAllowed = thisPC.Class.getTraitAllowedByTag(selectedItem[0].Name);
                if ((selectedTrait != null) && (selectedTraitAllowed != null))
                {
                    if (thisPC.Class.SpellsAllowed.Count > 0)
                    {
                        if (selectedTraitAllowed.Allow)
                        {
                            if (selectedTraitAllowed.AtWhatLevelIsAvailable <= thisPC.ClassLevel)
                            {
                                if ((traitPointsToSpend > 0) && (!haveTraitAlready(selectedTraitAllowed)))
                                {
                                    selectedTrait.passRefs(ccr_game, null);
                                    thisPC.KnownTraitsList.traitList.Add(selectedTrait);
                                    thisPC.KnownTraitsTags.Add(selectedTrait.TraitTag);
                                    traitPointsToSpend--;
                                    refreshLbxTraitsKnown();
                                    refreshTraitPanelInfo();
                                }
                            }
                            else
                            {
                                IBMessageBox.Show(ccr_game, "You do not have enough levels to learn this Trait yet");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("traits allowed is empty");
                    }
                }
                else
                {
                    MessageBox.Show("couldn't find the selected Trait or TraitAllowed");
                }
                // Display text of first item selected.
                //this.Text = selectedItem[0].Text;
            }
            else
            {
                // Display default string.
                //MessageBox.Show("selectedItems is empty");
                //this.Text = "Empty";
            } 

            //old stuff below here...can delete
            /*if (thisPC.Class.TraitsAllowed[selectedTraitIndex].Allow)
            {
                if (thisPC.Class.TraitsAllowed[selectedTraitIndex].AtWhatLevelIsAvailable <= thisPC.ClassLevel)
                {
                    if ((traitPointsToSpend > 0) && (!haveTraitAlready()))
                    {
                        Trait newTS = ccr_game.module.ModuleTraitsList.getTraitByTag(thisPC.Class.TraitsAllowed[selectedTraitIndex].Tag);
                        newTS.passRefs(ccr_game, null);
                        thisPC.KnownTraitsList.traitList.Add(newTS);
                        thisPC.KnownTraitsTags.Add(newTS.TraitTag);
                        traitPointsToSpend--;
                        refreshLbxTraitsKnown();
                        refreshTraitPanelInfo();
                    }
                }
                else
                {
                    IBMessageBox.Show(ccr_game, "You do not have enough levels to learn this Trait yet");
                }
            }*/
        }
        private void btnRemoveTrait_Click(object sender, EventArgs e)
        {
            if (lbxKnownTraits.SelectedIndex >= numberOfAutoReceivedTraits)
            {
                if ((lbxKnownTraits.Items.Count > 0) && (lbxKnownTraits.SelectedIndex >= 0))
                {
                    try
                    {
                        // The Remove button was clicked.
                        int selectedIndex = lbxKnownTraits.SelectedIndex;
                        thisPC.KnownTraitsList.traitList.RemoveAt(selectedIndex);
                        thisPC.KnownTraitsTags.RemoveAt(selectedIndex);
                    }
                    catch { }
                    selectedTraitIndex = 0;
                    lbxKnownTraits.SelectedIndex = 0;
                    traitPointsToSpend++;
                    refreshLbxTraitsKnown();
                    refreshTraitPanelInfo();
                }
            }
            else if (lbxKnownTraits.SelectedIndex >= 0)
            {
                IBMessageBox.Show(ccr_game, "Automatically received Traits can't be removed");
            }
        }
        //Spells
        private void lvSpellsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Acquire SelectedItems reference.
            var selectedItem = lvSpellsAvailable.SelectedItems;
            if (selectedItem.Count > 0)
            {
                // selectedItem[0].Name is where the Spells Tag was stored
                Spell selectedSpell = ccr_game.module.ModuleSpellsList.getSpellByTag(selectedItem[0].Name);
                SpellAllowed selectedSpellAllowed = thisPC.Class.getSpellAllowedByTag(selectedItem[0].Name);
                if ((selectedSpell != null) && (selectedSpellAllowed != null))
                {
                    if (thisPC.Class.SpellsAllowed.Count > 0)
                    {
                        rtxtDescription.Text = ccr_game.module.LabelSpells + " Name: " + selectedSpell.SpellName + Environment.NewLine +
                                            "SP Cost: " + selectedSpell.CostSP + Environment.NewLine +
                                            "Target Range: " + selectedSpell.Range + Environment.NewLine +
                                            "Area of Effect (square radius): " + selectedSpell.AoeRadiusOrLength + Environment.NewLine +
                                            "Available at Level: " + selectedSpellAllowed.AtWhatLevelIsAvailable + Environment.NewLine +
                                            "Requires Specific Training: " + selectedSpellAllowed.NeedsSpecificTrainingToLearn.ToString() + Environment.NewLine +
                                            Environment.NewLine +
                                            "Description: " + Environment.NewLine +
                                            selectedSpell.Description;
                    }
                    else
                    {
                        MessageBox.Show("spells allowed is empty");
                    }
                }
                else
                {
                    MessageBox.Show("couldn't find the selected Spell or SpellAllowed");
                }
                // Display text of first item selected.
                //this.Text = selectedItem[0].Text;
            }
            else
            {
                // Display default string.
                //MessageBox.Show("selectedItems is empty");
                //this.Text = "Empty";
            }
        }
        private void dgvSpellsAvailable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSpellsAvailable.CurrentCell != null)
            {
                selectedSpellIndex = dgvSpellsAvailable.CurrentCell.RowIndex;
                if (thisPC.Class.SpellsAllowed.Count > 0)
                {
                    Spell newTS = ccr_game.module.ModuleSpellsList.getSpellByTag(thisPC.Class.SpellsAllowed[selectedSpellIndex].Tag);
                    rtxtDescription.Text = ccr_game.module.LabelSpells + " Name: " + newTS.SpellName + Environment.NewLine +
                                        "SP Cost: " + newTS.CostSP + Environment.NewLine +
                                        "Target Range: " + newTS.Range + Environment.NewLine +
                                        "Area of Effect (square radius): " + newTS.AoeRadiusOrLength + Environment.NewLine +
                                        Environment.NewLine +
                                        "Description: " + Environment.NewLine +
                                        newTS.Description;
                }
            }
        }
        private void btnAddSpell_Click(object sender, EventArgs e)
        {
            // Acquire SelectedItems reference.
            var selectedItem = lvSpellsAvailable.SelectedItems;
            if (selectedItem.Count > 0)
            {
                // selectedItem[0].Name is where the Spells Tag was stored
                Spell selectedSpell = ccr_game.module.ModuleSpellsList.getSpellByTag(selectedItem[0].Name);
                SpellAllowed selectedSpellAllowed = thisPC.Class.getSpellAllowedByTag(selectedItem[0].Name);
                if ((selectedSpell != null) && (selectedSpellAllowed != null))
                {
                    if (thisPC.Class.SpellsAllowed.Count > 0)
                    {
                        if (selectedSpellAllowed.Allow)
                        {
                            if (selectedSpellAllowed.AtWhatLevelIsAvailable <= thisPC.ClassLevel)
                            {
                                if ((spellPointsToSpend > 0) && (!haveSpellAlready(selectedSpellAllowed)))
                                {
                                    selectedSpell.passRefs(ccr_game, null);
                                    thisPC.KnownSpellsList.spellList.Add(selectedSpell);
                                    thisPC.KnownSpellsTags.Add(selectedSpell.SpellTag);
                                    spellPointsToSpend--;
                                    refreshLbxSpellsKnown();
                                    refreshSpellPanelInfo();
                                }
                            }
                            else
                            {
                                IBMessageBox.Show(ccr_game, "You do not have enough levels to learn this Spell yet");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("spells allowed is empty");
                    }
                }
                else
                {
                    MessageBox.Show("couldn't find the selected Spell or SpellAllowed");
                }
                // Display text of first item selected.
                //this.Text = selectedItem[0].Text;
            }
            else
            {
                // Display default string.
                //MessageBox.Show("selectedItems is empty");
                //this.Text = "Empty";
            }

            // Old stuff below...can delete
            /*if (thisPC.Class.SpellsAllowed.Count > 0)
            {
                if (thisPC.Class.SpellsAllowed[selectedSpellIndex].Allow)
                {
                    if (thisPC.Class.SpellsAllowed[selectedSpellIndex].AtWhatLevelIsAvailable <= thisPC.ClassLevel)
                    {
                        if ((spellPointsToSpend > 0) && (!haveSpellAlready()))
                        {
                            Spell newTS = ccr_game.module.ModuleSpellsList.getSpellByTag(thisPC.Class.SpellsAllowed[selectedSpellIndex].Tag);
                            newTS.passRefs(ccr_game, null);
                            thisPC.KnownSpellsList.spellList.Add(newTS);
                            thisPC.KnownSpellsTags.Add(newTS.SpellTag);
                            spellPointsToSpend--;
                            refreshLbxSpellsKnown();
                            refreshSpellPanelInfo();
                        }
                    }
                    else
                    {
                        IBMessageBox.Show(ccr_game, "You do not have enough levels to learn this Spell yet");
                    }
                }
            }*/
        }
        private void btnRemoveSpell_Click(object sender, EventArgs e)
        {
            if (lbxKnownSpells.SelectedIndex >= numberOfAutoReceivedSpells)
            {
                if ((lbxKnownSpells.Items.Count > 0) && (lbxKnownSpells.SelectedIndex >= 0))
                {
                    try
                    {
                        // The Remove button was clicked.
                        int selectedIndex = lbxKnownSpells.SelectedIndex;
                        thisPC.KnownSpellsList.spellList.RemoveAt(selectedIndex);
                        thisPC.KnownSpellsTags.RemoveAt(selectedIndex);
                    }
                    catch { }
                    selectedSpellIndex = 0;
                    lbxKnownSpells.SelectedIndex = 0;
                    spellPointsToSpend++;
                    refreshLbxSpellsKnown();
                    refreshSpellPanelInfo();
                }
            }
            else if (lbxKnownSpells.SelectedIndex >= 0)
            {
                IBMessageBox.Show(ccr_game, "Automatically received Spells can't be removed");
            }
        }
        //Form buttons
        private void btnFinish_Click(object sender, EventArgs e)
        {            
            thisPC.HP = thisPC.HPMax;
            thisPC.SP = thisPC.SPMax;
            savePC();
            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (gbSkills.Enabled) //going to Main
            {
                gbMain.Enabled = true;
                groupBox1.Visible = true;
                gbSkills.Enabled = false;
                gbSkills.Visible = false;
                gbTraits.Enabled = false;
                gbTraits.Visible = false;
                gbSpells.Enabled = false;
                gbSpells.Visible = false;
                btnBack.Enabled = false;
                btnNext.Enabled = false;
                btnFinish.Enabled = false;
                calcPointsLeft();
            }
            else if (gbTraits.Enabled) //going to Skills
            {
                gbMain.Enabled = false;
                groupBox1.Visible = false;
                gbSkills.Enabled = true;
                gbSkills.Visible = true;
                gbTraits.Enabled = false;
                gbTraits.Visible = false;
                gbSpells.Enabled = false;
                gbSpells.Visible = false;
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
            }            
            else //going to Traits
            {
                gbMain.Enabled = false;
                groupBox1.Visible = false;
                gbSkills.Enabled = false;
                gbSkills.Visible = false;
                gbTraits.Enabled = true;
                gbTraits.Visible = true;
                gbSpells.Enabled = false;
                gbSpells.Visible = false;
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
            }
            changeGBBackColor();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (gbMain.Enabled) //going to Skills
            {
                gbMain.Enabled = false;
                groupBox1.Visible = false;
                gbSkills.Enabled = true;
                gbSkills.Visible = true;
                gbTraits.Enabled = false;
                gbTraits.Visible = false;
                gbSpells.Enabled = false;                
                gbSpells.Visible = false;
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
                calcPointsLeft();
                DgvColorChange();
            }
            else if (gbSkills.Enabled) //going to Traits
            {
                gbMain.Enabled = false;
                groupBox1.Visible = false;
                gbSkills.Enabled = false;
                gbSkills.Visible = false;
                gbTraits.Enabled = true;
                gbTraits.Visible = true;
                gbSpells.Enabled = false;
                gbSpells.Visible = false;
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
            }
            else //going to Spells
            {
                gbMain.Enabled = false;
                groupBox1.Visible = false;
                gbSkills.Enabled = false;
                gbSkills.Visible = false;
                gbTraits.Enabled = false;
                gbTraits.Visible = false;
                gbSpells.Enabled = true;
                gbSpells.Visible = true;
                btnBack.Enabled = true;
                btnNext.Enabled = false;
                btnFinish.Enabled = true;
            }
            changeGBBackColor();
        }
        #endregion

        #region Methods
        private void SortAllowedLists()
        {
            List<SpellAllowed> sortSpellList = new List<SpellAllowed>();
            sortSpellList.Clear();
            foreach (SpellAllowed sa in thisPC.Class.SpellsAllowed)
            {
                sortSpellList.Add(sa);
            }
            sortSpellList = sortSpellList.OrderBy(o => o.AtWhatLevelIsAvailable).ThenBy(o => o.Name).ToList();
            thisPC.Class.SpellsAllowed.Clear();
            foreach (SpellAllowed sa in sortSpellList)
            {
                thisPC.Class.SpellsAllowed.Add(sa);
            }

            List<TraitAllowed> sortTraitList = new List<TraitAllowed>();
            sortTraitList.Clear();
            foreach (TraitAllowed ta in thisPC.Class.TraitsAllowed)
            {
                sortTraitList.Add(ta);
            }
            sortTraitList = sortTraitList.OrderBy(o => o.AtWhatLevelIsAvailable).ThenBy(o => o.Name).ToList();
            thisPC.Class.TraitsAllowed.Clear();
            foreach (TraitAllowed ta in sortTraitList)
            {
                thisPC.Class.TraitsAllowed.Add(ta);
            }
        }
        public void refreshFonts()
        {
            dgvSkills.BackgroundColor = ccr_game.module.ModuleTheme.StandardBackColor;
            lbxKnownSpells.BackColor = ccr_game.module.ModuleTheme.StandardBackColor;
            lbxKnownTraits.BackColor = ccr_game.module.ModuleTheme.StandardBackColor;
            lvSpellsAvailable.BackColor = ccr_game.module.ModuleTheme.StandardBackColor;
            lvTraitsAvailable.BackColor = ccr_game.module.ModuleTheme.StandardBackColor;
            gbMain.Font = ccr_game.module.ModuleTheme.ModuleFont;
            btnPortrait.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 0.75f);
            btnIcon.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 0.75f);
            groupBox2.Font = ccr_game.module.ModuleTheme.ModuleFont;
            gbSkills.Font = ccr_game.module.ModuleTheme.ModuleFont;
            gbSpells.Font = ccr_game.module.ModuleTheme.ModuleFont;
            gbTraits.Font = ccr_game.module.ModuleTheme.ModuleFont;
            txtSkillPointsLeftToSpend.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 1.25f);
            txtTraitsToLearn.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 1.25f);
            txtSpellsToLearn.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 1.25f);
            lblCharKnownSpellsList.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 0.85f);
            lblCharKnownSpellsList.Font = new Font(lblCharKnownSpellsList.Font, FontStyle.Underline);
            label36.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 0.85f);
            label36.Font = new Font(label36.Font, FontStyle.Underline);
            label32.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 0.85f);
            label32.Font = new Font(label32.Font, FontStyle.Underline);
            label37.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 0.85f);
            label37.Font = new Font(label37.Font, FontStyle.Underline);
            label30.Font = prntForm.ChangeFontSize(ccr_game.module.ModuleTheme.ModuleFont, 0.85f);
            btnBack.Font = ccr_game.module.ModuleTheme.ModuleFont;
            btnFinish.Font = ccr_game.module.ModuleTheme.ModuleFont;
            btnNext.Font = ccr_game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        private void loadDefaultProtraitAndSprite()
        {
            try
            {
                //thisPC.PortraitFileG = "HMF_G.png";
                thisPC.PortraitFileL = "HMF_L.png";
                //thisPC.PortraitFileM = "HMF_M.png";
                //thisPC.PortraitFileS = "HMF_S.png";
                portrait = thisPC.LoadCharacterPortraitBitmapL("portraits\\" + thisPC.PortraitFileL);
                portraitBitmap.Image = (Image)portrait;
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to open the default portraits: " + ex.ToString());
            }

            try
            {
                thisPC.SpriteFilename = "heroA.spt";
                thisPC.LoadSpriteStuff(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName);
                iconGameMap = (Bitmap)thisPC.CharSprite.Image.Clone();
                //iconGameMap = new Bitmap(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + thisPC.CharSprite.SpriteSheetFilename);
                iconBitmap.Image = (Image)iconGameMap;

                if (iconGameMap == null)
                {
                    IBMessageBox.Show(ccr_game, "returned a null icon bitmap");
                }
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to open the default sprite: " + ex.ToString());
            }
        }
        private void setupLabels()
        {
            lblGold.Text = ccr_game.module.LabelFunds + ":";
            gbSpells.Text = ccr_game.module.LabelSpells.ToUpper();
            lblSpellsToLearn.Text = ccr_game.module.LabelSpells + "\r\nto Learn:";
            lblCharKnownSpellsList.Text = "Character\'s Known " + ccr_game.module.LabelSpells + " List";
        }
        private void setupGroupBoxes()
        {
            gbMain.ForeColor = Color.Blue;
            foreach (Control ctl in gbMain.Controls)
            { ctl.ForeColor = SystemColors.ControlText; }

            gbSkills.ForeColor = Color.Blue;
            foreach (Control ctl in gbSkills.Controls)
            { ctl.ForeColor = SystemColors.ControlText; }

            gbTraits.ForeColor = Color.Blue;
            foreach (Control ctl in gbTraits.Controls)
            { ctl.ForeColor = SystemColors.ControlText; }

            gbSpells.ForeColor = Color.Blue;
            foreach (Control ctl in gbSpells.Controls)
            { ctl.ForeColor = SystemColors.ControlText; }
        }
        private void changeGBBackColor()
        {
            if (gbMain.Enabled)
            {
                gbMain.BackColor = Color.Gray;
                gbSkills.BackColor = Color.DarkGray;
                gbSpells.BackColor = Color.DarkGray;
                gbTraits.BackColor = Color.DarkGray;
            }
            else if (gbSkills.Enabled)
            {
                gbMain.BackColor = Color.DarkGray;
                gbSkills.BackColor = Color.Gray;
                gbSpells.BackColor = Color.DarkGray;
                gbTraits.BackColor = Color.DarkGray;
            }
            else if (gbTraits.Enabled)
            {
                gbMain.BackColor = Color.DarkGray;
                gbSkills.BackColor = Color.DarkGray;
                gbSpells.BackColor = Color.DarkGray;
                gbTraits.BackColor = Color.Gray;
            }
            else //gbSpells is Enabled
            {
                gbMain.BackColor = Color.DarkGray;
                gbSkills.BackColor = Color.DarkGray;
                gbSpells.BackColor = Color.Gray;
                gbTraits.BackColor = Color.DarkGray;
            }
        }
        private void fillTraitsWithAutomaticallyReceived()
        {
            thisPC.KnownTraitsList.traitList.Clear();
            thisPC.KnownTraitsTags.Clear();
            refreshLbxTraitsKnown();
            refreshTraitPanelInfo();
            foreach (TraitAllowed tr in thisPC.Class.TraitsAllowed)
            {
                if ((tr.AtWhatLevelIsAvailable == 1) && (tr.AutomaticallyLearned))
                {
                    Trait newTS = ccr_game.module.ModuleTraitsList.getTraitByTag(tr.Tag);
                    newTS.passRefs(ccr_game, null);
                    thisPC.KnownTraitsList.traitList.Add(newTS);
                    thisPC.KnownTraitsTags.Add(newTS.TraitTag);
                    refreshLbxTraitsKnown();
                    refreshTraitPanelInfo();
                }
            }
            numberOfAutoReceivedTraits = thisPC.KnownTraitsList.traitList.Count;
        }
        private void fillSpellsWithAutomaticallyReceived()
        {
            thisPC.KnownSpellsList.spellList.Clear();
            thisPC.KnownSpellsTags.Clear();
            refreshLbxSpellsKnown();
            refreshSpellPanelInfo();
            foreach (SpellAllowed sp in thisPC.Class.SpellsAllowed)
            {
                if ((sp.AtWhatLevelIsAvailable == 1) && (sp.AutomaticallyLearned))
                {
                    Spell newTS = ccr_game.module.ModuleSpellsList.getSpellByTag(sp.Tag);
                    newTS.passRefs(ccr_game, null);
                    thisPC.KnownSpellsList.spellList.Add(newTS);
                    thisPC.KnownSpellsTags.Add(newTS.SpellTag);
                    refreshLbxSpellsKnown();
                    refreshSpellPanelInfo();
                }
            }
            numberOfAutoReceivedSpells = thisPC.KnownSpellsList.spellList.Count;
        }
        private void setupSkillsDataGridView()
        {
            dgvSkills.DataSource = thisPC.KnownSkillsList.skillsList;
            dgvSkills.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "SkillName";
            columnA.HeaderText = "Name";
            columnA.Name = "skillName";
            columnA.Width = 100;

            DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
            columnB.DataPropertyName = "PointsPerRank";
            columnB.HeaderText = "Pts/Rank";
            columnB.Name = "pointsPerRank";
            columnB.Width = 70;

            DataGridViewColumn columnC = new DataGridViewTextBoxColumn();
            columnC.DataPropertyName = "Ranks";
            columnC.HeaderText = "Ranks";
            columnC.Name = "ranks";
            columnC.Width = 60;

            DataGridViewColumn columnD = new DataGridViewTextBoxColumn();
            columnD.DataPropertyName = "MaxRanksAtLevel";
            columnD.HeaderText = "Max Ranks";
            columnD.Name = "maxRanksAtLevel";
            columnD.Width = 60;

            DataGridViewColumn columnE = new DataGridViewTextBoxColumn();
            columnE.DataPropertyName = "Modifiers";
            columnE.HeaderText = "Mods";
            columnE.Name = "modifiers";
            columnE.Width = 60;

            DataGridViewColumn columnF = new DataGridViewTextBoxColumn();
            columnF.DataPropertyName = "TotalRanks";
            columnF.HeaderText = "TotalRanks";
            columnF.Name = "totalRanks";
            columnF.Width = 80;            

            dgvSkills.Columns.Clear();
            dgvSkills.Columns.Add(columnA);
            dgvSkills.Columns.Add(columnB);
            dgvSkills.Columns.Add(columnC);
            dgvSkills.Columns.Add(columnD);
            dgvSkills.Columns.Add(columnE);
            dgvSkills.Columns.Add(columnF);
            //dgvSkills.AutoResizeColumns();
        }
        private void setupTraitsDataGridView()
        {
            dgvTraitsAvailable.DataSource = thisPC.Class.TraitsAllowed;
            dgvTraitsAvailable.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "Name";
            columnA.HeaderText = "Name";
            columnA.Name = "name";
            columnA.Width = 142;            

            dgvTraitsAvailable.Columns.Clear();
            dgvTraitsAvailable.Columns.Add(columnA);
            //dgvTraitsAvailable.AutoResizeColumns();
        }
        private void setupSpellsDataGridView()
        {
            dgvSpellsAvailable.DataSource = thisPC.Class.SpellsAllowed;
            dgvSpellsAvailable.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "Name";
            columnA.HeaderText = "Name";
            columnA.Name = "name";
            columnA.Width = 142;

            dgvSpellsAvailable.Columns.Clear();
            dgvSpellsAvailable.Columns.Add(columnA);
            //dgvSpellsAvailable.AutoResizeColumns();
        }
        private void initialSkillCalcs()
        {
            foreach (Skill s in thisPC.KnownSkillsList.skillsList)
            {
                SkillAllowed sa = getSkillAllowedByTag(s.SkillTag);
                if (sa != null)
                {
                    s.PointsPerRank = sa.PointsPerRank;
                    s.MaxRanksAtLevel = sa.MaxRanksAtLevelOne;
                    s.reCalculate(thisPC);
                }
            }
        }
        private void DgvColorChange()
        {
            DataGridViewCellStyle RedCellStyle = new DataGridViewCellStyle();
            RedCellStyle.ForeColor = Color.Red;
            DataGridViewCellStyle BlackCellStyle = new DataGridViewCellStyle();
            BlackCellStyle.ForeColor = Color.Black;

            foreach (DataGridViewRow dgvr in dgvSkills.Rows)
            {
                //if class doesn't allow skill show as red, else black
                SkillAllowed sa = getSkillAllowedByTag(thisPC.KnownSkillsList.skillsList[dgvr.Index].SkillTag);
                if (sa.Allow)
                { dgvr.DefaultCellStyle = BlackCellStyle; }
                else
                { dgvr.DefaultCellStyle = RedCellStyle; }
            }
            /*foreach (DataGridViewRow dgvr in dgvTraitsAvailable.Rows)
            {
                //if class doesn't allow skill show as red, else black
                if (thisPC.Class.TraitsAllowed[dgvr.Index].Allow)
                { dgvr.DefaultCellStyle = BlackCellStyle; }
                else
                { dgvr.DefaultCellStyle = RedCellStyle; }
            }*/
            /*foreach (DataGridViewRow dgvr in dgvSpellsAvailable.Rows)
            {
                //if class doesn't allow skill show as red, else black
                if (thisPC.Class.SpellsAllowed[dgvr.Index].Allow)
                { dgvr.DefaultCellStyle = BlackCellStyle; }
                else
                { dgvr.DefaultCellStyle = RedCellStyle; }
            }*/
        }
        private void fillClassList()
        {
            availableClassList.Clear();
            //iterate through module class list and if the tag exists in the Race allowed list, add to cmbList
            foreach (PlayerClass cls in ccr_game.module.ModulePlayerClassList.playerClassList)
            {
                if (thisPC.Race.ClassesAllowed.Contains(cls.PlayerClassTag))
                {
                    availableClassList.Add(cls);
                }
            }
            resetCmbClass();
        }
        private void resetCmbClass()
        {
            cmbClass.BeginUpdate();
            cmbClass.DataSource = null;
            cmbClass.DataSource = availableClassList;
            cmbClass.DisplayMember = "PlayerClassName";
            cmbClass.EndUpdate();
        }
        private void calcPointsLeft()
        {
            pointsLeft = maxPoints - (int)numStr.Value - (int)numDex.Value - (int)numCon.Value - (int)numWis.Value - (int)numInt.Value - (int)numCha.Value;
            if (pointsLeft == 0)
            {
                btnNext.Enabled = true;
                //btnFinish.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
                //btnFinish.Enabled = false;
            }
        }
        private void setModifiers()
        {
            strRaceMod = thisPC.Race.StrMod;
            dexRaceMod = thisPC.Race.DexMod;
            intRaceMod = thisPC.Race.IntMod;
            chaRaceMod = thisPC.Race.ChaMod;
            conRaceMod = thisPC.Race.ConMod;
            wisRaceMod = thisPC.Race.WisMod;

            /*if (thisPC.Class == PC.charClass.Fighter)
            {
                strClassMod = 0;
                dexClassMod = 0;
                intClassMod = 0;
                chaClassMod = 0;
                conClassMod = 0;
                wisClassMod = 0;
            }
            else if (thisPC.Class == PC.charClass.Thief)
            {
                strClassMod = 0;
                dexClassMod = 0;
                intClassMod = 0;
                chaClassMod = 0;
                conClassMod = 0;
                wisClassMod = 0;
            }
            else if (thisPC.Class == PC.charClass.Wizard)
            {
                strClassMod = 0;
                dexClassMod = 0;
                intClassMod = 0;
                chaClassMod = 0;
                conClassMod = 0;
                wisClassMod = 0;
            }
            if (thisPC.Race == PC.race.Human)
            {
                strRaceMod = 0;
                dexRaceMod = 0;
                intRaceMod = 0;
                chaRaceMod = 0;
                conRaceMod = 0;
                wisRaceMod = 0;
            }
            else if (thisPC.Race == PC.race.Dwarf)
            {
                strRaceMod = 2;
                dexRaceMod = -2;
                intRaceMod = 0;
                chaRaceMod = -2;
                conRaceMod = 2;
                wisRaceMod = 0;
            }
            else if (thisPC.Race == PC.race.Elf)
            {
                strRaceMod = -2;
                dexRaceMod = 2;
                intRaceMod = 2;
                chaRaceMod = 0;
                conRaceMod = -2;
                wisRaceMod = 0;
            }*/
        }
        private void resetPointsToSpend()
        {
            if (thisPC.Class.SkillPointsToSpendAtLevelTable.Count < 1)
            {
                thisPC.Class.setupTables();
            }
            skillPointsToSpend = thisPC.Class.SkillPointsToSpendAtLevelTable[1];
            maxSkillPointsToSpend = thisPC.Class.SkillPointsToSpendAtLevelTable[1];
            traitPointsToSpend = thisPC.Class.TraitPointsToSpendAtLevelTable[1];
            spellPointsToSpend = thisPC.Class.SpellPointsToSpendAtLevelTable[1];
            /* Old Way
            skillPointsToSpend = thisPC.Class.SkillPointsToSpendAtLevelOne;
            maxSkillPointsToSpend = thisPC.Class.SkillPointsToSpendAtLevelOne;
            traitPointsToSpend = thisPC.Class.TraitPointsToSpendAtLevelOne;
            spellPointsToSpend = thisPC.Class.SpellPointsToSpendAtLevelOne;*/
        }
        private void resetSkillRanks()
        {
            foreach (Skill s in thisPC.KnownSkillsList.skillsList)
            {
                SkillAllowed sa = getSkillAllowedByTag(s.SkillTag);
                s.Ranks = 0;
            }
        }
        private bool haveTraitAlready()
        {
            foreach (Trait t in thisPC.KnownTraitsList.traitList)
            {
                if (thisPC.Class.TraitsAllowed[selectedTraitIndex].Tag == t.TraitTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool haveTraitAlready(TraitAllowed ta)
        {
            foreach (Trait t in thisPC.KnownTraitsList.traitList)
            {
                if (ta.Tag == t.TraitTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool haveSpellAlready()
        {
            foreach (Spell s in thisPC.KnownSpellsList.spellList)
            {
                if (thisPC.Class.SpellsAllowed[selectedSpellIndex].Tag == s.SpellTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool haveSpellAlready(SpellAllowed sa)
        {
            foreach (Spell s in thisPC.KnownSpellsList.spellList)
            {
                if (sa.Tag == s.SpellTag)
                {
                    return true;
                }
            }
            return false;
        }
        private void refreshPanelInfo()
        {
            thisPC.UpdateStats(prntForm.sf);
            initialSkillCalcs();
            //IBMessageBox.Show(game, "refresh panel");
            try
            {
                txtPointsLeft.Text = pointsLeft.ToString();
                numStr.Value = thisPC.BaseStr;
                numDex.Value = thisPC.BaseDex;
                numInt.Value = thisPC.BaseInt;
                numCha.Value = thisPC.BaseCha;
                numCon.Value = thisPC.BaseCon;
                numWis.Value = thisPC.BaseWis;
                txtHP.Text = thisPC.HPMax.ToString();
                txtSP.Text = thisPC.SPMax.ToString();
                txtGold.Text = thisPC.Funds.ToString();
                strMod.Text = Convert.ToString(strRaceMod);
                dexMod.Text = Convert.ToString(dexRaceMod);
                intMod.Text = Convert.ToString(intRaceMod);
                chaMod.Text = Convert.ToString(chaRaceMod);
                conMod.Text = Convert.ToString(conRaceMod);
                wisMod.Text = Convert.ToString(wisRaceMod);
                strFinal.Text = Convert.ToString(thisPC.BaseStr + strRaceMod);
                dexFinal.Text = Convert.ToString(thisPC.BaseDex + dexRaceMod);
                intFinal.Text = Convert.ToString(thisPC.BaseInt + intRaceMod);
                chaFinal.Text = Convert.ToString(thisPC.BaseCha + chaRaceMod);
                conFinal.Text = Convert.ToString(thisPC.BaseCon + conRaceMod);
                wisFinal.Text = Convert.ToString(thisPC.BaseWis + wisRaceMod);
                int strE = (thisPC.BaseStr + strRaceMod - 10) / 2;
                strEffect.Text = strE.ToString("+#;-#;0");
                int dexE = ((thisPC.BaseDex + dexRaceMod - 10) / 2);
                dexEffect.Text = dexE.ToString("+#;-#;0");
                int intE = ((thisPC.BaseInt + intRaceMod - 10) / 2);
                intEffect.Text = intE.ToString("+#;-#;0");
                int chaE = ((thisPC.BaseCha + chaRaceMod - 10) / 2);
                chaEffect.Text = chaE.ToString("+#;-#;0");
                int conE = ((thisPC.BaseCon + conRaceMod - 10) / 2);
                conEffect.Text = conE.ToString("+#;-#;0");
                int wisE = ((thisPC.BaseWis + wisRaceMod - 10) / 2);
                wisEffect.Text = wisE.ToString("+#;-#;0");
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(ccr_game, "failed to refresh panel");
                ccr_game.errorLog(ex.ToString());
            }
        }
        private void refreshSkillPanelInfo()
        {
            txtSkillPointsLeftToSpend.Text = skillPointsToSpend.ToString();
        }
        private void refreshTraitPanelInfo()
        {
            txtTraitsToLearn.Text = traitPointsToSpend.ToString();
        }
        private void refreshSpellPanelInfo()
        {
            txtSpellsToLearn.Text = spellPointsToSpend.ToString();
        }
        private void refreshLbxTraitsKnown()
        {
            lbxKnownTraits.BeginUpdate();
            lbxKnownTraits.DataSource = null;
            lbxKnownTraits.DataSource = thisPC.KnownTraitsList.traitList;
            lbxKnownTraits.DisplayMember = "TraitName";
            lbxKnownTraits.EndUpdate();
        }
        private void refreshLbxSpellsKnown()
        {
            lbxKnownSpells.BeginUpdate();
            lbxKnownSpells.DataSource = null;
            lbxKnownSpells.DataSource = thisPC.KnownSpellsList.spellList;
            lbxKnownSpells.DisplayMember = "SpellName";
            lbxKnownSpells.EndUpdate();
        }
        private void refreshLvSpellsAvailable()
        {
            lvSpellsAvailable.Items.Clear();
            foreach (SpellAllowed sa in thisPC.Class.SpellsAllowed)
            {
                if (sa.Allow)
                {
                    ListViewItem lvitm = new ListViewItem();
                    lvitm.Text = sa.Name;
                    lvitm.Name = sa.Tag;
                    if (sa.AtWhatLevelIsAvailable <= thisPC.ClassLevel) { lvitm.ForeColor = Color.Black; }
                    else { lvitm.ForeColor = Color.Gray; }
                    lvSpellsAvailable.Items.Add(lvitm);
                }
            }
        }
        private void refreshLvTraitsAvailable()
        {
            lvTraitsAvailable.Items.Clear();
            foreach (TraitAllowed ta in thisPC.Class.TraitsAllowed)
            {
                if (ta.Allow)
                {
                    ListViewItem lvitm = new ListViewItem();
                    lvitm.Text = ta.Name;
                    lvitm.Name = ta.Tag;
                    if (ta.AtWhatLevelIsAvailable <= thisPC.ClassLevel) { lvitm.ForeColor = Color.Black; }
                    else { lvitm.ForeColor = Color.Gray; }
                    lvTraitsAvailable.Items.Add(lvitm);
                }
            }
        }
        private int sumTotalSkillRanks()
        {
            int total = 0;
            foreach (Skill s in thisPC.KnownSkillsList.skillsList)
            {
                SkillAllowed sa = getSkillAllowedByTag(s.SkillTag);
                total += s.Ranks * sa.PointsPerRank;
            }
            return total;
        }
        private void savePC()
        {
            string jobDir = ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName + "\\characters\\player";
            thisPC.Tag = thisPC.Name.ToLower();
            thisPC.ResRef = thisPC.Tag + "00";
            thisPC.savePCFile(jobDir + "\\" + thisPC.Name + ".char");
        }
        #endregion        
    }
}
