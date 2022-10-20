using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Logs.Abstract
{
    public interface ILogCatcherMongoLog
    {
        Task WriteLogWarning(Exception ex);
        Task WriteLogInfo(Exception ex);
        Task WriteLogDebug(Exception ex);
    }
}
