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
            //Form1 prntForm = new Form1();
            //prntForm.testMessage();
            //MessageBox.Show("entered script");
            if (sf.gm.module.ModuleGlobalInts.Count == 0)
            {
                newCharacterStuff(sf);

                GlobalInt newGlobal = new GlobalInt();
                newGlobal.Key = "addPCdone";
                newGlobal.Value = 1;
                sf.gm.module.ModuleGlobalInts.Add(newGlobal);
                MessageBox.Show("completed the script");
            }
            else
            {
                int found1 = 0;
                foreach (GlobalInt variable in sf.gm.module.ModuleGlobalInts)
                {
                    //MessageBox.Show("variable.Key = " + variable.Key + "   variable.Value = " + variable.Value);
                    if (variable.Key == "addPCdone")
                    {
                        found1 = 1;
                        //MessageBox.Show("variable.Key == addPCdone");
                        if (variable.Value != 1)
                        {
                            //MessageBox.Show("variable.Value != 1");
                            newCharacterStuff(sf);

                            //check if variable is equal
                            int exists = 0;
                            foreach (GlobalInt variable2 in sf.gm.module.ModuleGlobalInts)
                            {
                                if (variable2.Key == "addPCdone")
                                {
                                    variable2.Value = 1;
                                    exists = 1;
                                }
                            }
                            if (exists == 0)
                            {
                                GlobalInt newGlobal = new GlobalInt();
                                newGlobal.Key = "addPCdone";
                                newGlobal.Value = 1;
                                sf.gm.module.ModuleGlobalInts.Add(newGlobal);
                            }
                        }
                    }
                }
                if (found1 == 0)
                {
                    newCharacterStuff(sf);

                    GlobalInt newGlobal = new GlobalInt();
                    newGlobal.Key = "addPCdone";
                    newGlobal.Value = 1;
                    sf.gm.module.ModuleGlobalInts.Add(newGlobal);
                    //MessageBox.Show("completed the script");
                }
            }
        }

        public void newCharacterStuff(ScriptFunctions sf)
        {
            PC newCharacter = new PC();
            newCharacter.Name = "Drinian";
            newCharacter.MainHand = sf.gm.module.ModuleItemsList.itemsList[0];
            newCharacter.BaseStr = 14;
            newCharacter.BaseDex = 14;
            newCharacter.BaseInt = 10;
            newCharacter.BaseCha = 10;
            newCharacter.BaseCon = 10;
            newCharacter.BaseWis = 10;
            newCharacter.HP = 12;
            newCharacter.HPMax = 12;
            newCharacter.PortraitFileG = "HEMT_G.png";
            newCharacter.PortraitFileL = "HEMT_L.png";
            newCharacter.PortraitFileM = "HEMT_M.png";
            newCharacter.PortraitFileS = "HEMT_S.png";
            newCharacter.SpriteFilename = "drinian.spt";
	    newCharacter.LoadSpriteStuff(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\sprites");
            sf.gm.playerList.PCList.Add(newCharacter);
            sf.gm.addPCScriptFired = true;
            sf.gm.uncheckConvo = true;
        }
    }
}
