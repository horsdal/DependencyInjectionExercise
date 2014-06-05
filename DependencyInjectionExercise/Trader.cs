namespace DependencyInjectionExercise
{
  public class Trader 
  {
    private readonly StockService stockService;

    public Trader(StockService stockService)
    {
      this.stockService = stockService;
    }

    public bool Buy(string symbol, decimal bid, int amount, out decimal currentPrice)
    {
      currentPrice = stockService.CurrentPriceOf(symbol);
      if (currentPrice <= bid)
        stockService.Buy(symbol, amount);
      return currentPrice < bid;
    }
  }
}