using System.Globalization;
using AutoMapper;
using SIENN.Domain;
using SIENN.WebApi.Automapper.Resolvers;
using SIENN.WebApi.Controllers.CategoryViewModels;
using SIENN.WebApi.Controllers.ProductDetailsViewModels;
using SIENN.WebApi.Controllers.ProductTypeViewModels;
using SIENN.WebApi.Controllers.ProductViewModels;
using SIENN.WebApi.Controllers.UnitViewModels;

namespace SIENN.WebApi.Automapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dst => dst.Categries, opt => opt.MapFrom(src => src.Categries));

            CreateMap<ProductInputModel, Product>()
                .ForMember(dst => dst.ProductType, opt => opt.Ignore())
                .ForMember(dst => dst.Unit, opt => opt.Ignore())
                .ForMember(dst => dst.ProductTypeId, opt => opt.MapFrom(src => src.ProductType.Id))
                .ForMember(dst => dst.UnitId, opt => opt.MapFrom(src => src.Unit.Id))
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<ProductUpdateModel, Product>()
                .ForMember(dst => dst.Categries, opt => opt.MapFrom(src => src.Categries))
                .ForMember(dst => dst.Unit, opt => opt.Ignore())
                .ForMember(dst => dst.ProductTypeId, opt => opt.MapFrom(src => src.ProductType.Id))
                .ForMember(dst => dst.UnitId, opt => opt.MapFrom(src => src.Unit.Id));

            CreateMap<Category, CategoryViewModel>();
            CreateMap<ProductCategory, CategoryViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Category.Code))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Category.Description));

            CreateMap<CategoryInputModel, Category>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Products, opt => opt.Ignore());
            CreateMap<CategoryUpdateModel, Category>()
                .ForMember(dst => dst.Products, opt => opt.Ignore());

            CreateMap<Unit, UnitViewModel>();
            CreateMap<UnitInputModel, Unit>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<UnitUpdateModel, Unit>();

            CreateMap<ProductType, ProductTypeViewModel>();
            CreateMap<ProductTypeInputModel, ProductType>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<ProductTypeUpdateModel, ProductType>();

            CreateMap<ProductCategoryUpdateModel, ProductCategory>()
                .ForMember(dst => dst.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dst => dst.Category, opt => opt.MapFrom(src => src.Category))
                ;
            CreateMap<CategoryViewModel, ProductCategory>()
                .ForMember(dst => dst.Product, opt => opt.Ignore())
                .ForMember(dst => dst.Category, opt => opt.Ignore())
                .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.ProductId, opt => opt.Ignore());

            CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(dst => dst.IsAvailable, opt => opt.ResolveUsing(new AvailabiltyLabelResolver()))
                .ForMember(dst => dst.CategoriesCount, opt => opt.MapFrom(src => src.Categries.Count))
                .ForMember(dst => dst.DeliveryDate, opt => opt.ResolveUsing(new DeliveryDateLabelResolver()))
                .ForMember(dst => dst.ProductDescription, opt => opt.MapFrom(src => $"({src.Code}) {src.Description}"))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => $"{src.Price.ToString(CultureInfo.InvariantCulture).Replace(".",",")} zł"))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => $"({src.ProductType.Code}) {src.ProductType.Description}"))
                .ForMember(dst => dst.Unit, opt => opt.MapFrom(src => $"({src.Unit.Code}) {src.Unit.Description}"));
        }
    }
}