using FTPapp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPappF.Visitor
{
    public interface IVisitor
    {
        void VisitUser(User user);
        void VisitUnknownCommandException(UnknownCommandException unknownCommandException);
    }
}
