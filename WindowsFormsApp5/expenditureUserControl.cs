using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class expenditureUserControl : UserControl
    {
        public expenditureUserControl()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.hotelManagementConnectionString1);
        SqlDataAdapter adptr;
        DataTable tbl;

        private void expenditureUserControl_Load(object sender, EventArgs e)
        {
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (accCheck.Checked == true || expCheck.Checked == true)
            {

                string format = "dd MMMM yyyy";
                string duration = startDate.Value.ToString(format) + " - " + endDate.Value.ToString(format);
                int originalWidth = accountsGrid.Width;
                int origianlHeight = accountsGrid.Height;
                accountsGrid.Dock = DockStyle.None;
                accountsGrid.Size = new Size(760, 842);
                expenseGrid.Dock = DockStyle.None;
                expenseGrid.Size = new Size(760, 842);
                try
                {
                    if (accCheck.Checked == true)
                    {
                        DGVPrinter print = new DGVPrinter();
                        print.TitleFont = new Font("Franklin Gothic", 16.0f, FontStyle.Bold);
                        print.SubTitle = duration;
                        print.SubTitleFont = new Font(print.SubTitleFont.FontFamily, 10.0f);
                        print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                        print.PageNumbers = true;
                        print.PageNumberInHeader = false;
                        print.HeaderCellAlignment = StringAlignment.Near;
                        print.Footer = "Generated " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                        print.FooterFont = new Font("Franklin Gothic", 9.0f, FontStyle.Italic);
                        print.FooterSpacing = 15.0f;
                        //print.TableAlignment = DGVPrinter.Alignment.Center;
                        print.Title = "Accounts";
                        print.PrintDataGridView(accountsGrid);
                    }
                    if (expCheck.Checked == true)
                    {
                        DGVPrinter print = new DGVPrinter();
                        print.TitleFont = new Font("Franklin Gothic", 16.0f, FontStyle.Bold);
                        print.SubTitle = duration;
                        print.SubTitleFont = new Font(print.SubTitleFont.FontFamily, 10.0f);
                        print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                        print.PageNumbers = true;
                        print.PageNumberInHeader = false;
                        print.HeaderCellAlignment = StringAlignment.Near;
                        print.Footer = "Generated " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                        print.FooterFont = new Font("Franklin Gothic", 9.0f, FontStyle.Italic);
                        print.FooterSpacing = 15.0f;
                        //print.TableAlignment = DGVPrinter.Alignment.Center;

                        print.Title = "Expense Sheet";
                        print.PrintDataGridView(expenseGrid);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Error Occurred. Please try again", "Error");
                }

                accountsGrid.Dock = DockStyle.Top;
                accountsGrid.Size = new Size(originalWidth, origianlHeight);
                expenseGrid.Dock = DockStyle.Top;
                expenseGrid.Size = new Size(originalWidth, origianlHeight);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = itemTB.Text;
            string desc = descTB.Text;
            string qty = qtyTB.Text;
            string amount = amountTB.Text;
            string date = newDate.Value.ToString("dd-MM-yyyy");

            if(item!=""&&desc!=""&&qty!=""&&amount!=""&&date!="")
            {
                con.Open();
                string query = "insert into expense (description, item, quantity, amount, date) values('" + desc + "', '" + item + "', " + qty + ", '" + amount + "', '" + date + "');";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Expense has been saved", "Success");
                update();
            }
        }

        public void update()
        {
            this.expenseTableAdapter.Fill(this.hotelManagementDataSet.expense);
            this.customerTableAdapter.Fill(this.hotelManagementDataSet.Customer);
        }

    }
}
