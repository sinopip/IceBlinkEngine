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
            sp.Name = "Confusion";
            sp.Type = "Debuff";
            sp.TargetType = "enemies";
            sp.BaseDC = 11;
            sp.StatMod = "INT";
            sp.Save = "Will";
            sp.NbDice = 1;
            sp.Die = 6;
            sp.DiceAdd = 1;
            sp.SpriteFileName = "effect_on.spt";
            sp.SoundFX = "";
			sp.SpellColor = Color.YellowGreen;
			sp.EffectDescription = " becomes confused...";
			sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("confusion");
			sf.DoSpell(sp);
        }
    }
}
