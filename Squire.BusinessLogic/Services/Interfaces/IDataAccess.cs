using MongoDB.Bson;
using Squire.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squire.BusinessLogic.Services.Interfaces
{
    public interface IDataAccess
    {
        IEnumerable<Software> GetSoftwares();

        void Insert(Software sw);

        void Delete(ObjectId id);

        Software Get(ObjectId id);
    }
}
