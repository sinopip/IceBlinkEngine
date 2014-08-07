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
                Combat c = sf.frm.currentCombat;
                Skill sk = source.KnownSkillsList.getSkillByTag("hideInShadows");
                // if already in stealth, do nothing
                // make stealth check
                int skChkRoll = sf.gm.Random(20);
                int skChkMods = sk.Ranks + sk.Modifiers;
                int skChk = skChkRoll + skChkMods;
                int DC = 5;
                int highestPerception = 0;

                //Entering Stealth becomes more difficult if enemeis are near
                foreach (Creature crt2 in sf.gm.currentEncounter.EncounterCreatureList.creatures)
                {
                    if (crt2.PerceptionRange >= sf.CalcDistance(crt2.CombatLocation, source.CombatLocation))
                    {
                        if (crt2.PerceptionValue >= highestPerception)
                        {
                            highestPerception = crt2.PerceptionValue;
                        }
                    }

                    if (sf.CalcDistance(crt2.CombatLocation, source.CombatLocation) <= 3)
                    {
                        DC += (4 - (sf.CalcDistance(crt2.CombatLocation, source.CombatLocation)));
                    }
                }

                DC += highestPerception;

                if ((skChk >= DC) && (source.SP >= 3)) // if successful, set variable on PC of "StealthModeOn"
                {
                    sf.DrawCombatFloatyTextOverSquare("Stealthed", source.CombatLocation.X, source.CombatLocation.Y, 60, 12, -20, Color.Lime, Color.Black);
                    sf.DrawCombatFloatyTextOverSquare("-3 SP", source.CombatLocation.X, source.CombatLocation.Y, 60, 16, -5, Color.Blue, Color.Black);
                    source.SP -= 3;
                    //source.ACBase += 50;
                    sf.SetLocalInt(source.Tag, "StealthModeOn", 1);
                    c.logText(source.Name, Color.Blue);
                    c.logText(" enters stealth mode successfully", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(skChkRoll.ToString() + " + " + skChkMods.ToString() + " >= " + DC.ToString() + " (roll + mods >= DC)", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);

                    //set the new sprite by assigning a new sprite file name
                    //source.SpriteFilename = "Sneaker.spt";
                    //this will load the sprite file (using p1 now) and load the sprite image "SpriteSheetFilename"
                    //source.LoadSpriteStuff(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName);
                    //source.currentIconBitmap = (); 
                    //Reload the sprite texture for each PC in the party
                    //sf.gm.ChangePartySprite();

                }
                else //else say failed and end turn
                {
                    if (source.SP < 3)
                    {
                        sf.DrawCombatFloatyTextOverSquare("Too few SP to enter stealth", source.CombatLocation.X, source.CombatLocation.Y, 12, -20, 25, Color.Red, Color.Black);
                        c.logText(source.Name + " has too few SP to enter stealth", Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        //c.logText(skChkRoll.ToString() + " + " + skChkMods.ToString() + " < " + DC.ToString() + " (roll + mods < DC)", Color.Black);
                        //c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                    }
                    else
                    {
                        sf.DrawCombatFloatyTextOverSquare("Detected - failed to enter stealth!", source.CombatLocation.X, source.CombatLocation.Y, 12, -20, 25, Color.Red, Color.Black);
                        c.logText(source.Name + " was detected and failed to enter stealth", Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(skChkRoll.ToString() + " + " + skChkMods.ToString() + " < " + DC.ToString() + " (roll + mods < DC)", Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                    }
                }
                /* OLD VERSION
                PC source = (PC)sf.CombatSource;
                Combat c = sf.frm.currentCombat;
                Skill sk = source.KnownSkillsList.getSkillByTag("stealth");                
                // if already in stealth, do nothing
                // make stealth check
                int skChkRoll = sf.gm.Random(20);
                int skChkMods = sk.Ranks + sk.Modifiers;
                int skChk = skChkRoll + skChkMods;
                int DC = 10;
                if (skChk >= DC) // if successful, set variable on PC of "StealthModeOn"
                {
                    sf.SetLocalInt(source.Tag, "StealthModeOn", 1);
                    sf.DrawCombatFloatyTextOverSquare("Hidden in Shadows", source.CombatLocation.X, source.CombatLocation.Y, 60, 16, -5, Color.Blue, Color.Black);
                    c.logText(source.Name, Color.Blue);
                    c.logText(" enters stealth mode successfully", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(skChkRoll.ToString() + " + " + skChkMods.ToString() + " >= " + DC.ToString() + " (roll + mods >= DC)", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
                else //else say failed and end turn
                {
                    c.logText("Failed Skill Check", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(skChkRoll.ToString() + " + " + skChkMods.ToString() + " < " + DC.ToString() + " (roll + mods < DC)", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
                */
            }          
            else if (sf.CombatSource is Creature)
            {
                Creature source = (Creature)sf.CombatSource;
                Combat c = sf.frm.currentCombat;
                Skill sk = source.KnownSkillsList.getSkillByTag("hideInShadows");                
                // if already in stealth, do nothing
                // make stealth check
                int skChkRoll = sf.gm.Random(20);
                int skChkMods = sk.Ranks + sk.Modifiers;
                int skChk = skChkRoll + skChkMods;
                int DC = 10;
                if (skChk >= DC) // if successful, set variable on Creature of "StealthModeOn"
                {
                    sf.SetLocalInt(source.Tag, "StealthModeOn", 1);
                    sf.DrawCombatFloatyTextOverSquare("Hidden in Shadows", source.CombatLocation.X, source.CombatLocation.Y, 60, 16, -5, Color.Blue, Color.Black);
                    c.logText(source.Name, Color.LightGray);
                    c.logText(" enters stealth mode successfully", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(skChkRoll.ToString() + " + " + skChkMods.ToString() + " >= " + DC.ToString() + " (roll + mods >= DC)", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
                else //else say failed and end turn
                {
                    c.logText(source.Name, Color.LightGray);
                    c.logText("Failed Skill Check", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(skChkRoll.ToString() + " + " + skChkMods.ToString() + " < " + DC.ToString() + " (roll + mods < DC)", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
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
