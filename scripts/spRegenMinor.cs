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
            sp.Name = "Minor Regeneration";
            sp.TargetType = "allies";
            sp.Type = "Buff";
			sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("regenMinor");
			sp.SpellColor = Color.Silver;
			sp.EffectDescription = "begins to regenerate";			
            sf.DoSpell(sp);					
        }
    }
}
