using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sat.Recruitment.Domain.Interfaces
{
    public interface IFileService
    {
        List<User> GetUsersFromFile(string path);
    }
}
