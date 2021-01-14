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
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }


        private void buttonAuth_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
                //da = new SqlDataAdapter($"select * from Employee where login='{textBoxLogin.Text}' and password='{textBoxPassword.Text}'", con);
                da = new SqlDataAdapter(
                    "select " +
                    "Employee.login as Login, " +
                    "Employee.password as Password, " +
                    "Private_Info.first_name as First_Name, " +
                    "Private_Info.last_name as Last_Name, " +
                    "Private_Info.patronymic as Patronymic, " +
                    "Post.name as Post " +
                    "from Employee " +
                    "left join Private_Info on Employee.id_private_info = Private_Info.id " +
                    "left join Post on Employee.id_post = Post.id " +
                    $"where login='{textBoxLogin.Text}' and password='{textBoxPassword.Text}'"
                    , con);

                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Employee");
                con.Close();
                if(ds.Tables["Employee"].Rows[0].ItemArray[0] != null)
                {
                    main m = new main();
                    m.emp = new main.Employees(ds.Tables["Employee"].Rows[0].ItemArray[2].ToString(), ds.Tables["Employee"].Rows[0].ItemArray[3].ToString(), ds.Tables["Employee"].Rows[0].ItemArray[4].ToString(), ds.Tables["Employee"].Rows[0].ItemArray[5].ToString());
                    this.Hide();
                    m.Show();
                }
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /*
        

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
        */
    }
}
