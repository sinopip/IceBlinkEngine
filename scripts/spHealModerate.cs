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

			
            SpellParameters sp = new SpellParameters();
            sp.Name = "Heal Moderate";
            sp.TargetType = "allies";
            sp.Type = "Heal";
            sp.NbDice = 0;
            sp.DiceAdd = 20;
			sp.SpellColor = Color.Cyan;
 			sp.Description = "heals";
            sf.DoSpell(sp); 			
    }
}
