//gcCheckLocalInt.cs - Check to see if a Local Int has a value
//parm1 = (string) objectTag to which to attach this local variable (use "this" (without the quotes) or leave blank to use the convo owner's tag)
//parm2 = (string) local variable name
//parm3 = (string) compare type ( = , < , > , ! )
//parm4 = (int) value
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
            if ((p1 == "this") || (p1 == ""))
            {
                p1 = sf.ConvoOwnerTag;
            }
            int parm4 = Convert.ToInt32(p4);
            sf.gm.returnCheck = sf.CheckLocalInt(p1, p2, p3, parm4);
        }
    }
}
