	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Windows.Forms;
	using System.Drawing;
	using IceBlinkCore;

    namespace IceBlink
    {
        public class IceBlinkScript
        {       
            public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
            {
            	/*Container c = new Container();
            	c.containerInventoryList.Add(sf.gm.module.ModuleItemsList.getItem("Heal Light Wounds Potion"));
				            	
            	ContainerDialogBox cb = new ContainerDialogBox(sf.gm, c);
            	cb.Show();*/
            	
                IBMessageBox.Show(sf.gm, "(Before leaving, you get some items, putting on some thick cloth and a shortsword in your scabbard)");
                foreach (Item it in sf.gm.module.ModuleItemsList.itemsList)
                {
                	Item armory = null;
                	if (it.ItemName == "Short Sword") 
					{
                		sf.GiveItem(it.ItemTag,1);
                		armory = sf.gm.module.ModuleItemsList.getItemByTag("ssword01");
                		if (armory != null)
						{
                			sf.gm.playerList.PCList[0].MainHand = armory.DeepCopy();
							sf.gm.playerList.PCList[0].MainHandTag = armory.ItemTag;
						}
					}
                	else if (it.ItemName == "Dagger")
                	{
                		sf.GiveItem(it.ItemTag,2);
                	}
                	else if (it.ItemName == "Robes")
                	{
                		sf.GiveItem(it.ItemTag,1);
                		armory = sf.gm.module.ModuleItemsList.getItemByTag("robes");
                		if (armory != null)
                		{
                			sf.gm.playerList.PCList[0].Body = armory.DeepCopy();
                			sf.gm.playerList.PCList[0].BodyTag = armory.ItemTag;
                		}
                	}
                	else if (it.ItemName == "Leather Armor")
                		sf.GiveItem(it.ItemTag,2);      
                	
					sf.gm.playerList.PCList[0].UpdateSimpleStats();
                	sf.frm.pcInventory.refreshEquippedToPc0();					
                	sf.frm.refreshFormControls();
                	}
            }            

        }
    }

