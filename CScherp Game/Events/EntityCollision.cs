using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public delegate void EntityCollisionHandler(EntityCollisionEventArgs args);

    public class EntityCollisionEventArgs : EventArgs
    {

        public Game Game { get; }
        public Collision Collision { get; }
        
        public EntityCollisionEventArgs(Game game, Collision c)
        {
            Game = game;
            Collision = c;
        }

    }
}
