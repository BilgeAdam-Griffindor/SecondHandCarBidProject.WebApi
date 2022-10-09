using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.DataAccess.Mongo.MongoModels
{
    [BsonIgnoreExtraElements]
    public class EmailPasswordTokenModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        public Guid UserId { get; set; }

        [BsonElement("token")]
        public string Token { get; set; }

        [BsonElement("token_for")]
        public string TokenFor { get; set; }

        [BsonElement("expiration_date")]
        public DateTime ExpirationDate { get; set; }
    }
}
