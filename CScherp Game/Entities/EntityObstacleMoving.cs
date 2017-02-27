using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{

    public class EntityObstacleMoving : Entity
    {

        public EntityObstacleMoving(double x, double y) : this(x, y, 1, 0) { }
        public Bitmap seelLeft;
        public Bitmap seelRight;
        public EntityObstacleMoving(double x, double y, double vx, double vy) : base(x, y)
        {
            Speed = new Vector(vx, vy);
            Drag = 1;
            seelLeft = CScherp_Game.Properties.Resources.seelLeft;
            seelRight = CScherp_Game.Properties.Resources.seel;
            this.Size = new Vector(seelLeft.Width, seelLeft.Height);
        }

        public override void OnCollide(EntityCollisionEventArgs args)
        {
            this.HandleCollisionBounce(args.Collision);
        }

        public override Bitmap GetBitmap()
        {
            return (Speed.X > 0 || Speed.Y > 0) ? seelRight : seelLeft; // Sprite van het obstakel (veranderd als hij in een andere richting beweegt)
        }
    }
}
