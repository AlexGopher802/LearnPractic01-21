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
    public partial class main : Form
    {
        public int idEmployee;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        int unlockedPage = 0;
        int selectedRowIndex = -1;

        public Employees emp;
        public class Employees
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string patronymic { get; set; }
            public string post { get; set; }

            public Employees(string fn, string ln, string patr, string post)
            {
                this.first_name = fn;
                this.last_name = ln;
                this.patronymic = patr;
                this.post = post;
            }
        }

            public enum PostAcces

            {
                Admin,
                Sklad,
                Cash
            }

        public main()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"insert into Private_Info(first_name, last_name, patronymic) values ('{textBoxFirstName.Text}', '{textBoxLastName.Text}', '{textBoxPatronymic.Text}') " +
                    $"insert into Contacts(phone, email, adress) values ('{textBoxPhone.Text}', '{textBoxEmail.Text}', '{textBoxAdress.Text}') " +
                    $"insert into Employee(login, password, id_post, id_private_info, id_contacts, salary) values " +
                    $"('{textBoxLogin.Text}', '{textBoxPassword.Text}', " +
                    $"(select id from Post where name='{comboBoxPost.SelectedItem}'), " +
                    $"(select id from Private_Info where first_name='{textBoxFirstName.Text}' and last_name='{textBoxLastName.Text}' and patronymic='{textBoxPatronymic.Text}'), " +
                    $"(select id from Contacts where phone='{textBoxPhone.Text}' and email='{textBoxEmail.Text}' and adress='{textBoxAdress.Text}'), {Convert.ToInt32(textBoxSalary.Text)})";
                cmd.ExecuteNonQuery();
                GetList();

                formClear();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                var data = dataGridViewUsers.Rows[selectedRowIndex];
                cmd.CommandText = $"update Employee set login='{textBoxLogin.Text}', password='{textBoxPassword.Text}', salary='{textBoxSalary.Text}', id_post=(select id from Post where name='{comboBoxPost.SelectedItem}') where login='{data.Cells["Login"].Value}'; " +
                    $"update Private_Info set first_name='{textBoxFirstName.Text}', last_name='{textBoxLastName.Text}', patronymic='{textBoxPatronymic.Text}' where first_name='{data.Cells["First_Name"].Value}' and last_name='{data.Cells["Last_Name"].Value}' and patronymic='{data.Cells["Patronymic"].Value}'; " +
                    $"update Contacts set email='{textBoxEmail.Text}', phone='{textBoxPhone.Text}', adress='{textBoxAdress.Text}' where email='{data.Cells["Email"].Value}' and phone='{data.Cells["Phone"].Value}' and adress='{data.Cells["Adress"].Value}; '";
                cmd.ExecuteNonQuery();
                con.Close();
                GetList();

                formClear();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
            }
            finally
            {
                con.Close();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var data = dataGridViewUsers.Rows[selectedRowIndex];
                if (MessageBox.Show($"Вы уверены, что хотите удалить запись о сотруднике \"{data.Cells["Last_Name"].Value} {data.Cells["First_Name"].Value} {data.Cells["Patronymic"].Value} ?\"", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"delete from Employee where login='{data.Cells["Login"].Value}'; " +
                    $"delete from Private_Info where first_name='{data.Cells["First_Name"].Value}' and  last_name='{data.Cells["Last_Name"].Value}' and patronymic='{data.Cells["Patronymic"].Value}'; " +
                    $"delete from Contacts where phone='{data.Cells["Phone"].Value}' and  email='{data.Cells["Email"].Value}' and adress='{data.Cells["Adress"].Value}'; ";
                cmd.ExecuteNonQuery();
                con.Close();
                GetList();

                formClear();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
            }
            finally
            {
                con.Close();
            }
        }

        void formClear()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPatronymic.Clear();
            textBoxLogin.Clear();
            textBoxPassword.Clear();
            textBoxPhone.Clear();
            textBoxEmail.Clear();
            textBoxAdress.Clear();
            textBoxSalary.Clear();
            selectedRowIndex = -1;
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {
            GetList();
            labelInfo.Text = $"{emp.post}: {emp.last_name} {emp.first_name} {emp.patronymic}";

            da = new SqlDataAdapter("select name from Post", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Post");
            con.Close();

            List<string> postList = new List<string>();
            for(int i = 0; i < ds.Tables["Post"].Rows.Count; i++)
            {
                postList.Add(ds.Tables["Post"].Rows[i].ItemArray[0].ToString());
            }
            comboBoxPost.DataSource = postList;

            switch (emp.post)
            {
                case "Администратор":
                    unlockedPage = (int)PostAcces.Admin;
                    break;
                case "Фармацевт":
                    unlockedPage = (int)PostAcces.Cash;
                    break;
                case "Складовщик":
                    unlockedPage = (int)PostAcces.Sklad;
                    break;
            }

            tabControl1.SelectedIndex = unlockedPage;
            formClear();
        }

        void GetList()
        {
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter(
                "select " +
                "Employee.login as Login, " +
                "Employee.password as Password, " +
                "Contacts.email as Email, " +
                "Private_Info.first_name as First_Name, " +
                "Private_Info.last_name as Last_Name, " +
                "Private_Info.patronymic as Patronymic, " +
                "Post.name as Post, " +
                "Employee.salary as Salary, " +
                "Contacts.phone as Phone, " +
                "Contacts.adress as Adress " +
                "from Employee " +
                "left join Contacts on Employee.id_contacts = Contacts.id " +
                "left join Private_Info on Employee.id_private_info = Private_Info.id " +
                "left join Post on Employee.id_post = Post.id "
                , con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Employee");
            dataGridViewUsers.DataSource = ds.Tables["Employee"];
            con.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void dataGridViewUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;

            /*labelInfo.Text = selectedRowIndex.ToString() + " " +
                dataGridViewUsers.Rows[selectedRowIndex].Cells[;*/

            try
            {
                var data = dataGridViewUsers.Rows[e.RowIndex];
                textBoxLogin.Text = data.Cells["Login"].Value.ToString();
                textBoxPassword.Text = data.Cells["Password"].Value.ToString();
                textBoxFirstName.Text = data.Cells["First_Name"].Value.ToString();
                textBoxLastName.Text = data.Cells["Last_Name"].Value.ToString();
                textBoxPatronymic.Text = data.Cells["Patronymic"].Value.ToString();
                textBoxEmail.Text = data.Cells["Email"].Value.ToString();
                textBoxPhone.Text = data.Cells["Phone"].Value.ToString();
                textBoxAdress.Text = data.Cells["Adress"].Value.ToString();
                textBoxSalary.Text = data.Cells["Salary"].Value.ToString();
                comboBoxPost.SelectedItem = data.Cells["Post"].Value.ToString();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPageIndex != unlockedPage)
            {
                e.Cancel = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            formClear();
        }
    }
}
