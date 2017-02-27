using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CScherp_Game
{
    
    public partial class MainMenu : Form
    {
        
        
        
        // Embedded Font for labels
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
private Game gameLocal;        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myHeaderFont;
        Font myTextFont;

        public string SelectedLevelPath = CScherp_Game.Properties.Resources.level1;

        public MainMenu(Game game)
        {
            InitializeComponent();
            this.gameLocal = game;
            // initializing Font
            byte[] fontData = Properties.Resources.IceCaps;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IceCaps.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IceCaps.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myHeaderFont = new Font(fonts.Families[0], 58F);
            myTextFont = new Font(fonts.Families[0], 32F);

            // Assign event for window closing
            Closing += new CancelEventHandler(MainMenu_Closing);

            // Assign hover events for Label2
            label2.MouseEnter += new EventHandler(Label2_OnMouseEnter);
            label2.MouseLeave += new EventHandler(Label2_OnMouseLeave);

            // Assing hover events for Label3
            LLevelSelect.MouseEnter += new EventHandler(Label3_OnMouseEnter);
            LLevelSelect.MouseLeave += new EventHandler(Label3_OnMouseLeave);

            // Assign hover events for Label4
            label4.MouseEnter += new EventHandler(Label4_OnMouseEnter);
            label4.MouseLeave += new EventHandler(Label4_OnMouseLeave);

        }

        // Starts new game when start label clicked
        // Hides mainmenu
        private void StartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            gameLocal.Reset();
            gameLocal.Window.Closed += (s, args) => this.Close();
            gameLocal.Start();
        }

        // Load Fonts
        private void MainMenu_Load(object sender, EventArgs e)
        {
            label1.Font = myHeaderFont;
            label2.Font = myTextFont;
            LLevelSelect.Font = myTextFont;
            label4.Font = myTextFont;
        }

        // Event for Main menu close
        private void MainMenu_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        // Hover events for Label2
        private void Label2_OnMouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Aqua;
        }

        private void Label2_OnMouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        // Hover events for Label3
        private void Label3_OnMouseEnter(object sender, EventArgs e)
        {
            LLevelSelect.ForeColor = Color.Aqua;
        }

        private void Label3_OnMouseLeave(object sender, EventArgs e)
        {
            LLevelSelect.ForeColor = Color.White;
        }

        // Hover events for Label4
        private void Label4_OnMouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Aqua;
        }

        private void Label4_OnMouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        //Activates Level Editor
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Editor editor = new Editor(this.gameLocal);
            editor.Closed += (s, args) => Application.Exit();
            editor.Show();
        }

        // Event for Level select click
        private void LLevelSelect_Click(object sender, EventArgs e)
        {
            // create OpenFileDialog
            OpenFileDialog LevelSelectDialog = new OpenFileDialog();

            LevelSelectDialog.Filter = "XML Files|*.xml";
            LevelSelectDialog.Title = "Select an XML File";

            if (LevelSelectDialog.ShowDialog() == DialogResult.OK) // processing result of dialog
            {
                string XMLPath = LevelSelectDialog.InitialDirectory + LevelSelectDialog.FileName;
                Console.WriteLine("Level " + XMLPath + " Selected!");

                SelectedLevelPath = XMLPath;
                gameLocal.SetLevel(SelectedLevelPath);
                // Start game als er een level geselecteerd is
                StartGame_Click(sender, e);

            }
            else Console.WriteLine("Level " + SelectedLevelPath + " Selected!");
        }
    }
}
