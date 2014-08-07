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
    public partial class SpellSelect : IBForm
    {
        private Combat msc_combat;
        private Game msc_game;
        private PC msc_pc;

        public SpellSelect(Combat c, Game g, PC pc)
        {
            InitializeComponent();
            msc_combat = c;
            msc_game = g;
            msc_pc = pc;
            IceBlinkButtonResize.setupAll(msc_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(msc_game);
            gbSpellDesc.setupAll(msc_game);
            gbSpellList.setupAll(msc_game);
            this.setupAll(msc_game);
            setupLabels();
            refreshFonts();
            setFormSize();
            createButtons();
        }
        public void refreshFonts()
        {
            gbSpellList.Font = msc_game.module.ModuleTheme.ModuleFont;
            gbSpellDesc.Font = msc_game.module.ModuleTheme.ModuleFont;
            rtxtSpellDescription.Font = msc_game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        private void setupLabels()
        {
            gbSpellList.Text = "Known " + msc_game.module.LabelSpells;
            gbSpellDesc.Text = msc_game.module.LabelSpells + " Description";
        }
        private void setFormSize()
        {
            if (msc_pc.KnownSpellsList.spellList.Count < 8)
            {
                this.Height = 320;
            }
            else if (msc_pc.KnownSpellsList.spellList.Count < 12)
            {
                this.Height = 400;
            }
            else if (msc_pc.KnownSpellsList.spellList.Count < 16)
            {
                this.Height = 480;
            }
            else
            {
                this.Height = 560;
            }
        }
        private void createButtons()
        {
            int index = 0;
            int row = 0;
            foreach (Spell sp in msc_pc.KnownSpellsList.spellList)
            {
                IceBlinkButtonMedium btnNew = new IceBlink.IceBlinkButtonMedium();
                if (index % 2 == 0) //even...place on left
                {
                    btnNew.Location = new System.Drawing.Point(10, row * 45 + 30);
                }
                else //odd...place on right
                {
                    btnNew.Location = new System.Drawing.Point(110, row * 45 + 30);
                    row++;
                }
                btnNew.Size = new System.Drawing.Size(93, 40);
                btnNew.TextIB = sp.SpellName.ToUpper();
                btnNew.Name = sp.SpellTag;
                btnNew.Click += new System.EventHandler(this.btnSelectedSpell_Click);
                btnNew.MouseEnter += new EventHandler(this.btnSelectedSpell_Enter);
                btnNew.setupAll(msc_game);
                this.gbSpellList.Controls.Add(btnNew);
                index++;
            }
        }
        private void btnSelectedSpell_Click(object sender, EventArgs e)
        {
            IceBlinkButtonMedium selectBtn = (IceBlinkButtonMedium)sender;
            Spell selectedSpell = msc_pc.KnownSpellsList.getSpellByTag(selectBtn.Name);
            int cost = selectedSpell.CostSP;
            // check to see if enough SP
            if (msc_pc.SP >= cost) // if enough SP, then currentTS equals selected and close
            {
                msc_combat.currentSpell = selectedSpell;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else // else message with not enough
            {
                IBMessageBox.Show(msc_game, "You do not have enough SP at this time");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
        private void btnSelectedSpell_Enter(object sender, EventArgs e)
        {
            IceBlinkButtonMedium selectBtn = (IceBlinkButtonMedium)sender;
            Spell selectedSpell = msc_pc.KnownSpellsList.getSpellByTag(selectBtn.Name);
            rtxtSpellDescription.Text = msc_game.module.LabelSpells + " Name: " + selectedSpell.SpellName + Environment.NewLine +
                                        "SP Cost: " + selectedSpell.CostSP + Environment.NewLine +
                                        "Target Range: " + selectedSpell.Range + Environment.NewLine +
                                        "Area of Effect (square radius): " + selectedSpell.AoeRadiusOrLength + Environment.NewLine +
                                        Environment.NewLine +
                                        "Description: " + Environment.NewLine +
                                        selectedSpell.Description;
        }
    }
}
