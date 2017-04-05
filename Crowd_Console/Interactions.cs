using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Crowd_Console
{
    static class Interactions
    {
        static int widthSize;
        static int heightSize;
        static int peopleCount = 0;

        static Cell[,] cells;

        static Random rnd = new Random();

        static public void CreateGrid(int widthC, int heightC)
        {
            widthSize = widthC;
            heightSize = heightC;

            cells = new Cell[widthC, heightC];
            for (int i = 0; i < widthC; i++)
                for (int j = 0; j < heightC; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            Console.WriteLine("Matrix {0}x{1} created", widthC, heightC);
        }

        static public bool Add_Person()
        {

            int i = rnd.Next(widthSize);
            int j = rnd.Next(heightSize);

            if (cells[i, j].isEmpty)
            {
                Person currentPerson = new Person(cells[i, j], peopleCount++);
                cells[i, j].isEmpty = false;

                Console.WriteLine("Person-[{0}]: created ({1}, {2})", peopleCount, i, j);
                
                Thread thr = new Thread(()=>{
                    PathFinding(currentPerson);
                });
                thr.Start();

                return true;
            }
            else return false;
        }

        static private void PathFinding(Person currentPerson)
        {
            string direction;
            while (!IsExit(currentPerson))
            {
                direction = ChooseDirection(currentPerson);
                if (!((Move(currentPerson, "up") || (Move(currentPerson, direction)))))
                {
                    Thread.Sleep(100);
                }
            }
        }

        static private string ChooseDirection(Person currentPerson)
        {
            string tmpDirection;
            if (currentPerson.I % 5 != 0)
                if (currentPerson.I % 5 < 3)
                    tmpDirection = "left";
                else
                {
                    int needThatI = currentPerson.I + (5 - currentPerson.I % 5) + 1;
                    if (needThatI > cells.GetLength(0))
                        tmpDirection = "left";
                    else
                        tmpDirection = "right";
                }
            else tmpDirection = null;

            return tmpDirection;
        }

        static private bool IsExit(Person currentPerson)
        {
            if (currentPerson.cell.haveDoor)
            {
                currentPerson.cell.isEmpty = true;
                Console.WriteLine("Person[{0}]: exit", currentPerson.id);
                return true;
            }
            else return false;
        }

        static private bool Move(Person person, string direction)
        {
            int deltaI = 0;
            int deltaJ = 0;

            switch (direction)
            {
                case "up": deltaJ = -1;
                    break;
                case "left": deltaI = -1;
                    break;
                case "right": deltaI = 1;
                    break;

                default: return false;
            }

            int oldI = person.I;
            int oldJ = person.J;

            int newI = person.I + deltaI;
            int newJ = person.J + deltaJ;

            if ((newI >= 0) && (newJ >= 0) && (cells[newI, newJ].isEmpty))
            {
                person.cell = cells[newI, newJ];
                cells[person.I, person.J].isEmpty = true;
                person.I = newI;
                person.J = newJ;
                cells[person.I, person.J].isEmpty = false;

                Console.WriteLine("Person-[{0}]: moove ({1}, {2})->({3}, {4})", person.id, oldI, oldJ, newI, newJ);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
