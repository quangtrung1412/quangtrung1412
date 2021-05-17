using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesFullC.Contexts;
using TesFullC.Models;

namespace TesFullC.Responsitories.Implements
{
    public class StockResponsitories : IStockResponsitories
    {
        private readonly MSSqlContext _db;
        public object[] SetParameter(TableStock tableStock)
        {
            object[] param ={
                new SqlParameter("@id",tableStock.Id),
                new SqlParameter("@giaTC",tableStock.GiaTc),
                new SqlParameter("@giaTran",tableStock.GiaTran),
                new SqlParameter("@giaSan",tableStock.GiaSan),
                new SqlParameter("@muaG3",(object)tableStock.MuaG3??DBNull.Value),
                new SqlParameter("@muaKL3",(object)tableStock.MuaKl3??DBNull.Value),
                new SqlParameter("@muaG2",(object)tableStock.MuaG2??DBNull.Value),
                new SqlParameter("@muaKL2",(object)tableStock.MuaKl2??DBNull.Value),
                new SqlParameter("@muaG1",(object)tableStock.MuaG1??DBNull.Value),
                new SqlParameter("@muaKL1",(object)tableStock.MuaKl1??DBNull.Value),
                new SqlParameter("@gia",(object)tableStock.Gia??DBNull.Value),
                new SqlParameter("@kl",(object)tableStock.Kl??DBNull.Value),
                new SqlParameter("@tyLe",(object)tableStock.TyLe??DBNull.Value),
                new SqlParameter("@banG1",(object)tableStock.BanG1??DBNull.Value),
                new SqlParameter("@banKL1",(object)tableStock.BanKl1??DBNull.Value),
                new SqlParameter("@banG2",(object)tableStock.BanG2??DBNull.Value),
                new SqlParameter("@banKL2",(object)tableStock.BanKl2??DBNull.Value),
                new SqlParameter("@banG3",(object)tableStock.BanG3??DBNull.Value),
                new SqlParameter("@banKL3",(object)tableStock.BanKl3??DBNull.Value),
                new SqlParameter("@tongKl",(object)tableStock.TongKl??DBNull.Value),
                new SqlParameter("@moCua",(object)tableStock.MoCua??DBNull.Value),
                new SqlParameter("@caoNhat",(object)tableStock.CaoNhat??DBNull.Value),
                new SqlParameter("@thapNhat",(object)tableStock.ThapNhat??DBNull.Value),
                new SqlParameter("@nnmua",(object)tableStock.Nnmua??DBNull.Value),
                new SqlParameter("@nnban",(object)tableStock.Nnban??DBNull.Value),
                new SqlParameter("@room",(object)tableStock.RoomConLai??DBNull.Value)
            };
            return param;
        }

        public StockResponsitories(MSSqlContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteTableStock(string stockId)
        {
            Boolean bl = false;
            var id = new SqlParameter("@id", stockId);
            int rs= await _db.Database.ExecuteSqlRawAsync("exec DeleteTableStock @id", id);
            if (rs <= 0)
            {
                bl = false;
            }
            return bl;
            
        }

        public async Task<TableStock> GetTableStockById(string stockId)
        {
            
            var param = new SqlParameter("@id", stockId);

            TableStock tableStock =  _db
                                    .TableStocks
                                    .FromSqlRaw("exec SP_GET_TableStockById @id", param)
                                    .AsEnumerable()
                                    .FirstOrDefault();                                 
            return tableStock;
        }

        public async Task<IEnumerable<TableStock>> GetTableStocks()
        {
            IEnumerable<TableStock> tableStocks = await _db.TableStocks.FromSqlRaw("SP_GET_TableStock").ToListAsync();
            return tableStocks;
        }

        public async Task<TableStock> InsertTableStock(TableStock tableStock)
        {

            //await _db.TableStocks.AddAsync(tableStock);
            await _db.Database.ExecuteSqlRawAsync("exec InsertTableStock @id,@giaTC,@giaTran,@giaSan,@muaG3,@muaKL3,@muaG2,@muaKL2,@muaG1,@muaKL1,@gia,@kl,@tyLe,@banG1,@banKL1,@banG2,@banKL2,@banG3,@banKL3,@tongKl,@moCua,@caoNhat,@thapNhat,@nnmua,@nnban,@room", SetParameter(tableStock));
            
            return tableStock;
        }

        public async Task<TableStock> UpdateTableStock(TableStock tableStock)
        {
            //_db.TableStocks.Update(tableStock);
            await _db.Database.ExecuteSqlRawAsync("exec UpdateTableStock @id,@giaTC,@giaTran,@giaSan,@muaG3,@muaKL3,@muaG2,@muaKL2,@muaG1,@muaKL1,@gia,@kl,@tyLe,@banG1,@banKL1,@banG2,@banKL2,@banG3,@banKL3,@tongKl,@moCua,@caoNhat,@thapNhat,@nnmua,@nnban,@room", SetParameter(tableStock));
            //await _db.SaveChangesAsync();
            return tableStock;
        }
    }
}
