using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;

namespace IceBlinkToolset
{
    public partial class MergerEditor : Form
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;

        private PlayerClasses classListImport = new PlayerClasses();
        private Races raceListImport = new Races();
        private Skills skillListImport = new Skills();
        private Spells spellListImport = new Spells();
        private Traits traitListImport = new Traits();
        private Effects effectListImport = new Effects();
        private Creatures creatureListImport = new Creatures();
        private Items itemListImport = new Items();
        private Props propListImport = new Props();

        public MergerEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
        }

        #region Handlers
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (lbxImport.SelectedIndex >= 0)
            {
                if (cmbDataType.SelectedIndex == 0) //Class
                {
                    if (!classExists(classListImport.playerClassList[lbxImport.SelectedIndex]))
                    {
                        prntForm.playerClassesList.playerClassList.Add(classListImport.playerClassList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 1) //Race
                {
                    if (!raceExists(raceListImport.racesList[lbxImport.SelectedIndex]))
                    {
                        prntForm.racesList.racesList.Add(raceListImport.racesList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 2) //Skill
                {
                    if (!skillExists(skillListImport.skillsList[lbxImport.SelectedIndex]))
                    {
                        prntForm.skillsList.skillsList.Add(skillListImport.skillsList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 3) //Spell
                {
                    if (!spellExists(spellListImport.spellList[lbxImport.SelectedIndex]))
                    {
                        prntForm.spellsList.spellList.Add(spellListImport.spellList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 4) //Trait
                {
                    if (!traitExists(traitListImport.traitList[lbxImport.SelectedIndex]))
                    {
                        prntForm.traitsList.traitList.Add(traitListImport.traitList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 5) //Effect
                {
                    if (!effectExists(effectListImport.effectsList[lbxImport.SelectedIndex]))
                    {
                        prntForm.effectsList.effectsList.Add(effectListImport.effectsList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 6) //Creature
                {
                    if (!creatureExists(creatureListImport.creatures[lbxImport.SelectedIndex]))
                    {
                        prntForm.creaturesList.creatures.Add(creatureListImport.creatures[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 7) //Item
                {
                    if (!itemExists(itemListImport.itemsList[lbxImport.SelectedIndex]))
                    {
                        prntForm.itemsList.itemsList.Add(itemListImport.itemsList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }
                else if (cmbDataType.SelectedIndex == 8) //Prop
                {
                    if (!propExists(propListImport.propsList[lbxImport.SelectedIndex]))
                    {
                        prntForm.propsList.propsList.Add(propListImport.propsList[lbxImport.SelectedIndex]);
                        refreshImportListBox();
                        refreshMainListBox();
                    }
                }                
            }
        }
        private void btnFolderImport_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath != "")
                {
                    string folder = folderBrowserDialog1.SelectedPath;
                    txtFolderImport.Text = folder;
                    loadAllData(folder);
                }
            }            
        }
        private void loadAllData(string folderpath)
        {
            try
            {
                classListImport = classListImport.loadPlayerClassesFile(folderpath + "\\playerClasses.cls");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import classes file: " + ex.ToString());
            }
            try
            {
                raceListImport = raceListImport.loadRacesFile(folderpath + "\\races.rce");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import races file: " + ex.ToString());
            }
            try
            {
                skillListImport = skillListImport.loadSkillsFile(folderpath + "\\skills.skl");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import skills file: " + ex.ToString());
            }
            try
            {
                spellListImport = spellListImport.loadSpellsFile(folderpath + "\\spells.spls");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import spells file: " + ex.ToString());
            }
            try
            {
                traitListImport = traitListImport.loadTraitsFile(folderpath + "\\traits.trts");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import traits file: " + ex.ToString());
            }
            try
            {
                effectListImport = effectListImport.loadEffectsFile(folderpath + "\\effects.eft");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import effects file: " + ex.ToString());
            }
            try
            {
                creatureListImport = creatureListImport.loadCreaturesFile(folderpath + "\\creatures.crt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import classes file: " + ex.ToString());
            }
            try
            {
                propListImport = propListImport.loadPropsFile(folderpath + "\\props.prp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import props file: " + ex.ToString());
            }
            try
            {
                itemListImport = itemListImport.loadItemsFile(folderpath + "\\items.items");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open import items file: " + ex.ToString());
            }
        }
        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshImportListBox();
            refreshMainListBox();
        }
        private void pgMain_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshImportListBox();
            refreshMainListBox();
        }
        private void pgImport_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshImportListBox();
            refreshMainListBox();
        }
        private void lbxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMain.SelectedIndex >= 0)
            {
                if (cmbDataType.SelectedIndex == 0) //Class
                {
                    pgMain.SelectedObject = prntForm.playerClassesList.playerClassList[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 1) //Race
                {
                    pgMain.SelectedObject = prntForm.racesList.racesList[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 2) //Skill
                {
                    pgMain.SelectedObject = prntForm.skillsList.skillsList[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 3) //Spell
                {
                    pgMain.SelectedObject = prntForm.spellsList.spellList[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 4) //Trait
                {
                    pgMain.SelectedObject = prntForm.traitsList.traitList[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 5) //Effect
                {
                    pgMain.SelectedObject = prntForm.effectsList.effectsList[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 6) //Creature
                {
                    pgMain.SelectedObject = prntForm.creaturesList.creatures[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 7) //Item
                {
                    pgMain.SelectedObject = prntForm.itemsList.itemsList[lbxMain.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 8) //Prop
                {
                    pgMain.SelectedObject = prntForm.propsList.propsList[lbxMain.SelectedIndex];
                }   
            }
        }
        private void lbxImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxImport.SelectedIndex >= 0)
            {
                if (cmbDataType.SelectedIndex == 0) //Class
                {
                    pgImport.SelectedObject = classListImport.playerClassList[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 1) //Race
                {
                    pgImport.SelectedObject = raceListImport.racesList[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 2) //Skill
                {
                    pgImport.SelectedObject = skillListImport.skillsList[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 3) //Spell
                {
                    pgImport.SelectedObject = spellListImport.spellList[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 4) //Trait
                {
                    pgImport.SelectedObject = traitListImport.traitList[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 5) //Effect
                {
                    pgImport.SelectedObject = effectListImport.effectsList[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 6) //Creature
                {
                    pgImport.SelectedObject = creatureListImport.creatures[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 7) //Item
                {
                    pgImport.SelectedObject = itemListImport.itemsList[lbxImport.SelectedIndex];
                }
                else if (cmbDataType.SelectedIndex == 8) //Prop
                {
                    pgImport.SelectedObject = propListImport.propsList[lbxImport.SelectedIndex];
                }   
            }
        }
        #endregion

        #region Methods
        private void refreshMainListBox()
        {
            if (cmbDataType.SelectedIndex == 0) //Class
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.playerClassesList.playerClassList;
                lbxMain.DisplayMember = "PlayerClassName";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 1) //Race
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.racesList.racesList;
                lbxMain.DisplayMember = "RaceName";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 2) //Skill
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.skillsList.skillsList;
                lbxMain.DisplayMember = "SkillName";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 3) //Spell
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.spellsList.spellList;
                lbxMain.DisplayMember = "SpellName";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 4) //Trait
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.traitsList.traitList;
                lbxMain.DisplayMember = "TraitName";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 5) //Effect
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.effectsList.effectsList;
                lbxMain.DisplayMember = "EffectName";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 6) //Creature
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.creaturesList.creatures;
                lbxMain.DisplayMember = "NameWithNotes";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 7) //Item
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.itemsList.itemsList;
                lbxMain.DisplayMember = "ItemName";
                lbxMain.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 8) //Prop
            {
                lbxMain.BeginUpdate();
                lbxMain.DataSource = null;
                lbxMain.DataSource = prntForm.propsList.propsList;
                lbxMain.DisplayMember = "PropNameWithNotes";
                lbxMain.EndUpdate();
            }   
        }
        private void refreshImportListBox()
        {
            if (cmbDataType.SelectedIndex == 0) //Class
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = classListImport.playerClassList;
                lbxImport.DisplayMember = "PlayerClassName";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 1) //Race
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = raceListImport.racesList;
                lbxImport.DisplayMember = "RaceName";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 2) //Skill
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = skillListImport.skillsList;
                lbxImport.DisplayMember = "SkillName";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 3) //Spell
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = spellListImport.spellList;
                lbxImport.DisplayMember = "SpellName";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 4) //Trait
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = traitListImport.traitList;
                lbxImport.DisplayMember = "TraitName";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 5) //Effect
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = effectListImport.effectsList;
                lbxImport.DisplayMember = "EffectName";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 6) //Creature
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = creatureListImport.creatures;
                lbxImport.DisplayMember = "NameWithNotes";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 7) //Item
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = itemListImport.itemsList;
                lbxImport.DisplayMember = "ItemName";
                lbxImport.EndUpdate();
            }
            else if (cmbDataType.SelectedIndex == 8) //Prop
            {
                lbxImport.BeginUpdate();
                lbxImport.DataSource = null;
                lbxImport.DataSource = propListImport.propsList;
                lbxImport.DisplayMember = "PropNameWithNotes";
                lbxImport.EndUpdate();
            }   
        }        
        private bool classExists(PlayerClass itImp)
        {
            foreach (PlayerClass it in prntForm.playerClassesList.playerClassList)
            {
                if (it.PlayerClassTag == itImp.PlayerClassTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool raceExists(Race itImp)
        {
            foreach (Race it in prntForm.racesList.racesList)
            {
                if (it.RaceTag == itImp.RaceTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool skillExists(Skill itImp)
        {
            foreach (Skill it in prntForm.skillsList.skillsList)
            {
                if (it.SkillTag == itImp.SkillTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool spellExists(Spell itImp)
        {
            foreach (Spell it in prntForm.spellsList.spellList)
            {
                if (it.SpellTag == itImp.SpellTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool traitExists(Trait itImp)
        {
            foreach (Trait it in prntForm.traitsList.traitList)
            {
                if (it.TraitTag == itImp.TraitTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool effectExists(Effect itImp)
        {
            foreach (Effect it in prntForm.effectsList.effectsList)
            {
                if (it.EffectTag == itImp.EffectTag)
                {
                    return true;
                }
            }
            return false;
        }
        private bool creatureExists(Creature itImp)
        {
            foreach (Creature it in prntForm.creaturesList.creatures)
            {
                if (it.ResRef == itImp.ResRef)
                {
                    return true;
                }
            }
            return false;
        }
        private bool itemExists(Item itImp)
        {
            foreach (Item it in prntForm.itemsList.itemsList)
            {
                if (it.ItemResRef == itImp.ItemResRef)
                {
                    return true;
                }
            }
            return false;
        }
        private bool propExists(Prop itImp)
        {
            foreach (Prop it in prntForm.propsList.propsList)
            {
                if (it.PropResRef == itImp.PropResRef)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion        
    }
}
