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
    public partial class SkillSelect : IBForm
    {
        private Combat msc_combat;
        private Game msc_game;
        private PC msc_pc;

        public SkillSelect(Combat c, Game g, PC pc)
        {
            InitializeComponent();
            msc_combat = c;
            msc_game = g;
            msc_pc = pc;
            IceBlinkButtonResize.setupAll(msc_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(msc_game);
            gbSkillDesc.setupAll(msc_game);
            gbSpellList.setupAll(msc_game);
            this.setupAll(msc_game);
            refreshFonts();
            setFormSize();
            createButtons();
        }
        public void refreshFonts()
        {
            gbSpellList.Font = msc_game.module.ModuleTheme.ModuleFont;
            gbSkillDesc.Font = msc_game.module.ModuleTheme.ModuleFont;
            rtxtSkillDescription.Font = msc_game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
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
            foreach (Skill sk in msc_pc.KnownSkillsList.skillsList)
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
                btnNew.TextIB = sk.SkillName.ToUpper();
                btnNew.Name = sk.SkillTag;
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
            Skill selectedSkill = msc_pc.KnownSkillsList.getSkillByTag(selectBtn.Name);
            msc_combat.currentSkill = selectedSkill;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void btnSelectedSpell_Enter(object sender, EventArgs e)
        {
            IceBlinkButtonMedium selectBtn = (IceBlinkButtonMedium)sender;
            Skill selectedSkill = msc_pc.KnownSkillsList.getSkillByTag(selectBtn.Name);
            rtxtSkillDescription.Text = selectedSkill.Description;
        }
    }
}
