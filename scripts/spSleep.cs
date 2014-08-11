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
            sp.Name = "Sleep";
            sp.TargetType = "enemies";
            sp.Type = "Debuff";
            sp.BaseDC = 11;
            sp.Save = "Will";
            sp.StatMod = "CHA";
			sp.SpellColor = Color.WhiteSmoke;
			sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("sleep");
            sp.EffectDescription = "falls asleep";       
            sf.DoSpell(sp); 				
        }
    }
}
