//encOnFleeCombat
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
            //int roundNumber = (int)sf.passParameterScriptObject; //passing in current number of rounds at the time that "Run Away" was pressed
            IBMessageBox.Show(sf.gm, "You can not flee from this battle...All of Charn is counting on you!");
            sf.returnScriptObject = false; //true = flee was successful, false = failed to flee, stay in combat (combat screen will not close at this time)
        }
    }
}
