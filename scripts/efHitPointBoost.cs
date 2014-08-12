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
			int heal = 2;
			
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }			
			
			if (source is PC) //the script was called from a main map
       		{
				if (((PC)source).HP <= -20)
                {
                    sf.WriteToLog("Can't heal a dead character!", Color.Silver);
                    sf.WriteToLog(Environment.NewLine, Color.Silver);
                    return;
                }
                else
                {
                    ((PC)source).HP += heal;
                    if (((PC)source).HP > ((PC)source).HPMax)
                        ((PC)source).HP = ((PC)source).HPMax;
                    if ((((PC)source).HP > 0) && (((PC)source).Status == CharBase.charStatus.Dead))
                        ((PC)source).Status = CharBase.charStatus.Alive;
                }
            }
            else if (source is Creature)
            {
                ((Creature)source).HP += heal;
                if (((Creature)source).HP > ((Creature)source).HPMax)
                    ((Creature)source).HP = ((Creature)source).HPMax;
            }
                
                sf.WriteToLog(((Creature)source).Name, Color.Blue);
                sf.WriteToLog(" heals ", Color.Black);
                sf.WriteToLog(((Creature)source).Name, Color.LightGray);
                sf.WriteToLog(" for ", Color.Black);
                sf.WriteToLog(heal.ToString(), Color.Lime);
                sf.WriteToLog(" hit points", Color.Black);
                sf.WriteToLog(Environment.NewLine, Color.Black); 
                sf.WriteToLog(Environment.NewLine, Color.Black); 
        }
    }
}
