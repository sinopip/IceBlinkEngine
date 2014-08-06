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
            if (sf.CombatSource is PC)
            {
                PC source = (PC)sf.CombatSource;
                //Creature target = (Creature)sf.CombatTarget;
                Point target = (Point)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;
                foreach (Creature crt in c.com_encounter.EncounterCreatureList.creatures)
                {
                    // if in range of radius of x and radius of y
                    if ((crt.CombatLocation.X >= target.X - c.currentSpell.AoeRadiusOrLength) && (crt.CombatLocation.X <= target.X + c.currentSpell.AoeRadiusOrLength))
                    {
                        if ((crt.CombatLocation.Y >= target.Y - c.currentSpell.AoeRadiusOrLength) && (crt.CombatLocation.Y <= target.Y + c.currentSpell.AoeRadiusOrLength))
                        {
                            int saveChkRoll = sf.gm.Random(20);
                            int saveChk = saveChkRoll + crt.Will;
                            int DC = 13;
                            if (saveChk >= DC) //passed save check
                            {
                                c.logText(crt.Name, Color.Blue);
                                c.logText(" avoids the sleep spell ", Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(saveChkRoll.ToString() + " + " + crt.Fortitude.ToString() + " >= " + DC.ToString(), Color.Blue);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                            }
                            else //failed check
                            {
                                //IBMessageBox.Show(sf.gm, "Regeneration Effect Begins");
                                c.logText(crt.Name, Color.LightGray);
                                c.logText(" is held by a sleep spell ", Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                crt.Status = CharBase.charStatus.Held;
                                crt.AddEffectByTag("sleep");
                            }
                        }
                    }
                }
            }
            else if (sf.CombatSource is Creature)
            {
                Creature source = (Creature)sf.CombatSource;
                //PC target = (PC)sf.CombatTarget;
                Point target = (Point)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;
                foreach (PC pc in sf.gm.playerList.PCList)
                {
                    // if in range of radius of x and radius of y
                    if ((pc.CombatLocation.X >= target.X - sf.SpellToCast.AoeRadiusOrLength) && (pc.CombatLocation.X <= target.X + sf.SpellToCast.AoeRadiusOrLength))
                    {
                        if ((pc.CombatLocation.Y >= target.Y - sf.SpellToCast.AoeRadiusOrLength) && (pc.CombatLocation.Y <= target.Y + sf.SpellToCast.AoeRadiusOrLength))
                        {
                            int saveChkRoll = sf.gm.Random(20);
                            int saveChk = saveChkRoll + pc.Will;
                            int DC = 13;
                            if (saveChk >= DC) //passed save check
                            {
                                c.logText(pc.Name, Color.Blue);
                                c.logText(" avoids the sleep spell ", Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(saveChkRoll.ToString() + " + " + pc.Fortitude.ToString() + " >= " + DC.ToString(), Color.Blue);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                            }
                            else //failed check
                            {
                                //IBMessageBox.Show(sf.gm, "Regeneration Effect Begins");
                                c.logText(pc.Name, Color.LightGray);
                                c.logText(" is held by a sleep spell ", Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                pc.Status = CharBase.charStatus.Held;
                                pc.AddEffectByTag("sleep");
                            }
                        }
                    }
                }
            }
            else // don't know who cast this spell
            {
                IBMessageBox.Show(sf.gm, "Invalid script owner, not a Creature or PC");
                return;
            }
        }
    }
}
