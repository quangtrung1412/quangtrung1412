using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesFullC.Models;

namespace TesFullC.Responsitories
{
    public interface IStockResponsitories
    {
        Task<IEnumerable<TableStock>> GetTableStocks();
        Task<TableStock> GetTableStockById(string stockId);
        Task<TableStock> UpdateTableStock(TableStock tableStock);
        Task<TableStock> InsertTableStock(TableStock tableStock);
        Task<bool> DeleteTableStock(string stockId);
    }
}
