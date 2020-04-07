using FTPapp.Exceptions;
using FTPapp.Memento;
using FTPappF;
using FTPappF.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FTPapp
{
    public class FTPManager
    {
        private FTPappF.localhost.MyService _myService;
        private User _tempUser;
        private CareTaker _careTaker;
        private IState State { get; set; }
        public FTPManager(FTPappF.localhost.MyService myService)
        {
            _tempUser = Authorization();
            _myService = myService;
            _careTaker = new CareTaker();
        }
        public void ChangeTempUser()
        {
            _careTaker.History.Push(new Memento.Memento(_tempUser)); //memento
            _tempUser = Authorization();
        }
        public void GetPreviousUser()
        {
            _tempUser = _careTaker.History.Pop().ObjToSave as User;  //memento
        }
        public string ExecuteCommand(string command)
        {
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

        private static User Authorization()
        {
            User user;
            Console.WriteLine("Your name: ");
            string name = Console.ReadLine();
            if (name == "admin")
                user = new UserBuilder().SetName(name).CreateAdmin().Build(); //builder
            else
                user = new UserBuilder().SetName(name).SetRights("r").Build();
            Console.WriteLine("Hi, {0}! You can {1}", user.Name, user.Rights);
            return user;
        }
    }
}
