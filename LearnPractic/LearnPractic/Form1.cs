using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LearnPractic
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetList();
        }

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        void GetList()
        {
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter("select * from Contacts", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Contacts");
            dataGridView.DataSource = ds.Tables["Contacts"];
            con.Close();
        }
        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = String.Format("insert into Contacts(phone, email, mail) values ('{0}', '{1}', '{2}')", textBoxPhone.Text, textBoxEmail.Text, textBoxMail.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }
        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = String.Format("update Contacts set email='{1}', mail='{2}' where phone='{0}'", textBoxPhone.Text, textBoxEmail.Text, textBoxMail.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = String.Format("delete from Contacts where phone='{0}'", textBoxPhone.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
