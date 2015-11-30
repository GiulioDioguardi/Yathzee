using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1Cs
{
    public delegate int Transformer (int i);
    class Delegate
    {
        public static void Transform (int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
          
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            var values = new int[] { 2, 3, 4 };
            Transformer t = Double;
            t += Square;
            Delegate.Transform(values, t);
            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }
        public static int Double(int x) { return 2 * x; }
        public static int Square(int x) { return x * x; }
    }
}
