//gaSetGlobalInt.cs - Set a global Int (create a new one if currently doesn't exist)
//parm1 = (string) global variable name
//parm2 = (int) value or (string) increment "++" or (string) decrement "--"
//parm3 = none
//parm4 = none
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            if (p2 == "++")
            {
                int currentValue = sf.GetGlobalInt(p1);
                if (currentValue == -1) //this is our first time using this variable so set to 1
                {
                    sf.SetGlobalInt(p1, 1);
                }
                else //we have the variable so increment by one
                {
                    currentValue++;
                    sf.SetGlobalInt(p1, currentValue);
                }
            }
            else if (p2 == "--")
            {
                int currentValue = sf.GetGlobalInt(p1);
                if (currentValue == -1) //this is our first time using this variable so set to 1
                {
                    sf.SetGlobalInt(p1, 0);
                }
                else //we have the variable so decrement by one
                {
                    currentValue--;
                    if (currentValue < 0) { currentValue = 0; }
                    sf.SetGlobalInt(p1, currentValue);
                }
            }
            else
            {
                int parm2 = Convert.ToInt32(p2);
                sf.SetGlobalInt(p1, parm2);
            }
        }
    }
}
