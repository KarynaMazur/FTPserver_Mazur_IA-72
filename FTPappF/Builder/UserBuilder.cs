using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPappF.Builder
{
    public class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            user = new User();
        }
        public UserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }
        public UserBuilder SetRights(string rights)
        {
            user.Rights = rights;
            return this;
        }
        public UserBuilder CreateAdmin()
        {
            user.Rights = "rwe";
            return this;
        }
        public User Build()
        {
            return user;
        }
    }
}
