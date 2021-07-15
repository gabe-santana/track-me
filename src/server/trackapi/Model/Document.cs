using System;
using MongoDB.Bson;
using trackapi.Config;
using trackapi.Model.Interfaces;

namespace trackapi.Model
{
    [BsonCollection("User")]
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}