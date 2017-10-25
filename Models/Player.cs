using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mvc.Models{
    public class Player 
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
        public string playerId {get;set;}
        public string name {get;set;}
        
        public string team {get;set;}
        
    }
}