using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesFullC.Models
{
    public class Respone
    {
        //catch lỗi phản hồi massage
        public int Status { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
