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
            sp.Name = "Haste";
            sp.TargetType = "allies";
            sp.Type = "Buff";
			sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("haste");
            sp.NbDice = 0;
            sp.DiceAdd = Math.Min(source.ClassLevel, 6);
			sp.SpellColor = Color.LightBlue;
			sp.EffectDescription = "'s speed increases";			
            sf.DoSpell(sp);			
        }
    }
}
