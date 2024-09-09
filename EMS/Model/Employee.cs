using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS.Model
{
    public class Employee
    {
/*Now create session for login logout and make entity for that
 * like limited info id & name & isAdmin etc*/
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }
    }
}