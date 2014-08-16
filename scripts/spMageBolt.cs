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
            sp.Name = "Mage Bolts";
            sp.TargetType = "enemies";
            sp.Type = "Damage";
            sp.NbDice = 1;
            sp.Die = 4;
            sp.DiceAdd = 1;
            sp.BaseDC = -1; // no save
            sp.EnergySource = "Magic";
			sp.SpellColor = Color.Magenta;
            //sp.Description = "is hit by "+sp.NbDice+" bolts";
			int nb_bolts = source.ClassLevel / 3 + 1;
			sf.DoSpell(sp); 	
			for (int i=0; i < nb_bolts-1; i++)
			{
				sf.PlaySoundFX("buffer.wav");
				sf.DoSpellAction(sp, sf.MainMapScriptCall);
				WriteToLog(Environment.NewLine, Color.Black);
			}
        }
    }
}
