using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kurshac
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_7;database=is_1_20_st7_KURS;password=70179163;";
        MySqlConnection conn;

        private void auth_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
        }
        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public void GetUserInfo(string login_user)
        {
            string selected_id_stud = guna2TextBox1.Text;
            conn.Open();
            string sql = $"SELECT * FROM login_password WHERE login='{login_user}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                authclass.auth_id = reader[0].ToString();
                authclass.auth_fio = reader[1].ToString();
            }
            reader.Close();
            conn.Close();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM login_password WHERE login = @un and  password= @up";
            conn.Open();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            command.Parameters["@un"].Value = guna2TextBox1.Text;
            command.Parameters["@up"].Value = sha256(guna2TextBox2.Text);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            conn.Close();
            if (table.Rows.Count > 0)
            {
                authclass.auth = true;
                GetUserInfo(guna2TextBox1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные данные авторизации!");
            }
        }

    }
}
