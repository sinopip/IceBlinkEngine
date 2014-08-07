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
    public partial class About : IBForm
    {
        public Game game;
        public Form1 frm;

        public About()
        {
            InitializeComponent();
        }

        public void passRefs(Form1 f, Game g)
        {
            game = g;
            frm = f;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            this.setupAll(game);
            richTextBox1.LoadFile(game.mainDirectory + "\\data\\about.rtf");
        }
    }
}
