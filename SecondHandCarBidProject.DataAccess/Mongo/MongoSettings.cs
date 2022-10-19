

namespace SecondHandCarBidProject.DataAccess.Mongo
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LogCollection { get; set; }
        public string EmailPasswordTokenCollection { get; set; }
    }
}
