using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using IceBlink;
using IceBlinkToolset;

namespace IceBlinkCore
{
    [Serializable]
    public class Journal
    {
        [XmlIgnore]
        public Game game;

        private int nextIdNum = 0;
        [XmlElement]
        public int NextIdNum
        {
            get 
            {
                nextIdNum++;
                return nextIdNum;
            }
            set { nextIdNum = value; }
        }

        [XmlArrayItem("JournalCategories")]
        public List<JournalCategory> categories = new List<JournalCategory>();

        public Journal()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveJournalFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Journal));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Journal file. Error: " + ex.Message);
                game.errorLog(ex.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                writer = null;
            }
        }
        public Journal loadJournalFile(string filename)
        {
            Journal toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Journal));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Journal)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Journal file (blank one created). Error:\n{0}", ex.Message);
                game.errorLog(ex.ToString());
                toReturn = new Journal(); 
            }
            finally
            {
                if (myFileStream != null)
                {
                    myFileStream.Close();
                }
            }
            return toReturn;
        }
        public JournalCategory getJournalCategoryByName(string name)
        {
            foreach (JournalCategory it in categories)
            {
                if (it.Name == name) return it;
            }
            return null;
        }
        public JournalCategory getJournalCategoryByTag(string tag)
        {
            foreach (JournalCategory it in categories)
            {
                if (it.Tag == tag) return it;
            }
            return null;
        }
        public Journal DeepCopy()
        {
            Journal other = (Journal)this.MemberwiseClone();
            other.categories = new List<JournalCategory>();
            foreach (JournalCategory jcat in this.categories)
            {
                JournalCategory j = jcat.DeepCopy();
                other.categories.Add(j);
            }
            return other;
        }
    }

    [Serializable]
    public class JournalCategory
    {
        [XmlIgnore]
        public Game game;

        public enum priority
        {
            Highest = 0,
            High = 1,
            Medium = 2,
            Low = 3,
            Lowest = 4
        }

        #region Fields
        private int orderIndex = 0;
        private string name = "newCategory";
        private string tag = "tag";
        private priority _priority = priority.Medium;
        private List<JournalEntry> entries = new List<JournalEntry>();
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("JournalCategory"), DescriptionAttribute("index"), ReadOnly(true)]
        public int OrderIndex
        {
            get { return orderIndex; }
            set { orderIndex = value; }
        }

        [XmlElement]
        [CategoryAttribute("JournalCategory"), DescriptionAttribute("Name of the quest. Will be used as the title of the quest in the player's journal.")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlElement]
        [CategoryAttribute("JournalCategory"), DescriptionAttribute("Tag of the Category (Must be unique)")]
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }
                
        [XmlElement]
        [CategoryAttribute("JournalCategory"), DescriptionAttribute("Item Category Type")]
        public priority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        [XmlArrayItem("JournalEntries")]
        [CategoryAttribute("JournalCategory"), ReadOnly(true)]
        public List<JournalEntry> Entries
        {
            get { return entries; }
            set { entries = value; }
        }       
        #endregion

        public JournalCategory()
        {
        }
        public override string ToString()
        {
            return Name;
        }
        public JournalEntry getJournalEntryByTag(string tag)
        {
            foreach (JournalEntry it in entries)
            {
                if (it.Tag == tag) return it;
            }
            return null;
        }
        public JournalCategory ShallowCopy()
        {
            return (JournalCategory)this.MemberwiseClone();
        }
        public JournalCategory DeepCopy()
        {
            JournalCategory other = (JournalCategory)this.MemberwiseClone();
            other.Entries = new List<JournalEntry>();
            foreach (JournalEntry jent in this.entries)
            {
                JournalEntry j = jent.DeepCopy();
                other.Entries.Add(j);
            }
            return other;
        }        
    }

    [Serializable]
    public class JournalEntry
    {

        #region Fields
        private int orderIndex;
        private string entryTitle = "newTitle";
        private string entryText = "quest entry text";
        private string tag = "tag";
        private bool endPoint = false;
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("JournalEntry"), DescriptionAttribute("index"), ReadOnly(true)]
        public int OrderIndex
        {
            get { return orderIndex; }
            set { orderIndex = value; }
        }

        [XmlElement]
        [CategoryAttribute("JournalEntry"), DescriptionAttribute("Journal entry title for this node of the quest. This is the entry's title that will show up in the player's Journal.")]
        public string EntryTitle
        {
            get { return entryTitle; }
            set { entryTitle = value; }
        }

        [XmlElement]
        [CategoryAttribute("JournalEntry"), DescriptionAttribute("Journal entry text for this node of the quest. This is the quest information that will show up in the player's Journal.")]
        public string EntryText
        {
            get { return entryText; }
            set { entryText = value; }
        }

        [XmlElement]
        [CategoryAttribute("JournalEntry"), DescriptionAttribute("Tag of the entry (Must be unique)")]
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        [XmlElement]
        [CategoryAttribute("JournalEntry"), DescriptionAttribute("TRUE means that the quest is considered completed upon reaching this entry. FALSE means that this quest is still active upon reaching this entry.")]
        public bool EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
        #endregion

        public JournalEntry()
        {
            //this.OrderIndex = index;
            //this.Tag = "EntryTag" + nextID.ToString();
        }
        public JournalEntry ShallowCopy()
        {
            return (JournalEntry)this.MemberwiseClone();
        }
        public JournalEntry DeepCopy()
        {
            JournalEntry other = (JournalEntry)this.MemberwiseClone();
            //other.IdInfo = new IdInfo(this.IdInfo.IdNumber);
            return other;
        }
    }
}
