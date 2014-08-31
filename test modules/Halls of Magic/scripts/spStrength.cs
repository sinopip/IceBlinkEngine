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
			
            Creature source = sf.GetActionCreatureData();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }                           
 
            SpellParameters sp = new SpellParameters();
            sp.Name = "Strength";
            sp.TargetType = "allies";
            sp.Type = "Buff";
            sp.NbDice = 0;
            sp.DiceAdd = 5 * source.ClassLevel;
			sp.SpellColor = Color.Brown;
			sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("strength");
            sp.EffectDescription = "becomes stronger";       
            sf.DoSpell(sp); 		
        }
    }
}
