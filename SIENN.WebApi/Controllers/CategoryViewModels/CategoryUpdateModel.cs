using System;

namespace SIENN.WebApi.Controllers.CategoryViewModels
{
    public class CategoryUpdateModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Category code maximum length 128 chars, can not be null
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Category description maximum length 500 chars
        /// </summary>
        public String Description { get; set; }
    }
}