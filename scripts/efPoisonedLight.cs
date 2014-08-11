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
			
			Creature source = sf.GetActionCreature();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }		
			if (parm1 >= parm2)
			{
					sf.WriteToLog(source.Name, Color.Blue);
					sf.WriteToLog(" is no more affected by light poison", Color.Black);
					sf.WriteToLog(Environment.NewLine, Color.Black);
					return;
			}
            SpellParameters sp = new SpellParameters();
            sp.Name = "Light Poison";
            //sp.TargetType = "any";
            //sp.Type = "Damage";
            sp.NbDice = 1;
            sp.Die = 3;
            sp.DiceAdd = 0;
            sp.BaseDC = -1; // no save
            sp.EnergySource = "Poison";
			sp.SpellColor = Color.Green;
            sp.Description = "is poisoned";
            
            SpecialActionResult result = new SpecialActionResult();
    		result = sf.RollVsDC(sf.GetSourceCreature(),sp);
        	sf.DoDamage(sp, result, sf.GetSourceCreature());  			
        }
    }
}
