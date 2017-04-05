using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowd_Console
{
    class Person
    {
        int i;
        int j;

        public int id;

        public Cell cell;

        public int I
        {
            get { return i; }
            set
            {
                i = value;
            }
        }

        public int J
        {
            get { return j; }
            set
            {
                j = value;
            }
        }

        public Person(Cell cell, int id)
        {
            this.cell = cell;
            this.i = cell.i;
            this.j = cell.j;
            this.id = id;
        }
    }
}
