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
    public partial class Frm_login : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        
        public Frm_login()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nndas\Documents\Hotel_Management_System.accdb";
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;
            if (String.IsNullOrEmpty(tbx_user.Text))
            {
                errorProvider1.SetError(tbx_user, "Username Required! ");
                isok = false;

            }
            else if (String.IsNullOrEmpty(tbx_password.Text))
            {
                errorProvider1.SetError(tbx_password, "Username Required! ");
                isok = false;
            }
            else if (cmb_permission.Text == "Permission")
            {
                errorProvider1.SetError(cmb_permission, " Permission Required! ");
                isok = false;
            }

            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select * from USERS, PERMISSION  where USER_NAME='" + tbx_user.Text + "' and PSWD='" + tbx_password.Text + "' and PER_ID = PID and PROLE='" + cmb_permission.Text + "'";

                    OleDbDataReader reader = command.ExecuteReader();
                    int count = 0;
                    string per = cmb_permission.SelectedItem.ToString();
                    while (reader.Read())
                    {

                        count++;
                    }
                    if (count == 0)
                    {
                        MessageBox.Show("User name or password dosen't match! \n or Permission Denide!");

                        connection.Close();
                    }
                    else
                    {

                        MessageBox.Show("You have logged in Successfully","Information! ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        connection.Close();
                        if (per == "admin")
                        {
                            this.Hide();
                            Admin f2 = new Admin();
                            f2.Show();
                        }
                        else
                        {
                            this.Hide();
                            Recp f3 = new Recp();
                            f3.Show();

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("All fiels are mandatory! ", "Warning! ",MessageBoxButtons.OKCancel ,MessageBoxIcon.Warning );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program?", "Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from PERMISSION ";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cmb_permission.Items.Add(reader["PROLE"].ToString());

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void cmb_permission_Validating(object sender, CancelEventArgs e)
        {
            
        }
    }
}
