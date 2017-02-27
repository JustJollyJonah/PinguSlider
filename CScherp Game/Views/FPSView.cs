using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game.Views
{
    public class FPSView : View
    {
        public bool Enabled { get; set; }
        private int LastFPS;
        private long LastFPSStamp;
        private int CurrentFPS;

        public FPSView() : base()
        {
            LastFPS = 0;
            LastFPSStamp = 0;
            CurrentFPS = 0;
        }

        public override void Update(Model model, long dt)
        {
            Game game = (Game)model;
            Graphics g = game.Window.Graphics;

            if (Enabled)
            {
                // FPS Rendering
                long now = game.Stopwatch.ElapsedMilliseconds;
                if (now - LastFPSStamp > 1000)
                {
                    LastFPSStamp = now;
                    LastFPS = CurrentFPS;
                    CurrentFPS = 0;
                }
                CurrentFPS++;
                game.Window.label14.Text = "FPS: " + LastFPS;
            }
            else
            {
                game.Window.label14.Text = "";
            }
        }
    }
}
