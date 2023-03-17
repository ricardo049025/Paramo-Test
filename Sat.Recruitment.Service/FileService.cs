using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sat.Recruitment.Service
{
    public class FileService : IFileService
    {
        public List<User> GetUsersFromFile(string path)
        {
            List<User> _users = new List<User>();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                User user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();

            return _users;
        }
    }
}
