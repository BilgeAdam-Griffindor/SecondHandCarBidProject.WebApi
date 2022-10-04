using SecondHandCarBidProject.Log.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Concrete
{
    public class MssqlDatabaseLog<T> : ILogger<T> where T : class
    {
        public async Task DataLog(T data)
        {
            throw new NotImplementedException();
        }
    }
}
