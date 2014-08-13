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
    /*public partial class TraitSpellEditor : Form
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;
        private int selectedLbxIndex = 0;

        public TraitSpellEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
            refreshListBox();
        }
        private void refreshListBox()
        {
            lbxTraitSpells.BeginUpdate();
            lbxTraitSpells.DataSource = null;
            lbxTraitSpells.DataSource = prntForm.traitSpellsList.traitSpellList;
            lbxTraitSpells.DisplayMember = "TraitSpellName";
            lbxTraitSpells.EndUpdate();
        }        
        private void btnAddTraitSpell_Click(object sender, EventArgs e)
        {
            TraitSpell newTS = new TraitSpell();
            newTS.passRefs(game);
            newTS.TraitSpellName = "newTraitSpell";
            newTS.TraitSpellTag = "newTraitSpellTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.traitSpellsList.traitSpellList.Add(newTS);
            refreshListBox();
        }
        private void btnRemoveTraitSpell_Click(object sender, EventArgs e)
        {
            if (lbxTraitSpells.Items.Count > 0)
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxTraitSpells.SelectedIndex;
                    //mod.ModuleContainersList.containers.RemoveAt(selectedIndex);
                    prntForm.traitSpellsList.traitSpellList.RemoveAt(selectedIndex);
                }
                catch { }
                selectedLbxIndex = 0;
                lbxTraitSpells.SelectedIndex = 0;
                refreshListBox();
            }
        }
        private void btnDuplicateTraitSpell_Click(object sender, EventArgs e)
        {
            TraitSpell newCopy = prntForm.traitSpellsList.traitSpellList[selectedLbxIndex].DeepCopy();
            newCopy.passRefs(game);
            newCopy.TraitSpellTag = "newTraitSpellTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.traitSpellsList.traitSpellList.Add(newCopy);
            refreshListBox();
        }
        private void lbxTraitSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbxTraitSpells.SelectedIndex >= 0) && (prntForm.traitSpellsList.traitSpellList != null))
            {
                selectedLbxIndex = lbxTraitSpells.SelectedIndex;
                lbxTraitSpells.SelectedIndex = selectedLbxIndex;
                propertyGrid1.SelectedObject = prntForm.traitSpellsList.traitSpellList[selectedLbxIndex];
            }
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshListBox();
        }
    }*/
}
