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
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Ryshniak\Tooded_DB.mdf");
        SqlCommand command;
        SqlDataAdapter adapter_toode, adapter_kategooria;


        int Id = 0;
        int kogus = 0;
        int kogus_naitamine = 0;

        public ostja_form()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodenimetus, Hind, Kogus, Bpilt FROM Toodetabel WHERE Kogus > 0", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            ostukorv.Font= new Font("Cascadia Mono", 13);
            connect.Close();
        }

        private void lisa_toode_btn_Click(object sender, EventArgs e)
        {
            string nimetus = dataGridView1.SelectedRows[0].Cells["Toodenimetus"].Value.ToString();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Valige toode!");
                return;
            }
            kogus = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Kogus"].Value);
            if (kogus > 0)
                kogus -= 1;
            else
            {
                MessageBox.Show("Kogus on juba 0!");
                return;
            }
            using (SqlCommand command = new SqlCommand(
                "UPDATE Toodetabel SET Kogus=@kogus WHERE Toodenimetus=@nimetus", connect))
            {
                command.Parameters.AddWithValue("@nimetus", nimetus);
                command.Parameters.AddWithValue("@kogus", kogus);

                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
            }
            NaitaAndmed();
            toode_lbl.Text = "1.  " + nimetus + " ................";
        }
        private void muuja_Load(object sender, EventArgs e)
        {

        }

    }
}
