using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IceBlinkCore;

namespace IceBlink
{
    public static class Stats
    {
        public static void UpdateStats(CharBase pc, ScriptFunctions sf)
        {
            //used at level up, doPcTurn, open inventory, etc.
            ReCalcSavingThrowBases(pc); //SD_20131029
            pc.Fortitude = pc.BaseFortitude + CalcSavingThrowModifiersFortitude(pc) +(pc.Constitution - 10) / 2; //SD_20131127
            pc.Will = pc.BaseWill + CalcSavingThrowModifiersWill(pc) + (pc.Wisdom - 10) / 2; //SD_20131127
            pc.Reflex = pc.BaseReflex + CalcSavingThrowModifiersReflex(pc) + (pc.Dexterity - 10) / 2; //SD_20131127
            pc.Strength = pc.BaseStr + pc.Race.StrMod + CalcAttributeModifierStr(pc); //SD_20131127
            pc.Dexterity = pc.BaseDex + pc.Race.DexMod + CalcAttributeModifierDex(pc); //SD_20131127
            pc.Constitution = pc.BaseCon + pc.Race.ConMod + CalcAttributeModifierCon(pc); //SD_20131127
            pc.Intelligence = pc.BaseInt + pc.Race.IntMod + CalcAttributeModifierInt(pc); //SD_20131127
            pc.Wisdom = pc.BaseWis + pc.Race.WisMod + CalcAttributeModifierWis(pc); //SD_20131127
            pc.Charisma = pc.BaseCha + pc.Race.ChaMod + CalcAttributeModifierCha(pc); //SD_20131127
            //SD_20131124 Start
            pc.DamageTypeResistanceTotalAcid = pc.Race.DamageTypeResistanceValueAcid + CalcAcidModifiers(pc);
            if (pc.DamageTypeResistanceTotalAcid > 100) { pc.DamageTypeResistanceTotalAcid = 100; }            
            pc.DamageTypeResistanceTotalBludgeoning = pc.Race.DamageTypeResistanceValueBludgeoning + CalcBludgeoningModifiers(pc);
            if (pc.DamageTypeResistanceTotalBludgeoning > 100) { pc.DamageTypeResistanceTotalBludgeoning = 100; }
            pc.DamageTypeResistanceTotalCold = pc.Race.DamageTypeResistanceValueCold + CalcAcidModifiers(pc);
            if (pc.DamageTypeResistanceTotalCold > 100) { pc.DamageTypeResistanceTotalCold = 100; }
            pc.DamageTypeResistanceTotalElectricity = pc.Race.DamageTypeResistanceValueElectricity + CalcElectricityModifiers(pc);
            if (pc.DamageTypeResistanceTotalElectricity > 100) { pc.DamageTypeResistanceTotalElectricity = 100; }            
            pc.DamageTypeResistanceTotalFire = pc.Race.DamageTypeResistanceValueFire + CalcFireModifiers(pc);
            if (pc.DamageTypeResistanceTotalFire > 100) { pc.DamageTypeResistanceTotalFire = 100; }            
            pc.DamageTypeResistanceTotalLight = pc.Race.DamageTypeResistanceValueLight + CalcLightModifiers(pc);
            if (pc.DamageTypeResistanceTotalLight > 100) { pc.DamageTypeResistanceTotalLight = 100; }            
            pc.DamageTypeResistanceTotalMagic = pc.Race.DamageTypeResistanceValueMagic + CalcMagicModifiers(pc);
            if (pc.DamageTypeResistanceTotalMagic > 100) { pc.DamageTypeResistanceTotalMagic = 100; }
            pc.DamageTypeResistanceTotalPiercing = pc.Race.DamageTypeResistanceValuePiercing + CalcPiercingModifiers(pc);
            if (pc.DamageTypeResistanceTotalPiercing > 100) { pc.DamageTypeResistanceTotalPiercing = 100; }
            pc.DamageTypeResistanceTotalPoison = pc.Race.DamageTypeResistanceValuePoison + CalcPoisonModifiers(pc);
            if (pc.DamageTypeResistanceTotalPoison > 100) { pc.DamageTypeResistanceTotalPoison = 100; }
            pc.DamageTypeResistanceTotalSlashing = pc.Race.DamageTypeResistanceValueSlashing + CalcSlashingModifiers(pc);
            if (pc.DamageTypeResistanceTotalSlashing > 100) { pc.DamageTypeResistanceTotalSlashing = 100; }
            pc.DamageTypeResistanceTotalSonic = pc.Race.DamageTypeResistanceValueSonic + CalcSonicModifiers(pc);
            if (pc.DamageTypeResistanceTotalSonic > 100) { pc.DamageTypeResistanceTotalSonic = 100; }
            //SD_20131124 End
            //pc.BaseAttBonus = (int)((double)pc.ClassLevel * pc.Class.BabMultiplier) + CalcBABAdders(pc);
            if (pc.Class.BabTable.Count > 0)//SD_20131115
            {
                pc.BaseAttBonus = pc.Class.BabTable[pc.ClassLevel] + CalcBABAdders(pc); //SD_20131115
            }

            int cMod = (pc.Constitution - 10) / 2;
            int iMod = (pc.Intelligence - 10) / 2;
            pc.SPMax = pc.Class.StartingSP + iMod + ((pc.ClassLevel - 1) * (pc.Class.SpPerLevelUp + iMod));            
            pc.HPMax = pc.Class.StartingHP + cMod + ((pc.ClassLevel - 1) * (pc.Class.HpPerLevelUp + cMod));
            
            int dMod = (pc.Dexterity - 10) / 2;
            int maxDex = CalcMaxDexBonus(pc);
            if (dMod > maxDex) { dMod = maxDex; }
            int armBonus = 0;
            int acMods = 0;
            int armDamRed = 0;
            int damRedMods = 0;
            armBonus = CalcArmorBonuses(pc);
            armDamRed = CalcDamReduction(pc);
            damRedMods = CalcDamRedModifiers(pc);
            acMods = CalcACModifiers(pc);
            pc.TotalDamageReduction = armDamRed + damRedMods;
            pc.AC = pc.ACBase + dMod + armBonus + acMods;
            //pc.MoveDistance = pc.MoveDistanceBase + CalcMovementBonuses(pc); //SD_20131116
            if (pc.Body.ArmorWeightType == Item.ArmorWeight.Light) //SD_20131116
            {
                pc.MoveDistance = pc.Race.MoveDistanceLightArmor + CalcMovementBonuses(pc);
            }
            else //medium or heavy SD_20131116
            {
                pc.MoveDistance = pc.Race.MoveDistanceMediumHeavyArmor + CalcMovementBonuses(pc);
            }
            //go through all passive traits and run their scripts
            sf.passParameterScriptObject = pc;
            foreach (Trait tr in pc.KnownTraitsList.traitList)
            {
                if (tr.UseableInSituation == UsableInSituation.Passive)
                {
                    var script = tr.TraitScript;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
            }
            foreach (Effect ef in pc.EffectsList.effectsList)
            {
                if (ef.UsedForUpdateStats)
                {
                    var script = ef.EffectScript;
                    script.Parm1 = ef.CurrentDurationInUnits.ToString();
                    script.Parm2 = ef.DurationInUnits.ToString();
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
            }
            RunAllItemWhileEquippedScripts(pc, sf);            
            sf.passParameterScriptObject = null;
            if (pc.HP > pc.HPMax) { pc.HP = pc.HPMax; } //SD_20131201
            if (pc.SP > pc.SPMax) { pc.SP = pc.SPMax; } //SD_20131201
        }
        public static void RunAllItemWhileEquippedScripts(CharBase pc, ScriptFunctions sf)
        {
            try
            {
                if (pc.Head.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.Head.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
                if (pc.Neck.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.Neck.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
                if (pc.Body.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.Body.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
                if (pc.MainHand.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.MainHand.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
                if (pc.OffHand.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.OffHand.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
                if (pc.Ring1.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.Ring1.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
                if (pc.Ring2.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.Ring2.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }
                if (pc.Feet.OnWhileEquipped.FilenameOrTag != "none")
                {
                    var script = pc.Feet.OnWhileEquipped;
                    sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                }                
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(sf.gm, "failed running OnWhileEquipped scripts during UpdateStats()... see debug.txt");
                sf.gm.errorLog(ex.ToString());
            }
        }
        public static void UpdateSimpleStats(CharBase pc)
        {
            //used when updating properties after change to a property in the toolset
            //ReCalcSavingThrowBases(pc); //SD_20131029
            pc.Fortitude = pc.BaseFortitude + CalcSavingThrowModifiersFortitude(pc) + (pc.Constitution - 10) / 2;
            pc.Will = pc.BaseWill + CalcSavingThrowModifiersWill(pc) + (pc.Wisdom - 10) / 2;
            pc.Reflex = pc.BaseReflex + CalcSavingThrowModifiersReflex(pc) + (pc.Dexterity - 10) / 2;
            pc.Strength = pc.BaseStr + pc.Race.StrMod + CalcAttributeBonuses(pc, CharBase.CharacterAttribute.Strength);
            pc.Dexterity = pc.BaseDex + pc.Race.DexMod + CalcAttributeBonuses(pc, CharBase.CharacterAttribute.Dexterity);
            pc.Constitution = pc.BaseCon + pc.Race.ConMod + CalcAttributeBonuses(pc, CharBase.CharacterAttribute.Constitution);
            pc.Intelligence = pc.BaseInt + pc.Race.IntMod + CalcAttributeBonuses(pc, CharBase.CharacterAttribute.Intelligence);
            pc.Wisdom = pc.BaseWis + pc.Race.WisMod + CalcAttributeBonuses(pc, CharBase.CharacterAttribute.Wisdom);
            pc.Charisma = pc.BaseCha + pc.Race.ChaMod + CalcAttributeBonuses(pc, CharBase.CharacterAttribute.Charisma);
            
            //pc.BaseAttBonus = (int)((double)pc.ClassLevel * pc.Class.BabMultiplier) + CalcBABAdders(pc);
            if (pc.Class.BabTable.Count > 0)//SD_20131115
            {
                pc.BaseAttBonus = pc.Class.BabTable[pc.ClassLevel] + CalcBABAdders(pc); //SD_20131115
            }

            int dMod = (pc.Dexterity - 10) / 2;
            int maxDex = CalcMaxDexBonus(pc);
            if (dMod > maxDex) { dMod = maxDex; }
            int armBonus = 0;
            int armDamRed = 0;
            int acMods = 0;
            int damRedMods = 0;
            armBonus = CalcArmorBonuses(pc);
            armDamRed = CalcDamReduction(pc);
            damRedMods = CalcDamRedModifiers(pc);
            acMods = CalcACModifiers(pc);
            pc.TotalDamageReduction = armDamRed + damRedMods;
            pc.AC = pc.ACBase + dMod + armBonus + acMods;
            //pc.MoveDistance = pc.MoveDistanceBase + CalcMovementBonuses(pc); //SD_20131116
            if (pc.Body.ArmorWeightType == Item.ArmorWeight.Light) //SD_20131116
            {
                pc.MoveDistance = pc.Race.MoveDistanceLightArmor + CalcMovementBonuses(pc);
            }
            else //medium or heavy SD_20131116
            {
                pc.MoveDistance = pc.Race.MoveDistanceMediumHeavyArmor + CalcMovementBonuses(pc);
            }
        }
        public static int CalcBABAdders(CharBase pc)
        {
            int adder = 0;
            foreach (Trait tr in pc.KnownTraitsList.traitList)
            {
                adder += tr.BABModifier;
            }
            foreach (Effect ef in pc.EffectsList.effectsList)
            {
                adder += ef.BABModifier;
            }
            return adder;
        }
        public static int CalcACModifiers(CharBase pc)
        {
            int adder = 0;
            foreach (Trait tr in pc.KnownTraitsList.traitList)
            {
                adder += tr.ACModifier;
            }
            foreach (Effect ef in pc.EffectsList.effectsList)
            {
                adder += ef.ACModifier;
            }
            return adder;
        }
        public static int CalcDamRedModifiers(CharBase pc)
        {
            int adder = 0;
            foreach (Trait tr in pc.KnownTraitsList.traitList)
            {
                adder += tr.DamageReductionModifier;
            }
            foreach (Effect ef in pc.EffectsList.effectsList)
            {
                adder += ef.DamageReductionModifier;
            }
            return adder;
        }
        public static int CalcArmorBonuses(CharBase pc)
        {
            int armBonuses = 0;
            armBonuses += pc.Head.ItemArmorBonus;
            armBonuses += pc.Neck.ItemArmorBonus;
            armBonuses += pc.Body.ItemArmorBonus;
            armBonuses += pc.MainHand.ItemArmorBonus;
            armBonuses += pc.OffHand.ItemArmorBonus;
            armBonuses += pc.Ring1.ItemArmorBonus;
            armBonuses += pc.Ring2.ItemArmorBonus;
            armBonuses += pc.Feet.ItemArmorBonus;
            return armBonuses;
        }
        public static int CalcMaxDexBonus(CharBase pc)
        {
            int armMaxDexBonuses = 99;
            if (pc.Head.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.Head.ItemMaxDexBonus; }
            if (pc.Neck.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.Neck.ItemMaxDexBonus; }
            if (pc.Body.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.Body.ItemMaxDexBonus; }
            if (pc.MainHand.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.MainHand.ItemMaxDexBonus; }
            if (pc.OffHand.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.OffHand.ItemMaxDexBonus; }
            if (pc.Ring1.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.Ring1.ItemMaxDexBonus; }
            if (pc.Ring2.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.Ring2.ItemMaxDexBonus; }
            if (pc.Feet.ItemMaxDexBonus < armMaxDexBonuses) { armMaxDexBonuses = pc.Feet.ItemMaxDexBonus; }
            return armMaxDexBonuses;
        }
        public static int CalcMovementBonuses(CharBase pc)
        {
            int moveBonuses = 0;
            moveBonuses += pc.Head.MovementPointModifier;
            moveBonuses += pc.Neck.MovementPointModifier;
            moveBonuses += pc.Body.MovementPointModifier;
            moveBonuses += pc.MainHand.MovementPointModifier;
            moveBonuses += pc.OffHand.MovementPointModifier;
            moveBonuses += pc.Ring1.MovementPointModifier;
            moveBonuses += pc.Ring2.MovementPointModifier;
            moveBonuses += pc.Feet.MovementPointModifier;
            return moveBonuses;
        }
        public static int CalcInitiativeBonuses(CharBase pc)
        {
            int intBonuses = 0;
            intBonuses += pc.Head.InitiativeBonus;
            intBonuses += pc.Neck.InitiativeBonus;
            intBonuses += pc.Body.InitiativeBonus;
            intBonuses += pc.MainHand.InitiativeBonus;
            intBonuses += pc.OffHand.InitiativeBonus;
            intBonuses += pc.Ring1.InitiativeBonus;
            intBonuses += pc.Ring2.InitiativeBonus;
            intBonuses += pc.Feet.InitiativeBonus;
            return intBonuses;
        }
        public static int CalcAttributeBonuses(CharBase pc, CharBase.CharacterAttribute attType) //SD_20131127 NO LONGER USED ...CAN DELETE
        {
            int attBonuses = 0;
            if (attType == pc.Head.AttributeBonusType)
            {
                attBonuses += pc.Head.AttributeBonusModifier;
            }
            if (attType == pc.Neck.AttributeBonusType)
            {
                attBonuses += pc.Neck.AttributeBonusModifier;
            }
            if (attType == pc.Body.AttributeBonusType)
            {
                attBonuses += pc.Body.AttributeBonusModifier;
            }
            if (attType == pc.MainHand.AttributeBonusType)
            {
                attBonuses += pc.MainHand.AttributeBonusModifier;
            }
            if (attType == pc.OffHand.AttributeBonusType)
            {
                attBonuses += pc.OffHand.AttributeBonusModifier;
            }
            if (attType == pc.Ring1.AttributeBonusType)
            {
                attBonuses += pc.Ring1.AttributeBonusModifier;
            }
            if (attType == pc.Ring2.AttributeBonusType)
            {
                attBonuses += pc.Ring2.AttributeBonusModifier;
            }
            if (attType == pc.Feet.AttributeBonusType)
            {
                attBonuses += pc.Feet.AttributeBonusModifier;
            }
            return attBonuses;
        }
        //SD_20131127 Start
        public static int CalcAttributeModifierStr(CharBase pc)
        {
            int attBonuses = 0;
            attBonuses += pc.Head.AttributeBonusModifierStr;
            attBonuses += pc.Neck.AttributeBonusModifierStr;
            attBonuses += pc.Body.AttributeBonusModifierStr;
            attBonuses += pc.MainHand.AttributeBonusModifierStr;
            attBonuses += pc.OffHand.AttributeBonusModifierStr;
            attBonuses += pc.Ring1.AttributeBonusModifierStr;
            attBonuses += pc.Ring2.AttributeBonusModifierStr;
            attBonuses += pc.Feet.AttributeBonusModifierStr;
            return attBonuses;
        }
        public static int CalcAttributeModifierDex(CharBase pc)
        {
            int attBonuses = 0;
            attBonuses += pc.Head.AttributeBonusModifierDex;
            attBonuses += pc.Neck.AttributeBonusModifierDex;
            attBonuses += pc.Body.AttributeBonusModifierDex;
            attBonuses += pc.MainHand.AttributeBonusModifierDex;
            attBonuses += pc.OffHand.AttributeBonusModifierDex;
            attBonuses += pc.Ring1.AttributeBonusModifierDex;
            attBonuses += pc.Ring2.AttributeBonusModifierDex;
            attBonuses += pc.Feet.AttributeBonusModifierDex;
            return attBonuses;
        }
        public static int CalcAttributeModifierCon(CharBase pc)
        {
            int attBonuses = 0;
            attBonuses += pc.Head.AttributeBonusModifierCon;
            attBonuses += pc.Neck.AttributeBonusModifierCon;
            attBonuses += pc.Body.AttributeBonusModifierCon;
            attBonuses += pc.MainHand.AttributeBonusModifierCon;
            attBonuses += pc.OffHand.AttributeBonusModifierCon;
            attBonuses += pc.Ring1.AttributeBonusModifierCon;
            attBonuses += pc.Ring2.AttributeBonusModifierCon;
            attBonuses += pc.Feet.AttributeBonusModifierCon;
            return attBonuses;
        }
        public static int CalcAttributeModifierInt(CharBase pc)
        {
            int attBonuses = 0;
            attBonuses += pc.Head.AttributeBonusModifierInt;
            attBonuses += pc.Neck.AttributeBonusModifierInt;
            attBonuses += pc.Body.AttributeBonusModifierInt;
            attBonuses += pc.MainHand.AttributeBonusModifierInt;
            attBonuses += pc.OffHand.AttributeBonusModifierInt;
            attBonuses += pc.Ring1.AttributeBonusModifierInt;
            attBonuses += pc.Ring2.AttributeBonusModifierInt;
            attBonuses += pc.Feet.AttributeBonusModifierInt;
            return attBonuses;
        }
        public static int CalcAttributeModifierWis(CharBase pc)
        {
            int attBonuses = 0;
            attBonuses += pc.Head.AttributeBonusModifierWis;
            attBonuses += pc.Neck.AttributeBonusModifierWis;
            attBonuses += pc.Body.AttributeBonusModifierWis;
            attBonuses += pc.MainHand.AttributeBonusModifierWis;
            attBonuses += pc.OffHand.AttributeBonusModifierWis;
            attBonuses += pc.Ring1.AttributeBonusModifierWis;
            attBonuses += pc.Ring2.AttributeBonusModifierWis;
            attBonuses += pc.Feet.AttributeBonusModifierWis;
            return attBonuses;
        }
        public static int CalcAttributeModifierCha(CharBase pc)
        {
            int attBonuses = 0;
            attBonuses += pc.Head.AttributeBonusModifierCha;
            attBonuses += pc.Neck.AttributeBonusModifierCha;
            attBonuses += pc.Body.AttributeBonusModifierCha;
            attBonuses += pc.MainHand.AttributeBonusModifierCha;
            attBonuses += pc.OffHand.AttributeBonusModifierCha;
            attBonuses += pc.Ring1.AttributeBonusModifierCha;
            attBonuses += pc.Ring2.AttributeBonusModifierCha;
            attBonuses += pc.Feet.AttributeBonusModifierCha;
            return attBonuses;
        }
        //SD_20131127 End
        public static int CalcSavingThrowBonuses(CharBase pc, CharBase.SavingThrow savType) //SD_20131127 NO LONGER USED ...CAN DELETE
        {
            int savBonuses = 0;
            if (savType == pc.Head.SavingThrowBonusType)
            {
                savBonuses += pc.Head.SavingThrowBonusModifier;
            }
            if (savType == pc.Neck.SavingThrowBonusType)
            {
                savBonuses += pc.Neck.SavingThrowBonusModifier;
            }
            if (savType == pc.Body.SavingThrowBonusType)
            {
                savBonuses += pc.Body.SavingThrowBonusModifier;
            }
            if (savType == pc.MainHand.SavingThrowBonusType)
            {
                savBonuses += pc.MainHand.SavingThrowBonusModifier;
            }
            if (savType == pc.OffHand.SavingThrowBonusType)
            {
                savBonuses += pc.OffHand.SavingThrowBonusModifier;
            }
            if (savType == pc.Ring1.SavingThrowBonusType)
            {
                savBonuses += pc.Ring1.SavingThrowBonusModifier;
            }
            if (savType == pc.Ring2.SavingThrowBonusType)
            {
                savBonuses += pc.Ring2.SavingThrowBonusModifier;
            }
            if (savType == pc.Feet.SavingThrowBonusType)
            {
                savBonuses += pc.Feet.SavingThrowBonusModifier;
            }
            return savBonuses;
        } 
        //SD_20131127 Start
        public static int CalcSavingThrowModifiersReflex(CharBase pc)
        {
            int savBonuses = 0;
            savBonuses += pc.Head.SavingThrowModifierReflex;
            savBonuses += pc.Neck.SavingThrowModifierReflex;
            savBonuses += pc.Body.SavingThrowModifierReflex;
            savBonuses += pc.MainHand.SavingThrowModifierReflex;
            savBonuses += pc.OffHand.SavingThrowModifierReflex;
            savBonuses += pc.Ring1.SavingThrowModifierReflex;
            savBonuses += pc.Ring2.SavingThrowModifierReflex;
            savBonuses += pc.Feet.SavingThrowModifierReflex;
            return savBonuses;
        }
        public static int CalcSavingThrowModifiersFortitude(CharBase pc)
        {
            int savBonuses = 0;
            savBonuses += pc.Head.SavingThrowModifierFortitude;
            savBonuses += pc.Neck.SavingThrowModifierFortitude;
            savBonuses += pc.Body.SavingThrowModifierFortitude;
            savBonuses += pc.MainHand.SavingThrowModifierFortitude;
            savBonuses += pc.OffHand.SavingThrowModifierFortitude;
            savBonuses += pc.Ring1.SavingThrowModifierFortitude;
            savBonuses += pc.Ring2.SavingThrowModifierFortitude;
            savBonuses += pc.Feet.SavingThrowModifierFortitude;
            return savBonuses;
        }
        public static int CalcSavingThrowModifiersWill(CharBase pc)
        {
            int savBonuses = 0;
            savBonuses += pc.Head.SavingThrowModifierWill;
            savBonuses += pc.Neck.SavingThrowModifierWill;
            savBonuses += pc.Body.SavingThrowModifierWill;
            savBonuses += pc.MainHand.SavingThrowModifierWill;
            savBonuses += pc.OffHand.SavingThrowModifierWill;
            savBonuses += pc.Ring1.SavingThrowModifierWill;
            savBonuses += pc.Ring2.SavingThrowModifierWill;
            savBonuses += pc.Feet.SavingThrowModifierWill;
            return savBonuses;
        }
        //SD_20131127 End
        public static int CalcDamReduction(CharBase pc)
        {
            int armBonuses = 0;
            armBonuses += pc.Head.ItemDamageReduction;
            armBonuses += pc.Neck.ItemDamageReduction;
            armBonuses += pc.Body.ItemDamageReduction;
            armBonuses += pc.MainHand.ItemDamageReduction;
            armBonuses += pc.OffHand.ItemDamageReduction;
            armBonuses += pc.Ring1.ItemDamageReduction;
            armBonuses += pc.Ring2.ItemDamageReduction;
            armBonuses += pc.Feet.ItemDamageReduction;
            return armBonuses;
        }
        //SD_20131124 Start
        public static int CalcAcidModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueAcid;
            mod += pc.Neck.DamageTypeResistanceValueAcid;
            mod += pc.Body.DamageTypeResistanceValueAcid;
            mod += pc.MainHand.DamageTypeResistanceValueAcid;
            mod += pc.OffHand.DamageTypeResistanceValueAcid;
            mod += pc.Ring1.DamageTypeResistanceValueAcid;
            mod += pc.Ring2.DamageTypeResistanceValueAcid;
            mod += pc.Feet.DamageTypeResistanceValueAcid;
            return mod;
        }
        public static int CalcBludgeoningModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueBludgeoning;
            mod += pc.Neck.DamageTypeResistanceValueBludgeoning;
            mod += pc.Body.DamageTypeResistanceValueBludgeoning;
            mod += pc.MainHand.DamageTypeResistanceValueBludgeoning;
            mod += pc.OffHand.DamageTypeResistanceValueBludgeoning;
            mod += pc.Ring1.DamageTypeResistanceValueBludgeoning;
            mod += pc.Ring2.DamageTypeResistanceValueBludgeoning;
            mod += pc.Feet.DamageTypeResistanceValueBludgeoning;
            return mod;
        }
        public static int CalcColdModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueCold;
            mod += pc.Neck.DamageTypeResistanceValueCold;
            mod += pc.Body.DamageTypeResistanceValueCold;
            mod += pc.MainHand.DamageTypeResistanceValueCold;
            mod += pc.OffHand.DamageTypeResistanceValueCold;
            mod += pc.Ring1.DamageTypeResistanceValueCold;
            mod += pc.Ring2.DamageTypeResistanceValueCold;
            mod += pc.Feet.DamageTypeResistanceValueCold;
            return mod;
        }
        public static int CalcElectricityModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueElectricity;
            mod += pc.Neck.DamageTypeResistanceValueElectricity;
            mod += pc.Body.DamageTypeResistanceValueElectricity;
            mod += pc.MainHand.DamageTypeResistanceValueElectricity;
            mod += pc.OffHand.DamageTypeResistanceValueElectricity;
            mod += pc.Ring1.DamageTypeResistanceValueElectricity;
            mod += pc.Ring2.DamageTypeResistanceValueElectricity;
            mod += pc.Feet.DamageTypeResistanceValueElectricity;
            return mod;
        }
        public static int CalcFireModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueFire;
            mod += pc.Neck.DamageTypeResistanceValueFire;
            mod += pc.Body.DamageTypeResistanceValueFire;
            mod += pc.MainHand.DamageTypeResistanceValueFire;
            mod += pc.OffHand.DamageTypeResistanceValueFire;
            mod += pc.Ring1.DamageTypeResistanceValueFire;
            mod += pc.Ring2.DamageTypeResistanceValueFire;
            mod += pc.Feet.DamageTypeResistanceValueFire;
            return mod;
        }
        public static int CalcLightModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueLight;
            mod += pc.Neck.DamageTypeResistanceValueLight;
            mod += pc.Body.DamageTypeResistanceValueLight;
            mod += pc.MainHand.DamageTypeResistanceValueLight;
            mod += pc.OffHand.DamageTypeResistanceValueLight;
            mod += pc.Ring1.DamageTypeResistanceValueLight;
            mod += pc.Ring2.DamageTypeResistanceValueLight;
            mod += pc.Feet.DamageTypeResistanceValueLight;
            return mod;
        }
        public static int CalcMagicModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueMagic;
            mod += pc.Neck.DamageTypeResistanceValueMagic;
            mod += pc.Body.DamageTypeResistanceValueMagic;
            mod += pc.MainHand.DamageTypeResistanceValueMagic;
            mod += pc.OffHand.DamageTypeResistanceValueMagic;
            mod += pc.Ring1.DamageTypeResistanceValueMagic;
            mod += pc.Ring2.DamageTypeResistanceValueMagic;
            mod += pc.Feet.DamageTypeResistanceValueMagic;
            return mod;
        }
        public static int CalcPiercingModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValuePiercing;
            mod += pc.Neck.DamageTypeResistanceValuePiercing;
            mod += pc.Body.DamageTypeResistanceValuePiercing;
            mod += pc.MainHand.DamageTypeResistanceValuePiercing;
            mod += pc.OffHand.DamageTypeResistanceValuePiercing;
            mod += pc.Ring1.DamageTypeResistanceValuePiercing;
            mod += pc.Ring2.DamageTypeResistanceValuePiercing;
            mod += pc.Feet.DamageTypeResistanceValuePiercing;
            return mod;
        }
        public static int CalcPoisonModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValuePoison;
            mod += pc.Neck.DamageTypeResistanceValuePoison;
            mod += pc.Body.DamageTypeResistanceValuePoison;
            mod += pc.MainHand.DamageTypeResistanceValuePoison;
            mod += pc.OffHand.DamageTypeResistanceValuePoison;
            mod += pc.Ring1.DamageTypeResistanceValuePoison;
            mod += pc.Ring2.DamageTypeResistanceValuePoison;
            mod += pc.Feet.DamageTypeResistanceValuePoison;
            return mod;
        }
        public static int CalcSlashingModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueSlashing;
            mod += pc.Neck.DamageTypeResistanceValueSlashing;
            mod += pc.Body.DamageTypeResistanceValueSlashing;
            mod += pc.MainHand.DamageTypeResistanceValueSlashing;
            mod += pc.OffHand.DamageTypeResistanceValueSlashing;
            mod += pc.Ring1.DamageTypeResistanceValueSlashing;
            mod += pc.Ring2.DamageTypeResistanceValueSlashing;
            mod += pc.Feet.DamageTypeResistanceValueSlashing;
            return mod;
        }
        public static int CalcSonicModifiers(CharBase pc)
        {
            int mod = 0;
            mod += pc.Head.DamageTypeResistanceValueSonic;
            mod += pc.Neck.DamageTypeResistanceValueSonic;
            mod += pc.Body.DamageTypeResistanceValueSonic;
            mod += pc.MainHand.DamageTypeResistanceValueSonic;
            mod += pc.OffHand.DamageTypeResistanceValueSonic;
            mod += pc.Ring1.DamageTypeResistanceValueSonic;
            mod += pc.Ring2.DamageTypeResistanceValueSonic;
            mod += pc.Feet.DamageTypeResistanceValueSonic;
            return mod;
        }
        //SD_20131124 End
        //SD_20131029 Start
        public static void ReCalcSavingThrowBases(CharBase pc)
        {
            if (pc.Class.PlayerClassName != "newClass")
            {
                pc.BaseFortitude = pc.Class.BaseFortitudeAtLevel[pc.ClassLevel];
                pc.BaseReflex = pc.Class.BaseReflexAtLevel[pc.ClassLevel];
                pc.BaseWill = pc.Class.BaseWillAtLevel[pc.ClassLevel];
            }
        }
        //SD_20131029 End
    }
}
