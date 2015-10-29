using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1Cs
{
    struct Location
    {
        public int x;
        public int y;

        public Location(int x_ = 0, int y_ = 0)
        {
            this.x = x_;
            this.y = y_;
        }
    }

    public class Product
    {
        decimal currentPrice;

        public Product() { }
        public Product(decimal d) { currentPrice = d; }
        
        public decimal CurrentPrice
        {
            get
            {
                return this.currentPrice;
            }
            set
            {
                this.currentPrice = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product(6);
            Console.WriteLine(p.CurrentPrice);
            p.CurrentPrice -= 20;
            Console.WriteLine(p.CurrentPrice);
            p.CurrentPrice += 3;
            Console.WriteLine(p.CurrentPrice);
        }
    }
}
