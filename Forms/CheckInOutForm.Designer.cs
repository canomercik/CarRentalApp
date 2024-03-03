namespace SQL_Project.Forms
{
    partial class CheckInOutForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ReservationID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VehicleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PickupDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DropoffDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReservationStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.CheckInOutID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StaffID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckInTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckOutTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ReservationID,
            this.CustomerID,
            this.VehicleID,
            this.PickupDate,
            this.DropoffDate,
            this.ReservationStatus});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 200);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ReservationID
            // 
            this.ReservationID.Text = "ReservationID";
            this.ReservationID.Width = 90;
            // 
            // CustomerID
            // 
            this.CustomerID.Text = "CustomerID";
            this.CustomerID.Width = 75;
            // 
            // VehicleID
            // 
            this.VehicleID.Text = "VehicleID";
            this.VehicleID.Width = 75;
            // 
            // PickupDate
            // 
            this.PickupDate.Text = "Pickup Date";
            this.PickupDate.Width = 180;
            // 
            // DropoffDate
            // 
            this.DropoffDate.Text = "Dropoff Date";
            this.DropoffDate.Width = 180;
            // 
            // ReservationStatus
            // 
            this.ReservationStatus.Text = "Reservation Status";
            this.ReservationStatus.Width = 110;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CheckInOutID,
            this.columnHeader1,
            this.StaffID,
            this.CheckInTimestamp,
            this.CheckOutTimestamp});
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(12, 218);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(776, 200);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // CheckInOutID
            // 
            this.CheckInOutID.Text = "CheckInOutID";
            this.CheckInOutID.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ReservationID";
            this.columnHeader1.Width = 100;
            // 
            // StaffID
            // 
            this.StaffID.Text = "StaffID";
            this.StaffID.Width = 100;
            // 
            // CheckInTimestamp
            // 
            this.CheckInTimestamp.Text = "CheckInTimestamp";
            this.CheckInTimestamp.Width = 200;
            // 
            // CheckOutTimestamp
            // 
            this.CheckOutTimestamp.Text = "CheckOutTimestamp";
            this.CheckOutTimestamp.Width = 200;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aquamarine;
            this.button1.Location = new System.Drawing.Point(794, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 74);
            this.button1.TabIndex = 3;
            this.button1.Text = "CheckIn";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Pink;
            this.button2.Location = new System.Drawing.Point(794, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 74);
            this.button2.TabIndex = 3;
            this.button2.Text = "CheckOut";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckInOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 431);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Name = "CheckInOutForm";
            this.Text = "CheckInOutForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ReservationID;
        private System.Windows.Forms.ColumnHeader CustomerID;
        private System.Windows.Forms.ColumnHeader VehicleID;
        private System.Windows.Forms.ColumnHeader PickupDate;
        private System.Windows.Forms.ColumnHeader DropoffDate;
        private System.Windows.Forms.ColumnHeader ReservationStatus;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader CheckInOutID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader StaffID;
        private System.Windows.Forms.ColumnHeader CheckInTimestamp;
        private System.Windows.Forms.ColumnHeader CheckOutTimestamp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}