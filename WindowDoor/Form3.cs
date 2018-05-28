using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Personal;
using SQLite;

namespace WindowDoor
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            DataSet ds = new DataSet(); //Создаем объект класса DataSet

            var db = new SQLiteConnection("BD.db", true);

            var persons = db.Query<Person>("SELECT * FROM Person");





            dataGridView1.DataSource = persons;

           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
