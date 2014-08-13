//gaEnableDisableTriggerEvent.cs - Enables or disables a Trigger Event
//parm1 = (string) the tag of the trigger
//parm2 = (int) event number to enable/disable
//parm3 = (bool) true = enable, false = disable
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
            int parm2 = Convert.ToInt32(p2);
            bool parm3 = Convert.ToBoolean(p3);
            sf.EnableDisableTriggerEvent(p1, parm2, parm3);
        }
    }
}
