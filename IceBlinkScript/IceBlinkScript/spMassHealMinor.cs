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
                foreach (PC pc in sf.gm.playerList.PCList)
                {
                    if (pc.HP <= -20)
                    {
                        c.logText("Can't heal a dead character!", Color.Silver);
                        c.logText(Environment.NewLine, Color.Silver);
                    }
                    else
                    {
                        int heal = 8;
                        c.logText(source.Name, Color.Blue);
                        c.logText(" heals ", Color.Silver);
                        c.logText(pc.Name, Color.LightGray);
                        c.logText(" for ", Color.Silver);
                        c.logText(heal.ToString(), Color.Lime);
                        c.logText(" hit points", Color.Silver);
                        c.logText(Environment.NewLine, Color.Silver);
                        //c.logText(Environment.NewLine, Color.Silver);
                        pc.HP += heal;
                        if (pc.HP > pc.HPMax)
                        {
                            pc.HP = pc.HPMax;
                        }
                        if ((pc.HP > 0) && (pc.Status == CharBase.charStatus.Dead))
                        {
                            pc.Status = CharBase.charStatus.Alive;
                        }
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
                    foreach (PC pc in sf.gm.playerList.PCList)
                    {
                        if (pc.HP <= -20)
                        {
                            c.logText("Can't heal a dead character!", Color.Silver);
                            c.logText(Environment.NewLine, Color.Silver);
                        }
                        else
                        {
                            int heal = 8;
                            c.logText(source.Name, Color.Blue);
                            c.logText(" heals ", Color.Black);
                            c.logText(pc.Name, Color.LightGray);
                            c.logText(" for ", Color.Black);
                            c.logText(heal.ToString(), Color.Lime);
                            c.logText(" hit points", Color.Black);
                            c.logText(Environment.NewLine, Color.Black);
                            c.logText(Environment.NewLine, Color.Black);
                            pc.HP += heal;
                            if (pc.HP > pc.HPMax)
                            {
                                pc.HP = pc.HPMax;
                            }
                            if ((pc.HP > 0) && (pc.Status == CharBase.charStatus.Dead))
                            {
                                pc.Status = CharBase.charStatus.Alive;
                            }
                        }
                    }
                }
                else if (sf.CombatSource is Creature)
                {

                    Creature source = (Creature)sf.CombatSource;
                    Creature target = (Creature)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;
                    foreach (Creature crt in c.com_encounter.EncounterCreatureList.creatures)
                    {
                        int heal = 8;
                        c.logText(source.Name, Color.Blue);
                        c.logText(" heals ", Color.Black);
                        c.logText(crt.Name, Color.LightGray);
                        c.logText(" for ", Color.Black);
                        c.logText(heal.ToString(), Color.Lime);
                        c.logText(" hit points", Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        crt.HP += heal;
                        if (crt.HP > crt.HPMax)
                        {
                            crt.HP = crt.HPMax;
                        }
                    }
                }
                else // don't know who cast this spell
                {
                    MessageBox.Show("Invalid script owner, not a Creature or PC");
                    return;
                }
            }
        }
    }
}
