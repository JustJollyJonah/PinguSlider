using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public static class RenderHelper
    {

        private static Font _Font = new Font("Consolas", 8);
        private static Dictionary<Color, Pen> _Pens = new Dictionary<Color, Pen>();
        private static Pen _ActivePen;

        public static void SetColor(Color c)
        {
            Pen pen = _Pens.ContainsKey(c) ? _Pens[c] : null;
            if (pen == null)
            {
                pen = _Pens[c] = new Pen(c, 1);
            }
            _ActivePen = pen;
        }

        public static void DrawString(Graphics g, String s, Vector v)
        {
            DrawString(g, s, v.X.Floor(), v.Y.Floor());
        }
        public static void DrawString(Graphics g, String s, int x, int y)
        {
            g.DrawString(s, _Font, _ActivePen.Brush, x, y);
        }

        public static void DrawLineRel(Graphics g, Vector v1, Vector v2)
        {
            DrawLineRel(g, v1.X.Floor(), v1.Y.Floor(), v2.X.Floor(), v2.Y.Floor());
        }
        public static void DrawLineRel(Graphics g, int x, int y, int dx, int dy)
        {
            DrawLineAbs(g, x, y, x + dx, y + dy);
        }

        public static void DrawLineAbs(Graphics g, Vector v1, Vector v2)
        {
            DrawLineAbs(g, v1.X.Floor(), v1.Y.Floor(), v2.X.Floor(), v2.Y.Floor());
        }
        public static void DrawLineAbs(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(_ActivePen, x1, y1, x2, y2);
        }

        public static void DrawRectangle(Graphics g, Rectangle r)
        {
            DrawRectangle(g, r.X1.Floor(), r.Y1.Floor(), r.Width.Floor(), r.Width.Floor());
        }
        public static void DrawRectangle(Graphics g, int x, int y, int width, int height)
        {
            g.DrawRectangle(_ActivePen, x, y, width - 1, height - 1);
        }

        public static void DrawCrossRectangle(Graphics g, Rectangle r)
        {
            DrawCrossRectangle(g, r.X1.Floor(), r.Y1.Floor(), r.Width.Floor(), r.Height.Floor());
        }
        public static void DrawCrossRectangle(Graphics g, int x, int y, int width, int height)
        {
            DrawRectangle(g, x, y, width, height);
            DrawLineAbs(g, x, y, x + width - 1, y + height - 1);
            DrawLineAbs(g, x, y + height - 1, x + width - 1, y);
        }

    }
}
