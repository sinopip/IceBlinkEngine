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
                if (target.HP <= -20)
                {
                    c.logText("Can't heal a dead character!", Color.Silver);
                    c.logText(Environment.NewLine, Color.Silver);
                }
                else
                {
                    int heal = 16;
                    sf.frm.logText(source.Name, Color.Blue);
                    sf.frm.logText(" heals ", Color.Silver);
                    sf.frm.logText(target.Name, Color.LightGray);
                    sf.frm.logText(" for ", Color.Silver);
                    sf.frm.logText(heal.ToString(), Color.Lime);
                    sf.frm.logText(" hit points", Color.Silver);
                    sf.frm.logText(Environment.NewLine, Color.Silver);
                    sf.frm.logText(Environment.NewLine, Color.Silver);

                    target.HP += heal;
                    if (target.HP > target.HPMax)
                    {
                        target.HP = target.HPMax;
                    }
                    if ((target.HP > 0) && (target.Status == CharBase.charStatus.Dead))
                    {
                        target.Status = CharBase.charStatus.Alive;
                    }
                }
            }
            else //the script was called from a combat map
            {
                if (sf.CombatSource is PC)
                {
                    PC source = (PC)sf.CombatSource;
                    PC target = (PC)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;
                    if (target.HP <= -20)
                    {
                        c.logText("Can't heal a dead character!", Color.Silver);
                        c.logText(Environment.NewLine, Color.Silver);
                    }
                    else
                    {
                        int heal = 16;
                        c.logText(source.Name, Color.Blue);
                        c.logText(" heals ", Color.Black);
                        c.logText(target.Name, Color.LightGray);
                        c.logText(" for ", Color.Black);
                        c.logText(heal.ToString(), Color.Lime);
                        c.logText(" hit points", Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        target.HP += heal;
                        if (target.HP > target.HPMax)
                        {
                            target.HP = target.HPMax;
                        }
                        if ((target.HP > 0) && (target.Status == CharBase.charStatus.Dead))
                        {
                            target.Status = CharBase.charStatus.Alive;
                        }
                    }
                }
                else if (sf.CombatSource is Creature)
                {
                    Creature source = (Creature)sf.CombatSource;
                    Creature target = (Creature)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;
                    int heal = 16;
                    c.logText(source.Name, Color.Blue);
                    c.logText(" heals ", Color.Black);
                    c.logText(target.Name, Color.LightGray);
                    c.logText(" for ", Color.Black);
                    c.logText(heal.ToString(), Color.Lime);
                    c.logText(" hit points", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    target.HP += heal;
                    if (target.HP > target.HPMax)
                    {
                        target.HP = target.HPMax;
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
