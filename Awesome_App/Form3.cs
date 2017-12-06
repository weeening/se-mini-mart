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
    public partial class Form3 : Form
    {
        string connection = "";
        public Form3()
        {
            InitializeComponent();
            connection = "Server=localhost;Database=minimart;username=root;password=root;";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO product" + "(product_id,product_name,product_price,product_categories,product_quantity,vendor_id)"
                + "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','"+ textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();//to execute insert query 
            con.Close();
            MessageBox.Show("Save Successful!");
            Display();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"update product set product_id='" + textBox1.Text + "'," +
                "product_name = '" + textBox2.Text + "',product_price='" + textBox3.Text + "',product_categories='" + comboBox1.Text + "',product_quantity='" + textBox4.Text + "',vendor_id='" + textBox5.Text + "'" +
                "where(product_id='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update Successful!");
            Display();
        }
        public void Display()
        {

            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from product", con);
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
                dataGridView1.Rows[n].Cells[5].Value = Item[5].ToString();
            }
        }



        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void showall_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from product", con);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"DELETE FROM product where product_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();//to execute Delete query based on primary key as mobile
            con.Close();
            MessageBox.Show("Delete Successful!");
            Display();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu frm = new MainMenu();
            frm.Show();
        }

        
    }
}
