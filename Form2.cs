using epood_tooded;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epood_toode
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void ostja_btn_Click(object sender, EventArgs e)
        {
            ostja_form Ostja = new ostja_form();
            Ostja.Show();
        }

        private void muuja_btn_Click(object sender, EventArgs e)
        {
            muuja_form Muuja = new muuja_form();
            Muuja.Show();
        }

        private void epood_lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
