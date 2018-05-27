using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinDoors;
namespace Personal
{
   public class Person
    {
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public List<WinDoor>  Windows { get; set; }


        public Person()
        {
            FirstName = "";
            SecondName = "";
            PhoneNumber = "";
            Date = DateTime.Now;
            Windows = new List<WinDoor>();
        }
        public string Name()
        {
            return FirstName + " " + SecondName;
        }
    }
}
