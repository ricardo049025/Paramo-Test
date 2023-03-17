using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private IUserService service;
       
        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            try
            {
               var result = await service.GenerateNewUser(name, email, address, phone, userType, money);
               return result;
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
            
        }

    }
   
}
