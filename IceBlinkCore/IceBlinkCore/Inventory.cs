using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace SpaceFrontiersCore
{
    [Serializable]
    public class Inventory
    {
        [XmlArrayItem("PartyInventory")]
        public List<Item> partyInventoryList = new List<Item>();

        public Inventory()
        {
        }

        public void saveInventoryFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Inventory));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                string strErr = "Unable to save Inventory file. Error: " + ex.Message;
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

        public Inventory loadInventoryFile(string filename)
        {
            Inventory toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Inventory));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Inventory)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                string strErr = String.Format("Unable to open xml Inventory file. Error:\n{0}", ex.Message);
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

        public Item getItem(string tag)
        {
            foreach (Item it in partyInventoryList)
            {
                if (it.p_tag == tag) return it;
            }
            return null;
        }
    }
}
