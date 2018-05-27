using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinDoors;
using SQLite;
namespace Personal
{
   public class Person
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string SecondName { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        [MaxLength(30)]
        public DateTime Date { get; set; }

        [MaxLength(30)]
        public double Summ { get; set; }

        [Ignore] 
        public List<WinDoor>  Windows { get; set; }

     
        public Person()
        {
            FirstName = "";
            SecondName = "";
            PhoneNumber = "";
            Date = DateTime.Now;
            Windows = new List<WinDoor>();
        }
        
      public  void getSumm()
        {
            Summ = 0;
            foreach (WinDoor w in Windows)
            {
                Summ += w.Summ;
            }
        }
        public string Name()
        {
            return FirstName + " " + SecondName;
        }
    }
}
