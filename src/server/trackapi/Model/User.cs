using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using trackapi.Config;

namespace trackapi.Model
{
    
    [BsonCollection("User")]
    public class User : Document
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}