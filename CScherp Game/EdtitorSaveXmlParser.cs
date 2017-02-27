using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace CScherp_Game
{
    static class EdtitorSaveXmlParser
    {
        public static void ParseToXmlAndSave(List<Entity> list)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                //SETUP XML FILE + LEVEL SIZE
                writer.WriteStartDocument();
                writer.WriteStartElement("level");

                //LOOP THROUGH LIST WITH CHOOSEN ENTITY AND CREATE XML NODES + ATTRIBUTE
                foreach (Entity entity in list)
                {
                    String entityXmlName = entity.ToString();
                    Console.WriteLine(entityXmlName);
                    writer.WriteStartElement("entity");

                    switch (entityXmlName)
                    {
                        case "EntityFinish":
                            writer.WriteAttributeString("type", "finish");
                            writer.WriteAttributeString("x", entity.X1.ToString());
                            writer.WriteAttributeString("y", entity.Y1.ToString());
                            break;
                        case "EntityPlayer":
                            writer.WriteAttributeString("type", "player");
                            writer.WriteAttributeString("x", entity.X1.ToString());
                            writer.WriteAttributeString("y", entity.Y1.ToString());
                            break;
                        case "EntityObstacleMoving":
                            writer.WriteAttributeString("type", "obstacle1");
                            writer.WriteAttributeString("x", entity.X1.ToString());
                            writer.WriteAttributeString("y", entity.Y1.ToString());
                            writer.WriteAttributeString("vx", entity.Speed.X.ToString());
                            writer.WriteAttributeString("vy", entity.Speed.Y.ToString());
                            break;
                        case "EntityObstacleStatic":
                            writer.WriteAttributeString("type", "obstacle2");
                            writer.WriteAttributeString("x", entity.X1.ToString());
                            writer.WriteAttributeString("y", entity.Y1.ToString());
                            break;
                        default:
                            break;
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();              
            }
            //Opens a standard system save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc.Save(saveFileDialog.FileName);
            }
        }
        
    }
}
