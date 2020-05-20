using FTPapp.Exceptions;
using FTPapp.MementoFolder;
using FTPappF;
using FTPappF.Builder;
using FTPappF.Visitor;
using FTPappF.WCFserver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FTPapp
{
    public class FTPManager : AbstractManager
    {
        private CareTaker _careTaker;
        private MakeLog _makeLog;

        public FTPManager(MakeLog makeLog)
        {
            _tempUser = Authorization();
            _makeLog = makeLog;
            _makeLog.VisitUser(_tempUser); //visitor
            _careTaker = new CareTaker();
        }
        public override void ChangeTempUser()
        {
            _careTaker.SaveMemento(_tempUser.CreateMemento()); 
            _tempUser = Authorization();
            _makeLog.VisitUser(_tempUser); //visitor
        }
        public override void GetPreviousUser()  //переопределение
        {
            _tempUser.SetMemento(_careTaker.GetMemento()); 
        }

        public static User Authorization()
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