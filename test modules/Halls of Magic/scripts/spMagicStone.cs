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
            sp.Name = "Magic Stone";
            sp.TargetType = "enemies";
            sp.Type = "Damage";
            sp.NbDice = 1;
            sp.Die = 3;
            sp.DiceAdd = 1;
            sp.BaseDC = -1; // no save
            sp.EnergySource = "Bludgeoning";
			sp.SpellColor = Color.Brown;
            //sp.Description = "is hit by "+sp.NbDice+" stones";
			int nb_stones = Math.Min((source.ClassLevel -1) / 2 + 1, 5);
			sf.DoSpell(sp);
			for (int i=0; i< nb_stones; i++)
			{
				sf.PlaySoundFX("punch.wav");
				sf.DoSpellAction(sp, sf.MainMapScriptCall);	
			}
        }
    }
}
