using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CScherp_Game.Views
{
    class DataView : View
    {
        public Stopwatch Stopwatch { get; }
        private Window window;
        public DataView(Window window) : base()
        {
            this.window = window;
        }
        public override void Update(Model m, long dt)
        {
            Game game = (Game)m;
            Graphics g = game.Window.Graphics;
            Level level = game.Level;
            //EntityPlayer
            
            
            foreach (Entity e in level.Entities)
            {
                if (e.GetType() == typeof(EntityPlayer)) //Checkt Type van Object uit de Lijst
                { //Past de text van de labels op de Window aan met de Data van het object
                    window.label1.Text = "Pos X: " + Math.Round(e.Position.X, 2);
                    window.label2.Text = "Pos Y: " + Math.Round(e.Position.Y, 2);
                    window.label3.Text = "vX: " + Math.Round(e.Speed.X, 2);
                    window.label4.Text = "vY " + Math.Round(e.Speed.Y, 2);
                } 
                 else if (e.GetType() == typeof(EntityObstacleStatic))
                { 
                    window.label5.Text = "Pos X: " + Math.Round(e.Position.X, 2);
                    window.label6.Text = "Pos Y: " + Math.Round(e.Position.Y, 2);
                    window.label7.Text = "vX: " + Math.Round(e.Speed.X, 2);
                    window.label8.Text = "vY " + Math.Round(e.Speed.Y, 2);
                }
                else if (e.GetType() == typeof(EntityObstacleMoving)) {
                    window.label9.Text = "Pos X: " + Math.Round(e.Position.X, 2);
                    window.label10.Text = "Pos Y: " + Math.Round(e.Position.Y, 2);
                    window.label11.Text = "vX: " + Math.Round(e.Speed.X, 2);
                    window.label12.Text = "vY " + Math.Round(e.Speed.Y, 2);
                }
            }
        }
    }
}
