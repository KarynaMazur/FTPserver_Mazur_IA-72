using FTPapp.MementoFolder;
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

        public Memento CreateMemento()
        {
            return new Memento(this);
        }

        public void SetMemento(User user)
        {
            this.Name = user.Name;
            this.Login = user.Login;
            this.Password = user.Password;
            this.Rights = user.Rights;
        }


    }
}
