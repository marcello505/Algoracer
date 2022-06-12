using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;



public class LeaderboardManager : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://admin:admin@cluster0.aasp9.mongodb.net/?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    // Start is called before the first frame update
    void Start()
    {
        connect();
        //AddToLeaderBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void connect(){
        database = client.GetDatabase("AlgoRace");
        collection = database.GetCollection<BsonDocument>("Leaderboard");

        //show first record of collection
        var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
        Debug.Log(firstDocument.ToJson());
    }

    public async void AddToLeaderBoard()
    {
        var document = new BsonDocument { {"Name", "Kevin" } };
        await collection.InsertOneAsync(document);
    }

    public async Task<List<Leaderboard>> GetLeaderboardScores()
    {
        var allScoresTask = collection.FindAsync(new BsonDocument());
        var scoresAwaited = await allScoresTask;

        List<Leaderboard> scores = new List<Leaderboard>();
        foreach (var score in scoresAwaited.ToList())
        {
            scores.Add(Deserialize(score.ToString()));
        }

        return scores;
    }

    private Leaderboard Deserialize(string rawjson)
    {
        var leaderboard = new Leaderboard();

        var stringWithoutID = rawjson.Substring(rawjson.IndexOf("),") + 4);
        var name = stringWithoutID.Substring(0, stringWithoutID.IndexOf(":") - 2);



        leaderboard.Name = name;
        leaderboard.QuestionsRight = 2;
        return leaderboard;
    }
}

public class Leaderboard
{
    public string Name { get; set; }
    public int QuestionsRight { get; set; }
}
