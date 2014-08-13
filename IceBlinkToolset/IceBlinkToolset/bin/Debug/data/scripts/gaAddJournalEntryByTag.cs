//gaAddJournalEntryByTag.cs - Adds an entry to the player's journal
//parm1 = (string) module's categoryTag that the entry belongs to
//parm2 = (string) entryTag of the journal entry
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
            sf.AddJournalEntry(p1, p2);
        }
    }
}
