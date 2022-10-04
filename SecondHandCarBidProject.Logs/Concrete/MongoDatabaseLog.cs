using SecondHandCarBidProject.Log.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Log.Concrete
{
    public class MongoDatabaseLog<T> : ILogger<T> where T : class
    {
        public MongoDatabaseLog()
        {

        }
        public async Task DataLog(T data)
        {
            throw new NotImplementedException();
        }
    }
}
