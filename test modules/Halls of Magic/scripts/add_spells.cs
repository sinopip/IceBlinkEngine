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
			// p1 : type of spells (default "Offense", or "Defense")
            public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
            {
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Fireball"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Flame Fingers"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Resist Cold"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Resist Fire"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Minor Healing"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Moderate Healing"));
           	
            	if (p1 == "Defense")
            	{
             		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Bless"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Dimension Door"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Free Action"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Haste"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Mage Armor"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Mass Minor Heal"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Minor Regeneration"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Resurrection"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Strength"));
            		
            	}
            	else // Offense!
            	{
             		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Acid Arrow"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Blast of Light"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Confusion"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Disintegrate"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Finger of Death"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Hold"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Ice Storm"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Mage Bolt"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Magic Stone"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Meteor Swarm"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Sleep"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Tornado"));
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(
            			sf.gm.module.moduleSpellsList.getSpellByName("Web"));
            	}
            	foreach (Spell sp in sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList)
            		sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsTags.Add(sp.SpellTag);
            	// to get ALL spells
        		/*foreach (Spell sp in sf.gm.module.moduleSpellsList.spellList)
				{
					// * adding spell is necessary for recording the spells in savegames
					sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsTags.Add(sp.SpellTag);
					sf.gm.playerList.PCList[sf.gm.selectedPartyLeader].KnownSpellsList.spellList.Add(sp);
				}
            	*/	
            }     
        }
    }

