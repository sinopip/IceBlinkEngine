using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using System.IO;

namespace IceBlink
{
    public partial class PartyInventory : IBForm
    {
        public Form1 pcI_frm;
        private Game pcI_game;
        private int _selectedLbxIndex;
        private Item Item1 = new Item();
        private Item Item2 = new Item();
        private Item Item3 = new Item();
        private Item Item4 = new Item();
        private Item Item5 = new Item();
        private Item Item6 = new Item();
        private Item Item7 = new Item();
        private Item Item8 = new Item();
        private Item getItem = new Item();
        private int _selectedPC = 0; 

        public PartyInventory()
        {
            InitializeComponent();
            lbxInventory.DrawMode = DrawMode.OwnerDrawFixed;
            lbxInventory.DrawItem += new DrawItemEventHandler(lbxInventory_DrawItem);
        }
        public void passRefs(Game game, Form1 frm)
        {
            pcI_game = game;
            pcI_frm = frm;
            rbtnPc0.Checked = true;
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
            refreshFonts();
            iceBlinkGroupBoxMedium1.setupAll(pcI_game);
            iceBlinkGroupBoxMedium2.setupAll(pcI_game);
            iceBlinkGroupBoxMedium3.setupAll(pcI_game);
            btnDeleteItem.setupAll(pcI_game);
            btnRemoveBody.setupAll(pcI_game);
            btnRemoveFeet.setupAll(pcI_game);
            btnRemoveHead.setupAll(pcI_game);
            btnRemoveMainHand.setupAll(pcI_game);
            btnRemoveNeck.setupAll(pcI_game);
            btnRemoveOffHand.setupAll(pcI_game);
            btnRemoveRing1.setupAll(pcI_game);
            btnRemoveRing2.setupAll(pcI_game);
            btnUseItem.setupAll(pcI_game);
            IceBlinkButtonResize.setupAll(pcI_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(pcI_game);
            this.setupAll(pcI_game);
        }
        public void refreshFonts()
        {
            //groupBox1.Font = pcI_game.module.ModuleTheme.ModuleFont;
            //groupBox2.Font = pcI_game.module.ModuleTheme.ModuleFont;
            //groupBox3.Font = pcI_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium1.Font = pcI_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium2.Font = pcI_game.module.ModuleTheme.ModuleFont;
            iceBlinkGroupBoxMedium3.Font = pcI_game.module.ModuleTheme.ModuleFont;
            lbxInventory.Font = pcI_game.module.ModuleTheme.ModuleFont;
            panel1.Font = pcI_game.module.ModuleTheme.ModuleFont;
            btnUseItem.Font = pcI_game.module.ModuleTheme.ModuleFont;
            btnDeleteItem.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label1.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label2.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label3.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label4.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label5.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label6.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label7.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label8.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtBody.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtEncumbrance.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtFeet.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtHead.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtMainHand.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtNeck.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtOffHand.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtRing1.Font = pcI_game.module.ModuleTheme.ModuleFont;
            txtRing2.Font = pcI_game.module.ModuleTheme.ModuleFont;
            label9.Font = pcI_game.module.ModuleTheme.ModuleFont;
            rtxtDesc.Font = pcI_game.module.ModuleTheme.ModuleFont;
            /*
            gbMain.Font = game.module.ModuleTheme.ModuleFont;
            groupBox2.Font = game.module.ModuleTheme.ModuleFont;
            gbSkills.Font = game.module.ModuleTheme.ModuleFont;
            gbSpells.Font = game.module.ModuleTheme.ModuleFont;
            gbTraits.Font = game.module.ModuleTheme.ModuleFont;
            txtSkillPointsLeftToSpend.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            txtTraitsToLearn.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            txtSpellsToLearn.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            lblCharKnownSpellsList.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            lblCharKnownSpellsList.Font = new Font(lblCharKnownSpellsList.Font, FontStyle.Underline);
            label32.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.85f);
            label32.Font = new Font(label32.Font, FontStyle.Underline);
            label30.Font = prntForm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 0.75f);
            btnFinish.Font = game.module.ModuleTheme.ModuleFont;
            */
            this.Invalidate();
        }
        private void lbxInventory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (lbxInventory.Items.Count > 0)
            {
                // Draw the background of the ListBox control for each item.
                e.DrawBackground();

                Brush myBrush = Brushes.Black; //default color for item

                //string itemName = pcI_game.partyInventoryList[e.Index].ItemResRef;
                //Item item = pcI_game.module.ModuleItemsList.getItem(itemName);
                //if class doesn't allow item show as red, else black
                if (pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(pcI_game.partyInventoryList[e.Index].ItemResRef))
                {
                    myBrush = Brushes.Black;
                }
                else
                {
                    myBrush = Brushes.Red;
                }

                // Draw the current item text based on the current 
                // Font and the custom brush settings.
                //
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                // If the ListBox has focus, draw a focus rectangle 
                // around the selected item.
                //
                e.DrawFocusRectangle();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.I)
            {
                if (pcI_frm.inventoryOpen)
                {
                    pcI_frm.pcInventory.Hide();
                    pcI_frm.inventoryOpen = false;
                }
                else
                {
                    pcI_frm.pcInventory.Show();
                    pcI_frm.inventoryOpen = true;
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (pcI_game.partyInventoryList.Count > 0)
            {
                DialogResult dlg = IBMessageBox.Show(pcI_game, "Are you sure you wish to drop the item forever?", enumMessageButton.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    pcI_game.partyInventoryList.RemoveAt(_selectedLbxIndex);
                    pcI_game.partyInventoryTagList.RemoveAt(_selectedLbxIndex);
                    _selectedLbxIndex = 0;
                    refreshlbxItems();
                    refreshPanelInfo();
                }
                if (dlg == DialogResult.No)
                {
                    // do nothing
                }                
            }
        }
        private void btnUseItem_Click(object sender, EventArgs e)
        {
            if (pcI_game.partyInventoryList.Count > 0)
            {
                pcI_game.indexOfPCtoLastUseItem = _selectedPC;
                if ((pcI_game.partyInventoryList[_selectedLbxIndex].OnUseItem.FilenameOrTag == "none") || (pcI_game.partyInventoryList[_selectedLbxIndex].OnUseItem.FilenameOrTag == ""))
                {
                    IBMessageBox.Show(pcI_game, "Item does nothing");
                }
                else
                {
                    try
                    {
                        pcI_frm.sf.MainMapScriptCall = true; //can be used as a flag in your scripts that the call is coming from the main map
                        var scriptItm = pcI_game.partyInventoryList[_selectedLbxIndex].OnUseItem;
                        pcI_frm.doScriptBasedOnFilename(scriptItm.FilenameOrTag, scriptItm.Parm1, scriptItm.Parm2, scriptItm.Parm3, scriptItm.Parm4);
                
                        //pcI_frm.doScriptBasedOnFilename(pcI_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs", "", "", "", "");
                        //pcI_game.executeScript(pcI_game.mainDirectory + "\\modules\\" + pcI_game.module.ModuleFolderName + "\\scripts\\" + pcI_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs");                        
                        if (pcI_game.deleteItemUsedScript)
                        {
                            pcI_game.partyInventoryList.RemoveAt(_selectedLbxIndex);
                            pcI_game.partyInventoryTagList.RemoveAt(_selectedLbxIndex);
                            _selectedLbxIndex = 0;
                            refreshlbxItems();
                            refreshPanelInfo();
                            pcI_game.deleteItemUsedScript = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        IBMessageBox.Show(pcI_game, "failed to fire item script");
                        pcI_game.errorLog(ex.ToString());
                    }
                    finally
                    {
                        pcI_frm.sf.MainMapScriptCall = false; //set back to false after use
                    }                    
                }
                pcI_frm.doPortraitStats();
            }
            /* Old Way
            if (pcI_game.partyInventoryList.Count > 0)
            {
                pcI_game.indexOfPCtoLastUseItem = _selectedPC;
                if (pcI_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename == "")
                {
                    IBMessageBox.Show(pcI_game, "Item does nothing");
                }
                else
                {
                    try
                    {
                        pcI_frm.doScriptBasedOnFilename(pcI_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs", "", "", "", "");
                        //pcI_game.executeScript(pcI_game.mainDirectory + "\\modules\\" + pcI_game.module.ModuleFolderName + "\\scripts\\" + pcI_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs");                        
                        if (pcI_game.deleteItemUsedScript)
                        {
                            pcI_game.partyInventoryList.RemoveAt(_selectedLbxIndex);
                            pcI_game.partyInventoryTagList.RemoveAt(_selectedLbxIndex);
                            _selectedLbxIndex = 0;
                            refreshlbxItems();
                            refreshPanelInfo();
                            pcI_game.deleteItemUsedScript = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        IBMessageBox.Show(pcI_game, "failed to fire item script");
                        pcI_game.errorLog(ex.ToString());
                    }
                }
                pcI_frm.doPortraitStats();
            }
            */
        }
        public void refreshlbxItems()
        {
            lbxInventory.BeginUpdate();
            lbxInventory.DataSource = null;
            lbxInventory.DataSource = pcI_game.partyInventoryList;
            lbxInventory.DisplayMember = "ItemName";
            lbxInventory.EndUpdate();
        }
        public void refreshDescriptionBox()
        {
            rtxtDesc.Text = "";
            if ((pcI_game.partyInventoryList.Count > 0) && (_selectedLbxIndex < pcI_game.partyInventoryList.Count))
            {
                Item selectedItem = pcI_game.partyInventoryList[_selectedLbxIndex];
                refreshDescriptionBox(selectedItem);
            }
        }
        public void refreshDescriptionBox(Item selectedItem)
        {
            try
            {
                if (File.Exists(pcI_game.mainDirectory + "\\modules\\" + pcI_game.module.ModuleFolderName + "\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(pcI_game.mainDirectory + "\\modules\\" + pcI_game.module.ModuleFolderName + "\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(pcI_game.mainDirectory + "\\modules\\" + pcI_game.module.ModuleFolderName + "\\graphics\\sprites\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(pcI_game.mainDirectory + "\\modules\\" + pcI_game.module.ModuleFolderName + "\\graphics\\sprites\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(pcI_game.mainDirectory + "\\data\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(pcI_game.mainDirectory + "\\data\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(pcI_game.mainDirectory + "\\data\\graphics\\sprites\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(pcI_game.mainDirectory + "\\data\\graphics\\sprites\\" + selectedItem.ItemIconFilename);
                }
                else
                { 
                    //do nothing, didn't find image for item
                }
                //Item selectedItem = pcI_game.partyInventoryList[_selectedLbxIndex];
                if ((selectedItem.ItemCategory == Item.category.Melee) || (selectedItem.ItemCategory == Item.category.Ranged))
                {
                    rtxtDesc.Text = selectedItem.ItemDescription + Environment.NewLine +
                                   "Damage: " + selectedItem.ItemDamageNumberOfDice.ToString() + "d" + selectedItem.ItemDamageDie.ToString() + Environment.NewLine +
                                   "Attack Bonus: " + selectedItem.ItemAttackBonus.ToString() + Environment.NewLine +
                                   "Attack Range: " + selectedItem.ItemAttackRange.ToString() + Environment.NewLine +
                                   "Area of Effect: " + selectedItem.ItemAreaOfEffect.ToString();
                }
                else if (selectedItem.ItemCategory != Item.category.General)
                {
                    rtxtDesc.Text = selectedItem.ItemDescription + Environment.NewLine +
                                   "AC Bonus: " + selectedItem.ItemArmorBonus.ToString() + Environment.NewLine +
                                   "Max Dex Bonus: " + selectedItem.ItemMaxDexBonus.ToString() + Environment.NewLine +
                                   "Damage Reduction: " + selectedItem.ItemDamageReduction.ToString();
                }
                else
                {
                    rtxtDesc.Text = selectedItem.ItemDescription;
                }
            }
            catch { }
        }
        public void refreshPanelInfo()
        {
            //refreshDescriptionBox();
            try
            {
                if (pcI_game.playerList.PCList.Count > 0)
                    rbtnPc0.BackgroundImage = (Image)pcI_game.playerList.PCList[0].portraitBitmapS;
                if (pcI_game.playerList.PCList.Count > 1)
                    rbtnPc1.BackgroundImage = (Image)pcI_game.playerList.PCList[1].portraitBitmapS;
                if (pcI_game.playerList.PCList.Count > 2)
                    rbtnPc2.BackgroundImage = (Image)pcI_game.playerList.PCList[2].portraitBitmapS;
                if (pcI_game.playerList.PCList.Count > 3)
                    rbtnPc3.BackgroundImage = (Image)pcI_game.playerList.PCList[3].portraitBitmapS;
                if (pcI_game.playerList.PCList.Count > 4)
                    rbtnPc4.BackgroundImage = (Image)pcI_game.playerList.PCList[4].portraitBitmapS;
                if (pcI_game.playerList.PCList.Count > 5)
                    rbtnPc5.BackgroundImage = (Image)pcI_game.playerList.PCList[5].portraitBitmapS;
            }
            catch (Exception ex)
            {
                pcI_game.errorLog(ex.ToString());
            }
        }
        private void lbxInventory_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbxInventory.Items.Count == 0) { return; }
            if (lbxInventory.SelectedIndex >= 0) { _selectedLbxIndex = lbxInventory.SelectedIndex; }

            refreshDescriptionBox();
            refreshPanelInfo();
            lbxInventory.SelectedIndex = _selectedLbxIndex;            

            //int index = lbxInventory.IndexFromPoint(e.X, e.Y);
            int index = _selectedLbxIndex;
            if (index != -1)
            {
                getItem = pcI_game.partyInventoryList[index];
                //logText("getItem = " + getItem.t_name);
                DragDropEffects dde1 = DoDragDrop(getItem, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    //pcI_game.partyInventoryList.RemoveAt(lbxInventory.IndexFromPoint(e.X, e.Y));
                    //pcI_game.partyInventoryTagList.RemoveAt(lbxInventory.IndexFromPoint(e.X, e.Y));
                    pcI_game.partyInventoryList.RemoveAt(index);
                    pcI_game.partyInventoryTagList.RemoveAt(index);
                    refreshlbxItems();
                }
                //logText(getItem.t_name);
                //logText(dde1.ToString());
            }
        }
        private void txtHead_DragOver(object sender, DragEventArgs e)
        {
            if ((pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef)) && (getItem.ItemCategory == IceBlinkCore.Item.category.Head))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtHead_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                if (txtHead.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item7);
                    pcI_game.partyInventoryTagList.Add(Item7.ItemTag);
                }
                Item7 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Head = getItem;
                pcI_game.playerList.PCList[_selectedPC].HeadTag = getItem.ItemTag;
                txtHead.Text = Item7.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void txtNeck_DragOver(object sender, DragEventArgs e)
        {
            if ((pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef)) && (getItem.ItemCategory == IceBlinkCore.Item.category.Neck))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtNeck_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                if (txtNeck.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item8);
                    pcI_game.partyInventoryTagList.Add(Item8.ItemTag);
                }
                Item8 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Neck = getItem;
                pcI_game.playerList.PCList[_selectedPC].NeckTag = getItem.ItemTag;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void txtBody_DragOver(object sender, DragEventArgs e)
        {
            if ((pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef)) && (getItem.ItemCategory == IceBlinkCore.Item.category.Armor))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtBody_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                if (txtBody.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item1);
                    pcI_game.partyInventoryTagList.Add(Item1.ItemTag);
                }
                Item1 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Body = getItem;
                pcI_game.playerList.PCList[_selectedPC].BodyTag = getItem.ItemTag;
                txtBody.Text = Item1.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void txtMainHand_DragOver(object sender, DragEventArgs e)
        {
            if ((getItem.ItemCategory == IceBlinkCore.Item.category.Melee) || (getItem.ItemCategory == IceBlinkCore.Item.category.Ranged))
            {
                if (pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef))
                {
                    e.Effect = DragDropEffects.All;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtMainHand_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                if (txtMainHand.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item2);
                    pcI_game.partyInventoryTagList.Add(Item2.ItemTag);
                }
                Item2 = getItem;
                pcI_game.playerList.PCList[_selectedPC].MainHand = getItem;
                pcI_game.playerList.PCList[_selectedPC].MainHandTag = getItem.ItemTag;
                txtMainHand.Text = Item2.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }        
        private void txtOffHand_DragOver(object sender, DragEventArgs e)
        {
            /*if ((pcI_game.playerList.PCList[_selectedPC].Class == PC.charClass.Thief) && (getItem.ItemCategory == IceBlinkCore.Item.category.Melee) && (getItem.ItemUseByThief))
            {
                e.Effect = DragDropEffects.All;
            }*/
            //else if ((pcI_game.playerList.PCList[_selectedPC].Class == PC.charClass.Fighter) && (getItem.ItemCategory == IceBlinkCore.Item.category.Shield) && (getItem.ItemUseByFighter))
            if ((pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef)) && ((getItem.ItemCategory == IceBlinkCore.Item.category.Shield) || getItem.ArmorWeightType.ToString() == "Light"))
            //if ((pcI_game.playerList.PCList[_selectedPC].Class == PC.charClass.Fighter) && (getItem.ItemCategory == IceBlinkCore.Item.category.Shield) && (getItem.ItemUseByFighter))
            {
                e.Effect = DragDropEffects.All;
            }
            /*else if ((pcI_game.playerList.PCList[_selectedPC].Class == PC.charClass.Wizard) && (getItem.ItemCategory == IceBlinkCore.Item.category.Shield) && (getItem.ItemUseByMage))
            {
                e.Effect = DragDropEffects.All;
            }*/
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtOffHand_DragDrop(object sender, DragEventArgs e)
        {
            //logText("getItem = " + getItem.t_name);
            //if (e.Data.GetDataPresent(DataFormats.StringFormat))
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                //string str = (string)e.Data.GetData(DataFormats.StringFormat);
                if (txtOffHand.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item4);
                    pcI_game.partyInventoryTagList.Add(Item4.ItemTag);
                }
                Item4 = getItem;
                pcI_game.playerList.PCList[_selectedPC].OffHand = getItem;
                pcI_game.playerList.PCList[_selectedPC].OffHandTag = getItem.ItemTag;
                txtOffHand.Text = Item4.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void txtRing1_DragOver(object sender, DragEventArgs e)
        {
            if ((pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef)) && (getItem.ItemCategory == IceBlinkCore.Item.category.Ring))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtRing1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                if (txtRing1.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item3);
                    pcI_game.partyInventoryTagList.Add(Item3.ItemTag);
                }
                Item3 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Ring1 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Ring1Tag = getItem.ItemTag;
                txtRing1.Text = Item3.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void txtRing2_DragOver(object sender, DragEventArgs e)
        {
            if ((pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef)) && (getItem.ItemCategory == IceBlinkCore.Item.category.Ring))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtRing2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                if (txtRing2.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item5);
                    pcI_game.partyInventoryTagList.Add(Item5.ItemTag);
                }
                Item5 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Ring2 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Ring2Tag = getItem.ItemTag;
                txtRing2.Text = Item5.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void txtFeet_DragOver(object sender, DragEventArgs e)
        {
            if ((pcI_game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(getItem.ItemResRef)) && (getItem.ItemCategory == IceBlinkCore.Item.category.Boots))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void txtFeet_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Item)))
            {
                if (txtFeet.Text != "")
                {
                    pcI_game.partyInventoryList.Add(Item6);
                    pcI_game.partyInventoryTagList.Add(Item6.ItemTag);
                }
                Item6 = getItem;
                pcI_game.playerList.PCList[_selectedPC].Feet = getItem;
                pcI_game.playerList.PCList[_selectedPC].FeetTag = getItem.ItemTag;
                txtFeet.Text = Item6.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }       
        private void btnRemoveHead_Click(object sender, EventArgs e)
        {
            if (txtHead.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item7);
                pcI_game.partyInventoryTagList.Add(Item7.ItemTag);
            }
            Item7 = new Item();
            Item7.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Head = new Item();
            pcI_game.playerList.PCList[_selectedPC].Head.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].HeadTag = "";
            txtHead.Text = Item7.ItemName;
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void btnRemoveNeck_Click(object sender, EventArgs e)
        {
            if (txtNeck.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item8);
                pcI_game.partyInventoryTagList.Add(Item8.ItemTag);
            }
            Item8 = new Item();
            Item8.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Neck = new Item();
            pcI_game.playerList.PCList[_selectedPC].Neck.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].NeckTag = "";
            txtNeck.Text = Item8.ItemName;
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void btnRemoveBody_Click(object sender, EventArgs e)
        {
            if (txtBody.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item1);
                pcI_game.partyInventoryTagList.Add(Item1.ItemTag);
            }
            Item1 = new Item();
            Item1.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Body = new Item();
            pcI_game.playerList.PCList[_selectedPC].Body.ItemName = "";
            txtBody.Text = Item1.ItemName;
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void btnRemoveMainHand_Click(object sender, EventArgs e)
        {
            if (txtMainHand.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item2);
                pcI_game.partyInventoryTagList.Add(Item2.ItemTag);
            }
            Item2 = new Item();
            Item2.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].MainHand = new Item();
            pcI_game.playerList.PCList[_selectedPC].MainHand.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].MainHandTag = "";
            txtMainHand.Text = Item2.ItemName;
            // remove item from PC weapon slot
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void btnRemoveRing1_Click(object sender, EventArgs e)
        {
            if (txtRing1.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item3);
                pcI_game.partyInventoryTagList.Add(Item3.ItemTag);
            }
            Item3 = new Item();
            Item3.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Ring1 = new Item();
            pcI_game.playerList.PCList[_selectedPC].Ring1.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Ring1Tag = "";
            txtRing1.Text = Item3.ItemName;
            // remove item from PC belt slot
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void btnRemoveOffHand_Click(object sender, EventArgs e)
        {
            if (txtOffHand.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item4);
                pcI_game.partyInventoryTagList.Add(Item4.ItemTag);
            }
            Item4 = new Item();
            Item4.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].OffHand = new Item();
            pcI_game.playerList.PCList[_selectedPC].OffHand.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].OffHandTag = "";
            txtOffHand.Text = Item4.ItemName;
            // remove item from PC band slot
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void btnRemoveRing2_Click(object sender, EventArgs e)
        {
            if (txtRing2.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item5);
                pcI_game.partyInventoryTagList.Add(Item5.ItemTag);
            }
            Item5 = new Item();
            Item5.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Ring2 = new Item();
            pcI_game.playerList.PCList[_selectedPC].Ring2.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Ring2Tag = "";
            txtRing2.Text = Item5.ItemName;
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void btnRemoveFeet_Click(object sender, EventArgs e)
        {
            if (txtFeet.Text != "")
            {
                pcI_game.partyInventoryList.Add(Item6);
                pcI_game.partyInventoryTagList.Add(Item6.ItemTag);
            }
            Item6 = new Item();
            Item6.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].Feet = new Item();
            pcI_game.playerList.PCList[_selectedPC].Feet.ItemName = "";
            pcI_game.playerList.PCList[_selectedPC].FeetTag = "";
            txtFeet.Text = Item6.ItemName;
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        public void refreshEquippedToPc0()
        {
            rbtnPc0.Checked = true;
            if (rbtnPc0.Checked)
            {
                _selectedPC = 0;
                Item1 = pcI_game.playerList.PCList[0].Body;
                txtBody.Text = Item1.ItemName;
                Item2 = pcI_game.playerList.PCList[0].MainHand;
                txtMainHand.Text = Item2.ItemName;
                Item3 = pcI_game.playerList.PCList[0].Ring1;
                txtRing1.Text = Item3.ItemName;
                Item4 = pcI_game.playerList.PCList[0].OffHand;
                txtOffHand.Text = Item4.ItemName;
                Item5 = pcI_game.playerList.PCList[0].Ring2;
                txtRing2.Text = Item5.ItemName;
                Item6 = pcI_game.playerList.PCList[0].Feet;
                txtFeet.Text = Item6.ItemName;
                Item7 = pcI_game.playerList.PCList[0].Head;
                txtHead.Text = Item7.ItemName;
                Item8 = pcI_game.playerList.PCList[0].Neck;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void rbtnPc0_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc0.Checked)
            {
                _selectedPC = 0;
                Item1 = pcI_game.playerList.PCList[0].Body;
                txtBody.Text = Item1.ItemName;
                Item2 = pcI_game.playerList.PCList[0].MainHand;
                txtMainHand.Text = Item2.ItemName;
                Item3 = pcI_game.playerList.PCList[0].Ring1;
                txtRing1.Text = Item3.ItemName;
                Item4 = pcI_game.playerList.PCList[0].OffHand;
                txtOffHand.Text = Item4.ItemName;
                Item5 = pcI_game.playerList.PCList[0].Ring2;
                txtRing2.Text = Item5.ItemName;
                Item6 = pcI_game.playerList.PCList[0].Feet;
                txtFeet.Text = Item6.ItemName;
                Item7 = pcI_game.playerList.PCList[0].Head;
                txtHead.Text = Item7.ItemName;
                Item8 = pcI_game.playerList.PCList[0].Neck;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void rbtnPc1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc1.Checked)
            {
                _selectedPC = 1;
                Item1 = pcI_game.playerList.PCList[1].Body;
                txtBody.Text = Item1.ItemName;
                Item2 = pcI_game.playerList.PCList[1].MainHand;
                txtMainHand.Text = Item2.ItemName;
                Item3 = pcI_game.playerList.PCList[1].Ring1;
                txtRing1.Text = Item3.ItemName;
                Item4 = pcI_game.playerList.PCList[1].OffHand;
                txtOffHand.Text = Item4.ItemName;
                Item5 = pcI_game.playerList.PCList[1].Ring2;
                txtRing2.Text = Item5.ItemName;
                Item6 = pcI_game.playerList.PCList[1].Feet;
                txtFeet.Text = Item6.ItemName;
                Item7 = pcI_game.playerList.PCList[1].Head;
                txtHead.Text = Item7.ItemName;
                Item8 = pcI_game.playerList.PCList[1].Neck;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void rbtnPc2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc2.Checked)
            {
                _selectedPC = 2;
                Item1 = pcI_game.playerList.PCList[2].Body;
                txtBody.Text = Item1.ItemName;
                Item2 = pcI_game.playerList.PCList[2].MainHand;
                txtMainHand.Text = Item2.ItemName;
                Item3 = pcI_game.playerList.PCList[2].Ring1;
                txtRing1.Text = Item3.ItemName;
                Item4 = pcI_game.playerList.PCList[2].OffHand;
                txtOffHand.Text = Item4.ItemName;
                Item5 = pcI_game.playerList.PCList[2].Ring2;
                txtRing2.Text = Item5.ItemName;
                Item6 = pcI_game.playerList.PCList[2].Feet;
                txtFeet.Text = Item6.ItemName;
                Item7 = pcI_game.playerList.PCList[2].Head;
                txtHead.Text = Item7.ItemName;
                Item8 = pcI_game.playerList.PCList[2].Neck;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void rbtnPc3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc3.Checked)
            {
                _selectedPC = 3;
                Item1 = pcI_game.playerList.PCList[3].Body;
                txtBody.Text = Item1.ItemName;
                Item2 = pcI_game.playerList.PCList[3].MainHand;
                txtMainHand.Text = Item2.ItemName;
                Item3 = pcI_game.playerList.PCList[3].Ring1;
                txtRing1.Text = Item3.ItemName;
                Item4 = pcI_game.playerList.PCList[3].OffHand;
                txtOffHand.Text = Item4.ItemName;
                Item5 = pcI_game.playerList.PCList[3].Ring2;
                txtRing2.Text = Item5.ItemName;
                Item6 = pcI_game.playerList.PCList[3].Feet;
                txtFeet.Text = Item6.ItemName;
                Item7 = pcI_game.playerList.PCList[3].Head;
                txtHead.Text = Item7.ItemName;
                Item8 = pcI_game.playerList.PCList[3].Neck;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void rbtnPc4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc4.Checked)
            {
                _selectedPC = 4;
                Item1 = pcI_game.playerList.PCList[4].Body;
                txtBody.Text = Item1.ItemName;
                Item2 = pcI_game.playerList.PCList[4].MainHand;
                txtMainHand.Text = Item2.ItemName;
                Item3 = pcI_game.playerList.PCList[4].Ring1;
                txtRing1.Text = Item3.ItemName;
                Item4 = pcI_game.playerList.PCList[4].OffHand;
                txtOffHand.Text = Item4.ItemName;
                Item5 = pcI_game.playerList.PCList[4].Ring2;
                txtRing2.Text = Item5.ItemName;
                Item6 = pcI_game.playerList.PCList[4].Feet;
                txtFeet.Text = Item6.ItemName;
                Item7 = pcI_game.playerList.PCList[4].Head;
                txtHead.Text = Item7.ItemName;
                Item8 = pcI_game.playerList.PCList[4].Neck;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }
        private void rbtnPc5_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc5.Checked)
            {
                _selectedPC = 5;
                Item1 = pcI_game.playerList.PCList[5].Body;
                txtBody.Text = Item1.ItemName;
                Item2 = pcI_game.playerList.PCList[5].MainHand;
                txtMainHand.Text = Item2.ItemName;
                Item3 = pcI_game.playerList.PCList[5].Ring1;
                txtRing1.Text = Item3.ItemName;
                Item4 = pcI_game.playerList.PCList[5].OffHand;
                txtOffHand.Text = Item4.ItemName;
                Item5 = pcI_game.playerList.PCList[5].Ring2;
                txtRing2.Text = Item5.ItemName;
                Item6 = pcI_game.playerList.PCList[5].Feet;
                txtFeet.Text = Item6.ItemName;
                Item7 = pcI_game.playerList.PCList[5].Head;
                txtHead.Text = Item7.ItemName;
                Item8 = pcI_game.playerList.PCList[5].Neck;
                txtNeck.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
        }        
        private void txtHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtHead.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].Head;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtNeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtNeck.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].Neck;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtBody_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBody.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].Body;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtMainHand_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtMainHand.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].MainHand;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtOffHand_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtOffHand.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].OffHand;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtRing1_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtRing1.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].Ring1;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtRing2_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtRing2.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].Ring2;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtFeet_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtFeet.Text != "")
            {
                Item selectedItem = pcI_game.playerList.PCList[_selectedPC].Feet;
                refreshDescriptionBox(selectedItem);
            }
        }              

        private void PartyInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            pcI_frm.inventoryOpen = false;
            this.Hide();
            e.Cancel = true; // this cancels the close event.            
        }

        private void txtOffHand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
