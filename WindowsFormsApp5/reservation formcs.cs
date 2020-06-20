using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class reservation_formcs : MetroForm
    {
        public reservation_formcs()
        {
            InitializeComponent();
        }

        Panel Change = new Panel();

        public string name = "";
        public string cnic = "";
        public string phone = "";
        public string date = "";
        public int days;
        public int duration;
        public string dateFormat = "HH:mm dd-MM-yyyy";
        //take values for database from above variables


        public void sourcePanel(Panel p)
        {
            Change = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = nameTB.Text;
            cnic = cnicTB.Text;
            phone = phoneTb.Text;
            days = int.Parse(daysNumeric.Value.ToString());
            date = dateTime.Value.ToString(dateFormat);
            duration = (int)((DateTime.Now - dateTime.Value).TotalDays);
            if (duration ==0)
                duration = 1;

            SqlConnection con = new SqlConnection(Properties.Settings.Default.hotelManagementConnectionString1);
            con.Open();
            string query = "Update reservation set name='" + name + "', cnic='" + cnic + "', phone='" + phone + "', CheckIn='" + date + "', days="+days+", Status='Occupied' where RoomNo="+ this.Text +";";
            string query2 = "Insert into customer(Name, Cnic, Checkin, roomno, Spend, Dues) values('" + name + "' , '" + cnic + "', '" + date + "', " + int.Parse(this.Text) + ", (select rent from reservation where roomno=" + this.Text + ")*"+days+", 0);";
            SqlCommand cmd = new SqlCommand(query, con); 
            int response=cmd.ExecuteNonQuery();
            if (response == 1)
            {
                occupiedConfig(Change);
                cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
                MessageBox.Show("Could not reserve. Try Again");
            Close();
        }

        public void occupiedConfig(Panel p)
        {
            string roomno = "";
            p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            p.BackColor = Color.FromArgb(34, 45, 83);
            foreach(Control c in p.Controls)
            {
                c.Visible = true;
                if (c is Label)
                    c.ForeColor = Color.White;
                if (c is Button)
                {
                    Button b = c as Button;
                    b.Image = Properties.Resources.Asset_3;
                }
                if (c is Label && (c.Font.Size > 14.25 && c.Font.Name == "Impact"))
                    roomno = c.Text;

                if (c.Text == "Cleaning" || c.Text == "Available")
                    c.Text = "Occupied";
                if (c.Font.Name == "Microsoft Sans Serif")
                {
                    c.Text = duration.ToString() + "/" + days.ToString();
                    if (duration > days)
                        c.ForeColor = Color.LightCoral;
                    else
                        c.ForeColor = Color.White;
                }
                if (c.Font.Name == "Calibri") 
                    c.Text = name.ToUpper();

            }
        }
    }
}
