
namespace ClockWorkITTestV1
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("compiles");
            Stock  TestStock  = new Stock();
            TestStock.AddStockItem("Soup", 0.65f, 99);
            TestStock.AddStockItem("Bread", 0.8f, 99);
            TestStock.AddStockItem("Milk", 1.30F, 99);
            TestStock.AddStockItem("Apples", 1f, 99);
            Basket TestBasket = new Basket();
            Console.WriteLine("Test For: soup and bread discount bread forward/multiple of same");
            TestBasket.UnitTestMakeBasket(TestStock, "Bread Bread Soup Soup Soup Soup");
            TestBasket.SumUp();
            TestBasket.ApplyDiscounts();
            TestBasket = new Basket();
            Console.WriteLine("Test For: out of stock/apples discount en masse");
            TestBasket.UnitTestMakeBasket(TestStock, "Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples Apples ");
            TestBasket.SumUp();
            TestBasket.ApplyDiscounts();
            (TestStock.GetStockList())[3].ChangeStock(99);//fixes the stock deficit as stock file is shared between tests
            TestBasket = new Basket();
            Console.WriteLine("Test For: soup and bread, bread backwards");
            TestBasket.UnitTestMakeBasket(TestStock, "Soup Soup Bread");
            TestBasket.SumUp();
            TestBasket.ApplyDiscounts();
            TestBasket = new Basket();
            Console.WriteLine("Test For: appples discount and soup and bread discount");
            TestBasket.UnitTestMakeBasket(TestStock, "Apples Soup Bread Soup");
            TestBasket.SumUp();
            TestBasket.ApplyDiscounts();
            TestBasket = new Basket();
            while (true)
            {
                TestBasket.MakeBasket(TestStock);
                TestBasket.SumUp();
                TestBasket.ApplyDiscounts();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }
    }
}
