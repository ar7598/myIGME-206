using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontDiePart1
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Write code for an Adjacency Matrix and Adjacency List based on the digraph given in PE21
    // Restrictions: None
    class Program
    {
        // Adjacency Matrix
        // The letters written in the rows are the nodes at which the player is located
        // The letters written in the columns are the nodes at which the player may or may not travel
        // The positive numbers (including 0) in the matrix represent the cost it takes to move between the nodes
        // Positive numbers (including 0) also represent that it is possible to move from the currently located room (or node) to another room
        // Any negative number in the matrix (which will always be -1) represents that a move between those rooms is not possible
        // The second matrix written is in parallel with the first matrix
        // It will represent the directions that can be traversed from node to node
        // N = north, S =south, E = east, and W = west
        // null values are written to represent that movement between the two nodes is impossible
        static int[,] mwGraph = new int[,]
        {
                        /*A*/   /*B*/   /*C*/   /*D*/   /*E*/   /*F*/   /*G*/   /*H*/
            /*A*/   {     0,      2,     -1,     -1,     -1,     -1,     -1,     -1 },
            /*B*/   {    -1,     -1,      2,      3,     -1,     -1,     -1,     -1 },
            /*C*/   {    -1,      2,     -1,     -1,     -1,     -1,     -1,     20 },
            /*D*/   {    -1,      3,      5,     -1,      2,      4,     -1,     -1 },
            /*E*/   {    -1,     -1,     -1,     -1,     -1,      3,     -1,     -1 },
            /*F*/   {    -1,     -1,     -1,     -1,     -1,     -1,      1,     -1 },
            /*G*/   {    -1,     -1,     -1,     -1,      0,     -1,     -1,      2 },
            /*H*/   {    -1,     -1,     -1,     -1,     -1,     -1,     -1,     -1 } 
        };

        static string[,] mdGraph = new string[,]
        {
                        /*A*/   /*B*/   /*C*/   /*D*/   /*E*/   /*F*/   /*G*/   /*H*/
            /*A*/   {   "N,E",   "S",   null,   null,   null,   null,   null,   null },
            /*B*/   {   null,   null,    "S",    "E",   null,   null,   null,   null },
            /*C*/   {   null,    "N",   null,   null,   null,   null,   null,    "S" },
            /*D*/   {   null,    "W",    "S",   null,    "N",    "E",   null,   null },
            /*E*/   {   null,   null,   null,   null,   null,    "S",   null,   null },
            /*F*/   {   null,   null,   null,   null,   null,   null,    "E",   null },
            /*G*/   {   null,   null,   null,   null,    "N",   null,   null,    "S" },
            /*H*/   {   null,   null,   null,   null,   null,   null,   null,   null }
        };

        // Adjacency List
        // Written as 2 parallel lists
        // The first list will represent the rooms (or nodes) as well as what rooms can be traveled to from said rooms
        // The order of the lists will be North, South, East, and then West
        // A value of -1 means that travel is not possible through that direction
        // The rooms will be represented through numbers (A=0, B=1, C=2, D=3, E=4, F=5, G=6, and H=7)
        // The second list will represent the cost it takes to travel between the rooms
        // As the lists are parallel, the costs in the second list will correspond to the rooms that can be traveled to in the first list
        static int[][] lGraph = new int[][]
        {
            /*A*/ new int[] {0, 1, 0, -1},
            /*B*/ new int[] {-1, 2, 3, -1},
            /*C*/ new int[] {1, 7, -1, -1},
            /*D*/ new int[] {4, 2, 5, 1},
            /*E*/ new int[] {-1, 5, -1, -1},
            /*F*/ new int[] {-1, -1, 6, -1},
            /*G*/ new int[] {4, 7, -1, -1},
            /*H*/ null
        };

        static int[][] wGraph = new int[][]
        {
            /*A*/ new int[] {0, 2, 0, -1},
            /*B*/ new int[] {-1, 2, 3, -1},
            /*C*/ new int[] {2, 20, -1, -1},
            /*D*/ new int[] {2, 5, 4, 3},
            /*E*/ new int[] {-1, 3, -1, -1},
            /*F*/ new int[] {-1, -1, 1, -1},
            /*G*/ new int[] {0, 2, -1, -1},
            /*H*/ null
        };

        // Method: Main
        // Purpose: No code currently
        // Restrictions: No code currently
        static void Main(string[] args)
        {
        }
    }
}
