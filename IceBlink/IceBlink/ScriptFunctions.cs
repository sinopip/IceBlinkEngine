using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using IceBlinkCore;

namespace IceBlink
{
    public class ScriptFunctions
    {
        public Form1 frm;
        public Game gm;

        public ScriptFunctions()
        {
        }
        public void passRefs(Form1 f, Game g)
        {
            frm = f;
            gm = g;
        }
        public void SetSquareCollidable(string areaFilename, int x, int y, bool collidable)
        {
            foreach (Area ar in gm.module.ModuleAreasObjects)
            {
                if (ar.AreaFileName == areaFilename)
                {
                    //will change the square to be walkable or non-walkable based on the input of "collidable"
                    ar.TileMapList[y * ar.MapSizeInSquares.Width + x].collidable = collidable;
                }
            }
        }
        public void AddCharacterToParty(string filename)
        {
            try
            {
                string jobDir = gm.mainDirectory + "\\modules\\" + gm.module.ModuleFolderName + "\\characters";
                string spriteFolder = gm.mainDirectory + "\\modules\\" + gm.module.ModuleFolderName + "\\graphics\\sprites";
                //load the character file
                PC newPC = new PC();
                newPC.passRefs(gm, null);
                newPC = newPC.loadPCFile(jobDir + "\\" + filename);
                newPC.passRefs(gm, null);
                newPC.LoadAllPcStuff(spriteFolder);
                //check to see if already in party before adding
                bool foundOne = false;
                foreach (PC pc in gm.playerList.PCList)
                {
                    if (newPC.Tag == pc.Tag)
                    {
                        foundOne = true;
                    }
                }
                if (!foundOne)
                {
                    gm.playerList.PCList.Add(newPC);
                    gm.addPCScriptFired = true;
                    gm.uncheckConvo = true;

                    if (gm.playerList.PCList.Count > 3)
                    {
                        frm.pc_button_3.Enabled = true;
                        frm.pcInventory.rbtnPc3.Enabled = true;
                        frm.pc_button_3.Image = (Image)gm.playerList.PCList[3].portraitBitmapM;
                        frm.pcSheet3.passRefs(frm, gm, 3);
                        frm.pcSheet3.refreshSheet();
                    }
                    if (gm.playerList.PCList.Count > 2)
                    {
                        frm.pc_button_2.Enabled = true;
                        frm.pcInventory.rbtnPc2.Enabled = true;
                        frm.pc_button_2.Image = (Image)gm.playerList.PCList[2].portraitBitmapM;
                        frm.pcSheet2.passRefs(frm, gm, 2);
                        frm.pcSheet2.refreshSheet();
                    }
                    if (gm.playerList.PCList.Count > 1)
                    {
                        frm.pc_button_1.Enabled = true;
                        frm.pcInventory.rbtnPc1.Enabled = true;
                        frm.pc_button_1.Image = (Image)gm.playerList.PCList[1].portraitBitmapM;
                        frm.pcSheet1.passRefs(frm, gm, 1);
                        frm.pcSheet1.refreshSheet();
                    }
                    if (gm.playerList.PCList.Count > 0)
                    {
                        frm.pc_button_0.Enabled = true;
                        frm.pcInventory.rbtnPc0.Enabled = true;
                        frm.pc_button_0.Image = (Image)gm.playerList.PCList[0].portraitBitmapM;
                        frm.pcSheet0.passRefs(frm, gm, 0);
                        frm.pcSheet0.refreshSheet();
                    }
                    frm.doPortraitStats();
                }
                else
                {
                    MessageBox.Show("This PC is already in the party");
                }
            }
            catch
            {
                MessageBox.Show("failed to load character from character folder");
            }            
        }
        public Creature getScriptOwnerCreature()
        {
            return gm.scriptOwnerCreature;
        }
        public void EnableDisableTrigger(string tag, bool enable)
        {
            try
            {
                Trigger trig = gm.currentArea.AreaTriggerList.getTriggerByTag(tag);
                trig.Enabled = enable;
            }
            catch
            {
                MessageBox.Show("can't find designated trigger tag in this area");
            }
        }
        public void EnableDisableTriggerEvent(string tag, int eventNumber, bool enable)
        {
            try
            {
                Trigger trig = gm.currentArea.AreaTriggerList.getTriggerByTag(tag);
                if (eventNumber == 1)
                {
                    trig.EnabledEvent1 = enable;
                }
                else if (eventNumber == 2)
                {
                    trig.EnabledEvent2 = enable;
                }
                else if (eventNumber == 3)
                {
                    trig.EnabledEvent3 = enable;
                }
                else if (eventNumber == 4)
                {
                    trig.EnabledEvent4 = enable;
                }
                else if (eventNumber == 5)
                {
                    trig.EnabledEvent5 = enable;
                }
                else if (eventNumber == 6)
                {
                    trig.EnabledEvent6 = enable;
                }
            }
            catch
            {
                MessageBox.Show("can't find designated trigger tag in this area");
            }
        }
        public void GiveFunds(int amount)
        {
            gm.partyGold += amount;
        }
        public void GiveItem(string tag, int quantity)
        {
            Item newItem = gm.module.ModuleItemsList.getItemByTag(tag).DeepCopy();
            for (int i = 0; i < quantity; i++)
            {
                gm.partyInventoryList.Add(newItem);
            }
        }
        public void GiveXP(int amount)
        {
            if (gm.playerList.PCList.Count > 0)
            {
                int xpToGive = amount / gm.playerList.PCList.Count;
                //give xp to each PC member...split the value given
                foreach (PC givePcXp in gm.playerList.PCList)
                {
                    givePcXp.XP += xpToGive;
                }
            }
        }
        public void SetGlobalInt(string variableName, int value)
        {
            int exists = 0;
            foreach (GlobalInt variable in gm.module.ModuleGlobalInts)
            {
                if (variable.Key == variableName)
                {
                    variable.Value = value;
                    exists = 1;
                }
            }
            if (exists == 0)
            {
                GlobalInt newGlobal = new GlobalInt();
                newGlobal.Key = variableName;
                newGlobal.Value = value;
                gm.module.ModuleGlobalInts.Add(newGlobal);
            }
        }
        public void TakeItem(string tag, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                bool FoundOne = false;
                int cnt = 0;
                foreach (Item item in gm.partyInventoryList)
                {
                    if (!FoundOne)
                    {
                        if (item.ItemTag == tag)
                        {
                            gm.partyInventoryList.RemoveAt(cnt);
                            FoundOne = true;
                        }
                    }
                    cnt++;
                }
                cnt = 0;
                foreach (PC pc in gm.playerList.PCList)
                {
                    if (!FoundOne)
                    {
                        if (pc.Body.ItemTag == tag)
                        {
                            gm.playerList.PCList[cnt].Body = new Item();
                            gm.playerList.PCList[cnt].Body.ItemName = "";
                            FoundOne = true;
                        }
                        if (pc.MainHand.ItemTag == tag)
                        {
                            gm.playerList.PCList[cnt].MainHand = new Item();
                            gm.playerList.PCList[cnt].MainHand.ItemName = "";
                            FoundOne = true;
                        }
                        if (pc.Ring1.ItemTag == tag)
                        {
                            gm.playerList.PCList[cnt].Ring1 = new Item();
                            gm.playerList.PCList[cnt].Ring1.ItemName = "";
                            FoundOne = true;
                        }
                        if (pc.OffHand.ItemTag == tag)
                        {
                            gm.playerList.PCList[cnt].OffHand = new Item();
                            gm.playerList.PCList[cnt].OffHand.ItemName = "";
                            FoundOne = true;
                        }
                    }
                    cnt++;
                }
            }
        }
        public bool CheckForItem(string tag, int quantity)
        {
            //check if item is on any of the party members
            int numFound = 0;
            foreach (PC pc in gm.playerList.PCList)
            {
                if (pc.Body.ItemTag == tag)
                    numFound++;
                if (pc.MainHand.ItemTag == tag)
                    numFound++;
                if (pc.Ring1.ItemTag == tag)
                    numFound++;
                if (pc.OffHand.ItemTag == tag)
                    numFound++;
            }
            foreach (Item item in gm.partyInventoryList)
            {
                if (item.ItemTag == tag)
                    numFound++;
            }
            if (numFound >= quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIsRace(int PCIndex, string tag)
        {
            if (gm.playerList.PCList[PCIndex].Race.ToString() == tag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIsGender(int PCIndex, string tag)
        {
            if (gm.playerList.PCList[PCIndex].Gender.ToString() == tag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIsClassLevel(int PCIndex, string tag, int level)
        {
            if (gm.playerList.PCList[PCIndex].Class.ToString() == tag)
            {
                if (gm.playerList.PCList[PCIndex].ClassLevel >= level)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CheckFunds(int amount)
        {
            if (gm.partyGold >= amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckGlobalInt(string variableName, string compare, int value)
        {
            foreach (GlobalInt variable in gm.module.ModuleGlobalInts)
            {
                if (variable.Key == variableName)
                {
                    if (compare == "=")
                    {
                        if (variable.Value == value)
                        {
                            return true;
                        }
                    }
                    else if (compare == ">")
                    {
                        if (variable.Value > value)
                        {
                            return true;
                        }
                    }
                    else if (compare == "<")
                    {
                        if (variable.Value < value)
                        {
                            return true;
                        }
                    }
                    else if (compare == "!")
                    {
                        if (variable.Value != value)
                        {
                            return true;
                        }
                    }
                }                
            }
            return false;
        }
    }
}
