using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Interfaces.Factory
{
    public class UserFactory
    {
        public static IUser getUser(String type, string name, string email, string address, string phone, decimal money)
        {
            IUser objectType = null;

            if (type.ToLower().Equals(UserTypeEnum.Normal.ToString().ToLower()))
                objectType = new UserNormal(name,email,address,phone,money);

            if (type.ToLower().Equals(UserTypeEnum.SuperUser.ToString().ToLower()))
                objectType = new UserSuper(name, email, address, phone, money);

            if (type.ToLower().Equals(UserTypeEnum.Premium.ToString().ToLower()))
                objectType = new UserPremium(name, email, address, phone, money);

            return objectType;
        }
    }
}
