//gaAddPartyMember.cs - Adds a pre-made character to the party
//parm1 = (string) PC file name (ex. Drinian.char)
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
            sf.AddCharacterToParty(p1);
        }
    }
}
