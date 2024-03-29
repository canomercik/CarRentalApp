﻿namespace SQL_Project.Forms
{
    partial class RentalHistoryForm
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
            this.Make = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PickupDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReservationStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DropoffDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Make,
            this.Model,
            this.Year,
            this.PickupDate,
            this.DropoffDate,
            this.ReservationStatus});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(819, 260);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Make
            // 
            this.Make.Text = "Make";
            this.Make.Width = 100;
            // 
            // Model
            // 
            this.Model.Text = "Model";
            this.Model.Width = 100;
            // 
            // Year
            // 
            this.Year.Text = "Year";
            this.Year.Width = 100;
            // 
            // PickupDate
            // 
            this.PickupDate.Text = "Pickup Date";
            this.PickupDate.Width = 200;
            // 
            // ReservationStatus
            // 
            this.ReservationStatus.Text = "Status";
            this.ReservationStatus.Width = 100;
            // 
            // DropoffDate
            // 
            this.DropoffDate.Text = "Dropoff Date";
            this.DropoffDate.Width = 200;
            // 
            // RentalHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 302);
            this.Controls.Add(this.listView1);
            this.Name = "RentalHistoryForm";
            this.Text = "RentalHistoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Make;
        private System.Windows.Forms.ColumnHeader Model;
        private System.Windows.Forms.ColumnHeader Year;
        private System.Windows.Forms.ColumnHeader PickupDate;
        private System.Windows.Forms.ColumnHeader ReservationStatus;
        private System.Windows.Forms.ColumnHeader DropoffDate;
    }
}