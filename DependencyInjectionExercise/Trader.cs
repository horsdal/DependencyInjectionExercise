namespace DependencyInjectionExercise
{
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
}