using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Domain.Interfaces.Factory;
using Sat.Recruitment.Entities;

namespace Sat.Recruitment.Service
{
    public class UserService : IUserService
    {
        private IEmailService emailService;
        private IFileService fileService;

        public UserService(IEmailService emailService, IFileService fileService)
        {
            this.emailService = emailService;
            this.fileService = fileService;
        }

        public bool IsValidUserFields(string name, string email, string address, string phone, ref string? xerror) 
        {
            string fields = String.Empty;

            if (string.IsNullOrEmpty(name))
                fields += "Name,";
            if (string.IsNullOrEmpty(email))
                fields += "Email,";
            if (string.IsNullOrEmpty(address))
                fields += ",Address,";
            if (string.IsNullOrEmpty(phone))
                fields += "Phone";

            if (!String.IsNullOrEmpty(fields))
                xerror = $"The next fields are required: {fields}";

            return String.IsNullOrEmpty(fields);
        }

        public async Task<Result> GenerateNewUser(string name, string email, string address, string phone, string userType, string money)
        {
            string errorMessage = String.Empty;

            if (!IsValidUserFields(name, email, address, phone, ref errorMessage))
                throw new Exception(errorMessage);

            IUser newUser = UserFactory.getUser(userType,name,emailService.GetNormalizedEmail(email),address,phone,Decimal.Parse(money));
            List<User> users = this.fileService.GetUsersFromFile(Directory.GetCurrentDirectory() + "/Files/Users.txt");

            if (isDuplicatedUser(newUser,users))
                throw new Exception("The user is duplicated");

            return new Result()
            {
                IsSuccess = true,
                Errors = "created user"
            };
        }

        public bool isDuplicatedUser(IUser newUser, List<User> users)
        {
            bool isDuplicated = false;
            
            foreach (var user in users)
            {
                if (user.Email == newUser.GetEmail() || user.Phone == newUser.GetPhone())
                    isDuplicated = true;
                else
                    if (user.Name == newUser.GetName())
                        if (user.Address == newUser.GetAddress())
                            isDuplicated = true;

            }

            return isDuplicated;
        }
    }
}

