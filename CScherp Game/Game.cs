using CScherp_Game.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CScherp_Game
{
    public class Game : Model
    {
        public Boolean gamePaused = false;
        public Level Level { get; private set; }
        public Window Window { get; private set; }
        public TimerScoreView timerScoreView;
        public FPSView fpsView;

        public bool HasWon { get; set; } = false;
        public bool HasLost { get; set; } = false; 
		private PopupWin win;
        private PopupLose lose;
        public MainMenu menu;

        public XmlParser xmlParser;
        public Stopwatch Stopwatch { get; }
        private long LastUpdate;
        public string SelectedLevelPath;

 
        public Game() : this(CScherp_Game.Properties.Resources.level1) { }
      

        public Game(string selectedLevelPath)
        {
            SelectedLevelPath = selectedLevelPath;
            menu = new MainMenu(this);
            xmlParser = new XmlParser(SelectedLevelPath, this);
            if (xmlParser.entities == null)
            {
                MessageBox.Show("Xml file failed to validate, check console for errors.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.ReadKey();
            }
            else
            {
                Window = new Window(this);
                Level = new Level(this, Window.GameWidth, Window.GameHeight, xmlParser.entities);
                Stopwatch = new Stopwatch();
                Stopwatch.Start();
                LastUpdate = Stopwatch.ElapsedMilliseconds;

                fpsView = new FPSView();
                timerScoreView = new TimerScoreView();

                this.AddView(new GameView());
                this.AddView(fpsView);
                this.AddView(timerScoreView);

                this.AddView(new DataView(this.Window));

                win = new PopupWin(this);
                lose = new PopupLose(this);
            }
        }
        public void Start()
        {
            Window.Show();
        }

        public void Stop()
        {
            Application.Exit();
        }

        public void Hide()
        {
            Window.Hide();
        }

        public void Reset()
        {
            xmlParser = new XmlParser(SelectedLevelPath, this);
            Level = new Level(this, Window.GameWidth, Window.GameHeight, xmlParser.entities);
            this.UnpauseGame();
            timerScoreView.stopwatch.Reset();
            timerScoreView.stopwatch.Start();

        }
        public void SetLevel(String level)
        {
            this.SelectedLevelPath = level;
        }

        public override void Update()
        {
            long now = Stopwatch.ElapsedMilliseconds;
            long diff = now ;
            LastUpdate = now;

            // Check of we window moeten tonen
            if (HasLost)
            {
                if (!lose.Visible)
                    lose.ShowDialog();
                HasLost = false;
            } else if (HasWon)
            {
                if (!win.Visible)
                    win.ShowDialog();
                HasWon = false;
            }

            // Model updaten (propageren naar Level object waar meeste logica plaatsvindt)
            if (!gamePaused)
            {
                Level.Update(diff);
            }
            // Alle Views van dit Model updaten
            base.UpdateViews(diff);
        }

        public void PauseGame()
        {
            timerScoreView.PauseTime();
            gamePaused = true;
        }
        public void UnpauseGame()
        {
            timerScoreView.ResumeTime();
            gamePaused = false;
        }
    }
}
