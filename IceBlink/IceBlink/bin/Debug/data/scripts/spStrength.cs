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
            if (sf.MainMapScriptCall) //the script was called from a main map
            {
                PC source = (PC)sf.MainMapSource;
                PC target = (PC)sf.MainMapTarget;
                Form1 c = sf.frm;
                c.logText("Strength is applied on ", Color.Silver);
                c.logText(target.Name, Color.Blue);
                c.logText(Environment.NewLine, Color.Silver);
                target.AddEffectOnMainMapByTag("strength");
            }
            else //the script was called from a combat map
            {
                if (sf.CombatSource is PC)
                {
                    PC source = (PC)sf.CombatSource;
                    PC target = (PC)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;
                    target.AddEffectByTag("strength");
                }
                else if (sf.CombatSource is Creature)
                {
                    Creature source = (Creature)sf.CombatSource;
                    Creature target = (Creature)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;
                    target.AddEffectByTag("strength");
                }
                else // don't know who cast this spell
                {
                    MessageBox.Show("Invalid script owner, not a Creature of PC");
                    return;
                }
            }
        }
    }
}
