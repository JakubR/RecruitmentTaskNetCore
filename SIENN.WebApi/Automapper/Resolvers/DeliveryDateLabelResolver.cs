using AutoMapper;
using SIENN.Domain;
using SIENN.WebApi.Controllers.ProductDetailsViewModels;

namespace SIENN.WebApi.Automapper.Resolvers
{
    public class DeliveryDateLabelResolver : IValueResolver<Product, ProductDetailsViewModel, string>
    {
        public string Resolve(Product source, ProductDetailsViewModel destination, string destMember, ResolutionContext context)
        {
            if (source.DeliveryDate.HasValue)
            {
                return
                    $"{source.DeliveryDate.Value.Day}-{source.DeliveryDate.Value.Month}-{source.DeliveryDate.Value.Year}";
            }

            return string.Empty;
        }
    }
}