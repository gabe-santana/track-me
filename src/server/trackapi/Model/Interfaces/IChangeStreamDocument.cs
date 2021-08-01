using MongoDB.Bson;
using MongoDB.Driver;

namespace trackapi.Model.Interfaces
{
    public interface IChangeStreamDocument<TDocument>
    {
        BsonDocument ClusterTime { get; }
        CollectionNamespace CollectionNamespace { get; }
        BsonDocument DocumentKey { get; }
        TDocument FullDocument { get; }
        ChangeStreamOperationType OperationType { get; }
        BsonDocument ResumeToken { get; }
        ChangeStreamUpdateDescription UpdateDescription { get; }
    }
}