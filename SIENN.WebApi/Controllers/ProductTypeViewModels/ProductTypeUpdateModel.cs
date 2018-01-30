using System;

namespace SIENN.WebApi.Controllers.ProductTypeViewModels
{
    public class ProductTypeUpdateModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Product type code maximum length 128 chars, can not be null
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Product type description maximum length 500 chars
        /// </summary>
        public String Description { get; set; }
    }
}