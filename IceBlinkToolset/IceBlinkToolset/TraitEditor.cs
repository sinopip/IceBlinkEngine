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
    public partial class TraitEditor : Form
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;
        private int selectedLbxIndex = 0;

        public TraitEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
            refreshListBox();
        }
        private void refreshListBox()
        {
            lbxTraits.BeginUpdate();
            lbxTraits.DataSource = null;
            lbxTraits.DataSource = prntForm.traitsList.traitList;
            lbxTraits.DisplayMember = "TraitName";
            lbxTraits.EndUpdate();
        }
        private void btnAddTrait_Click(object sender, EventArgs e)
        {
            Trait newTS = new Trait();
            newTS.passRefs(game, prntForm);
            newTS.TraitName = "newTrait";
            newTS.TraitTag = "newTraitTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.traitsList.traitList.Add(newTS);
            refreshListBox();
        }
        private void btnRemoveTrait_Click(object sender, EventArgs e)
        {
            if (lbxTraits.Items.Count > 0)
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxTraits.SelectedIndex;
                    //mod.ModuleContainersList.containers.RemoveAt(selectedIndex);
                    prntForm.traitsList.traitList.RemoveAt(selectedIndex);
                }
                catch { }
                selectedLbxIndex = 0;
                lbxTraits.SelectedIndex = 0;
                refreshListBox();
            }
        }        
        private void btnDuplicateTrait_Click(object sender, EventArgs e)
        {
            Trait newCopy = prntForm.traitsList.traitList[selectedLbxIndex].DeepCopy();
            newCopy.passRefs(game, prntForm);
            newCopy.TraitTag = "newTraitTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.traitsList.traitList.Add(newCopy);
            refreshListBox();
        }
        private void lbxTraits_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((lbxTraits.SelectedIndex >= 0) && (prntForm.traitsList.traitList != null))
            {
                selectedLbxIndex = lbxTraits.SelectedIndex;
                lbxTraits.SelectedIndex = selectedLbxIndex;
                propertyGrid1.SelectedObject = prntForm.traitsList.traitList[selectedLbxIndex];
            }
        } 
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshListBox();
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
        private void TraitEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkForNewTraits();
            checkForDeletedTraits();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            prntForm.traitsList.traitList = prntForm.traitsList.traitList.OrderBy(o => o.TraitName).ToList();
            refreshListBox();
        }       
    }
}
