//gcCheckIsClassLevel.cs - Checks to see if PC is a certain class and has enough levels in that class.
//parm1 = (int) index of the PC to check for class and level (1st PC is index = 0), leave blank 
//         or enter -1 to use the currently selected party leader
//parm2 = (string) tag of the class to check (ex. fighter)
//parm3 = (int) level to check if PC is equal to or greater than
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
            int parm1 = 0;
            if ((p1 == "") || (p1 == "-1"))
            {
                parm1 = sf.gm.selectedPartyLeader;
            }
            else
            {
                parm1 = Convert.ToInt32(p1);
            }
            int parm3 = Convert.ToInt32(p3);
            sf.gm.returnCheck = sf.CheckIsClassLevel(parm1, p2, parm3);
        }
    }
}
