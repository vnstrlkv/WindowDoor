using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prices;

namespace WindowDoor
{
    public partial class PriceForm : Form
    {
        public PriceForm()
        {
                        InitializeComponent();
            PriceList p = new PriceList();
            p.GetPricesGoogle();
            dataGridView1.DataSource = p.materials;
        }
    }
}
