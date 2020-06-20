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

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dashboardusercontrol1.BringToFront();
        }

        bool move;
        int mouseX;
        int mouseY;



        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void movementPanel_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void movementPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
        }

        private void movementPanel_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            colorchange("dashboardbtn");
            dashboardusercontrol1.BringToFront();
            dashboardusercontrol1.update();
        }

        void colorchange(string button)
        {
            foreach (Control cntrl in Menupanel.Controls)
            {
                if (cntrl is Button)
                {
                    Button b = (Button)cntrl;
                    if (b.Name == button)
                    {
                        b.BackColor = Color.FromArgb(0, 113, 135);
                        b.ForeColor = Color.White;
                        headLabel.Text = cntrl.Text;
                    }
                    else if (b.Name != button && b.Name != "closeBTN" && b.Name!="refreshBTN")
                    {
                        b.BackColor = Color.FromArgb(0, 5, 25);
                        b.ForeColor = Color.LightSteelBlue;
                    }
                }
                else if (cntrl is PictureBox)
                {
                    PictureBox p = (PictureBox)cntrl;
                    if (p.Name.Substring(0, 3) == button.Substring(0, 3))
                        p.BackColor = Color.FromArgb(0, 113, 135);
                    else
                        p.BackColor = Color.FromArgb(0, 5, 25);
                }
            }

        }

        private void reservationsBTN_Click(object sender, EventArgs e)
        {
            colorchange("reservationsBTN");
            reservationsUserControl1.BringToFront();
            reservationsUserControl1.update();
        }

        private void staffBTN_Click(object sender, EventArgs e)
        {
            staffUserControl1.BringToFront();
            colorchange("staffBTN");
            staffUserControl1.update();
        }

        private void roomserviceBTN_Click(object sender, EventArgs e)
        {
            roomServiceUserControl1.BringToFront();
            colorchange("roomserviceBTN");
            roomServiceUserControl1.refresh();
        }

        private void reportBTN_Click(object sender, EventArgs e)
        {
            reportUserControl1.BringToFront();
            colorchange("reportBTN");
            reportUserControl1.update();
        }

        private void experienceBTN_Click(object sender, EventArgs e)
        {
            expenditureUserControl1.BringToFront();
            colorchange("experienceBTN");
            expenditureUserControl1.update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dashboardusercontrol1.BringToFront();
        }

        public void update()
        {
            dashboardusercontrol1.update();
            reportUserControl1.update();
            roomServiceUserControl1.Refresh();
            expenditureUserControl1.update();
            reportUserControl1.update();
            reservationsUserControl1.update();
        }

        private void refreshBTN_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
