using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockWorkITTestV1
{
    internal class Basket
    {
        public int BasketId { get; set; }
        private float Sum;
        public List<Item> BasketList = new List<Item>();
        private Stock MyStock;
        private List<Item> MyStockList = new List<Item>();
        public void MakeBasket(Stock PassedStock)
        ///takes input from the user and converts it to a usable list format
        {
            Sum = 0;
            MyStock = PassedStock;
            MyStockList = MyStock.GetStockList();

            string userInput = string.Empty;
            string inputWord = string.Empty;
            Console.WriteLine("In Stock We Have " + MyStockList.Count() + " items : \n");
            for (int i = 0; i < MyStockList.Count; i++)
            {
                Console.WriteLine("ID: " + MyStockList[i].GetID() + " Name: " + MyStockList[i].GetName() + " Price: " + (String.Format("{0:c2}", MyStockList[i].GetPrice())) + " In Stock: " + MyStockList[i].GetStock());
            }
            Console.WriteLine("Please enter your basket in the format Item1 Item2 Item3 :");
            userInput = Console.ReadLine();
            userInput += " ";// so you can't accidentally miss the last item
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == 32)
                {
                    for (int j = 0; j < MyStockList.Count(); j++)
                    {
                        if (inputWord == MyStockList[j].GetName())
                        {
                            if (MyStockList[j].ChangeStock(-1))
                            {
                                //Console.WriteLine(MyStockList[j].GetName());
                                Console.WriteLine("Added " + inputWord + " to your basket. Stock remaining: " + MyStockList[j].GetStock());
                                BasketList.Add(MyStockList[j]);
                            }
                            inputWord = string.Empty;
                            break;
                        }
                    }
                    if (inputWord != string.Empty)
                    {
                        Console.WriteLine("Basket Contains unrecognised item: " + inputWord + ". Unrecognized item not added to basket.");
                        inputWord = string.Empty;
                    }
                }
                else
                {
                    inputWord += userInput[i];
                }
            }

        }
        public void UnitTestMakeBasket(Stock PassedStock, string debugInput)
        ///takes input from the user and converts it to a usable list format
        {
            Sum = 0;
            MyStock = PassedStock;
            MyStockList = MyStock.GetStockList();

            string userInput = string.Empty;
            string inputWord = string.Empty;
            Console.WriteLine("In Stock We Have " + MyStockList.Count() + " items : \n");
            for (int i = 0; i < MyStockList.Count; i++)
            {
                Console.WriteLine("ID: " + MyStockList[i].GetID() + " Name: " + MyStockList[i].GetName() + " Price: " + (String.Format("{0:c2}", MyStockList[i].GetPrice())) + " In Stock: " + MyStockList[i].GetStock());
            }
            Console.WriteLine("Please enter your basket in the format Item1 Item2 Item3 :");
            Console.WriteLine(debugInput);
            userInput = debugInput;
            userInput += " ";// so you can't accidentally miss the last item
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == 32)
                {
                    for (int j = 0; j < MyStockList.Count(); j++)
                    {
                        if (inputWord == MyStockList[j].GetName())
                        {
                            if (MyStockList[j].ChangeStock(-1))
                            {
                                //Console.WriteLine(MyStockList[j].GetName());
                                Console.WriteLine("Added " + inputWord + " to your basket. Stock remaining: " + MyStockList[j].GetStock());
                                BasketList.Add(MyStockList[j]);
                            }
                            inputWord = string.Empty;
                            break;
                        }
                    }
                    if (inputWord != string.Empty)
                    {
                        Console.WriteLine("Basket Contains unrecognised item: " + inputWord + ". Unrecognized item not added to basket.");
                        inputWord = string.Empty;
                    }
                }
                else
                {
                    inputWord += userInput[i];
                }
            }

        }
        public void SumUp()
        ///Just does the simple addition of the base prices of each selected item
        {
            try//additional logic so it doesn't crash if called on an empty basket
            {
                if (BasketList.Count() > 1)
                {
                    for (int i = 0; i < BasketList.Count(); i++)
                    {
                        Sum += BasketList[i].GetPrice();
                    }
                    Console.WriteLine("Your subtotal is: " + (String.Format("{0:c2}", Sum)));
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Sorry, your basket seems to be empty.");
            }

        }
        public void ApplyDiscounts()
        {
            List<Item> listForComparison = BasketList;
            float runningTotalDiscount;
            int reusableCounter;//so you don't have to remove references to obsolete variables when discounts change, stops bloat by wiping between discounts
            int reusableCounterTheSecond;

            //10% off apples
            runningTotalDiscount = 0;
            for (int i = 0; i < BasketList.Count(); i++)
            {
                if (BasketList[i].GetName() == "Apples")
                {
                    runningTotalDiscount += 0.1f;
                }
            }
            if (runningTotalDiscount > 0)
            {
                Console.WriteLine("Thanks to 10% off apples, you have saved: " + String.Format("{0:c2}", runningTotalDiscount));
                Sum -= runningTotalDiscount;
                Console.WriteLine("New total: " + (String.Format("{0:c2}", Sum)));
                runningTotalDiscount = 0;
            }

            //buy 2 soup get bread half price
            runningTotalDiscount = 0;
            reusableCounter = 0;
            reusableCounterTheSecond = 0;
            for (int i = 0; i < listForComparison.Count(); i++)
            {
                if (listForComparison[i].GetName() == "Soup")
                {
                    reusableCounter++;
                }
            }
            //Console.WriteLine(reusableCounter);
            for (int j = 0; j < listForComparison.Count(); j++)//ordered for loops makes sure the discount applies sequnetially no matter the order of the basket
            {
                if (reusableCounter >= 2)
                {
                    if (listForComparison[j].GetName() == "Bread")
                    {
                        runningTotalDiscount += (listForComparison[j].GetPrice() / 2);
                        reusableCounter -= 2;
                    }
                }
            }
            if (runningTotalDiscount > 0)
            {
                Console.WriteLine("Thanks to half off bread when you buy 2 tins of soup, you have saved: " + String.Format("{0:c2}", runningTotalDiscount));
                Sum -= runningTotalDiscount;
                Console.WriteLine("New total: " + (String.Format("{0:c2}", Sum)));
                runningTotalDiscount = 0;
            }
            Console.WriteLine("Final Total: " + String.Format("{0:c2}", Sum));
        }
    }
}
