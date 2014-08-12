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
            // C# code goes here
			
            Creature source = sf.GetActionCreature();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }                           
 
            SpellParameters sp = new SpellParameters();
            sp.Name = "Acid Arrow";
            sp.TargetType = "any";
            sp.Type = "Damage";
            sp.NbDice = 2;
            sp.Die = 4;
            sp.DiceAdd = 0;
            sp.BaseDC = -1; // no save
            sp.EnergySource = "Acid";
			sp.SpellColor = Color.Green;
            sp.Description = "is burned";
            sf.DoSpell(sp); 
			// * apply ongoing effect
			SpecialActionResult acid = new SpecialActionResult();
			acid.ScoreFinal = Math.Min(source.ClassLevel / 3, 6);
			sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("acidArrow");
			sf.DoBuff(sp, acid, sf.CombatTarget);
        }
    }
}
