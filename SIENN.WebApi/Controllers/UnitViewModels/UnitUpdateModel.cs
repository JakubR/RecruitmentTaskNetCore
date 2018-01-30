using System;

namespace SIENN.WebApi.Controllers.UnitViewModels
{
    public class UnitUpdateModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Unit code maximum length 128 chars, can not be null
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Unit description maximum length 500 chars
        /// </summary>
        public String Description { get; set; }
    }
}