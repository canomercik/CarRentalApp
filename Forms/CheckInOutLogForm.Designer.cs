namespace SQL_Project.Forms
{
    partial class CheckInOutLogForm
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
            this.CheckInOutID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReservationID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StaffID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckInTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckOutTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CheckInOutID,
            this.ReservationID,
            this.StaffID,
            this.CheckInTimestamp,
            this.CheckOutTimestamp});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(715, 425);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // CheckInOutID
            // 
            this.CheckInOutID.Text = "CheckInOutID";
            this.CheckInOutID.Width = 100;
            // 
            // ReservationID
            // 
            this.ReservationID.Text = "ReservationID";
            this.ReservationID.Width = 100;
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
            // CheckInOutLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 446);
            this.Controls.Add(this.listView1);
            this.Name = "CheckInOutLogForm";
            this.Text = "CheckInOutLogForm";
            this.Load += new System.EventHandler(this.CheckInOutLogForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader CheckInOutID;
        private System.Windows.Forms.ColumnHeader ReservationID;
        private System.Windows.Forms.ColumnHeader StaffID;
        private System.Windows.Forms.ColumnHeader CheckInTimestamp;
        private System.Windows.Forms.ColumnHeader CheckOutTimestamp;
    }
}