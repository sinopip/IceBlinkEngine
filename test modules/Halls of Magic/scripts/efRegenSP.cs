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
            object source = sf.GetSourceCreatureObject();
            if (source is PC)
            {
            	if (((PC)source).SP != ((PC)source).SPMax)
            	{
	            	sf.WriteToLog(((PC)source).Name + " regains 6 SP", Color.Blue);
	            	((PC)source).SP = Math.Min(((PC)source).SPMax, ((PC)source).SP + 6);
            	}
                
            }
            else if (source is Creature)
            {
            	if (((Creature)source).SP != ((Creature)source).SPMax)
            	{
	                sf.WriteToLog(((Creature)source).Name + " regains 6 SP", Color.Blue);
	                ((Creature)source).SP = Math.Min(((Creature)source).SPMax, ((Creature)source).SP + 6);
            	}
            }
            
        }
    }
}
