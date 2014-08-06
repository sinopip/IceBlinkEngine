// itModifyAttributePermanently.cs
// parm1 = (string) Attribute to modify (str, con, int, dex, wis, cha)
// parm2 = (string) Type of modification ( = , + , - )
// parm3 = (int) Amount of modification
// example: (str, =, 15) will change the PC's base strength to 15
// example: (wis, +, 2) will increase the PC's wisdom by 2
// example: (cha, -, 4) will decrease the PC's charisma by 4
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
            int PCindex = sf.gm.indexOfPCtoLastUseItem;
            PC pc = sf.gm.playerList.PCList[PCindex];

            int parm3 = Convert.ToInt32(p3);

            if (p1 == "str")
            {
                if (p2 == "=")
                {
                    pc.BaseStr = parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s base Strength is now " + pc.BaseStr.ToString());
                }
                else if (p2 == "+")
                {
                    pc.BaseStr += parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Strength increases by " + parm3.ToString());
                }
                else if (p2 == "-")
                {
                    pc.BaseStr -= parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Strength decreases by " + parm3.ToString());
                }
                else
                {
                    //IBMessageBox.Show(sf.gm, "did not recognize the mod type parameter");
                }
            }
            else if (p1 == "dex")
            {
                if (p2 == "=")
                {
                    pc.BaseDex = parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s base Dexterity is now " + parm3.ToString());
                }
                else if (p2 == "+")
                {
                    pc.BaseDex += parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Dexterity increases by " + parm3.ToString());
                }
                else if (p2 == "-")
                {
                    pc.BaseDex -= parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Dexterity decreases by " + parm3.ToString());
                }
                else
                {
                    //IBMessageBox.Show(sf.gm, "did not recognize the mod type parameter");
                }
            }
            else if (p1 == "con")
            {
                if (p2 == "=")
                {
                    pc.BaseCon = parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s base Constitution is now " + parm3.ToString());
                }
                else if (p2 == "+")
                {
                    pc.BaseCon += parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Constitution increases by " + parm3.ToString());
                }
                else if (p2 == "-")
                {
                    pc.BaseCon -= parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Constitution decreases by " + parm3.ToString());
                }
                else
                {
                    //IBMessageBox.Show(sf.gm, "did not recognize the mod type parameter");
                }
            }
            else if (p1 == "int")
            {
                if (p2 == "=")
                {
                    pc.BaseInt = parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s base Intelligence is now " + parm3.ToString());
                }
                else if (p2 == "+")
                {
                    pc.BaseInt += parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Intelligence increases by " + parm3.ToString());
                }
                else if (p2 == "-")
                {
                    pc.BaseInt -= parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Intelligence decreases by " + parm3.ToString());
                }
                else
                {
                    //IBMessageBox.Show(sf.gm, "did not recognize the mod type parameter");
                }
            }
            else if (p1 == "wis")
            {
                if (p2 == "=")
                {
                    pc.BaseWis = parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s base Wisdom is now " + parm3.ToString());
                }
                else if (p2 == "+")
                {
                    pc.BaseWis += parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Wisdom increases by " + parm3.ToString());
                }
                else if (p2 == "-")
                {
                    pc.BaseWis -= parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Wisdom decreases by " + parm3.ToString());
                }
                else
                {
                    //IBMessageBox.Show(sf.gm, "did not recognize the mod type parameter");
                }
            }
            else if (p1 == "cha")
            {
                if (p2 == "=")
                {
                    pc.BaseCha = parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s base Charisma is now " + parm3.ToString());
                }
                else if (p2 == "+")
                {
                    pc.BaseCha += parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Charisma increases by " + parm3.ToString());
                }
                else if (p2 == "-")
                {
                    pc.BaseCha -= parm3;
                    IBMessageBox.Show(sf.gm, pc.Name + "'s Charisma decreases by " + parm3.ToString());
                }
                else
                {
                    //IBMessageBox.Show(sf.gm, "did not recognize the mod type parameter");
                }
            }
            sf.gm.deleteItemUsedScript = true;
        }
    }
}
