using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace trackapi.Model.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
    }
}