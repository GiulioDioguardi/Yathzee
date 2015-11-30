using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1Cs
{
    class Program
    {
        public abstract class Asset
        {
            string name;
            public string Name { get { return name; } set { name = value; } }
            public Asset(string name) { this.Name = name; }

            public override string ToString()
            {
                return "Name :" + Name;
            }
        }

        public class House : Asset
        {
            int numRooms;
            int mortgage;

            public int NumRooms { get { return numRooms; } set { numRooms = value; } }
            public int Mortgage { get { return mortgage; } set { mortgage = value; } }
            public House(string name, int mortgage)
                : base(name)
            {
                this.Mortgage = mortgage;
            }

            public House(string name, int mortgage, int numRooms)
                : this(name, mortgage)
            {
                this.NumRooms = numRooms;
            }

            public override string ToString()
            {
                return base.ToString() + "\tMortgage: $" + Mortgage + "\tNumber of rooms: " + NumRooms;
            }
        }

        public class Stock : Asset
        {
            private int currentPrice;

            public int CurrentPrice { get { return currentPrice; } set { currentPrice = value; } }
            public Stock(string name, int currentPrice)
                : base(name)
            {
                this.CurrentPrice = currentPrice;
            }

            public override string ToString()
            {
                return base.ToString() + "\tCurrent price: $" + CurrentPrice;
            }
        }
       /* static void Main(string[] args)
        {
            House a = new House("My house", 23000);
            Stock b = new Stock("FAQ", 23);
            Console.WriteLine(a);
            House c = new House("Another house", 25000, 2);
            Console.WriteLine(c);
            Console.WriteLine(b);
        }*/
    }
}
