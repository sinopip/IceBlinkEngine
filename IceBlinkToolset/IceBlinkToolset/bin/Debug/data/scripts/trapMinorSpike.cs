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
            //MessageBox.Show("Minor Spike Trap triggered");
            foreach (PC pc in sf.gm.playerList.PCList)
            {
                int damage = sf.gm.Random(4);
                sf.DrawFloatyTextOverSquare("Spike Trap! " + pc.Name + " takes " + damage.ToString() + " damage", sf.gm.playerPosition.X, sf.gm.playerPosition.Y, 50, Color.Red, Color.Black);
                pc.HP = pc.HP - damage;
                if (pc.HP <= 0)
                {
                    sf.DrawFloatyTextOverSquare(pc.Name + " was killed", sf.gm.playerPosition.X, sf.gm.playerPosition.Y, 50, Color.Red, Color.Black);
                    pc.Status = PC.charStatus.Dead;
                }
            }
        }
    }
}
