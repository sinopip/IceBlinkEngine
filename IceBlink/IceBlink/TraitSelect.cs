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
    public partial class TraitSelect : IBForm
    {
        private Combat combat;
        private Game game;
        private PC pc;

        public TraitSelect(Combat c, Game g, PC p)
        {
            InitializeComponent();
            combat = c;
            game = g;
            pc = p;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            gbTraitSpellList.setupAll(game);
            groupBox1.setupAll(game);
            this.setupAll(game);
            refreshFonts();
            setFormSize();
            createButtons();
        }
        public void refreshFonts()
        {
            gbTraitSpellList.Font = game.module.ModuleTheme.ModuleFont;
            groupBox1.Font = game.module.ModuleTheme.ModuleFont;
            rtxtTraitDescription.Font = game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        private void setFormSize()
        {
            if (pc.KnownTraitsList.traitList.Count < 8)
            {
                this.Height = 320;
            }
            else if (pc.KnownTraitsList.traitList.Count < 12)
            {
                this.Height = 400;
            }
            else if (pc.KnownTraitsList.traitList.Count < 16)
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
            foreach (Trait tr in pc.KnownTraitsList.traitList)
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
                btnNew.TextIB = tr.TraitName.ToUpper();
                btnNew.Name = tr.TraitTag;
                btnNew.Click += new System.EventHandler(this.btnSelectedSpell_Click);
                btnNew.MouseEnter += new EventHandler(this.btnSelectedSpell_Enter);
                btnNew.setupAll(game);
                this.gbTraitSpellList.Controls.Add(btnNew);
                index++;
            }
        }
        private void btnSelectedSpell_Click(object sender, EventArgs e)
        {
            IceBlinkButtonMedium selectBtn = (IceBlinkButtonMedium)sender;
            Trait selectedTrait = pc.KnownTraitsList.getTraitByTag(selectBtn.Name);
            int cost = selectedTrait.CostSP;
            // check to see if enough SP
            if (pc.SP >= cost) // if enough SP, then currentTS equals selected and close
            {
                combat.currentTrait = selectedTrait;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else // else message with not enough
            {
                IBMessageBox.Show(game, "You do not have enough SP at this time");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
        private void btnSelectedSpell_Enter(object sender, EventArgs e)
        {
            IceBlinkButtonMedium selectBtn = (IceBlinkButtonMedium)sender;
            Trait selectedTrait = pc.KnownTraitsList.getTraitByTag(selectBtn.Name);
            rtxtTraitDescription.Text = "Trait Name: " + selectedTrait.TraitName + Environment.NewLine +
                                        "SP Cost: " + selectedTrait.CostSP + Environment.NewLine +
                                        "Target Range: " + selectedTrait.Range + Environment.NewLine +
                                        "Area of Effect (square radius): " + selectedTrait.AoeRadiusOrLength + Environment.NewLine +
                                        Environment.NewLine +
                                        "Description: " + Environment.NewLine +
                                        selectedTrait.Description;
        }
    }
}
