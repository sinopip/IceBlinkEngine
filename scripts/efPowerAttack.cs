// UsedForUpdateStats script
// parm1 = CurrentDurationInUnits
// parm2 = DurationInUnits
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using IceBlinkCore;
using IceBlink;


namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            int parm1 = Convert.ToInt32(p1); // parm1 = CurrentDurationInUnits (how many rounds have passed)
            int parm2 = Convert.ToInt32(p2); // parm2 = DurationInUnits (how long it lasts)
            // C# code goes here

			Creature source = sf.GetSourceCreature();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }
			
			sf.WriteToLog(source.Name, Color.Blue);
			sf.WriteToLog(" is in Power Attack mode: +2 melee damage, -2 BAB", Color.Silver);
            sf.WriteToLog(Environment.NewLine, Color.Silver);
            sf.WriteToLog(Environment.NewLine, Color.Silver);               
        }
    }
}
