using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class dashboardusercontrol : UserControl
    {
        public dashboardusercontrol()
        {
            InitializeComponent();
        }

        public void update()
        {
            int vacantCount = 0;
            int vacantRCount = 0;
            int vacantDCount = 0;
            int reservedCount = 0;
            int sumOfExpense = 0;
            int sumOfPayable = 0;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.hotelManagementConnectionString1);
            con.Open();
            string query = "Select * from reservation";
            string query2 = "select * from staffinfo";
            string query3 = "select * from expense;";
            string query4 = "select * from customer;";
            SqlDataAdapter adptr = new SqlDataAdapter(query, con);
            DataSet s = new DataSet();
            adptr.Fill(s, "res");
            adptr.Dispose();
            for (int i = 0; i < s.Tables["res"].Rows.Count; i++)
            {
                string status = s.Tables["res"].Rows[i]["Status"].ToString();
                if (status == "Available")
                {
                    vacantCount++;
                    vacantRCount++;
                }
                if (status == "Cleaning")
                {
                    vacantCount++;
                    vacantDCount++;
                }
                if (status == "Occupied")
                    reservedCount++;
            }

            adptr = new SqlDataAdapter(query2, con);
            adptr.Fill(s, "staff");
            adptr.Dispose();

            int presentStaff = 0;

            for(int i=0;  i<s.Tables["staff"].Rows.Count;i++)
            {
                string attendance=s.Tables["staff"].Rows[i]["Present"].ToString();
                if (attendance == "True")
                    presentStaff++;
            }

            adptr = new SqlDataAdapter(query3, con);
            adptr.Fill(s, "Expense");
            adptr.Dispose();
            for(int i=0; i<s.Tables["Expense"].Rows.Count;i++)
            {
                sumOfExpense+=int.Parse(s.Tables["Expense"].Rows[i]["Amount"].ToString());
            }

            expenseCurrent.Text = sumOfExpense.ToString();

            adptr = new SqlDataAdapter(query4, con);
            adptr.Fill(s, "customer");
            adptr.Dispose();
            for(int i=0; i< s.Tables["customer"].Rows.Count;i++)
            {
                sumOfPayable+=int.Parse(s.Tables["customer"].Rows[i]["Spend"].ToString());
            }

            expensepayableLB.Text = sumOfPayable.ToString();

            totalExpense.Text = (sumOfPayable+sumOfExpense).ToString();


            totalStaffLB.Text = s.Tables["staff"].Rows.Count.ToString();
            staffPresentLB.Text = presentStaff.ToString();
            staffAbsentLB.Text = (int.Parse(totalStaffLB.Text) - presentStaff).ToString();

            vacantLB.Text = vacantCount.ToString();
            vacantRLB.Text = vacantRCount.ToString();
            vacantDLB.Text = vacantDCount.ToString();
            totalRoomLB.Text = s.Tables["res"].Rows.Count.ToString();
            resVacantRooms.Text = vacantLB.Text;
            reservedLB.Text = reservedCount.ToString();
        }

        private void dashboardusercontrol_Load(object sender, EventArgs e)
        {
            update();
        }
    }
}
