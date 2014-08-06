//gcCheckForItemToggleLights.cs - Checks to see if an item(s) is/are in the party/PC inventory, if not in inventory turn
// the lights off in the area (erases the explored squares list and sets visible distance to 0)
//parm1 = (string) item tag
//parm2 = (int) quantity
//parm3 = (int) visible distance in area when lights are on
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
            bool hasItem = sf.CheckForItem(p1, parm2);
            if (hasItem)
            {
                //the party has the item so set the area's visible to the value set in parm3
                sf.gm.currentArea.VISIBLE_DISTANCE = parm3;
            }
            else
            {
                //the party does not have the item (or quantity) so set area to lights off
                //set visible distance to 0
                sf.gm.currentArea.VISIBLE_DISTANCE = 0;
                //set each square in the area to not visible (black).
                foreach (Tile sqr in sf.gm.currentArea.TileMapList)
                {
                    sqr.visible = false;
                }
            }
        }
    }
}
