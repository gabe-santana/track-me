using MongoDB.Bson;
using MongoDB.Driver;
using trackapi.Model.Interfaces;

namespace trackapi.Model
{
    public class ChangeStreamDocument<TDocument> : IChangeStreamDocument<TDocument>
    {
        public BsonDocument ClusterTime { get; }
        public CollectionNamespace CollectionNamespace { get; }
        public BsonDocument DocumentKey { get; }
        public TDocument FullDocument { get; }
        public ChangeStreamOperationType OperationType { get; }
        public BsonDocument ResumeToken { get; }
        public ChangeStreamUpdateDescription UpdateDescription { get; }
    }
}