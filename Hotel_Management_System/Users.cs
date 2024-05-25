using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hotel_Management_System
{
    public partial class Users : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Users()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\nndas\Documents\Hotel_Management_System.accdb";
        }


        private void btn_check_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from USERS ";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView7.DataSource = DT;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f2 = new Admin();
            f2.Show();
        }

        private void btn_close3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Validation1())
            {
                int count = 0;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select * from USERS where EMP_ID='"+txt_user_eid.Text+"'";
                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
                if (count != 0)
                {
                    MessageBox.Show("Username and Password of selected Employee ID already exists! ", "Warning! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "insert into USERS (USER_NAME, EMP_ID, PER_ID, PSWD) values ('" + txt_user_name.Text + "','"+txt_user_eid.Text+"','"+txt_user_pid.Text+"','"+txt_user_password.Text+"') ";
                        command.CommandText = query;
                        command.ExecuteNonQuery();

                        MessageBox.Show("New UserAdded Successfully! ");

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }

                    
                }

            }
            else 
            {
                MessageBox.Show("All the fields are mandatory! ","Warnimg! ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dataGridView7_SelectionChanged(object sender, EventArgs e)
        {

            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView7.SelectedCells)
            {
                cell = selectedCell;
                break;
            }

            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_uid.Text = row.Cells[0].Value.ToString();
                txt_user_name.Text = row.Cells[1].Value.ToString();
                txt_user_password.Text = row.Cells[2].Value.ToString();
                txt_user_eid.Text = row.Cells[3].Value.ToString();
                txt_user_pid.Text = row.Cells[4].Value.ToString();
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Validation1())
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "update USERS set USER_NAME='" + txt_user_name.Text + "', PSWD='" + txt_user_password.Text + "', EMP_ID='" + txt_user_eid.Text + "', PER_ID='" + txt_user_pid.Text + "' where USER_ID= " + txt_uid.Text + " and NOT PER_ID = '1'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Updated Syccessfully! \n NOTE:- Permission ID with ! will not be Updated");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else 
            {
                MessageBox.Show("All the fields are mandatory! ", "Warnimg! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool Validation1()
        {
            bool isok = true;

            if (String.IsNullOrEmpty(txt_user_name.Text))
            {
                errorProvider1.SetError(txt_user_name, "User_name is Required!");
                isok = false;
            }
            else if (String.IsNullOrEmpty(txt_user_password.Text))
            {
                errorProvider1.SetError(txt_user_password, "Password is Required!");
                isok = false;
            }
            else if (String.IsNullOrEmpty(txt_user_eid.Text))
            {
                errorProvider1.SetError(txt_user_eid, "Employee ID is Required!");
                isok = false;
            }
            else if (String.IsNullOrEmpty(txt_user_pid.Text))
            {
                errorProvider1.SetError(txt_user_pid, "Permission ID is Required!");
                isok = false;
            }

            return isok;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;
            if (String.IsNullOrEmpty(txt_uid.Text))
            {
                errorProvider1.SetError(txt_uid, "User ID is Required! ");
                isok = false;
            }

            if (isok)
            {

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " Delete from USERS where USER_ID=" + txt_uid.Text + " and NOT PER_ID = \"1\"";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Deleted Syccessfully! \n NOTE:- Permission ID with ! will not be Deleted");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("USER ID cannot be Blank! \n Please select it from the avilable Data! ", "Error! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_user_details_clear_Click(object sender, EventArgs e)
        {
            txt_uid.Clear();
            txt_user_eid.Clear();
            txt_user_password.Clear();
            txt_user_pid.Clear();
            txt_user_name.Clear();
            dataGridView7.DataSource = null;
        }
    }
}
