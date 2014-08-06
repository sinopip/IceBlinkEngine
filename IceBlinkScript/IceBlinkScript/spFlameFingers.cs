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
                Point target = (Point)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;
                foreach (Creature crt in c.com_encounter.EncounterCreatureList.creatures)
                {
                    // if in range of radius of x and radius of y
                    if ((crt.CombatLocation.X >= target.X - c.currentSpell.AoeRadiusOrLength) && (crt.CombatLocation.X <= target.X + c.currentSpell.AoeRadiusOrLength))
                    {
                        if ((crt.CombatLocation.Y >= target.Y - c.currentSpell.AoeRadiusOrLength) && (crt.CombatLocation.Y <= target.Y + c.currentSpell.AoeRadiusOrLength))
                        {
                            //int damage = 1 * sf.gm.Random(4);
                            float resist = (float)(1f - ((float)crt.DamageTypeResistanceValueFire / 100f));
                            float damage = source.ClassLevel * sf.gm.Random(3);
                            int fireDam = (int)(damage * resist);
                            if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " fireDam = " + fireDam.ToString(), Color.Silver); }
                            c.logText(source.Name, Color.Blue);
                            c.logText(" attacks ", Color.Black);
                            c.logText(crt.Name, Color.LightGray);
                            c.logText(" with Flaming Fingers and burns for ", Color.Black);
                            c.logText(damage.ToString(), Color.Lime);
                            c.logText(" point(s) of damage", Color.Black);
                            c.logText(Environment.NewLine, Color.Black);
                            c.logText(Environment.NewLine, Color.Black);

                            crt.HP -= fireDam;
                            if (crt.HP <= 0)
                            {
                                c.logText(source.Name + " killed the " + crt.Name, Color.Lime);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                crt.CharSprite.Image = new Bitmap(sf.gm.mainDirectory + "\\data\\rip.png");
                                c.refreshMap();
                            }
                        }
                    }
                }
                foreach (PC pc in sf.gm.playerList.PCList)
                {
                    // if in range of radius of x and radius of y
                    if ((pc.CombatLocation.X >= target.X - c.currentSpell.AoeRadiusOrLength) && (pc.CombatLocation.X <= target.X + c.currentSpell.AoeRadiusOrLength))
                    {
                        if ((pc.CombatLocation.Y >= target.Y - c.currentSpell.AoeRadiusOrLength) && (pc.CombatLocation.Y <= target.Y + c.currentSpell.AoeRadiusOrLength))
                        {
                            //int damage = 1 * sf.gm.Random(4);
                            float resist = (float)(1f - ((float)pc.DamageTypeResistanceTotalFire / 100f));
                            float damage = source.ClassLevel * sf.gm.Random(3);
                            int fireDam = (int)(damage * resist);
                            if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " fireDam = " + fireDam.ToString(), Color.Silver); }
                            c.logText(source.Name, Color.Blue);
                            c.logText(" attacks ", Color.Black);
                            c.logText(pc.Name, Color.Blue);
                            c.logText(" with Flaming Fingers and burns for ", Color.Black);
                            c.logText(damage.ToString(), Color.Lime);
                            c.logText(" point(s) of damage", Color.Black);
                            c.logText(Environment.NewLine, Color.Black);
                            c.logText(Environment.NewLine, Color.Black);

                            pc.HP -= fireDam;
                            if (pc.HP <= 0)
                            {
                                c.logText(pc.Name + " has been killed!", Color.Red);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                pc.Status = PC.charStatus.Dead;
                            }
                        }
                    }
                }
            }          
            else if (sf.CombatSource is Creature)
            {
                Creature source = (Creature)sf.CombatSource;
                Point target = (Point)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;
                foreach (PC pc in sf.gm.playerList.PCList)
                {
                    // if in range of radius of x and radius of y
                    if ((pc.CombatLocation.X >= target.X - sf.SpellToCast.AoeRadiusOrLength) && (pc.CombatLocation.X <= target.X + sf.SpellToCast.AoeRadiusOrLength))
                    {
                        if ((pc.CombatLocation.Y >= target.Y - sf.SpellToCast.AoeRadiusOrLength) && (pc.CombatLocation.Y <= target.Y + sf.SpellToCast.AoeRadiusOrLength))
                        {
                            //int damage = 1 * sf.gm.Random(4);
                            float resist = (float)(1f - ((float)pc.DamageTypeResistanceTotalFire / 100f));
                            float damage = source.ClassLevel * sf.gm.Random(3);
                            int fireDam = (int)(damage * resist);
                            if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " fireDam = " + fireDam.ToString(), Color.Silver); }
                            c.logText(source.Name, Color.Blue);
                            c.logText(" attacks ", Color.Black);
                            c.logText(pc.Name, Color.LightGray);
                            c.logText(" with Flaming Fingers and burns for ", Color.Black);
                            c.logText(damage.ToString(), Color.Lime);
                            c.logText(" point(s) of damage", Color.Black);
                            c.logText(Environment.NewLine, Color.Black);
                            c.logText(Environment.NewLine, Color.Black);

                            pc.HP -= fireDam;
                            if (pc.HP <= 0)
                            {
                                c.logText(pc.Name + " has been killed!", Color.Red);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                                pc.Status = PC.charStatus.Dead;
                            }
                        }
                    }
                }
                foreach (Creature crt in c.com_encounter.EncounterCreatureList.creatures)
                {
                    // if in range of radius of x and radius of y
                    if ((crt.CombatLocation.X >= target.X - sf.SpellToCast.AoeRadiusOrLength) && (crt.CombatLocation.X <= target.X + sf.SpellToCast.AoeRadiusOrLength))
                    {
                        if ((crt.CombatLocation.Y >= target.Y - sf.SpellToCast.AoeRadiusOrLength) && (crt.CombatLocation.Y <= target.Y + sf.SpellToCast.AoeRadiusOrLength))
                        {
                            //int damage = 1 * sf.gm.Random(4);
                            float resist = (float)(1f - ((float)crt.DamageTypeResistanceValueFire / 100f));
                            float damage = source.ClassLevel * sf.gm.Random(3);
                            int fireDam = (int)(damage * resist);
                            if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " fireDam = " + fireDam.ToString(), Color.Silver); }
                            c.logText(source.Name, Color.Blue);
                            c.logText(" attacks ", Color.Black);
                            c.logText(crt.Name, Color.LightGray);
                            c.logText(" with Flaming Fingers and burns for ", Color.Black);
                            c.logText(damage.ToString(), Color.Lime);
                            c.logText(" point(s) of damage", Color.Black);
                            c.logText(Environment.NewLine, Color.Black);
                            c.logText(Environment.NewLine, Color.Black);

                            crt.HP -= fireDam;
                            if (crt.HP <= 0)
                            {
                                c.logText(source.Name + " killed the " + crt.Name, Color.Lime);
                                c.logText(Environment.NewLine, Color.Black);
                                c.logText(Environment.NewLine, Color.Black);
                            }
                        }
                    }
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
