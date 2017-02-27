using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{

    public class Rectangle
    {

        public Vector Position { get; set; }
        public Vector Size { get; set; }

        public double X1
        {
            get
            {
                return Position.X;
            }
            set
            {
                Position = new Vector(value, Position.Y);
            }
        }

        public double Y1
        {
            get
            {
                return Position.Y;
            }
            set
            {
                Position = new Vector(Position.X, value);
            }
        }

        public double X2
        {
            get /* Rectangle_X2Get_ShouldReturnPositionPlusSizeMinusOne */
            {
                return Position.X + Size.X - 1;
            }
            set /* Rectangle_X2Set_ShouldUpdatePositionToValueMinusSizePlusOne */
            {
                Position = new Vector(value - Size.X + 1, Position.Y);
            }
        }

        public double Y2
        {
            get /* Rectangle_Y2Get_ShouldReturnPositionPlusSizeMinusOne */
            {
                return Position.Y + Size.Y - 1;
            }
            set /* Rectangle_Y2Set_ShouldUpdatePositionToValueMinusSizePlusOne */
            {
                Position = new Vector(Position.X, value - Size.Y + 1);
            }
        }

        public double Width
        {
            get
            {
                return Size.X;
            }
            set
            {
                Size = new Vector(value, Size.Y);
            }
        }

        public double Height
        {
            get
            {
                return Size.Y;
            }
            set
            {
                Size = new Vector(Size.X, value);
            }
        }

        public double Left
        {
            get { return X1; }
        }

        public double Right
        {
            get { return X2; }
        }

        public double Top
        {
            get { return Y1; }
        }

        public double Bottom
        {
            get { return Y2; }
        }

        public Rectangle LeftSide
        {
            get /* No unit test */
            {
                return new Rectangle(this.X1, this.Y1, 0, this.Height);
            }
        }

        public Rectangle RightSide
        {
            get /* No unit test */
            {
                return new Rectangle(this.X2, this.Y1, 0, this.Height);
            }
        }

        public Rectangle TopSide
        {
            get /* No unit test */
            {
                return new Rectangle(this.X1, this.Y1, this.Width, 0);
            }
        }

        public Rectangle BottomSide
        {
            get /* No unit test */
            {
                return new Rectangle(this.X1, this.Y2, this.Width, 0);
            }
        }

        public Rectangle Floored
        {
            get /* Rectangle_Floored_ShouldReturnFlooredRectangle */
            {
                return new Rectangle(X1.Floor(), Y1.Floor(), Width.Floor(), Height.Floor());
            }
        }

        public Rectangle(double x, double y, double w, double h)
        {
            Position = new Vector(x, y);
            Size = new Vector(w, h);
        }

        /* Rectangle_IntersectsRectangle_WhenNoOverlap_ShouldReturnFalse
         * Rectangle_IntersectsRectangle_WhenCollide_ShouldReturnFalse
         * Rectangle_IntersectsRectangle_WhenOverlap_ShouldReturnTrue */
        public bool Intersects(Rectangle r)
        {
            return X1 <= r.X2 && X2 >= r.X1 && Y1 <= r.Y2 && Y2 >= r.Y1;
        }

        /* Rectangle_IntersectsVector_WhenInside_ShouldReturnTrue
         * Rectangle_IntersectsVector_WhenOnBorder_ShouldReturnTrue
         * Rectangle_IntersectsVector_WhenOutside_ShouldReturnFalse */
        public bool Intersects(Vector v)
        {
            return (v.X >= X1) && (v.Y >= Y1) && (v.X <= X2) && (v.Y <= Y2);
        }

        /* Rectangle_GetCenter_WhenEvenDimensions_ShouldReturnWithDecimals
         * Rectangle_GetCenter_WhenUnevenDimensions_ShouldReturnWithoutDecimals */
        public Vector GetCenter()
        {
            return new Vector(X1 + ((X2 - X1) / 2), Y1 + ((Y2 - Y1) / 2));
        }

        /* Rectangle_AtPosition_ShouldReturnRectangleAtPositionWithOldDimensions
         * Rectangle_AtPosition_ShouldReturnNewRectangleWithOldDimensions */
        public Rectangle AtPosition(Vector pos)
        {
            return new Rectangle(pos.X, pos.Y, Size.X, Size.Y);
        }

    }
}
