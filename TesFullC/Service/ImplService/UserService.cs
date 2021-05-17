using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TesFullC.Models;
using TesFullC.Responsitories;

namespace TesFullC.Service.ImplService
{
    public class UserService : IUserService
    {
        private readonly IUserResponsitories _respo;

        public UserService(IUserResponsitories respo)
        {
            _respo = respo;
        }

        public bool CheckLogin(string email, string password)
        {
            User u = _respo.GetUserByEmail(email);
            if(u != null)
            {
                if(u.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<object> GetUserById(int userId)
        {
            return new Respone
            {
                Status = (int)HttpStatusCode.OK,
                Data = await _respo.GetUserById(userId)
            };
            
        }

        public async Task<object> GetUsers()
        {
            return new Respone
            {
                Status = (int)HttpStatusCode.OK,
                Data = await _respo.GetUsers()
            };
        }

        public async Task<object> InsertUser(User user)
        {
            return new Respone
            {
                Status = (int)HttpStatusCode.Created,
                Data = await _respo.InsertUser(user)
            };
        }

        public Task<object> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
