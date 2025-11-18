using System;
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

namespace epood_tooded
{
    public partial class muuja_form : Form
    {
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Ryshniak\Epood_Tooded\Tooded_DB.mdf;Integrated Security=True");
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\oleks\Desktop\C#\epood_tooded\epood_tooded\Tooded_DB.mdf");
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\epood_toode\Tooded_DB.mdf");
        SqlCommand command;
        SqlDataAdapter adapter_toode, adapter_kategooria;
        public muuja_form()
        {
            InitializeComponent();
            NaitaKategooriad();
            NaitaAndmed();
        }

        SaveFileDialog save;
        OpenFileDialog open;
        string extension = null;
        int Id = 0;
        byte[] imageData;

        public void NaitaKategooriad()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM Kategooriatable", connect);
            System.Data.DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!kat_com_box.Items.Contains(item["Kategooria_nimetus"]))
                {
                    kat_com_box.Items.Add(item["Kategooria_nimetus"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM Kategooriatable WHERE Id=@id", connect);
                    command.Parameters.AddWithValue("@id", item["Id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();
        }
        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodetabel.Id, Toodetabel.Toodenimetus, Toodetabel.Kogus," +
                " Toodetabel.Hind, Toodetabel.Pilt, Toodetabel.Bpilt, Kategooriatable.Kategooria_nimetus" +
                " as Kategooria_nimetus FROM Toodetabel INNER JOIN Kategooriatable ON Toodetabel.Kategooriad=Kategooriatable.Id", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.DataPropertyName = "Kategooria_nimetus";
            HashSet<string> keys = new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
            {
                string kat_n = item["Kategooria_nimetus"].ToString();
                if (!keys.Contains(kat_n))
                {
                    keys.Add(kat_n);
                    combo_kat.Items.Add(kat_n);
                }
            }
            dataGridView1.Columns.Add(combo_kat);
            // pb.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"C:\Users\opilane\source\repos\Ryshniak\Epood_Tooted\images"), "pood.png"));
            pb.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"C:\Users\opilane\source\repos\epood_toode\images"), "pood.png"));
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            connect.Close();
        }
        private void lisa_kat_btn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var items in kat_com_box.Items)
            {
                if (items.ToString() == kat_com_box.Text)
                {
                    on = true;

                }
            }
            if (on == false)
            {
                command = new SqlCommand("INSERT INTO Kategooriatable (Kategooria_nimetus) VALUES (@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", kat_com_box.Text);
                command.ExecuteNonQuery();
                connect.Close();
                kat_com_box.Items.Clear();
                NaitaKategooriad();
            }
            else
            {
                MessageBox.Show("Selline kategooriat on juba olemas!");
            }
        }
        private void kustuta_kat_btn_Click(object sender, EventArgs e)
        {
            if (kat_com_box.SelectedItem != null)
            {
                connect.Open();
                string kat_val = kat_com_box.SelectedItem.ToString();
                command = new SqlCommand("DELETE FROM Kategooriatable WHERE Kategooria_nimetus=@kat", connect);
                command.Parameters.AddWithValue("@kat", kat_val);
                command.ExecuteNonQuery();
                connect.Close();
                kat_com_box.Items.Clear();
                NaitaKategooriad();
            }
        }
        private void lisa_btn_Click(object sender, EventArgs e)
        {
            if (toode_text_box.Text.Trim() != string.Empty &&
                kogus_text_box.Text.Trim() != string.Empty &&
                hind_text_box.Text.Trim() != string.Empty && kat_com_box.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    command = new SqlCommand("SELECT Id FROM Kategooriatable WHERE Kategooria_nimetus=@kat", connect);
                    command.Parameters.AddWithValue("@kat", kat_com_box.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());
                    command = new SqlCommand("INSERT INTO Toodetabel (Toodenimetus, Kogus, Hind, Pilt, Bpilt, Kategooriad)"
                        +
                        "VALUES(@toode, @kogus, @hind, @pilt, @bpilt, @kat)", connect);
                    command.Parameters.AddWithValue("@toode", toode_text_box.Text);
                    command.Parameters.AddWithValue("@kogus", kogus_text_box.Text);
                    command.Parameters.AddWithValue("@hind", hind_text_box.Text);
                    extension = Path.GetExtension(open.FileName);
                    command.Parameters.AddWithValue("@pilt", toode_text_box.Text + extension);
                    imageData = File.ReadAllBytes(open.FileName);
                    command.Parameters.AddWithValue("@bpilt", imageData);
                    command.Parameters.AddWithValue("@kat", Id);
                    command.ExecuteNonQuery();
                    connect.Close();
                    NaitaAndmed();
                    puhasta_btn_Click(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad!");
            }
        }
        private void uuenda_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            }
            if (toode_text_box.Text != "" && kogus_text_box.Text != "" && hind_text_box.Text != "" && pb.Image != null)
            {
                int Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                string file_pilt = toode_text_box.Text + extension;
                MemoryStream ms = new MemoryStream();
                pb.Image.Save(ms, pb.Image.RawFormat);
                byte[] imgBytes = ms.ToArray();

                using (SqlCommand command = new SqlCommand(
                "UPDATE Toodetabel SET Toodenimetus=@toode, Kogus=@kogus, Hind=@hind, Pilt=@pilt, BPilt=@BPilt WHERE Id=@id",
                connect))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@toode", toode_text_box.Text);
                    command.Parameters.AddWithValue("@kogus", Convert.ToInt32(kogus_text_box.Text));
                    command.Parameters.AddWithValue("@hind", Convert.ToDouble(hind_text_box.Text));
                    command.Parameters.AddWithValue("@pilt", file_pilt);
                    command.Parameters.Add("@BPilt", SqlDbType.VarBinary).Value = imgBytes;

                    connect.Open();
                    command.ExecuteNonQuery();
                    connect.Close();
                }
                NaitaAndmed();
                MessageBox.Show("Andmed uuendatud");
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad ja lisa pilt");
            }
        }
        private void kustuta_btn_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            MessageBox.Show(Id.ToString());
            if (Id != 0)
            {
                command = new SqlCommand("DELETE Toodetabel WHERE Id=@id", connect);
                connect.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
                connect.Close();

                NaitaAndmed();

                MessageBox.Show("Andmed tabelist Tooded on kustutatud");
            }
            else
            {
                MessageBox.Show("Viga Tooded tabelist andmete kustutamiega");
            }
        }
        private void puhasta_btn_Click(object sender, EventArgs e)
        {
            toode_text_box.Text = "";
            kogus_text_box.Text = "";
            hind_text_box.Text = "";
            kat_com_box.SelectedItem = null;

            //using (FileStream fs = new FileStream(Path.Combine(Path.GetFullPath(@"C:\Users\opilane\source\repos\Ryshniak\Epood_Tooded\Images"), "pood.png"), FileMode.Open, FileAccess.Read))
            using (FileStream fs = new FileStream(Path.Combine(Path.GetFullPath(@"C:\Users\opilane\source\repos\epood_toode\images"), "pood.png"), FileMode.Open, FileAccess.Read))
            {
                pb.Image = Image.FromStream(fs);
            }
        }
        private void otsi_fail_btn_Click(object sender, EventArgs e)
        {
            if (toode_text_box.Text == "")
            {
                MessageBox.Show("Palun sisesta toode nimetus enne pildi valimist!");
                return;
            }
            open = new OpenFileDialog();
            // open.InitialDirectory = @"C:\Kasutaja\opilane\source\repos\Ryshniak\Epood_Tooded\Picture";
            open.InitialDirectory = @"C:\Users\oleks\Desktop\C#\epood_tooded\epood_tooded\epood_pic";
            open.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";

            FileInfo open_info = new FileInfo(@"C:\Users\opilane\source\repos\epood_toode\images" + open.FileName);
            if (open.ShowDialog() == DialogResult.OK && toode_text_box.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\images");
                save.FileName = toode_text_box.Text + Path.GetExtension(open.FileName);
                save.Filter = "Images" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK && toode_text_box != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    pb.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või oli vajutatud Cancel");
            }
        }
        Form popupForm;
        private void Loopilt(Image image, int r)
        {
            popupForm = new Form();
            popupForm.FormBorderStyle = FormBorderStyle.None;
            popupForm.StartPosition = FormStartPosition.Manual;
            popupForm.Size = new Size(200, 200);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            popupForm.Controls.Add(pictureBox);

            System.Drawing.Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(4, r, true);
            System.Drawing.Point popupLocation = dataGridView1.PointToScreen(cellRectangle.Location);

            popupForm.Location = new System.Drawing.Point(popupLocation.X + cellRectangle.Width, popupLocation.Y);
            popupForm.Show();
        }
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                imageData = dataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image img = Image.FromStream(ms);
                        Loopilt(img, e.RowIndex);
                    }
                }
            }
        }
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (popupForm != null && !popupForm.IsDisposed)
            {
                popupForm.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

