using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using IceBlink;

namespace IceBlinkCore
{
    [Serializable]
    public class Config
    {
        /*
        [XmlIgnore]
        public Game game;

        //private string defaultThemeFolderName;
        //private string defaultThemeFilename;

        [XmlElement]
        public string DefaultThemeFolderName
        {
            get
            {
                return defaultThemeFolderName;
            }
            set
            {
                defaultThemeFolderName = value;
            }
        }
        [XmlElement]
        public string DefaultThemeFilename
        {
            get
            {
                return defaultThemeFilename;
            }
            set
            {
                defaultThemeFilename = value;
            }
        }
        
        public Config()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveConfigFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Config));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Config file. Error: " + ex.Message);
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
        public Config loadConfigFile(string filename)
        {
            Config toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Config)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Config file. Error:\n{0}", ex.Message);
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
        */
    }
}
