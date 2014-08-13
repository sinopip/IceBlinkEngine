//gaAddJournalEntryByIndex.cs - Adds an entry to the player's journal
//parm1 = (string) module's categoryTag that the entry belongs to
//parm2 = (int) index of the journal entry from the category's list of entries
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
            int parm2 = Convert.ToInt32(p2);
            sf.AddJournalEntry(p1, parm2);
        }
    }
}
