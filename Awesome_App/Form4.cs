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
    public partial class Form4 : Form
    {
        string connection = "";
        public Form4()
        {
            InitializeComponent();
            connection = "Server=localhost;Database=minimart;username=root;password=root;";
        }

        public void Display()
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from vendor", con);
            DataTable dt = new DataTable();//pass database table value to local data table
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow Item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = Item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = Item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = Item[3].ToString();
            }
        }

        private void clearall_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO vendor" + "(vendor_id,vendor_contact,vendor_company,vendor_address)"
                + "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
            cmd.ExecuteNonQuery();//to execute insert query 
            con.Close();
            MessageBox.Show("Save Successful!");
            Display();
        }

        private void update_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"update vendor set vendor_id='" + textBox1.Text + "'," +
                "vendor_contact = '" + textBox2.Text + "',vendor_company='" + textBox3.Text + "',vendor_address='" + textBox4.Text + "'" +
                "where(vendor_id='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update Successful!");
            Display();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"DELETE FROM vendor where vendor_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();//to execute Delete query based on primary key as mobile
            con.Close();
            MessageBox.Show("Delete Successful!");
            Display();
        }

        private void showall_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from vendor", con);
            DataTable dt = new DataTable();//pass database table value to local data table
            try
            {
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu frm = new MainMenu();
            frm.Show();
        }
    }
}
