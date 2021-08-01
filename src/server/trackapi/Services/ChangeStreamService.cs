using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using trackapi.Config;
using trackapi.Config.Interfaces;
using trackapi.Services.Interfaces;

namespace trackapi.Services
{
    public class ChangeStreamService<TDocWatch> : IChangeStreamService<TDocWatch>
    {
        private readonly IMongoCollection<TDocWatch> _collection;

        public ChangeStreamService(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocWatch>(GetCollectionName(typeof(TDocWatch)));
        }
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute) documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }


        public TDocWatch Watch()
        {
           var pipeline = 
                new EmptyPipelineDefinition<ChangeStreamDocument<TDocWatch>>()
                .Match(x => x.OperationType == ChangeStreamOperationType.Update);

            var changeStreamOptions = new ChangeStreamOptions
            {
                FullDocument = ChangeStreamFullDocumentOption.UpdateLookup
            };

            using (var cursor = _collection.Watch(pipeline, changeStreamOptions))
            {
                foreach (var change in cursor.ToEnumerable())
                {
                    return change.FullDocument;
                }
            }
            throw null;
        }
    }
}