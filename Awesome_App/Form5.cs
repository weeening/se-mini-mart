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
    public partial class Form5 : Form
    {
        string connection = "";
        public Form5()
        {
            InitializeComponent();
            connection = "Server=localhost;Database=minimart;username=root;password=root";
        }

        public void Display()
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("select orders.order_id, orders.product_id, product.product_name, orders.vendor_id, vendor.vendor_company from orders, vendor, product where orders.product_id = product.product_id and orders.vendor_id = vendor.vendor_id order by order_id", con);
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
                dataGridView1.Rows[n].Cells[4].Value = Item[4].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu frm = new MainMenu();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO orders" + "(order_id, product_id, vendor_id)"
                + "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();//to execute insert query 
            con.Close();
            MessageBox.Show("Save Successful!");
            Display();
        }

        private void update_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"update orders set order_id='" + textBox1.Text + "'," +
                "product_id = '" + textBox2.Text + "',vendor_id='" + textBox3.Text + "'" +
                "where(order_id='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update Successful!");
            Display();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"DELETE FROM orders where order_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();//to execute Delete query based on primary key as mobile
            con.Close();
            MessageBox.Show("Delete Successful!");
            Display();
        }

        private void showall_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("select orders.order_id, orders.product_id,  product.product_name, orders.vendor_id, vendor.vendor_company from orders, vendor, product where orders.product_id = product.product_id and orders.vendor_id = vendor.vendor_id order by order_id", con);
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
    }
}
