using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02EndToEndWebApp_done.Model
{
    public class Customer : _02EndToEndWebApp_done.Model.ICustomer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }


    }
}
