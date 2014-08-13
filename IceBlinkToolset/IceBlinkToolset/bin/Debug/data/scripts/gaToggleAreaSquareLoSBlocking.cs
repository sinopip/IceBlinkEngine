//gaToggleSquareLoSBlocking.cs - Set the selected square's LoSBlocking to true or false
//parm1 = (int) square's grid X location
//parm2 = (int) square's grid Y location
//parm3 = (bool) true = turn on LoSBlocking, false = turn off LoSBlocking
//parm4 = not used
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
            int x = Convert.ToInt32(p1);
            int y = Convert.ToInt32(p2);
            bool parm3 = Convert.ToBoolean(p3);

            Area ar = sf.gm.currentArea;
            ar.TileMapList[y * ar.MapSizeInSquares.Width + x].LoSBlocked = parm3;
        }
    }
}
