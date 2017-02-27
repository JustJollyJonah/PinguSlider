using System;
using System.Media;
using System.Windows.Forms;
namespace CScherp_Game
{
    public partial class PopupLose : Form
    {
       
        private Game gameLocal;
        public PopupLose(Game game)
        {
            InitializeComponent();
            this.gameLocal = game;
           
        }

        private void PopupLose_Load(object sender, EventArgs e)
        {
            SoundPlayer nootnoot = new SoundPlayer(CScherp_Game.Properties.Resources.noot4);
            nootnoot.Play();
        }

        // When mainMenu button clicked, game and popup hide and mainMenu shows
        // When retry button clicked, game resets 
        private void LoseButton_Click(object sender, EventArgs e)
        {
            if (sender == mainMenu_button)
            {
                
                gameLocal.menu.Show();

                this.Close();
                gameLocal.Hide();
                
            } else if (sender == retry_button) {
                gameLocal.Reset();
                this.Close();
                
        }
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

    }
}
