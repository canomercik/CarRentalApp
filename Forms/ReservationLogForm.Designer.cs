namespace SQL_Project.Forms
{
    partial class ReservationLogForm
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
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(720, 426);
            this.listView1.TabIndex = 0;
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
            // ReservationLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 450);
            this.Controls.Add(this.listView1);
            this.Name = "ReservationLogForm";
            this.Text = "ReservationLogForm";
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
    }
}