using System;
using MongoDB.Bson;
using trackapi.Config;
using trackapi.Model.Interfaces;

namespace trackapi.Model
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set;} = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}