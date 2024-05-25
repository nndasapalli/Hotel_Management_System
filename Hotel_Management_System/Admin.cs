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
using System.Text.RegularExpressions;

namespace Hotel_Management_System
{
    public partial class Admin : Form
    {
        
        private OleDbConnection connection = new OleDbConnection();
        public Admin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nndas\Documents\Hotel_Management_System.accdb";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=100009483912455");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/naveen.dasapalli/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/naveen-dasapalli-5b7603120/");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/nndasapalli");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCR8PxvEr2jEc45VlAhktAOg");
        }

        private void btn_close2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_emp_details_Click(object sender, EventArgs e)
        {

            pnl_add.Visible = false;
            pnl_c.Hide();
            pnl_booking.Hide();
            pnl_billing.Hide();
            pnl_main.Hide();
            pnl_right.Visible = true;
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from EMPLOYEE";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView1.DataSource = DT;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (Validation1())
            {
                if (Validation1_email())
                {
                    int count = 0;
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "select * from EMPLOYEE where EID='"+txt_eid.Text+"'";
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
                        errorProvider1.SetError(txt_eid, "Employee ID already exists! ");
                        MessageBox.Show("Employee ID already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            connection.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            string query = "insert into EMPLOYEE (EID, ENAME, AGE, PHONE, ADDRESS, EMAIL, JOB_ROLE, JOINING_DATE, SALARY, SEX) values ('" + txt_eid.Text + "','" + txt_ename.Text + "','" + txt_age.Text + "','" + txt_phone.Text + "','" + txt_address.Text + "','" + txt_email.Text + "','" + cmb_job_role.Text + "','" + txt_joining_date.Text + "','" + txt_salary.Text + "', '"+cmb_esex.Text+"') ";
                            command.CommandText = query;
                            command.ExecuteNonQuery();

                            MessageBox.Show("New Employee Added Successfully! ");

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
                    MessageBox.Show("Email should contain \"@\"", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                
            }
            else 
            {
                
                    MessageBox.Show("All the fields are mandatory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_new_emp_Click(object sender, EventArgs e)
        {
            pnl_right.Visible = false;
            pnl_c.Hide();
            pnl_booking.Hide();
            pnl_billing.Hide();
            pnl_main.Hide();
            pnl_add.Visible = true;
            
        }

        private void btn_booking_Click(object sender, EventArgs e)
        {
            pnl_right.Visible = false;
            pnl_add.Visible = false;
            pnl_c.Hide();
            pnl_billing.Hide();
            pnl_main.Hide();
            pnl_booking.Show();


        }

        private void btn_ckeck_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;
            if (String.IsNullOrEmpty(txt_eid.Text))
            {
                errorProvider1.SetError(txt_eid,"Employee ID is Required! ");
                isok = false;
            }

            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select * from EMPLOYEE where EID='" + txt_eid.Text + "'";
                    command.CommandText = query;

                    OleDbDataAdapter DA = new OleDbDataAdapter(command);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    dataGridView2.DataSource = DT;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else 
            {
                MessageBox.Show("Employee ID cannot be left blank! ","Error! ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Validation1())
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " update EMPLOYEE set ENAME='" + txt_ename.Text + "', AGE='" + txt_age.Text + "', PHONE='" + txt_phone.Text + "', ADDRESS='" + txt_address.Text + "', EMAIL='" + txt_email.Text + "', JOB_ROLE='" + cmb_job_role.Text + "', JOINING_DATE='" + txt_joining_date.Text + "', SALARY='" + txt_salary.Text + "' where EID= '" + txt_eid.Text + "' ";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Edited Syccessfully! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("All fiels are mandatory! ", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_manager_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from EMPLOYEE where JOB_ROLE=\"Manager\"";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView1.DataSource = DT;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btn_recp_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from EMPLOYEE where JOB_ROLE=\"Recp\"";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView1.DataSource = DT;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btn_chef_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from EMPLOYEE where JOB_ROLE=\"Chef\"";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView1.DataSource = DT;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btn_workers_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from EMPLOYEE where JOB_ROLE=\"Worker\"";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView1.DataSource = DT;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;
            if (string.IsNullOrEmpty(txt_eid.Text))
            {
                errorProvider1.SetError(txt_eid,"Employee ID is Required! ");
                isok = false;
            }

            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " Delete from EMPLOYEE where EID='" + txt_eid.Text + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Deleted Syccessfully! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Employee ID Cannot be blank! ","Error! ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public bool Validation1()
        {
            bool isok = true;

            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txt_eid.Text))
            {
                errorProvider1.SetError(txt_eid, " Employee ID is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_ename.Text))
            {
                errorProvider1.SetError(txt_ename, " Employee Name is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_age.Text))
            {
                errorProvider1.SetError(txt_age, " Age is Required! ");
                isok = false;
            }
            else if (cmb_esex.Text == "Select")
            {
                errorProvider1.SetError(cmb_esex, " Job Role is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_phone.Text))
            {
                errorProvider1.SetError(txt_phone, " Phone number is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_address.Text))
            {
                errorProvider1.SetError(txt_address, " Address is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_email.Text))
            {
                errorProvider1.SetError(txt_email, " Email is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_salary.Text))
            {
                errorProvider1.SetError(txt_salary, " Salary is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_joining_date.Text))
            {
                errorProvider1.SetError(txt_joining_date, " Date is Required! ");
                isok = false;
            }
            else if (cmb_job_role.Text == "Select")
            {
                errorProvider1.SetError(cmb_job_role, " Job Role is Required! ");
                isok = false;
            }

            return isok;
        }

        public bool Validation1_email()
        {
            bool isok = true;
            if (!txt_email.Text.Contains('@'))
            {
                errorProvider1.SetError(txt_email, " Email should contain \"@\" ");
                isok = false;
            }
            return isok;
        }

       

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView2.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_eid.Text = row.Cells[0].Value.ToString();
                txt_ename.Text = row.Cells[1].Value.ToString();
                txt_age.Text = row.Cells[2].Value.ToString();
                //txt_sex.Text = row.Cells[3].Value.ToString(); - To impliment
                txt_phone.Text = row.Cells[4].Value.ToString();
                txt_address.Text = row.Cells[5].Value.ToString();
                txt_email.Text = row.Cells[6].Value.ToString();
                cmb_job_role.Text = row.Cells[7].Value.ToString();
                txt_joining_date.Text = row.Cells[8].Value.ToString();
                txt_salary.Text = row.Cells[9].Value.ToString();

            }
        }

        private void btn_add_c_Click(object sender, EventArgs e)
        {
            if (Validation2())
            {
                if (Validation2_formet())
                {
                    int count = 0;
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "select * from CUSTOMER where CID='"+txt_cid.Text+"' ";
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
                        errorProvider1.SetError(txt_cid, "Customer ID already exist! ");
                        MessageBox.Show("Customer ID already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {


                        try
                        {
                            connection.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            string query = "insert into CUSTOMER (CID, CNAME, AGE, PHONE, ADDRESS, EMAIL, SEX) values ('" + txt_cid.Text + "','" + txt_cname.Text + "','" + txt_cage.Text + "','" + txt_cphone.Text + "','" + txt_caddress.Text + "','" + txt_cemail.Text + "','" + cmb_csex.Text + "') ";
                            command.CommandText = query;
                            command.ExecuteNonQuery();

                            MessageBox.Show("New Customer Added Successfully! ");

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
                    MessageBox.Show("Email should contain \"@\"", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {

                MessageBox.Show("All the fields are mandatory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validation2()
        {
            bool isok = true;

            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txt_cid.Text))
            {
                errorProvider1.SetError(txt_cid, " Customer ID is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_cname.Text))
            {
                errorProvider1.SetError(txt_cname, " Customer Name is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_cage.Text))
            {
                errorProvider1.SetError(txt_cage, " Age is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_cphone.Text))
            {
                errorProvider1.SetError(txt_cphone, " Phone number is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_caddress.Text))
            {
                errorProvider1.SetError(txt_caddress, " Address is Required! ");
                isok = false;
            }
            else if (string.IsNullOrEmpty(txt_cemail.Text))
            {
                errorProvider1.SetError(txt_cemail, " Email is Required! ");
                isok = false;
            }
            else if (cmb_csex.Text == "Select")
            {
                errorProvider1.SetError(cmb_csex, " Sex field is Required! ");
                isok = false;
            }
           

            return isok;
        }
        public bool Validation2_formet()
        {
            bool isok = true;
            if (!txt_cemail.Text.Contains('@'))
            {
                errorProvider1.SetError(txt_cemail, " Email should contain \"@\" ");
                isok = false;
            }
           
            return isok;
        }

        private void btn_customer_details_Click(object sender, EventArgs e)
        {
            pnl_right.Visible = false;
            pnl_add.Visible = false;
            pnl_booking.Hide();
            pnl_billing.Hide();
            pnl_main.Hide();
            pnl_c.Show();
            
        }

        private void btn_check_c_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;
            if (string.IsNullOrEmpty(txt_cid.Text))
            {
                errorProvider1.SetError(txt_cid,"Customer ID is Required! ");
                isok = false;
            }
            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select * from CUSTOMER where CID='" + txt_cid.Text + "'";
                    command.CommandText = query;

                    OleDbDataAdapter DA = new OleDbDataAdapter(command);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    dataGridView3.DataSource = DT;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Customer ID Cannot be Blank! ", "Error! ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView3.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_cid.Text = row.Cells[0].Value.ToString();
                txt_cname.Text = row.Cells[1].Value.ToString();
                txt_caddress.Text = row.Cells[2].Value.ToString();
                txt_cage.Text = row.Cells[3].Value.ToString();
                txt_cphone.Text = row.Cells[4].Value.ToString();
                txt_cemail.Text = row.Cells[5].Value.ToString();
                cmb_csex.Text = row.Cells[6].Value.ToString();

            }
        }

        private void btn_edit_c_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Validation2())
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " update CUSTOMER set CNAME='" + txt_cname.Text + "', AGE='" + txt_cage.Text + "', PHONE='" + txt_cphone.Text + "', ADDRESS='" + txt_caddress.Text + "', EMAIL='" + txt_cemail.Text + "',   SEX='" + cmb_csex.SelectedItem.ToString() + "' where CID= '" + txt_cid.Text + "' ";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Edited Syccessfully! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("All fields are mandatory! ","Error! ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_all_customer_details_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from CUSTOMER";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView3.DataSource = DT;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btn_delete_c_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;
            if (String.IsNullOrEmpty(txt_cid.Text))
            {
                errorProvider1.SetError(txt_cid, "Customer ID is Required! ");
                isok = false;
            }

            if (isok)
            {

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " Delete from CUSTOMER where CID='" + txt_cid.Text + "'";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Data Deleted Syccessfully! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Customer ID cannot be Blank! ","Error! ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_avilable_rooms_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select RID, CATEGORY, TYPE, FLORE, PRICE, DESCRIPTION, AVILABLITY from ROOMS where AVILABLITY = \"Yes\" ";
                command.CommandText = query;

                OleDbDataAdapter DA = new OleDbDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dataGridView4.DataSource = DT;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        
        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView4.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_b_rid.Text = row.Cells[0].Value.ToString();
                

            }
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string SID = "";
 
            bool isok = true;
            if (String.IsNullOrEmpty(txt_b_bid.Text))
            {
                errorProvider1.SetError(txt_b_bid, " Booking Id is Required! ");
                isok = false;
            }
            else if (String.IsNullOrEmpty(txt_b_cid.Text))
            {
                errorProvider1.SetError(txt_b_cid, " Customer Id is Required! ");
                isok = false;

            }
            else if (String.IsNullOrEmpty(txt_b_rid.Text))
            {
                errorProvider1.SetError(txt_b_rid, " Customer Id is Required! ");
                isok = false;

            }

            if (isok)
            {
                int BID = int.Parse(txt_b_bid.Text);
                int count = 0;
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select * from BOOKING where BID = " + txt_b_bid.Text + " ";
                    command.CommandText = query;
                    OleDbDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        count++;
                    }

                    //MessageBox.Show("Booking Done! ");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
                if (count != 0)
                {
                    MessageBox.Show("Booking ID already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string query = "select * from CUSTOMER where CID = '" + txt_b_cid.Text + "' ";
                        command.CommandText = query;
                        OleDbDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            count++;
                        }

                        //MessageBox.Show("Booking Done! ");

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                    if (count == 0)
                    {
                        MessageBox.Show("Customer ID doesnot exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        try
                        {
                            connection.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            string query = "insert into BOOKING (BID, CID, BOOKING_DATE) values (" + BID + ", '" + txt_b_cid.Text + "','" + dtp_b_booking_date.Value.ToString("dd-MM-yyyy") + "') ";
                            command.CommandText = query;
                            command.ExecuteNonQuery();

                            //MessageBox.Show("Booking Done! ");

                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }

                        try
                        {
                            connection.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            string query = "select SID from SERVICES where NAME = '" + cmb_b_services.Text + "' ";
                            command.CommandText = query;
                            OleDbDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                SID = reader["SID"].ToString();
                            }

                            //MessageBox.Show("Booking Done! ");

                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }

                        try
                        {
                            connection.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            string nonquery = "insert into CUSTOMER_SERVICES (CID, SID, RID, BID) values ('" + txt_b_cid.Text + "','" + SID + "' ,'" + txt_b_rid.Text + "', '" + BID + "') ";
                            command.CommandText = nonquery;
                            command.ExecuteNonQuery();

                            //MessageBox.Show("Booking Done! ");

                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }

                        try
                        {

                            string Avilablity = "No";
                            connection.Open();
                            OleDbCommand command = new OleDbCommand();
                            command.Connection = connection;
                            string query = " update ROOMS set AVILABLITY ='" + Avilablity + "'  where RID = " + txt_b_rid.Text + " ";

                            command.CommandText = query;
                            command.ExecuteNonQuery();

                            MessageBox.Show("Booking Done! ");
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }
                    }
                }


            }
            else
            {
                MessageBox.Show(" Please fill all the fields! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_add_services_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string serviceid = "";
            bool isok = true;

            if (cmb_b_services.Text == "Select")
            {
                errorProvider1.SetError(cmb_b_services, " Please Select one of the services! ");
                isok = false;
            }
            else if (String.IsNullOrEmpty(txt_b_bid.Text))
            {
                errorProvider1.SetError(txt_b_bid, " Booking Id is Required! ");
                isok = false;
            }
            else if (String.IsNullOrEmpty(txt_b_cid.Text))
            {
                errorProvider1.SetError(txt_b_cid, " Customer Id is Required! ");
                isok = false;
            }
            else if (String.IsNullOrEmpty(txt_b_rid.Text))
            {
                errorProvider1.SetError(txt_b_rid, "Room Number is Required! ");
                isok = false;
            }

            if (isok)
            {
                int BID = int.Parse(txt_b_bid.Text);
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select SID from SERVICES where NAME = '" + cmb_b_services.Text + "' ";
                    command.CommandText = query;
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serviceid = reader["SID"].ToString();
                    }

                    //MessageBox.Show("Booking Done! ");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string nonquery = "insert into CUSTOMER_SERVICES (CID, SID, RID, BID) values ('" + txt_b_cid.Text + "','" + serviceid + "' ,'" + txt_b_rid.Text + "', '" + BID + "') ";
                    command.CommandText = nonquery;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Service Successfully Added! ");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show(" Please fill all the required fields! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_booking_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int RID = 0;

            bool isok = true;
            if (String.IsNullOrEmpty(txt_b_bid.Text))
            {
                errorProvider1.SetError(txt_b_bid, " Booking Id is Required! ");
                isok = false;
            }
            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select C.RID from CUSTOMER_SERVICES C, BOOKING B where  C.BID = B.BID and B.BID =" + txt_b_bid.Text + " ";
                    command.CommandText = query;
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RID = int.Parse(reader["RID"].ToString());
                    }

                    //MessageBox.Show("stage1 ");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }

                try
                {

                    string Avilablity = "Yes";
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " update ROOMS set AVILABLITY ='" + Avilablity + "'  where RID = " + RID + " ";

                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    //MessageBox.Show("stage2 ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " Delete from BOOKING where BID=" + txt_b_bid.Text + " ";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    //MessageBox.Show("Booking Canceled! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " Delete from CUSTOMER_SERVICES where BID=" + txt_b_bid.Text + " ";
                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Booking Canceled! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show(" Please fill Booking ID! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_check_in_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;
            if (String.IsNullOrEmpty(txt_b_bid.Text))
            {
                errorProvider1.SetError(txt_b_bid, " Booking Id is Required! ");
                isok = false;
            }
            if (isok)
            {
                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " update BOOKING set CHECK_IN_DATE ='" + dtp_check_in_date.Value.ToString("dd-MM-yyyy") + "'  where BID = " + txt_b_bid.Text + " ";

                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Checked In Successfully! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show(" Please fill Booking ID! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_check_out_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int RID = 0;
            bool isok = true;
            if (String.IsNullOrEmpty(txt_b_bid.Text))
            {
                errorProvider1.SetError(txt_b_bid, " Booking Id is Required! ");
                isok = false;
            }
            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select C.RID from CUSTOMER_SERVICES C, BOOKING B where  C.BID = B.BID and B.BID =" + txt_b_bid.Text + " ";
                    command.CommandText = query;
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RID = int.Parse(reader["RID"].ToString());
                    }

                    //MessageBox.Show("stage1 ");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }

                try
                {

                    string Avilablity = "Yes";
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " update ROOMS set AVILABLITY ='" + Avilablity + "'  where RID = " + RID + " ";

                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    //MessageBox.Show("stage2 ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }

                try
                {

                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " update BOOKING set CHECK_OUT_DATE ='" + dtp_check_out_date.Value.ToString("dd-MM-yyyy") + "'  where BID = " + txt_b_bid.Text + " ";

                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    MessageBox.Show("Checked Out Successfully! ");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show(" Please fill Booking ID! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_b_check_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool isok = true;
            if (String.IsNullOrEmpty(txt_b_bid.Text))
            {
                errorProvider1.SetError(txt_b_bid,"Please provide Booking ID to check booking! ");
                isok = false;
            }

            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select * from CUSTOMER_SERVICES where BID="+ txt_b_bid.Text +"";
                    command.CommandText = query;

                    OleDbDataAdapter DA = new OleDbDataAdapter(command);
                    DataTable DT = new DataTable();
                    DA.Fill(DT);
                    dataGridView5.DataSource = DT;


                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Please provide Booking ID to check booking!", "Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView5.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_b_cid.Text = row.Cells[0].Value.ToString();
                txt_b_rid.Text = row.Cells[2].Value.ToString();
                //txt_b_bid.Text = row.Cells[3].Value.ToString();


            }
        }

        private void btn_bill_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isok = true;

            if (String.IsNullOrEmpty(txt_billing_bid.Text))
            {
                errorProvider1.SetError(txt_billing_bid,"Booking is Required! ");
                isok = false;
            }

            if (isok)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select sum(S.PRICE) from SERVICES S, CUSTOMER_SERVICES C  where S.SID=C.SID and C.BID=" + txt_billing_bid.Text + " ";
                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_billing_total_services_amount.Text = reader[0].ToString();
                    }


                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select R.PRICE from ROOMS R, CUSTOMER_SERVICES C  where R.RID=C.RID and C.BID=" + txt_billing_bid.Text + " ";
                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_billing_room_price.Text = reader[0].ToString();
                    }


                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }

                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "select S.NAME from SERVICES S, CUSTOMER_SERVICES C  where S.SID=C.SID and C.BID=" + txt_billing_bid.Text + " ";
                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }


                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }


                txt_billing_total_amount.Text = (int.Parse(txt_billing_total_services_amount.Text) + int.Parse(txt_billing_room_price.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Boking ID Should not be left blank!", "Error! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_billing_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = false;
            pnl_c.Hide();
            pnl_booking.Hide();
            pnl_right.Hide();
            pnl_main.Hide();
            pnl_billing.Show();
        }

        private void lbl_admin_panel_Click(object sender, EventArgs e)
        {
            pnl_add.Hide();
            pnl_billing.Hide();
            pnl_booking.Hide();
            pnl_c.Hide();
            pnl_right.Hide();
            pnl_main.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            pnl_add.Hide();
            pnl_billing.Hide();
            pnl_booking.Hide();
            pnl_c.Hide();
            pnl_right.Hide();
            pnl_main.Show();
  
        }

        private void btn_billing_clear_Click(object sender, EventArgs e)
        {
            txt_billing_bid.Clear();
            txt_billing_room_price.Clear();
            txt_billing_total_amount.Clear();
            txt_billing_total_services_amount.Clear();
            listBox1.Items.Clear();
        }

        private void btn_booking_clear_Click(object sender, EventArgs e)
        {
            txt_b_bid.Clear();
            txt_b_cid.Clear();
            txt_b_rid.Clear();
            dataGridView4.DataSource = null;
            dataGridView5.DataSource = null;
            cmb_b_services.Text = "Select";
            
        }

        private void btn_customer_details_clear_Click(object sender, EventArgs e)
        {
            txt_caddress.Clear();
            txt_cage.Clear();
            txt_cemail.Clear();
            txt_cid.Clear();
            txt_cname.Clear();
            txt_cphone.Clear();
            cmb_csex.Text = "Select";
            dataGridView3.DataSource = null;
        }

        private void btn_add_new_employee_clear_Click(object sender, EventArgs e)
        {
            txt_eid.Clear();
            txt_email.Clear();
            txt_ename.Clear();
            txt_joining_date.Clear();
            txt_phone.Clear();
            txt_salary.Clear();
            txt_address.Clear();
            txt_age.Clear();
            cmb_esex.Text = "Select";
            cmb_job_role.Text = "Select";
            dataGridView2.DataSource = null;
        }

        private void btn_employee_details_clear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void txt_billing_bid_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);

        }

        public bool ValidationIsDigit(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
            return e.Handled;
        }


        private void txt_b_bid_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);
        }

        private void txt_b_rid_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);
        }

        private void txt_cage_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);
        }

        private void txt_cphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);
        }

        private void txt_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);
        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);
        }

        private void txt_salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDigit(e);
        }

        private void txt_joining_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationIsDate(e);
        }
        public bool ValidationIsDate(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != '-' && ch!= '/')
            {
                e.Handled = true;
            }
            return e.Handled;
        }

        private void btn_admin_panel_users_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users f4 = new Users();
            f4.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
