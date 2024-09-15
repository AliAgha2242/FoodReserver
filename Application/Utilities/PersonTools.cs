using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class PersonTools
    {
        public EncriptTools Encript { get; }
        public PersonTools(EncriptTools encript)
        {
            Encript = encript;
        }


        public string PasswordGenerator(string password, string passwordSalt)
        {
            return string.Concat(Encript.GetSHA256(password),Encript.GetSHA256(passwordSalt));
        }
    }
}

