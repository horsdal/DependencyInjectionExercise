namespace DependencyInjectionExercise
{
  using System.Net;

  public class YahooStockService
  {
    public const string YahooPath = "http://finance.yahoo.com/d/quotes?s={0}&f=b";

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