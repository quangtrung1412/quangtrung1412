using System;
using System.Collections.Generic;

#nullable disable

namespace TesFullC.Models
{
    public class TableStock
    {
        public string Id { get; set; }
        public double GiaTc { get; set; }
        public double GiaTran { get; set; }
        public double GiaSan { get; set; }
        public double? MuaG3 { get; set; }
        public int? MuaKl3 { get; set; }
        public double? MuaG2 { get; set; }
        public int? MuaKl2 { get; set; }
        public double? MuaG1 { get; set; }
        public int? MuaKl1 { get; set; }
        public double? Gia { get; set; }
        public int? Kl { get; set; }
        public double? TyLe { get; set; }
        public double? BanG1 { get; set; }
        public int? BanKl1 { get; set; }
        public double? BanG2 { get; set; }
        public int? BanKl2 { get; set; }
        public double? BanG3 { get; set; }
        public int? BanKl3 { get; set; }
        public int? TongKl { get; set; }
        public double? MoCua { get; set; }
        public double? CaoNhat { get; set; }
        public double? ThapNhat { get; set; }
        public int? Nnmua { get; set; }
        public int? Nnban { get; set; }
        public int? RoomConLai { get; set; }
    }
}
