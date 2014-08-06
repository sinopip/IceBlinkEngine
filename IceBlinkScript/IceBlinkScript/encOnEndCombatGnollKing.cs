//encOnEndCombatGnollKing.cs
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;
using System.Drawing;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            sf.AddJournalEntry("KinstanTS", "kinstanTS3");
            sf.SetGlobalInt("TreeSpiritQuest", 3);
        }
    }
}
