using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary.Exceptions
{
    public class NumberIsWrongException:Exception
    {
        public NumberIsWrongException(string msg) : base(msg)
        {

        }
    }
}
