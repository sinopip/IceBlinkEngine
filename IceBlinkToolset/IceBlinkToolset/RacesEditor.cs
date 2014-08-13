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
    public partial class RacesEditor : Form
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;
        private int selectedLbxIndex = 0;

        public RacesEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
            refreshListBox();
            refreshClassesAllowed();
            checkForNewTraits();
            checkForDeletedTraits();
            setupTraitsDataGridView();
        }
        
        #region Handlers
        private void btnAddRace_Click(object sender, EventArgs e)
        {
            Race newRace = new Race();
            newRace.passRefs(game);
            newRace.RaceName = "newRace";
            newRace.RaceTag = "newRace_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.racesList.racesList.Add(newRace);
            fillAllowedTraitList();
            refreshListBox();
        }
        private void btnRemoveRace_Click(object sender, EventArgs e)
        {
            if (lbxRaces.Items.Count > 0)
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxRaces.SelectedIndex;
                    //mod.ModuleContainersList.containers.RemoveAt(selectedIndex);
                    prntForm.racesList.racesList.RemoveAt(selectedIndex);
                }
                catch { }
                selectedLbxIndex = 0;
                lbxRaces.SelectedIndex = 0;
                refreshListBox();
            }
        }
        private void btnDuplicateRace_Click(object sender, EventArgs e)
        {
            Race newCopy = prntForm.racesList.racesList[selectedLbxIndex].DeepCopy();
            newCopy.passRefs(game);
            newCopy.RaceTag = "newRaceTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.racesList.racesList.Add(newCopy);
            refreshListBox();
        }
        private void lbxRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbxRaces.SelectedIndex >= 0) && (prntForm.playerClassesList.playerClassList != null))
            {
                selectedLbxIndex = lbxRaces.SelectedIndex;
                lbxRaces.SelectedIndex = selectedLbxIndex;
                propertyGrid1.SelectedObject = prntForm.racesList.racesList[selectedLbxIndex];
                refreshClassesAllowed();
                setupTraitsDataGridView();
            }
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshListBox();
        }
        private void cbxClassesAllowed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lbxRaces_MouseClick(object sender, MouseEventArgs e)
        {
            prntForm.racesList.racesList[selectedLbxIndex].ClassesAllowed.Clear();
            foreach (object itemChecked in cbxClassesAllowed.CheckedItems)
            {
                PlayerClass chkdItem = (PlayerClass)itemChecked;
                prntForm.racesList.racesList[selectedLbxIndex].ClassesAllowed.Add(chkdItem.PlayerClassTag);
            }
        }
        private void RacesEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            prntForm.racesList.racesList[selectedLbxIndex].ClassesAllowed.Clear();
            foreach (object itemChecked in cbxClassesAllowed.CheckedItems)
            {
                PlayerClass chkdItem = (PlayerClass)itemChecked;
                prntForm.racesList.racesList[selectedLbxIndex].ClassesAllowed.Add(chkdItem.PlayerClassTag);
            }
        }
        private void dgvTraitsAllowed_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Incorrect Data Type");
        }
        #endregion

        #region Methods
        private void refreshListBox()
        {
            lbxRaces.BeginUpdate();
            lbxRaces.DataSource = null;
            lbxRaces.DataSource = prntForm.racesList.racesList;
            lbxRaces.DisplayMember = "RaceName";
            lbxRaces.EndUpdate();
        }
        private void refreshClassesAllowed()
        {
            cbxClassesAllowed.BeginUpdate();
            cbxClassesAllowed.DataSource = null;
            cbxClassesAllowed.DataSource = prntForm.playerClassesList.playerClassList;
            cbxClassesAllowed.DisplayMember = "PlayerClassName";
            cbxClassesAllowed.EndUpdate();

            //uncheck all first
            for (int i = 0; i < cbxClassesAllowed.Items.Count; i++)
            {
                cbxClassesAllowed.SetItemChecked(i, false);
            }
            //iterate and check ones in list
            for (int i = 0; i < cbxClassesAllowed.Items.Count; i++)
            {
                PlayerClass thisPlayerClass = (PlayerClass)cbxClassesAllowed.Items[i];
                if (prntForm.racesList.racesList[selectedLbxIndex].ClassesAllowed.Contains((string)thisPlayerClass.PlayerClassTag))
                {
                    cbxClassesAllowed.SetItemChecked(i, true);
                }
            }
        }
        private void checkForNewTraits()
        {
            bool foundOne = false;
            foreach (Race rc in prntForm.racesList.racesList)
            {
                foreach (Trait tr in prntForm.traitsList.traitList)
                {
                    foreach (TraitAllowed ta in rc.TraitsAllowed)
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
                        rc.TraitsAllowed.Add(newTA);
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
            foreach (Race rc in prntForm.racesList.racesList)
            {
                for (int i = rc.TraitsAllowed.Count - 1; i >= 0; i--)
                {
                    foreach (Trait tr in prntForm.traitsList.traitList)
                    {
                        if (tr.TraitTag == rc.TraitsAllowed[i].Tag)
                        {
                            foundOne = true;
                            break;
                        }
                    }
                    if (!foundOne)
                    {
                        rc.TraitsAllowed.RemoveAt(i);
                    }
                    else
                    {
                        foundOne = false;
                    }
                }
            }
        }
        private void fillAllowedTraitList()
        {
            foreach (Trait tr in prntForm.traitsList.traitList)
            {
                TraitAllowed newTA = new TraitAllowed();
                newTA.Name = tr.TraitName;
                newTA.Tag = tr.TraitTag;
                prntForm.racesList.racesList[selectedLbxIndex].TraitsAllowed.Add(newTA);
            }
        }
        private void setupTraitsDataGridView()
        {
            dgvTraitsAllowed.DataSource = prntForm.racesList.racesList[selectedLbxIndex].TraitsAllowed;
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
            prntForm.racesList.racesList = prntForm.racesList.racesList.OrderBy(o => o.RaceName).ToList();
            refreshListBox();            
        }
    }
}
