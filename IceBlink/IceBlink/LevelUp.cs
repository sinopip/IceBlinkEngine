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
    public partial class LevelUp : IBForm
    {
        private Form1 prntForm;
        private Game game;
        private PC thisPC;
        private int pointsLeft;
        private int maxPoints = 68;
        private Bitmap portrait;
        private int strRaceMod;
        private int dexRaceMod;
        private int intRaceMod;
        private int chaRaceMod;
        private int conRaceMod;
        private int wisRaceMod;
        private int strStart;
        private int dexStart;
        private int intStart;
        private int chaStart;
        private int conStart;
        private int wisStart;
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

        public LevelUp(Game g, Form1 f, PC p)
        {
            InitializeComponent();
            game = g;
            prntForm = f;
            thisPC = p;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            gbMain.setupAll(game);
            gbSkills.setupAll(game);
            gbSpells.setupAll(game);
            gbTraits.setupAll(game);
            groupBox1.setupAll(game);
            groupBox2.setupAll(game);
            btnAddSpell.setupAll(game);
            btnAddTrait.setupAll(game);
            btnDecrementSkill.setupAll(game);
            btnFinish.setupAll(game);
            btnBack.setupAll(game);
            btnNext.setupAll(game);
            btnIncrementSkill.setupAll(game);
            btnRemoveSpell.setupAll(game);
            btnRemoveTrait.setupAll(game);
            this.setupAll(game);
            //fill Traits available based on class, race, level and attributes
            //setupTraitsDataGridView();
            //fill Spells available based on class, race, level and attributes
            //setupSpellsDataGridView();
            setupLabels();
            loadDefaultProtrait();
            refreshFonts();            
        }

        #region Handlers
        private void LevelUp_Load(object sender, EventArgs e)
        {
            //fill skills available based on class, race and attributes
            thisPC.ClassLevel++;
            SortAllowedLists();
            setStartAttributes();
            setModifiers();
            setupSkillsDataGridView();
            resetPointsToSpend();
            DgvColorChange();
            initialSkillCalcs();
            fillTraitsWithAutomaticallyReceived();
            fillSpellsWithAutomaticallyReceived();
            refreshSkillPanelInfo();
            refreshTraitPanelInfo();
            refreshSpellPanelInfo();
            refreshLbxTraitsKnown();
            refreshLbxSpellsKnown();
            setupLvSpellsAvailable();
            setupLvTraitsAvailable();
            refreshLvSpellsAvailable();
            refreshLvTraitsAvailable();
            refreshPanelInfo();
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
            refreshPanelInfo();
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
        //Main
        private void numStr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numStr.Value >= strStart)
                {
                    thisPC.BaseStr = (int)numStr.Value;
                    calcPointsLeft();
                    refreshPanelInfo();
                }
                else
                {
                    numStr.Value = strStart;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
            }
        }
        private void numDex_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numDex.Value >= dexStart)
                {
                    thisPC.BaseDex = (int)numDex.Value;
                    calcPointsLeft();
                    refreshPanelInfo();
                }
                else
                {
                    numDex.Value = dexStart;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
            }
        }
        private void numCon_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numCon.Value >= conStart)
                {
                    thisPC.BaseCon = (int)numCon.Value;
                    calcPointsLeft();
                    refreshPanelInfo();
                }
                else
                {
                    numCon.Value = conStart;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
            }
        }
        private void numInt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numInt.Value >= intStart)
                {
                    thisPC.BaseInt = (int)numInt.Value;
                    calcPointsLeft();
                    refreshPanelInfo();
                }
                else
                {
                    numInt.Value = intStart;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
            }
        }
        private void numWis_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numWis.Value >= wisStart)
                {
                    thisPC.BaseWis = (int)numWis.Value;
                    calcPointsLeft();
                    refreshPanelInfo();
                }
                else
                {
                    numWis.Value = wisStart;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
            }
        }
        private void numCha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numCha.Value >= chaStart)
                {
                    thisPC.BaseCha = (int)numCha.Value;
                    calcPointsLeft();
                    refreshPanelInfo();
                }
                else
                {
                    numCha.Value = chaStart;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
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
                    if (thisPC.KnownSkillsList.skillsList[selectedSkillIndex].RanksAssigned < sa.MaxRanksAtLevelUp)
                    {
                        thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks++;
                        thisPC.KnownSkillsList.skillsList[selectedSkillIndex].RanksAssigned++;
                        thisPC.KnownSkillRefsTags[selectedSkillIndex].SkillRanks++;
                    }                    
                    thisPC.KnownSkillsList.skillsList[selectedSkillIndex].reCalculate(thisPC);
                }
            }
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            refreshSkillPanelInfo();
        }
        private void btnDecrementSkill_Click(object sender, EventArgs e)
        {
            SkillAllowed sa = getSkillAllowedByTag(thisPC.KnownSkillsList.skillsList[selectedSkillIndex].SkillTag);
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            if (sa.Allow)
            {
                if (thisPC.KnownSkillsList.skillsList[selectedSkillIndex].RanksAssigned > 0)
                {
                    thisPC.KnownSkillsList.skillsList[selectedSkillIndex].Ranks--;
                    thisPC.KnownSkillsList.skillsList[selectedSkillIndex].RanksAssigned--;
                    thisPC.KnownSkillRefsTags[selectedSkillIndex].SkillRanks--;
                }
                thisPC.KnownSkillsList.skillsList[selectedSkillIndex].reCalculate(thisPC);
            }
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
                Trait selectedTrait = game.module.ModuleTraitsList.getTraitByTag(selectedItem[0].Name);
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
        private void dgvTraitsAvailable_SelectionChanged(object sender, EventArgs e) //no longer used
        {
            if (dgvTraitsAvailable.CurrentCell != null)
            {
                selectedTraitIndex = dgvTraitsAvailable.CurrentCell.RowIndex;
                if (thisPC.Class.TraitsAllowed.Count > 0)
                {
                    Trait newTS = game.module.ModuleTraitsList.getTraitByTag(thisPC.Class.TraitsAllowed[selectedTraitIndex].Tag);
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
                Trait selectedTrait = game.module.ModuleTraitsList.getTraitByTag(selectedItem[0].Name);
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
                                    selectedTrait.passRefs(game, null);
                                    thisPC.KnownTraitsList.traitList.Add(selectedTrait);
                                    thisPC.KnownTraitsTags.Add(selectedTrait.TraitTag);
                                    traitPointsToSpend--;
                                    refreshLbxTraitsKnown();
                                    refreshTraitPanelInfo();
                                }
                            }
                            else
                            {
                                IBMessageBox.Show(game, "You do not have enough levels to learn this Trait yet");
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
                IBMessageBox.Show(game, "Automatically received Traits can't be removed");
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
                Spell selectedSpell = game.module.ModuleSpellsList.getSpellByTag(selectedItem[0].Name);
                SpellAllowed selectedSpellAllowed = thisPC.Class.getSpellAllowedByTag(selectedItem[0].Name);
                if ((selectedSpell != null) && (selectedSpellAllowed != null))
                {
                    if (thisPC.Class.SpellsAllowed.Count > 0)
                    {
                        rtxtDescription.Text = game.module.LabelSpells + " Name: " + selectedSpell.SpellName + Environment.NewLine +
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
        private void dgvSpellsAvailable_SelectionChanged(object sender, EventArgs e) //no longer used
        {
            if (dgvSpellsAvailable.CurrentCell != null)
            {
                selectedSpellIndex = dgvSpellsAvailable.CurrentCell.RowIndex;
                if (thisPC.Class.SpellsAllowed.Count > 0)
                {
                    Spell newTS = game.module.ModuleSpellsList.getSpellByTag(thisPC.Class.SpellsAllowed[selectedSpellIndex].Tag);
                    rtxtDescription.Text = game.module.LabelSpells + " Name: " + newTS.SpellName + Environment.NewLine +
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
                Spell selectedSpell = game.module.ModuleSpellsList.getSpellByTag(selectedItem[0].Name);
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
                                    selectedSpell.passRefs(game, null);
                                    thisPC.KnownSpellsList.spellList.Add(selectedSpell);
                                    thisPC.KnownSpellsTags.Add(selectedSpell.SpellTag);
                                    spellPointsToSpend--;
                                    refreshLbxSpellsKnown();
                                    refreshSpellPanelInfo();
                                }
                            }
                            else
                            {
                                IBMessageBox.Show(game, "You do not have enough levels to learn this Spell yet");
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
                IBMessageBox.Show(game, "Automatically received Spells can't be removed");
            }
        }
        //Buttons
        private void btnFinish_Click(object sender, EventArgs e)
        {
            //thisPC.ClassLevel++;
            //UpdateStats
            thisPC.HP += thisPC.Class.HpPerLevelUp + ((thisPC.Constitution - 10) / 2);
            thisPC.SP += thisPC.Class.SpPerLevelUp + ((thisPC.Intelligence - 10) / 2);
            //thisPC.HPMax += thisPC.Class.HpPerLevelUp + ((thisPC.Constitution - 10) / 2);
            //thisPC.SPMax += thisPC.Class.SpPerLevelUp + ((thisPC.Intelligence - 10) / 2);
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
                refreshPanelInfo();
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
            //changeGBBackColor();
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
                refreshPanelInfo();
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
            //changeGBBackColor();
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
            dgvSkills.BackgroundColor = game.module.ModuleTheme.StandardBackColor;
            lbxKnownSpells.BackColor = game.module.ModuleTheme.StandardBackColor;
            lbxKnownTraits.BackColor = game.module.ModuleTheme.StandardBackColor;
            lvSpellsAvailable.BackColor = game.module.ModuleTheme.StandardBackColor;
            lvTraitsAvailable.BackColor = game.module.ModuleTheme.StandardBackColor;
            gbMain.Font = game.module.ModuleTheme.ModuleFont;
            groupBox2.Font = game.module.ModuleTheme.ModuleFont;
            gbSkills.Font = game.module.ModuleTheme.ModuleFont;
            gbSpells.Font = game.module.ModuleTheme.ModuleFont;
            gbTraits.Font = game.module.ModuleTheme.ModuleFont;
            txtSkillPointsLeftToSpend.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            txtTraitsToLearn.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            txtSpellsToLearn.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            lblCharKnownSpellsList.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            lblCharKnownSpellsList.Font = new Font(lblCharKnownSpellsList.Font, FontStyle.Underline);
            label36.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label36.Font = new Font(label36.Font, FontStyle.Underline);
            label37.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label37.Font = new Font(label37.Font, FontStyle.Underline);
            label32.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label32.Font = new Font(label32.Font, FontStyle.Underline);
            label30.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.75f);
            btnFinish.Font = game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        private void loadDefaultProtrait()
        {
            try
            {
                if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\portraits\\" + thisPC.PortraitFileL))
                {
                    portrait = new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\portraits\\" + thisPC.PortraitFileL);
                    portraitBitmap.Image = (Image)portrait;
                }
                else if (File.Exists(game.mainDirectory + "\\portraits\\" + thisPC.PortraitFileL))
                {
                    portrait = new Bitmap(game.mainDirectory + "\\portraits\\" + thisPC.PortraitFileL);
                    portraitBitmap.Image = (Image)portrait;
                }
                /*
                try
                {
                    portrait = thisPC.LoadCharacterPortraitBitmapL("portraits\\" + thisPC.PortraitFileL);
                    portraitBitmap.Image = (Image)portrait;
                }*/
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(game, "failed to open the PC's portrait: " + ex.ToString());
            }
        }
        private void setupLabels()
        {
            gbSpells.Text = game.module.LabelSpells.ToUpper();
            lblSpellsToLearn.Text = game.module.LabelSpells + "\r\nto Learn:";
            lblCharKnownSpellsList.Text = "Character\'s Known " + game.module.LabelSpells + " List";
        }
        private void fillTraitsWithAutomaticallyReceived()
        {
            //thisPC.KnownTraitsList.traitList.Clear();
            refreshLbxTraitsKnown();
            refreshTraitPanelInfo();
            foreach (TraitAllowed tr in thisPC.Class.TraitsAllowed)
            {
                if ((tr.AtWhatLevelIsAvailable <= thisPC.ClassLevel) && (tr.AutomaticallyLearned) && (!haveTraitAlready(tr)))
                {
                    Trait newTS = game.module.ModuleTraitsList.getTraitByTag(tr.Tag);
                    newTS.passRefs(game, null);
                    thisPC.KnownTraitsList.traitList.Add(newTS);
                    thisPC.KnownTraitsTags.Add(newTS.TraitTag);
                    refreshLbxTraitsKnown();
                    refreshTraitPanelInfo();
                }
            }
            foreach (TraitAllowed tr in thisPC.Race.TraitsAllowed)
            {
                if ((tr.AtWhatLevelIsAvailable <= thisPC.ClassLevel) && (tr.AutomaticallyLearned) && (!haveTraitAlready(tr)))
                {
                    Trait newTS = game.module.ModuleTraitsList.getTraitByTag(tr.Tag);
                    newTS.passRefs(game, null);
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
            //thisPC.KnownSpellsList.spellList.Clear();
            refreshLbxSpellsKnown();
            refreshSpellPanelInfo();
            foreach (SpellAllowed sp in thisPC.Class.SpellsAllowed)
            {
                if ((sp.AtWhatLevelIsAvailable <= thisPC.ClassLevel) && (sp.AutomaticallyLearned) && (!haveSpellAlready(sp)))
                {
                    Spell newTS = game.module.ModuleSpellsList.getSpellByTag(sp.Tag);
                    newTS.passRefs(game, null);
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
            columnB.Width = 62;

            DataGridViewColumn columnC = new DataGridViewTextBoxColumn();
            columnC.DataPropertyName = "Ranks";
            columnC.HeaderText = "Ranks";
            columnC.Name = "ranks";
            columnC.Width = 50;

            DataGridViewColumn columnD = new DataGridViewTextBoxColumn();
            columnD.DataPropertyName = "RanksAssigned";
            columnD.HeaderText = "This Level Up";
            columnD.Name = "ranksAssigned";
            columnD.Width = 70;

            DataGridViewColumn columnE = new DataGridViewTextBoxColumn();
            columnE.DataPropertyName = "MaxRanksAtLevel";
            columnE.HeaderText = "Max Ranks";
            columnE.Name = "maxRanksAtLevel";
            columnE.Width = 50;

            DataGridViewColumn columnF = new DataGridViewTextBoxColumn();
            columnF.DataPropertyName = "Modifiers";
            columnF.HeaderText = "Mods";
            columnF.Name = "modifiers";
            columnF.Width = 50;

            DataGridViewColumn columnG = new DataGridViewTextBoxColumn();
            columnG.DataPropertyName = "TotalRanks";
            columnG.HeaderText = "Total Ranks";
            columnG.Name = "totalRanks";
            columnG.Width = 50;

            dgvSkills.Columns.Clear();
            dgvSkills.Columns.Add(columnA);
            dgvSkills.Columns.Add(columnB);
            dgvSkills.Columns.Add(columnC);
            dgvSkills.Columns.Add(columnD);
            dgvSkills.Columns.Add(columnE);
            dgvSkills.Columns.Add(columnF);
            dgvSkills.Columns.Add(columnG);
        }
        private void setupTraitsDataGridView() //no longer used
        {
            dgvTraitsAvailable.DataSource = thisPC.Class.TraitsAllowed;
            dgvTraitsAvailable.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "Name";
            columnA.HeaderText = "Name";
            columnA.Name = "name";
            columnA.Width = 160;

            dgvTraitsAvailable.Columns.Clear();
            dgvTraitsAvailable.Columns.Add(columnA);
        }
        private void setupSpellsDataGridView() //no longer used
        {
            dgvSpellsAvailable.DataSource = thisPC.Class.SpellsAllowed;
            dgvSpellsAvailable.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "Name";
            columnA.HeaderText = "Name";
            columnA.Name = "name";
            columnA.Width = 160;

            dgvSpellsAvailable.Columns.Clear();
            dgvSpellsAvailable.Columns.Add(columnA);
        }
        private void initialSkillCalcs()
        {
            foreach (Skill s in thisPC.KnownSkillsList.skillsList)
            {
                SkillAllowed sa = getSkillAllowedByTag(s.SkillTag);
                s.RanksAssigned = 0;
                s.PointsPerRank = sa.PointsPerRank;
                s.MaxRanksAtLevel = (sa.MaxRanksAtLevelUp * (thisPC.ClassLevel - 1)) + sa.MaxRanksAtLevelOne;
                s.reCalculate(thisPC);
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
        private void calcPointsLeft()
        {
            pointsLeft = maxPoints - (int)numStr.Value - (int)numDex.Value - (int)numCon.Value - (int)numWis.Value - (int)numInt.Value - (int)numCha.Value;
            if (pointsLeft == 0)
            {
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
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
        }
        private void setStartAttributes()
        {
            maxPoints = 68 + ((thisPC.ClassLevel / 4) * 2);
            strStart = thisPC.BaseStr;
            dexStart = thisPC.BaseDex;
            intStart = thisPC.BaseInt;
            chaStart = thisPC.BaseCha;
            conStart = thisPC.BaseCon;
            wisStart = thisPC.BaseWis;
        }
        private void resetPointsToSpend()
        {
            maxSkillPointsToSpend = 0;
            for (int x = 0; x < thisPC.ClassLevel; x++)
            {
                maxSkillPointsToSpend += thisPC.Class.SkillPointsToSpendAtLevelTable[x+1];
            }
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            traitPointsToSpend = thisPC.Class.TraitPointsToSpendAtLevelTable[thisPC.ClassLevel];
            spellPointsToSpend = thisPC.Class.SpellPointsToSpendAtLevelTable[thisPC.ClassLevel];
            /* Old Way
            maxSkillPointsToSpend = (thisPC.Class.SkillPointsToSpendAtLevelUp * (thisPC.ClassLevel - 1)) + thisPC.Class.SkillPointsToSpendAtLevelOne;
            skillPointsToSpend = maxSkillPointsToSpend - sumTotalSkillRanks();
            traitPointsToSpend = thisPC.Class.TraitPointsToSpendAtLevelUp;
            spellPointsToSpend = thisPC.Class.SpellPointsToSpendAtLevelUp;
            */
        }
        private bool haveTraitAlready() //no longer used
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
        private bool haveSpellAlready() //no longer used
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
            //initialSkillCalcs();
            //IBMessageBox.Show(game, "refresh panel");
            try
            {
                txtName.Text = thisPC.Name;
                txtRace.Text = thisPC.Race.RaceName;
                txtGender.Text = thisPC.Gender.ToString();
                txtClass.Text = thisPC.Class.PlayerClassName;
                txtLevel.Text = thisPC.ClassLevel.ToString();
                txtPointsLeft.Text = pointsLeft.ToString();
                numStr.Value = thisPC.BaseStr;
                numDex.Value = thisPC.BaseDex;
                numInt.Value = thisPC.BaseInt;
                numCha.Value = thisPC.BaseCha;
                numCon.Value = thisPC.BaseCon;
                numWis.Value = thisPC.BaseWis;
                txtHP.Text = Convert.ToString(thisPC.HP + thisPC.Class.HpPerLevelUp + ((thisPC.Constitution - 10) / 2));
                txtSP.Text = Convert.ToString(thisPC.SP + thisPC.Class.SpPerLevelUp + ((thisPC.Intelligence - 10) / 2));
                txtHPMax.Text = Convert.ToString(thisPC.HPMax);
                txtSPMax.Text = Convert.ToString(thisPC.SPMax);
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
                IBMessageBox.Show(game, "failed to refresh panel");
                game.errorLog(ex.ToString());
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
        #endregion
    }
}
