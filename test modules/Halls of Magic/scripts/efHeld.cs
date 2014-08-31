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

			bool effect_ends = false;
			object source = sf.GetSourceCreatureObject();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }	
			
			if (source is PC)
			{
				PC pc = (PC)source;
				sf.WriteToLog(pc.Name, Color.Blue);
				if (parm1 >= parm2)
				{
					effect_ends = true;
					if (pc.HP > 0)
						pc.Status = CharBase.charStatus.Alive;
					else
						pc.Status = CharBase.charStatus.Dead;
				}
				else
					pc.Status = CharBase.charStatus.Held;
			}
			else if (source is Creature)
			{
				Creature crt = (Creature)source;
				sf.WriteToLog(crt.Name, Color.Blue);
				if (parm1 >= parm2)
				{
					effect_ends = true;
					if (crt.HP > 0)
						crt.Status = CharBase.charStatus.Alive;
					else
						crt.Status = CharBase.charStatus.Dead;
				}
				else
					crt.Status = CharBase.charStatus.Held;
			}
			sf.WriteToLog(" is ko, " + parm1 + " out of " + parm2 + " seconds", Color.Black);
			sf.WriteToLog(Environment.NewLine, Color.Black);
			
			if (effect_ends)
			{
				if (source is PC)
					sf.WriteToLog(((PC)source).Name, Color.Blue);
				else if (source is Creature)
					sf.WriteToLog(((Creature)source).Name, Color.Blue); 
					sf.WriteToLog(" is no longer being held", Color.Black);
					sf.WriteToLog(Environment.NewLine, Color.Black);
			}			
        }
    }
}
