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
using Excel = Microsoft.Office.Interop.Excel;

namespace LearnPractic
{
    public partial class main : Form
    {
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Worksheet xlSheet;
        Microsoft.Office.Interop.Excel.Range xlSheetRange;

        public int idEmployee;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        int unlockedPage = 0;
        int selectedRowIndex = -1;
        int rowGenerated = 0;

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
        /*
        public enum PostAcces

        {
            Admin,
            Sklad,
            Cash,
            HR,
            Purchase
        }
        */
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
                GetListEmployee();

                formEmployeeClear();
                con.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
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
                GetListEmployee();

                formEmployeeClear();
                con.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
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
                GetListEmployee();

                formEmployeeClear();
                con.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        void formEmployeeClear()
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
            comboBoxPost.SelectedItem = null;
            selectedRowIndex = -1;
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {
            labelInfo.Text = $"{emp.post}: {emp.last_name} {emp.first_name} {emp.patronymic}";
            
            switch (emp.post)
            {
                case "Администратор":
                    unlockedPage = 0;
                    break;
                case "HR Менеджер":
                    unlockedPage = 0;
                    break;
                case "Товаровед":
                    unlockedPage = 1;
                    break;
                case "Фармацевт":
                    unlockedPage = 2;
                    break;
                case "Организатор закупок":
                    unlockedPage = 3;
                    break;
            }
            tabControl1.SelectedIndex = unlockedPage;
        }

