using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Servers;
using Squire.BusinessLogic.Models;
using Squire.BusinessLogic.Services.Interfaces;
using Squire.BusinessLogic.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly ISettings settings;
        private IMongoClient client;
        private IMongoDatabase db;

        private const string softwaresCollection = "softwares";

        public DataAccess(ISettings settings)
        {
            this.settings = settings;
            client = new MongoClient(settings.ConnectionString + settings.Database);
            db = client.GetDatabase(settings.Database);
        }

        public IEnumerable<Software> GetSoftwares()
        {
            return db.GetCollection<Software>(softwaresCollection).Find(Builders<Software>.Filter.Empty).ToList();
        }

        public void Insert(Software sw)
        {
            db.GetCollection<Software>(softwaresCollection).InsertOne(sw);
        }

        public void Delete(ObjectId id)
        {
            db.GetCollection<Software>(softwaresCollection).DeleteOne(p => p.Id == id);
        }

        public Software Get(string id)
        {
            var oid = ObjectId.Parse(id);
            return db.GetCollection<Software>(softwaresCollection).Find(p => p.Id == oid).FirstOrDefault();
        }
    }
}
