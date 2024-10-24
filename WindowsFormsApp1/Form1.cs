using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceTrackerApp
{
    public partial class Form1 : Form
    {
        // MySQL Connection string
        string connectionString = "server=localhost;database=finance_tracker;uid=root;pwd=your_password;";

        public Form1()
        {
            InitializeComponent();
        }

        // Method to execute queries
        private DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return dt;
        }

        // Example: Method to login user
        private bool LoginUser(string username, string password)
        {
            string query = $"SELECT * FROM Users WHERE username='{username}' AND password='{password}'";
            DataTable result = ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}