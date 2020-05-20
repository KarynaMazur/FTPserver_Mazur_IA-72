using FTPapp.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPappF.Visitor
{
    public class MakeLog : IVisitor
    {
        public void VisitUnknownCommandException(UnknownCommandException unknownCommandException)
        {
            MakeNote("Exception! Message: " + unknownCommandException.Message + "; InnerException: " + unknownCommandException.InnerException);
        }

        public void VisitUser(User user)
        {
            MakeNote("Temp user: " + user.Name + "; Rights: " + user.Rights);
        }

        public void MakeNote(string text)
        {
            string path = @"C:\Users\" + Environment.UserName + @"\Desktop\log.txt";

            if (!File.Exists(path))
                using (FileStream fs = File.Create(path))
                {
                    byte[] date = new UTF8Encoding(true).GetBytes(DateTime.Now.ToString() + Environment.NewLine);
                    fs.Write(date, 0, date.Length);
                }
            
            using (FileStream sw = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                byte[] date1 = new UTF8Encoding(true).GetBytes(text + Environment.NewLine);
                sw.Write(date1, 0, date1.Length);
            }
        }
    }
}
