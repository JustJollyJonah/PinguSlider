using CScherp_Game.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CScherp_Game
{
    public partial class    Window : Form
    {
        private Game Game;
        
        public int GameWidth { get; }
        public int GameHeight { get; }

        private BufferedGraphicsContext bufferContext;
        private BufferedGraphics bufferGraphics;
        private Graphics panelGraphics;

        public Graphics Graphics { get; private set; }

        public Window(Game game)
        {
            this.Game = game;

            InitializeComponent();

            // Give the game panel borders
            PanelGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // ..and THEN find out the resolution
            GameWidth = PanelGame.ClientSize.Width - 2;
            GameHeight = PanelGame.ClientSize.Height - 2;

            Console.WriteLine("{0} {1} {2} {3}", GameWidth, GameHeight, PanelGame.Width, PanelGame.Height);

            // Create buffered graphics
            bufferContext = BufferedGraphicsManager.Current;
            bufferGraphics = bufferContext.Allocate(PanelGame.CreateGraphics(),
                new System.Drawing.Rectangle(0, 0, GameWidth, GameHeight));

            // Get a Graphics object
            this.Graphics = bufferGraphics.Graphics;
            this.panelGraphics = this.PanelGame.CreateGraphics();
         
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game.Update();

            // Draw the buffered image onto the real Graphics object
            bufferGraphics.Render(this.panelGraphics);
        }

        // Shortcut keybind to 'P' for pausing and unpausing
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    if (CBDebugView.Checked)
                    {
                        PopupLose lose = new PopupLose(this.Game);
                        lose.ShowDialog();
                    }
                    return true;
                case Keys.F2:
                    if (CBDebugView.Checked)
                    {
                        PopupWin win = new PopupWin(this.Game);
                        win.ShowDialog();
                    }
                    return true;
                case Keys.F3:
                    if (CBDebugView.Checked)
                        Game.Reset();
                    return true;
                case Keys.P:
                    pauseButton.PerformClick();
                    return base.ProcessCmdKey(ref msg, keyData);
                case Keys.N:
                    if (CBDebugView.Checked)
                        this.Game.Level.Update(0);
                    return true;
                default:
                    return true;                   
            }
        }


        // Pauses game when pause button clicked and changes to play button
        // When play button clicked game continues and button changes to pause button 
        public void Pause_Click(object sender, EventArgs e)
        {
            if (Game.gamePaused == true)
            {
                Game.UnpauseGame();
                pauseButton.BackgroundImage = Properties.Resources.pause;
                Game.gamePaused = false;
            } else {
                Game.PauseGame();
                pauseButton.BackgroundImage = Properties.Resources.play;
                Game.gamePaused = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void buttonUp_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonUp = true;
        }

        private void buttonUp_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonUp = false;
        }

        private void buttonLeft_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonLeft = true;
        }

        private void buttonLeft_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonLeft = false;
        }

        private void buttonDown_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonDown = true;
        }

        private void buttonDown_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonDown = false;
            
        }

        private void buttonRight_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonRight = true;
        }

        private void buttonRight_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Game.Level.Player.mouseButtonRight = false;
        }

        private void CBDebugView_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDebugView.Checked == true) // Enable Debug view
                Game.AddView(new DebugView());
            else // Disable Debug view
            {
                var views =
                    from view in Game.views
                    where !(view is DebugView)
                    select view;
                Game.views = views.ToList();
            }
        }

        private void CBFPSView_CheckedChanged(object sender, EventArgs e)
        {
            if (CBFPSView.Checked == true) // Enable FPS view
                Game.fpsView.Enabled = true;
            else // Disable FPS view
                Game.fpsView.Enabled = false;
        }

        private void Window_Load(object sender, EventArgs e)
        {

        }
    }
}
