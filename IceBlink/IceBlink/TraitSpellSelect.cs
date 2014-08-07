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
    public partial class TraitSpellSelect : Form
    {
        Combat msc_combat;
        Game msc_game;
        PC msc_pc;
        private int selectedLbxIndex = 0;

        public TraitSpellSelect(Combat c, Game g, PC pc)
        {
            InitializeComponent();
            msc_combat = c;
            msc_game = g;
            msc_pc = pc;
            refreshListBox();
        }

        private void refreshListBox()
        {
            lbxTS.BeginUpdate();
            lbxTS.DataSource = null;
            lbxTS.DataSource = msc_pc.KnownTSList.traitSpellList;
            lbxTS.DisplayMember = "TraitSpellName";
            lbxTS.EndUpdate();
        }

        private void lbxTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show the description
            selectedLbxIndex = lbxTS.SelectedIndex;
            lbxTS.SelectedIndex = selectedLbxIndex;
            rtxtTraitSpellDescription.Text = msc_pc.KnownTSList.traitSpellList[selectedLbxIndex].Description;
        }

        private void btnSelectTS_Click(object sender, EventArgs e)
        {
            int cost = msc_pc.KnownTSList.traitSpellList[selectedLbxIndex].CostSP;            
            // check to see if enough SP
            if (msc_pc.SP >= cost) // if enough SP, then currentTS equals selected and close
            {
                msc_combat.currentTS = msc_pc.KnownTSList.traitSpellList[selectedLbxIndex];
                this.Close();
            }
            else // else message with not enough
            {
                MessageBox.Show("You do not have enough SP at this time");
            }         
        }
    }
}
