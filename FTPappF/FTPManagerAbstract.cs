using FTPappF.Builder;
using FTPappF.WCFserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPappF
{
    public abstract class FTPManagerAbstract
    {
        public User _tempUser;
        private MyService _myService;
        public FTPManagerAbstract()
        {
            _myService = new MyService();
        }

        public string ExecuteCommand(string command) // template method - реализован в абстрактном классе, 
        {                                            //  един для всех наследников
            if (command == "getPrevUser")
            {
                GetPreviousUser();
                return "User changed to " + _tempUser.Name;
            }
            else if (command == "newUser")
            {
                ChangeTempUser();
                return "User changed to " + _tempUser.Name;
            }
            return _myService.Send(command, _tempUser.Rights);
        }

        public abstract void GetPreviousUser(); // методы, которые должны быть 
        public abstract void ChangeTempUser(); // переопределены в классах наследниках

    }
}
