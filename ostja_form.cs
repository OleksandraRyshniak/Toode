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
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\oleks\Desktop\C#\toode_2\Tooded_DB.mdf");
        SqlCommand command;
        SqlDataAdapter adapter_toode, adapter_kategooria;
        DataTable dt_toode, dt_kat;
        DataTable ostukorv = new DataTable();
        public ostja_form()
        {
            InitializeComponent();
            NaitaAndmed();
            kategooria_list_box();
        }

        public void kategooria_list_box()
        {
            dt_kat = new DataTable();
            adapter_kategooria = new SqlDataAdapter(
                "SELECT Id, Kategooria_nimetus FROM Kategooriatable",
                connect
            );
            adapter_kategooria.Fill(dt_kat);

            list_box.DataSource = dt_kat;
            list_box.DisplayMember = "Kategooria_nimetus";
            list_box.ValueMember = "Id";
        }

        public void NaitaAndmed()
        {
            dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodenimetus, Hind, Kogus FROM Toodetabel WHERE Kogus > 0",connect);    
            adapter_toode.Fill(dt_toode);
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = dt_toode;
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
            if (list_box.SelectedValue == null) return;

            int kategooriaId;

            if (!int.TryParse(list_box.SelectedValue.ToString(), out kategooriaId))
                return;

            DataTable dt_tooted = new DataTable();
            SqlDataAdapter adapter_toode = new SqlDataAdapter(
                "SELECT Toodenimetus, Hind, Kogus FROM Toodetabel WHERE Id = @kat AND Kogus > 0",
                connect
            );

            adapter_toode.SelectCommand.Parameters.AddWithValue("@kat", kategooriaId);
            adapter_toode.Fill(dt_tooted);

            dataGridView2.DataSource = dt_tooted;
        }


        private void muuja_Load(object sender, EventArgs e)
        {

        }

    }
}
