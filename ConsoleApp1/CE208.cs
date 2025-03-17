using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CE208 : Counter
    {
        public CE208(int serialnumber, int adress, string password) : base(serialnumber, adress, password, 8) { }

    }
}
