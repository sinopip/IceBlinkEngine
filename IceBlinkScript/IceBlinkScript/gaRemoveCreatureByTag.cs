//gaRemoveCreatureByTag.cs - Removes a creature from any area, must use the tag of the placed creature
//parm1 = (string) the tag of the creature after placed on the map (not tag when in creature list)
//parm2 = not used
//parm3 = not used
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
            sf.RemoveCreatureByTag(p1);
        }
    }
}
