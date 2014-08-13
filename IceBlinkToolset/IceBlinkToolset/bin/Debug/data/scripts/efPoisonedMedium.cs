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
            int parm1 = Convert.ToInt32(p1); // parm1 = CurrentDurationInUnits (how many time units have passed)
            int parm2 = Convert.ToInt32(p2); // parm2 = DurationInUnits (how long it lasts)
            // C# code goes here
            if (sf.MainMapScriptCall) //the script was called from a main map
            {
                PC source = (PC)sf.MainMapSource;
                Form1 c = sf.frm;
                float resist = (float)(1f - ((float)source.DamageTypeResistanceTotalPoison / 100f));
                float damage = 1 * sf.gm.Random(6);
                int poisonDam = (int)(damage * resist);
                if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " poisonDam = " + poisonDam.ToString(), Color.Silver); }
                c.logText(source.Name, Color.Blue);
                c.logText(" is poisoned for ", Color.Silver);
                c.logText(poisonDam.ToString(), Color.Lime);
                c.logText(" hit points", Color.Silver);
                c.logText(Environment.NewLine, Color.Silver);
                c.logText(Environment.NewLine, Color.Silver);
                source.HP -= poisonDam;
                if (source.HP <= 0)
                {
                    c.logText(source.Name + " has been killed!", Color.Red);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    source.Status = PC.charStatus.Dead;
                }                
            }
            else //the script was called from a combat map
            {
                if (sf.CombatSource is PC)
                {
                    PC source = (PC)sf.CombatSource;
                    Combat c = sf.frm.currentCombat;
                    float resist = (float)(1f - ((float)source.DamageTypeResistanceTotalPoison / 100f));
                    float damage = 1 * sf.gm.Random(6);
                    int poisonDam = (int)(damage * resist);
                    if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " poisonDam = " + poisonDam.ToString(), Color.Silver); }
                    c.logText(source.Name, Color.Blue);
                    c.logText(" is poisoned for ", Color.Silver);
                    c.logText(poisonDam.ToString(), Color.Lime);
                    c.logText(" hit points", Color.Silver);
                    c.logText(Environment.NewLine, Color.Silver);
                    c.logText(Environment.NewLine, Color.Silver);
                    source.HP -= poisonDam;
                    if (source.HP <= 0)
                    {
                        c.logText(source.Name + " has been killed!", Color.Red);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        source.Status = PC.charStatus.Dead;
                    }
                }
                else if (sf.CombatSource is Creature)
                {
                    Creature source = (Creature)sf.CombatSource;
                    Combat c = sf.frm.currentCombat;
                    float resist = (float)(1f - ((float)source.DamageTypeResistanceValuePoison / 100f));
                    float damage = 1 * sf.gm.Random(6);
                    int poisonDam = (int)(damage * resist);
                    if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " poisonDam = " + poisonDam.ToString(), Color.Silver); }
                    c.logText(source.Name, Color.Blue);
                    c.logText(" is poisoned for ", Color.Silver);
                    c.logText(poisonDam.ToString(), Color.Lime);
                    c.logText(" hit points", Color.Silver);
                    c.logText(Environment.NewLine, Color.Silver);
                    c.logText(Environment.NewLine, Color.Silver);
                    source.HP -= poisonDam;
                    if (source.HP <= 0)
                    {
                        c.logText(source.Name + " has been killed", Color.Lime);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                    }
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
