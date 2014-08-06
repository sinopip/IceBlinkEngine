//gaGiveGold.cs - Gives gold to the party
//parm1 = (int) amount of gold to give to the party
//parm2 = none
//parm3 = none
//parm4 = none
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;
using System.Drawing;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            int parm1 = Convert.ToInt32(p1);
            sf.GiveFunds(parm1);
            sf.frm.logText("Party gains gold: ", Color.Yellow);
            sf.frm.logText(p1, Color.Lime);
            sf.frm.logText(Environment.NewLine, Color.Silver);
        }
    }
}
