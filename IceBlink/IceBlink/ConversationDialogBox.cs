using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using System.Text.RegularExpressions;

namespace IceBlink
{
    public partial class ConversationDialogBox : IBForm
    {
        Game c_game;
        Form1 c_frm;
        Convo t_convo = new Convo();
        int originalSelectedPartyLeader = 0;
        int parentIdNum = 0;
        bool userClosingConvo;
        public Bitmap convoBitmap;
        public Bitmap convoPlusBitmap;
        public List<PlayerNodeLink> playerNodeLinkList = new List<PlayerNodeLink>();
        private bool doActions = true;

        public ConversationDialogBox(Game game, Form1 frm, string filename)
        {
            InitializeComponent();
            userClosingConvo = true;
            c_game = game;
            c_frm = frm;
            IceBlinkButtonResize.setupAll(c_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(c_game);
            IceBlinkButtonClose.Enabled = false;
            IceBlinkButtonClose.Visible = false;
            this.setupAll(c_game);
            if (game.playerList.PCList[game.selectedPartyLeader].Status == CharBase.charStatus.Dead)
            {
                c_frm.SwitchToNextAvailablePartyLeader();
            }
            originalSelectedPartyLeader = c_game.selectedPartyLeader;
            this.panel1.BackColor = c_game.module.ModuleTheme.ConvoBackColor;
            this.panel2.BackColor = c_game.module.ModuleTheme.ConvoBackColor;
            this.rtxtNPC.BackColor = c_game.module.ModuleTheme.ConvoBackColor;
            this.rtxtNPC.ForeColor = c_game.module.ModuleTheme.ConvoTextColor;
            this.linkLabel1.LinkColor = c_game.module.ModuleTheme.ConvoTextColor;
            this.linkLabel2.LinkColor = c_game.module.ModuleTheme.ConvoTextColor;
            this.linkLabel3.LinkColor = c_game.module.ModuleTheme.ConvoTextColor;
            this.linkLabel4.LinkColor = c_game.module.ModuleTheme.ConvoTextColor;
            this.linkLabel5.LinkColor = c_game.module.ModuleTheme.ConvoTextColor;
            this.linkLabel6.LinkColor = c_game.module.ModuleTheme.ConvoTextColor;
            t_convo = t_convo.GetConversation(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\dialog\\" + filename + ".xml");
            t_convo.passRefs(c_game);
            SetNodeIsActiveFalseForAll();
            parentIdNum = getParentIdNum(parentIdNum);
            refreshFonts();
            if (t_convo.Narration)
            {
                if (t_convo.NpcPortraitBitmap != "") //Narration with image
                {
                    this.Size = new System.Drawing.Size(446, 490);
                    this.pictureBox1.Location = new System.Drawing.Point(21, 36);
                    this.pictureBox1.Size = new System.Drawing.Size(404, 204); // narration pictures should be 400x200
                    this.panel1.Location = new System.Drawing.Point(21, 246);
                    this.panel1.Size = new System.Drawing.Size(404, 175);
                    this.panel2.Location = new System.Drawing.Point(21, 427);
                    this.panel2.Size = new System.Drawing.Size(404, 39);
                }
                else //Narration without image
                {
                    this.Size = new System.Drawing.Size(446, 280);
                    this.panel1.Location = new System.Drawing.Point(21, 36);
                    this.panel1.Size = new System.Drawing.Size(404, 175);
                    this.panel2.Location = new System.Drawing.Point(21, 220);
                    this.panel2.Size = new System.Drawing.Size(404, 39);                                       
                }
                this.rbtnPc0.Enabled = false;
                this.rbtnPc1.Enabled = false;
                this.rbtnPc2.Enabled = false;
                this.rbtnPc3.Enabled = false;
                this.rbtnPc4.Enabled = false;
                this.rbtnPc5.Enabled = false;
                this.rbtnPc0.Visible = false;
                this.rbtnPc1.Visible = false;
                this.rbtnPc2.Visible = false;
                this.rbtnPc3.Visible = false;
                this.rbtnPc4.Visible = false;
                this.rbtnPc5.Visible = false; 
            }
            // load image for convo
            try
            {
                convoBitmap = new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\dialog\\" + t_convo.NpcPortraitBitmap);
            }
            catch (Exception ex)
            {
                //IBMessageBox.Show(game, "No image was associated with this convo (or load error), using a default");
                c_game.errorLog(ex.ToString());
                convoBitmap = new Bitmap(game.mainDirectory + "\\data\\graphics\\NOPORT_L.png");
            }              
            pictureBox1.Image = (Image)convoBitmap;

            loadConvoPlusImage();

            //doAction() for current npc Node (all actions for node)
            /*foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(parentIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                //action.doAction(ref c_game);
            }*/
            
            refreshPcPortraits();
            if ((!t_convo.PartyChat) && (!t_convo.Narration)) //if using old style and not a narration, highlight the selectedPartyLeader image
            {
                if (c_game.selectedPartyLeader == 0)
                {
                    rbtnPc0.Checked = true;
                }
                else if (c_game.selectedPartyLeader == 1)
                {
                    rbtnPc1.Checked = true;
                }
                else if (c_game.selectedPartyLeader == 2)
                {
                    rbtnPc2.Checked = true;
                }
                else if (c_game.selectedPartyLeader == 3)
                {
                    rbtnPc3.Checked = true;
                }
                else if (c_game.selectedPartyLeader == 4)
                {
                    rbtnPc4.Checked = true;
                }
                else if (c_game.selectedPartyLeader == 5)
                {
                    rbtnPc5.Checked = true;
                }
            }
            doActions = true;            
            doConvo(parentIdNum); // load up the text for the NPC node and all PC responses
        }
        private void SetNodeIsActiveFalseForAll()
        {
            foreach (ConvoSavedValues csv in c_game.module.ModuleConvoSavedValuesList)
            {
                if (csv.ConvoFileName == t_convo.ConvoFileName)
                {
                    t_convo.GetContentNodeById(csv.NodeNotActiveIdNum).NodeIsActive = false;
                }
            }
        }
        public void refreshFonts()
        {
            panel2.Font = c_game.module.ModuleTheme.ModuleFont;
            //label0.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            rtxtNPC.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            linkLabel1.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            linkLabel2.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            linkLabel3.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            linkLabel4.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            linkLabel5.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            linkLabel6.Font = c_frm.ChangeFontSize(c_game.module.ModuleTheme.ModuleFont, 1.25f);
            this.Invalidate();
        }
        public void refreshPcPortraits()
        {
            //refreshFonts();
            if (!t_convo.Narration)
            {
                try
                {
                    if (c_game.playerList.PCList.Count >= 1)
                    {
                        if ((!t_convo.PartyChat) && (c_game.selectedPartyLeader != 0))
                        {
                            this.rbtnPc0.Visible = false;
                        }
                        else
                        {
                            this.rbtnPc0.Visible = true;
                        }
                    }
                    if (c_game.playerList.PCList.Count >= 2)
                    {
                        if ((!t_convo.PartyChat) && (c_game.selectedPartyLeader != 1))
                        {
                            this.rbtnPc1.Visible = false;
                        }
                        else
                        {
                            this.rbtnPc1.Visible = true;
                        }
                    }
                    if (c_game.playerList.PCList.Count >= 3)
                    {
                        if ((!t_convo.PartyChat) && (c_game.selectedPartyLeader != 2))
                        {
                            this.rbtnPc2.Visible = false;
                        }
                        else
                        {
                            this.rbtnPc2.Visible = true;
                        }
                    }
                    if (c_game.playerList.PCList.Count >= 4)
                    {
                        if ((!t_convo.PartyChat) && (c_game.selectedPartyLeader != 3))
                        {
                            this.rbtnPc3.Visible = false;
                        }
                        else
                        {
                            this.rbtnPc3.Visible = true;
                        }
                    }
                    if (c_game.playerList.PCList.Count >= 5)
                    {
                        if ((!t_convo.PartyChat) && (c_game.selectedPartyLeader != 4))
                        {
                            this.rbtnPc4.Visible = false;
                        }
                        else
                        {
                            this.rbtnPc4.Visible = true;
                        }
                    }
                    if (c_game.playerList.PCList.Count >= 6)
                    {
                        if ((!t_convo.PartyChat) && (c_game.selectedPartyLeader != 5))
                        {
                            this.rbtnPc5.Visible = false;
                        }
                        else
                        {
                            this.rbtnPc5.Visible = true;
                        }
                    }

                    if (c_game.playerList.PCList.Count > 0)
                    {
                        rbtnPc0.BackgroundImage = (Image)c_game.playerList.PCList[0].portraitBitmapS;
                        if ((t_convo.PartyChat) || (c_game.selectedPartyLeader == 0))
                        {
                            if (c_game.playerList.PCList[0].Status != CharBase.charStatus.Dead)
                            {
                                this.rbtnPc0.Enabled = true;
                            }
                        }
                    }
                    if (c_game.playerList.PCList.Count > 1)
                    {
                        rbtnPc1.BackgroundImage = (Image)c_game.playerList.PCList[1].portraitBitmapS;
                        if ((t_convo.PartyChat) || (c_game.selectedPartyLeader == 1))
                        {
                            if (c_game.playerList.PCList[1].Status != CharBase.charStatus.Dead)
                            {
                                this.rbtnPc1.Enabled = true;
                            }
                        }
                    }
                    if (c_game.playerList.PCList.Count > 2)
                    {
                        rbtnPc2.BackgroundImage = (Image)c_game.playerList.PCList[2].portraitBitmapS;
                        if ((t_convo.PartyChat) || (c_game.selectedPartyLeader == 2))
                        {
                            if (c_game.playerList.PCList[2].Status != CharBase.charStatus.Dead)
                            {
                                this.rbtnPc2.Enabled = true;
                            }
                        }
                    }
                    if (c_game.playerList.PCList.Count > 3)
                    {
                        rbtnPc3.BackgroundImage = (Image)c_game.playerList.PCList[3].portraitBitmapS;
                        if ((t_convo.PartyChat) || (c_game.selectedPartyLeader == 3))
                        {
                            if (c_game.playerList.PCList[3].Status != CharBase.charStatus.Dead)
                            {
                                this.rbtnPc3.Enabled = true;
                            }
                        }
                    }
                    if (c_game.playerList.PCList.Count > 4)
                    {
                        rbtnPc4.BackgroundImage = (Image)c_game.playerList.PCList[4].portraitBitmapS;
                        if ((t_convo.PartyChat) || (c_game.selectedPartyLeader == 4))
                        {
                            if (c_game.playerList.PCList[4].Status != CharBase.charStatus.Dead)
                            {
                                this.rbtnPc4.Enabled = true;
                            }
                        }
                    }
                    if (c_game.playerList.PCList.Count > 5)
                    {
                        rbtnPc5.BackgroundImage = (Image)c_game.playerList.PCList[5].portraitBitmapS;
                        if ((t_convo.PartyChat) || (c_game.selectedPartyLeader == 5))
                        {
                            if (c_game.playerList.PCList[5].Status != CharBase.charStatus.Dead)
                            {
                                this.rbtnPc5.Enabled = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    c_game.errorLog(ex.ToString());
                }
            }
        }
        private int getParentIdNum(int childIdNum) // Gets the first NPC node idNum that returns a true conditional
        {
            //first determine which NPC subNode to use by cycling through all children of parentNode until one returns true from conditionals
            foreach (ContentNode npcNode in t_convo.GetContentNodeById(childIdNum).subNodes)
            {
                bool check = true;
                ContentNode chkNode = new ContentNode();
                chkNode.passRefs(c_game);
                chkNode = npcNode;
                // IBMessageBox.Show(c_game, "npcNode.IdNum = " + npcNode.idNum.ToString());
                // cycle through the conditions of each npcNode and check for true
                // if one node is a link, then go to the linked node and check its conditional
                if (npcNode.isLink)
                {
                    chkNode = t_convo.GetContentNodeById(npcNode.linkTo);
                }
                bool AndStatments = true;
                foreach (Condition conditional in chkNode.conditions)
                {
                    if (!conditional.c_and)
                    {
                        AndStatments = false;
                        break;
                    }
                }
                foreach (Condition conditional in chkNode.conditions)
                {
                    c_frm.doScriptBasedOnFilename(conditional.c_script, conditional.c_parameter_1, conditional.c_parameter_2, conditional.c_parameter_3, conditional.c_parameter_4);
                    if (AndStatments) //this is an "and" set
                    {
                        if ((c_game.returnCheck == false) && (conditional.c_not == false))
                        {
                            check = false;
                        }
                        if ((c_game.returnCheck == true) && (conditional.c_not == true))
                        {
                            check = false;
                        }
                    }
                    else //this is an "or" set
                    {
                        if ((c_game.returnCheck == false) && (conditional.c_not == false))
                        {
                            check = false;
                        }
                        else if ((c_game.returnCheck == true) && (conditional.c_not == true))
                        {
                            check = false;
                        }
                        else //in "or" statement, if find one true then done
                        {
                            check = true;
                            break;
                        }
                    }
                    /*OLD WAY
                    c_frm.doScriptBasedOnFilename(conditional.c_script, conditional.c_parameter_1, conditional.c_parameter_2, conditional.c_parameter_3, conditional.c_parameter_4);
                    if ((c_game.returnCheck == false) && (conditional.c_not == false))
                    {
                        check = false;
                        continue;
                    }
                    if ((c_game.returnCheck == true) && (conditional.c_not == true))
                    {
                        check = false;
                        continue;
                    }
                    */
                    //if ((c_game.returnCheck == true) && (!conditional.c_and))
                    //{
                    //    break;
                    //}
                    //IBMessageBox.Show(c_game,"script: " + conditional.c_script + "  variable: " + conditional.c_parameter_1 + "  value: " + conditional.c_parameter_2);
                }
                if ((check == true) && (chkNode.NodeIsActive))
                {
                    //IBMessageBox.Show(c_game, "returning npcNode.idNum = " + npcNode.idNum.ToString());
                    if (chkNode.ShowOnlyOnce)
                    {
                        chkNode.NodeIsActive = false;
                        saveNodeIsActiveFalseToModule(chkNode);
                    }
                    return chkNode.idNum;
                }
            }
            if (t_convo.GetContentNodeById(childIdNum).subNodes[0].ShowOnlyOnce)
            {
                t_convo.GetContentNodeById(childIdNum).subNodes[0].NodeIsActive = false;
                saveNodeIsActiveFalseToModule(t_convo.GetContentNodeById(childIdNum).subNodes[0]);
            }
            return t_convo.GetContentNodeById(childIdNum).subNodes[0].idNum;
        }
        /*private void doConvo(int parentIdNum) // load up the text for the NPC node and all PC responses
        {
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(parentIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
            }
            rtxtNPC.Text = replaceText(t_convo.GetContentNodeById(parentIdNum).conversationText);

            if (t_convo.Narration)
            {
                linkLabel1.TextAlign = ContentAlignment.TopCenter;
            }
            else
            {
                linkLabel1.Location = new System.Drawing.Point(5, 10);
            }
            loadNodePortrait();
            playNodeSound();
            linkLabel1.Text = "1) " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[0].conversationText);

            if (t_convo.GetContentNodeById(parentIdNum).subNodes.Count > 1)
            {
                linkLabel2.Location = new System.Drawing.Point(5, linkLabel1.Location.Y + linkLabel1.Height + 10);
                linkLabel2.Text = "2) " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[1].conversationText);
            }
            else { linkLabel2.Text = ""; }

            if (t_convo.GetContentNodeById(parentIdNum).subNodes.Count > 2)
            {
                linkLabel3.Location = new System.Drawing.Point(5, linkLabel2.Location.Y + linkLabel2.Height + 10);
                linkLabel3.Text = "3) " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[2].conversationText);
            }
            else { linkLabel3.Text = ""; }

            if (t_convo.GetContentNodeById(parentIdNum).subNodes.Count > 3)
            {
                linkLabel4.Location = new System.Drawing.Point(5, linkLabel3.Location.Y + linkLabel3.Height + 10);
                linkLabel4.Text = "4) " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[3].conversationText);
            }
            else { linkLabel4.Text = ""; }

            if (t_convo.GetContentNodeById(parentIdNum).subNodes.Count > 4)
            {
                linkLabel5.Location = new System.Drawing.Point(5, linkLabel4.Location.Y + linkLabel4.Height + 10);
                linkLabel5.Text = "5) " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[4].conversationText);
            }
            else { linkLabel5.Text = ""; }

            if (t_convo.GetContentNodeById(parentIdNum).subNodes.Count > 5)
            {
                linkLabel6.Location = new System.Drawing.Point(5, linkLabel5.Location.Y + linkLabel5.Height + 10);
                linkLabel6.Text = "6) " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[5].conversationText);
            }
            else { linkLabel6.Text = ""; }
        }
        */
        private void saveNodeIsActiveFalseToModule(ContentNode nod)
        {
            ConvoSavedValues newCSV = new ConvoSavedValues();
            newCSV.ConvoFileName = t_convo.ConvoFileName;
            newCSV.NodeNotActiveIdNum = nod.idNum;
            c_game.module.ModuleConvoSavedValuesList.Add(newCSV);
        }
        private void doConvo(int parentIdNum) // load up the text for the NPC node and all PC responses
        {
            string selectedPcOptions = "";
            string comparePcOptions = "";
            rbtnPc0.Image = null;
            rbtnPc1.Image = null;
            rbtnPc2.Image = null;
            rbtnPc3.Image = null;
            rbtnPc4.Image = null;
            rbtnPc5.Image = null;
            //rbtnPc0.Text = "";
            //rbtnPc1.Text = "";
            //rbtnPc2.Text = "";
            //rbtnPc3.Text = "";
            //rbtnPc4.Text = "";
            //rbtnPc5.Text = "";
            //reset list of PlayerNodeList
            playerNodeLinkList.Clear();
            this.panel2.Controls.Clear();

            if (doActions)
            {
                foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(parentIdNum).actions)
                {
                    //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                    c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                }
            }
            rtxtNPC.Text = replaceText(t_convo.GetContentNodeById(parentIdNum).conversationText);

            #region loop through all nodes and check to see if they should be visible
            int cnt = 0; 
            foreach (ContentNode pcNode in t_convo.GetContentNodeById(parentIdNum).subNodes)
            {
                //check to see if passes conditional
                bool check = true;
                ContentNode chkNode = new ContentNode();
                chkNode.passRefs(c_game);
                chkNode = pcNode;
                //MessageBox.Show("pcNode.IdNum = " + pcNode.idNum.ToString());
                // cycle through the conditions of each pcNode and check for true
                // if one node is a link, then go to the linked node and check its conditional
                if (pcNode.isLink)
                {
                    chkNode = t_convo.GetContentNodeById(pcNode.linkTo);
                }
                bool AndStatments = true;
                foreach (Condition conditional in chkNode.conditions)
                {
                    if (!conditional.c_and)
                    {
                        AndStatments = false;
                        break;
                    }
                }
                foreach (Condition conditional in chkNode.conditions)
                {
                    c_frm.doScriptBasedOnFilename(conditional.c_script, conditional.c_parameter_1, conditional.c_parameter_2, conditional.c_parameter_3, conditional.c_parameter_4);
                    if (AndStatments) //this is an "and" set
                    {
                        if ((c_game.returnCheck == false) && (conditional.c_not == false))
                        {
                            check = false;
                        }
                        if ((c_game.returnCheck == true) && (conditional.c_not == true))
                        {
                            check = false;
                        }
                    }
                    else //this is an "or" set
                    {
                        if ((c_game.returnCheck == false) && (conditional.c_not == false))
                        {
                            check = false;
                        }
                        else if ((c_game.returnCheck == true) && (conditional.c_not == true))
                        {
                            check = false;
                        }
                        else //in "or" statement, if find one true then done
                        {
                            check = true;
                            break;
                        }
                    }
                    //MessageBox.Show("script: " + conditional.c_script + "  variable: " + conditional.c_parameter_1 + "  value: " + conditional.c_parameter_2);
                }
                if (check == true)
                {
                    //MessageBox.Show("returning pcNode.idNum = " + pcNode.idNum.ToString());
                    //if pass, then show and add to playerNodeList
                    PlayerNodeLink newNode = new PlayerNodeLink();
                    //assign the nodeIndex to the linkNode
                    newNode.nodeIndex = cnt;
                    selectedPcOptions += cnt.ToString();
                    newNode.SetUpNode(c_game, c_frm);
                    newNode.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
                    playerNodeLinkList.Add(newNode);
                    this.panel2.Controls.Add(newNode.linkLabel);
                }                
                cnt++;
            }
            #endregion

            #region Iterate through all other PCs and see what node options they have and indicate if different
            int PcIndx = 0;
            int originalPartyLeader = c_game.selectedPartyLeader;
            //int tempPartyLeader = 0;
            foreach (PC pc in c_game.playerList.PCList)
            {
                comparePcOptions = "";
                c_game.selectedPartyLeader = PcIndx;
                if (PcIndx != originalPartyLeader)
                {
                    //loop through all nodes and check to see if they should be visible
                    int cntr = 0;
                    foreach (ContentNode pcNode in t_convo.GetContentNodeById(parentIdNum).subNodes)
                    {
                        //check to see if passes conditional
                        bool check = true;
                        ContentNode chkNode = new ContentNode();
                        chkNode.passRefs(c_game);
                        chkNode = pcNode;
                        // cycle through the conditions of each pcNode and check for true
                        // if one node is a link, then go to the linked node and check its conditional
                        if (pcNode.isLink)
                        {
                            chkNode = t_convo.GetContentNodeById(pcNode.linkTo);
                        }
                        foreach (Condition conditional in chkNode.conditions)
                        {
                            c_frm.doScriptBasedOnFilename(conditional.c_script, conditional.c_parameter_1, conditional.c_parameter_2, conditional.c_parameter_3, conditional.c_parameter_4);
                            if ((c_game.returnCheck == false) && (conditional.c_not == false))
                            {
                                check = false;
                            }
                            if ((c_game.returnCheck == true) && (conditional.c_not == true))
                            {
                                check = false;
                            }
                        }
                        if (check == true)
                        {
                            comparePcOptions += cntr.ToString();
                        }
                        cntr++;
                    }
                    //compare this PC to the selectedPartyLeader's options
                    if (comparePcOptions != selectedPcOptions)
                    {
                        //if different, Place a Text Letter on Button "+"
                        //if (PcIndx == 0) { rbtnPc0.Text = "+"; }
                        //if (PcIndx == 1) { rbtnPc1.Text = "+"; }
                        //if (PcIndx == 2) { rbtnPc2.Text = "+"; }
                        //if (PcIndx == 3) { rbtnPc3.Text = "+"; }
                        //if (PcIndx == 4) { rbtnPc4.Text = "+"; }
                        //if (PcIndx == 5) { rbtnPc5.Text = "+"; }

                        if (PcIndx == 0) { rbtnPc0.Image = convoPlusBitmap; }
                        if (PcIndx == 1) { rbtnPc1.Image = convoPlusBitmap; }
                        if (PcIndx == 2) { rbtnPc2.Image = convoPlusBitmap; }
                        if (PcIndx == 3) { rbtnPc3.Image = convoPlusBitmap; }
                        if (PcIndx == 4) { rbtnPc4.Image = convoPlusBitmap; }
                        if (PcIndx == 5) { rbtnPc5.Image = convoPlusBitmap; }
                    }                    
                }
                PcIndx++;
            }
            #endregion
            //return back to original selected PC after making checks for different node options available
            c_game.selectedPartyLeader = originalPartyLeader;

            #region Iterate through all playerNodeLinkList and assign location and text
            for (int i = 0; i < playerNodeLinkList.Count; i++)
            {
                if (i == 0)
                {
                    if (t_convo.Narration)
                    {
                        /*
                        int startX = (panel2.Width / 2) - (playerNodeLinkList[i].linkLabel.Width / 2);
                        if (startX < 5) { startX = 5; }
                        //playerNodeLinkList[i].linkLabel.TextAlign = ContentAlignment.TopCenter;
                        playerNodeLinkList[i].linkLabel.Location = new System.Drawing.Point(startX, 10);
                        */
                        playerNodeLinkList[i].linkLabel.Location = new System.Drawing.Point(5, 10);
                    }
                    else
                    {
                        playerNodeLinkList[i].linkLabel.Location = new System.Drawing.Point(5, 10);
                    }
                    playerNodeLinkList[i].linkLabel.Text = "1) " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[playerNodeLinkList[i].nodeIndex].conversationText);
                }
                else
                {
                    playerNodeLinkList[i].linkLabel.Location = new System.Drawing.Point(5, playerNodeLinkList[i - 1].linkLabel.Location.Y + playerNodeLinkList[i - 1].linkLabel.Height + 10);
                    playerNodeLinkList[i].linkLabel.Text = (i + 1).ToString() + ") " + replaceText(t_convo.GetContentNodeById(parentIdNum).subNodes[playerNodeLinkList[i].nodeIndex].conversationText);
                }
            }          
            #endregion

            //adjust response window size for multiple response narration dialog
            if (t_convo.Narration)
            {
                int ySize = playerNodeLinkList[playerNodeLinkList.Count - 1].linkLabel.Location.Y + playerNodeLinkList[playerNodeLinkList.Count - 1].linkLabel.Height + 15;
                int yBottom = this.panel2.Location.Y + ySize + 20;
                this.Size = new System.Drawing.Size(446, yBottom);
                this.panel2.Size = new System.Drawing.Size(404, ySize);
            }
            ParseItalicText(rtxtNPC);
            ParseBoldText(rtxtNPC);
            //load node portrait and play node sound
            loadNodePortrait();
            playNodeSound();
        }
        private void ParseBoldText(RichTextBox tb)
        {
            ////Bold Parsing////
            int parseCount = 0;
            int lastStartPosition = 0;
            int currentPosition = 0;

            if (tb.Text.Substring(0, 3) == "[b]")
            {
                tb.Text = " " + tb.Text;
            }

            while (currentPosition < tb.Text.Length - 3)
            {
                if (tb.Text.Substring(currentPosition, 3) == "[b]")
                {
                    if (parseCount == 0)
                    {
                        lastStartPosition = currentPosition;
                    }
                    parseCount++;
                }
                if (tb.Text.Substring(currentPosition, 4) == "[/b]")
                {
                    parseCount--;
                    if (parseCount == 0)
                    {
                        tb.Select(lastStartPosition + 3, currentPosition - lastStartPosition - 3);
                        tb.SelectionFont = new Font(tb.SelectionFont.FontFamily, tb.SelectionFont.Size, tb.SelectionFont.Style | FontStyle.Bold);
                    }
                }
                currentPosition += 1;
            }

            //clean the <B> tags, carefulf to use the RTF property instead of TEXT property !!!!
            tb.Rtf = tb.Rtf.Replace("[b]", "");
            tb.Rtf = tb.Rtf.Replace("[/b]", "");
            /////End Parsing Bold
        }
        private void ParseItalicText(RichTextBox tb)
        {
            ////Italic Parsing////
            int parseCount = 0;
            int lastStartPosition = 0;
            int currentPosition = 0;

            if (tb.Text.Substring(0, 3) == "[i]")
            {
                tb.Text = " " + tb.Text;
            }

            while (currentPosition < tb.Text.Length - 3)
            {
                if (tb.Text.Substring(currentPosition, 3) == "[i]")
                {
                    if (parseCount == 0)
                    {
                        lastStartPosition = currentPosition;
                    }
                    parseCount++;
                }
                if (tb.Text.Substring(currentPosition, 4) == "[/i]")
                {
                    parseCount--;
                    if (parseCount == 0)
                    {
                        tb.Select(lastStartPosition + 3, currentPosition - lastStartPosition - 3);
                        tb.SelectionFont = new Font(tb.SelectionFont.FontFamily, tb.SelectionFont.Size, tb.SelectionFont.Style | FontStyle.Italic);
                    }
                }
                currentPosition += 1;
            }

            //clean the <i> tags, carefulf to use the RTF property instead of TEXT property !!!!
            tb.Rtf = tb.Rtf.Replace("[i]", "");
            tb.Rtf = tb.Rtf.Replace("[/i]", "");
            /////End Parsing Bold
        }
        public string replaceText(string originalText)
        {
            PC pc = c_game.playerList.PCList[c_game.selectedPartyLeader];
            var newString = Regex.Replace(originalText, @"\<(.*?)\>",
                        m =>
                        {
                            var codeString = m.Groups[1].Value;

                            switch (codeString)
                            {
                                case "FirstName":
                                    codeString = pc.Name;
                                    break;
                                case "FullName":
                                    codeString = pc.Name;
                                    break;
                                case "Class":
                                    codeString = pc.Class.PlayerClassName;
                                    break;
                                case "class":
                                    codeString = pc.Class.PlayerClassName.ToLower();
                                    break;
                                case "Race":
                                    codeString = pc.Race.RaceName;
                                    break;
                                case "race":
                                    codeString = pc.Race.RaceName.ToLower();
                                    break;
                                case "Sir/Madam":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "Sir"; }
                                    else { codeString = "Madam"; }
                                    break;
                                case "sir/madam":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "sir"; }
                                    else { codeString = "madam"; }
                                    break;
                                case "His/Her":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "His"; }
                                    else { codeString = "Her"; }
                                    break;
                                case "his/her":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "his"; }
                                    else { codeString = "her"; }
                                    break;
                                case "Him/Her":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "Him"; }
                                    else { codeString = "Her"; }
                                    break;
                                case "him/her":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "him"; }
                                    else { codeString = "her"; }
                                    break;
                                case "He/She":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "He"; }
                                    else { codeString = "She"; }
                                    break;
                                case "he/she":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "he"; }
                                    else { codeString = "she"; }
                                    break;
                                case "Boy/Girl":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "Boy"; }
                                    else { codeString = "Girl"; }
                                    break;
                                case "boy/girl":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "boy"; }
                                    else { codeString = "girl"; }
                                    break;
                                case "Lad/Lass":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "Lad"; }
                                    else { codeString = "Lass"; }
                                    break;
                                case "lad/lass":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "lad"; }
                                    else { codeString = "lass"; }
                                    break;
                                case "Man/Woman":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "Man"; }
                                    else { codeString = "Woman"; }
                                    break;
                                case "man/woman":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "man"; }
                                    else { codeString = "woman"; }
                                    break;
                                case "Brother/Sister":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "Brother"; }
                                    else { codeString = "Sister"; }
                                    break;
                                case "brother/sister":
                                    if (pc.Gender == CharBase.gender.Male) { codeString = "brother"; }
                                    else { codeString = "sister"; }
                                    break;
                                default:
                                    codeString = "TOKEN_FAILED";
                                    break;
                            }

                            // then you have to evaluate this string
                            return codeString;
                        });
            var newString2 = Regex.Replace(newString, @"\|(.*?)\|",
                        m =>
                        {
                            var codeString = m.Groups[1].Value;
                            codeString = "";
                            return codeString;
                        });
            return newString2;
        }
        public string replaceNotesText(string originalText)
        {
            PC pc = c_game.playerList.PCList[c_game.selectedPartyLeader];            
            var newString = Regex.Replace(originalText, @"\|(.*?)\|",
                        m =>
                        {
                            var codeString = m.Groups[1].Value;
                            codeString = "";
                            return codeString;
                        });
            return newString;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.D1) || (keyData == Keys.NumPad1))
            {
                if (playerNodeLinkList.Count > 0)
                    selectedLine(null, 0);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D2) || (keyData == Keys.NumPad2))
            {
                if (playerNodeLinkList.Count > 1)
                    selectedLine(null, 1);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D3) || (keyData == Keys.NumPad3))
            {
                if (playerNodeLinkList.Count > 2)
                    selectedLine(null, 2);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D4) || (keyData == Keys.NumPad4))
            {
                if (playerNodeLinkList.Count > 3)
                    selectedLine(null, 3);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D5) || (keyData == Keys.NumPad5))
            {
                if (playerNodeLinkList.Count > 4)
                    selectedLine(null, 4);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D6) || (keyData == Keys.NumPad6))
            {
                if (playerNodeLinkList.Count > 5)
                    selectedLine(null, 5);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D7) || (keyData == Keys.NumPad7))
            {
                if (playerNodeLinkList.Count > 6)
                    selectedLine(null, 6);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D8) || (keyData == Keys.NumPad8))
            {
                if (playerNodeLinkList.Count > 7)
                    selectedLine(null, 7);
                return true; //for the active control to see the keypress, return false 
            }
            else if ((keyData == Keys.D9) || (keyData == Keys.NumPad9))
            {
                if (playerNodeLinkList.Count > 8)
                    selectedLine(null, 8);
                return true; //for the active control to see the keypress, return false 
            }
            else if (keyData == Keys.Escape)
            {
                DialogResult result = IBMessageBox.Show(c_game, "Exiting a conversation via the Esc Key may break possible quests. Are you sure you wish to exit this conversation? ", enumMessageButton.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    userClosingConvo = false;
                    c_game.selectedPartyLeader = originalSelectedPartyLeader;
                    this.Close();
                }
                return true; //for the active control to see the keypress, return false 
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void loadConvoPlusImage()
        {
            // load image for convo
            try
            {
                convoPlusBitmap = new Bitmap(c_game.mainDirectory + "\\data\\graphics\\convoPlus.png");
            }
            catch (Exception ex)
            {
                //IBMessageBox.Show(game, "No image was associated with this convo (or load error), using a default");
                c_game.errorLog(ex.ToString());
                convoPlusBitmap = new Bitmap(20, 20);
            }
            pictureBox1.Image = (Image)convoBitmap;
        }
        private void loadNodePortrait()
        {
            // load image for convo
            try
            {
                if ((t_convo.GetContentNodeById(parentIdNum).NodePortraitBitmap == "") || (t_convo.GetContentNodeById(parentIdNum).NodePortraitBitmap == null))
                {
                    convoBitmap = new Bitmap(c_game.mainDirectory + "\\modules\\" + c_game.module.ModuleFolderName + "\\graphics\\dialog\\" + t_convo.NpcPortraitBitmap);
                }
                else
                {
                    convoBitmap = new Bitmap(c_game.mainDirectory + "\\modules\\" + c_game.module.ModuleFolderName + "\\graphics\\dialog\\" + t_convo.GetContentNodeById(parentIdNum).NodePortraitBitmap);
                }
            }
            catch (Exception ex)
            {
                //IBMessageBox.Show(game, "No image was associated with this convo (or load error), using a default");
                c_game.errorLog(ex.ToString());
                convoBitmap = new Bitmap(c_game.mainDirectory + "\\data\\graphics\\NOPORT_L.png");
            }
            pictureBox1.Image = (Image)convoBitmap;
        }
        private void playNodeSound()
        {
            try
            {
                c_frm.convoSounds.controls.stop();
                string snd = t_convo.GetContentNodeById(parentIdNum).NodeSound;
                if ((snd == "none") || (snd == ""))
                {
                    //do not play anything
                }
                else
                {
                    c_frm.convoSounds.URL = c_game.mainDirectory + "\\modules\\" + c_game.module.ModuleFolderName + "\\sounds\\convoSounds\\" + snd;
                    c_frm.convoSounds.controls.stop();
                    c_frm.convoSounds.controls.play();
                }
            }
            catch (Exception ex)
            {
                c_game.errorLog("Failed in playNodeSound(): " + ex.ToString());
            }
        }
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedLine(sender, 0);
        }
        /*
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedLine1();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedLine2();
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedLine3();
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedLine4();
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedLine5();
        }
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectedLine6();
        }
        */
        private void selectedLine(object sender, int idx)
        {
            int index = 1;
            if (sender != null)
            {
                LinkLabel linkLabel = (LinkLabel)sender;
                index = Convert.ToInt32(linkLabel.Name);                
            }
            else
            {
                index = Convert.ToInt32(playerNodeLinkList[idx].linkLabel.Name);
            }
            
            #region send choosen text to the main screen log
            string NPCname = "";
            ContentNode selectedNod = t_convo.GetContentNodeById(parentIdNum).subNodes[index];
            if ((selectedNod.NodeNpcName == "") || (selectedNod.NodeNpcName == null) || (selectedNod.NodeNpcName.Length <= 0))
            {
                //c_frm.logText(t_convo.DefaultNpcName + ": ", Color.Yellow);
                NPCname = t_convo.DefaultNpcName;
            }
            else
            {
                //c_frm.logText(selectedNod.NodeNpcName + ": ", Color.Yellow);
                NPCname = selectedNod.NodeNpcName;
            }
            string npcNode = replaceText(rtxtNPC.Text);
            string pcNode = replaceText(selectedNod.conversationText);
            //c_frm.doScriptBasedOnFilename("dsAdventureMapConvoLog.cs", rtxtNPC.Text, NPCname, selectedNod.conversationText, c_game.playerList.PCList[c_game.selectedPartyLeader].Name);
            c_frm.doScriptBasedOnFilename("dsAdventureMapConvoLog.cs", npcNode, NPCname, pcNode, c_game.playerList.PCList[c_game.selectedPartyLeader].Name);
            #endregion

            int childIdNum = t_convo.GetContentNodeById(parentIdNum).subNodes[index].idNum;
            // if PC node choosen was a linked node, then return the idNum of the linked node
            if (t_convo.GetContentNodeById(parentIdNum).subNodes[index].isLink)
            {
                childIdNum = t_convo.GetContentNodeById(t_convo.GetContentNodeById(parentIdNum).subNodes[index].linkTo).idNum;
            }
            //doAction() for current selected PC Node (all actions for node)
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(childIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
            }
            if (t_convo.GetContentNodeById(childIdNum).subNodes.Count < 1)
            {
                /*try
                {
                    t_convo.SaveContentConversation(c_game.mainDirectory + "\\modules\\" + c_game.module.ModuleFolderName + "\\dialog\\" + t_convo.ConvoFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save Convo file to disk. Original error: " + ex.Message);
                }*/
                userClosingConvo = false;
                c_game.selectedPartyLeader = originalSelectedPartyLeader;
                this.Close();
            }
            else
            {
                parentIdNum = getParentIdNum(childIdNum);
                doActions = true;
                doConvo(parentIdNum);
            }
        }
        /*
        private void selectedLine1()
        {
            //IBMessageBox.Show(game, "you selected label 1");

            // returns the id number of the PC node choosen
            int childIdNum = t_convo.GetContentNodeById(parentIdNum).subNodes[0].idNum;
            // if PC node choosen was a linked node, then return the idNum of the linked node
            if (t_convo.GetContentNodeById(parentIdNum).subNodes[0].isLink)
                childIdNum = t_convo.GetContentNodeById(t_convo.GetContentNodeById(parentIdNum).subNodes[0].linkTo).idNum;
            //doAction() for current PC Node choosen (all actions for node)
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(childIdNum).actions)
            {
                //MessageBox.Show("script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                //action.doAction(ref c_game);
            }
            // if this is an END DIALOG node then exit dialog
            if (t_convo.GetContentNodeById(childIdNum).subNodes.Count < 1)
            {
                userClosingConvo = false;
                this.Close();
            }
            else // find the next NPC node (first to return true conditional) from the choosen PC node's children
            {
                parentIdNum = getParentIdNum(childIdNum);
                doConvo(parentIdNum);
            }
        }
        private void selectedLine2()
        {
            //IBMessageBox.Show(game, "you selected label 2");
            int childIdNum = t_convo.GetContentNodeById(parentIdNum).subNodes[1].idNum;
            // if PC node choosen was a linked node, then return the idNum of the linked node
            if (t_convo.GetContentNodeById(parentIdNum).subNodes[1].isLink)
                childIdNum = t_convo.GetContentNodeById(t_convo.GetContentNodeById(parentIdNum).subNodes[1].linkTo).idNum;
            //doAction() for current npc Node (all actions for node)
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(childIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                //action.doAction(ref c_game);
            }
            if (t_convo.GetContentNodeById(childIdNum).subNodes.Count < 1)
            {
                userClosingConvo = false;
                this.Close();
            }
            else
            {
                parentIdNum = getParentIdNum(childIdNum);
                doConvo(parentIdNum);
            }
        }
        private void selectedLine3()
        {
            //IBMessageBox.Show(game, "you selected label 3");
            int childIdNum = t_convo.GetContentNodeById(parentIdNum).subNodes[2].idNum;
            // if PC node choosen was a linked node, then return the idNum of the linked node
            if (t_convo.GetContentNodeById(parentIdNum).subNodes[2].isLink)
                childIdNum = t_convo.GetContentNodeById(t_convo.GetContentNodeById(parentIdNum).subNodes[2].linkTo).idNum;
            //doAction() for current npc Node (all actions for node)
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(childIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                //action.doAction(ref c_game);
            }
            if (t_convo.GetContentNodeById(childIdNum).subNodes.Count < 1)
            {
                userClosingConvo = false;
                this.Close();
            }
            else
            {
                parentIdNum = getParentIdNum(childIdNum);
                doConvo(parentIdNum);
            }
        }
        private void selectedLine4()
        {
            //IBMessageBox.Show(game, "you selected label 4");
            int childIdNum = t_convo.GetContentNodeById(parentIdNum).subNodes[3].idNum;
            // if PC node choosen was a linked node, then return the idNum of the linked node
            if (t_convo.GetContentNodeById(parentIdNum).subNodes[3].isLink)
                childIdNum = t_convo.GetContentNodeById(t_convo.GetContentNodeById(parentIdNum).subNodes[3].linkTo).idNum;
            //doAction() for current npc Node (all actions for node)
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(childIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                //action.doAction(ref c_game);
            }
            if (t_convo.GetContentNodeById(childIdNum).subNodes.Count < 1)
            {
                userClosingConvo = false;
                this.Close();
            }
            else
            {
                parentIdNum = getParentIdNum(childIdNum);
                doConvo(parentIdNum);
            }
        }
        private void selectedLine5()
        {
            //IBMessageBox.Show(game, "you selected label 5");
            int childIdNum = t_convo.GetContentNodeById(parentIdNum).subNodes[4].idNum;
            // if PC node choosen was a linked node, then return the idNum of the linked node
            if (t_convo.GetContentNodeById(parentIdNum).subNodes[4].isLink)
                childIdNum = t_convo.GetContentNodeById(t_convo.GetContentNodeById(parentIdNum).subNodes[4].linkTo).idNum;
            //doAction() for current npc Node (all actions for node)
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(childIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                //action.doAction(ref c_game);
            }
            if (t_convo.GetContentNodeById(childIdNum).subNodes.Count < 1)
            {
                userClosingConvo = false;
                this.Close();
            }
            else
            {
                parentIdNum = getParentIdNum(childIdNum);
                doConvo(parentIdNum);
            }
        }
        private void selectedLine6()
        {
            //IBMessageBox.Show(game, "you selected label 6");
            int childIdNum = t_convo.GetContentNodeById(parentIdNum).subNodes[5].idNum;
            // if PC node choosen was a linked node, then return the idNum of the linked node
            if (t_convo.GetContentNodeById(parentIdNum).subNodes[5].isLink)
                childIdNum = t_convo.GetContentNodeById(t_convo.GetContentNodeById(parentIdNum).subNodes[5].linkTo).idNum;
            //doAction() for current npc Node (all actions for node)
            foreach (IceBlinkCore.Action action in t_convo.GetContentNodeById(childIdNum).actions)
            {
                //IBMessageBox.Show(game, "script: " + action.a_script + "  variable: " + action.a_parameter_1 + "  value: " + action.a_parameter_2);
                c_frm.doScriptBasedOnFilename(action.a_script, action.a_parameter_1, action.a_parameter_2, action.a_parameter_3, action.a_parameter_4);
                //action.doAction(ref c_game);
            }
            if (t_convo.GetContentNodeById(childIdNum).subNodes.Count < 1)
            {
                userClosingConvo = false;
                this.Close();
            }
            else
            {
                parentIdNum = getParentIdNum(childIdNum);
                //parentIdNum = t_convo.GetContentNodeById(childIdNum).subNodes[0].idNum;
                doConvo(parentIdNum);
            }
        }
        */
        private void ConversationDialogBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userClosingConvo)
            {
                e.Cancel = true; // this cancels the close event.
            }
        }

        private void rbtnPc0_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc0.Checked)
            {
                c_game.ChangePartySprite();
                c_game.selectedPartyLeader = 0;
            }
            refreshPcPortraits();
            doActions = false;
            doConvo(parentIdNum);
        }
        private void rbtnPc1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc1.Checked)
            {
                c_game.ChangePartySprite();
                c_game.selectedPartyLeader = 1;
            }
            refreshPcPortraits();
            doActions = false;
            doConvo(parentIdNum);
        }
        private void rbtnPc2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc2.Checked)
            {
                c_game.ChangePartySprite();
                c_game.selectedPartyLeader = 2;
            }
            refreshPcPortraits();
            doActions = false;
            doConvo(parentIdNum);
        }
        private void rbtnPc3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc3.Checked)
            {
                c_game.ChangePartySprite();
                c_game.selectedPartyLeader = 3;
            }
            refreshPcPortraits();
            doActions = false;
            doConvo(parentIdNum);
        }
        private void rbtnPc4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc4.Checked)
            {
                c_game.ChangePartySprite();
                c_game.selectedPartyLeader = 4;
            }
            refreshPcPortraits();
            doActions = false;
            doConvo(parentIdNum);
        }
        private void rbtnPc5_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPc5.Checked)
            {
                c_game.ChangePartySprite();
                c_game.selectedPartyLeader = 5;
            }
            refreshPcPortraits();
            doActions = false;
            doConvo(parentIdNum);
        }
    }
    public class PlayerNodeLink
    {
        public LinkLabel linkLabel = new LinkLabel();
        public int nodeIndex;

        public PlayerNodeLink()
        {
        }
        public void SetUpNode(Game game, Form1 frm)
        {
            linkLabel.AutoSize = true;
            linkLabel.ForeColor = System.Drawing.Color.Silver;
            linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            linkLabel.Location = new System.Drawing.Point(5, 10);
            linkLabel.MaximumSize = new System.Drawing.Size(450, 0);
            linkLabel.Name = nodeIndex.ToString();
            linkLabel.Size = new System.Drawing.Size(72, 17);
            linkLabel.TabStop = true;
            linkLabel.Text = "linkLabel";
            linkLabel.Font = frm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            linkLabel.LinkColor = game.module.ModuleTheme.ConvoTextColor;
        }
    }
}
