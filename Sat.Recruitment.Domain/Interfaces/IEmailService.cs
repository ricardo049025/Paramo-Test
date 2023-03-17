using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Interfaces
{
    public interface IEmailService
    {
        string GetNormalizedEmail(string email);
    }
}
