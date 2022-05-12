using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockWorkITTestV1
{
    internal class Item // holds info about specific items on the stockfile
    {
        private int Id;
        private string Name;
        private float Price;
        private int NumberInStock;
        public void init(int MyID, string MyName, float MyPrice, int MyStock)
        {
            Id = MyID;
            Name = MyName;
            Price = MyPrice;
            NumberInStock = MyStock;
            //Console.WriteLine(MyName + " Initialised");
        }
        public float GetPrice()
        {
            return Price;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetID()
        {
            return Id;
        }
        public int GetStock()
        {
            return NumberInStock;
        }
        public bool ChangeStock(int change)
        ///Adjusts the stock levels whenever a basket is put through
        {
            if (NumberInStock + change >= 0)//making sure you can't sell imaginary stock
            {
                NumberInStock += change;
                //Console.WriteLine("Current " + Name + " left in stock: " + NumberInStock);
                return true;
            }
            else
            {
                Console.WriteLine("Not Possible with current stock");
                return false;
            }
        }
    }
}
