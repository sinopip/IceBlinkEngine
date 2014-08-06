//pcOnScoringHit_FireDamage.cs
//fire damage of XdY+Z (1d4+1 would be X=1, Y=4, Z=1)
//parm1 = (int) number of dice to roll (X).  
//parm2 = (int) number of sides to dice (Y).
//parm3 = (int) adder to total roll (Z).
//parm4 = none
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
            if ((p1 == "none") || (p1 == ""))
            {
                p1 = "0";
            }
            if ((p2 == "none") || (p2 == ""))
            {
                p2 = "0";
            }
            if ((p3 == "none") || (p3 == ""))
            {
                p3 = "0";
            }
            int parm1 = Convert.ToInt32(p1);
            int parm2 = Convert.ToInt32(p2);
            int parm3 = Convert.ToInt32(p3);
            // C# code goes here
            Combat c = sf.frm.currentCombat;
            PC pc = (PC)sf.CombatSource;
            Creature crt = (Creature)sf.CombatTarget;            

            float resist = (float)(1f - ((float)crt.DamageTypeResistanceValueFire / 100f));
            float damage = (parm1 * sf.gm.Random(parm2)) + parm3;
            int fireDam = (int)(damage * resist);
            if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " fireDam = " + fireDam.ToString(), Color.Silver); }

            c.logText(crt.Name, Color.Blue);
            c.logText(" is burned for ", Color.Silver);
            c.logText(fireDam.ToString(), Color.Lime);
            c.logText(" hit points", Color.Silver);
            c.logText(Environment.NewLine, Color.Silver);
            c.logText(Environment.NewLine, Color.Silver);
            crt.HP -= fireDam;
            if (crt.HP <= 0)
            {
                c.logText(crt.Name + " has been killed", Color.Lime);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }
        }
    }
}
