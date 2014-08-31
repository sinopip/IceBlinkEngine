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
            sp.Name = "Free Action";
            sp.TargetType = "allies";
            sp.Type = "Buff";
			sp.CountersEffects = "Hold, Slow";
			sp.SpellColor = Color.Blue;
            sf.DoSpell(sp); 	
        }
    }
}
