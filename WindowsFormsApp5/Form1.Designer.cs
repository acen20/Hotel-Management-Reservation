namespace WindowsFormsApp5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.headLabel = new System.Windows.Forms.Label();
            this.movementPanel = new System.Windows.Forms.Panel();
            this.Menupanel = new System.Windows.Forms.Panel();
            this.closeBTN = new System.Windows.Forms.Button();
            this.experienceicon = new System.Windows.Forms.PictureBox();
            this.reporticon = new System.Windows.Forms.PictureBox();
            this.roomserviceicon = new System.Windows.Forms.PictureBox();
            this.stafficon = new System.Windows.Forms.PictureBox();
            this.reservationicon = new System.Windows.Forms.PictureBox();
            this.dashboardicon = new System.Windows.Forms.PictureBox();
            this.dashboardbtn = new System.Windows.Forms.Button();
            this.experienceBTN = new System.Windows.Forms.Button();
            this.reportBTN = new System.Windows.Forms.Button();
            this.staffBTN = new System.Windows.Forms.Button();
            this.roomserviceBTN = new System.Windows.Forms.Button();
            this.reservationsBTN = new System.Windows.Forms.Button();
            this.dashboardusercontrol1 = new WindowsFormsApp5.dashboardusercontrol();
            this.reportUserControl1 = new WindowsFormsApp5.reportUserControl();
            this.expenditureUserControl1 = new WindowsFormsApp5.expenditureUserControl();
            this.roomServiceUserControl1 = new WindowsFormsApp5.roomServiceUserControl();
            this.staffUserControl1 = new WindowsFormsApp5.staffUserControl();
            this.reservationsUserControl1 = new WindowsFormsApp5.reservationsUserControl();
            this.refreshBTN = new System.Windows.Forms.Button();
            this.movementPanel.SuspendLayout();
            this.Menupanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.experienceicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporticon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomserviceicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stafficon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardicon)).BeginInit();
            this.SuspendLayout();
            // 
            // headLabel
            // 
            this.headLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(135)))));
            this.headLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.headLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headLabel.ForeColor = System.Drawing.Color.White;
            this.headLabel.Location = new System.Drawing.Point(812, 26);
            this.headLabel.Name = "headLabel";
            this.headLabel.Padding = new System.Windows.Forms.Padding(5, 5, 25, 5);
            this.headLabel.Size = new System.Drawing.Size(219, 31);
            this.headLabel.TabIndex = 2;
            this.headLabel.Text = "Dashboard";
            // 
            // movementPanel
            // 
            this.movementPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.movementPanel.Controls.Add(this.headLabel);
            this.movementPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.movementPanel.Location = new System.Drawing.Point(0, 0);
            this.movementPanel.Name = "movementPanel";
            this.movementPanel.Size = new System.Drawing.Size(1034, 57);
            this.movementPanel.TabIndex = 0;
            this.movementPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.movementPanel_MouseDown);
            this.movementPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movementPanel_MouseMove);
            this.movementPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.movementPanel_MouseUp);
            // 
            // Menupanel
            // 
            this.Menupanel.BackColor = System.Drawing.Color.Transparent;
            this.Menupanel.Controls.Add(this.refreshBTN);
            this.Menupanel.Controls.Add(this.closeBTN);
            this.Menupanel.Controls.Add(this.experienceicon);
            this.Menupanel.Controls.Add(this.reporticon);
            this.Menupanel.Controls.Add(this.roomserviceicon);
            this.Menupanel.Controls.Add(this.stafficon);
            this.Menupanel.Controls.Add(this.reservationicon);
            this.Menupanel.Controls.Add(this.dashboardicon);
            this.Menupanel.Controls.Add(this.dashboardbtn);
            this.Menupanel.Controls.Add(this.experienceBTN);
            this.Menupanel.Controls.Add(this.reportBTN);
            this.Menupanel.Controls.Add(this.staffBTN);
            this.Menupanel.Controls.Add(this.roomserviceBTN);
            this.Menupanel.Controls.Add(this.reservationsBTN);
            this.Menupanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menupanel.Location = new System.Drawing.Point(0, 57);
            this.Menupanel.Name = "Menupanel";
            this.Menupanel.Size = new System.Drawing.Size(166, 504);
            this.Menupanel.TabIndex = 3;
            // 
            // closeBTN
            // 
            this.closeBTN.BackColor = System.Drawing.Color.Maroon;
            this.closeBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closeBTN.FlatAppearance.BorderSize = 0;
            this.closeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBTN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBTN.ForeColor = System.Drawing.Color.AliceBlue;
            this.closeBTN.Location = new System.Drawing.Point(50, 324);
            this.closeBTN.Margin = new System.Windows.Forms.Padding(0);
            this.closeBTN.Name = "closeBTN";
            this.closeBTN.Size = new System.Drawing.Size(74, 39);
            this.closeBTN.TabIndex = 13;
            this.closeBTN.Text = "Close";
            this.closeBTN.UseVisualStyleBackColor = false;
            this.closeBTN.Click += new System.EventHandler(this.button10_Click);
            // 
            // experienceicon
            // 
            this.experienceicon.Image = ((System.Drawing.Image)(resources.GetObject("experienceicon.Image")));
            this.experienceicon.Location = new System.Drawing.Point(12, 200);
            this.experienceicon.Name = "experienceicon";
            this.experienceicon.Size = new System.Drawing.Size(26, 26);
            this.experienceicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.experienceicon.TabIndex = 12;
            this.experienceicon.TabStop = false;
            // 
            // reporticon
            // 
            this.reporticon.Image = ((System.Drawing.Image)(resources.GetObject("reporticon.Image")));
            this.reporticon.Location = new System.Drawing.Point(12, 162);
            this.reporticon.Name = "reporticon";
            this.reporticon.Size = new System.Drawing.Size(26, 26);
            this.reporticon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.reporticon.TabIndex = 11;
            this.reporticon.TabStop = false;
            // 
            // roomserviceicon
            // 
            this.roomserviceicon.Image = ((System.Drawing.Image)(resources.GetObject("roomserviceicon.Image")));
            this.roomserviceicon.Location = new System.Drawing.Point(12, 122);
            this.roomserviceicon.Name = "roomserviceicon";
            this.roomserviceicon.Size = new System.Drawing.Size(26, 26);
            this.roomserviceicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.roomserviceicon.TabIndex = 10;
            this.roomserviceicon.TabStop = false;
            // 
            // stafficon
            // 
            this.stafficon.Image = ((System.Drawing.Image)(resources.GetObject("stafficon.Image")));
            this.stafficon.Location = new System.Drawing.Point(12, 85);
            this.stafficon.Name = "stafficon";
            this.stafficon.Size = new System.Drawing.Size(26, 26);
            this.stafficon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.stafficon.TabIndex = 9;
            this.stafficon.TabStop = false;
            // 
            // reservationicon
            // 
            this.reservationicon.Image = ((System.Drawing.Image)(resources.GetObject("reservationicon.Image")));
            this.reservationicon.Location = new System.Drawing.Point(12, 46);
            this.reservationicon.Name = "reservationicon";
            this.reservationicon.Size = new System.Drawing.Size(26, 26);
            this.reservationicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.reservationicon.TabIndex = 8;
            this.reservationicon.TabStop = false;
            // 
            // dashboardicon
            // 
            this.dashboardicon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(135)))));
            this.dashboardicon.Image = ((System.Drawing.Image)(resources.GetObject("dashboardicon.Image")));
            this.dashboardicon.Location = new System.Drawing.Point(12, 7);
            this.dashboardicon.Name = "dashboardicon";
            this.dashboardicon.Size = new System.Drawing.Size(31, 26);
            this.dashboardicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.dashboardicon.TabIndex = 7;
            this.dashboardicon.TabStop = false;
            // 
            // dashboardbtn
            // 
            this.dashboardbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(135)))));
            this.dashboardbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.dashboardbtn.FlatAppearance.BorderSize = 0;
            this.dashboardbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardbtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardbtn.ForeColor = System.Drawing.Color.White;
            this.dashboardbtn.Location = new System.Drawing.Point(1, 0);
            this.dashboardbtn.Margin = new System.Windows.Forms.Padding(0);
            this.dashboardbtn.Name = "dashboardbtn";
            this.dashboardbtn.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.dashboardbtn.Size = new System.Drawing.Size(165, 39);
            this.dashboardbtn.TabIndex = 1;
            this.dashboardbtn.Text = "Dashboard";
            this.dashboardbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboardbtn.UseCompatibleTextRendering = true;
            this.dashboardbtn.UseVisualStyleBackColor = false;
            this.dashboardbtn.Click += new System.EventHandler(this.dashboardbtn_Click);
            // 
            // experienceBTN
            // 
            this.experienceBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.experienceBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.experienceBTN.FlatAppearance.BorderSize = 0;
            this.experienceBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.experienceBTN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experienceBTN.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.experienceBTN.Location = new System.Drawing.Point(1, 195);
            this.experienceBTN.Margin = new System.Windows.Forms.Padding(0);
            this.experienceBTN.Name = "experienceBTN";
            this.experienceBTN.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.experienceBTN.Size = new System.Drawing.Size(165, 39);
            this.experienceBTN.TabIndex = 6;
            this.experienceBTN.Text = "Expenditure";
            this.experienceBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.experienceBTN.UseVisualStyleBackColor = false;
            this.experienceBTN.Click += new System.EventHandler(this.experienceBTN_Click);
            // 
            // reportBTN
            // 
            this.reportBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.reportBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.reportBTN.FlatAppearance.BorderSize = 0;
            this.reportBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportBTN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBTN.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.reportBTN.Location = new System.Drawing.Point(1, 156);
            this.reportBTN.Margin = new System.Windows.Forms.Padding(0);
            this.reportBTN.Name = "reportBTN";
            this.reportBTN.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.reportBTN.Size = new System.Drawing.Size(165, 39);
            this.reportBTN.TabIndex = 5;
            this.reportBTN.Text = "Report";
            this.reportBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportBTN.UseVisualStyleBackColor = false;
            this.reportBTN.Click += new System.EventHandler(this.reportBTN_Click);
            // 
            // staffBTN
            // 
            this.staffBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.staffBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.staffBTN.FlatAppearance.BorderSize = 0;
            this.staffBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staffBTN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffBTN.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.staffBTN.Location = new System.Drawing.Point(1, 78);
            this.staffBTN.Margin = new System.Windows.Forms.Padding(0);
            this.staffBTN.Name = "staffBTN";
            this.staffBTN.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.staffBTN.Size = new System.Drawing.Size(165, 39);
            this.staffBTN.TabIndex = 4;
            this.staffBTN.Text = "Staff";
            this.staffBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.staffBTN.UseVisualStyleBackColor = false;
            this.staffBTN.Click += new System.EventHandler(this.staffBTN_Click);
            // 
            // roomserviceBTN
            // 
            this.roomserviceBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.roomserviceBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.roomserviceBTN.FlatAppearance.BorderSize = 0;
            this.roomserviceBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roomserviceBTN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomserviceBTN.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.roomserviceBTN.Location = new System.Drawing.Point(1, 117);
            this.roomserviceBTN.Margin = new System.Windows.Forms.Padding(0);
            this.roomserviceBTN.Name = "roomserviceBTN";
            this.roomserviceBTN.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.roomserviceBTN.Size = new System.Drawing.Size(165, 39);
            this.roomserviceBTN.TabIndex = 3;
            this.roomserviceBTN.Text = "Room Service";
            this.roomserviceBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roomserviceBTN.UseVisualStyleBackColor = false;
            this.roomserviceBTN.Click += new System.EventHandler(this.roomserviceBTN_Click);
            // 
            // reservationsBTN
            // 
            this.reservationsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.reservationsBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.reservationsBTN.FlatAppearance.BorderSize = 0;
            this.reservationsBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reservationsBTN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationsBTN.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.reservationsBTN.Location = new System.Drawing.Point(1, 39);
            this.reservationsBTN.Margin = new System.Windows.Forms.Padding(0);
            this.reservationsBTN.Name = "reservationsBTN";
            this.reservationsBTN.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.reservationsBTN.Size = new System.Drawing.Size(165, 39);
            this.reservationsBTN.TabIndex = 2;
            this.reservationsBTN.Text = "Reservation";
            this.reservationsBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reservationsBTN.UseVisualStyleBackColor = false;
            this.reservationsBTN.Click += new System.EventHandler(this.reservationsBTN_Click);
            // 
            // dashboardusercontrol1
            // 
            this.dashboardusercontrol1.AutoSize = true;
            this.dashboardusercontrol1.BackColor = System.Drawing.Color.White;
            this.dashboardusercontrol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardusercontrol1.Location = new System.Drawing.Point(0, 0);
            this.dashboardusercontrol1.Name = "dashboardusercontrol1";
            this.dashboardusercontrol1.Size = new System.Drawing.Size(1034, 561);
            this.dashboardusercontrol1.TabIndex = 10;
            // 
            // reportUserControl1
            // 
            this.reportUserControl1.AutoSize = true;
            this.reportUserControl1.BackColor = System.Drawing.Color.White;
            this.reportUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportUserControl1.Location = new System.Drawing.Point(0, 0);
            this.reportUserControl1.Name = "reportUserControl1";
            this.reportUserControl1.Size = new System.Drawing.Size(1034, 561);
            this.reportUserControl1.TabIndex = 9;
            // 
            // expenditureUserControl1
            // 
            this.expenditureUserControl1.BackColor = System.Drawing.Color.White;
            this.expenditureUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expenditureUserControl1.Location = new System.Drawing.Point(0, 0);
            this.expenditureUserControl1.Name = "expenditureUserControl1";
            this.expenditureUserControl1.Size = new System.Drawing.Size(1034, 561);
            this.expenditureUserControl1.TabIndex = 8;
            // 
            // roomServiceUserControl1
            // 
            this.roomServiceUserControl1.AutoScroll = true;
            this.roomServiceUserControl1.AutoSize = true;
            this.roomServiceUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomServiceUserControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomServiceUserControl1.Location = new System.Drawing.Point(0, 0);
            this.roomServiceUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.roomServiceUserControl1.Name = "roomServiceUserControl1";
            this.roomServiceUserControl1.Size = new System.Drawing.Size(1034, 561);
            this.roomServiceUserControl1.TabIndex = 7;
            // 
            // staffUserControl1
            // 
            this.staffUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staffUserControl1.Location = new System.Drawing.Point(0, 0);
            this.staffUserControl1.Name = "staffUserControl1";
            this.staffUserControl1.Size = new System.Drawing.Size(1034, 561);
            this.staffUserControl1.TabIndex = 6;
            // 
            // reservationsUserControl1
            // 
            this.reservationsUserControl1.AutoSize = true;
            this.reservationsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reservationsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.reservationsUserControl1.Name = "reservationsUserControl1";
            this.reservationsUserControl1.Size = new System.Drawing.Size(1034, 561);
            this.reservationsUserControl1.TabIndex = 4;
            // 
            // refreshBTN
            // 
            this.refreshBTN.BackColor = System.Drawing.Color.ForestGreen;
            this.refreshBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.refreshBTN.FlatAppearance.BorderSize = 0;
            this.refreshBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBTN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBTN.ForeColor = System.Drawing.Color.AliceBlue;
            this.refreshBTN.Location = new System.Drawing.Point(50, 276);
            this.refreshBTN.Margin = new System.Windows.Forms.Padding(0);
            this.refreshBTN.Name = "refreshBTN";
            this.refreshBTN.Size = new System.Drawing.Size(74, 39);
            this.refreshBTN.TabIndex = 14;
            this.refreshBTN.Text = "Refresh";
            this.refreshBTN.UseVisualStyleBackColor = false;
            this.refreshBTN.Click += new System.EventHandler(this.refreshBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1034, 561);
            this.Controls.Add(this.Menupanel);
            this.Controls.Add(this.movementPanel);
            this.Controls.Add(this.reportUserControl1);
            this.Controls.Add(this.expenditureUserControl1);
            this.Controls.Add(this.roomServiceUserControl1);
            this.Controls.Add(this.staffUserControl1);
            this.Controls.Add(this.reservationsUserControl1);
            this.Controls.Add(this.dashboardusercontrol1);
            this.MinimumSize = new System.Drawing.Size(800, 39);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.movementPanel.ResumeLayout(false);
            this.Menupanel.ResumeLayout(false);
            this.Menupanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.experienceicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporticon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomserviceicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stafficon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Panel movementPanel;
        private System.Windows.Forms.Panel Menupanel;
        private System.Windows.Forms.Button closeBTN;
        private System.Windows.Forms.PictureBox experienceicon;
        private System.Windows.Forms.PictureBox reporticon;
        private System.Windows.Forms.PictureBox roomserviceicon;
        private System.Windows.Forms.PictureBox stafficon;
        private System.Windows.Forms.PictureBox reservationicon;
        private System.Windows.Forms.PictureBox dashboardicon;
        private System.Windows.Forms.Button dashboardbtn;
        private System.Windows.Forms.Button experienceBTN;
        private System.Windows.Forms.Button reportBTN;
        private System.Windows.Forms.Button staffBTN;
        private System.Windows.Forms.Button roomserviceBTN;
        private System.Windows.Forms.Button reservationsBTN;
        private reservationsUserControl reservationsUserControl1;
        private staffUserControl staffUserControl1;
        private roomServiceUserControl roomServiceUserControl1;
        private expenditureUserControl expenditureUserControl1;
        private reportUserControl reportUserControl1;
        private dashboardusercontrol dashboardusercontrol1;
        private System.Windows.Forms.Button refreshBTN;
    }
}

