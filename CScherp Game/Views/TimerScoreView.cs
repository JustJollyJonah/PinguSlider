using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace CScherp_Game.Views
{
    public class TimerScoreView : View
    {
        public Stopwatch stopwatch  { get; }
        public long lastTime;

        public TimerScoreView() : base()
        {
            // initializing stopwatch
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }


        // update the timer in Update function
        public override void Update(Model model, long dt)
        {
            Game game = (Game)model;
            Graphics g = game.Window.Graphics;
            
            long time = stopwatch.ElapsedMilliseconds;
            long diff = time - lastTime;
            lastTime = time / 1000;
            //Console.WriteLine(lastTime);

            game.Window.label13.Text = "Time: " + lastTime + "s";

        }
        // Pause the timer 
        public void PauseTime()
        {
            stopwatch.Stop();
        }

        // Resume the timer
        public void ResumeTime()
        {
            stopwatch.Start();
        }

    }
}


    
