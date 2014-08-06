//gcCheckAttribute.cs - Checks to see if PC has a certain value in an attribute.
//parm1 = (int) index of the PC to check for attribute (1st PC is index = 0), leave blank 
//         or enter -1 to use the currently selected party leader
//parm2 = (string) attribute to check (use all lower case of one of the
//         following three letters: str, dex, con, int, wis, cha) 
//parm3 = (string) compare type ( = , < , > , ! )
//parm4 = (int) value

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
            int parm4 = Convert.ToInt32(p4);            
            sf.gm.returnCheck = sf.CheckAttribute(parm1, p2, p3, parm4);
        }
    }
}
