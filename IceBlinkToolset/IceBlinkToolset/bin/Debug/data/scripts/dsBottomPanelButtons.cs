//dsBottomPanelButtons.cs
//p1 = Tag of clicked button
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;
using IceBlinkToolset;
using System.Drawing;
using System.IO;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            try
            {
                sf.MainMapScriptCall = true; //can be used as a flag in your scripts that the call is coming from the main map
                if (p1 == "castSpell")
                {
                    selectedUseSpell(sf);
                }
                if (p1 == "useTrait")
                {
                    selectedUseTrait(sf);
                }
                // Party Conversation system requires that each possible companion has a conversation file
                // that is named exactly the same as their name. The conversation does NOT need to be attached
                // to the companion in the ConversationTag property.
                if (p1 == "partyConvo")
                {
                    partyConvo(sf);
                }
                if (p1 == "combatOrder")
                {
                    CombatOrder(sf);
                }
            }
            finally
            {
                sf.MainMapScriptCall = false; //set back to false after use
            }
        }        
        private void selectedUseTrait(ScriptFunctions sf)
        {
            PC pc = new PC();
            pc.passRefs(sf.gm, null);
            pc = sf.gm.playerList.PCList[sf.gm.selectedPartyLeader];
            //gbPlayerTurn.Enabled = false;
            //currentSpell = MageSpells.mageSpellList.None;
            //MageSpellsCombat msc = new MageSpellsCombat(this, com_game, char_pt);
            //msc.ShowDialog();
            TraitSelectMainMap tss = new TraitSelectMainMap(sf.frm, sf.gm, pc);
            DialogResult result = tss.ShowDialog();
            if (result == DialogResult.OK)
            {
                //SpellTargeting();
                //IBMessageBox.Show(sf.gm, "attempt to cast name");
                PC tempPC = (PC)sf.MainMapTarget;
                //IBMessageBox.Show(sf.gm, "selected cast spell: " + sf.frm.currentSpell.SpellName + "on PC target: " + tempPC.Name);
                ScriptSelectEditorReturnObject script = sf.frm.currentTrait.TraitScript;
                //IBMessageBox.Show(sf.gm, "going to spell script");
                sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                pc.SP -= sf.frm.currentTrait.CostSP;
                if (pc.SP < 0) { pc.SP = 0; }
            }
            else if (result == DialogResult.Cancel)
            {
                //IBMessageBox.Show(sf.gm, "cancelled trait selection");
                //gbPlayerTurn.Enabled = true;
                //logText("cancelled spell use", Color.DarkRed);
                //logText(Environment.NewLine, Color.Black);
                return;
            }
            else
            {
                IBMessageBox.Show(sf.gm, "didn't register your choice...cancelled");
            }
        }
        private void selectedUseSpell(ScriptFunctions sf)
        {
            PC pc = new PC();
            pc.passRefs(sf.gm, null);
            pc = sf.gm.playerList.PCList[sf.gm.selectedPartyLeader];
            //gbPlayerTurn.Enabled = false;
            //currentSpell = MageSpells.mageSpellList.None;
            //MageSpellsCombat msc = new MageSpellsCombat(this, com_game, char_pt);
            //msc.ShowDialog();
            SpellSelectMainMap tss = new SpellSelectMainMap(sf.frm, sf.gm, pc);
            DialogResult result = tss.ShowDialog();
            if (result == DialogResult.OK)
            {
                //SpellTargeting();
                //IBMessageBox.Show(sf.gm, "attempt to cast name");
                PC tempPC = (PC)sf.MainMapTarget;
                //IBMessageBox.Show(sf.gm, "selected cast spell: " + sf.frm.currentSpell.SpellName + "on PC target: " + tempPC.Name);
                ScriptSelectEditorReturnObject script = sf.frm.currentSpell.SpellScript;
                //IBMessageBox.Show(sf.gm, "going to spell script");
                sf.frm.doScriptBasedOnFilename(script.FilenameOrTag, script.Parm1, script.Parm2, script.Parm3, script.Parm4);
                pc.SP -= sf.frm.currentSpell.CostSP;
                if (pc.SP < 0) { pc.SP = 0; }
            }
            else if (result == DialogResult.Cancel)
            {
                //IBMessageBox.Show(sf.gm, "cancelled spell selection");
                //gbPlayerTurn.Enabled = true;
                //logText("cancelled spell use", Color.DarkRed);
                //logText(Environment.NewLine, Color.Black);
                return;
            }
            else
            {
                IBMessageBox.Show(sf.gm, "didn't register your choice...cancelled");
            }
        }
        private void partyConvo(ScriptFunctions sf)
        {           
            PC pc = sf.gm.playerList.PCList[sf.gm.selectedPartyLeader];
            PartyConvo convo = new PartyConvo(sf, pc);
            DialogResult result = convo.ShowDialog();
            if (result == DialogResult.OK)
            {
                PC sourcePC = (PC)sf.MainMapSource;
                PC targetPC = (PC)sf.MainMapTarget;
                sf.frm.doNarrationBasedOnTag(targetPC.Name);
            }
            else if (result == DialogResult.Cancel)
            {
                //IBMessageBox.Show(sf.gm, "cancelled party convo selection");
                return;
            }
            else
            {
                IBMessageBox.Show(sf.gm, "didn't register your choice...cancelled");
            }
        }
        private void CombatOrder(ScriptFunctions sf)
        {
            CombatOrder convo = new CombatOrder(sf);
            convo.ShowDialog();            
        }
    }

    public partial class PartyConvo : IBForm
    {
        public ScriptFunctions sf;
        public PC pc;

        public PartyConvo(ScriptFunctions s, PC p)
        {
            InitializeComponent();
            sf = s;
            pc = p;
            this.setupAll(sf.gm);
            IceBlinkButtonResize.setupAll(sf.gm);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(sf.gm);
            gbPcSelect.setupAll(sf.gm);
            gbPcSelect.Visible = true;
            refreshPcPortraits();
        }

        public void refreshPcPortraits()
        {
            try
            {
                if (sf.gm.playerList.PCList.Count >= 1)
                {
                    this.rbtnPc0.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 2)
                {
                    this.rbtnPc1.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 3)
                {
                    this.rbtnPc2.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 4)
                {
                    this.rbtnPc3.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 5)
                {
                    this.rbtnPc4.Visible = true;
                }
                if (sf.gm.playerList.PCList.Count >= 6)
                {
                    this.rbtnPc5.Visible = true;
                }

                if (sf.gm.playerList.PCList.Count > 0)
                {
                    rbtnPc0.Image = (Image)sf.gm.playerList.PCList[0].portraitBitmapS;
                    if ((pc != sf.gm.playerList.PCList[0]) && (File.Exists(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\dialog\\" + sf.gm.playerList.PCList[0].Name + ".xml")))
                    { 
                        this.rbtnPc0.Enabled = true;
                    }
                    else 
                    { 
                        this.rbtnPc0.Enabled = false; 
                    }
                }
                if (sf.gm.playerList.PCList.Count > 1)
                {
                    rbtnPc1.Image = (Image)sf.gm.playerList.PCList[1].portraitBitmapS;
                    if ((pc != sf.gm.playerList.PCList[1]) && (File.Exists(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\dialog\\" + sf.gm.playerList.PCList[1].Name + ".xml")))
                    {
                        this.rbtnPc1.Enabled = true;
                    }
                    else
                    {
                        this.rbtnPc1.Enabled = false;
                    }
                }
                if (sf.gm.playerList.PCList.Count > 2)
                {
                    rbtnPc2.Image = (Image)sf.gm.playerList.PCList[2].portraitBitmapS;
                    if ((pc != sf.gm.playerList.PCList[2]) && (File.Exists(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\dialog\\" + sf.gm.playerList.PCList[2].Name + ".xml")))
                    {
                        this.rbtnPc2.Enabled = true;
                    }
                    else
                    {
                        this.rbtnPc2.Enabled = false;
                    }
                }
                if (sf.gm.playerList.PCList.Count > 3)
                {
                    rbtnPc3.Image = (Image)sf.gm.playerList.PCList[3].portraitBitmapS;
                    if ((pc != sf.gm.playerList.PCList[3]) && (File.Exists(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\dialog\\" + sf.gm.playerList.PCList[3].Name + ".xml")))
                    {
                        this.rbtnPc3.Enabled = true;
                    }
                    else
                    {
                        this.rbtnPc3.Enabled = false;
                    }
                }
                if (sf.gm.playerList.PCList.Count > 4)
                {
                    rbtnPc4.Image = (Image)sf.gm.playerList.PCList[4].portraitBitmapS;
                    if ((pc != sf.gm.playerList.PCList[4]) && (File.Exists(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\dialog\\" + sf.gm.playerList.PCList[4].Name + ".xml")))
                    {
                        this.rbtnPc4.Enabled = true;
                    }
                    else
                    {
                        this.rbtnPc4.Enabled = false;
                    }
                }
                if (sf.gm.playerList.PCList.Count > 5)
                {
                    rbtnPc5.Image = (Image)sf.gm.playerList.PCList[5].portraitBitmapS;
                    if ((pc != sf.gm.playerList.PCList[5]) && (File.Exists(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\dialog\\" + sf.gm.playerList.PCList[5].Name + ".xml")))
                    {
                        this.rbtnPc5.Enabled = true;
                    }
                    else
                    {
                        this.rbtnPc5.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                sf.gm.errorLog(ex.ToString());
            }
        }
        private void rbtnPc0_CheckedChanged(object sender, EventArgs e)
        {
            sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[0];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc1_CheckedChanged(object sender, EventArgs e)
        {
            sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[1];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc2_CheckedChanged(object sender, EventArgs e)
        {
            sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[2];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc3_CheckedChanged(object sender, EventArgs e)
        {
            sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[3];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc4_CheckedChanged(object sender, EventArgs e)
        {
            sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[4];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void rbtnPc5_CheckedChanged(object sender, EventArgs e)
        {
            sf.MainMapSource = pc;
            sf.MainMapTarget = sf.gm.playerList.PCList[5];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
    partial class PartyConvo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartyConvo));
            this.gbPcSelect = new IceBlink.IceBlinkGroupBoxMedium();
            this.rbtnPc5 = new System.Windows.Forms.RadioButton();
            this.rbtnPc4 = new System.Windows.Forms.RadioButton();
            this.rbtnPc3 = new System.Windows.Forms.RadioButton();
            this.rbtnPc2 = new System.Windows.Forms.RadioButton();
            this.rbtnPc1 = new System.Windows.Forms.RadioButton();
            this.rbtnPc0 = new System.Windows.Forms.RadioButton();
            this.gbPcSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPcSelect
            // 
            this.gbPcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPcSelect.BackColor = System.Drawing.Color.Transparent;
            this.gbPcSelect.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbPcSelect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbPcSelect.BorderThickness = 2F;
            this.gbPcSelect.Controls.Add(this.rbtnPc5);
            this.gbPcSelect.Controls.Add(this.rbtnPc4);
            this.gbPcSelect.Controls.Add(this.rbtnPc3);
            this.gbPcSelect.Controls.Add(this.rbtnPc2);
            this.gbPcSelect.Controls.Add(this.rbtnPc1);
            this.gbPcSelect.Controls.Add(this.rbtnPc0);
            this.gbPcSelect.HeaderForeColor = System.Drawing.Color.White;
            //this.gbPcSelect.HeaderImage = ((System.Drawing.Image)(resources.GetObject("gbPcSelect.HeaderImage")));
            this.gbPcSelect.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbPcSelect.Location = new System.Drawing.Point(12, 40);
            this.gbPcSelect.Name = "gbPcSelect";
            this.gbPcSelect.Size = new System.Drawing.Size(319, 214);
            this.gbPcSelect.TabIndex = 9;
            this.gbPcSelect.TabStop = false;
            this.gbPcSelect.Text = "START A CONVERSATION  -  SELECT A COMPANION";
            this.gbPcSelect.TextIB = "iceBlinkGBMedium1";
            // 
            // rbtnPc5
            // 
            this.rbtnPc5.Appearance = System.Windows.Forms.Appearance.Button;
            //this.rbtnPc5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc5.BackgroundImage")));
            this.rbtnPc5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc5.Enabled = false;
            this.rbtnPc5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc5.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc5.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc5.Location = new System.Drawing.Point(199, 128);
            this.rbtnPc5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc5.Name = "rbtnPc5";
            this.rbtnPc5.Size = new System.Drawing.Size(46, 68);
            this.rbtnPc5.TabIndex = 48;
            this.rbtnPc5.TabStop = true;
            this.rbtnPc5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc5.UseVisualStyleBackColor = true;
            this.rbtnPc5.Visible = false;
            this.rbtnPc5.CheckedChanged += new System.EventHandler(this.rbtnPc5_CheckedChanged);
            // 
            // rbtnPc4
            // 
            this.rbtnPc4.Appearance = System.Windows.Forms.Appearance.Button;
            //this.rbtnPc4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc4.BackgroundImage")));
            this.rbtnPc4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc4.Enabled = false;
            this.rbtnPc4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc4.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc4.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc4.Location = new System.Drawing.Point(139, 128);
            this.rbtnPc4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc4.Name = "rbtnPc4";
            this.rbtnPc4.Size = new System.Drawing.Size(46, 68);
            this.rbtnPc4.TabIndex = 47;
            this.rbtnPc4.TabStop = true;
            this.rbtnPc4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc4.UseVisualStyleBackColor = true;
            this.rbtnPc4.Visible = false;
            this.rbtnPc4.CheckedChanged += new System.EventHandler(this.rbtnPc4_CheckedChanged);
            // 
            // rbtnPc3
            // 
            this.rbtnPc3.Appearance = System.Windows.Forms.Appearance.Button;
            //this.rbtnPc3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc3.BackgroundImage")));
            this.rbtnPc3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc3.Enabled = false;
            this.rbtnPc3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc3.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc3.Location = new System.Drawing.Point(79, 128);
            this.rbtnPc3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc3.Name = "rbtnPc3";
            this.rbtnPc3.Size = new System.Drawing.Size(46, 68);
            this.rbtnPc3.TabIndex = 46;
            this.rbtnPc3.TabStop = true;
            this.rbtnPc3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc3.UseVisualStyleBackColor = true;
            this.rbtnPc3.Visible = false;
            this.rbtnPc3.CheckedChanged += new System.EventHandler(this.rbtnPc3_CheckedChanged);
            // 
            // rbtnPc2
            // 
            this.rbtnPc2.Appearance = System.Windows.Forms.Appearance.Button;
            //this.rbtnPc2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc2.BackgroundImage")));
            this.rbtnPc2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc2.Enabled = false;
            this.rbtnPc2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc2.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc2.Location = new System.Drawing.Point(199, 47);
            this.rbtnPc2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc2.Name = "rbtnPc2";
            this.rbtnPc2.Size = new System.Drawing.Size(46, 68);
            this.rbtnPc2.TabIndex = 45;
            this.rbtnPc2.TabStop = true;
            this.rbtnPc2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc2.UseVisualStyleBackColor = true;
            this.rbtnPc2.Visible = false;
            this.rbtnPc2.CheckedChanged += new System.EventHandler(this.rbtnPc2_CheckedChanged);
            // 
            // rbtnPc1
            // 
            this.rbtnPc1.Appearance = System.Windows.Forms.Appearance.Button;
            //this.rbtnPc1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc1.BackgroundImage")));
            this.rbtnPc1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc1.Enabled = false;
            this.rbtnPc1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc1.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc1.Location = new System.Drawing.Point(139, 47);
            this.rbtnPc1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc1.Name = "rbtnPc1";
            this.rbtnPc1.Size = new System.Drawing.Size(46, 68);
            this.rbtnPc1.TabIndex = 44;
            this.rbtnPc1.TabStop = true;
            this.rbtnPc1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc1.UseVisualStyleBackColor = true;
            this.rbtnPc1.Visible = false;
            this.rbtnPc1.CheckedChanged += new System.EventHandler(this.rbtnPc1_CheckedChanged);
            // 
            // rbtnPc0
            // 
            this.rbtnPc0.Appearance = System.Windows.Forms.Appearance.Button;
            //this.rbtnPc0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbtnPc0.BackgroundImage")));
            this.rbtnPc0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnPc0.Enabled = false;
            this.rbtnPc0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnPc0.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnPc0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rbtnPc0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnPc0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPc0.ForeColor = System.Drawing.Color.Magenta;
            this.rbtnPc0.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc0.Location = new System.Drawing.Point(79, 47);
            this.rbtnPc0.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rbtnPc0.Name = "rbtnPc0";
            this.rbtnPc0.Size = new System.Drawing.Size(46, 68);
            this.rbtnPc0.TabIndex = 43;
            this.rbtnPc0.TabStop = true;
            this.rbtnPc0.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.rbtnPc0.UseVisualStyleBackColor = true;
            this.rbtnPc0.Visible = false;
            this.rbtnPc0.CheckedChanged += new System.EventHandler(this.rbtnPc0_CheckedChanged);
            // 
            // PartyConvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(340, 266);
            this.Controls.Add(this.gbPcSelect);
            this.Name = "PartyConvo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WorldMap";
            this.Controls.SetChildIndex(this.gbPcSelect, 0);
            this.gbPcSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlink.IceBlinkGroupBoxMedium gbPcSelect;
        public System.Windows.Forms.RadioButton rbtnPc5;
        public System.Windows.Forms.RadioButton rbtnPc4;
        public System.Windows.Forms.RadioButton rbtnPc3;
        public System.Windows.Forms.RadioButton rbtnPc2;
        public System.Windows.Forms.RadioButton rbtnPc1;
        public System.Windows.Forms.RadioButton rbtnPc0;

    }

    public partial class CombatOrder : IBForm
    {
        public ScriptFunctions sf;

        public CombatOrder(ScriptFunctions s)
        {
            InitializeComponent();
            sf = s;
            this.setupAll(sf.gm);
            IceBlinkButtonResize.setupAll(sf.gm);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(sf.gm);
            gbPcSelect.setupAll(sf.gm);
            gbPcSelect.Visible = true;
            createButtons();
        }
        private void createButtons()
        {
            IceBlinkButtonMedium btnNew = new IceBlink.IceBlinkButtonMedium();
            btnNew.Location = new System.Drawing.Point(30, 50);
            btnNew.Size = new System.Drawing.Size(100, 30);
            btnNew.TextIB = "1  2  3  4  5  6";
            btnNew.Name = "123456";
            btnNew.Click += new System.EventHandler(this.btnSelectedOrder_Click);
            btnNew.setupAll(sf.gm);
            this.gbPcSelect.Controls.Add(btnNew);

            btnNew = new IceBlink.IceBlinkButtonMedium();
            btnNew.Location = new System.Drawing.Point(170, 50);
            btnNew.Size = new System.Drawing.Size(100, 30);
            btnNew.TextIB = "2  3  4  5  6  1";
            btnNew.Name = "234561";
            btnNew.Click += new System.EventHandler(this.btnSelectedOrder_Click);
            btnNew.setupAll(sf.gm);
            this.gbPcSelect.Controls.Add(btnNew);

            btnNew = new IceBlink.IceBlinkButtonMedium();
            btnNew.Location = new System.Drawing.Point(30, 100);
            btnNew.Size = new System.Drawing.Size(100, 30);
            btnNew.TextIB = "3  4  5  6  1  2";
            btnNew.Name = "345612";
            btnNew.Click += new System.EventHandler(this.btnSelectedOrder_Click);
            btnNew.setupAll(sf.gm);
            this.gbPcSelect.Controls.Add(btnNew);

            btnNew = new IceBlink.IceBlinkButtonMedium();
            btnNew.Location = new System.Drawing.Point(170, 100);
            btnNew.Size = new System.Drawing.Size(100, 30);
            btnNew.TextIB = "4  5  6  1  2  3";
            btnNew.Name = "456123";
            btnNew.Click += new System.EventHandler(this.btnSelectedOrder_Click);
            btnNew.setupAll(sf.gm);
            this.gbPcSelect.Controls.Add(btnNew);

            btnNew = new IceBlink.IceBlinkButtonMedium();
            btnNew.Location = new System.Drawing.Point(30, 150);
            btnNew.Size = new System.Drawing.Size(100, 30);
            btnNew.TextIB = "5  6  1  2  3  4";
            btnNew.Name = "561234";
            btnNew.Click += new System.EventHandler(this.btnSelectedOrder_Click);
            btnNew.setupAll(sf.gm);
            this.gbPcSelect.Controls.Add(btnNew);

            btnNew = new IceBlink.IceBlinkButtonMedium();
            btnNew.Location = new System.Drawing.Point(170, 150);
            btnNew.Size = new System.Drawing.Size(100, 30);
            btnNew.TextIB = "6  1  2  3  4  5";
            btnNew.Name = "612345";
            btnNew.Click += new System.EventHandler(this.btnSelectedOrder_Click);
            btnNew.setupAll(sf.gm);
            this.gbPcSelect.Controls.Add(btnNew);
        }
        private void btnSelectedOrder_Click(object sender, EventArgs e)
        {
            IceBlinkButtonMedium selectBtn = (IceBlinkButtonMedium)sender;
            if (selectBtn.Name == "123456")
            {
                sf.gm.PartyCombatOrder = new int[] { 0, 1, 2, 3, 4, 5 };
                sf.frm.logText("new party combat order is: 1 2 3 4 5 6", Color.Aqua);
                sf.frm.logText(Environment.NewLine, Color.Aqua);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (selectBtn.Name == "234561")
            {
                sf.gm.PartyCombatOrder = new int[] { 1, 2, 3, 4, 5, 0 };
                sf.frm.logText("new party combat order is: 2 3 4 5 6 1", Color.Aqua);
                sf.frm.logText(Environment.NewLine, Color.Aqua);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (selectBtn.Name == "345612")
            {
                sf.gm.PartyCombatOrder = new int[] { 2, 3, 4, 5, 0, 1 };
                sf.frm.logText("new party combat order is: 3 4 5 6 1 2", Color.Aqua);
                sf.frm.logText(Environment.NewLine, Color.Aqua);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (selectBtn.Name == "456123")
            {
                sf.gm.PartyCombatOrder = new int[] { 3, 4, 5, 0, 1, 2 };
                sf.frm.logText("new party combat order is: 4 5 6 1 2 3", Color.Aqua);
                sf.frm.logText(Environment.NewLine, Color.Aqua);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (selectBtn.Name == "561234")
            {
                sf.gm.PartyCombatOrder = new int[] { 4, 5, 0, 1, 2, 3 };
                sf.frm.logText("new party combat order is: 5 6 1 2 3 4", Color.Aqua);
                sf.frm.logText(Environment.NewLine, Color.Aqua);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (selectBtn.Name == "612345")
            {
                sf.gm.PartyCombatOrder = new int[] { 5, 0, 1, 2, 3, 4 };
                sf.frm.logText("new party combat order is: 6 1 2 3 4 5", Color.Aqua);
                sf.frm.logText(Environment.NewLine, Color.Aqua);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                sf.gm.PartyCombatOrder = new int[] { 0, 1, 2, 3, 4, 5 };
                sf.frm.logText("new party combat order is: 1 2 3 4 5 6", Color.Aqua);
                sf.frm.logText(Environment.NewLine, Color.Aqua);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
    partial class CombatOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartyConvo));
            this.gbPcSelect = new IceBlink.IceBlinkGroupBoxMedium();
            this.gbPcSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPcSelect
            // 
            this.gbPcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPcSelect.BackColor = System.Drawing.Color.Transparent;
            this.gbPcSelect.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gbPcSelect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbPcSelect.BorderThickness = 2F;
            this.gbPcSelect.HeaderForeColor = System.Drawing.Color.White;
            this.gbPcSelect.HeaderShadowColor = System.Drawing.Color.Black;
            this.gbPcSelect.Location = new System.Drawing.Point(12, 40);
            this.gbPcSelect.Name = "gbPcSelect";
            this.gbPcSelect.Size = new System.Drawing.Size(300, 214);
            this.gbPcSelect.TabIndex = 9;
            this.gbPcSelect.TabStop = false;
            this.gbPcSelect.Text = "SELECT THE PARTY COMBAT ORDER";
            this.gbPcSelect.TextIB = "iceBlinkGBMedium1";            
            // 
            // PartyConvo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(320, 266);
            this.Controls.Add(this.gbPcSelect);
            this.Name = "CombatOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Combat Order";
            this.Controls.SetChildIndex(this.gbPcSelect, 0);
            this.gbPcSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IceBlink.IceBlinkGroupBoxMedium gbPcSelect;
    }
}
