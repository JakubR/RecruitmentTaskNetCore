﻿namespace SIENN.Domain
{
    public class ProductCategory
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}