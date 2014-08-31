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

			Creature source = sf.GetSourceCreatureData();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }

			// * +2 to attack and damage with Strength -> -4 to attack => -2	 to attack final
            if (source is PC)
            {
	            ((PC)source).Strength += 4;
	            ((PC)source).BaseAttBonusAdders -= 4;
            }
            else if (source is Creature)
            {
	            ((Creature)source).Strength += 4;
	            ((Creature)source).BaseAttBonusAdders -= 4;
            }
            
			sf.WriteToLog(source.Name, Color.Blue);
			sf.WriteToLog(" is in Power Attack mode: +2 melee damage, -2 BAB", Color.Silver);
            sf.WriteToLog(Environment.NewLine, Color.Silver);
            sf.WriteToLog(Environment.NewLine, Color.Silver);               
        }
    }
}
