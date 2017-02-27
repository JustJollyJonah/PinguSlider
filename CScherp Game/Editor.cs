using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CScherp_Game
{
    public partial class Editor : Form
    {
        private int mouseX = 0;
        private int mouseY = 0;
        int playerCount = 0;
        private BufferedGraphicsContext bufferContext;
        private BufferedGraphics bufferGraphics;
        private Graphics panelGraphics;
        private List<Entity> chosenEntities;
        private Entity selectedEntity { get; set; }
        private Rectangle cursorRect { get; set; }
        private Game game;

        public Editor(Game game)
        {
            this.game = game;
            InitializeComponent();
            chosenEntities = new List<Entity>();
            panelEditor.Size = new Size(567, 310);
            bufferContext = BufferedGraphicsManager.Current;
            this.panelGraphics = panelEditor.CreateGraphics();
            this.bufferGraphics = bufferContext.Allocate(this.CreateGraphics(), new System.Drawing.Rectangle(0, 0, panelEditor.Width, panelEditor.Height));
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            //Delay for rendering
            timer1.Start();

            //Adds raw entities to combobox
            entityListEditor.Items.Add(new EntityFinish(0, 0));
            entityListEditor.Items.Add(new EntityPlayer(50, 50));
            entityListEditor.Items.Add(new EntityObstacleMoving(75, 75));
            entityListEditor.Items.Add(new EntityObstacleStatic(80, 80));
            entityListEditor.SelectedIndex = 1;
        }

        private void panelEditor_MouseMove(object sender, MouseEventArgs e)
        {
            //Sets mousevariable to current mouse position
            mouseX = e.X;
            mouseY = e.Y;
            xEntityEditor.Text = mouseX.ToString();
            yEntityEditor.Text = mouseY.ToString();
        }

        private void entityListEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Puts information of an entity to screen
            var entity = (Entity)entityListEditor.SelectedItem;
            messageTextEditor.Text = "No message";
            selectedEntity = entity;
            nameEntity.Text = entity.ToString();
            xEntityEditor.Text = entity.X1.ToString();
            yEntityEditor.Text = entity.Y1.ToString();
            directionInputEntityEditor.ReadOnly = true;
            directionInputEntityEditor.Text = "";
            spritePreviewEditor.Image = entity.GetBitmap();

            if (entity.ToString() == "EntityObstacleMoving")
                directionInputEntityEditor.ReadOnly = false;
        }

        private void cancelButtonEditor_Click(object sender, EventArgs e)
        {
            //Return to main menu
            this.Hide();
            
            game.menu.Closed += (s, args) => this.Close();
            game.menu.Show();
        }

        private void saveButtonEditor_Click(object sender, EventArgs e)
        {
            EdtitorSaveXmlParser.ParseToXmlAndSave(chosenEntities);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //Checks of rectangle entity doesn't cross any border
            cursorRect = selectedEntity.AtPosition(new Vector(mouseX, mouseY));
            bool left = cursorRect.X1 < 0;
            bool top = cursorRect.Y1 < 0;
            bool right = cursorRect.X2 >= this.panelEditor.Width;
            bool bottom = cursorRect.Y2 >= this.panelEditor.Height;

            if (right)
                cursorRect.X2 = this.panelEditor.Width - 1;
            if (bottom)
                cursorRect.Y2 = this.panelEditor.Height - 1;
            //Draw selectedentity by mousepointer
            this.bufferGraphics.Graphics.DrawImage(selectedEntity.GetBitmap(), (float)cursorRect.X1, (float)cursorRect.Y1);

            //Draw Choosen entities on screen
            for (int i = 0; i < chosenEntities.Count; i++)
            {
                bufferGraphics.Graphics.DrawImage(chosenEntities[i].GetBitmap(), new Point((int)chosenEntities[i].X1, (int)chosenEntities[i].Y1));
            }

            //Render 
            bufferGraphics.Render(this.panelGraphics);

            //Clear screen
            bufferGraphics.Graphics.Clear(Color.Cyan);

        }

        private void panelEditor_MouseDown(object sender, MouseEventArgs e)
        {
            //Checks of new entity is overlapping an other entity
            bool crossCheck = false;
            foreach (Entity entity in chosenEntities)
            {
                if (cursorRect.Intersects(entity))
                    crossCheck = true;
            }
            //When cursor intersects with a choosen entity
            if (crossCheck)
            {
                //When left mousebutton was pressed
                if (e.Button == MouseButtons.Left)
                    messageTextEditor.Text = "Entity error";
                //When right mousebutton was pressed, delete entity from list
                else if (e.Button == MouseButtons.Right)
                {
                    chosenEntities = DeleteEntityFromChoosenList(cursorRect, chosenEntities);
                }
            }
            else
            {
                //When there isn't an intersection, add new entity to list
                messageTextEditor.Text = "Entity is added";
                String directionString = directionInputEntityEditor.Text;

                if (playerCount == 1 && selectedEntity.ToString() == "EntityPlayer")
                    messageTextEditor.Text = "There is already\n a player \nentity";            

                selectedEntity.X1 = mouseX;
                selectedEntity.Y1 = mouseY;

                if (directionString == "0" || directionString == "1")
                    AddEntity(selectedEntity, ref chosenEntities, cursorRect, ref playerCount, directionString);
                else
                    AddEntity(selectedEntity, ref chosenEntities, cursorRect, ref playerCount);
            }
        }

        public void AddEntity(Entity selectEntity, ref List<Entity> listWithChoosenEntities, Rectangle cursorRect, ref int Count)
        {
            //Checks selected entity type
            switch (selectEntity.ToString())
            {
                case "EntityFinish":
                    listWithChoosenEntities.Add(new EntityFinish(cursorRect.X1, cursorRect.Y1));
                    break;
                case "EntityPlayer":
                    if (Count != 1)
                    {
                        Count = 1;
                        listWithChoosenEntities.Add(new EntityPlayer(cursorRect.X1, cursorRect.Y1));
                    }
                    break;
                case "EntityObstacleMoving":
                    listWithChoosenEntities.Add(new EntityObstacleMoving(cursorRect.X1, cursorRect.Y1, 0, 0));
                    break;
                case "EntityObstacleStatic":
                    listWithChoosenEntities.Add(new EntityObstacleStatic(cursorRect.X1, cursorRect.Y1));
                    break;
                default:
                    break;
            }
        }

        public void AddEntity(Entity selectEntity, ref List<Entity> listWithChoosenEntities, Rectangle cursorRect, ref int Count, String direction)
        {
            if (direction == "0")
                listWithChoosenEntities.Add(new EntityObstacleMoving(cursorRect.X1, cursorRect.Y1, 2, 0));
            else if (direction == "1")
                listWithChoosenEntities.Add(new EntityObstacleMoving(cursorRect.X1, cursorRect.Y1, 0, 2));
        }
        public List<Entity> DeleteEntityFromChoosenList(Rectangle cursorRectangle, List<Entity> listWithChoosenEntities)
        {
            for (int i = 0; i < listWithChoosenEntities.Count; i++)
            {
                if (cursorRectangle.Intersects(listWithChoosenEntities[i]))
                {
                    if (listWithChoosenEntities[i].ToString() == "EntityPlayer")
                        playerCount = 0;
                    listWithChoosenEntities.RemoveAt(i);
                }
            }
            return listWithChoosenEntities;
        }
    }
}
