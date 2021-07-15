using System;
using MongoDB.Bson;
using trackapi.Model.Interfaces;

namespace trackapi.Model
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}