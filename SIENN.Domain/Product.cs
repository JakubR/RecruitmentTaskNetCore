using System;
using System.Collections.Generic;

namespace SIENN.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ICollection<ProductCategory> Categries { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
    }
}