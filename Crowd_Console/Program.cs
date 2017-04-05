using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowd_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================CROWD_consoleVersion_1=================");
            Console.WriteLine();
          
            #region GetInput
            Console.WriteLine("Enter matrix size");
            Console.Write("Width i -> ");

            int tmp;

            do
            {
                tmp = InputCheck(Console.ReadLine());
            } while (tmp == -1);
            
            int widthSize = tmp;

            Console.Write("Height j -> ");
            do
            {
                tmp = InputCheck(Console.ReadLine());
            } while (tmp == -1);

            int HeightSize = tmp;
            #endregion

            Console.WriteLine();
            Interactions.CreateGrid(widthSize,HeightSize);

            Console.WriteLine();
            int n;
            n = widthSize * HeightSize / 3;
            Console.WriteLine("Creating {0} people..", n);
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                while(!Interactions.Add_Person());
            }



                Console.ReadKey();

        }

        static private int InputCheck(string line)
        {
            try
            {
                int i = Convert.ToInt32(line);
                if (i > 0)
                    return i;
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
