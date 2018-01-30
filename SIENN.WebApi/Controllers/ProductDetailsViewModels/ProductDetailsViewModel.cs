namespace SIENN.WebApi.Controllers.ProductDetailsViewModels
{
    public class ProductDetailsViewModel
    {
        public string ProductDescription { get; set; }
        public string Price { get; set; }
        /// <summary>
        /// Available values : Yes, No
        /// </summary>
        public string IsAvailable { get; set; }
        public string DeliveryDate { get; set; }
        public int CategoriesCount { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }
}