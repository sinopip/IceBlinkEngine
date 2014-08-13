//gcCheckFunds.cs - Checks to see if party has enough funds.
//parm1 = (int) check amount of funds equal to or greater
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
            int parm1 = Convert.ToInt32(p1);
            sf.gm.returnCheck = sf.CheckFunds(parm1);
        }
    }
}
