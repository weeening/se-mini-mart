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

namespace Awesome_App
{
    public partial class Form1 : Form
    {
        string connection = "";
        public Form1()
        {
            InitializeComponent();
            connection = "datasource=localhost; port=3306;username=root;password=root";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("select * from minimart.admin where admin_id='" + this.username_txt.Text + "' and admin_password='" + this.password_txt.Text + "'; ", con);

                MySqlDataReader myReader;
                con.Open();
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Welcome Dear Admin");
                    this.Hide();
                    Form6 f2 = new Form6();
                    f2.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate Enter! Please Try Again");
                }
                else
                    MessageBox.Show("Access Denied! Please Try Again");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("select * from minimart.stockcontroller where sc_id='" + this.username_txt.Text + "' and sc_password='" + this.password_txt.Text + "'; ", con);

                MySqlDataReader myReader;
                con.Open();
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Welcome Dear Staff");
                    this.Hide();
                    MainMenu f3 = new MainMenu();
                    f3.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate Enter! Please Try Again");
                }
                else
                    MessageBox.Show("Access Denied! Please Try Again");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
