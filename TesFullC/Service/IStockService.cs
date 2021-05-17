using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesFullC.Models;

namespace TesFullC.Service
{
    public interface IStockService
    {
        Task<object> GetTableStocks();
        Task<object> GetTableStockById(string stockId);
        Task<object> UpdateTableStock(TableStock tableStock);
        Task<object> InsertTableStock(TableStock tableStock);
        Task<bool> DeleteTableStock(string stockId);
    }
}
