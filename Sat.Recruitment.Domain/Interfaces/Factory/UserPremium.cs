﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Interfaces.Factory
{
    public class UserPremium : IUser
    {
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public decimal money { set; get; }

        public UserPremium(string name, string email, string address, string phone, decimal money)
        {
            this.name = name;
            this.email = email;
            this.address = address;
            this.phone = phone;
            this.money = money;
        }

        public string UserType()
        {
            return Enums.UserTypeEnum.Premium.ToString();
        }
        public string GetName()
        {
            return this.name;
        }

        public string GetEmail()
        {
            return this.email;
        }
        public string GetAddress()
        {
            return this.address;
        }
        public string GetPhone()
        {
            return this.phone;
        }

        public decimal GetMoneyCal()
        {
            decimal calcmoney = money;

            if (money > 100)
            {
                var gif = money * 2;
                calcmoney = money + gif;
            }

            return calcmoney;
        }

    }
}
