using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epood_toode
{
    public partial class ostja_form : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\epood_toode\Tooded_DB.mdf");
        SqlCommand command;
        SqlDataAdapter adapter_toode, adapter_kategooria;

        public ostja_form()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodetabel.Toodenimetus, Toodetabel.Hind, Toodetabel.Kogus, Toodetabel.Bpilt FROM Toodetabel", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;

            connect.Close();
        }

        private void lisa_toode_btn_Click(object sender, EventArgs e)
        {

        }

        private void muuja_Load(object sender, EventArgs e)
        {

        }
    }
}
