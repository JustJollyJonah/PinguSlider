using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CScherp_Game
{
    public partial class PopupWin : Form
    {
        
        private Game game;
        public PopupWin(Game game)
        {
            InitializeComponent();
            
            this.game = game;
           
        }

        private void PopupWin_Shown(object sender, EventArgs e)
        {
            SoundPlayer noot7 = new SoundPlayer(CScherp_Game.Properties.Resources.noot7);
            noot7.Play();
            label2.Text = "Your time is " + (game.timerScoreView.stopwatch.ElapsedMilliseconds / 1000) + " seconds";
            
        }

        // When mainMenu button clicked, game and popup hide and mainMenu shows
        // When retry button clicked, game resets 
        private void button_Click(object sender, EventArgs e)
        {
            if (sender == retry_button)
            {
                //game.gamePaused = false;
                game.Reset();
                this.Close();
            }
            else if (sender == mainMenu_button)
            {
                game.menu.Show();

                this.Close();
                game.Hide();
            }
        }
    }
}
