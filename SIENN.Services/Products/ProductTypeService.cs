using System.Linq;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services.Common;

namespace SIENN.Services.Products
{
    public class ProductTypeService : ICrudService<ProductType>
    {
        private readonly IReadOnlyRepository<ProductType> _productTypeReadRepository;
        private readonly IWriteOnlyRepository<ProductType> _productTypeWoRepository;

        public ProductTypeService(IReadOnlyRepository<ProductType> productTypeReadRepository, IWriteOnlyRepository<ProductType> productTypeWoRepository)
        {
            _productTypeReadRepository = productTypeReadRepository;
            _productTypeWoRepository = productTypeWoRepository;
        }

        public ProductType Get(int id)
        {
            return _productTypeReadRepository.GetFirst(x=>x.Id == id);
        }

        public ProductType Update(ProductType productType)
        {
            return _productTypeWoRepository.UpdateData(x => x.Id == productType.Id, x =>
            {
                x.Code = productType.Code;
                x.Description = productType.Description;
            }).First();
        }

        public ProductType Create(ProductType productType)
        {
            return _productTypeWoRepository.InsertData(productType);
        }

        public void Delete(int id)
        {
            _productTypeWoRepository.DeleteData(x => x.Id == id);
        }
    }
}