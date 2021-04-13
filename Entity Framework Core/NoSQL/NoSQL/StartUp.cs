using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace NoSQL
{
    public class StartUp
    {
        public static void Main()
        {
            var client = new MongoClient(
                "mongodb://127.0.0.1:27017"
            );

            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("articles");

            var articles = collection
                .Find(new BsonDocument()).ToList();

            ReadArticleNames(articles);

            InsertArticle(collection);

            UpdateArticles(articles, collection);

            DeleteLowRatedArticles(collection);
        }

        private static void ReadArticleNames(IEnumerable<BsonDocument> articles)
        {
            foreach (var article in articles)
            {
                var name = article.GetElement("name").Value.AsString;
                Console.WriteLine(name);
            }
        }

        private static void InsertArticle(IMongoCollection<BsonDocument> collection)
        {
            //author "Steve Jobs", date "05-05-2005", name "The story of Apple",  rating "60".

            collection.InsertOne(new BsonDocument
            {
                {"author", "Steve Jobs"},
                {"date", "05-05-2005"},
                {"name", "The story of Apple"},
                {"rating", "60"}
            });
        }
        private static void UpdateArticles(IEnumerable<BsonDocument> articles, IMongoCollection<BsonDocument> collection)
        {
            foreach (var article in articles)
            {
                var newRating = int.Parse(article.GetElement("rating").Value.AsString) + 10;

                var filterQuery = Builders<BsonDocument>.Filter.Eq("_id", article.GetElement("_id").Value);

                var updateQuery = Builders<BsonDocument>.Update.Set("rating", newRating.ToString());

                collection.UpdateOne(filterQuery, updateQuery);
                Console.WriteLine($"Name: {article.GetElement("name").Value} - Rating: {article.GetElement("rating").Value}");
            }
        }

        private static void DeleteLowRatedArticles(IMongoCollection<BsonDocument> collection)
        {
            var deleteFilter = Builders<BsonDocument>
                .Filter.Lte("rating", 50);
            collection.DeleteMany(deleteFilter);
        }
    }
}
