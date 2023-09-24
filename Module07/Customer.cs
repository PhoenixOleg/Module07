using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07
{
    abstract class Customer
    {
        internal Address address;
        internal Contacts contacts;
    }

    class Person : Customer 
    {

    }

    class Company : Customer 
    {

    }
}
