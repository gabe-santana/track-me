using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace trackapi.Model
{
   public class ChangeStreamOptions
    {
        public int? BatchSize { get; set; }
        public Collation Collation { get; set; }
        public ChangeStreamFullDocumentOption FullDocument { get; set; }
        public TimeSpan? MaxAwaitTime { get; set; }
        public BsonDocument ResumeAfter { get; set; }
        public BsonTimestamp StartAtOperationTime { get; set; }
    }
}