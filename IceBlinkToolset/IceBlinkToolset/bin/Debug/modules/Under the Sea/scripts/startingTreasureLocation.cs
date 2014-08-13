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
            // C# code goes here
            Form1 f = sf.frm;

            int rnd = sf.gm.Random(8);
            if (sf.frm.debugMode)
            {
               f.logText("rnd = " + rnd.ToString(), Color.Silver);
               f.logText(Environment.NewLine, Color.Silver);
            }

            Prop chest = sf.gm.currentArea.AreaPropList.getPropByTag("chestprop");

            if (chest == null)
            {
                f.logText("chest is null", Color.Silver);
                f.logText(Environment.NewLine, Color.Silver);
                return; 
            }
            if (sf.frm.debugMode)
            {
               f.logText("chest is at (" + chest.Location.X.ToString() + ", " + chest.Location.Y.ToString() + ")", Color.Silver);
               f.logText(Environment.NewLine, Color.Silver);
            }

            switch (rnd)
            {
                case 1:
                    chest.Location = new Point(1, 14);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (1, 14)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                case 2:
                    chest.Location = new Point(7, 14);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (7, 14)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                case 3:
                    chest.Location = new Point(1, 8);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (1, 8)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                case 4:
                    chest.Location = new Point(14, 14);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (14, 14)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                case 5:
                    chest.Location = new Point(14, 7);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (14, 7)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                case 6:
                    chest.Location = new Point(14, 1);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (14, 1)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                case 7:
                    chest.Location = new Point(1, 3);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (1, 3)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                case 8:
                    chest.Location = new Point(3, 3);
                    if (sf.frm.debugMode)
                    {
                        f.logText("chest is now at (3, 3)", Color.Silver);
                        f.logText(Environment.NewLine, Color.Silver);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
