//dsAdventureMapConvoLog.cs
//p1 = NPC node conversation text
//p2 = NPC name
//p3 = PC selected response node text
//p4 = PC name that spoke this node
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
		sf.frm.logText(p2 + ": ", Color.Yellow);
		sf.frm.logText(p1, Color.Silver);
		sf.frm.logText(Environment.NewLine, Color.Silver);
		sf.frm.logText(p4 + ": ", Color.DodgerBlue);
		sf.frm.logText(p3, Color.Silver);
		sf.frm.logText(Environment.NewLine, Color.Silver);
		//sf.frm.logText(Environment.NewLine, Color.Silver);
        }
    }
}
