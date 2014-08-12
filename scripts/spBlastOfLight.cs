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
            sp.Name = "Blast of Light";
            sp.TargetType = "enemies";
            sp.Type = "Damage";
            sp.NbDice = 2;
            sp.Die = 6;
            sp.DiceAdd = source.ClassLevel / 2;
            sp.BaseDC = -1;
            //sp.Save = "Reflex";
            //sp.StatMod = "WIS";
            //sp.SuccessSaveResistance = 0.5;
            sp.EnergySource = "Light";
			sp.SpellColor = Color.Yellow;
            sp.Description = "is sunburned";
            sf.DoSpell(sp); 
			
        }
    }
}
