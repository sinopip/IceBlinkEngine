using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using IceBlinkCore;


namespace IceBlink
{
    public partial class StartScreen : Form
    {
        private Game game;
        public Form1 frm;

        public StartScreen(Game g, Form1 f)
        {
            game = g;
            frm = f;
            InitializeComponent();
            ibtnExit.setupAll(g);
            ibtnNewGame.setupAll(g);
            ibtnSavedGame.setupAll(g);
            rbtnSize4.Checked = true;
            lblVersion.Text = game.IBVersion;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnSavedGame_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void ibtnNewGame_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void ibtnSavedGame_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void ibtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rbtnSize1_CheckedChanged(object sender, EventArgs e)
        {
            frm.windowSize = 1;
        }
        private void rbtnSize2_CheckedChanged(object sender, EventArgs e)
        {
            frm.windowSize = 2;
        }
        private void rbtnSize3_CheckedChanged(object sender, EventArgs e)
        {
            frm.windowSize = 3;
        }
        private void rbtnSize4_CheckedChanged(object sender, EventArgs e)
        {
            frm.windowSize = 0;
        }       
    }
}
