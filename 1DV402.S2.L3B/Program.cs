using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3B
{
    class Program
    {
        private static Random random = new Random();

        /// <summary>
        /// Anropar RandomizeShapes() för att slumpa figurer.
        /// Figurerna sorteras och presenteras sedan mha ViewShapes().
        /// Användaren kan sedan välja att genomföra nya beräkningar eller att avsluta genom att trycka Esc.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            do
            {
            Shape[] randomShapes = RandomizeShapes();

            Array.Sort(randomShapes);

            ViewShapes(randomShapes);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("");
            Console.WriteLine("Tryck valfri tangent för ny beräkning - Esc avslutar.\n");
            Console.ResetColor();
            Console.WriteLine();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Slumpar ett visst antal figurer samt dess längder och bredder i givna intervall.
        /// Referenserna till figurerna sparas i en array som metoden returnerar en referens till.
        /// </summary>
        /// <returns></returns>
        private static Shape[] RandomizeShapes()
        {
            int shapeTypeLength = Enum.GetValues(typeof(ShapeType)).Length;

            const int maxNumberOfShapes = 20;
            const int minNumberOfShapes = 5;

            const int maxMeasure = 100;
            const int minMeasure = 5;

            int numberOfShapes = random.Next(minNumberOfShapes, maxNumberOfShapes+1);
            
            Shape[] shapeArray = new Shape[numberOfShapes];

            for (int i = 0; i < numberOfShapes; i++)
            {
                Shape shape;
                switch ((ShapeType)random.Next(shapeTypeLength))
                {
                    case ShapeType.Ellipse:
                        shape = new Ellipse(random.NextDouble() * (maxMeasure - minMeasure) + minMeasure, 
                                            random.NextDouble() * (maxMeasure - minMeasure) + minMeasure);
                        break;
                    case ShapeType.Rectangle:
                        shape = new Rectangle(random.NextDouble() * (maxMeasure - minMeasure) + minMeasure, 
                                              random.NextDouble() * (maxMeasure - minMeasure) + minMeasure);
                        break;
                    default:
                        shape = null;
                        break;
                }
                shapeArray[i] = shape;
            }

            return shapeArray;
        }

        /// <summary>
        /// Presenterar figurerna som skickas till metoden i en enkel tabell som
        /// sorteras efter storleken på figurernas areor, mha ToString().
        /// </summary>
        /// <param name="shapes"></param>
        private static void ViewShapes(Shape[] shapes)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  ╔════════════════════════════════════════╗  ");
            Console.WriteLine("  ║          Geometriska figurer           ║  ");
            Console.WriteLine("  ╚════════════════════════════════════════╝  ");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Figur".PadRight(9) + 
                              "Längd".PadLeft(9) + 
                              "Bredd".PadLeft(9) + 
                              "Omkrets".PadLeft(10) + 
                              "Area".PadLeft(9));
            Console.WriteLine(new string('=', 46));

            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine(shapes[i].ToString());
            }
        }
    }
}
