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
    public partial class Form6 : Form
    {
        string connection = "";
        public Form6()
        {
            InitializeComponent();
            connection = "Server=localhost;Database=minimart;username=root;password=root;";
        }

        public void Display()
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from stockcontroller", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void clearall_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        private void save_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO stockcontroller" + "(sc_id, sc_password, sc_name, sc_email, sc_phone)"
                + "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();//to execute insert query 
            con.Close();
            MessageBox.Show("Save Success!");
            Display();
        }

        private void update_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"update stockcontroller set sc_id='" + textBox1.Text + "'," +
                "sc_password = '" + textBox2.Text + "',sc_name='" + textBox3.Text + "',sc_email='" + textBox4.Text + "',sc_phone='" + textBox5.Text + "'" +
                "where(sc_id='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();//to execute insert query 
            con.Close();
            MessageBox.Show("Update Success!");
            Display();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);//create object con 
            con.Open();
            MySqlCommand cmd = new MySqlCommand(@"DELETE FROM stockcontroller where sc_id='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();//to execute Delete query based on primary key as mobile
            con.Close();
            MessageBox.Show("Delete Success!");
            Display();
        }

        private void showall_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from stockcontroller", con);
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
