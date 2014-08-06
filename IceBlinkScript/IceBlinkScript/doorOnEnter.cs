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
            //MessageBox.Show("OnEnter triggered");
            string propTag = (string)sf.passParameterScriptObject;
            Prop prp = sf.gm.currentArea.AreaPropList.getPropByTag(propTag);
            if (prp != null)
            {
                if ((prp.PropLocked) || (prp.PropTrapped))
                {
                    sf.gm.turnLoSBlockingOff = false;
                    sf.frm.doConversationBasedOnObject(propTag);
                    if (sf.gm.turnLoSBlockingOff)
                    {
                        Area ar = sf.gm.currentArea;
                        ar.TileMapList[prp.Location.Y * ar.MapSizeInSquares.Width + prp.Location.X].LoSBlocked = false;
                    }
                    sf.gm.turnLoSBlockingOff = false;
                }
            }
        }
    }
}
