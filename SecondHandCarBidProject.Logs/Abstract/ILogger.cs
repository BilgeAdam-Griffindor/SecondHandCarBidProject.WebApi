using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Log.Abstract
{
    public interface ILogger<T>
    {
         Task DataLog(T data);

    }
}
