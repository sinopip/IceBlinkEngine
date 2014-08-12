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
			
			Creature source = sf.GetActionCreatureData();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }		
			if (parm1 >= parm2)
			{
					sf.WriteToLog(source.Name, Color.Blue);
					sf.WriteToLog(" has no more acid ongoing damage", Color.Black);
					sf.WriteToLog(Environment.NewLine, Color.Black);
					return;
			}
            SpellParameters sp = new SpellParameters();
            sp.Name = "Acid Arrow";
            //sp.TargetType = "any";
            //sp.Type = "Damage";
            sp.NbDice = 2;
            sp.Die = 4;
            sp.DiceAdd = 0;
            sp.BaseDC = -1; // no save
            sp.EnergySource = "Acid";
			sp.SpellColor = Color.Green;
            sp.Description = "is burned from acid";
            
            SpecialActionResult result = new SpecialActionResult();
    		result = sf.RollVsDC(sf.GetSourceCreatureObject(),sp);
        	sf.DoDamage(sp, result, sf.GetSourceCreatureObject());                  
        }
    }
}
