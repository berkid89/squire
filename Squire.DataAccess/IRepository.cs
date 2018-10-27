using Squire.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squire.DataAccess
{
    public interface IRepository
    {
        Task<IRepository> InitAsync();

        Task<Product> GetProductInfo(string productId);
    }
}