        void GetListEmployee()
        {
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter(
                "select " +
                "Employee.login as Login, " +
                "Employee.password as Password, " +
                "Post.name as Post, " +
                "Private_Info.first_name as First_Name, " +
                "Private_Info.last_name as Last_Name, " +
                "Private_Info.patronymic as Patronymic, " +
                "Contacts.email as Email, " +
                "Employee.salary as Salary, " +
                "Contacts.phone as Phone, " +
                "Contacts.adress as Adress, " +
                "Employee.id as Id " +
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
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if ((e.TabPageIndex != unlockedPage) && (emp.post != "Администратор"))
            {
                e.Cancel = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            formEmployeeClear();
        }

        private void checkAvalDrug_CheckedChanged(object sender, EventArgs e)
        {
            formDrugPurchaseClear();
            comboBoxDrugPurchase.SelectedItem = null;
            comboBoxDrugPurchase.Enabled = checkAvalDrug.Checked;
            textBoxDrugNamePurchase.Enabled = !checkAvalDrug.Checked;
            richTextBoxDrugCompositionPurchase.Enabled = !checkAvalDrug.Checked;
            richTextBoxRecipeDrugPurchase.Enabled = !checkAvalDrug.Checked;
            UDPriceBuy.Enabled = !checkAvalDrug.Checked;
        }

        private void checkAvalCounterparty_CheckedChanged(object sender, EventArgs e)
        {
            formCounterpartyClear();
            comboBoxCounterpartys.SelectedItem = null;
            comboBoxCounterpartys.Enabled = checkAvalCounterparty.Checked;
            textBoxCounterName.Enabled = !checkAvalCounterparty.Checked;
            textBoxCounterPhone.Enabled = !checkAvalCounterparty.Checked;
            textBoxCounterEmail.Enabled = !checkAvalCounterparty.Checked;
            textBoxCounterAddress.Enabled = !checkAvalCounterparty.Checked;
            textBoxCounterBankScore.Enabled = !checkAvalCounterparty.Checked;
            textBoxCounterINN.Enabled = !checkAvalCounterparty.Checked;
        }

        private void tabPageEmployee_Enter(object sender, EventArgs e)
        {
            GetListEmployee();
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter("select name from Post", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Post");
            con.Close();

            List<string> postList = new List<string>();
            for (int i = 0; i < ds.Tables["Post"].Rows.Count; i++)
            {
                postList.Add(ds.Tables["Post"].Rows[i].ItemArray[0].ToString());
            }
            comboBoxPost.DataSource = postList;

            formEmployeeClear();
        }

        private void tabPageSklad_Enter(object sender, EventArgs e)
        {
            GetListSklad();
            formSkladClear();
        }

        void GetListSklad()
        {
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter(
                "select " +
                "Drug.name as Drug_Name, " +
                "Sklad.quantity as Quantity, " +
                "Drug.price_buy as Price_Buy, " +
                "Drug.price_sell as Price_Sell, " +
                "Drug.composition as Composition, " +
                "Drug.recipe as Recipe " +
                "from Sklad " +
                "left join Drug on Sklad.id_drug = Drug.id "
                , con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Sklad");
            dataGridViewSklad.DataSource = ds.Tables["Sklad"];
            con.Close();
        }

        private void dataGridViewSklad_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;

            try
            {
                var data = dataGridViewSklad.Rows[e.RowIndex];
                textBoxDrugName.Text = data.Cells["Drug_Name"].Value.ToString();
                drugQuantityInfo.Text = data.Cells["Quantity"].Value.ToString();
                TextBoxComposits.Text = data.Cells["Composition"].Value.ToString();
                TextBoxRecipe.Text = data.Cells["Recipe"].Value.ToString();
                UDPriceSell.Value = (int)data.Cells["Price_Sell"].Value;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        void formSkladClear()
        {
            textBoxDrugName.Clear();
            TextBoxComposits.Clear();
            TextBoxRecipe.Clear();
            drugQuantityInfo.Text = "";
            selectedRowIndex = -1;
        }

        private void buttonDrugClear_Click(object sender, EventArgs e)
        {
            formSkladClear();
        }

        bool checkValidFormPurchase()
        {
            if((textBoxDrugNamePurchase.Text) != "" && (richTextBoxDrugCompositionPurchase.Text != "") && (richTextBoxRecipeDrugPurchase.Text != "") && (UDQuantityPurchase.Value > 0) && (UDPriceBuy.Value > 0))
            {
                if((textBoxCounterName.Text != "") && (textBoxCounterPhone.Text != "") && (textBoxCounterEmail.Text != "") && (textBoxCounterAddress.Text != "") && (textBoxCounterBankScore.Text != "") && (textBoxCounterINN.Text != ""))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Форма контрагента не заполнена.", "Ошибка");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Форма препарата не заполнена.", "Ошибка");
                return false;
            }
        }

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            if (!checkValidFormPurchase()) { return; }
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            try
            {
                if (checkAvalDrug.Checked)
                {
                    cmd.CommandText = $"update Sklad set quantity = quantity + {UDQuantityPurchase.Value} " +
                        $"where id_drug = (select id from Drug where name='{comboBoxDrugPurchase.SelectedItem}'); ";
                }
                else
                {
                    cmd.CommandText = $"insert into Drug(name, composition, recipe, price_buy) values ('{textBoxDrugNamePurchase.Text}', '{richTextBoxDrugCompositionPurchase.Text}', '{richTextBoxRecipeDrugPurchase.Text}', {(int)UDPriceBuy.Value}); " +
                    $"insert into Sklad(id_drug, quantity) values ((select id from Drug where name='{textBoxDrugNamePurchase.Text}'), {(int)UDQuantityPurchase.Value}) ";
                }
                cmd.ExecuteNonQuery();

                if (!checkAvalCounterparty.Checked)
                {
                    cmd.CommandText = $"insert into Contacts(phone, email, adress) values ('{textBoxCounterPhone.Text}', '{textBoxCounterEmail.Text}', '{textBoxCounterAddress.Text}'); " +
                    $"insert into Counterparty(name, bank_score, inn, id_contacts) values ('{textBoxCounterName.Text}', '{textBoxCounterBankScore.Text}', '{textBoxCounterINN.Text}', " +
                    $"(select id from Contacts where phone='{textBoxCounterPhone.Text}' and email='{textBoxCounterEmail.Text}' and adress='{textBoxCounterAddress.Text}')); ";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = $"insert into Pact(quantity, summa, date_time, id_counterparty, id_sklad) values (" +
                    $"{(int)UDQuantityPurchase.Value}, {(int)UDQuantityPurchase.Value * (int)UDPriceBuy.Value}, '{DateTime.Now}', " +
                    $"(select id from Counterparty where name='{textBoxCounterName.Text}'), " +
                    $"(select id from Sklad where id_drug=(select id from Drug where name='{textBoxDrugNamePurchase.Text}'))); ";
                cmd.ExecuteNonQuery();

                con.Close();

                GetListSklad();
                formDrugPurchaseClear();
                formCounterpartyClear();
                MessageBox.Show("Заказ успешно оформлен.", "Успех");

                tabPagePurchase_Enter(sender, e);

                generateExcelCheck(false, false);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        void formDrugPurchaseClear()
        {
            comboBoxDrugPurchase.SelectedItem = null;
            textBoxDrugNamePurchase.Clear();
            UDQuantityPurchase.Value = 0;
            richTextBoxDrugCompositionPurchase.Clear();
            richTextBoxRecipeDrugPurchase.Clear();
            UDPriceBuy.Value = 0;
        }

        private void ClearFormDrugPurchase_Click(object sender, EventArgs e)
        {
            formDrugPurchaseClear();
        }

        void formCounterpartyClear()
        {
            comboBoxCounterpartys.SelectedItem = null;
            textBoxCounterName.Clear();
            textBoxCounterPhone.Clear();
            textBoxCounterEmail.Clear();
            textBoxCounterAddress.Clear();
            textBoxCounterBankScore.Clear();
            textBoxCounterINN.Clear();
        }

        private void ClearFormCounterpartyPurchase_Click(object sender, EventArgs e)
        {
            formCounterpartyClear();
        }

        private void tabPagePurchase_Enter(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter("select name from Drug", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Drug");
            con.Close();

            List<string> drugList = new List<string>();
            for (int i = 0; i < ds.Tables["Drug"].Rows.Count; i++)
            {
                drugList.Add(ds.Tables["Drug"].Rows[i].ItemArray[0].ToString());
            }
            comboBoxDrugPurchase.DataSource = drugList;

            da = new SqlDataAdapter("select name from Counterparty", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Counterparty");
            con.Close();

            List<string> counterList = new List<string>();
            for (int i = 0; i < ds.Tables["Counterparty"].Rows.Count; i++)
            {
                counterList.Add(ds.Tables["Counterparty"].Rows[i].ItemArray[0].ToString());
            }
            comboBoxCounterpartys.DataSource = counterList;

            comboBoxDrugPurchase.SelectedItem = null;
            comboBoxCounterpartys.SelectedItem = null;

            formDrugPurchaseClear();
            formCounterpartyClear();
        }

        private void comboBoxDrugPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxDrugPurchase.SelectedItem == null) { return; }
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter("select Drug.name as Drug_Name, " +
                "Drug.composition as Composition, " +
                "Drug.recipe as Recipe, " +
                "Sklad.quantity as Quantity, " +
                "Drug.price_buy as Price " +
                "from Sklad " +
                "left join Drug on Sklad.id_drug = Drug.id " +
                $"where Drug.name='{comboBoxDrugPurchase.SelectedItem}' ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Sklad");
            con.Close();

            textBoxDrugNamePurchase.Text = ds.Tables["Sklad"].Rows[0].ItemArray[0].ToString();
            richTextBoxDrugCompositionPurchase.Text = ds.Tables["Sklad"].Rows[0].ItemArray[1].ToString();
            richTextBoxRecipeDrugPurchase.Text = ds.Tables["Sklad"].Rows[0].ItemArray[2].ToString();
            UDPriceBuy.Value = (int)ds.Tables["Sklad"].Rows[0].ItemArray[4];
        }

        private void comboBoxCounterpartys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCounterpartys.SelectedItem == null) { return; }
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter("select Counterparty.name as Name, " +
                "Counterparty.bank_score as Bank_Score, " +
                "Counterparty.inn as INN, " +
                "Contacts.phone as Phone, " +
                "Contacts.email as Email, " +
                "Contacts.adress as Adress " +
                "from Counterparty " +
                "left join Contacts on Counterparty.id_contacts = Contacts.id " +
                $"where Counterparty.name='{comboBoxCounterpartys.SelectedItem}' ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Counterparty");
            con.Close();

            textBoxCounterName.Text = ds.Tables["Counterparty"].Rows[0].ItemArray[0].ToString();
            textBoxCounterBankScore.Text = ds.Tables["Counterparty"].Rows[0].ItemArray[1].ToString();
            textBoxCounterINN.Text = ds.Tables["Counterparty"].Rows[0].ItemArray[2].ToString();
            textBoxCounterPhone.Text = ds.Tables["Counterparty"].Rows[0].ItemArray[3].ToString();
            textBoxCounterEmail.Text = ds.Tables["Counterparty"].Rows[0].ItemArray[4].ToString();
            textBoxCounterAddress.Text = ds.Tables["Counterparty"].Rows[0].ItemArray[5].ToString();
        }

        private void buttonDrugDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var data = dataGridViewSklad.Rows[selectedRowIndex];
                if (MessageBox.Show($"Вы уверены, что хотите удалить запись о товаре \"{data.Cells["Drug_Name"].Value} ?\"", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"delete from Sklad where id_drug=(select id from Drug where name='{data.Cells["Drug_Name"].Value}'); " +
                    $"delete from Drug where name='{data.Cells["Drug_Name"].Value}'; ";
                cmd.ExecuteNonQuery();
                con.Close();

                GetListSklad();
                formSkladClear();
                con.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        private void buttonDrugChange_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                var data = dataGridViewSklad.Rows[selectedRowIndex];
                cmd.CommandText = $"update Drug set name='{textBoxDrugName.Text}', composition='{TextBoxComposits.Text}', recipe='{TextBoxRecipe.Text}', price_sell={(int)UDPriceSell.Value} where name='{data.Cells["Drug_Name"].Value}'; ";
                cmd.ExecuteNonQuery();
                con.Close();

                GetListSklad();
                formSkladClear();
                con.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
        }

        void formCartClear()
        {
            comboBoxDrugNameToCart.SelectedItem = null;
            UDQuantityDrugToCart.Value = 0;
            labelSumToCart.Text = "0";
        }

        void clearDataCart()
        {
            dataGridViewCart.Rows.Clear();
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.Columns.Add("Drug Name", "Drug Name");
            dataGridViewCart.Columns.Add("Quantity", "Quantity");
            dataGridViewCart.Columns.Add("Sum", "Sum");
        }

        private void tabPageCash_Enter(object sender, EventArgs e)
        {
            clearDataCart();
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter("select name from Drug", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Drug");
            con.Close();

            List<string> drugList = new List<string>();
            for (int i = 0; i < ds.Tables["Drug"].Rows.Count; i++)
            {
                drugList.Add(ds.Tables["Drug"].Rows[i].ItemArray[0].ToString());
            }
            comboBoxDrugNameToCart.DataSource = drugList;

            comboBoxDrugNameToCart.SelectedItem = null;
            formCartClear();
        }

        private void comboBoxDrugNameToCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrugNameToCart.SelectedItem == null) { return; }
            con = new SqlConnection(@"Data Source=localhost;Initial Catalog=LearnPractic;Integrated Security=True");
            da = new SqlDataAdapter("select " +
                "Sklad.quantity as Quantity, " +
                "Drug.price_sell as Price " +
                "from Sklad " +
                "left join Drug on Sklad.id_drug = Drug.id " +
                $"where Drug.name='{comboBoxDrugNameToCart.SelectedItem}' ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Sklad");
            con.Close();

            UDQuantityDrugToCart.Maximum = (int)ds.Tables["Sklad"].Rows[0].ItemArray[0];
        }

        private void UDQuantityDrugToCart_ValueChanged(object sender, EventArgs e)
        {
            labelSumToCart.Text = ((int)UDQuantityDrugToCart.Value * (int)ds.Tables["Sklad"].Rows[0].ItemArray[1]).ToString();
        }

        private void buttonClearFormCart_Click(object sender, EventArgs e)
        {
            formCartClear();
        }

        bool checkValidFormCart()
        {
            if(UDQuantityDrugToCart.Value > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Корректно заполните поля формы", "Ошибка");
                return false;
            }
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (!checkValidFormCart()) { return; }

            dataGridViewCart.Rows.Add();
            int countRows = dataGridViewCart.Rows.Count;
            dataGridViewCart.Rows[countRows - 1].Cells["Drug Name"].Value = comboBoxDrugNameToCart.SelectedItem.ToString();
            dataGridViewCart.Rows[countRows - 1].Cells["Quantity"].Value = (int)UDQuantityDrugToCart.Value;
            string cashString = labelSumToCart.Text.ToString();
            dataGridViewCart.Rows[countRows - 1].Cells["Sum"].Value = Convert.ToInt32(cashString);

            int allSum = 0;
            foreach(DataGridViewRow i in dataGridViewCart.Rows)
            {
                allSum += (int)i.Cells["Sum"].Value;
            }
            labelAllSumCart.Text = allSum.ToString();
            formCartClear();
        }

        private void buttonBuyCart_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                foreach (DataGridViewRow i in dataGridViewCart.Rows)
                {
                    cmd.CommandText = $"update Sklad set quantity = quantity - {(int)i.Cells["Quantity"].Value} where id_drug=(select id from Drug where name='{i.Cells["Drug Name"].Value}'); ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $"insert into Tab(quantity, summa, date_time, id_sklad, id_employee) " +
                        $"values ({(int)i.Cells["Quantity"].Value}, {(int)i.Cells["Sum"].Value}, '{DateTime.Now}', " +
                        $"(select id from Sklad where id_drug=(select id from Drug where name='{i.Cells["Drug Name"].Value}')), " +
                        $"(select id from Employee where id_private_info=(select id from Private_Info where first_name='{emp.first_name}' and last_name='{emp.last_name}' and patronymic='{emp.patronymic}'))); ";
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                rowGenerated = dataGridViewCart.Rows.Count;
                formCartClear();
                clearDataCart();

                MessageBox.Show("Заказ успешно оформлен.", "Успех");

                generateExcelCheck(true, false);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка");
                con.Close();
            }
            
        }

        private void buttonDropCart_Click(object sender, EventArgs e)
        {
            clearDataCart();
        }


        private DataTable GetData(bool all)
        {
            DataTable dt = new DataTable();
            try
            {
                string str = $"top {rowGenerated} ";
                if (all) { str = ""; }
                da = new SqlDataAdapter($"select {str}" +
                "Drug.name as Препарат, " +
                "Tab.quantity as Количество, " +
                "Tab.summa as Сумма, " +
                "Tab.date_time as Дата, " +
                "Private_Info.last_name as Фамилия_сотрудника, " +
                "Private_Info.first_name as Имя_сотрудника " +
                "from Tab " +
                "left join Sklad on Tab.id_sklad = Sklad.id " +
                "left join Drug on Sklad.id_drug = Drug.id " +
                "left join Employee on Tab.id_employee = Employee.id " +
                "left join Private_Info on Employee.id_private_info = Private_Info.id " +
                $"order by Tab.id desc ", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Tab");
                dt = ds.Tables["Tab"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dt;
        }

        private DataTable GetDataPurchase(bool all)
        {
            DataTable dt = new DataTable();
            try
            {
                string str = "top 1 ";
                if(all) { str = ""; }
                da = new SqlDataAdapter($"select {str}" +
                "Counterparty.name as Контрагент, " +
                "Drug.name as Препарат, " +
                "Pact.quantity as Количество, " +
                "Pact.summa as Сумма, " +
                "Pact.date_time as Дата " +
                "from Pact " +
                "left join Sklad on Pact.id_sklad = Sklad.id " +
                "left join Drug on Sklad.id_drug = Drug.id " +
                "left join Counterparty on Pact.id_counterparty = Counterparty.id " +
                $"order by Pact.id desc ", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Pact");
                dt = ds.Tables["Pact"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dt;
        }

        void generateExcelCheck(bool tab, bool all)
        {
            xlApp = new Excel.Application();

            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                xlSheet.Name = "Данные";

                //Выгрузка данных
                DataTable dt = new DataTable();
                if (tab) { dt = GetData(all); }
                else { dt = GetDataPurchase(all);  }

                int collInd = 0;
                int rowInd = 0;
                string data = "";

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }

                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

                //Отсоединяемся от Excel
                releaseObject(xlSheetRange);
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }
        }

        //Освобождаем ресуры (закрываем Excel)
        void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void buttonAllTabs_Click(object sender, EventArgs e)
        {
            generateExcelCheck(true, true);
        }

        private void buttonAllPurchases_Click(object sender, EventArgs e)
        {
            generateExcelCheck(false, true);
        }
    }
}
