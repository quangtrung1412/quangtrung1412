using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TesFullC.Models;
using TesFullC.Responsitories;

namespace TesFullC.Service.ImplService
{
    public class StockService : IStockService
    {
        private readonly IStockResponsitories _resp;

        public StockService(IStockResponsitories resp)
        {
            _resp = resp;
        }

        public Task<bool> DeleteTableStock(string stockId)
        {
            if (stockId == null)
            {
                return new Respone
                {
                    Status = (int)HttpStatusCode.NoContent,
                    Message = "mã không được trống"
                };
            }
            return new Respone
            {
                Status = (int)HttpStatusCode.OK,
                Data = await _resp.GetTableStockById(stockId)
            };
        }

        public async Task<object> GetTableStockById(string stockId)
        {
            if (stockId == null)
            {
                return new Respone
                {
                    Status = (int)HttpStatusCode.NoContent,
                    Message = "mã không được trống"
                };
            }
            return new Respone
            {
                Status = (int)HttpStatusCode.OK,
                Data = await _resp.GetTableStockById(stockId)
            };
        }

        public async Task<object> GetTableStocks()
        {
            return new Respone
            {
                Status = (int)HttpStatusCode.OK,
                Data = await _resp.GetTableStocks()
            };
        }

        public async Task<object> InsertTableStock(TableStock tableStock)
        {
            return new Respone
            {
                Status = (int)HttpStatusCode.Created,
                Data = await _resp.InsertTableStock(tableStock)
            };
        }

        public async Task<object> UpdateTableStock(TableStock tableStock)
        {
            return new Respone
            {
                Status = (int)HttpStatusCode.Created,
                Data = await _resp.UpdateTableStock(tableStock)
            };
        }
    }
}
