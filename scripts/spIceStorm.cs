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
            sp.Name = "Ice Storm";
            sp.TargetType = "any";
            sp.Type = "Damage";
            sp.NbDice = source.ClassLevel;
            sp.Die = 3;
            sp.DiceAdd = +1 * source.ClassLevel;
            sp.BaseDC = 11;
            sp.Save = "Reflex";
            sp.StatMod = "CHA";
            sp.SuccessSaveResistance = 0.5;
            sp.EnergySource = "Cold";
			sp.SpellColor = Color.Blue;
            sp.Description = "is struck and freezes";         
            sf.DoSpell(sp); 			
        }
    }
}
