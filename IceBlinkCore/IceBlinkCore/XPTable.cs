using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using IceBlink;

namespace IceBlinkCore
{
    /*[Serializable]
    public class XPTable
    {
        [XmlArrayItem]
        public int[] Fighter;
        [XmlArray]
        public int[] Thief;
        [XmlArray]
        public int[] Mage;
        [XmlIgnore]
        public Game game;

        public XPTable()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void SetValues()
        {
            this.Fighter = new int[9] { 0, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000 };
            this.Thief = new int[9] { 0, 1250, 2500, 5000, 10000, 20000, 40000, 70000, 110000 };
            this.Mage = new int[9] { 0, 2500, 5000, 10000, 20000, 40000, 60000, 90000, 135000 };
        }
        public void saveXPTableFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(XPTable));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Items file. Error: " + ex.Message);
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
        public XPTable loadXPTableFile(string filename)
        {
            XPTable toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(XPTable));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (XPTable)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml XPTable file. Error:\n{0}", ex.Message);
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
    }*/
}
