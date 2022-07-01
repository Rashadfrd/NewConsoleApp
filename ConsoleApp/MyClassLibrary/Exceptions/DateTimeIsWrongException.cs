using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary.Exceptions
{
    public class DateTimeIsWrongException:Exception
    {
        public DateTimeIsWrongException(string msg):base(msg)
        {

        }
    }
}
