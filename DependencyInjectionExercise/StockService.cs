namespace DependencyInjectionExercise
{
  public interface StockService
  {
    decimal CurrentPriceOf(string symbol);
    void Buy(string symbol, int amount);
  }
}