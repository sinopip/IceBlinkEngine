using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;
using System.Drawing;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            /*PC pc = (PC)sf.CombatTarget; //this is the PC that is being attacked
            Creature crt = (Creature)sf.CombatSource;
            Combat c = sf.frm.currentCombat;
            if (sf.CheckLocalInt(crt.Tag, "StealthModeOn", "=", 1))
            {
                sf.SetLocalInt(crt.Tag, "StealthModeOn", 0); //turn off stealth mode if Creature is attacking
                c.logText(crt.Name, Color.LightGray);
                c.logText(" exits stealth mode", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }*/
        }
    }
}
