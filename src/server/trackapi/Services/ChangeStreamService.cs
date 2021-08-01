using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using trackapi.Config;
using trackapi.Config.Interfaces;
using trackapi.Services.Interfaces;

namespace trackapi.Services
{
    public class ChangeStreamService<TDocWatch> : IChangeStreamService<TDocWatch>
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public ChangeStreamService(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<BsonDocument>(GetCollectionName(typeof(TDocWatch)));
        }
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute) documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public async Task Watch(WebSocket websocket, WebSocketReceiveResult result)
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>()
            .Match(change => change.OperationType == ChangeStreamOperationType.Insert || change.OperationType == ChangeStreamOperationType.Update || change.OperationType == ChangeStreamOperationType.Replace)
            .AppendStage<ChangeStreamDocument<BsonDocument>, ChangeStreamDocument<BsonDocument>, BsonDocument>(
            "{ $project: { 'fullDocument': 1}}");

            var options = new ChangeStreamOptions{
                    FullDocument = ChangeStreamFullDocumentOption.UpdateLookup
                };

            var enumerator = _collection.Watch(pipeline, options).ToEnumerable().GetEnumerator();
           
            while (enumerator.MoveNext()){

                var serverMsg =  Encoding.UTF8.GetBytes(enumerator.Current.ToString());
                await websocket.SendAsync(new ArraySegment<byte>(serverMsg), WebSocketMessageType.Text, true, CancellationToken.None);
            }

            enumerator.Dispose();
        }
    }
}