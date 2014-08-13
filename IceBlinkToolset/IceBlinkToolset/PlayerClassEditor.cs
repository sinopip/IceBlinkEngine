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
using System.Threading;

namespace IceBlinkToolset
{
    public partial class PlayerClassEditor : Form
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;
        private int selectedLbxIndex = 0;

        public PlayerClassEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
            refreshListBox();
            fillSavesIfEmpty();
            fillOtherTablesIfEmpty();
            checkForNewTraits();
            checkForNewSpells();
            checkForNewSkills();
            checkForDeletedSkills();
            checkForDeletedSpells();
            checkForDeletedTraits();
            refreshItemsAllowed();
            refreshSkillsAllowed();
            setupSkillsDataGridView();
            setupSpellsDataGridView();
            setupTraitsDataGridView();
        }

        #region Handlers
        private void btnAddPlayerClass_Click(object sender, EventArgs e)
        {
            PlayerClass newPlayerClass = new PlayerClass();
            newPlayerClass.passRefs(game);
            newPlayerClass.PlayerClassName = "newPlayerClass";
            newPlayerClass.PlayerClassTag = "newPlayerClassTag_" + prntForm.mod.NextIdNumber.ToString();
            newPlayerClass.setupXpTable();
            newPlayerClass.setupSavingThrowTables();
            newPlayerClass.setupTables();
            prntForm.playerClassesList.playerClassList.Add(newPlayerClass);
            selectedLbxIndex = prntForm.playerClassesList.playerClassList.Count - 1;
            fillAllowedSkillList();
            fillAllowedSpellList();
            fillAllowedTraitList();
            //lbxPlayerClasses.SelectedIndex = selectedLbxIndex;
            refreshListBox();            
        }
        private void btnRemovePlayerClass_Click(object sender, EventArgs e)
        {
            if (lbxPlayerClasses.Items.Count > 0)
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxPlayerClasses.SelectedIndex;
                    //mod.ModuleContainersList.containers.RemoveAt(selectedIndex);
                    prntForm.playerClassesList.playerClassList.RemoveAt(selectedIndex);
                }
                catch { }
                selectedLbxIndex = 0;
                lbxPlayerClasses.SelectedIndex = 0;
                refreshListBox();
            }
        }
        private void btnDuplicatePlayerClass_Click(object sender, EventArgs e)
        {
            PlayerClass newCopy = prntForm.playerClassesList.playerClassList[selectedLbxIndex].DeepCopy();
            newCopy.passRefs(game);
            newCopy.PlayerClassTag = "newPlayerClassTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.playerClassesList.playerClassList.Add(newCopy);
            refreshListBox();
        }
        private void lbxPlayerClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbxPlayerClasses.SelectedIndex >= 0) && (prntForm.playerClassesList.playerClassList != null))
            {
                selectedLbxIndex = lbxPlayerClasses.SelectedIndex;
                lbxPlayerClasses.SelectedIndex = selectedLbxIndex;
                propertyGrid1.SelectedObject = prntForm.playerClassesList.playerClassList[selectedLbxIndex];
                refreshItemsAllowed();
                refreshSkillsAllowed();
                setupSkillsDataGridView();
                setupTraitsDataGridView();
                setupSpellsDataGridView();
            }
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshListBox();
        }
        private void lbxPlayerClasses_MouseClick(object sender, MouseEventArgs e)
        {
            prntForm.playerClassesList.playerClassList[selectedLbxIndex].ItemsAllowed.Clear();
            foreach (object itemChecked in cbxItemsAllowed.CheckedItems)
            {
                Item chkdItem = (Item)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].ItemsAllowed.Add(chkdItem.ItemResRef);
            }
            /*prntForm.playerClassesList.playerClassList[selectedLbxIndex].SkillsAllowed.Clear();
            foreach (object itemChecked in cbxSkillsAllowed.CheckedItems)
            {
                Skill chkdItem = (Skill)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].SkillsAllowed.Add(chkdItem.SkillTag);
            }*/
            /*prntForm.playerClassesList.playerClassList[selectedLbxIndex].TraitsAllowed.Clear();
            foreach (object itemChecked in cbxTraitsAllowed.CheckedItems)
            {
                Trait chkdItem = (Trait)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].TraitsAllowed.Add(chkdItem.TraitTag);
            }*/
            /*prntForm.playerClassesList.playerClassList[selectedLbxIndex].SpellsAllowed.Clear();
            foreach (object itemChecked in cbxSpellsAllowed.CheckedItems)
            {
                Spell chkdItem = (Spell)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].SpellsAllowed.Add(chkdItem.SpellTag);
            }*/
        }
        private void PlayerClassEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            prntForm.playerClassesList.playerClassList[selectedLbxIndex].ItemsAllowed.Clear();
            foreach (object itemChecked in cbxItemsAllowed.CheckedItems)
            {
                Item chkdItem = (Item)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].ItemsAllowed.Add(chkdItem.ItemResRef);
            }
            /*prntForm.playerClassesList.playerClassList[selectedLbxIndex].SkillsAllowed.Clear();
            foreach (object itemChecked in cbxSkillsAllowed.CheckedItems)
            {
                Skill chkdItem = (Skill)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].SkillsAllowed.Add(chkdItem.SkillTag);
            }*/
            /*prntForm.playerClassesList.playerClassList[selectedLbxIndex].TraitsAllowed.Clear();
            foreach (object itemChecked in cbxTraitsAllowed.CheckedItems)
            {
                Trait chkdItem = (Trait)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].TraitsAllowed.Add(chkdItem.TraitTag);
            }*/
            /*prntForm.playerClassesList.playerClassList[selectedLbxIndex].SpellsAllowed.Clear();
            foreach (object itemChecked in cbxSpellsAllowed.CheckedItems)
            {
                Spell chkdItem = (Spell)itemChecked;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].SpellsAllowed.Add(chkdItem.SpellTag);
            }*/
        }
        private void dgvSpellsAllowed_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Incorrect Data Type");
        }
        private void dgvTraitsAllowed_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Incorrect Data Type");
        }
        private void dgvSkillsAllowed_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Incorrect Data Type");
        }
        #endregion

        #region Methods
        private void fillSavesIfEmpty()
        {
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                if (cl.BaseFortitudeAtLevel.Count < 1)
                {
                    cl.setupSavingThrowTables();
                }
            }
        }
        private void fillOtherTablesIfEmpty()
        {
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                if (cl.BabTable.Count < 1)
                {
                    cl.setupTables();
                }
            }
        }
        private void checkForNewSkills()
        {
            bool foundOne = false;
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                foreach (Skill sk in prntForm.skillsList.skillsList)
                {
                    foreach (SkillAllowed ska in cl.SkillsAllowed)
                    {
                        if (ska.Tag == sk.SkillTag)
                        {
                            foundOne = true;
                            break;
                        }
                    }
                    if (!foundOne)
                    {
                        SkillAllowed newTA = new SkillAllowed();
                        newTA.Name = sk.SkillName;
                        newTA.Tag = sk.SkillTag;
                        cl.SkillsAllowed.Add(newTA);
                    }
                    else
                    {
                        foundOne = false;
                    }
                }
            }
        }
        private void checkForDeletedSkills()
        {
            bool foundOne = false;
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                for (int i = cl.SkillsAllowed.Count - 1; i >= 0; i--)
                {
                    foreach (Skill sk in prntForm.skillsList.skillsList)
                    {
                        if (sk.SkillTag == cl.SkillsAllowed[i].Tag)
                        {
                            foundOne = true;
                            break;
                        }                        
                    }
                    if (!foundOne)
                    {
                        cl.SkillsAllowed.RemoveAt(i);
                    }
                    else
                    {
                        foundOne = false;
                    }
                }
            }
        }
        private void checkForNewTraits()
        {
            bool foundOne = false;
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                foreach (Trait tr in prntForm.traitsList.traitList)
                {
                    foreach (TraitAllowed ta in cl.TraitsAllowed)
                    {
                        if (ta.Tag == tr.TraitTag)
                        {
                            foundOne = true;
                            break;
                        }
                    }
                    if (!foundOne)
                    {
                        TraitAllowed newTA = new TraitAllowed();
                        newTA.Name = tr.TraitName;
                        newTA.Tag = tr.TraitTag;
                        cl.TraitsAllowed.Add(newTA);
                    }
                    else
                    {
                        foundOne = false;
                    }
                }
            }
        }
        private void checkForDeletedTraits()
        {
            bool foundOne = false;
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                for (int i = cl.TraitsAllowed.Count - 1; i >= 0; i--)
                {
                    foreach (Trait tr in prntForm.traitsList.traitList)
                    {
                        if (tr.TraitTag == cl.TraitsAllowed[i].Tag)
                        {
                            foundOne = true;
                            break;
                        }                        
                    }
                    if (!foundOne)
                    {
                        cl.TraitsAllowed.RemoveAt(i);
                    }
                    else
                    {
                        foundOne = false;
                    }
                }
            }
        }
        private void checkForNewSpells()
        {
            bool foundOne = false;
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                foreach (Spell sp in prntForm.spellsList.spellList)
                {
                    foreach (SpellAllowed sa in cl.SpellsAllowed)
                    {
                        if (sa.Tag == sp.SpellTag)
                        {
                            foundOne = true;
                            break;
                        }
                    }
                    if (!foundOne)
                    {
                        SpellAllowed newSA = new SpellAllowed();
                        newSA.Name = sp.SpellName;
                        newSA.Tag = sp.SpellTag;
                        cl.SpellsAllowed.Add(newSA);
                    }
                    else
                    {
                        foundOne = false;
                    }
                }
            }
        }
        private void checkForDeletedSpells()
        {
            bool foundOne = false;
            foreach (PlayerClass cl in prntForm.playerClassesList.playerClassList)
            {
                for (int i = cl.SpellsAllowed.Count - 1; i >= 0; i--)
                {
                    foreach (Spell sp in prntForm.spellsList.spellList)
                    {
                        if (sp.SpellTag == cl.SpellsAllowed[i].Tag)
                        {
                            foundOne = true;
                            break;
                        }
                    }
                    if (!foundOne)
                    {
                        cl.SpellsAllowed.RemoveAt(i);
                    }
                    else
                    {
                        foundOne = false;
                    }
                }                
            }
        }
        private void refreshListBox()
        {
            lbxPlayerClasses.BeginUpdate();
            lbxPlayerClasses.DataSource = null;
            lbxPlayerClasses.DataSource = prntForm.playerClassesList.playerClassList;
            lbxPlayerClasses.DisplayMember = "PlayerClassName";
            lbxPlayerClasses.EndUpdate();
        }
        private void refreshItemsAllowed()
        {
            cbxItemsAllowed.BeginUpdate();
            cbxItemsAllowed.DataSource = null;
            cbxItemsAllowed.DataSource = prntForm.itemsList.itemsList;
            cbxItemsAllowed.DisplayMember = "ItemName";
            cbxItemsAllowed.EndUpdate();

            //uncheck all first
            for (int i = 0; i < cbxItemsAllowed.Items.Count; i++)
            {
                cbxItemsAllowed.SetItemChecked(i, false);
            }
            //iterate and check ones in list
            for (int i = 0; i < cbxItemsAllowed.Items.Count; i++)
            {
                Item thisItem = (Item)cbxItemsAllowed.Items[i];
                if (prntForm.playerClassesList.playerClassList[selectedLbxIndex].ItemsAllowed.Contains((string)thisItem.ItemResRef))
                {
                    cbxItemsAllowed.SetItemChecked(i, true);
                }
            }
        }
        private void refreshSkillsAllowed()
        {
            /*cbxSkillsAllowed.BeginUpdate();
            cbxSkillsAllowed.DataSource = null;
            cbxSkillsAllowed.DataSource = prntForm.skillsList.skillsList;
            cbxSkillsAllowed.DisplayMember = "SkillName";
            cbxSkillsAllowed.EndUpdate();

            //uncheck all first
            for (int i = 0; i < cbxSkillsAllowed.Items.Count; i++)
            {
                cbxSkillsAllowed.SetItemChecked(i, false);
            }
            //iterate and check ones in list
            for (int i = 0; i < cbxSkillsAllowed.Items.Count; i++)
            {
                Skill thisSkill = (Skill)cbxSkillsAllowed.Items[i];
                if (prntForm.playerClassesList.playerClassList[selectedLbxIndex].SkillsAllowed.Contains((string)thisSkill.SkillTag))
                {
                    cbxSkillsAllowed.SetItemChecked(i, true);
                }
            }*/
        }
        private void fillAllowedSkillList()
        {
            foreach (Skill sk in prntForm.skillsList.skillsList)
            {
                SkillAllowed newSA = new SkillAllowed();
                newSA.Name = sk.SkillName;
                newSA.Tag = sk.SkillTag;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].SkillsAllowed.Add(newSA);
            }
        }
        private void fillAllowedSpellList()
        {
            foreach (Spell sp in prntForm.spellsList.spellList)
            {
                SpellAllowed newSA = new SpellAllowed();
                newSA.Name = sp.SpellName;
                newSA.Tag = sp.SpellTag;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].SpellsAllowed.Add(newSA);
            }
        }
        private void fillAllowedTraitList()
        {
            foreach (Trait tr in prntForm.traitsList.traitList)
            {
                TraitAllowed newTA = new TraitAllowed();
                newTA.Name = tr.TraitName;
                newTA.Tag = tr.TraitTag;
                prntForm.playerClassesList.playerClassList[selectedLbxIndex].TraitsAllowed.Add(newTA);
            }
        }
        private void setupSkillsDataGridView()
        {
            dgvSkillsAllowed.DataSource = prntForm.playerClassesList.playerClassList[selectedLbxIndex].SkillsAllowed;
            dgvSkillsAllowed.AutoGenerateColumns = false;

            DataGridViewColumn column0 = new DataGridViewCheckBoxColumn();
            column0.DataPropertyName = "Allow";
            column0.HeaderText = "Allow";
            column0.Name = "check";
            column0.Width = 40;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "Name";
            columnA.HeaderText = "Name";
            columnA.Name = "name";
            columnA.Width = 120;
            columnA.ReadOnly = true;

            DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
            columnB.DataPropertyName = "PointsPerRank";
            columnB.HeaderText = "Points Per Rank";
            columnB.Name = "pointsPerRank";
            columnB.Width = 60;

            DataGridViewColumn columnC = new DataGridViewTextBoxColumn();
            columnC.DataPropertyName = "MaxRanksAtLevelOne";
            columnC.HeaderText = "Max Ranks At Level One";
            columnC.Name = "maxRanksAtLevelOne";
            columnC.Width = 80;

            DataGridViewColumn columnD = new DataGridViewTextBoxColumn();
            columnD.DataPropertyName = "MaxRanksAtLevelUp";
            columnD.HeaderText = "Max Ranks At Level Up";
            columnD.Name = "maxRanksAtLevelUp";
            columnD.Width = 90;

            dgvSkillsAllowed.Columns.Clear();
            dgvSkillsAllowed.Columns.Add(column0);
            dgvSkillsAllowed.Columns.Add(columnA);
            dgvSkillsAllowed.Columns.Add(columnB);
            dgvSkillsAllowed.Columns.Add(columnC);
            dgvSkillsAllowed.Columns.Add(columnD);
            //dgvSkills.AutoResizeColumns();
        }
        private void setupSpellsDataGridView()
        {
            dgvSpellsAllowed.DataSource = prntForm.playerClassesList.playerClassList[selectedLbxIndex].SpellsAllowed;
            dgvSpellsAllowed.AutoGenerateColumns = false;

            DataGridViewColumn column0 = new DataGridViewCheckBoxColumn();
            column0.DataPropertyName = "Allow";
            column0.HeaderText = "Allow";
            column0.Name = "check";
            column0.Width = 40;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "Name";
            columnA.HeaderText = "Name";
            columnA.Name = "name";
            columnA.Width = 120;
            columnA.ReadOnly = true;

            DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
            columnB.DataPropertyName = "AtWhatLevelIsAvailable";
            columnB.HeaderText = "At What Level Is Available";
            columnB.Name = "atWhatLevelIsAvailable";
            columnB.Width = 60;

            DataGridViewColumn columnC = new DataGridViewCheckBoxColumn();
            columnC.DataPropertyName = "AutomaticallyLearned";
            columnC.HeaderText = "Automatically Learned";
            columnC.Name = "automaticallyLearned";
            columnC.Width = 80;

            DataGridViewColumn columnD = new DataGridViewCheckBoxColumn();
            columnD.DataPropertyName = "NeedsSpecificTrainingToLearn";
            columnD.HeaderText = "Needs Specific Training To Learn";
            columnD.Name = "needsSpecificTrainingToLearn";
            columnD.Width = 90;

            dgvSpellsAllowed.Columns.Clear();
            dgvSpellsAllowed.Columns.Add(column0);
            dgvSpellsAllowed.Columns.Add(columnA);
            dgvSpellsAllowed.Columns.Add(columnB);
            dgvSpellsAllowed.Columns.Add(columnC);
            dgvSpellsAllowed.Columns.Add(columnD);
            //dgvSkills.AutoResizeColumns();
        }
        private void setupTraitsDataGridView()
        {
            dgvTraitsAllowed.DataSource = prntForm.playerClassesList.playerClassList[selectedLbxIndex].TraitsAllowed;
            dgvTraitsAllowed.AutoGenerateColumns = false;

            DataGridViewColumn column0 = new DataGridViewCheckBoxColumn();
            column0.DataPropertyName = "Allow";
            column0.HeaderText = "Allow";
            column0.Name = "check";
            column0.Width = 40;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "Name";
            columnA.HeaderText = "Name";
            columnA.Name = "name";
            columnA.Width = 120;
            columnA.ReadOnly = true;

            DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
            columnB.DataPropertyName = "AtWhatLevelIsAvailable";
            columnB.HeaderText = "At What Level Is Available";
            columnB.Name = "atWhatLevelIsAvailable";
            columnB.Width = 60;

            DataGridViewColumn columnC = new DataGridViewCheckBoxColumn();
            columnC.DataPropertyName = "AutomaticallyLearned";
            columnC.HeaderText = "Automatically Learned";
            columnC.Name = "automaticallyLearned";
            columnC.Width = 80;

            DataGridViewColumn columnD = new DataGridViewCheckBoxColumn();
            columnD.DataPropertyName = "NeedsSpecificTrainingToLearn";
            columnD.HeaderText = "Needs Specific Training To Learn";
            columnD.Name = "needsSpecificTrainingToLearn";
            columnD.Width = 90;

            dgvTraitsAllowed.Columns.Clear();
            dgvTraitsAllowed.Columns.Add(column0);
            dgvTraitsAllowed.Columns.Add(columnA);
            dgvTraitsAllowed.Columns.Add(columnB);
            dgvTraitsAllowed.Columns.Add(columnC);
            dgvTraitsAllowed.Columns.Add(columnD);
            //dgvSkills.AutoResizeColumns();
        }
        #endregion        

        private void btnSort_Click(object sender, EventArgs e)
        {
            prntForm.playerClassesList.playerClassList = prntForm.playerClassesList.playerClassList.OrderBy(o => o.PlayerClassName).ToList();
            refreshListBox();
        }
    }
}
