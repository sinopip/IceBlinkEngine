//TindraHint.cs
//parm1 = none
//parm2 = none
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
            int currentValue = sf.GetGlobalInt("TindraHint");
            if (currentValue == -1) //this is our first hint so set to 1
            {
                sf.SetGlobalInt("TindraHint", 1);
            }
            else //we have hints so increment by one
            {
                currentValue++;
                sf.SetGlobalInt("TindraHint", currentValue);
            }
            //once we discover two hints or the letter, we have enough to uncover Tindra's plot
            if (currentValue > 1)
            {
                sf.SetGlobalInt("TindraDiscover", 1);
            }
        }
    }
}
