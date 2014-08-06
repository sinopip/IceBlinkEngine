//gaStartEncounterByTag.cs - begins an encounter based on the encounter's tag (encounter name in the toolset's encounters list)
//parm1 = (string) encounter's tag
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
            sf.frm.doEncounterBasedOnTag(p1);
        }
    }
}
