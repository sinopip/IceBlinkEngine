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
            int xShift = 55;
            // C# code goes here
            if (sf.passParameterScriptObject is PC)
            {
                PC pc = (PC)sf.passParameterScriptObject;
                string text = "";
                int x = pc.CombatLocation.X * sf.gm._squareSize - sf.gm._squareSize;
                int y = pc.CombatLocation.Y * sf.gm._squareSize;

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

                text = pc.Name;
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y, 0, text, 150, 255, Color.White, Color.Black);
                text = "HP: " + pc.HP + "  SP: " + pc.SP + "  AC: " + pc.AC;
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y + 15, 0, text, 150, 255, Color.White, Color.Black);
                if ((pc.Status == CharBase.charStatus.Dead) && (pc.HP <= -20))
                {
                    text = "Status: Dead";
                }
                else if ((pc.Status == CharBase.charStatus.Dead) && (pc.HP > -20))
                {
                    text = "Status: Unconscious";
                }
                else
                {
                    text = "Status: " + pc.Status.ToString();
                }                
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y + 30, 0, text, 150, 255, Color.White, Color.Black);
                text = "Weapon: " + pc.MainHand.ItemName;
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y + 45, 0, text, 150, 255, Color.White, Color.Black);
                text = "BAB: +" + pc.BaseAttBonus + "  ToHit: +" + attackMod;
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y + 60, 0, text, 150, 255, Color.White, Color.Black);
            }
            else if (sf.passParameterScriptObject is Creature)
            {
                Creature crt = (Creature)sf.passParameterScriptObject;
                string text = "";
                int x = crt.CombatLocation.X * sf.gm._squareSize - sf.gm._squareSize;
                int y = crt.CombatLocation.Y * sf.gm._squareSize;

                text = crt.Name;
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y, 0, text, 150, 255, Color.White, Color.Black);
                text = "HP: " + crt.HP + "  SP: " + crt.SP + "  AC: " + crt.AC;
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y + 15, 0, text, 150, 255, Color.White, Color.Black);
                text = "Status: " + crt.Status.ToString();
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y + 30, 0, text, 150, 255, Color.White, Color.Black);
                text = "Attack: " + crt.Attack.ToString();
                sf.gm.DrawCombatTextShadowOutlineMainMap(x - xShift, y + 45, 0, text, 150, 255, Color.White, Color.Black);
            }
        }        
    }
}
