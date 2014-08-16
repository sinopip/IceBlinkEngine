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
            sp.Name = "Resurrection";
            sp.TargetType = "allies";
            sp.Type = "Heal";
            sp.NbDice = 1;
            sp.Die = 6;
            sp.DiceAdd = source.ClassLevel;
			sp.SpellColor = Color.Yellow;
			sp.Description = "heals";
            sp.Effect = new Effect();
            sp.Effect.EffectName = "Special Effect : Revive";
            sf.DoSpell(sp);
        }
    }
}
