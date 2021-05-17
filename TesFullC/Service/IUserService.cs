using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesFullC.Models;

namespace TesFullC.Service
{
    public interface IUserService
    {
        Task<object> GetUsers();
        Task<object> GetUserById(int userId);
        Task<object> InsertUser(User user);
        Task<object> UpdateUser(User user);

        bool CheckLogin(string email, string password);
    }
}
