using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public class Level
    {

        public Game Game;
        public List<Entity> Entities { get; }
        public EntityPlayer Player { get; }

        // Breedte / hoogte van de game wereld
        private int GameWidth;
        private int GameHeight;

        // Alle multicast delegates
        public event EntityCollisionHandler EntityCollisionHandlers;

        public Level(Game game, int gameWidth, int gameHeight, List<Entity> entities = null)
        {
            Game = game;
            GameWidth = gameWidth;
            GameHeight = gameHeight;
            Entities = new List<Entity>();

            // Add walls
            this.SpawnEntity(new EntityWall(0, -1, gameWidth, 1)); // Top wall
            this.SpawnEntity(new EntityWall(-1, 0, 1, gameHeight)); // Left wall
            this.SpawnEntity(new EntityWall(gameWidth, 0, 1, gameHeight)); // Right wall
            this.SpawnEntity(new EntityWall(0, gameHeight, gameWidth, 1)); // Bottom wall

            // Spawn all other entities neatly
            if (entities != null)
                foreach(Entity e in entities)
                    this.SpawnEntity(e);

            // Find player object
            var ply = Entities.FirstOrDefault((entity) => entity is EntityPlayer);
            this.Player = (ply != null) ? (EntityPlayer) ply : null;
        }

        public void Update(long dt)
        {
            // Update all entities. This makes every entity type update their Speed vectors.
            foreach (Entity entity in Entities)
            {
                entity.Update(this, dt);
            }

            // Check voor botsingen tussen de entities
            Dictionary<Entity, List<Collision>> collisions = new Dictionary<Entity, List<Collision>>();
            foreach (Entity e1 in Entities)
            {
                foreach(Entity e2 in Entities)
                {
                    if (e1 != e2)
                    {
                        Collision c = e1.FindCollision(e2);
                        if (c != null)
                        {
                            // Add collision to list inside dictionary with Entity1 as key
                            List<Collision> cols1 = collisions.ContainsKey(e1) ? collisions[e1] : null;
                            if (cols1 == null)
                            {
                                cols1 = new List<Collision>();
                                collisions.Add(e1, cols1);
                            }
                            cols1.Add(c);
                            
                            // Add collision to list inside dictionary with Entity2 as key
                            List<Collision> cols2 = collisions.ContainsKey(e2) ? collisions[e2] : null;
                            if (cols2 == null)
                            {
                                cols2 = new List<Collision>();
                                collisions.Add(e2, cols2);
                            }
                            cols2.Add(c);

                            // Invoke the multicast delegate
                            EntityCollisionHandlers(new EntityCollisionEventArgs(Game, c));
                        }
                    }
                }
            }
            
            // Bij alle entities Position += Speed doen
            foreach(Entity e in Entities)
            {
                e.Move(this, 1);
            }
        }

        public void Render(Graphics g)
        {
            foreach (Entity e in Entities)
            {
                e.Render(g);
            }
        }

        public void SpawnEntity(Entity e)
        {
            if (this.Entities.Contains(e))
                return;
            
            this.Entities.Add(e);
            e.OnSpawn(this);
        }

        public void DestroyEntity(Entity e)
        {
            this.Entities.Remove(e);
            //e.OnDestroy(this);
        }

    }
}
