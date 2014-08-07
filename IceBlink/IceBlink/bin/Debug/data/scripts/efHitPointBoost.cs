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
                if (source.HP <= -20)
                {
                    c.logText("Can't heal a dead character!", Color.Silver);
                    c.logText(Environment.NewLine, Color.Silver);
                }
                else
                {
                    int heal = 2;
                    c.logText(source.Name, Color.Blue);
                    c.logText(" heals ", Color.Silver);
                    c.logText(source.Name, Color.LightGray);
                    c.logText(" for ", Color.Silver);
                    c.logText(heal.ToString(), Color.Lime);
                    c.logText(" hit points", Color.Silver);
                    c.logText(Environment.NewLine, Color.Silver);                    
                    source.HP += heal;
                    if (source.HP > source.HPMax)
                    {
                        source.HP = source.HPMax;
                    }
                    if ((source.HP > 0) && (source.Status == CharBase.charStatus.Dead))
                    {
                        source.Status = CharBase.charStatus.Alive;
                    }
                }
            }
            else //the script was called from a combat map
            {
                if (sf.CombatSource is PC)
                {
                    PC source = (PC)sf.CombatSource;
                    Combat c = sf.frm.currentCombat;
                    if (source.HP <= -20)
                    {
                        c.logText("Can't heal a dead character!", Color.Silver);
                        c.logText(Environment.NewLine, Color.Silver);
                    }
                    else
                    {
                        int heal = 2;
                        c.logText(source.Name, Color.Blue);
                        c.logText(" heals ", Color.Black);
                        c.logText(source.Name, Color.LightGray);
                        c.logText(" for ", Color.Black);
                        c.logText(heal.ToString(), Color.Lime);
                        c.logText(" hit points", Color.Black);
                        c.logText(Environment.NewLine, Color.Black); 
                        c.logText(Environment.NewLine, Color.Black); 
                        source.HP += heal;
                        if (source.HP > source.HPMax)
                        {
                            source.HP = source.HPMax;
                        }
                        if ((source.HP > 0) && (source.Status == CharBase.charStatus.Dead))
                        {
                            source.Status = CharBase.charStatus.Alive;
                        }
                    }
                }
                else if (sf.CombatSource is Creature)
                {
                    Creature source = (Creature)sf.CombatSource;
                    Combat c = sf.frm.currentCombat;
                    int heal = 2;
                    c.logText(source.Name, Color.Blue);
                    c.logText(" heals ", Color.Black);
                    c.logText(source.Name, Color.LightGray);
                    c.logText(" for ", Color.Black);
                    c.logText(heal.ToString(), Color.Lime);
                    c.logText(" hit points", Color.Black);
                    c.logText(Environment.NewLine, Color.Black); 
                    c.logText(Environment.NewLine, Color.Black);
                    source.HP += heal;
                    if (source.HP > source.HPMax)
                    {
                        source.HP = source.HPMax;
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
