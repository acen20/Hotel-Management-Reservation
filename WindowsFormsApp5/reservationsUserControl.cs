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
    public partial class reservationsUserControl : UserControl
    {
        public reservationsUserControl()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.hotelManagementConnectionString1);
        SqlCommand cmd;
        SqlDataAdapter adptr;

        string drop_state_single = "down";
        string drop_state_two = "down";
        string drop_state_three = "down";

        private void dropsinglebed_Click(object sender, EventArgs e)
        {
            if (drop_state_single == "down")
            {
                drop_state_single = "up";
                dropsinglebed.Image = Properties.Resources.Asset_1;
                oneBedPanel.AutoSize = true;
            }
            else
            {
                drop_state_single = "down";
                dropsinglebed.Image = Properties.Resources.whitedrop;
                oneBedPanel.AutoSize = false;
            }
        }

        private void droptwobed_Click(object sender, EventArgs e)
        {
            if (drop_state_two == "down")
            {
                drop_state_two = "up";
                droptwobed.Image = Properties.Resources.Asset_1;
                twobedpanel.AutoSize = true;
            }
            else
            {
                drop_state_two = "down";
                droptwobed.Image = Properties.Resources.whitedrop;
                twobedpanel.AutoSize = false;
            }
        }

        private void dropthreebed_Click(object sender, EventArgs e)
        {
            if (drop_state_three == "down")
            {
                drop_state_three = "up";
                dropthreebed.Image = Properties.Resources.Asset_1;
                threebedpanel.AutoSize = true;
            }
            else
            {
                drop_state_three = "down";
                dropthreebed.Image = Properties.Resources.whitedrop;
                threebedpanel.AutoSize = false;
            }
        }

        private void occupiedStrip()
        {
            contextMenuStrip1.Items.Clear();
            availableToolStripMenuItem.Text = "Vacate";
            contextMenuStrip1.Items.Add(availableToolStripMenuItem);
        }

        private void cleaningStrip()
        {
            contextMenuStrip1.Items.Clear();
            availableToolStripMenuItem.Text = "Available";
            contextMenuStrip1.Items.Add(availableToolStripMenuItem);
        }

        private void availableStrip()
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(reserveToolStripMenuItem);
            contextMenuStrip1.Items.Add(cleaningToolStripMenuItem);
        }

        private void availableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (availableToolStripMenuItem.Text == "Vacate")
            {
                string roomno = "";
                Control p = source(sender);
                foreach(Control c in p.Controls)
                {
                    if(c is Label)
                    {
                        Label l = (Label)c;
                        if (l.Font.Name == "Impact" && l.Font.Size > 15)
                        {
                            roomno = l.Text;
                            break;
                        }
                    }
                }

                vacatePanelConfig(roomno, "Vacate");
                confirmBTN.Click+=(s, args)=> availableConfig(sender, "strip");
            }
            else
                availableConfig(sender, "strip");
        }

        private void cleaningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleaningConfig(sender, "strip");
        }

        private void reserveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Control sourceControl = source(sender);
            string roomNo = "";
            foreach (Control c in sourceControl.Controls)
            {
                if (c is Label)
                {
                    Label l = c as Label;
                    if (l.Font.Name == "Impact" && l.Font.Size > 14.25f)
                    {
                        roomNo = l.Text;
                        break;
                    }
                }
            }
            reservation_formcs form = new reservation_formcs();
            form.Text = roomNo;
            form.sourcePanel(sourceControl as Panel);
            form.FormClosed += (s, args) => update();
            form.Show();

        }


        private Control source(object sender)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            Control con=null;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                   con = owner.SourceControl;
                }

            }
            return con;
        }


        private void availableConfig(Object sender, string cntrl)
        {
            string roomno = "";
            Panel p;
            if (cntrl == "strip")
                p = (Panel)source(sender);
            else
                p = (Panel)sender;
            p.BackColor = Color.White;
            p.ForeColor = Color.FromArgb(0, 5, 25);
            p.BorderStyle = BorderStyle.FixedSingle;
            foreach (Control c in p.Controls)
            {
                if (c is Label)
                {
                    Label l = c as Label;
                    if (l.Text == "Occupied" || l.Text == "Cleaning")
                    {
                        l.Text = "Available";
                        l.ForeColor = Color.FromArgb(51, 204, 102);
                    }
                    if (l.Font.Name == "Impact" && l.Font.Size > 14.25)
                    {
                        l.ForeColor = Color.FromArgb(0,5,25);
                        roomno = l.Text;
                    }
                }
                if (c is Button)
                {
                    Button b = c as Button;
                    b.Image = Properties.Resources.Asset_4;
                    b.Visible = true;
                }
                if (c is Button || c.Text == "Available" || (c.Font.Name == "Impact" && c.Font.Size > 14.25f))
                    continue;
                else
                    c.Visible = false;

            }
            if (cntrl == "strip")
            {
                con.Open();
                string query = "Update reservation set Status='Available' , name=null, cnic=null, phone=null, checkin=null where roomno=" + roomno + ";";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        private void getStatus(Button b)
        {
            string status = "";
            foreach (Control c in b.Parent.Controls)
            {
                if (c is Label)
                {
                    Label l = (Label)c;
                    if (l.Text == "Occupied" || l.Text == "Available" || l.Text == "Cleaning")
                    {
                        status = l.Text;
                        break;
                    }
                }
            }
            if (status == "Occupied")
                occupiedStrip();
            else if (status == "Cleaning")
                cleaningStrip();
            else
                availableStrip();
            contextMenuStrip1.Show(b.Parent, 5, 50);
        }

        

        private void cleaningConfig(Object sender, string cntrl)
        {
            Panel p = null;
            string roomno = "";
            if (cntrl == "strip")
                p = (Panel)source(sender);
            else
                p = (Panel)sender;
            p.BackColor = Color.DarkGray;
            p.ForeColor = Color.White;
            p.BorderStyle = BorderStyle.FixedSingle;
            foreach (Control c in p.Controls)
            {
                if (c is Label)
                {
                    Label l = c as Label;
                    if (l.Text == "Available" || l.Text=="Occupied")
                    {
                        l.Text = "Cleaning";
                        l.ForeColor = Color.White;
                    }
                    if (l.Font.Name == "Impact"  && l.Font.Size>14.25)
                    {
                        l.ForeColor = Color.White;
                        roomno = l.Text;
                    }
                }
                if (c is Button)
                {
                    Button b = c as Button;
                    b.Image = Properties.Resources.Asset_3;
                }
                if (c is Button || c.Text == "Cleaning" || (c.Font.Name == "Impact" && c.Font.Size > 14.25f))
                    continue;
                else
                    c.Visible = false;
            }
            if(cntrl=="strip")
            {
                con.Open();
                string query = "Update reservation set Status='Cleaning' where roomno=" + roomno + ";";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update()
        {
            bool found = false;
            string query = "Select * from reservation;";
            con.Open();
            adptr = new SqlDataAdapter(query, con);
            DataSet s = new DataSet();
            adptr.Fill(s, "reservation");
            for (int i = 0; i < s.Tables["reservation"].Rows.Count; i++)
            {
                string roomno = s.Tables["reservation"].Rows[i]["Roomno"].ToString();
                if(int.Parse(s.Tables["reservation"].Rows[i]["Bed"].ToString())==1)
                {
                    foreach(Panel p in oneBedPanel.Controls)
                    {
                        foreach(Control c in p.Controls)
                        {
                            if (c is Label)
                            {
                                Label l = (Label)c;
                                if (l.Font.Name == "Impact" && l.Font.Size > 14.25)
                                {
                                    if (l.Text == roomno)
                                    {
                                        found = true;
                                        {
                                            if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Cleaning")
                                                cleaningConfig(p,"");
                                            else if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Available")
                                                availableConfig(p,"");
                                            else if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Occupied")
                                            {
                                                reservation_formcs cs = new reservation_formcs();
                                                DateTime startdate = DateTime.ParseExact(s.Tables["reservation"].Rows[i]["Checkin"].ToString(),cs.dateFormat,null);
                                                cs.name = s.Tables["reservation"].Rows[i]["Name"].ToString();
                                                double dur =(DateTime.Now - startdate).TotalDays;
                                                cs.duration = ((int)dur) + 1;
                                                cs.days = (int)(s.Tables["reservation"].Rows[i]["Days"]);
                                                cs.occupiedConfig(p);
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        if(found==true)
                        {
                            found = false;
                            break;
                        }
                    }
                }

                //---------------------Now for 2 bed
                if (int.Parse(s.Tables["reservation"].Rows[i]["Bed"].ToString()) == 2)
                {
                    foreach (Panel p in twobedpanel.Controls)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c is Label)
                            {
                                Label l = (Label)c;
                                if (l.Font.Name == "Impact" && l.Font.Size > 14.25)
                                {
                                    if (l.Text == roomno)
                                    {
                                        found = true;
                                        {
                                            if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Cleaning")
                                                cleaningConfig(p, "");
                                            else if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Available")
                                                availableConfig(p, "");
                                            else if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Occupied")
                                            {
                                                reservation_formcs cs = new reservation_formcs();
                                                DateTime startdate = DateTime.ParseExact(s.Tables["reservation"].Rows[i]["Checkin"].ToString(), cs.dateFormat, null);
                                                cs.name = s.Tables["reservation"].Rows[i]["Name"].ToString();
                                                double dur = (DateTime.Now - startdate).TotalDays;
                                                cs.duration = ((int)dur) + 1;
                                                cs.days = (int)(s.Tables["reservation"].Rows[i]["Days"]);
                                                cs.occupiedConfig(p);
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        if (found == true)
                        {
                            found = false;
                            break;
                        }
                    }
                }


                //------------------Three bed

                if (int.Parse(s.Tables["reservation"].Rows[i]["Bed"].ToString()) == 3)
                {
                    foreach (Panel p in threebedpanel.Controls)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c is Label)
                            {
                                Label l = (Label)c;
                                if (l.Font.Name == "Impact" && l.Font.Size > 14.25)
                                {
                                    if (l.Text == roomno)
                                    {
                                        found = true;
                                        {
                                            if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Cleaning")
                                                cleaningConfig(p, "");
                                            else if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Available")
                                                availableConfig(p, "");
                                            else if (s.Tables["reservation"].Rows[i]["Status"].ToString() == "Occupied")
                                            {
                                                reservation_formcs cs = new reservation_formcs();
                                                DateTime startdate = DateTime.ParseExact(s.Tables["reservation"].Rows[i]["Checkin"].ToString(), cs.dateFormat, null);
                                                cs.name = s.Tables["reservation"].Rows[i]["Name"].ToString();
                                                double dur = ((DateTime.Now - startdate).TotalDays);
                                                cs.duration = ((int)dur)+1;
                                                cs.days = (int)(s.Tables["reservation"].Rows[i]["Days"]);
                                                cs.occupiedConfig(p);
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        if (found == true)
                        {
                            found = false;
                            break;
                        }
                    }
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getStatus((Button)sender);
        }

        private void reservationsUserControl_Load(object sender, EventArgs e)
        {
            update();
        }

        private void panelDoubleClick(object sender, MouseEventArgs e)
        {
            string roomno = "";
            Panel p = (Panel)sender;
            foreach (Control c in p.Controls)
            {
                if (c is Label)
                {
                    Label l = (Label)c;
                    if (l.Font.Name == "Impact" && l.Font.Size > 15)
                    {
                        roomno = l.Text;
                        break;
                    }
                }
            }

            vacatePanelConfig(roomno,"");
        }

        private void label34_Click(object sender, EventArgs e)
        {
            roomINFOPANEL.Visible = false;
        }

        private int calculateServices(string roomno, DateTime checkin, string totalORRemaining)
        {
            int bill = 0;
            int unpaid = 0;
            con.Open();
            DataSet s = billing(roomno);
            con.Close();

            for (int i = 0; i < s.Tables["service"].Rows.Count; i++)
            {
                if (s.Tables["service"].Rows[i]["Time"].ToString() != "")
                {
                    DateTime time = DateTime.ParseExact(s.Tables["service"].Rows[i]["Time"].ToString(), "HH:mm dd-MM-yyyy", null);
                    if (time >= checkin && time <= DateTime.Now)
                    {
                        bill += int.Parse(s.Tables["service"].Rows[i]["Bill"].ToString());
                        if(s.Tables["service"].Rows[i]["Payment"].ToString()=="Unpaid")
                            unpaid+= int.Parse(s.Tables["service"].Rows[i]["Bill"].ToString());
                    }
                }
            }
            s.Dispose();
            if (totalORRemaining == "total")
                return bill;
            else
                return unpaid;
        }

        private DataSet billing(String roomno)
        {
            string query = "select roomno, bill, Time, payment from roomservice where roomno=" + roomno + ";";
            adptr = new SqlDataAdapter(query, con);
            DataSet s = new DataSet();
            adptr.Fill(s, "service");
            adptr.Dispose();
            return s;
        }

       private int calculateRent(string roomno)
        {
            int totalrent = 0;
            con.Open();
            string query = "Select rent,Checkin from reservation where roomno=" + roomno + ";";
            adptr = new SqlDataAdapter(query, con);
            DataSet s = new DataSet();
            adptr.Fill(s, "rent");
            int dayRent=int.Parse(s.Tables["rent"].Rows[0]["Rent"].ToString());
            DateTime t = DateTime.ParseExact(s.Tables["rent"].Rows[0]["Checkin"].ToString(), "HH:mm dd-MM-yyyy", null);
            int NumOfDays = ((int)(DateTime.Now - t).TotalDays)+1;
            totalrent = NumOfDays * dayRent;
            con.Close();
            return totalrent;
        } 

        private int calculateDues(string roomno, DateTime t)
        {
            int rent = calculateRent(roomno);
            int services = calculateServices(roomno, t, "Unpaid");
            string query = "Select Spend from customer where roomno=" + roomno + ";";
            DataSet s = new DataSet();
            con.Open();
            adptr = new SqlDataAdapter(query, con);
            adptr.Fill(s, "spend");
            int customerAccount=int.Parse(s.Tables["spend"].Rows[0]["Spend"].ToString());
            int due = (services+rent) - customerAccount;
            con.Close();
            adptr.Dispose();
            return due;
        }

        private void vacatePanelConfig(string roomno, string vacate)
        {
            con.Open();
            string query = "Select * from reservation where roomno=" + roomno + ";";
            adptr = new SqlDataAdapter(query, con);
            DataSet s = new DataSet();
            adptr.Fill(s, "reservation");
            con.Close();
            vacateRoomLB.Text = roomno;
            //roomINFOPANEL.BackColor = Color.FromArgb(32, 32, 32);
            roomINFOPANEL.Visible = true;
            vacateRoomNameLB.Text = s.Tables["reservation"].Rows[0]["Name"].ToString().ToUpper();
            vacateRoomCNICLB.Text = s.Tables["reservation"].Rows[0]["CNIC"].ToString();
            vacateRoomINLB.Text = s.Tables["reservation"].Rows[0]["checkin"].ToString();
            vacateRoomOUTLB.Text = "-";
            rentTB.Text = s.Tables["reservation"].Rows[0]["rent"].ToString();
            if (vacateRoomINLB.Text != "")
            {

                vacateRoomServiceLB.Text = calculateServices(roomno, DateTime.ParseExact(vacateRoomINLB.Text, "HH:mm dd-MM-yyyy", null), "total").ToString();
                vacateRoomDaysLB.Text = s.Tables["reservation"].Rows[0]["Days"].ToString();
                vacateRoomDuesLB.Text = calculateDues(roomno, DateTime.ParseExact(vacateRoomINLB.Text, "HH:mm dd-MM-yyyy", null)).ToString();
            }
            else
            {
                vacateRoomDaysLB.Text = "-";
                vacateRoomDuesLB.Text = "-";
                vacateRoomServiceLB.Text = "-";
            }
            confirmBTN.Visible = false;
            if (vacate == "Vacate")
            {
                vacateRoomOUTLB.Text = DateTime.Now.ToString("HH:mm dd-MM-yyyy");
                confirmBTN.Visible = true;
            }

            vacateRoomStatusLB.Text = s.Tables["reservation"].Rows[0]["Status"].ToString().ToUpper();
        }

        private void confirmBTN_Click(object sender, EventArgs e)
        {
            con.Open();
            string roomno = vacateRoomLB.Text;
            string query2 = "update customer set Dues=0, Checkout='" + vacateRoomOUTLB.Text + "', Spend=(Select spend from customer where roomno=" + roomno + ")+" + vacateRoomDuesLB.Text + " where roomno=" + roomno + ";";
            string query3 = "insert into allRecords Select * from customer where roomno=" + roomno + ";";
            string query4 = "delete from customer where roomno=" + roomno + ";";
            cmd = new SqlCommand(query2, con);
            int updateResponse=cmd.ExecuteNonQuery();
            cmd = new SqlCommand(query3, con);
            int copyResponse=cmd.ExecuteNonQuery();
            cmd = new SqlCommand(query4, con);
            int deleteResponse=cmd.ExecuteNonQuery();
            if(updateResponse==1&&copyResponse==1&&deleteResponse==1)
                roomINFOPANEL.Visible = false;
            con.Close();
        }

        private void rentSaveBTN_Click(object sender, EventArgs e)
        {
            rentSaveBTN.Visible = false;
            con.Open();
            string query = "update reservation set rent=" + rentTB.Text + " where roomno=" + vacateRoomLB.Text + ";";
            cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
            update();
        }

        private void rentTB_Click(object sender, EventArgs e)
        {
            rentSaveBTN.Visible = true;
        }
    }
}
