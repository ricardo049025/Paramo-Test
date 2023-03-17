using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Domain.Interfaces.Factory;
using Sat.Recruitment.Entities;
using Sat.Recruitment.Service;
using Xunit;

namespace Sat.Recruitment.Test
{
    [ExcludeFromCodeCoverage]
    public class UserValidations
    {
        [Fact]
        public void NormalizeEmailTest()
        {
            string email = "Franco.Perez@gmail.com";
            var emailvalid = new Mock<IEmailService>();
            emailvalid.Setup(x=> x.GetNormalizedEmail(email)).Returns("FrancoPerez@gmail.com");
            Assert.Equal("FrancoPerez@gmail.com", emailvalid.Object.GetNormalizedEmail(email));

        }

        [Fact]
        public void GetValueFromFileTest()
        {   
            string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            List<User> users = new List<User>()
            {
                new User { Name = "Juan", Email="Juan@marmol.com", Phone="+5491154762312", Address="Peru 2464", UserType =  UserTypeEnum.Normal.ToString(), Money=1234},
                new User { Name = "Franco", Email="Franco.Perez@gmail.com", Phone="+534645213542", Address="Alvear y Colombres", UserType =  UserTypeEnum.Premium.ToString(), Money=112234},
                new User { Name = "Agustina", Email="Agustina@gmail.com", Phone="+534645213542", Address="Garay y Otra Calle", UserType =  UserTypeEnum.SuperUser.ToString(), Money=112234}
            };
            
            var filemock = new Mock<IFileService>();
            filemock.Setup(x => x.GetUsersFromFile(path)).Returns(users);
            Assert.Equal(users, filemock.Object.GetUsersFromFile(path));
        }
        [Fact]
        public void UserControllerTest()
        {
            string name = "ricardo", email = "example@gmail.com", address = "Masaya, Nicaragua", phone = "+50585021379",  userType = "Normal", money = "123";
            IEmailService emailservice = new EmailService();
            IFileService fileservice = new FileService();
            IUserService userService = new UserService(emailservice,fileservice);

            UsersController controller = new UsersController(userService);
            var result = controller.CreateUser(name,email,address,phone,userType,money);
            Assert.True(result.Result.IsSuccess);
            Assert.Equal("created user", result.Result.Errors);
        }

    }
}
