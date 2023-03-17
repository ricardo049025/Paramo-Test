using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Interfaces.Factory
{
    public interface IUser
    {
        String UserType();
        string GetName();
        string GetEmail();
        string GetAddress();
        public string GetPhone();
        decimal GetMoneyCal();
    }
}
