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
            sp.Name = "Finger of Death";
            sp.TargetType = "enemies";
            sp.Type = "Damage";
            sp.NbDice = 1 * source.ClassLevel;
            sp.Die = 6;
            sp.DiceAdd = source.ClassLevel;
            sp.BaseDC = 14;
            sp.SuccessSaveResistance = 0.0;
            sp.StatMod = "INT";
            sp.EnergySource = "Magic";
			sp.SpellColor = Color.OrangeRed;
            sp.Description = "";
            sp.Effect = new Effect();
            sp.Effect.EffectName = "Special Effect : Death";
            sf.DoSpell(sp);
        }
    }
}
