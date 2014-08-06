using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using IceBlink;

namespace IceBlinkCore
{
    [Serializable]
    public class Containers
    {
        [XmlIgnore]
        public Game game;
        [XmlArrayItem("Containers")]
        public List<Container> containers = new List<Container>();
        public Containers()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveContainersFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Containers));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Containers file. Error: " + ex.Message);
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
        public Containers loadContainersFile(string filename)
        {
            Containers toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Containers));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Containers)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Containers file. Error:\n{0}", ex.Message);
                game.errorLog(ex.ToString());
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
        public Container getContainer(string tag)
        {
            foreach (Container cont in containers)
            {
                if (cont.containerTag == tag) return cont;
            }
            return null;
        }
    }

    [Serializable]
    public class Container
    {
        [XmlIgnore]
        public Game game;
        [XmlElement]
        public string containerTag = ""; //container tag
        [XmlArrayItem ("ContainerItems")]
        public List<string> items = new List<string>();
        [XmlElement]
        public List<string> containerItemTags = new List<string>();
        [XmlElement]
        public List<string> InitialContainerItemTags = new List<string>();
        [XmlIgnore]
        public List<Item> containerInventoryList = new List<Item>();

        public Container()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public override string ToString()
        {
            return containerTag;
        }
        public string ContainerTag
        {
            get { return containerTag; }
        }
        public Container DeepCopy()
        {
            Container other = (Container)this.MemberwiseClone();

            other.items = new List<string>();
            foreach (string str in this.items)
            {
                other.items.Add(str);
            }

            other.containerItemTags = new List<string>();
            foreach (string str in this.containerItemTags)
            {
                other.containerItemTags.Add(str);
            }

            other.InitialContainerItemTags = new List<string>();
            foreach (string str in this.InitialContainerItemTags)
            {
                other.InitialContainerItemTags.Add(str);
            }

            other.containerInventoryList = new List<Item>();

            return other;
        }
    }
}
