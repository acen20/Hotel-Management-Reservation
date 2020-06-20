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
using MetroFramework;
using System.Collections;

namespace WindowsFormsApp5
{
    public partial class roomServiceUserControl : UserControl
    {
        public roomServiceUserControl()
        {
            InitializeComponent();
        }

        class menuitems{
            public string item;
            public int price;
        };


        List<String> order = new List<String>();
        ArrayList pricing = new ArrayList();
        int totalAmount = 0;

        private void roomServiceUserControl_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(menuCB.SelectedItem!=null)
            {
                string item = menuCB.SelectedItem.ToString();
                if (order.Contains(item))
                {
                    foreach (Control t in orderPanel.Controls)
                    {
                        if (t.Text.Contains(item))
                        {
                            string[] split = t.Text.Split(' ');
                            int qty = int.Parse(split[0]);
                            qty = qty + int.Parse(menuQty.Value.ToString());
                            t.Text = qty.ToString() + " " + item;
                        }
                    }
                }
                else
                {
                    TextBox tb = new TextBox();
                    tb.Text = menuQty.Value.ToString() + " " + item;
                    order.Add(menuCB.SelectedItem.ToString());
                    orderPanel.Controls.Add(tb);
                }
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomnoLB.Text=roomnoCB.SelectedItem.ToString();
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timingLB.Text = timeCB.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (roomnoLB.Text!="" && timingLB.Text!="")
            {
                string payment="Unpaid";
                string connectString = Properties.Settings.Default.hotelManagementConnectionString1; 
                SqlConnection con = new SqlConnection(connectString);
                string concatenate = "";
                foreach (TextBox t in orderPanel.Controls)
                    concatenate += t.Text + ", ";
                con.Open();
                string query = "insert into roomservice (Description, RoomNo, Time, Service, Bill, Payment) values('" + concatenate + "','" + roomnoLB.Text + "','" + DateTime.Now.ToString("HH:mm dd-MM-yyyy") + "','"+timingLB.Text+"',"+calculateTotal()+", '"+payment+"');";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (drinksCB.SelectedItem != null)
            {
                string item = drinksCB.SelectedItem.ToString();
                if (order.Contains(item))
                {
                    foreach (Control t in orderPanel.Controls)
                    {
                        if (t.Text.Contains(item))
                        {
                            string[] split = t.Text.Split(' ');
                            int qty = int.Parse(split[0]);
                            qty = qty + int.Parse(drinksQty.Value.ToString());
                            t.Text = qty.ToString() + " " + item;
                        }
                    }
                }
                else
                {
                    TextBox tb = new TextBox();
                    tb.Text = drinksQty.Value.ToString() + " " + item;
                    order.Add(drinksCB.SelectedItem.ToString());
                    orderPanel.Controls.Add(tb);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void refresh()
        {
            totalAmount = 0;
            drinksCB.Items.Clear();
            menuCB.Items.Clear();
            DataSet s = new DataSet();
            string query = "Select * from menu";
            string query2 = "select roomno from reservation where status='Occupied';";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.hotelManagementConnectionString1);
            SqlDataAdapter adptr = new SqlDataAdapter();
            adptr.SelectCommand = new SqlCommand(query, con);
            adptr.Fill(s, "menu");

            int menurows=s.Tables["menu"].Rows.Count;

            for (int i = 0; i < menurows; i++)
            {
                string item = s.Tables["menu"].Rows[i]["Type"].ToString();
                if ( item== "Food")
                {
                    menuCB.Items.Add(s.Tables["menu"].Rows[i]["item"].ToString());
                }
                else if(item=="Drink")
                {
                    drinksCB.Items.Add(s.Tables["menu"].Rows[i]["item"].ToString());
                }
                menuitems mi = new menuitems();
                mi.item = s.Tables["menu"].Rows[i]["item"].ToString();
                mi.price = int.Parse(s.Tables["menu"].Rows[i]["price"].ToString());
                pricing.Add(mi);
            }

            adptr.SelectCommand = new SqlCommand(query2, con);
            adptr.Fill(s, "roomno");
            int roomrows = s.Tables["roomno"].Rows.Count;
            roomnoCB.Items.Clear();
            for (int i = 0; i < roomrows; i++)
            {
                roomnoCB.Items.Add(s.Tables["roomno"].Rows[i]["roomno"].ToString());
            }

            orderPanel.Controls.Clear();
            order.Clear();
            roomnoLB.Text = "";
            timingLB.Text = "";
            roomnoCB.ResetText();
            timeCB.ResetText();
            menuCB.ResetText();
            menuQty.Value = 1;
            drinksCB.ResetText();
            drinksQty.Value = 1;
            this.roomserviceTableAdapter.Fill(this.hotelManagementDataSet.roomservice);
        }

        private void orderPanel_Paint(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculateTotal();
            totalAmount = 0;
        }

        private int calculateTotal()
        {
            foreach (TextBox t in orderPanel.Controls)
            {
                if (t.Text != "")
                {
                    string[] split = t.Text.Split(' ');
                    int qty = int.Parse(split[0]);

                    foreach (menuitems m in pricing)
                    {
                        if (t.Text.Contains(m.item))
                        {
                            totalAmount = totalAmount + m.price * qty;
                        }

                    }
                }

            }
            totalLB.Text = totalAmount.ToString();
            return totalAmount;
        }
    }
}
