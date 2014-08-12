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
            sp.Name = "Bless";
            sp.TargetType = "allies";
            sp.Type = "Buff";
            sp.NbDice = 0;
            sp.DiceAdd = 5 * source.ClassLevel;
			sp.SpellColor = Color.Yellow;
			sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("bless");
            sp.EffectDescription = "is blessed";
			sp.SpriteFileName = "effect_on.spt";
			sp.SoundFX = "laser.wav";			
			SpecialActionResult bless;			
            sf.DoSpell(sp); 
			foreach (PC pc in sf.gm.playerList.PCList)
			{
				bless = new SpecialActionResult();
				bless.ScoreFinal = sp.DiceAdd;
				if (pc.Name != ((PC)sf.MainMapTarget).Name)
					sf.DoBuff(sp, bless, pc);
			}			
        }
    }
}
