using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using UnityEngine;



public class LeaderboardManager : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://admin:admin@cluster0.aasp9.mongodb.net/?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    // Start is called before the first frame update

    public void connect(){
        database = client.GetDatabase("AlgoRace");
        collection = database.GetCollection<BsonDocument>("Leaderboard");

        //show first record of collection
        var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
        Debug.Log(firstDocument.ToJson());
    }

    public async void AddToLeaderBoard(Leaderboard leaderboardEntry)
    {
        var document = BsonDocument.Parse(JsonConvert.SerializeObject(leaderboardEntry));
        await collection.InsertOneAsync(document);
    }

    public IList<Leaderboard> GetLeaderboardScores()
    {
        var allScoresTask = collection.Find(new BsonDocument())
            .SortBy(s => s["Time"]).Limit(10);

        var scores = new List<Leaderboard>();
        foreach (var score in allScoresTask.ToList())
        {
            var result = BsonSerializer.Deserialize<Leaderboard>(score);
            scores.Add(result);
        }

        return scores;
    }
}

public class Leaderboard
{
    public ObjectId _id { get; set; }
    public string Name { get; set; }
    public int QuestionsRight { get; set; }
    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    public float Time { get; set; }
}
