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
        /// the  playground is getting made.
        /// </summary>
        private void createNewMaze()
        {
            mazeTiles = new PictureBox[XTILES, YTILES];
            //Loop for getting all tiles
            int offsetx = 13;
            int offsety = 45;
            for (int i = 0; i < XTILES; i++)
            {
                for (int j = 0; j < YTILES; j++)
                {
                    //initialize a new PictureBox array at cordinate XTILES, YTILES
                    mazeTiles[i, j] = new PictureBox();
                    //calculate size and location
                    int xPosition = (i * TILESIZE) + offsetx; // padding from left
                    int yPosition = (j * TILESIZE) + offsety; // padding from top
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
            //mazeTiles[4, 23].BackColor = Color.Black; // where 4 is Xposition and 23 is Y position
        }

        /// <summary>
        /// The place where you can pick the color white for the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void White_Click(object sender, EventArgs e)
        {
            currentcolor = Color.White;
        }

        /// <summary>
        /// the place where you can pick the color black for the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Black_Click(object sender, EventArgs e)
        {
            currentcolor = Color.Black;
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
        /// Solve_click activates the event breath first algorithm which solves the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Solve_Click(object sender, EventArgs e)
        {                     
            Node first = new Node(0, 0, null);
            Queue<Node> searchqueue = new Queue<Node>();
            bool[,] alreadySearched = new bool[XTILES, YTILES];
            searchqueue.Enqueue(first);
            while (searchqueue.Any())
            {
                Node current = searchqueue.Dequeue();               
                if (current.xPos == XTILES -1 && current.yPos == YTILES -1)
                {
                    current = current.previous;
                    while (current.previous != null)
		            {                                                                       
                        mazeTiles[current.xPos, current.yPos].BackColor = Color.Red;
                        current = current.previous;
                    }
                    return; // returns the way of the maze.
                }
                              
                if (current.xPos != XTILES - 1 && mazeTiles[current.xPos + 1, current.yPos].BackColor != Color.Black && !alreadySearched[current.xPos + 1, current.yPos]) // checks right position
                {                    
                    Node next = new Node(current.xPos + 1, current.yPos, current);
                    alreadySearched[next.xPos, next.yPos] = true;
                    searchqueue.Enqueue(next);
                }
                if (current.yPos != YTILES - 1 && mazeTiles[current.xPos, current.yPos + 1].BackColor != Color.Black && !alreadySearched[current.xPos, current.yPos + 1]) // checks bottom position
                {                   
                    Node next = new Node(current.xPos, current.yPos + 1, current);
                    alreadySearched[next.xPos, next.yPos] = true;
                    searchqueue.Enqueue(next);
                }
                if (current.xPos > 0 && mazeTiles[current.xPos - 1, current.yPos].BackColor != Color.Black && !alreadySearched[current.xPos - 1, current.yPos]) // checks left position
                {                   
                    Node next = new Node(current.xPos - 1, current.yPos, current);
                    alreadySearched[next.xPos, next.yPos] = true;
                    searchqueue.Enqueue(next);
                }
                if (current.yPos > 0 && mazeTiles[current.xPos, current.yPos - 1].BackColor != Color.Black && !alreadySearched[current.xPos, current.yPos - 1]) // checks top position
                {                    
                    Node next = new Node(current.xPos, current.yPos - 1, current);
                    alreadySearched[next.xPos, next.yPos] = true;
                    searchqueue.Enqueue(next);
                }        
            }
            // if maze cannot be solved.
            MessageBox.Show("No solution is found ;(");         
        }
        /// <summary>
        /// Removes the color which was left after using button1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Click(object sender, EventArgs e)
        {
            //Change all gray and red tiles to white
            for (int i = 0; i < XTILES; i++)
            {
                for (int j = 0; j < YTILES; j++)
                {
                    Color[] clean = { Color.Gray, Color.Red };
                    if (clean.Contains(mazeTiles[i, j].BackColor))
                        mazeTiles[i, j].BackColor = Color.White;
                }
            }

            //Reset start and finish to light blue
            mazeTiles[0, 0].BackColor = Color.LightBlue;
            mazeTiles[XTILES - 1, YTILES - 1].BackColor = Color.LightBlue;
        }
    }
}
