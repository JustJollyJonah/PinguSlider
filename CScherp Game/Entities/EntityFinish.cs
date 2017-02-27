using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public class EntityFinish : Entity
    {
        // Constructor
        public EntityFinish(double x, double y) : base(x, y) { }

        public override void OnCollide(EntityCollisionEventArgs args)
        {
            // Doe niks!
        }

        public override Bitmap GetBitmap()
        {
            // Sprite van het object
            return CScherp_Game.Properties.Resources.iglo ;
        }
    }
}
