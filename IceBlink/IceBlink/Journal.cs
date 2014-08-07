using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;

namespace IceBlink
{
    public partial class JournalScreen : IBForm
    {
        private Form1 frm;
        private Game game;
        private int _selectedLbxQuestsIndex;
        private int _selectedLbxCompletedIndex;
        private int entryQuestIndex;
        private int entryCompletedIndex;

        public JournalScreen()
        {
            InitializeComponent();
        }
        public void passRefs(Game g, Form1 f)
        {
            game = g;
            frm = f;
            IceBlinkButtonResize.setupAll(game);
            //IceBlinkButtonResize.Enabled = false;
            //IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            btnCompletedBack.setupAll(game);
            btnCompletedNext.setupAll(game);
            btnQuestBack.setupAll(game);
            btnQuestNext.setupAll(game);
            gbQuests.setupAll(game);
            gbCompleted.setupAll(game);
            gbNotes.setupAll(game);
            btnQuestsTab.setupAll(game);
            btnCompletedTab.setupAll(game);
            btnNotesTab.setupAll(game);
            this.setupAll(game);
            _selectedLbxQuestsIndex = 0;
            _selectedLbxCompletedIndex = 0;
            entryQuestIndex = 0;
            entryCompletedIndex = 0;
            refreshlbxQuests();
            refreshlbxCompleted();
            refreshFonts();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.J) && (!rtxtNotes.Focused))
            {
                if (frm.journalOpen)
                {
                    frm.pcJournalScreen.Hide();
                    frm.journalOpen = false;
                }
                else
                {
                    frm.pcJournalScreen.Show();
                    frm.journalOpen = true;
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Handlers
        private void btnQuestsTab_Click(object sender, EventArgs e)
        {
            gbQuests.Visible = true;
            gbCompleted.Visible = false;
            gbNotes.Visible = false;
        }
        private void btnCompletedTab_Click(object sender, EventArgs e)
        {
            gbQuests.Visible = false;
            gbCompleted.Visible = true;
            gbNotes.Visible = false;
        }
        private void btnNotesTab_Click(object sender, EventArgs e)
        {
            gbQuests.Visible = false;
            gbCompleted.Visible = false;
            gbNotes.Visible = true;
        }
        private void lbxQuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbxQuests.Items.Count > 0) && (lbxQuests.SelectedIndex >= 0))
            {
                _selectedLbxQuestsIndex = lbxQuests.SelectedIndex;
                loadLastEntryOfSelectedQuestCategory();
                lbxQuests.SelectedIndex = _selectedLbxQuestsIndex;                
            }            
        }
        private void lbxCompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbxCompleted.Items.Count > 0) && (lbxCompleted.SelectedIndex >= 0))
            {
                _selectedLbxCompletedIndex = lbxCompleted.SelectedIndex;
                loadLastEntryOfSelectedCompletedCategory();
                lbxCompleted.SelectedIndex = _selectedLbxCompletedIndex;
            }
        }
        private void btnQuestBack_Click(object sender, EventArgs e)
        {
            if (game.partyJournalQuests.categories.Count > 0)
            {
                JournalCategory cat = game.partyJournalQuests.categories[_selectedLbxQuestsIndex];
                if ((cat.Entries.Count > 0) && (entryQuestIndex > 0))
                {
                    entryQuestIndex--;
                    JournalEntry entry = cat.Entries[entryQuestIndex];
                    rtxtQuests.Text = entry.EntryTitle + Environment.NewLine + Environment.NewLine + entry.EntryText;
                }
            }
        }
        private void btnQuestNext_Click(object sender, EventArgs e)
        {
            if (game.partyJournalQuests.categories.Count > 0)
            {
                JournalCategory cat = game.partyJournalQuests.categories[_selectedLbxQuestsIndex];
                if ((cat.Entries.Count > 0) && (entryQuestIndex < cat.Entries.Count - 1))
                {
                    entryQuestIndex++;
                    JournalEntry entry = cat.Entries[entryQuestIndex];
                    rtxtQuests.Text = entry.EntryTitle + Environment.NewLine + Environment.NewLine + entry.EntryText;
                }
            }
        }
        private void btnCompletedBack_Click(object sender, EventArgs e)
        {
            if (game.partyJournalCompleted.categories.Count > 0)
            {
                JournalCategory cat = game.partyJournalCompleted.categories[_selectedLbxCompletedIndex];
                if ((cat.Entries.Count > 0) && (entryCompletedIndex > 0))
                {
                    entryCompletedIndex--;
                    JournalEntry entry = cat.Entries[entryCompletedIndex];
                    rtxtCompleted.Text = entry.EntryTitle + Environment.NewLine + Environment.NewLine + entry.EntryText;
                }
            }
        }
        private void btnCompletedNext_Click(object sender, EventArgs e)
        {
            if (game.partyJournalCompleted.categories.Count > 0)
            {
                JournalCategory cat = game.partyJournalCompleted.categories[_selectedLbxCompletedIndex];
                if ((cat.Entries.Count > 0) && (entryCompletedIndex < cat.Entries.Count - 1))
                {
                    entryCompletedIndex++;
                    JournalEntry entry = cat.Entries[entryCompletedIndex];
                    rtxtCompleted.Text = entry.EntryTitle + Environment.NewLine + Environment.NewLine + entry.EntryText;
                }
            }
        }
        private void rtxtNotes_TextChanged(object sender, EventArgs e)
        {
            game.partyJournalNotes = rtxtNotes.Text;
        }
        private void JournalScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.journalOpen = false;
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }
        #endregion

        #region Methods
        public void refreshFonts()
        {
            rtxtQuests.BackColor = game.module.ModuleTheme.ConvoBackColor;
            lbxQuests.BackColor = game.module.ModuleTheme.ConvoBackColor;
            rtxtCompleted.BackColor = game.module.ModuleTheme.ConvoBackColor;
            lbxCompleted.BackColor = game.module.ModuleTheme.ConvoBackColor;
            rtxtNotes.BackColor = game.module.ModuleTheme.ConvoBackColor;
            
            rtxtQuests.ForeColor = game.module.ModuleTheme.ConvoTextColor;
            lbxQuests.ForeColor = game.module.ModuleTheme.ConvoTextColor;
            rtxtCompleted.ForeColor = game.module.ModuleTheme.ConvoTextColor;
            lbxCompleted.ForeColor = game.module.ModuleTheme.ConvoTextColor;
            rtxtNotes.ForeColor = game.module.ModuleTheme.ConvoTextColor;
            
            lbxQuests.Font = frm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            lbxCompleted.Font = frm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            rtxtQuests.Font = frm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            rtxtCompleted.Font = frm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);
            rtxtNotes.Font = frm.ChangeFontSize(game.module.ModuleTheme.ModuleFont, 1.25f);

            btnQuestsTab.Font = game.module.ModuleTheme.ModuleFont;
            btnCompletedTab.Font = game.module.ModuleTheme.ModuleFont;
            btnNotesTab.Font = game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        public void refreshAll()
        {
            //TODO need to refresh the text box as well for both
            rtxtQuests.Text = "";
            rtxtCompleted.Text = "";
            refreshlbxQuests();
            refreshlbxCompleted();            
            rtxtNotes.Text = game.partyJournalNotes;
            refreshFonts();
        }
        public void refreshlbxQuests()
        {
            lbxQuests.BeginUpdate();
            lbxQuests.DataSource = null;
            lbxQuests.DataSource = game.partyJournalQuests.categories;
            lbxQuests.DisplayMember = "Name";
            lbxQuests.EndUpdate();
        }
        public void refreshlbxCompleted()
        {
            lbxCompleted.BeginUpdate();
            lbxCompleted.DataSource = null;
            lbxCompleted.DataSource = game.partyJournalCompleted.categories;
            lbxCompleted.DisplayMember = "Name";
            lbxCompleted.EndUpdate();
        }
        public void loadLastEntryOfSelectedQuestCategory()
        {
            if (game.partyJournalQuests.categories.Count > 0)
            {
                JournalCategory cat = game.partyJournalQuests.categories[_selectedLbxQuestsIndex];
                if (cat.Entries.Count > 0)
                {
                    JournalEntry entry = cat.Entries[cat.Entries.Count - 1];
                    entryQuestIndex = cat.Entries.Count - 1;
                    rtxtQuests.Text = entry.EntryTitle + Environment.NewLine + Environment.NewLine + entry.EntryText;
                }
            }
        }
        public void loadLastEntryOfSelectedCompletedCategory()
        {
            if (game.partyJournalCompleted.categories.Count > 0)
            {
                JournalCategory cat = game.partyJournalCompleted.categories[_selectedLbxCompletedIndex];
                if (cat.Entries.Count > 0)
                {
                    JournalEntry entry = cat.Entries[cat.Entries.Count - 1];
                    entryCompletedIndex = cat.Entries.Count - 1;
                    rtxtCompleted.Text = entry.EntryTitle + Environment.NewLine + Environment.NewLine + entry.EntryText;
                }
            }
        }
        #endregion        
    }
}
