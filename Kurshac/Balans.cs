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
    public partial class Balans : Form
    {
        public Balans()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int balance = Convert.ToInt32(label3Balance.Text);

            balance += Convert.ToInt32(guna2TextBox1.Text);

            label3Balance.Text = balance.ToString();
            guna2TextBox1.Clear();
        }
    }
}
