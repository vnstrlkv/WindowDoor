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
        public int Count { get; set; }
        private double sizeMaterial;
        private double size;
        public double Size { get => size; }
        public double SizeMaterial
        {
            get { return sizeMaterial; }
            set
            {
                if (value == 1.4)
                {
                    sizeMaterial = value;
                    size = 1.5;
                }
                else if (value == 2)
                {
                    size = 2.2;
                    sizeMaterial = 2;
                };
            }
        }

        public bool Deaf { get; set; }

        public bool OpenWindow { get; set; }
        public bool Pipe { get; set; }
        public bool PaintPipe { get; set; }
        public bool Flash { get; set; }

        public bool FullOpenWindow { get; set; }

        public bool Cutting { get; set; }
        public double Summ { get; set; }

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
