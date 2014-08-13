// UsedForUpdateStats script
// parm1 = CurrentDurationInUnits
// parm2 = DurationInUnits
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
            int parm1 = Convert.ToInt32(p1); // parm1 = CurrentDurationInUnits (how many rounds have passed)
            int parm2 = Convert.ToInt32(p2); // parm2 = DurationInUnits (how long it lasts)
            // C# code goes here
            if (sf.MainMapScriptCall) //the script was called from a main map
            {
                PC source = (PC)sf.MainMapSource;
                Form1 c = sf.frm;
                c.logText(source.Name, Color.Blue);
                c.logText(" is in Power Attack mode: +2 melee damage, -2 BAB", Color.Silver);
                c.logText(Environment.NewLine, Color.Silver);
                c.logText(Environment.NewLine, Color.Silver);
            }
            else //the script was called from a combat map
            {
                if (sf.CombatSource is PC)
                {
                    PC source = (PC)sf.CombatSource;
                    Combat c = sf.frm.currentCombat;
                    c.logText(source.Name, Color.Blue);
                    c.logText(" is in Power Attack mode: +2 melee damage, -2 BAB", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
                else if (sf.CombatSource is Creature)
                {
                    Creature source = (Creature)sf.CombatSource;
                    Combat c = sf.frm.currentCombat;
                    c.logText(source.Name, Color.Blue);
                    c.logText(" is in Power Attack mode: +2 melee damage, -2 BAB", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
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
