using AutoMapper;
using SIENN.Domain;
using SIENN.WebApi.Controllers.ProductDetailsViewModels;

namespace SIENN.WebApi.Automapper.Resolvers
{
    public class AvailabiltyLabelResolver : IValueResolver<Product, ProductDetailsViewModel, string>
    {
        public string Resolve(Product source, ProductDetailsViewModel destination, string destMember, ResolutionContext context)
        {
            if (source.IsAvailable)
            {
                return "Yes";
            }
            return "No";
        }
    }
}