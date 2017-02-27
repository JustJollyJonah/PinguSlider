using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public class Vector
    {

        public double X { get; private set; }
        public double Y { get; private set; }

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
            }
        }

        public Vector() : this(0, 0)
        { }

        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector Add(double x, double y)
        {
            return this + new Vector(x, y);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public Vector Subtract(double x, double y)
        {
            return this - new Vector(x, y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public Vector Multiply(double x, double y)
        {
            return this * new Vector(x, y);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y);
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        public Vector Divide(double x, double y)
        {
            return this / new Vector(x, y);
        }

        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(
                (b.X == 0) ? 0 : (a.X / b.X),
                (b.Y == 0) ? 0 : (a.Y / b.Y)
            );
        }

        public static Vector operator /(Vector a, double b)
        {
            if (b == 0)
                return new Vector(0, 0);
            return new Vector(a.X / b, a.Y / b);
        }

        public Vector Negate()
        {
            return !this;
        }

        public static Vector operator !(Vector a)
        {
            return new Vector(0 - a.X, 0 - a.Y);
        }

        public static bool operator <(Vector a, Vector b)
        {
            return a.Length < b.Length;
        }

        public static bool operator >(Vector a, Vector b)
        {
            return a.Length > b.Length;
        }

        public static bool operator <=(Vector a, Vector b)
        {
            return a.Length <= b.Length;
        }

        public static bool operator >=(Vector a, Vector b)
        {
            return a.Length >= b.Length;
        }

        public Vector Delta(Vector a)
        {
            return new Vector(
                a.X - this.X,
                a.Y - this.Y
            );
        }

        public double Distance(Vector a)
        {
            return this.Delta(a).Length;
        }

        public Vector Normalize()
        {
            double length = this.Length;
            if (length == 0)
                return new Vector(0, 0);
            return new Vector(this.X / length, this.Y / length);
        }

        public Vector SetX(double x)
        {
            return new Vector(x, Y);
        }

        public Vector SetY(double y)
        {
            return new Vector(X, y);
        }

        public Vector GetX()
        {
            return new Vector(X, 0);
        }

        public Vector GetY()
        {
            return new Vector(0, Y);
        }

        public Vector Minimum(double? x = null, double? y = null)
        {
            return new Vector(
                (x == null) ? X : X.Min((double) x),
                (y == null) ? Y : Y.Min((double) y) 
            );
        }

        public Vector Maximum(double? x = null, double? y = null)
        {
            return new Vector(
                (x == null) ? X : X.Max((double)x),
                (y == null) ? Y : Y.Max((double)y)
            );
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Vector))
            {
                Vector v = (Vector)obj;
                return (v.X == X && v.Y == Y);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Vector({0}, {1})", Math.Round(X, 4), Math.Round(Y, 4));
        }

    }

    public static class VectorHelper
    {

        /* VectorHelper_Min_ShouldReturnLowestArgument */
        public static double Min(this double a, params double[] list)
        {
            double cur = a;
            foreach (double other in list)
                if (other < cur)
                    cur = other;
            return cur;
        }

        /* VectorHelper_Max_ShouldReturnHighestArgument */
        public static double Max(this double a, params double[] list)
        {
            double cur = a;
            foreach (double other in list)
                if (other > cur)
                    cur = other;
            return cur;
        }

        /* VectorHelper_IsPositive_WhenPositive_ShouldReturnTrue
         * VectorHelper_IsPositive_WhenZero_ShouldReturnTrue
         * VectorHelper_IsPositive_WhenNegative_ShouldReturnFalse */
        public static bool IsPositive(this double a)
        {
            return a >= 0;
        }
        /* VectorHelper_IsNegative_WhenPositive_ShouldReturnFalse
         * VectorHelper_IsNegative_WhenZero_ShouldReturnFalse
         * VectorHelper_IsNegative_WhenNegative_ShouldReturnTrue */
        public static bool IsNegative(this double a)
        {
            return a < 0;
        }

        /* VectorHelper_Floor_ShouldRoundDown */
        public static int Floor(this double a)
        {
            return (int)Math.Floor(a);
        }

        /* VectorHelper_Ceiling_ShouldRoundUp */
        public static int Ceiling(this double a)
        {
            return (int)Math.Ceiling(a);
        }
    }
}
