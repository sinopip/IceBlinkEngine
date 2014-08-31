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
			// this works not for allies creatures yet
            
			bool effect_ends = false;
			object source = sf.GetSourceCreatureObject();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }	
			if (source is PC)
			{
				// no effect on PC yet
			}
			else if (source is Creature)
			{
				Creature crt = (Creature)source;
				sf.WriteToLog(crt.Name, Color.Blue);
				if (parm1 >= parm2)
				{
					effect_ends = true;
					crt.OnStartCombatTurn.FilenameOrTag = "crtOnStartCombatTurn.cs";
				}
				else
				{
					int actiontype = sf.gm.Random(3);
					if (actiontype == 1)
					{
						crt.OnStartCombatTurn.FilenameOrTag = "crtPCAllyOnStartCombatTurn.cs";
						//sf.WriteToLog(crt.Name+" attacks its allies!", Color.Black);
					}
					else if (actiontype == 2)
					{
					   crt.OnStartCombatTurn.FilenameOrTag = "";
					   sf.WriteToLog(crt.Name+" looks perplexed.", Color.Black);   
					}
					else
						crt.OnStartCombatTurn.FilenameOrTag = "crtOnStartCombatTurn.cs";
				}
			}
			sf.WriteToLog(" is confused, " + parm1 + " out of " + parm2 + " seconds", Color.Black);
			sf.WriteToLog(Environment.NewLine, Color.Black);
			
			if (effect_ends)
			{
				if (source is PC)
					sf.WriteToLog(((PC)source).Name, Color.Blue);
				else if (source is Creature)
					sf.WriteToLog(((Creature)source).Name, Color.Blue); 
				sf.WriteToLog(" is no longer confused", Color.Black);
				sf.WriteToLog(Environment.NewLine, Color.Black);
			}
        }
    }
}
