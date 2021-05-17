using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TesFullC.Models;
using TesFullC.Service;

namespace TesFullC.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StockApiController : ControllerBase
    {
        private readonly IStockService _stockSerivce;

        public StockApiController(IStockService stockService)
        {
            _stockSerivce = stockService;
        }
        [Route("GetAllStock")]
        public async Task<IActionResult> StockApi()
        {
            Respone res = (Respone)await _stockSerivce.GetTableStocks();
            object dataRes = null;
            if (res.Status == (int)HttpStatusCode.OK)
            {
                dataRes = res.Data;
            }
            else
            {
                dataRes = res.Message;
            }
            return StatusCode(res.Status, dataRes);
        }
        [Route("GetStock")]
        [HttpGet]
        public async Task<IActionResult> GetStockById(string stockId)
        {
            Respone res = (Respone)await _stockSerivce.GetTableStockById(stockId);
            object dataRes = null;
            if(res.Status == (int)HttpStatusCode.OK)
            {
                dataRes = res.Data;
            }
            else
            {
                dataRes = res.Message;
            }
            return StatusCode(res.Status, dataRes);
        }
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert(TableStock tableStock)
        {
            var resp = (Respone)await _stockSerivce.InsertTableStock(tableStock);
            object dataResp = null;
            if (resp.Status == (int)HttpStatusCode.Created)
            {
                dataResp = resp.Data;
            }
            else
            {
                dataResp = resp.Message;
            }
            return StatusCode(resp.Status, dataResp);
        }
       
        [HttpPut]
        public async Task<IActionResult> Update(TableStock tableStock)
        {
            var resp = (Respone)await _stockSerivce.UpdateTableStock(tableStock);
            object dataResp = null;
            if (resp.Status == (int)HttpStatusCode.Created)
            {
                dataResp = resp.Data;
            }
            else
            {
                dataResp = resp.Message;
            }
            return StatusCode(resp.Status, dataResp);
        }
        
    }
}
