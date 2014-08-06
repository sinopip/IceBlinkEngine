using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using IceBlink;
using System.IO;

namespace IceBlinkCore
{
    [Serializable]
    public class NPCs
    {
        [XmlArrayItem("NPCs")]
        public List<NPC> npcList = new List<NPC>();
        [XmlIgnore]
        public Game game;

        public NPCs()
        {
        }

        public void passRefs(Game g)
        {
            game = g;
        }

        public void saveNPCsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(NPCs));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Creature file. Error: " + ex.Message);
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

        public NPCs loadNPCsFile(string filename)
        {
            NPCs toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(NPCs));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (NPCs)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml NPC file. Error:\n{0}", ex.Message);
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

        public NPC getCreature(string name)
        {
            foreach (NPC cr in npcList)
            {
                if (cr.char_name == name) return cr;
            }
            return null;
        }

        public NPC getCreatureByTag(string tag)
        {
            foreach (NPC crtag in npcList)
            {
                if (crtag.char_tag == tag) return crtag;
            }
            return null;
        }
    }

    [Serializable]
    public class NPC : CharBase
    {
    }
}
