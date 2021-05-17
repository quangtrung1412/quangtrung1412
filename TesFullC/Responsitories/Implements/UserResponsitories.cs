using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesFullC.Contexts;
using TesFullC.Models;
using TesFullC.Responsitories;

namespace TesFullC.Responsitories.Implements
{
    public class UserResponsitories : IUserResponsitories
    {
        private readonly MSSqlContext _db;

        public UserResponsitories(MSSqlContext db)
        {
            _db = db;
        }
        
        public User GetUserByEmail(string email)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
        public async Task<User> GetUserById(int userId)
        {
            User user = await _db.Users.FindAsync(userId);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = await _db.Users.ToListAsync();
            return users;
        }

        public async Task<User> InsertUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;

        }

        public async Task<User> UpdateUser(User user)
        {
             _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;

        }
    }
}
