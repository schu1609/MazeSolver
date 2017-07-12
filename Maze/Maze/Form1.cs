using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    /// <summary>
    /// the Class where the maze is created by you and where you decide big you want it to be.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The variables that stores the path color, amount of tiles, tile sizes and the drawing object mazetiles.
        /// </summary>
        Color currentcolor = Color.White;
        private static int XTILES = 25; //Number of X tiles
        private static int YTILES = 25; //Number of Y tiles
        private int TILESIZE = 10; //Size of the tiles (pixles)
        private static bool active = false;
        private static PictureBox[,] mazeTiles;
        /// <summary>
        /// The constructer which starts the components which are needed for the maze.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            createNewMaze();
            Maze();
        }
        /// <summary>
        /// The place where you can pick the color white for the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentcolor = Color.White;
        }
        /// <summary>
        /// the place where you can pick the color black for the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            currentcolor = Color.Black;
        }
        /// <summary>
        /// the  playground is getting made.
        /// </summary>
        private void createNewMaze()
        {
            mazeTiles = new PictureBox[XTILES, YTILES];
            //Loop for getting all tiles
            for (int i = 0; i < XTILES; i++)
            {
                for (int j = 0; j < YTILES; j++)
                {
                    //initialize a new PictureBox array at cordinate XTILES, YTILES
                    mazeTiles[i, j] = new PictureBox();
                    //calculate size and location
                    int xPosition = (i * TILESIZE) + 13; //13 is padding from left
                    int yPosition = (j * TILESIZE) + 45; //45 is padding from top
                    mazeTiles[i, j].SetBounds(xPosition, yPosition, TILESIZE, TILESIZE);
                    //make top left and right bottom corner light blue. Used for start and finish
                    if ((i == 0 && j == 0) || (i == XTILES - 1 && j == YTILES - 1))
                        mazeTiles[i, j].BackColor = Color.LightBlue;
                    else
                    {
                        //make all other tiles white
                        mazeTiles[i, j].BackColor = Color.White;
                        //make it clickable
                        EventHandler clickEvent = new EventHandler(PictureBox_Click);
                        mazeTiles[i, j].Click += clickEvent; // += used in case other events are used
                    }
                    //Add to controls to form (display picture box)
                    this.Controls.Add(mazeTiles[i, j]);
                }
            }
        }
        /// <summary>
        /// picturebox are the maze tiles which you can change into the color you have chosen from picturebox2 and picturebox1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = currentcolor;
        }
        /// <summary>
        /// button1 activates the event of the Node class which solves the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button1_Click(object sender, EventArgs e)
        {
            //Create a previously searched array
            active = true;
            bool[,] alreadySearched = new bool[XTILES, YTILES];

            Node first = new Node(0, 0, new List<Node>());
            first.run();
        }
        /// <summary>
        /// Removes the color which was left after using button1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Change all greay tiles to white
            for (int i = 0; i < XTILES; i++)
            {
                for (int j = 0; j < YTILES; j++)
                {
                    Color[] clean = { Color.Gray, Color.Blue, Color.Red };
                    if (clean.Contains(mazeTiles[i, j].BackColor))
                        mazeTiles[i, j].BackColor = Color.White;
                }
            }

            //Reset start and finish to light blue
            mazeTiles[0, 0].BackColor = Color.LightBlue;
            mazeTiles[XTILES - 1, YTILES - 1].BackColor = Color.LightBlue;
        }
        /// <summary>
        /// method which creates the maze in code.
        /// </summary>
        public void Maze()
        {
            for (int i = 0; i < XTILES; i++)
            {
                for (int j = 0; j < YTILES; j++)
                {
                    if (mazeTiles[i, j].BackColor == Color.Black)
                        mazeTiles[i, j].BackColor = Color.White;
                }
            }
            //mazeTiles[4, 23].BackColor = Color.Black;
        }
        /// <summary>
        /// node class that solves the maze in a breadthfirst algorithm way.
        /// </summary>
        public class Node
        {
            private List<Node> path;
            private int xPos;
            private int yPos;

            public Node(int x, int y, List<Node>p)
            {
                xPos = x;
                yPos = y;
                path = p;
                p.Add(this);
            }

            public void run()
            {
                if (active)
                {
                    mazeTiles[xPos, yPos].BackColor = Color.Blue;
                    if (xPos == XTILES-1 && yPos == YTILES-1)
                    {
                        end();
                    }
                    right();
                    bottom();                   
                    left();
                    top();
                }
            }
            
            private void right()
            {
                if (xPos != XTILES -1)
                {
                    if (!(path.Exists(r => r.xPos == this.xPos + 1) &&
                        path.Exists(r => r.yPos == this.yPos)) &&
                        mazeTiles[xPos + 1, yPos].BackColor != Color.Black)
                    {
                        Node neue = new Node(xPos + 1, yPos, path);
                        neue.run();
                    }
                }
            }
            private void bottom() {
                if (yPos != YTILES -1)
                {
                    if (!(path.Exists(r => r.xPos == this.xPos) &&
                        path.Exists(r => r.yPos == this.yPos + 1)) &&
                        mazeTiles[xPos, yPos + 1].BackColor != Color.Black)
                    {
                        Node neue = new Node(xPos, yPos + 1, path);
                        neue.run();
                    }
                }
            }
            private void left() {
                if (xPos != 0)
                {
                    if (!(path.Exists(r => r.xPos == this.xPos - 1) &&
                        path.Exists(r => r.yPos == this.yPos)) &&
                        mazeTiles[xPos - 1, yPos].BackColor != Color.Black)
                    {
                        Node neue = new Node(xPos - 1, yPos, path);
                        neue.run();
                    }
                }
            }
            private void top() {
                if (yPos != 0)
                {
                    if (!(path.Exists(r => r.xPos == this.xPos) &&
                        path.Exists(r => r.yPos == this.yPos - 1)) &&
                        mazeTiles[xPos, yPos - 1].BackColor != Color.Black)
                    {
                        Node neue = new Node(xPos, yPos - 1, path);
                        neue.run();
                    }
                }
            }
            private void end()
            {
                active = false;
                foreach (Node z in path)
                {
                    mazeTiles[z.xPos, z.yPos].BackColor = Color.Red;
                }
            }            
        }
    }
}
