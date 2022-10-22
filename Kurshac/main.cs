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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void main_Load(object sender, EventArgs e)
        {
            Hide();
            auth MAIN = new auth();
            MAIN.ShowDialog();
            if (authclass.auth)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
    }
}
