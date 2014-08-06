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
        public RichTextBox RtxtInfo = new RichTextBox();

        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            RtxtInfo = sf.frm.currentCombat.rtxtInfo;
            RtxtInfo.SelectionTabs = new int[] { 25, 50, 75, 100 }; //changes the default spacing between tabs (in pixels)

            if (sf.passParameterScriptObject is PC)
            {
                PC pc = (PC)sf.passParameterScriptObject;
                RtxtInfo.Clear();
                AddText(pc.Name, Color.Black, true, sf.gm.module.ModuleTheme.ModuleFontName, 12.0f);
                AddText("HP: " + pc.HP + "\t\tSP: " + pc.SP, Color.Black);
                if ((pc.Status == CharBase.charStatus.Dead) && (pc.HP <= -20))
                {
                    AddText("Status: Dead", Color.Black);
                }
                else if ((pc.Status == CharBase.charStatus.Dead) && (pc.HP > -20))
                {
                    AddText("Status: Unconscious", Color.Black);
                }
                else
                {
                    AddText("Status: " + pc.Status.ToString(), Color.Black);
                }
                //AddText("Status: " + pc.Status.ToString(), Color.Black);
                AddText("Weapon: " + pc.MainHand.ItemName, Color.Black);
                AddText("BAB: +" + pc.BaseAttBonus, Color.Black, false);
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
                AddText("\t\tToHit: +" + attackMod, Color.Black);                              // "\t" is a tab command
            }
            else if (sf.passParameterScriptObject is Creature)
            {
                Creature crt = (Creature)sf.passParameterScriptObject;
                RtxtInfo.Clear();
                AddText(crt.Name, Color.Black, true, sf.gm.module.ModuleTheme.ModuleFontName, 12.0f);
                AddText("HP: " + crt.HP + "   SP: " + crt.SP, Color.Black);
                AddText("Status: " + crt.Status.ToString(), Color.Black);
                AddText("Attack: +" + crt.Attack, Color.Black);
            }
        }

        public void AddText(string text, Color color)
        {
            RtxtInfo.SelectionColor = color;
            RtxtInfo.AppendText(text);
            RtxtInfo.AppendText(Environment.NewLine);
        }
        public void AddText(string text, Color color, bool newLine)
        {
            RtxtInfo.SelectionColor = color;
            RtxtInfo.AppendText(text);
            if (newLine)
            {
                RtxtInfo.AppendText(Environment.NewLine);
            }
        }
        public void AddText(string text, Color color, bool newLine, string fontName, float fontSize)
        {
            RtxtInfo.SelectionColor = color;
            RtxtInfo.SelectionFont = new Font(fontName, fontSize);
            RtxtInfo.AppendText(text);
            if (newLine)
            {
                RtxtInfo.AppendText(Environment.NewLine);
            }
        }
        public void AddText(string text, Color color, bool newLine, string fontName, float fontSize, FontStyle fontStyle)
        {
            RtxtInfo.SelectionColor = color;
            RtxtInfo.SelectionFont = new Font(fontName, fontSize, fontStyle);
            RtxtInfo.AppendText(text);
            if (newLine)
            {
                RtxtInfo.AppendText(Environment.NewLine);
            }
        }
    }
}
