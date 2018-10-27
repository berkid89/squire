using Squire.Common;
using Squire.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squire.Functions
{
    public static class InitDb
    {
        private static IRepository Repo;

        static InitDb()
        {
            Repo = new CosmosDbRepo(
                Environment.GetEnvironmentVariable(Consts.ENV_SquireDbEndpointUri),
                Environment.GetEnvironmentVariable(Consts.ENV_SquireDbPrimaryKey)
            );
        }

        public static async Task<IRepository> GetRepoAsync()
        {
            return await Repo.InitAsync();
        }
    }
}
