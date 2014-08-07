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
    public partial class Store : IBForm
    {
        private Form1 frm;
        private Game game;
        private Shop currentShop;
        private int _selectedLbxIndex;
        private int _selectedLbxIndexShop;
        private int _selectedPC = 0;
        private Item Item1 = new Item();
        private Item Item2 = new Item();
        private Item Item3 = new Item();
        private Item Item4 = new Item();
        private Item Item5 = new Item();
        private Item Item6 = new Item();
        private Item Item7 = new Item();
        private Item Item8 = new Item();

        public Store()
        {
            InitializeComponent();
        }
        public void passRefs(Game g, Form1 f, Shop s)
        {
            game = g;
            frm = f;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            groupBox1.setupAll(game);
            groupBox2.setupAll(game);
            groupBox3.setupAll(game);
            groupBox4.setupAll(game);
            groupBox5.setupAll(game);
            btnBuyItem.setupAll(game);
            btnDeleteItem.setupAll(game);
            btnRemoveBody.setupAll(game);
            btnRemoveFeet.setupAll(game);
            btnRemoveHead.setupAll(game);
            btnRemoveMainHand.setupAll(game);
            btnRemoveNeck.setupAll(game);
            btnRemoveOffHand.setupAll(game);
            btnRemoveRing1.setupAll(game);
            btnRemoveRing2.setupAll(game);
            btnSellItem.setupAll(game);
            btnUseItem.setupAll(game);
            this.setupAll(game);
            currentShop = s;
            rbtnPc0.Checked = true;
            _selectedLbxIndex = 0;
            refreshPanelInfo();
            refreshShopPanelInfo();
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
            //DgvColorChange();
            refreshFonts();
            refreshFunds();
            setupLabels();
            rbtnPc0.Checked = false;
            rbtnPc0.Checked = true;
        }
        private void Store_Load(object sender, EventArgs e)
        {
            rbtnPc0.Checked = false;
            rbtnPc0.Checked = true;
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
        }

        #region Handlers
        private void rbtnPc0_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc0.Checked)
            {
                _selectedPC = 0;
                Item1 = game.playerList.PCList[0].Head;
                txtHead.Text = Item1.ItemName;
                Item2 = game.playerList.PCList[0].Neck;
                txtNeck.Text = Item2.ItemName;
                Item3 = game.playerList.PCList[0].Body;
                txtBody.Text = Item3.ItemName;
                Item4 = game.playerList.PCList[0].MainHand;
                txtMainHand.Text = Item4.ItemName;
                Item5 = game.playerList.PCList[0].OffHand;
                txtOffHand.Text = Item5.ItemName;
                Item6 = game.playerList.PCList[0].Ring1;
                txtRing1.Text = Item6.ItemName;
                Item7 = game.playerList.PCList[0].Ring2;
                txtRing2.Text = Item7.ItemName;
                Item8 = game.playerList.PCList[0].Feet;
                txtFeet.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshPanelInfo();
            refreshShopPanelInfo();
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
            //DgvColorChange();
        }
        private void rbtnPc1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc1.Checked)
            {
                _selectedPC = 1;
                Item1 = game.playerList.PCList[1].Head;
                txtHead.Text = Item1.ItemName;
                Item2 = game.playerList.PCList[1].Neck;
                txtNeck.Text = Item2.ItemName;
                Item3 = game.playerList.PCList[1].Body;
                txtBody.Text = Item3.ItemName;
                Item4 = game.playerList.PCList[1].MainHand;
                txtMainHand.Text = Item4.ItemName;
                Item5 = game.playerList.PCList[1].OffHand;
                txtOffHand.Text = Item5.ItemName;
                Item6 = game.playerList.PCList[1].Ring1;
                txtRing1.Text = Item6.ItemName;
                Item7 = game.playerList.PCList[1].Ring2;
                txtRing2.Text = Item7.ItemName;
                Item8 = game.playerList.PCList[1].Feet;
                txtFeet.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshPanelInfo();
            refreshShopPanelInfo();
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
            //DgvColorChange();
        }
        private void rbtnPc2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc2.Checked)
            {
                _selectedPC = 2;
                Item1 = game.playerList.PCList[2].Head;
                txtHead.Text = Item1.ItemName;
                Item2 = game.playerList.PCList[2].Neck;
                txtNeck.Text = Item2.ItemName;
                Item3 = game.playerList.PCList[2].Body;
                txtBody.Text = Item3.ItemName;
                Item4 = game.playerList.PCList[2].MainHand;
                txtMainHand.Text = Item4.ItemName;
                Item5 = game.playerList.PCList[2].OffHand;
                txtOffHand.Text = Item5.ItemName;
                Item6 = game.playerList.PCList[2].Ring1;
                txtRing1.Text = Item6.ItemName;
                Item7 = game.playerList.PCList[2].Ring2;
                txtRing2.Text = Item7.ItemName;
                Item8 = game.playerList.PCList[2].Feet;
                txtFeet.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshPanelInfo();
            refreshShopPanelInfo();
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
            //DgvColorChange();
        }
        private void rbtnPc3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc3.Checked)
            {
                _selectedPC = 3;
                Item1 = game.playerList.PCList[3].Head;
                txtHead.Text = Item1.ItemName;
                Item2 = game.playerList.PCList[3].Neck;
                txtNeck.Text = Item2.ItemName;
                Item3 = game.playerList.PCList[3].Body;
                txtBody.Text = Item3.ItemName;
                Item4 = game.playerList.PCList[3].MainHand;
                txtMainHand.Text = Item4.ItemName;
                Item5 = game.playerList.PCList[3].OffHand;
                txtOffHand.Text = Item5.ItemName;
                Item6 = game.playerList.PCList[3].Ring1;
                txtRing1.Text = Item6.ItemName;
                Item7 = game.playerList.PCList[3].Ring2;
                txtRing2.Text = Item7.ItemName;
                Item8 = game.playerList.PCList[3].Feet;
                txtFeet.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshPanelInfo();
            refreshShopPanelInfo();
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
            //DgvColorChange();
        }
        private void rbtnPc4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc4.Checked)
            {
                _selectedPC = 4;
                Item1 = game.playerList.PCList[4].Head;
                txtHead.Text = Item1.ItemName;
                Item2 = game.playerList.PCList[4].Neck;
                txtNeck.Text = Item2.ItemName;
                Item3 = game.playerList.PCList[4].Body;
                txtBody.Text = Item3.ItemName;
                Item4 = game.playerList.PCList[4].MainHand;
                txtMainHand.Text = Item4.ItemName;
                Item5 = game.playerList.PCList[4].OffHand;
                txtOffHand.Text = Item5.ItemName;
                Item6 = game.playerList.PCList[4].Ring1;
                txtRing1.Text = Item6.ItemName;
                Item7 = game.playerList.PCList[4].Ring2;
                txtRing2.Text = Item7.ItemName;
                Item8 = game.playerList.PCList[4].Feet;
                txtFeet.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshPanelInfo();
            refreshShopPanelInfo();
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
            //DgvColorChange();
        }
        private void rbtnPc5_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc5.Checked)
            {
                _selectedPC = 5;
                Item1 = game.playerList.PCList[5].Head;
                txtHead.Text = Item1.ItemName;
                Item2 = game.playerList.PCList[5].Neck;
                txtNeck.Text = Item2.ItemName;
                Item3 = game.playerList.PCList[5].Body;
                txtBody.Text = Item3.ItemName;
                Item4 = game.playerList.PCList[5].MainHand;
                txtMainHand.Text = Item4.ItemName;
                Item5 = game.playerList.PCList[5].OffHand;
                txtOffHand.Text = Item5.ItemName;
                Item6 = game.playerList.PCList[5].Ring1;
                txtRing1.Text = Item6.ItemName;
                Item7 = game.playerList.PCList[5].Ring2;
                txtRing2.Text = Item7.ItemName;
                Item8 = game.playerList.PCList[5].Feet;
                txtFeet.Text = Item8.ItemName;
            }
            _selectedLbxIndex = 0;
            refreshPanelInfo();
            refreshShopPanelInfo();
            setupShopItemsDataGridView();
            setupInventoryItemsDataGridView();
            //DgvColorChange();
        }
        private void btnRemoveHead_Click(object sender, EventArgs e)
        {
            if (txtHead.Text != "")
            {
                game.partyInventoryList.Add(Item1);
                game.partyInventoryTagList.Add(Item1.ItemTag);
            }
            Item1 = new Item();
            Item1.ItemName = "";
            game.playerList.PCList[_selectedPC].Head = new Item();
            game.playerList.PCList[_selectedPC].Head.ItemName = "";
            txtHead.Text = Item1.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnRemoveNeck_Click(object sender, EventArgs e)
        {
            if (txtNeck.Text != "")
            {
                game.partyInventoryList.Add(Item2);
                game.partyInventoryTagList.Add(Item2.ItemTag);
            }
            Item2 = new Item();
            Item2.ItemName = "";
            game.playerList.PCList[_selectedPC].Neck = new Item();
            game.playerList.PCList[_selectedPC].Neck.ItemName = "";
            txtNeck.Text = Item2.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnRemoveBody_Click(object sender, EventArgs e)
        {
            if (txtBody.Text != "")
            {
                game.partyInventoryList.Add(Item3);
                game.partyInventoryTagList.Add(Item3.ItemTag);
            }
            Item3 = new Item();
            Item3.ItemName = "";
            game.playerList.PCList[_selectedPC].Body = new Item();
            game.playerList.PCList[_selectedPC].Body.ItemName = "";
            txtBody.Text = Item3.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnRemoveMainHand_Click(object sender, EventArgs e)
        {
            if (txtMainHand.Text != "")
            {
                game.partyInventoryList.Add(Item4);
                game.partyInventoryTagList.Add(Item4.ItemTag);
            }
            Item4 = new Item();
            Item4.ItemName = "";
            game.playerList.PCList[_selectedPC].MainHand = new Item();
            game.playerList.PCList[_selectedPC].MainHand.ItemName = "";
            txtMainHand.Text = Item4.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnRemoveOffHand_Click(object sender, EventArgs e)
        {
            if (txtOffHand.Text != "")
            {
                game.partyInventoryList.Add(Item5);
                game.partyInventoryTagList.Add(Item5.ItemTag);
            }
            Item5 = new Item();
            Item5.ItemName = "";
            game.playerList.PCList[_selectedPC].OffHand = new Item();
            game.playerList.PCList[_selectedPC].OffHand.ItemName = "";
            txtOffHand.Text = Item5.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnRemoveRing1_Click(object sender, EventArgs e)
        {
            if (txtRing1.Text != "")
            {
                game.partyInventoryList.Add(Item6);
                game.partyInventoryTagList.Add(Item6.ItemTag);
            }
            Item6 = new Item();
            Item6.ItemName = "";
            game.playerList.PCList[_selectedPC].Ring1 = new Item();
            game.playerList.PCList[_selectedPC].Ring1.ItemName = "";
            txtRing1.Text = Item6.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnRemoveRing2_Click(object sender, EventArgs e)
        {
            if (txtRing2.Text != "")
            {
                game.partyInventoryList.Add(Item7);
                game.partyInventoryTagList.Add(Item7.ItemTag);
            }
            Item7 = new Item();
            Item7.ItemName = "";
            game.playerList.PCList[_selectedPC].Ring2 = new Item();
            game.playerList.PCList[_selectedPC].Ring2.ItemName = "";
            txtRing2.Text = Item7.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnRemoveFeet_Click(object sender, EventArgs e)
        {
            if (txtFeet.Text != "")
            {
                game.partyInventoryList.Add(Item8);
                game.partyInventoryTagList.Add(Item8.ItemTag);
            }
            Item8 = new Item();
            Item8.ItemName = "";
            game.playerList.PCList[_selectedPC].Feet = new Item();
            game.playerList.PCList[_selectedPC].Feet.ItemName = "";
            txtFeet.Text = Item8.ItemName;
            _selectedLbxIndex = 0;
            setupInventoryItemsDataGridView();
            refreshPanelInfo();
            frm.pcInventory.refreshEquippedToPc0();
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (game.partyInventoryList.Count > 0)
            {
                DialogResult dlg = IBMessageBox.Show(game, "Are you sure you wish to drop the item forever?", enumMessageButton.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    game.partyInventoryList.RemoveAt(_selectedLbxIndex);
                    game.partyInventoryTagList.RemoveAt(_selectedLbxIndex);
                    _selectedLbxIndex = 0;
                    setupInventoryItemsDataGridView();
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
            if (game.partyInventoryList.Count > 0)
            {
                game.indexOfPCtoLastUseItem = _selectedPC;
                if ((game.partyInventoryList[_selectedLbxIndex].OnUseItem.FilenameOrTag == "none") || (game.partyInventoryList[_selectedLbxIndex].OnUseItem.FilenameOrTag == ""))
                //if (game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename == "")
                {
                    IBMessageBox.Show(game, "Item does nothing");
                }
                else
                {
                    try
                    {
                        var scriptItm = game.partyInventoryList[_selectedLbxIndex].OnUseItem;
                        frm.doScriptBasedOnFilename(scriptItm.FilenameOrTag, scriptItm.Parm1, scriptItm.Parm2, scriptItm.Parm3, scriptItm.Parm4);
                
                        //frm.doScriptBasedOnFilename(game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs", "", "", "", "");
                        //game.executeScript(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\scripts\\" + game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs");
                        if (game.deleteItemUsedScript)
                        {
                            game.partyInventoryList.RemoveAt(_selectedLbxIndex);
                            game.partyInventoryTagList.RemoveAt(_selectedLbxIndex);
                            _selectedLbxIndex = 0;
                            setupInventoryItemsDataGridView();
                            refreshPanelInfo();
                            game.deleteItemUsedScript = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        IBMessageBox.Show(game, "failed to fire item script");
                        game.errorLog(ex.ToString());
                    }
                }
                frm.doPortraitStats();
            }
        }
        private void btnBuyItem_Click(object sender, EventArgs e)
        {
            if (currentShop.shopItemObjectsList.Count > 0)
            {
                //IBMessageBox.Show(game, "you have: " + game.partyGold.ToString() + " and this costs: " + currentShop.shopItemObjectsList[_selectedLbxIndexShop].ItemValue.ToString());
                //check to see if party has enough money
                if (game.partyGold >= currentShop.shopItemObjectsList[_selectedLbxIndexShop].ItemValue)
                {
                    //if so, add item to party inventory
                    game.partyInventoryList.Add(currentShop.shopItemObjectsList[_selectedLbxIndexShop]);
                    game.partyInventoryTagList.Add(currentShop.shopItemObjectsList[_selectedLbxIndexShop].ItemTag);
                    game.partyGold -= currentShop.shopItemObjectsList[_selectedLbxIndexShop].ItemValue;
                    //remove from shop inventory
                    currentShop.shopItemObjectsList.RemoveAt(_selectedLbxIndexShop);
                    currentShop.shopItemTags.RemoveAt(_selectedLbxIndexShop);
                    _selectedLbxIndexShop = 0;
                    refreshShopPanelInfo();
                    refreshPanelInfo();
                    RefreshGrid(currentShop.shopItemObjectsList);
                    setupShopItemsDataGridView();
                    RefreshGrid(game.partyInventoryList);
                    setupInventoryItemsDataGridView();
                    //DgvColorChange();
                    refreshFunds();
                }
                else
                {
                    IBMessageBox.Show(game, "you do not have enough funds");                
                }                
            }
        }
        private void btnSellItem_Click(object sender, EventArgs e)
        {
            if (game.partyInventoryList.Count > 0)
            {
                //IBMessageBox.Show(game, "you have: " + game.partyGold.ToString() + " and this sells for: " + game.partyInventoryList[_selectedLbxIndex].ItemValue.ToString());
                currentShop.shopItemObjectsList.Add(game.partyInventoryList[_selectedLbxIndex]);
                currentShop.shopItemTags.Add(game.partyInventoryList[_selectedLbxIndex].ItemTag);
                //game.partyInventoryList.Add(currentShop.shopItemObjectsList[_selectedLbxIndexShop]);
                game.partyGold += game.partyInventoryList[_selectedLbxIndex].ItemValue;
                //remove from party inventory
                game.partyInventoryList.RemoveAt(_selectedLbxIndex);
                game.partyInventoryTagList.RemoveAt(_selectedLbxIndex);
                _selectedLbxIndex = 0;
                refreshShopPanelInfo();
                refreshPanelInfo();
                RefreshGrid(currentShop.shopItemObjectsList);
                setupShopItemsDataGridView();
                RefreshGrid(game.partyInventoryList);
                setupInventoryItemsDataGridView();
                //DgvColorChange();
                refreshFunds();
            }            
        }
        private void dgvShopItems_SelectionChanged(object sender, EventArgs e)
        {            
            if (currentShop.shopItemObjectsList.Count > 0)
            {                
                _selectedLbxIndexShop = dgvShopItems.CurrentCell.RowIndex;
                refreshShopPanelInfo();
            }
        }
        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (game.partyInventoryList.Count > 0)
            {
                _selectedLbxIndex = dgvInventory.CurrentCell.RowIndex;
                //refreshPanelInfo();
                refreshDescriptionBox();
            }
        }
        #endregion

        #region Methods
        public void refreshFunds()
        {
            txtFunds.Text = game.partyGold.ToString();
        }
        private void setupLabels()
        {
            label11.Text = "PARTY" + Environment.NewLine + game.module.LabelFunds.ToUpper() + ":";
        }
        public void refreshFonts()
        {
            groupBox1.Font = game.module.ModuleTheme.ModuleFont;
            groupBox2.Font = game.module.ModuleTheme.ModuleFont;
            groupBox3.Font = game.module.ModuleTheme.ModuleFont;
            groupBox4.Font = game.module.ModuleTheme.ModuleFont;
            groupBox5.Font = game.module.ModuleTheme.ModuleFont;
            dgvInventory.Font = game.module.ModuleTheme.ModuleFont;
            dgvShopItems.Font = game.module.ModuleTheme.ModuleFont;
            panel1.Font = game.module.ModuleTheme.ModuleFont;
            btnUseItem.Font = game.module.ModuleTheme.ModuleFont;
            btnDeleteItem.Font = game.module.ModuleTheme.ModuleFont;
            btnBuyItem.Font = game.module.ModuleTheme.ModuleFont;
            btnSellItem.Font = game.module.ModuleTheme.ModuleFont;
            label1.Font = game.module.ModuleTheme.ModuleFont;
            label2.Font = game.module.ModuleTheme.ModuleFont;
            label3.Font = game.module.ModuleTheme.ModuleFont;
            label4.Font = game.module.ModuleTheme.ModuleFont;
            label5.Font = game.module.ModuleTheme.ModuleFont;
            label6.Font = game.module.ModuleTheme.ModuleFont;
            label7.Font = game.module.ModuleTheme.ModuleFont;
            label8.Font = game.module.ModuleTheme.ModuleFont;
            txtBody.Font = game.module.ModuleTheme.ModuleFont;
            txtEncumbrance.Font = game.module.ModuleTheme.ModuleFont;
            txtFeet.Font = game.module.ModuleTheme.ModuleFont;
            txtHead.Font = game.module.ModuleTheme.ModuleFont;
            txtMainHand.Font = game.module.ModuleTheme.ModuleFont;
            txtNeck.Font = game.module.ModuleTheme.ModuleFont;
            txtOffHand.Font = game.module.ModuleTheme.ModuleFont;
            txtRing1.Font = game.module.ModuleTheme.ModuleFont;
            txtRing2.Font = game.module.ModuleTheme.ModuleFont;
            label9.Font = game.module.ModuleTheme.ModuleFont;
            rtxtDesc.Font = game.module.ModuleTheme.ModuleFont;
            rtxtShopItemDesc.Font = game.module.ModuleTheme.ModuleFont;
            txtFunds.Font = game.module.ModuleTheme.ModuleFont;
            label11.Font = game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        public void refreshDescriptionBox()
        {
            if ((game.partyInventoryList.Count > 0) && (_selectedLbxIndex < game.partyInventoryList.Count))
            {
                Item selectedItem = game.partyInventoryList[_selectedLbxIndex];
                refreshDescriptionBox(selectedItem);
            }
        }
        public void refreshDescriptionBox(Item selectedItem)
        {
            try
            {
                //Item selectedItem = pcI_game.partyInventoryList[_selectedLbxIndex];
                if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\data\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\" + selectedItem.ItemIconFilename))
                {
                    pbItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\data\\graphics\\sprites\\" + selectedItem.ItemIconFilename);
                }
                else
                {
                    //do nothing, didn't find image for item
                }
                if ((selectedItem.ItemCategory == Item.category.Melee) || (selectedItem.ItemCategory == Item.category.Ranged))
                {
                    rtxtDesc.Text = selectedItem.ItemDescription + Environment.NewLine +
                                   "Damage: " + selectedItem.ItemDamageNumberOfDice.ToString() + "d" + selectedItem.ItemDamageDie.ToString() + Environment.NewLine +
                                   "Attack Bonus: " + selectedItem.ItemAttackBonus.ToString() + Environment.NewLine +
                                   "Attack Range: " + selectedItem.ItemAttackRange.ToString() + Environment.NewLine +
                                   "Area of Effect: " + selectedItem.ItemAreaOfEffect.ToString();
                }
                else if ((selectedItem.ItemCategory == Item.category.Armor) || (selectedItem.ItemCategory == Item.category.Shield))
                {
                    rtxtDesc.Text = selectedItem.ItemDescription + Environment.NewLine +
                                   "AC Bonus: " + selectedItem.ItemArmorBonus.ToString() + Environment.NewLine +
                                   "Max Dex Bonus: " + selectedItem.ItemMaxDexBonus.ToString() + Environment.NewLine +
                                   "Damage Reduction: " + selectedItem.ItemDamageReduction.ToString();
                }
                else
                    rtxtDesc.Text = selectedItem.ItemDescription;
            }
            catch { }
        }
        public void refreshPanelInfo()
        {
            refreshFonts();            
            try
            {
                if (game.playerList.PCList.Count >= 1)
                {
                    this.rbtnPc0.Visible = true;
                }
                if (game.playerList.PCList.Count >= 2)
                {
                    this.rbtnPc1.Visible = true;
                }
                if (game.playerList.PCList.Count >= 3)
                {
                    this.rbtnPc2.Visible = true;
                }
                if (game.playerList.PCList.Count >= 4)
                {
                    this.rbtnPc3.Visible = true;
                }
                if (game.playerList.PCList.Count >= 5)
                {
                    this.rbtnPc4.Visible = true;
                }
                if (game.playerList.PCList.Count >= 6)
                {
                    this.rbtnPc5.Visible = true;
                }

                if (game.playerList.PCList.Count > 0)
                {
                    rbtnPc0.Image = (Image)game.playerList.PCList[0].portraitBitmapS;
                    this.rbtnPc0.Enabled = true;
                }
                if (game.playerList.PCList.Count > 1)
                {
                    rbtnPc1.Image = (Image)game.playerList.PCList[1].portraitBitmapS;
                    this.rbtnPc1.Enabled = true;
                }
                if (game.playerList.PCList.Count > 2)
                {
                    rbtnPc2.Image = (Image)game.playerList.PCList[2].portraitBitmapS;
                    this.rbtnPc2.Enabled = true;
                }
                if (game.playerList.PCList.Count > 3)
                {
                    rbtnPc3.Image = (Image)game.playerList.PCList[3].portraitBitmapS;
                    this.rbtnPc3.Enabled = true;
                }
                if (game.playerList.PCList.Count > 4)
                {
                    rbtnPc4.Image = (Image)game.playerList.PCList[4].portraitBitmapS;
                    this.rbtnPc4.Enabled = true;
                }
                if (game.playerList.PCList.Count > 5)
                {
                    rbtnPc5.Image = (Image)game.playerList.PCList[5].portraitBitmapS;
                    this.rbtnPc5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                game.errorLog(ex.ToString());
            }
        }
        public void refreshShopPanelInfo()
        {
            if ((currentShop.shopItemObjectsList.Count > 0) && (_selectedLbxIndexShop < currentShop.shopItemObjectsList.Count))
            {
                Item selectedItem = currentShop.shopItemObjectsList[_selectedLbxIndexShop];
                if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename))
                {
                    pbShopItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + selectedItem.ItemIconFilename))
                {
                    pbShopItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename))
                {
                    pbShopItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\data\\graphics\\sprites\\items\\" + selectedItem.ItemIconFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\" + selectedItem.ItemIconFilename))
                {
                    pbShopItemIcon.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\data\\graphics\\sprites\\" + selectedItem.ItemIconFilename);
                }
                else
                {
                    //do nothing, didn't find image for item
                }
                if ((selectedItem.ItemCategory == Item.category.Melee) || (selectedItem.ItemCategory == Item.category.Ranged))
                {
                    rtxtShopItemDesc.Text = selectedItem.ItemDescription + Environment.NewLine +
                                   "Damage: " + selectedItem.ItemDamageNumberOfDice.ToString() + "d" + selectedItem.ItemDamageDie.ToString() + Environment.NewLine +
                                   "Attack Bonus: " + selectedItem.ItemAttackBonus.ToString() + Environment.NewLine +
                                   "Attack Range: " + selectedItem.ItemAttackRange.ToString() + Environment.NewLine +
                                   "Area of Effect: " + selectedItem.ItemAreaOfEffect.ToString();
                }
                else if ((selectedItem.ItemCategory == Item.category.Armor) || (selectedItem.ItemCategory == Item.category.Shield))
                {
                    rtxtShopItemDesc.Text = selectedItem.ItemDescription + Environment.NewLine +
                                   "AC Bonus: " + selectedItem.ItemArmorBonus.ToString() + Environment.NewLine +
                                   "Max Dex Bonus: " + selectedItem.ItemMaxDexBonus.ToString() + Environment.NewLine +
                                   "Damage Reduction: " + selectedItem.ItemDamageReduction.ToString();
                }
                else
                    rtxtShopItemDesc.Text = selectedItem.ItemDescription;
            }
        }
        private void setupShopItemsDataGridView()
        {
            dgvShopItems.DataSource = currentShop.shopItemObjectsList;
            dgvShopItems.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "ItemName";
            columnA.HeaderText = "Item Name";
            columnA.Name = "itemName";
            columnA.Width = 140;

            DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
            columnB.DataPropertyName = "ItemValue";
            columnB.HeaderText = "Value";
            columnB.Name = "itemValue";
            columnB.Width = 50;

            dgvShopItems.Columns.Clear();
            dgvShopItems.Columns.Add(columnA);
            dgvShopItems.Columns.Add(columnB);
            DgvColorChange();
        }
        private void setupInventoryItemsDataGridView()
        {
            dgvInventory.DataSource = game.partyInventoryList;
            dgvInventory.AutoGenerateColumns = false;

            DataGridViewColumn columnA = new DataGridViewTextBoxColumn();
            columnA.DataPropertyName = "ItemName";
            columnA.HeaderText = "Item Name";
            columnA.Name = "itemName";
            columnA.Width = 140;

            DataGridViewColumn columnB = new DataGridViewTextBoxColumn();
            columnB.DataPropertyName = "ItemValue";
            columnB.HeaderText = "Value";
            columnB.Name = "itemValue";
            columnB.Width = 50;

            dgvInventory.Columns.Clear();
            dgvInventory.Columns.Add(columnA);
            dgvInventory.Columns.Add(columnB);
            DgvColorChange();
        }
        private void DgvColorChange()
        {
            DataGridViewCellStyle RedCellStyle = new DataGridViewCellStyle();
            RedCellStyle.ForeColor = Color.Red;
            DataGridViewCellStyle BlackCellStyle = new DataGridViewCellStyle();
            BlackCellStyle.ForeColor = Color.Black;

            foreach (DataGridViewRow dgvr in dgvShopItems.Rows)
            {
                if (dgvr.Cells[0].Value != null)
                {
                    string itemName = dgvr.Cells[0].Value.ToString();
                    Item item = game.module.ModuleItemsList.getItem(itemName);
                    //if class doesn't allow item show as red, else black
                    if (game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(item.ItemResRef))
                    { dgvr.DefaultCellStyle = BlackCellStyle; }
                    else
                    { dgvr.DefaultCellStyle = RedCellStyle; }
                }
            }

            foreach (DataGridViewRow dgvr in dgvInventory.Rows)
            {
                if (dgvr.Cells[0].Value != null)
                {
                    string itemName = dgvr.Cells[0].Value.ToString();
                    Item item = game.module.ModuleItemsList.getItem(itemName);
                    //if class doesn't allow item show as red, else black
                    if (game.playerList.PCList[_selectedPC].Class.ItemsAllowed.Contains(item.ItemResRef))
                    { dgvr.DefaultCellStyle = BlackCellStyle; }
                    else
                    { dgvr.DefaultCellStyle = RedCellStyle; }
                }
            }
        }
        private void RefreshGrid(object dataSource)
        {
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataSource];
            myCurrencyManager.Refresh();
        }
        #endregion        

        private void dgvShopItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //IBMessageBox.Show(game, "data error: " + e.ToString());
        }
        private void dgvInventory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //IBMessageBox.Show(game, "data error: " + e.ToString());
        }

        private void txtHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtHead.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].Head;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtNeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtNeck.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].Neck;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtBody_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBody.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].Body;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtMainHand_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtMainHand.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].MainHand;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtOffHand_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtOffHand.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].OffHand;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtRing1_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtRing1.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].Ring1;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtRing2_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtRing2.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].Ring2;
                refreshDescriptionBox(selectedItem);
            }
        }
        private void txtFeet_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtFeet.Text != "")
            {
                Item selectedItem = game.playerList.PCList[_selectedPC].Feet;
                refreshDescriptionBox(selectedItem);
            }
        }        
    }
}
