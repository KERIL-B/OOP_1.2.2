using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowd_Console
{
    class Cell
    {
        public int i;
        public int j;

        public bool haveDoor;
        public bool isEmpty;

        public Cell(int i, int j)
        {
            this.i = i;
            this.j = j;

            if ((j == 0) && (i % 5 == 0))
            {
                haveDoor = true;
                Console.WriteLine("Door in cell({0}, {1})", i, j);
            }
            else
                haveDoor = false;

            isEmpty = true;
        }
    }
}
