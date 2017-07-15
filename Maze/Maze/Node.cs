using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// node class that we use in the depth-first algorithm way.
    /// </summary>
    public class Node
    {
        public int xPos;
        public int yPos;
        public Node previous;
        //bool[,] alreadySearched = new bool[XTILES, YTILES];
        public Node(int x, int y, Node previous)
        {
            xPos = x;
            yPos = y;
            this.previous = previous;
        }
    }
}
