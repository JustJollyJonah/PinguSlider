using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public class EntityObstacleStatic : Entity
    {

        public bool Exploded;

        // Constructor
        public EntityObstacleStatic(double x, double y) : base(x, y)
        {
            Exploded = false;
        }

        public override void OnCollide(EntityCollisionEventArgs args)
        {
            base.OnCollide(args);

            if (!args.Collision.IsRelevant(this))
                return; // If not relevant then return

            //Console.WriteLine(args.Collision);

            Entity other = args.Collision.GetOther(this);

            if (other is EntityPlayer)
                Exploded = true; // Entity explodeerd als player er tegenaan botst
                        
        }

        public override Bitmap GetBitmap()
        {
            // Sprite van het obstakel
            return Exploded ? CScherp_Game.Properties.Resources.Explode : CScherp_Game.Properties.Resources.iceberg;
        }
    }
}
