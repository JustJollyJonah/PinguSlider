using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game.Views
{
    public class GameView : View
    {
        public override void Update(Model model, long dt)
        {
            Game game = (Game)model;
            Level level = game.Level;
            Graphics g = game.Window.Graphics;

            // Scherm legen
            g.DrawImage(CScherp_Game.Properties.Resources.bg, 0, 0);

            // Alle entities renderen in deze View
            level.Render(g);
        }
    }
}
