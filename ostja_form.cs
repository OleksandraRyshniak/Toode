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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace epood_toode
{
    public partial class ostja_form : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\epood\Tooded_DB.mdf");
        SqlCommand command;
        SqlDataAdapter adapter_toode, adapter_kategooria;
        DataTable dt_toode;
        DataTable ostukorv = new DataTable();


        int Id = 0;
        int kogus = 0;
        int kogus_naitamine = 0;

        public ostja_form()
        {
            InitializeComponent();
            NaitaAndmed();
            text_box.Items.Add("Kollane");
            lb.Items.Add("Rosa");
            lb.Items.Add("Roheline");
            lb.Items.Add("Punane");
            lb.Items.Add("Sinine");
        }

        public void NaitaAndmed()
        {
            
            dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodenimetus, Hind, Kogus FROM Toodetabel WHERE Kogus > 0",connect);    
            adapter_toode.Fill(dt_toode);
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
        }

        private void lisa_toode_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Valige toode!");
                return;
            }

            string nimetus = dataGridView1.SelectedRows[0].Cells["Toodenimetus"].Value.ToString();
            decimal hind = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Hind"].Value);
            int kogus_baas = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Kogus"].Value);


            if (kogus_baas <= 0)
            {
                MessageBox.Show("Kogus on 0!");
                return;
            }
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Toodetabel SET Kogus = Kogus - 1 WHERE Toodenimetus=@n", connect))
            {
                cmd.Parameters.AddWithValue("@n", nimetus);

                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            bool found = false;

            foreach (DataRow r in ostukorv.Rows)
            {
                if (r["Toodenimetus"].ToString() == nimetus)
                {
                    r["Kogus"] = Convert.ToInt32(r["Kogus"]) + 1;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                DataRow row = ostukorv.NewRow();
                row["Toodenimetus"] = nimetus;
                row["Hind"] = hind;
                row["Kogus"] = 1;
                ostukorv.Rows.Add(row);
            }
            NaitaAndmed();
        }

        private void list_box_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void muuja_Load(object sender, EventArgs e)
        {

        }

    }
}
