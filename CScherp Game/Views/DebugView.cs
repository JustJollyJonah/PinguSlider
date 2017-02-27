using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game
{
    public class DebugView : View
    {

        public override void Update(Model m, long dt)
        {
            Game game = (Game)m;
            Graphics g = game.Window.Graphics;

            Level level = game.Level;
            if (level != null)
            {
                foreach (Entity e in level.Entities)
                {
                    e.RenderDebugInfo(g);
                }
            }
        }

    }

    public static class DebugRenderer
    {
        public static void RenderDebugInfo(this Entity e, Graphics g)
        {
            // Muren interesseren ons niet zo veel!
            if (e is EntityWall)
                return;

            // Draw red outline and cross
            RenderHelper.SetColor(Color.Red);
            RenderHelper.DrawCrossRectangle(g, e);

            // Begin rendering vector lines   
            RenderHelper.SetColor(Color.Blue);
            const double VECTOR_SCALE = 10.0;

            // Grab rectangle floored
            Rectangle floored = e.Floored;

            // Find begin spot for horizontal line
            Vector begin = (e.Speed.X > 0) ?
                floored.RightSide.GetCenter() :
                    (e.Speed.X < 0) ?
                        floored.LeftSide.GetCenter() : null;

            // Draw horizontal line, if any
            if (begin != null)
                RenderHelper.DrawLineRel(g, begin, new Vector(e.Speed.X, 0) * VECTOR_SCALE);

            // Find begin spot for vertical line
            begin = (e.Speed.Y > 0) ?
                floored.BottomSide.GetCenter() :
                    (e.Speed.Y < 0) ?
                        floored.TopSide.GetCenter() : null;

            // Draw vertical line, if any
            if (begin != null)
                RenderHelper.DrawLineRel(g, begin, new Vector(0, e.Speed.Y) * VECTOR_SCALE);

            RenderHelper.SetColor(Color.Black);
            RenderHelper.DrawString(g,
                String.Format("X1: {0}\nY1: {1}\nX2: {2}\nY2: {3}\nvX: {4}\nvY: {5}",
                    Math.Round(floored.X1, 2),
                    Math.Round(floored.Y1, 2),
                    Math.Round(floored.X2, 2),
                    Math.Round(floored.Y2, 2),
                    Math.Round(e.Speed.X, 2),
                    Math.Round(e.Speed.Y, 2)),
                (int) (floored.X1 + floored.Width + 2), (int) floored.Y1);
        }
    }

}
