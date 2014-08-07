//gcCheckIsAlignment.cs - Checks to see if PC is of a certain alignment.
//parm1 = (int) index of the PC to check for class and level (1st PC is index = 0), leave blank 
//         or enter -1 to use the currently selected party leader
//parm2 = (int) Law/Chaos type  (0 = only check for Good/Evil, 1 = Lawful, 2 = Neutral 3 = Chaotic)
//parm3 = (int) Good/Evil type  (0 = only check for Law/Chaos, 1 = Good, 2 = Neutral 3 = Evil)
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
            int parm2 = 0;
            int parm3 = 0;
            if ((p1 == "") || (p1 == "-1"))
            {
                parm1 = sf.gm.selectedPartyLeader;
            }
            else
            {
                parm1 = Convert.ToInt32(p1);
            }
            try
            {
                parm2 = Convert.ToInt32(p2);
            }
            catch
            {
                parm2 = 0;
                IBMessageBox.Show(sf.gm, "The check alignment script parm2 should be a number...please verify");
            }
            try
            {
                parm3 = Convert.ToInt32(p3);                
            }
            catch
            {
                parm3 = 0;
                IBMessageBox.Show(sf.gm, "The check alignment script parm3 should be a number...please verify");
            }
            sf.gm.returnCheck = sf.CheckIsAlignmnet(parm1, parm2, parm3);
        }
    }
}
