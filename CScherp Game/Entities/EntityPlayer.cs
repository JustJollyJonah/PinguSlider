using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CScherp_Game
{
    public class EntityPlayer : Entity
    {
        //Boolian for checking of button is pressed.
        public bool mouseButtonUp { get; set; }
        public bool mouseButtonLeft { get; set; }
        public bool mouseButtonRight { get; set; }
        public bool mouseButtonDown { get; set; }

        public EntityPlayer(double x, double y) : base(x, y) { }

        public override Bitmap GetBitmap()
        {
            if(this.Speed.X > 0)
            {
                return CScherp_Game.Properties.Resources.Cbeebies_pingu_img_pingu_slide_small;
            } else if (this.Speed.X < 0)
            {
                return CScherp_Game.Properties.Resources.Cbeebies_pingu_img_pingu_slide_LEFT;
            } else
            {
                return CScherp_Game.Properties.Resources.Cbeebies_pingu_img_pingu_slide_small;
            }
        }

        public override void Update(Level l, long dt)
        {
            //Checks if any button - mouse or keyboard is pressed
            bool down = Keyboard.IsKeyDown(Key.Down) || mouseButtonDown;
            bool up = Keyboard.IsKeyDown(Key.Up) || mouseButtonUp;
            bool right = Keyboard.IsKeyDown(Key.Right) || mouseButtonRight;
            bool left = Keyboard.IsKeyDown(Key.Left) || mouseButtonLeft;

            SetPlayerDirection(down, up, right, left);
        }

        public void SetPlayerDirection(bool down, bool up, bool right, bool left)
        {
            int vertical = up ? (down ? 0 : -2) : (down ? 2 : 0);
            int horizontal = left ? (right ? 0 : -2) : (right ? 2 : 0);

            if (vertical != 0)
                Speed = Speed.SetY(vertical);

            if (horizontal != 0)
                Speed = Speed.SetX(horizontal);

            if (vertical != 0 && horizontal != 0)
                Speed = Speed.Normalize() * 2;
        }

        public override void OnCollide(EntityCollisionEventArgs e)
        {
            base.OnCollide(e);

            // Check of we relevant zijn
            if (!e.Collision.IsRelevant(this))
                return;

            // Pak de andere entity
            Entity other = e.Collision.GetOther(this);

            // Is een schermpje al zichtbaar? Laat dan maar.
            if (e.Game.HasWon || e.Game.HasLost)
                return;

            // Toon het correcte schermpje!
            if (other is EntityObstacleMoving || other is EntityObstacleStatic)
            {
                e.Game.PauseGame();
                e.Game.timerScoreView.PauseTime();
                e.Game.HasLost = true;
            }
            else if (other is EntityFinish)
            {
                e.Game.PauseGame();
                e.Game.timerScoreView.PauseTime();
                e.Game.HasWon = true;
            }
            
        }

    }
}
