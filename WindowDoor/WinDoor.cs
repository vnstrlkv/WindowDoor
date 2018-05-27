using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDoors
{
    public class WinDoor
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string Material { get; set; }
        public double Delivery { get; set; }
        public double Metering { get; set; }
        public double InstallWindow { get; set; }

        public bool Deaf { get; set; }

        public bool OpenWindow { get; set; }
        public bool Pipe { get; set; }
        public bool PaintPipe { get; set; }

        public bool FullOpenWindow { get; set; }

        public bool Cutting { get; set; }

        public double Perimeter ()
        {
            return (Height + Width) * 2;
        }

        public double Square ()
        {
            return Height * Width;
        }

       public WinDoor()
        {
            Height = 0;
            Width = 0;
        }

    }
}
