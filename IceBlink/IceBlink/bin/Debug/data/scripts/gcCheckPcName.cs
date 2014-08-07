//gcCheckPcName.cs - Checks to see if a PC's Name matches a given name.
//parm1 = (int) index of the PC to check for Name (1st PC is index = 0), leave blank 
//         or enter -1 to use the currently selectedPartyLeader
//parm2 = (string) Name to check against the choosen PC's Name
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
            int parm1 = 0;
            if ((p1 == "") || (p1 == "-1"))
            {
                parm1 = sf.gm.selectedPartyLeader;
            }
            else
            {
                parm1 = Convert.ToInt32(p1);
            }
            if (sf.gm.playerList.PCList[parm1].Name == p2)
            {
                sf.gm.returnCheck = true;
            }
            else
            {
                sf.gm.returnCheck = false;
            }
        }
    }
}
