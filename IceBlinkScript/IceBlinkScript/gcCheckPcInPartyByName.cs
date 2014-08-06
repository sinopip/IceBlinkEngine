//gcCheckPcInPartyByName.cs - Checks to see if a PC's name (in the party) matches a given name.
//parm1 = (string) Name to check against the choosen PC's Name
//parm2 = none
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
            sf.gm.returnCheck = false;
            foreach (PC pc in sf.gm.playerList.PCList)
            {
                if (pc.Name == p1)
                {
                    sf.gm.returnCheck = true;
                }
            }            
        }
    }
}
