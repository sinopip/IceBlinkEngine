//gcCheckGlobalInt.cs - Check to see if a global Int has a value
//parm1 = (string) global variable name
//parm2 = (string) compare type ( = , < , > , ! )
//parm3 = (int) value
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
            int parm3 = Convert.ToInt32(p3);
            sf.gm.returnCheck = sf.CheckGlobalInt(p1,p2,parm3);
        }
    }
}
