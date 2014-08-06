//gaSetLocalInt.cs - Set a local Int (create a new one if currently doesn't exist)
//parm1 = (string) objectTag to which to attach this local variable (use "this" (without the quotes) or leave blank to use the convo owner's tag)
//parm2 = (string) local variable name
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
            if ((p1 == "this") || (p1 == ""))
            {
                p1 = sf.ConvoOwnerTag;
            }
            int parm3 = Convert.ToInt32(p3);
            sf.SetLocalInt(p1, p2 ,parm3);
        }
    }
}
