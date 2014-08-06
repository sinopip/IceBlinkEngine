using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;
using System.Drawing;


namespace IceBlink
{
    public class IceBlinkScript
    {
        //new variable accessible for all methods of IceBlinkScript class
        //stores the penalty for attacks after the first (increase by -5 per additional attack)
        public int multAttackPenalty = 0;

        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)

        #region Main script: Do pc attacks, contains multiple attacks, backstabs, cleaves, critical hits and to hit bonus for attacks from behind
        {
            // C# code goes here
            PC pc = (PC)sf.CombatSource;
            Creature crt = (Creature)sf.CombatTarget; //this is the creature that is being attacked
            Combat c = sf.frm.currentCombat;

            //Creatures on directly neighbouring fields get an extra attack on the player if he attacks anywhere with a ranged weapon
            //better don't shoot when in melee range of disturbing enemies
            //this iterates through all the creatures in the encounter
            //note: if you want free attacks on characters casting in melee, this will have to be coded into the spell scripts as of now
            foreach (Creature crtr in sf.gm.currentEncounter.EncounterCreatureList.creatures)
            {
                //check whether pc is attacking with non-melee weapon /non-barehanded and if there's any creature on neighbouring field
                if ((pc.MainHand.ItemCategory != Item.category.Melee) && (pc.MainHand.ItemName != "") && (sf.CalcDistance(crt.CombatLocation, pc.CombatLocation) <= 1))
                {
                    //each neighbouring creature gets a free attack on the player
                    //see this function at the end of this script
                    doStandardCreatureAttack2(sf, pc, crtr);
                }
            }

            //all attacks of the PC from behind get a +2 bonus to hit
            //I have palced this outside the loop for multiple attacks as otherwise each consecutive attack would unintendedly increase this bonus
            if (IsAttackFromBehind(pc, crt))
            {
                crt.ACBase -= 2;
            }

            //Backstabs are only possible in melee
            //Right now a backstab attack denies multiple attacks -  a bit unfair for high level thieves, or not? Pending discusssion.
            //Might be compensated by very high damage multipliers though, which would look impressive :-): One single, but deadly strike, I like :-)
            //Current doBackStabPcAttack has higher multipliers than usual OGL, but also costs a combat round on enter stealth and cosumes SP
            if ((HasBackStabTrait(pc)) && (IsAttackFromBehind(pc, crt)) && (sf.CalcDistance(crt.CombatLocation, pc.CombatLocation) <= 1) && (sf.CheckLocalInt(pc.Tag, "StealthModeOn", "=", 1)) && (pc.MainHand.ItemCategory == Item.category.Melee))
            {
                doBackStabPcAttack(sf, c, pc, crt);
            }
            else
            {
                //loop for multiple attacks
                //attack counter is the number of attacks available
                int attackCounter = (pc.BaseAttBonus / 6) + 1;
                for (int i = 0; i < attackCounter; i++)
                {
                    //if i > 0, i.e. second or more attacks, the BAB is reduced by 5 for each i (i.e. for each new attack)
                    //attacks against dead targets are lost, they are not re-routed to new target
                    //only re-routing is donce once due to cleave; greater cleave trait will make our lifes hard here :-)
                    multAttackPenalty = 5 * i;
                    if (HasCleaveTrait(pc))
                    {
                        bool killed = false;
                        killed = doStandardPcAttack(sf, c, pc, crt);
                        if (killed)
                        {
                            crt = sf.GetNextAdjacentCreature(pc);
                            if (crt != null)
                            {
                                sf.DrawCombatFloatyTextOverSquare("cleave", crt.CombatLocation.X, crt.CombatLocation.Y, 40, Color.White, Color.Black);
                                if (IsAttackFromBehind(pc, crt))
                                {
                                    //we changed target creature, so the bonus from behind has to be applied "again" here (i.e. for the first time on the new creature)
                                    crt.ACBase -= 2;
                                }
                                doStandardPcAttack(sf, c, pc, crt);
                            }
                            return;//do not try and attack same creature that was just killed
                        }
                    }
                    else
                    {
                        bool killed = false;
                        killed = doStandardPcAttack(sf, c, pc, crt);
                        if (killed)
                        {
                            //attacks against dead targets are lost, they are not re-routed to new target
                            return; //do not try and attack same creature that was just killed
                        }
                    }
                }
            }

            if (sf.CheckLocalInt(pc.Tag, "StealthModeOn", "=", 1))
            {
                sf.SetLocalInt(pc.Tag, "StealthModeOn", 0); //turn off stealth mode if PC is attacking
                //take care that a +50 AC bonus has been granted to stealthed characters by my customized skStealth.cs script (in order to protect them from AoO)
                //this line reverses this protection on leaving stealth
                //remove if using a different stealth system
                pc.ACBase -= 50;
                sf.DrawCombatFloatyTextOverSquare("Leaves stealth!", pc.CombatLocation.X, pc.CombatLocation.Y, 40, -20, 25, Color.Red, Color.Black);
                c.logText(pc.Name, Color.Blue);
                c.logText(" exits stealth mode", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }

            //this restores creature AC, negating the boni granted beforehand again
            //we might add flanking boni btw (if you like, in RedCarnival I run those on the StartCombatRound script hook right now, stems from a time where this script here was not existent)
            if (IsAttackFromBehind(pc, crt))
            {
                crt.ACBase += 2;
            }

        }
        #endregion

        #region Bool HasBackStabTrait
        public bool HasBackStabTrait(PC pc)
        {
            foreach (Trait tr in pc.KnownTraitsList.traitList)
            {
                if (tr.TraitTag == "backStab") { return true; }
            }
            return false;
        }
        #endregion

        #region Bool HasCleaveTrait
        public bool HasCleaveTrait(PC pc)
        {
            foreach (Trait tr in pc.KnownTraitsList.traitList)
            {
                if (tr.TraitTag == "cleave") { return true; }
            }
            return false;
        }
        #endregion

        #region Bool IsAttackFromBehind
        public bool IsAttackFromBehind(PC pc, Creature crt)
        {
            if ((pc.CombatLocation.X > crt.CombatLocation.X) && (pc.CombatLocation.Y > crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.UpLeft)) { return true; }
            if ((pc.CombatLocation.X == crt.CombatLocation.X) && (pc.CombatLocation.Y > crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.Up)) { return true; }
            if ((pc.CombatLocation.X < crt.CombatLocation.X) && (pc.CombatLocation.Y > crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.UpRight)) { return true; }
            if ((pc.CombatLocation.X > crt.CombatLocation.X) && (pc.CombatLocation.Y == crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.Left)) { return true; }
            if ((pc.CombatLocation.X < crt.CombatLocation.X) && (pc.CombatLocation.Y == crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.Right)) { return true; }
            if ((pc.CombatLocation.X > crt.CombatLocation.X) && (pc.CombatLocation.Y < crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.DownLeft)) { return true; }
            if ((pc.CombatLocation.X == crt.CombatLocation.X) && (pc.CombatLocation.Y < crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.Down)) { return true; }
            if ((pc.CombatLocation.X < crt.CombatLocation.X) && (pc.CombatLocation.Y < crt.CombatLocation.Y) && (crt.CombatFacing == CharBase.facing.DownRight)) { return true; }
            return false;
        }
        #endregion

        #region doStandardPcAttack
        public bool doStandardPcAttack(ScriptFunctions sf, Combat c, PC pc, Creature crt)
        {
            pc.UpdateSimpleStats();
            int attackRoll = sf.gm.Random(20);
            int attackMod = sf.CalcPcAttackModifier();
            //factor in the penalty for multiple attacks
            attackMod -= multAttackPenalty;
            int attack = attackRoll + attackMod;
            int defense = sf.CalcCreatureDefense();
            int damage = sf.CalcPcDamageToCreature();
            //variable storing whether a critical hit was rolled
            int criticalHitScored = 0;
            // variable for storing the critical hit range
            int criticalHitRange = pc.MainHand.CriticalHitRange;
            //variable for storing the critical hit multiplier
            int criticalHitDamageMultiplier = pc.MainHand.CriticalHitDamageMultiplier;
            //critical hit mechanism - triggered on a roll equal or higher than criticalHitRange  
            if ((attackRoll >= criticalHitRange) || (attackRoll == 20))
            {
                //second attack roll to confirm the critical hit
                int attackRoll2 = sf.gm.Random(20);
                int attackMod2 = sf.CalcPcAttackModifier();
                attackMod2 -= multAttackPenalty;
                int attack2 = attackRoll2 + attackMod2;
                int defense2 = sf.CalcCreatureDefense();
                //rolls of 20 always hit. also true for crit confirmation itself
                if ((attack2 >= defense2) || (attackRoll2 == 20))
                {
                    criticalHitScored = 1;
                    //damage is rolled as often as the critical hit multiplier indicates
                    for (int i = 0; i < criticalHitDamageMultiplier; i++)
                    {
                        damage = (damage + sf.CalcPcDamageToCreature());
                    }
                }
            }

            // do attack animation if sprite has animations
            sf.doPcAttackAnimation();
            //natural 20 always hits
            if ((attack >= defense) || (attackRoll == 20)) //HIT
            {
                sf.drawHitSymbolOnCreature();
                string attackResult = (damage.ToString() + " of " + crt.HP.ToString());

                //differ between attacks from behinds, critical and regular hits in various combinations
                if (IsAttackFromBehind(pc, crt))
                {

                    //adjust floaty for crtical hit
                    if (criticalHitScored == 1)
                    {
                        sf.DrawCombatFloatyTextOverSquare(("CRITICAL HIT from BEHIND: " + attackResult), crt.CombatLocation.X, crt.CombatLocation.Y, 50, -20, 25, Color.Red, Color.Black);
                    }
                    else
                    {
                        sf.DrawCombatFloatyTextOverSquare("From BEHIND: " + attackResult, crt.CombatLocation.X, crt.CombatLocation.Y, 40, 12, -20, Color.Red, Color.Black);
                    }
                }
                else
                    if (criticalHitScored == 1)
                    {
                        sf.DrawCombatFloatyTextOverSquare(("CRITICAL HIT: " + attackResult), crt.CombatLocation.X, crt.CombatLocation.Y, 40, -20, 25, Color.Red, Color.Black);
                    }
                    else
                    {
                        sf.DrawCombatFloatyTextOverSquare(attackResult, crt.CombatLocation.X, crt.CombatLocation.Y, 35, 12, -20, Color.Red, Color.Black);
                    }

                c.logText(pc.Name, Color.Blue);
                c.logText(" attacks ", Color.Black);
                if (IsAttackFromBehind(pc, crt))
                {
                    c.logText(" from BEHIND (enemy AC -2) ", Color.Black);
                }
                c.logText(crt.Name, Color.LightGray);
                //adjust combat log for critical hit
                if (criticalHitScored == 1)
                {
                    c.logText(" and CRITICALLY HITS for ", Color.Black);
                }
                else
                {
                    c.logText(" and HITS for ", Color.Black);
                }
                c.logText(damage.ToString(), Color.Lime);
                c.logText(" point(s) of damage", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(attackRoll.ToString() + " + " + attackMod.ToString() + " >= " + defense.ToString(), Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);

                #region onScoringHit script of used item
                IceBlinkCore.ScriptSelectEditorReturnObject scriptItem = pc.MainHand.OnScoringHit;
                sf.frm.doScriptBasedOnFilename(scriptItem.FilenameOrTag, scriptItem.Parm1, scriptItem.Parm2, scriptItem.Parm3, scriptItem.Parm4);
                #endregion

                crt.HP = crt.HP - damage;
                if (crt.HP <= 0)
                {
                    c.logText("You killed the " + crt.Name, Color.Lime);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    return true;
                }
                return false;
            }
            else //MISSED
            {
                sf.DrawCombatFloatyTextOverSquare("Evades!", crt.CombatLocation.X, crt.CombatLocation.Y, 40, 16, -5, Color.Blue, Color.Black);
                c.logText(pc.Name, Color.Blue);
                c.logText(" attacks ", Color.Black);
                c.logText(crt.Name, Color.LightGray);
                c.logText(" and MISSES", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(attackRoll.ToString() + " + " + attackMod.ToString() + " < " + defense.ToString(), Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                return false;
            }
        }
        #endregion

        #region doBackStabPcAttack
        public void doBackStabPcAttack(ScriptFunctions sf, Combat c, PC pc, Creature crt)
        {
            pc.UpdateSimpleStats();
            int attackRoll = sf.gm.Random(20);
            int attackMod = sf.CalcPcAttackModifier();
            int attack = attackRoll + attackMod;
            int defense = sf.CalcCreatureDefense();
            //we start with *3 multiplier due to the extra round it costs to go into stealth and the SP consumption 
            int bsMultiplier = (pc.ClassLevel / 4) + 3;
            int damage = sf.CalcPcDamageToCreature() * bsMultiplier;
            int criticalHitScored = 0;
            //critical hit (see detail comments above for normal attacks)
            // variable for storing the critical hit range
            int criticalHitRange = pc.MainHand.CriticalHitRange;
            //variable for storing the critical hit multiplier
            int criticalHitDamageMultiplier = pc.MainHand.CriticalHitDamageMultiplier;
            //critical hit mechanism - triggered on a roll equal or higher than criticalHitRange  
            if ((attackRoll >= criticalHitRange) || (attackRoll == 20))
            {
                int attackRoll2 = sf.gm.Random(20);
                int attackMod2 = sf.CalcPcAttackModifier();
                attackMod2 -= multAttackPenalty;
                int attack2 = attackRoll2 + attackMod2;
                int defense2 = sf.CalcCreatureDefense();
                if ((attack2 >= defense2) || (attackRoll2 == 20))
                {
                    criticalHitScored = 1;
                    //damage is rolled as often as the critical hit multiplier indicates
                    for (int i = 0; i < criticalHitDamageMultiplier; i++)
                    {
                        damage = (damage + sf.CalcPcDamageToCreature());
                    }
                }
            }
            // do attack animation if sprite has animations
            sf.doPcAttackAnimation();
            if ((attack >= defense) || (attackRoll == 20)) //HIT
            {
                sf.drawHitSymbolOnCreature();
                string attackResult = (damage.ToString() + " of " + crt.HP.ToString());
                if (criticalHitScored == 1)
                {
                    sf.DrawCombatFloatyTextOverSquare(("CRITICAL Backstab(x" + bsMultiplier.ToString() + "): " + attackResult + "!"), crt.CombatLocation.X, crt.CombatLocation.Y, 60, 12, -20, Color.Red, Color.Black);
                }
                else
                {
                    sf.DrawCombatFloatyTextOverSquare(("Backstab (x" + bsMultiplier.ToString() + "): " + attackResult + "!"), crt.CombatLocation.X, crt.CombatLocation.Y, 50, 12, -20, Color.Red, Color.Black);
                }
                c.logText(pc.Name, Color.Blue);
                if (criticalHitScored == 1)
                {
                    c.logText(" CRITICALLY attacks ", Color.Black);
                }
                else
                {
                    c.logText(" attacks ", Color.Black);
                }
                c.logText(crt.Name, Color.LightGray);
                c.logText(" from behind and BACKSTABS for ", Color.Black);
                c.logText(damage.ToString(), Color.Lime);
                c.logText(" point(s) of damage", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText("(backstab multiplier of " + bsMultiplier.ToString() + ")", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(attackRoll.ToString() + " + " + attackMod.ToString() + " >= " + defense.ToString(), Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);

                #region onScoringHit script of used item
                IceBlinkCore.ScriptSelectEditorReturnObject scriptItem = pc.MainHand.OnScoringHit;
                sf.frm.doScriptBasedOnFilename(scriptItem.FilenameOrTag, scriptItem.Parm1, scriptItem.Parm2, scriptItem.Parm3, scriptItem.Parm4);
                #endregion

                crt.HP = crt.HP - damage;
                if (crt.HP <= 0)
                {
                    c.logText("You killed the " + crt.Name, Color.Lime);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
            }
            else //MISSED
            {
                sf.DrawCombatFloatyTextOverSquare("Evades!", crt.CombatLocation.X, crt.CombatLocation.Y, 40, 16, -5, Color.Blue, Color.Black);
                c.logText(pc.Name, Color.Blue);
                c.logText(" backstabs ", Color.Black);
                c.logText(crt.Name, Color.LightGray);
                c.logText(" and MISSES", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(attackRoll.ToString() + " + " + attackMod.ToString() + " < " + defense.ToString(), Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }
        }
        #endregion

        #region Do free attacks against ranged pc attackers in melee range of interrupting creature
        //function for free attacks against ranged attackers in melee range of interrupting creature
        public void doStandardCreatureAttack2(ScriptFunctions sf, PC pc, Creature crtr)
        {
            Combat c = sf.frm.currentCombat;

            //note: I had to to borrow lots of code directly from scriptfunctions. dll as the function calls themselves mixed up crt and pc
            int attackRoll = sf.gm.Random(20);
            int attackMod = crtr.Attack;
            int defense = sf.CalcPcDefense();
            int damage = sf.CalcCreatureDamageToPc();
            /*int armDamRed = 0;
            if (pc.Body != null)
            {
                //How about other items that grant damage reduction - are they not factored in?
                armDamRed = pc.Body.ItemDamageReduction;
            }
            int dDam = crtr.DamageDie;
            int damage = (crtr.NumberOfDamageDice * sf.gm.Random(dDam)) - armDamRed + crtr.DamageAdder;
            if (damage < 0)
            {
                damage = 0;
            }*/
            int attack = attackRoll + attackMod;

            int criticalHitScored = 0;
            //critical hit (see detail in modified attackPlayer.cs)
            int criticalHitRange = crtr.CriticalHitRange;
            //variable for storing the critical hit multiplier
            int criticalHitDamageMultiplier = crtr.CriticalHitDamageMultiplier;
            //critical hit mechanism - triggered on a roll equal or higher than criticalHitRange  
            if ((attackRoll >= criticalHitRange) || (attackRoll == 20))
            {
                int attackRoll2 = sf.gm.Random(20);
                int attackMod2 = sf.CalcCreatureAttackModifier();
                int attack2 = attackRoll2 + attackMod2;
                int defense2 = sf.CalcPcDefense();
                if ((attack2 >= defense2) || (attackRoll2 == 20))
                {
                    criticalHitScored = 1;
                    //normal damage is rolled aagin - backstab damage is not double rolled
                    int additionaldamage = damage;
                    for (int i = 0; i < criticalHitDamageMultiplier; i++)
                    {
                        damage += additionaldamage;
                    }
                }
            }

            // do attack animation if sprite has animations
            if (crtr.CharSprite.AttackingNumberOfFrames > 1)
            {
                c.attackCreatureAnimation(crtr);
            }
            if (crtr.WeaponType != Creature.crCategory.Ranged)
            {
                c.playCreatureAttackSound(crtr);
            }
            if (attack >= defense)
            {
                Application.DoEvents();
                Thread.Sleep(100);
                sf.frm.currentCombat.refreshMap();

                //Some addition to explain why the extra attack has happened
                string attackResult = (damage.ToString() + " of " + pc.HP.ToString());
                if (criticalHitScored == 1)
                {
                    sf.DrawCombatFloatyTextOverSquare(("CRITICAL free attack against shooter: " + attackResult), pc.CombatLocation.X, pc.CombatLocation.Y, 60, 8, -35, Color.Red, Color.Black);
                }
                else
                {
                    sf.DrawCombatFloatyTextOverSquare(("Free attack against shooter: " + attackResult), pc.CombatLocation.X, pc.CombatLocation.Y, 60, 8, -35, Color.Red, Color.Black);
                }
                c.logText(crtr.Name, Color.LightGray);
                if (criticalHitScored == 1)
                {
                    c.logText(" CRITICALLY attacks ", Color.Black);
                }
                else
                {
                    c.logText(" attacks ", Color.Black);
                }
                c.logText(pc.Name, Color.Blue);
                //Some addition to explain why the extra attack has happened
                c.logText(" due to trying to shoot in melee range and HITS for ", Color.Black);
                c.logText(damage.ToString(), Color.Red);
                c.logText(" point(s) of damage", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(attackRoll.ToString() + " + " + attackMod.ToString() + " >= " + defense.ToString(), Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);

                #region onScoringHit script of creature
                IceBlinkCore.ScriptSelectEditorReturnObject scriptItem = crtr.OnScoringHit;
                sf.frm.doScriptBasedOnFilename(scriptItem.FilenameOrTag, scriptItem.Parm1, scriptItem.Parm2, scriptItem.Parm3, scriptItem.Parm4);
                #endregion

                pc.HP = pc.HP - damage;
                if (pc.HP <= 0)
                {
                    c.logText(pc.Name + " has been killed!", Color.Red);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    pc.Status = PC.charStatus.Dead;
                }
            }
            else
            {
                sf.DrawCombatFloatyTextOverSquare("Evades free attack against shooter!", pc.CombatLocation.X, pc.CombatLocation.Y, 60, 16, -5, Color.Blue, Color.Black);
                c.logText(crtr.Name, Color.LightGray);
                c.logText(" attacks ", Color.Black);
                c.logText(pc.Name, Color.Blue);
                c.logText(" due to trying to shoot in melee range and MISSES", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(attackRoll.ToString() + " + " + attackMod.ToString() + " < " + defense.ToString(), Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }
        }
        #endregion

    }
}
