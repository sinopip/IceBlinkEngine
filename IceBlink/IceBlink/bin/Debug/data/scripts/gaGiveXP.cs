//gaGiveXP.cs - Gives XP to the party
//parm1 = (int) amount of XP to the party (will be divided by size of party)
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
            sf.GiveXP(parm1);
            sf.frm.logText("Party gains XP: ", Color.Yellow);
            sf.frm.logText(p1, Color.Lime);
            sf.frm.logText(Environment.NewLine, Color.Silver);
        }
    }
}
