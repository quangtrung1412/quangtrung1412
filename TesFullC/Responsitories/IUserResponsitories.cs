using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesFullC.Models;


namespace TesFullC.Responsitories
{
    public interface IUserResponsitories
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int userId);
        User GetUserByEmail(string email);
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(User user);
        
        
    }
}
