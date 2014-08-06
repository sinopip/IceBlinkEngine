//gaGiveItem.cs - Gives an item(s) to the party
//parm1 = (string) item tag
//parm2 = (int) quantity
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
            int parm2 = Convert.ToInt32(p2);
            sf.GiveItem(p1,parm2);
            sf.frm.logText("Party gains an item: ", Color.Yellow);
            sf.frm.logText(sf.gm.module.ModuleItemsList.getItemByTag(p1).ItemName, Color.Lime);
            sf.frm.logText(Environment.NewLine, Color.Silver);
        }
    }
}
