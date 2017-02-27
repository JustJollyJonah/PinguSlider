using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;


namespace CScherp_Game
{
    public class XmlParser
    {
        public XmlDocument levelDocument { get; set; }
        public List<Entity> entities;
        public Boolean isResource; //voor unit tests

        public XmlParser() //unit test constructor
        {
            entities = new List<Entity>();
        }

        //zet het bestand of resource om in een uitleesbaar XmlDocument object
        public XmlParser(string path, Game game)
        {
            this.levelDocument = new XmlDocument();
            this.entities = new List<Entity>();
            Console.WriteLine(path);
            if (path.StartsWith("<")) //check of het een resource is
            {
                Console.WriteLine("It's a resource!");
                isResource = true;
                levelDocument.LoadXml(path); //laad de resource in een XmlDocument
            }
            else
            {
                Console.WriteLine("It's not a resource!");
                isResource = false; 
                levelDocument.Load(path); //laad Xml bestand in een XmlDocument
            }
            //vul de lijst met entities
            this.entities = PopulateEntities();
        }

   
        //in deze functie word een lijst met entities gemaakt, die lijst word gebruikt om een level mee te maken
        public List<Entity> PopulateEntities()
        {
            //check of er uberhaupt entities in de xml staan
            if (levelDocument.SelectNodes("//entity").Count == 0)
            {
               Console.WriteLine("Level does not contain any entities");
                return null;
            }
            else
            {
                Console.WriteLine(levelDocument.SelectNodes("//entity").Count);
                //loop door alle xml nodes heen
                foreach (XmlNode node in levelDocument.SelectNodes("//entity"))
                {
                    entities.Add(getEntityFromNode(node)); //voeg de bijbehorende entity aan de lijst toe
                }

                if (ValidateEntityList(entities)) //check of het level een speler en finish bevat
                {
                    return entities;
                }
                else
                {
                    return null;
                }
            }
        }
        
        //zet een node om in een entity
        public Entity getEntityFromNode(XmlNode node)
        {
            string type;
            double x;
            double y;
            //kijk of alle entities hun attributes hebben
            try
            {
                type = node.Attributes["type"].Value;
                Console.WriteLine(node.Attributes["type"].Value);
                x = double.Parse(node.Attributes["x"].Value);
                y = double.Parse(node.Attributes["y"].Value);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Xml node is missing vital attribute(s)");
                return null;
            }

            //kijk welk type de entities hebben en return een entity van het goede soort met de goede attributen
            switch (type) 
            {
                case "finish":
                    return new EntityFinish(x, y);
                case "obstacle1":
                    double vx;
                    double vy;
                    //Kijk of een bewegend obstakel wel een snelheid/richting heeft
                    try
                    {
                        vx = double.Parse(node.Attributes["vx"].Value);
                        vy = double.Parse(node.Attributes["vy"].Value);
                    } catch (NullReferenceException)
                    {
                        Console.WriteLine("Moving obstacle is missing speed/direction attribute");
                        
                        return null;
                    }
                    return new EntityObstacleMoving(x, y, vx, vy);
                case "obstacle2":
                    return new EntityObstacleStatic(x, y);
                case "player":
                    return new EntityPlayer(x, y);
                default:
                    return null;
            }

        }

        //Valideer of een level daadwerkelijk een speler en een finish heeft.
        //Kijk daarnaast of er niet meerdere spelers in staan 
        public Boolean ValidateEntityList(List<Entity> entityList)
        {
            int playercount = 0; 
            //tel het aantal spelers (zou 1 moeten zijn)
            foreach (Entity ep in entityList)
            {
                if(ep.GetType() == typeof(EntityPlayer)) {
                    playercount = playercount + 1;
                }
            }

            Console.WriteLine(playercount);
            // kijk of het level een finish heeft
            if (entityList.OfType<EntityFinish>().Any() == false)
            {
                Console.WriteLine("Xml file does not contain a finish entity");
                return false;
            //kijk of het level een speler heeft
            } else if (entityList.OfType<EntityPlayer>().Any() == false)
            {
               Console.WriteLine("Xml file does not contain a player entity");
                return false;
            // kijk of het level niet meerdere spelers heeft
            } else if (playercount > 1)
            {
                Console.WriteLine("Xml file contains more than 1 player");
                return false;
        } else
            {
                return true;
            }
        } 
    }
}
