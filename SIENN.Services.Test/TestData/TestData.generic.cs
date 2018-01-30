using System.Collections.Generic;
using SIENN.Services.Common;

namespace SIENN.Services.Test.TestData
{
    public abstract class TestData<T>
    {
        public abstract List<T> GetSampleData(ICurrentDateTime currentDateTime);
    }
}