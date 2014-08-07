//gaTransitionPartyToMapLocation.cs - Jump the party to any adventure map and location (make sure the location is valid)
//parm1 = (string) area name (as seen in area list)
//parm2 = (int) X coordinate
//parm3 = (int) Y coordinate
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
            int parm3 = Convert.ToInt32(p3);
            if (p1 == sf.gm.currentArea.AreaFileName)
            {
                sf.gm.playerPosition.X = parm2;
                sf.gm.playerPosition.Y = parm3;
            }
            else
            {
                sf.frm.doTransitionBasedOnAreaLocation(p1, parm2, parm3);
            }
        }
    }
}
