using System.Linq;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services.Common;

namespace SIENN.Services.Units
{
    public class UnitService : ICrudService<Unit>
    {
        private readonly IReadOnlyRepository<Unit> _readRepository;
        private readonly IWriteOnlyRepository<Unit> _writeRepository;

        public UnitService(IReadOnlyRepository<Unit> readRepository, IWriteOnlyRepository<Unit> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public Unit Get(int id)
        {
            return _readRepository.GetFirst(x => x.Id == id);
        }

        public Unit Create(Unit entity)
        {
            return _writeRepository.InsertData(entity);
        }

        public void Delete(int id)
        {
            _writeRepository.DeleteData(x => x.Id == id);
        }

        public Unit Update(Unit entity)
        {
            return _writeRepository.UpdateData(x=>x.Id == entity.Id,
                unit =>
                {
                    unit.Code = entity.Code;
                    unit.Description = entity.Description;
                })
                .First();
        }
    }
}