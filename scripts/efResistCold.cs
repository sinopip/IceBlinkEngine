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
            int parm1 = Convert.ToInt32(p1); // parm1 = CurrentDurationInUnits (how many time units have passed)
            int parm2 = Convert.ToInt32(p2); // parm2 = DurationInUnits (how long it lasts)
            // C# code goes here
			
			//object source = sf.GetSourceCreature();
			object source = sf.passParameterScriptObject;
            if (source is PC)
            {
                ((PC)source).DamageTypeResistanceTotalCold += 50;
                if (((PC)source).DamageTypeResistanceTotalCold > 100)
                {
                    (PC)source.DamageTypeResistanceTotalCold = 100;
                }
            }
            else if (source is Creature)
            {
                ((Creature)source).DamageTypeResistanceTotalCold += 50;
                if (((Creature)source).DamageTypeResistanceTotalCold > 100)
                {
                    ((Creature)source).DamageTypeResistanceTotalCold = 100;
                }
            }
            else // don't know who cast this spell
            {
                MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }
        }
    }
}
