namespace DependencyInjectionExercise
{
  using System;
  using System.Net;

  class Program
  {
    static void Main(string[] args)
    {
      var trader = new Trader();

      Console.WriteLine("Enter ticker symbol (e.g. msft or appl): ");
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
    }
  }

  public class Trader 
  {
    private YahooStockService stockService =  new YahooStockService();

    public bool Buy(string symbol, decimal bid, int amount, out decimal currentPrice)
    {
      currentPrice = stockService.CurrentPriceOf(symbol);
      if (currentPrice <= bid)
        stockService.Buy(symbol, amount);
      return currentPrice < bid;
    }
  }

  public class YahooStockService
  {
    public const string YahooPath = "http://finance.yahoo.com/d/quotes.csv?s={0}&f=b";

    public decimal CurrentPriceOf(string symbol)
    {
      var webClient = new WebClient();
      var quote = webClient.DownloadString(string.Format(YahooPath, symbol));
      return decimal.Parse(quote);
    }

    public void Buy(string symbol, int amount)
    {
      // do stuff with real implications ... :)
    }
  }
}
