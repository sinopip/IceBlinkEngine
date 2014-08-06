//gcCheckForItem.cs - Checks to see if an item(s) is/are in the party/PC inventory
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

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            int parm2 = Convert.ToInt32(p2);
            sf.gm.returnCheck = sf.CheckForItem(p1, parm2);
        }
    }
}
