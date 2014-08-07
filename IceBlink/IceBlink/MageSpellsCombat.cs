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
    public partial class MageSpellsCombat : Form
    {
        Combat msc_combat;
        Game msc_game;
        PC msc_pc;

        public MageSpellsCombat(Combat c, Game g, PC pc)
        {
            InitializeComponent();
            msc_combat = c;
            msc_game = g;
            msc_pc = pc;
            /*if (pc.ClassLevel < 5)
            {
                gbMageSpellsL3.Enabled = false;
            }
            if (pc.ClassLevel < 3)
            {
                gbMageSpellsL2.Enabled = false;
            }*/
        }
        
        private void btnMageBolt_Click(object sender, EventArgs e)
        {
            if (msc_pc.SP >= 5)
            {
                msc_combat.currentSpell = MageSpells.mageSpellList.MageBolt;
                this.Close();
            }
            else
                MessageBox.Show("You currently lack spell points for this spell");
        }
        private void btnMageBolt_MouseEnter(object sender, EventArgs e)
        {
            rtxtTraitSpellDescription.Text = "A magic missle launches from the casters side and automatically"
                                        + "hits a target for 1d4+1 points of damage";
        }
        private void btnFireball_Click(object sender, EventArgs e)
        {
            if (msc_pc.SP >= 10)
            {
                msc_combat.currentSpell = MageSpells.mageSpellList.Fireball;
                this.Close();
            }
            else
                MessageBox.Show("You currently lack spell points for this spell");
        }        
        private void btnFireball_MouseEnter(object sender, EventArgs e)
        {
            rtxtTraitSpellDescription.Text = "A fireball launches from the casters hands and automatically"
                                        + "hits all targets in the area of effect for 5d6 points of damage";
        }
        private void btnMinorHeal_Click(object sender, EventArgs e)
        {
            if (msc_pc.SP >= 5)
            {
                msc_combat.currentSpell = MageSpells.mageSpellList.MinorHealing;
                this.Close();
            }
            else
                MessageBox.Show("You currently lack spell points for this spell");
        }
        private void btnMinorHeal_MouseEnter(object sender, EventArgs e)
        {
            rtxtTraitSpellDescription.Text = "The caster heals himself or another party member for 10 hitpoints";
        }
        private void btnIceStorm_Click(object sender, EventArgs e)
        {
            if (msc_pc.SP >= 7)
            {
                msc_combat.currentSpell = MageSpells.mageSpellList.IceStorm;
                this.Close();
            }
            else
                MessageBox.Show("You currently lack spell points for this spell");
        }
        private void btnIceStorm_MouseEnter(object sender, EventArgs e)
        {
            rtxtTraitSpellDescription.Text = "An ice storm launches from the casters hands and automatically"
                                        + "hits all targets in the area of effect for 2d6 points of damage";
        }
    }
}
