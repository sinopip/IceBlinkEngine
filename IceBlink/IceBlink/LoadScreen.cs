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
    public partial class LoadScreen : Form
    {
        private Game game;
        private Form1 prntForm;

        public LoadScreen(Game g, Form1 frm)
        {
            InitializeComponent();
            game = g;
            prntForm = frm;
        }
        public void SetupScreenSize()
        {
            this.Width = BackgroundImage.Width;
            this.Height = BackgroundImage.Height;
        }
    }
}
