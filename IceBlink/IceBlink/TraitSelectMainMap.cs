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
    public partial class TraitSelectMainMap : IBForm
    {
        private Form1 frm;
        private Game game;
        private PC pc;

        public TraitSelectMainMap(Form1 f, Game g, PC p)
        {
            InitializeComponent();
            frm = f;
            game = g;
            pc = p;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            gbTraitList.setupAll(game);
            gbPcSelect.setupAll(game);
            gbPcSelect.Visible = false;
            btnSelectMapPoint.setupAll(game);
            gbTraitDesc.setupAll(game);
            this.setupAll(game);
            refreshFonts();
            setFormSize();
            createButtons();
            refreshPcPortraits();
        }
        public void refreshFonts()
        {
            gbTraitList.Font = game.module.ModuleTheme.ModuleFont;
            gbTraitDesc.Font = game.module.ModuleTheme.ModuleFont;
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
                if ((tr.UseableInSituation == UsableInSituation.Always) || (tr.UseableInSituation == UsableInSituation.OutOfCombat))
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
                    this.gbTraitList.Controls.Add(btnNew);
                    index++;
                }
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
                frm.currentTrait = selectedTrait;
                gbTraitDesc.Visible = false;
                gbTraitList.Visible = false;
                gbPcSelect.Visible = true;
                if (selectedTrait.TargetIsSelf)
                {
                    frm.sf.MainMapSource = pc;
                    frm.sf.MainMapTarget = pc;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                //combat.currentTrait = selectedTrait;
                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
        public void refreshPcPortraits()
        {
            try
            {
                if (game.playerList.PCList.Count >= 1)
                {
                    this.rbtnPc0.Visible = true;
                }
                if (game.playerList.PCList.Count >= 2)
                {
                    this.rbtnPc1.Visible = true;
                }
                if (game.playerList.PCList.Count >= 3)
                {
                    this.rbtnPc2.Visible = true;
                }
                if (game.playerList.PCList.Count >= 4)
                {
                    this.rbtnPc3.Visible = true;
                }
                if (game.playerList.PCList.Count >= 5)
                {
                    this.rbtnPc4.Visible = true;
                }
                if (game.playerList.PCList.Count >= 6)
                {
                    this.rbtnPc5.Visible = true;
                }

                if (game.playerList.PCList.Count > 0)
                {
                    rbtnPc0.BackgroundImage = (Image)game.playerList.PCList[0].portraitBitmapS;
                    this.rbtnPc0.Enabled = true;
                }
                if (game.playerList.PCList.Count > 1)
                {
                    rbtnPc1.BackgroundImage = (Image)game.playerList.PCList[1].portraitBitmapS;
                    this.rbtnPc1.Enabled = true;
                }
                if (game.playerList.PCList.Count > 2)
                {
                    rbtnPc2.BackgroundImage = (Image)game.playerList.PCList[2].portraitBitmapS;
                    this.rbtnPc2.Enabled = true;
                }
                if (game.playerList.PCList.Count > 3)
                {
                    rbtnPc3.BackgroundImage = (Image)game.playerList.PCList[3].portraitBitmapS;
                    this.rbtnPc3.Enabled = true;
                }
                if (game.playerList.PCList.Count > 4)
                {
                    rbtnPc4.BackgroundImage = (Image)game.playerList.PCList[4].portraitBitmapS;
                    this.rbtnPc4.Enabled = true;
                }
                if (game.playerList.PCList.Count > 5)
                {
                    rbtnPc5.BackgroundImage = (Image)game.playerList.PCList[5].portraitBitmapS;
                    this.rbtnPc5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
            }
        }
        private void rbtnPc0_CheckedChanged(object sender, EventArgs e)
        {
            frm.sf.MainMapSource = pc;
            frm.sf.MainMapTarget = game.playerList.PCList[0];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc1_CheckedChanged(object sender, EventArgs e)
        {
            frm.sf.MainMapSource = pc;
            frm.sf.MainMapTarget = game.playerList.PCList[1];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc2_CheckedChanged(object sender, EventArgs e)
        {
            frm.sf.MainMapSource = pc;
            frm.sf.MainMapTarget = game.playerList.PCList[2];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc3_CheckedChanged(object sender, EventArgs e)
        {
            frm.sf.MainMapSource = pc;
            frm.sf.MainMapTarget = game.playerList.PCList[3];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc4_CheckedChanged(object sender, EventArgs e)
        {
            frm.sf.MainMapSource = pc;
            frm.sf.MainMapTarget = game.playerList.PCList[4];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc5_CheckedChanged(object sender, EventArgs e)
        {
            frm.sf.MainMapSource = pc;
            frm.sf.MainMapTarget = game.playerList.PCList[5];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void btnSelectMapPoint_Click(object sender, EventArgs e)
        {

        }
    }
}
