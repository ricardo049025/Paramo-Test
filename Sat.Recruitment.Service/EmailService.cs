﻿using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Service
{
    public class EmailService : IEmailService
    {
        public string GetNormalizedEmail(string email)
        {
            //Normalize email
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
