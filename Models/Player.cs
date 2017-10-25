using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mvc.Models{
    public class Player 
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
        public string Name {get;set;}
        
        public string Team {get;set;}
        
    }
}