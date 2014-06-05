namespace DependencyInjectionExercise
{
  using System;

  class Program
  {
    private static Trader trader;

    static void Main(string[] args)
    {
      ComposeApplication();

      Console.WriteLine("Enter ticker symbol (e.g. msft or aapl): ");
      var symbol = Console.ReadLine();
      Console.WriteLine("Enter max price: ");
      var limit = decimal.Parse(Console.ReadLine());
      Console.WriteLine("Enter number of stocks to buy: ");
      var amount = int.Parse(Console.ReadLine());

      decimal currentPrice;
      if (trader.Buy(symbol, limit, amount, out currentPrice))
        Console.WriteLine("Bought {0} at {1}", symbol, currentPrice);
      else
        Console.WriteLine("Didn't buy {0} because current price is {1}", symbol, currentPrice);

      Console.ReadLine();
    }

    private static void ComposeApplication()
    {
      trader = new Trader(new YahooStockService("http://finance.yahoo.com/d/quotes?s={0}&f=b"));
    }
  }
}
