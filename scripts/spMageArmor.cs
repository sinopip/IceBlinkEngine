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
            sp.Name = "Mage Armor";
            sp.TargetType = "allies";
            sp.Type = "Buff";
            sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("mageArmor");
            sp.DiceAdd = 20 * source.ClassLevel;
			sp.SpellColor = Color.Magenta;
            sp.Description = " conjures a force shield";
			sp.EffectDescription = "is protected by a force shield";
            sf.DoSpell(sp); 			
        }
    }
}
