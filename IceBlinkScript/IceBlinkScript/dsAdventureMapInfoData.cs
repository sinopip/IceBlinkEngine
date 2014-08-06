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
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            int xShift = 55;
            // C# code goes here
            if (sf.passParameterScriptObject is Prop)
            {
                Prop prp = (Prop)sf.passParameterScriptObject;
                string text = "";
                int x = prp.Location.X * sf.gm._squareSize - sf.gm._squareSize;
                int y = prp.Location.Y * sf.gm._squareSize;

                if (prp.Visible)
                {
                    text = prp.MouseOverText;
                    sf.gm.DrawTextShadowOutlineMainMap(x - xShift, y, 0, text, 150, 255, Color.White, Color.Black);
                }
            }
            else if (sf.passParameterScriptObject is Creature)
            {
                Creature crt = (Creature)sf.passParameterScriptObject;
                string text = "";
                int x = crt.MapLocation.X * sf.gm._squareSize - sf.gm._squareSize;
                int y = crt.MapLocation.Y * sf.gm._squareSize;

                if (crt.Visible)
                {
                    text = crt.MouseOverText;
                    sf.gm.DrawTextShadowOutlineMainMap(x - xShift, y, 0, text, 150, 255, Color.White, Color.Black);
                }
            }
        }        
    }
}
