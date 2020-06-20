using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Data.SqlClient;
using System.Threading;

namespace WindowsFormsApp5
{
    public partial class staffUserControl : UserControl
    {
        string connectString = Properties.Settings.Default.hotelManagementConnectionString1;

        public staffUserControl()
        {
            InitializeComponent();
        }

        private void staffUserControl_Load(object sender, EventArgs e)
        {
            update();
        }
        private void loadsummary()
        {
            int countCook = 0;
            int countPlanner = 0;
            int countHousekeeper = 0;
            for (int i = 0; i < metroGrid1.RowCount; i++)
            {
                if (metroGrid1[4, i].Value.ToString() == "Cook")
                    countCook++;
                if (metroGrid1[4, i].Value.ToString() == "Event Planner")
                    countPlanner++;
                if (metroGrid1[4, i].Value.ToString() == "Housekeeper")
                    countHousekeeper++;
            }
            cookLabel.Text = countCook.ToString();
            hkLabel.Text = countHousekeeper.ToString();
            eventPLabel.Text = countPlanner.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            messageLB.Visible = true;
            if (nameTB.Text != "" && cnicTB.Text != "" && phoneTb.Text != "" && addressTB.Text != "" && designationCB.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(connectString);
                    con.Open();
                    string query = "insert into staffinfo (Name, CNIC, phone, address, designation)  values ('" + nameTB.Text + "','" + cnicTB.Text + "','" + phoneTb.Text + "','" + addressTB.Text + "','" + designationCB.SelectedItem.ToString() + "');";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int response = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (response == 1)
                    {
                        messageLB.Text = "Successful";
                        messageLB.BackColor = Color.SpringGreen;
                        update();
                    }
                    else
                    {
                        messageLB.Text = "Problem occured";
                        messageLB.BackColor = Color.Red;
                    }
                }catch(SqlException ex)
                {
                    if (ex.Number == 2627)
                        MessageBox.Show("This CNIC already exists", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                messageLB.Text = "Fill correctly";
                messageLB.BackColor = Color.Red;
            }

        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteBTN.Visible = true;
            modifyBTN.Visible = true;
            if(e.ColumnIndex==5)
            {
                DataGridViewCell c = metroGrid1.SelectedRows[0].Cells[5];
                if (c.Value.ToString() == "True")
                    c.Value = "False";
                else
                    c.Value = "True";
                string cnic = metroGrid1.SelectedRows[0].Cells[1].Value.ToString();
                SqlConnection con = new SqlConnection(connectString);
                con.Open();
                string query = "Update staffinfo set present='" + c.Value + "' where cnic ='" + cnic + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update()
        {
            this.staffInfoTableAdapter.Fill(this.hotelManagementDataSet.staffInfo);
            loadsummary();
            clear();
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (searchTB.Text != "" && searchBTN.Text=="Search")
            {
                metroGrid1.ClearSelection();
                string data = searchTB.Text.ToLower();
                for (int i = 0; i < metroGrid1.Rows.Count; i++)
                {
                    if (metroGrid1[0, i].Value.ToString().ToLower().Contains(data) ||
                        metroGrid1[1, i].Value.ToString().ToLower() == data)
                    {
                        flag = true;
                        metroGrid1.Rows[i].Selected = true;
                        metroGrid1.FirstDisplayedScrollingRowIndex = i;
                    }
                }
                if (flag == false)
                    MessageBox.Show("Your search did not match any record", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (flag == true)
                {
                    metroGrid1.RowsDefaultCellStyle.SelectionBackColor = Color.LightGreen;
                    searchBTN.Text = "Clear";
                }
            }

            else if(searchBTN.Text=="Clear")
            {
                clear();
            }
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedCells.Count > 0)
            {
                DialogResult res=MessageBox.Show("Delete selected record(s)?", "Confirmation", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    int response = -1;
                    SqlConnection con = new SqlConnection(connectString);
                    con.Open();
                    SqlCommand cmd;
                    for (int i = 0; i < metroGrid1.SelectedRows.Count; i++)
                    {
                        string cnic = metroGrid1.SelectedRows[i].Cells[1].Value.ToString();
                        string query = "Delete from staffinfo where cnic='" + cnic + "';";
                        cmd = new SqlCommand(query, con);
                        response = cmd.ExecuteNonQuery();
                    }

                    if (response == 1)
                    {
                        MessageBox.Show("Selected record(s) successfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        update();
                    }
                    else
                        MessageBox.Show("There was a problem with deletion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }


        void clear()
        {
            metroGrid1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 192, 255);
            metroGrid1.ClearSelection();
            metroGrid1.Refresh();
            searchBTN.Text = "Search";
            searchTB.Text = "";
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            if (searchTB.Text == "")
                clear();
        }

       
        private void editSave_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                string cnic = metroGrid1.SelectedRows[0].Cells[1].Value.ToString();
                string query = "Update staffinfo set Name='" + editnameTB.Text + "', CNIC='" + editCnicTB.Text + "', Phone='" + editPhoneTB.Text + "', Address='" + editAddressTB.Text + "' , Designation='" + editDesignationTB.Text + "' where cnic=" + cnic + ";";
                SqlConnection con = new SqlConnection(connectString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                int response = cmd.ExecuteNonQuery();
                if (response == 1)
                {
                    MessageBox.Show("Edited record successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    update();
                }
            }
            editingPanel.Visible = false;
        }

        private void modifyBTN_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count == 1)
            {
                editnameTB.Text = metroGrid1.SelectedRows[0].Cells[0].Value.ToString();
                editCnicTB.Text = metroGrid1.SelectedRows[0].Cells[1].Value.ToString();
                editPhoneTB.Text = metroGrid1.SelectedRows[0].Cells[2].Value.ToString();
                editAddressTB.Text = metroGrid1.SelectedRows[0].Cells[3].Value.ToString();
                editDesignationTB.Text = metroGrid1.SelectedRows[0].Cells[4].Value.ToString();
                editingPanel.Visible = true;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}