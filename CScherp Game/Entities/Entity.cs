using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public abstract class Entity : Rectangle
    {
        public Vector Speed { get; set; }
        public bool Moving
        {
            get
            {
                return Speed.Length > 0;
            }
        }

        public double Drag { get; protected set; } = 0.95;

        public Entity() : this(0, 0) { }
        public Entity(double x, double y) : this(x, y, 0, 0) { }
        public Entity(double x, double y, int w, int h) : base(x, y, w, h)
        {
            Speed = new Vector(0, 0);

            // Breedte en hoogte niet gespecificeerd? En er is een sprite?
            // Gebruik dan de resolutie van de sprite!
            Bitmap bmp = GetBitmap();
            if (w == 0 && h == 0 && bmp != null) {
                Size = new Vector(bmp.Width, bmp.Height);
            }
        }

        public void OnSpawn(Level l) {
            l.EntityCollisionHandlers += this.OnCollide;
        }
        public void OnDestroy(Level l) {
            l.EntityCollisionHandlers -= this.OnCollide;
        }

        public virtual void OnCollide(EntityCollisionEventArgs args)
        {
            this.HandleCollisionStop(args.Collision);
        }

        public virtual void Update(Level l, long dt) { }

        public virtual void Move(Level l, double dt)
        {
            MoveForVector(Speed);
        }

        public void MoveForVector(Vector v)
        {
            Position += v;
            Speed *= (v.Length > 0.1) ? Drag : 0;
        }

        public virtual void Render(Graphics g)
        {
            Bitmap bmp = GetBitmap();
           
            if (bmp != null)
            {
                g.DrawImage(bmp, X1.Floor(), Y1.Floor(), (float) bmp.Width, (float) bmp.Height);
            }
        }

        public virtual Bitmap GetBitmap()
        {
            return null;
        }

        public override string ToString()
        {
            return String.Format(GetType().Name);
        }

    }
}
