using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;

namespace openForgeScript
{
    public partial class PartyConvo : IBForm
    {
        public ScriptFunctions sf;

        public PartyConvo(ScriptFunctions s)
        {
            InitializeComponent();
            sf = s;
            this.setupAll(sf.gm);
            IceBlinkButtonResize.setupAll(sf.gm);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(sf.gm);
            gbPcSelect.setupAll(sf.gm);
            gbPcSelect.Visible = true;
            refreshPcPortraits();
        }

        public void refreshPcPortraits()
        {
            try
            {
                if (sf.gm.playerList.PCList.Count >= 1)
                {
                    this.rbtnPc0.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 2)
                {
                    this.rbtnPc1.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 3)
                {
                    this.rbtnPc2.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 4)
                {
                    this.rbtnPc3.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 5)
                {
                    this.rbtnPc4.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 6)
                {
                    this.rbtnPc5.Visible = true;
                }

                if (sf.gm.playerList.PCList.Count > 0)
                {
                    rbtnPc0.BackgroundImage = (Image)sf.gm.playerList.PCList[0].portraitBitmapS;
                    this.rbtnPc0.Enabled = true;
                }
                if (sf.gm.playerList.PCList.Count > 1)
                {
                    rbtnPc1.BackgroundImage = (Image)sf.gm.playerList.PCList[1].portraitBitmapS;
                    this.rbtnPc1.Enabled = true;
                }
                if (sf.gm.playerList.PCList.Count > 2)
                {
                    rbtnPc2.BackgroundImage = (Image)sf.gm.playerList.PCList[2].portraitBitmapS;
                    this.rbtnPc2.Enabled = true;
                }
                if (sf.gm.playerList.PCList.Count > 3)
                {
                    rbtnPc3.BackgroundImage = (Image)sf.gm.playerList.PCList[3].portraitBitmapS;
                    this.rbtnPc3.Enabled = true;
                }
                if (sf.gm.playerList.PCList.Count > 4)
                {
                    rbtnPc4.BackgroundImage = (Image)sf.gm.playerList.PCList[4].portraitBitmapS;
                    this.rbtnPc4.Enabled = true;
                }
                if (sf.gm.playerList.PCList.Count > 5)
                {
                    rbtnPc5.BackgroundImage = (Image)sf.gm.playerList.PCList[5].portraitBitmapS;
                    this.rbtnPc5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                sf.gm.errorLog(ex.ToString());
            }
        }
        private void rbtnPc0_CheckedChanged(object sender, EventArgs e)
        {
            //sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[0];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc1_CheckedChanged(object sender, EventArgs e)
        {
            //sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[1];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc2_CheckedChanged(object sender, EventArgs e)
        {
            //sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[2];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc3_CheckedChanged(object sender, EventArgs e)
        {
            //sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[3];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc4_CheckedChanged(object sender, EventArgs e)
        {
            //sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[4];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc5_CheckedChanged(object sender, EventArgs e)
        {
            //sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[5];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
