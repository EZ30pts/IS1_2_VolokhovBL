using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurshac
{
    public partial class MAIN : Form
    {
        public MAIN()
        {
            InitializeComponent();
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            Hide();
            auth MAIN = new auth();
            MAIN.ShowDialog();
            if (authclass.auth)
            {
                Show();
            }
            else
            {
                Close();
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void loadForm(object Form)
        {
            if (panel1.Controls.Count > 0) panel1.Controls.RemoveAt(0);
            Form form = Form as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            panel1.Tag = form;
            form.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadForm(new Katalog());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            loadForm(new Korzina());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            loadForm(new Balans());
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
