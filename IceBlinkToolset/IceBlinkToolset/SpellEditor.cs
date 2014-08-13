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
    public partial class SpellEditor : Form
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;
        private int selectedLbxIndex = 0;

        public SpellEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
            refreshListBox();
        }
        private void refreshListBox()
        {
            lbxSpells.BeginUpdate();
            lbxSpells.DataSource = null;
            lbxSpells.DataSource = prntForm.spellsList.spellList;
            lbxSpells.DisplayMember = "SpellName";
            lbxSpells.EndUpdate();
        }
        private void btnAddSpell_Click(object sender, EventArgs e)
        {
            Spell newTS = new Spell();
            newTS.passRefs(game, prntForm);
            newTS.SpellName = "newSpell";
            newTS.SpellTag = "newSpellTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.spellsList.spellList.Add(newTS);
            refreshListBox();
        }
        private void btnRemoveSpell_Click(object sender, EventArgs e)
        {
            if (lbxSpells.Items.Count > 0)
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxSpells.SelectedIndex;
                    //mod.ModuleContainersList.containers.RemoveAt(selectedIndex);
                    prntForm.spellsList.spellList.RemoveAt(selectedIndex);
                }
                catch { }
                selectedLbxIndex = 0;
                lbxSpells.SelectedIndex = 0;
                refreshListBox();
            }
        }
        private void btnDuplicateSpell_Click(object sender, EventArgs e)
        {
            Spell newCopy = prntForm.spellsList.spellList[selectedLbxIndex].DeepCopy();
            newCopy.passRefs(game, prntForm);
            newCopy.SpellTag = "newSpellTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.spellsList.spellList.Add(newCopy);
            refreshListBox();
        }
        private void lbxSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbxSpells.SelectedIndex >= 0) && (prntForm.spellsList.spellList != null))
            {
                selectedLbxIndex = lbxSpells.SelectedIndex;
                lbxSpells.SelectedIndex = selectedLbxIndex;
                propertyGrid1.SelectedObject = prntForm.spellsList.spellList[selectedLbxIndex];
            }
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshListBox();
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
        private void SpellEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkForNewSpells();
            checkForDeletedSpells();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            prntForm.spellsList.spellList = prntForm.spellsList.spellList.OrderBy(o => o.SpellName).ToList();
            refreshListBox();
        }        
    }
}
