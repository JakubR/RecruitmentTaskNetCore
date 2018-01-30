namespace SIENN.Services
{
    public class CategorySummary
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal AveragePrice { get; set; }
        public int AvailableProductsCount { get; set; }
    }
}