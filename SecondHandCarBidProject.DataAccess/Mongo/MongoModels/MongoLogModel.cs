using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SecondHandCarBidProject.DataAccess.Mongo.MongoModels
{
    public class MongoLogModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("base_user_id")]
        public int BaseUserId { get; set; }
        [BsonElement("ip_addres")]
        public string IpAddress { get; set; }
       
        [BsonElement("user_name")]
        public string UserName { get; set; }
        
        [BsonElement("created_date")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("ActionType")]
        public string ActionType { get; set; }
        [BsonElement("BrowserType")]
        public string BrowserType { get; set; }
        [BsonElement("Url")]
        public string Url { get; set; }
    }
}
