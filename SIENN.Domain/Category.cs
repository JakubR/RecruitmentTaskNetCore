using System;
using System.Collections.Generic;

namespace SIENN.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public String Description { get; set; }
        public List<ProductCategory> Products { get; set; }
    }
}