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
        public CharacterSheet PcSheet = new CharacterSheet();
        public RichTextBox rtxtMisc = new RichTextBox();
        public RichTextBox rtxtAtt = new RichTextBox();

        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            PcSheet = sf.currentCharacterSheet;
            rtxtMisc = PcSheet.rtxtMisc;
            rtxtAtt = PcSheet.rtxtAttributes;
            PC pc = PcSheet.pc_character;

            rtxtAtt.SelectionTabs = new int[] { 25, 50, 75, 100 }; //changes the default spacing between tabs (in pixels)
            //int strRaceMod = pc.Race.StrMod;
            //int dexRaceMod = pc.Race.DexMod;
            //int intRaceMod = pc.Race.IntMod;
            //int chaRaceMod = pc.Race.ChaMod;
            //int conRaceMod = pc.Race.ConMod;
            //int wisRaceMod = pc.Race.WisMod;
            //int strE = (pc.BaseStr + strRaceMod - 10) / 2;
            int strE = (pc.Strength - 10) / 2;
            string strMod = strE.ToString("+#;-#;0");
            int dexE = ((pc.Dexterity - 10) / 2);
            string dexMod = dexE.ToString("+#;-#;0");
            int intE = ((pc.Intelligence - 10) / 2);
            string intMod = intE.ToString("+#;-#;0");
            int chaE = ((pc.Charisma - 10) / 2);
            string chaMod = chaE.ToString("+#;-#;0");
            int conE = ((pc.Constitution - 10) / 2);
            string conMod = conE.ToString("+#;-#;0");
            int wisE = ((pc.Wisdom - 10) / 2);
            string wisMod = wisE.ToString("+#;-#;0");
            rtxtAtt.Clear();
            AddTextAtt("STR: \t" + pc.Strength + "\t(" + strMod + ")", Color.Black);
            AddTextAtt("DEX: \t" + pc.Dexterity + "\t(" + dexMod + ")", Color.Black);
            AddTextAtt("CON: \t" + pc.Constitution + "\t(" + conMod + ")", Color.Black);
            AddTextAtt("INT: \t" + pc.Intelligence + "\t(" + intMod + ")", Color.Black);
            AddTextAtt("WIS: \t" + pc.Wisdom + "\t(" + wisMod + ")", Color.Black);
            AddTextAtt("CHA: \t" + pc.Charisma + "\t(" + chaMod + ")", Color.Black);
            AddTextAtt("--------------------", Color.Black);
            AddTextAtt("HP: " + pc.HP + " / " + pc.HPMax, Color.Black);
            AddTextAtt("SP: " + pc.SP + " / " + pc.SPMax, Color.Black);
            //AddTextAtt("AC: " + pc.AC, Color.Black);
            if ((pc.Status == CharBase.charStatus.Dead) && (pc.HP <= -20))
            {
                AddTextAtt("Status: Dead", Color.Black);
            }
            else if ((pc.Status == CharBase.charStatus.Dead) && (pc.HP > -20))
            {
                AddTextAtt("Status: Unconscious", Color.Black);
            }
            else
            {
                AddTextAtt("Status: " + pc.Status.ToString(), Color.Black);
            }

            rtxtMisc.Clear();
            AddText("NAME: " + pc.Name, Color.Black, true, sf.gm.module.ModuleTheme.ModuleFontName, 12.0f);
            AddText("RACE: " + pc.Race.ToString(), Color.Black);
            AddText("GENDER: " + pc.Gender.ToString(), Color.Black);
            AddText("CLASS: " + pc.Class.ToString(), Color.Black);
            //AddText("ALIGNMENT: " + pc.AlignLawChaos.ToString() + " " + pc.AlignGoodEvil.ToString(), Color.Black);
            AddText("LEVEL: " + pc.ClassLevel, Color.Black);
            AddText("XP: " + pc.XP, Color.Black);
            //AddText("NEXT LVL: " + pc.XPNeeded, Color.Black, true, sf.gm.module.ModuleTheme.ModuleFontName, sf.gm.module.ModuleTheme.ModuleFontPointSize, FontStyle.Strikeout | FontStyle.Italic | FontStyle.Bold);
            AddText("NEXT LVL: " + pc.XPNeeded, Color.Black);
            AddText("-------------------------------", Color.Black);
            AddText("Fortitude: " + pc.Fortitude, Color.Black);
            AddText("Reflex: " + pc.Reflex, Color.Black);
            AddText("Will: " + pc.Will, Color.Black);
            AddText("-------------------------------", Color.Black);
            AddText("Effects" + "\t\t" + "Time Left", Color.Black, true, sf.gm.module.ModuleTheme.ModuleFontName, sf.gm.module.ModuleTheme.ModuleFontPointSize, FontStyle.Underline);
            foreach (Effect ef in pc.EffectsList.effectsList)
            {
                int remain = ef.DurationInUnits - ef.CurrentDurationInUnits;
                AddText(ef.EffectName + "\t" + remain.ToString(), Color.Black);
            }
            AddText("-------------------------------", Color.Black);
            AddText("AC: " + pc.AC, Color.Black);
            AddText("DR: " + pc.TotalDamageReduction, Color.Black);
            AddText("Move: " + pc.MoveDistance, Color.Black);
            AddText("-------------------------------", Color.Black);
            AddText("BAB: +" + pc.BaseAttBonus, Color.Black);
            AddText("Main Hand: " + pc.MainHand.ItemName, Color.Black);
            AddText("Damage: " + pc.MainHand.ItemDamageNumberOfDice + "d" + pc.MainHand.ItemDamageDie, Color.Black);
            int modifier = 0;
            if ((pc.MainHand.ItemCategory == Item.category.Melee) || (pc.MainHand.ItemName == ""))
            {
                modifier = (pc.Strength - 10) / 2;
            }
            else //ranged weapon used
            {
                modifier = (pc.Dexterity - 10) / 2;
            }
            int attackMod = modifier + pc.BaseAttBonus + pc.MainHand.ItemAttackBonus;
            AddText("ToHit: +" + attackMod, Color.Black);
            AddText("-------------------------------", Color.Black);
            AddText("Resistances", Color.Black, true, sf.gm.module.ModuleTheme.ModuleFontName, sf.gm.module.ModuleTheme.ModuleFontPointSize, FontStyle.Underline);
            if (pc.DamageTypeResistanceTotalAcid != 0) { AddText("Acid: " + pc.DamageTypeResistanceTotalAcid.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalBludgeoning != 0) { AddText("Bludgeoning: " + pc.DamageTypeResistanceTotalBludgeoning.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalCold != 0) { AddText("Cold: " + pc.DamageTypeResistanceTotalCold.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalElectricity != 0) { AddText("Electricity: " + pc.DamageTypeResistanceTotalElectricity.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalFire != 0) { AddText("Fire: " + pc.DamageTypeResistanceTotalFire.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalLight != 0) { AddText("Light: " + pc.DamageTypeResistanceTotalLight.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalMagic != 0) { AddText("Magic: " + pc.DamageTypeResistanceTotalMagic.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalPiercing != 0) { AddText("Piercing: " + pc.DamageTypeResistanceTotalPiercing.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalSlashing != 0) { AddText("Slashing: " + pc.DamageTypeResistanceTotalSlashing.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalSonic != 0) { AddText("Sonic: " + pc.DamageTypeResistanceTotalSonic.ToString(), Color.Black); }
            if (pc.DamageTypeResistanceTotalPoison != 0) { AddText("Poison: " + pc.DamageTypeResistanceTotalPoison.ToString(), Color.Black); }
        }

        public void AddText(string text, Color color)
        {
            rtxtMisc.SelectionColor = color;
            rtxtMisc.AppendText(text);
            rtxtMisc.AppendText(Environment.NewLine);
        }
        public void AddText(string text, Color color, bool newLine)
        {
            rtxtMisc.SelectionColor = color;
            rtxtMisc.AppendText(text);
            if (newLine)
            {
                rtxtMisc.AppendText(Environment.NewLine);
            }
        }
        public void AddText(string text, Color color, bool newLine, string fontName, float fontSize)
        {
            rtxtMisc.SelectionColor = color;
            rtxtMisc.SelectionFont = new Font(fontName, fontSize);
            rtxtMisc.AppendText(text);
            if (newLine)
            {
                rtxtMisc.AppendText(Environment.NewLine);
            }
        }
        public void AddText(string text, Color color, bool newLine, string fontName, float fontSize, FontStyle fontStyle)
        {
            rtxtMisc.SelectionColor = color;
            rtxtMisc.SelectionFont = new Font(fontName, fontSize, fontStyle);
            rtxtMisc.AppendText(text);
            if (newLine)
            {
                rtxtMisc.AppendText(Environment.NewLine);
            }
        }

        public void AddTextAtt(string text, Color color)
        {
            rtxtAtt.SelectionColor = color;
            rtxtAtt.AppendText(text);
            rtxtAtt.AppendText(Environment.NewLine);
        }
        public void AddTextAtt(string text, Color color, bool newLine)
        {
            rtxtAtt.SelectionColor = color;
            rtxtAtt.AppendText(text);
            if (newLine)
            {
                rtxtAtt.AppendText(Environment.NewLine);
            }
        }
        public void AddTextAtt(string text, Color color, bool newLine, string fontName, float fontSize)
        {
            rtxtAtt.SelectionColor = color;
            rtxtAtt.SelectionFont = new Font(fontName, fontSize);
            rtxtAtt.AppendText(text);
            if (newLine)
            {
                rtxtAtt.AppendText(Environment.NewLine);
            }
        }
        public void AddTextAtt(string text, Color color, bool newLine, string fontName, float fontSize, FontStyle fontStyle)
        {
            rtxtAtt.SelectionColor = color;
            rtxtAtt.SelectionFont = new Font(fontName, fontSize, fontStyle);
            rtxtAtt.AppendText(text);
            if (newLine)
            {
                rtxtAtt.AppendText(Environment.NewLine);
            }
        }
    }
}
