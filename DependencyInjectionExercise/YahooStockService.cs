namespace DependencyInjectionExercise
{
  using System.Net;

  public class YahooStockService : StockService
  {
    private readonly string serviceUriFormat;

    public YahooStockService(string serviceUriFormat)
    {
      this.serviceUriFormat = serviceUriFormat;
    }

    public decimal CurrentPriceOf(string symbol)
    {
      var webClient = new WebClient();
      var quote = webClient.DownloadString(string.Format(serviceUriFormat, symbol));
        return decimal.Parse(quote);
    }

    public void Buy(string symbol, int amount)
    {
      // do stuff with real implications ... :)
    }
  }
}