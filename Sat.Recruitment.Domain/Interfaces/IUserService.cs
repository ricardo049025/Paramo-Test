using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Interfaces.Factory;
using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Interfaces
{
    public interface IUserService
    {
        bool IsValidUserFields(string name, string email, string address, string phone, ref string xerror);
        public Task<Result> GenerateNewUser(string name, string email, string address, string phone, string userType, string money);
        bool isDuplicatedUser(IUser newUser, List<User> users);
    }
}
