using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Interfaces.Factory
{
    public class UserNormal : IUser
    {
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public decimal money { set; get; }

        public UserNormal(string name, string email, string address, string phone, decimal money)
        {
            this.name = name;
            this.email = email;
            this.address = address;
            this.phone = phone;
            this.money = money;
        }

        public string UserType()
        {
            return Enums.UserTypeEnum.Normal.ToString();
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
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = money * percentage;
                calcmoney = money + gif;
            }
            if (money < 100)
            {
                if (money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = money * percentage;
                    calcmoney = money + gif;
                }
            }

            return calcmoney;
        }
    }
}
