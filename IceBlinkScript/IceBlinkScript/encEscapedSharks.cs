//encOnFleeCombat
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
            //int roundNumber = (int)sf.passParameterScriptObject; //passing in current number of rounds at the time that "Run Away" was pressed
            Combat c = sf.frm.currentCombat;
            Encounter e = sf.gm.currentEncounter;
            IBMessageBox.Show(sf.gm, "You made it! You have escaped from the sharks...Frustrated, they swim away.");
            e.EncounterCreatureList.creatures.Clear();
            c.Close();
        }
    }
}
