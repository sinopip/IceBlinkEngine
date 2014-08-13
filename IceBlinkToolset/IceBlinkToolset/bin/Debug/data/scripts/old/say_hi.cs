using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            if (sf.gm.playerPosition.X == 5)
            {
               MessageBox.Show(p1 + " OnHeartBeat Triggered, " + p2 + "!");
            }
        }
    }
}
