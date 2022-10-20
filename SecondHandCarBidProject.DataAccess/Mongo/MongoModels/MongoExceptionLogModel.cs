using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SecondHandCarBidProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.MongoModels
{
    public class MongoExceptionLogModel:ILogEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("LogType")]
        public int LogType { get; set; }
        [BsonElement("Exception")]
        public string Exception { get; set; }

        [BsonElement("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}
