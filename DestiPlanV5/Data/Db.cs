using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace DestiPlanv5.Data
{
    class Db
    {
        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://vincentvictor00:Admin123@cluster0.1ucq88h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            return mongoClient;
        }

        public static IMongoCollection<Models.Trip> TripCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("myTripsDb");
            var tripCollection = database.GetCollection<Models.Trip>("MyTrips2");
            return tripCollection;
        }




    }
}
