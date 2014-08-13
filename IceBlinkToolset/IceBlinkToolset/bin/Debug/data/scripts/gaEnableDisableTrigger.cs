//gaEnableDisableTrigger.cs - Enables or Disables a Trigger
//parm1 = (string) the tag of the trigger
//parm2 = (bool) true = enable, false = disable
//parm3 = not used
//parm4 = not used
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
            bool parm2 = Convert.ToBoolean(p2);
            sf.EnableDisableTrigger(p1,parm2);
        }
    }
}
