﻿

namespace SecondHandCarBidProject.DataAccess.Mongo
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string WebApiAdmingRequestLogCollection { get; set; }
        public string WebApiExceptionLogCollection { get; set; }
        public string EmailPasswordTokenCollection { get; set; }
    }
}
