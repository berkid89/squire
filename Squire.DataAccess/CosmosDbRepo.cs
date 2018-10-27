using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Squire.Common;
using Squire.Common.Models;
using System;
using System.Threading.Tasks;

namespace Squire.DataAccess
{
    public class CosmosDbRepo : IRepository
    {
        private readonly DocumentClient client;

        public CosmosDbRepo(string endpointUri, string primaryKey)
        {
            client = new DocumentClient(new Uri(endpointUri), primaryKey);
        }

        public async Task<IRepository> InitAsync()
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = Consts.DatabaseName });
            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(Consts.DatabaseName), new DocumentCollection { Id = Consts.ProductsCollection });

            return this;
        }

        public async Task<Product> GetProductInfo(string productId)
        {
            return await client.ReadDocumentAsync<Product>(UriFactory.CreateDocumentUri(Consts.DatabaseName, Consts.ProductsCollection, productId));
        }
    }
}
