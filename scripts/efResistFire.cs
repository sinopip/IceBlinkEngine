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
			
			//object source = sf.GetSourceCreatureObject();
			object source = sf.passParameterScriptObject;
            if (source is PC)
            {
                ((PC)source).DamageTypeResistanceTotalFire += 50;
                if (((PC)source).DamageTypeResistanceTotalFire > 100)
                {
                    (PC)source.DamageTypeResistanceTotalFire = 100;
                }
            }
            else if (source is Creature)
            {
                ((Creature)source).DamageTypeResistanceTotalFire += 50;
                if (((Creature)source).DamageTypeResistanceTotalFire > 100)
                {
                    ((Creature)source).DamageTypeResistanceTotalFire = 100;
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
