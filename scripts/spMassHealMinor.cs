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
            sp.Name = "Mass Heal Minor";
            sp.TargetType = "allies";
            sp.Type = "Heal";
            sp.NbDice = 0;
            sp.DiceAdd = 10;
			sp.SpellColor = Color.Cyan;
			sp.Description = "heals";
            sf.DoSpell(sp);
			SpecialActionResult heal;
			if (source is PC)
			foreach (PC pc in sf.gm.playerList.PCList)
			{
				heal = new SpecialActionResult();
				heal.ScoreFinal = 10;
				if (pc.Name != source.Name)
					sf.DoHeal(sp, heal, pc);
			}
        }
    }
}
