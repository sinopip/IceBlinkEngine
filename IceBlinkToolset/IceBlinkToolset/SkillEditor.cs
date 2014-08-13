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
    public partial class SkillEditor : Form
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;
        private int selectedLbxIndex = 0;

        public SkillEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
            refreshListBox();
        }
        private void refreshListBox()
        {
            lbxSkills.BeginUpdate();
            lbxSkills.DataSource = null;
            lbxSkills.DataSource = prntForm.skillsList.skillsList;
            lbxSkills.DisplayMember = "SkillName";
            lbxSkills.EndUpdate();
        }        
        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            Skill newSkill = new Skill();
            newSkill.passRefs(game, prntForm);
            newSkill.SkillName = "newSkill";
            newSkill.SkillTag = "newSkillTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.skillsList.skillsList.Add(newSkill);
            refreshListBox();
        }
        private void btnRemoveSkill_Click(object sender, EventArgs e)
        {
            if (lbxSkills.Items.Count > 0)
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxSkills.SelectedIndex;
                    //mod.ModuleContainersList.containers.RemoveAt(selectedIndex);
                    prntForm.skillsList.skillsList.RemoveAt(selectedIndex);
                }
                catch { }
                selectedLbxIndex = 0;
                if (lbxSkills.Items.Count > 0)
                {
                    lbxSkills.SelectedIndex = 0;
                }
                refreshListBox();
            }
        }
        private void btnDuplicateSkill_Click(object sender, EventArgs e)
        {
            Skill newCopy = prntForm.skillsList.skillsList[selectedLbxIndex].DeepCopy();
            newCopy.passRefs(game, prntForm);
            newCopy.SkillTag = "newSkillTag_" + prntForm.mod.NextIdNumber.ToString();
            prntForm.skillsList.skillsList.Add(newCopy);
            refreshListBox();
        }
        private void lbxSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((lbxSkills.SelectedIndex >= 0) && (prntForm.skillsList.skillsList != null))
                {
                    selectedLbxIndex = lbxSkills.SelectedIndex;
                    lbxSkills.SelectedIndex = selectedLbxIndex;
                    propertyGrid1.SelectedObject = prntForm.skillsList.skillsList[selectedLbxIndex];
                }
            }
            catch { }
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshListBox();
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
        private void SkillEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkForNewSkills();
            checkForDeletedSkills();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<Skill> sortList = new List<Skill>();
            sortList.Clear();
            foreach (Skill sk in prntForm.skillsList.skillsList)
            {
                sortList.Add(sk);
            }
            sortList = sortList.OrderBy(o => o.SkillName).ToList();
            prntForm.skillsList.skillsList.Clear();
            foreach (Skill sk in sortList)
            {
                prntForm.skillsList.skillsList.Add(sk);
            }
            refreshListBox();
        }
    }
}
