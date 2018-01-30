using AutoMapper;
using NUnit.Framework;
using SIENN.WebApi.Automapper;

namespace SIENN.WebApi.Test
{
    public class AutomapperTest
    {
        private IMapper _mapper;

        [OneTimeSetUp]
        public void Setup()
        {
            this._mapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfileConfiguration()); })
                .CreateMapper();
        }

        [Test]
        public void AutomapperShouldInitializeWithoutException()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
