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
            //MessageBox.Show("entered avoidAoO script");
            Combat c = sf.frm.currentCombat;
            if (sf.CombatTarget is PC)
            {
                //c.logText("CombatTarget is PC", Color.Black);
                PC pc = (PC)sf.CombatTarget;
                if (sf.CheckLocalInt(pc.Tag, "StealthModeOn", "=", 1))
                {                    
                    sf.DrawCombatFloatyTextOverSquare("Avoids AoO due to Stealth", pc.CombatLocation.X, pc.CombatLocation.Y, 40, -20, 25, Color.Red, Color.Black);
                    c.logText(pc.Name, Color.Blue);
                    c.logText(" avoids Attack of Opportunity due to Stealth", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    sf.returnScriptObject = true; //avoid Attack of Opportunity
                    return;
                }
            }
            else if (sf.CombatTarget is Creature)
            {
                //c.logText("CombatTarget is Creature", Color.Black);
                Creature crt = (Creature)sf.CombatTarget; //this is the creature that is being attacked
                if (sf.CheckLocalInt(crt.Tag, "StealthModeOn", "=", 1))
                {
                    sf.DrawCombatFloatyTextOverSquare("Avoids AoO due to Stealth", crt.CombatLocation.X, crt.CombatLocation.Y, 40, -20, 25, Color.Red, Color.Black);
                    c.logText(crt.Name, Color.LightGray);
                    c.logText(" avoids Attack of Opportunity due to Stealth", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    sf.returnScriptObject = true; //avoid Attack of Opportunity
                    return;
                }
            }          
            sf.returnScriptObject = false; //failed to avoid Attack of Opportunity
        }
    }
}
