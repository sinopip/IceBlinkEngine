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
                for (int i = target.EffectsList.effectsList.Count; i > 0; i--)
                {
                    if (target.EffectsList.effectsList[i - 1].EffectCategory == "Hold")
                    {
                        target.EffectsList.effectsList.RemoveAt(i - 1);
                    }
                }
                if (target.HP > 0)
                {
                    target.Status = CharBase.charStatus.Alive;
                }
                else
                {
                    target.Status = CharBase.charStatus.Dead;
                }
                c.logText(target.Name, Color.Blue);
                c.logText(" is no longer being held", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }
            else //the script was called from a combat map
            {
                if (sf.CombatSource is PC)
                {
                    PC source = (PC)sf.CombatSource;
                    PC target = (PC)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;
                    for (int i = target.EffectsList.effectsList.Count; i > 0; i--)
                    {
                        if (target.EffectsList.effectsList[i - 1].EffectCategory == "Hold")
                        {
                            target.EffectsList.effectsList.RemoveAt(i - 1);
                        }
                    }
                    if (target.HP > 0)
                    {
                        target.Status = CharBase.charStatus.Alive;
                    }
                    else
                    {
                        target.Status = CharBase.charStatus.Dead;
                    }
                    c.logText(target.Name, Color.Blue);
                    c.logText(" is no longer being held", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
                else if (sf.CombatSource is Creature)
                {
                    Creature source = (Creature)sf.CombatSource;
                    Creature target = (Creature)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;
                    for (int i = target.EffectsList.effectsList.Count; i > 0; i--)
                    {
                        if (target.EffectsList.effectsList[i - 1].EffectCategory == "Hold")
                        {
                            target.EffectsList.effectsList.RemoveAt(i - 1);
                        }
                    }
                    target.Status = CharBase.charStatus.Alive;
                    c.logText(target.Name, Color.Blue);
                    c.logText(" is no longer being held", Color.Black);
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
