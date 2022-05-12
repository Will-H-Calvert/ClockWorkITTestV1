using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockWorkITTestV1
{
    internal class Stock// holds info about the stock file as a whole
    {
        private List<Item> StockList = new List<Item>();//holds all of the items that are in stock 
        private int currentID = 0;// holds the current limit of the list
        private Item itemToAdd;
        public void AddStockItem(string MyName, float MyPrice, int MyStock)
        ///adds and initialises a new item to the stockfile with passed values
        {
            itemToAdd = new Item();
            itemToAdd.init(currentID, MyName, MyPrice, MyStock);
            currentID++;
            StockList.Add(itemToAdd);
            Console.WriteLine(StockList.Count() + " Items on the stock file.");
        }
        public void RemoveStockItem(int idToRemove)
        ///removes whatever stock item matches the passed ID
        {
            StockList.RemoveAt(idToRemove);
        }
        public List<Item> GetStockList()
        {
            return StockList;
        }
    }
}
