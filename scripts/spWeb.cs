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
            sp.Name = "Web";
            sp.TargetType = "enemies";
            sp.Type = "Debuff";
            sp.BaseDC = 11;
            sp.Save = "Reflex";
            sp.StatMod = "INT";
			sp.SpellColor = Color.Gray;
            sp.EffectDescription = "is held by a web";
            sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("web"); 
            sf.DoSpell(sp); 			
        }
    }
}
