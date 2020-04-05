using FTPappF.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPappF
{
    public class User
    {
        public string Name;
        public string Login;
        public string Password;
        private string _rights;
        public string Rights { get => _rights; set{ _rights = value; } }

        public static UserBuilder CreateBuilder()
        {
            return new UserBuilder();
        }
    }
}
