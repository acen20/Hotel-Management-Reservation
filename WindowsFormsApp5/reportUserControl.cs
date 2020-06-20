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

namespace WindowsFormsApp5
{
    public partial class reportUserControl : UserControl
    {
        public reportUserControl()
        {
            InitializeComponent();
        }

        private void reportUserControl_Load(object sender, EventArgs e)
        {
            update();
        }

        public void update()
        {
            this.roomserviceTableAdapter.Fill(hotelManagementDataSet.roomservice);
            this.allRecordsTableAdapter.Fill(hotelManagementDataSet.allRecords);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (accCheck.Checked == true || roomCheck.Checked == true)
            {
                int originalWidth = accountsGrid.Width;
                int origianlHeight = accountsGrid.Height;
                accountsGrid.Dock = DockStyle.None;
                accountsGrid.Size = new Size(760, 842);
                roomGrid.Dock = DockStyle.None;
                roomGrid.Size = new Size(760, 842);
                try
                {
                    if (accCheck.Checked == true)
                    {
                        DGVPrinter print = new DGVPrinter();
                        print.TitleFont = new Font("Franklin Gothic", 16.0f, FontStyle.Bold);
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
                    if (roomCheck.Checked == true)
                    {
                        DGVPrinter print = new DGVPrinter();
                        print.TitleFont = new Font("Franklin Gothic", 16.0f, FontStyle.Bold);
                        print.SubTitleFont = new Font(print.SubTitleFont.FontFamily, 10.0f);
                        print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                        print.PageNumbers = true;
                        print.PageNumberInHeader = false;
                        print.HeaderCellAlignment = StringAlignment.Near;
                        print.Footer = "Generated " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                        print.FooterFont = new Font("Franklin Gothic", 9.0f, FontStyle.Italic);
                        print.FooterSpacing = 15.0f;
                        //print.TableAlignment = DGVPrinter.Alignment.Center;
                        print.Title = "Room Service";
                        print.PrintDataGridView(roomGrid);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred. Please try again", "Error");
                }
                accountsGrid.Dock = DockStyle.Top;
                accountsGrid.Size = new Size(originalWidth, origianlHeight);
                roomGrid.Dock = DockStyle.Top;
                roomGrid.Size = new Size(originalWidth, origianlHeight);
            }
        }
    }
}
