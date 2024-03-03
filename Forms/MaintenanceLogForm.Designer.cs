namespace SQL_Project.Forms
{
    partial class MaintenanceLogForm
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
            this.MaintenanceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VehicleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaintenanceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaintenanceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaintenanceStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaintenanceID,
            this.VehicleID,
            this.MaintenanceDate,
            this.MaintenanceType,
            this.MaintenanceStatus});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(717, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // MaintenanceID
            // 
            this.MaintenanceID.Text = "MaintenanceID";
            this.MaintenanceID.Width = 100;
            // 
            // VehicleID
            // 
            this.VehicleID.Text = "VehicleID";
            this.VehicleID.Width = 100;
            // 
            // MaintenanceDate
            // 
            this.MaintenanceDate.Text = "Maintenance Date";
            this.MaintenanceDate.Width = 200;
            // 
            // MaintenanceType
            // 
            this.MaintenanceType.Text = "Maintenance Type";
            this.MaintenanceType.Width = 150;
            // 
            // MaintenanceStatus
            // 
            this.MaintenanceStatus.Text = "Maintenance Status";
            this.MaintenanceStatus.Width = 150;
            // 
            // MaintenanceLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 450);
            this.Controls.Add(this.listView1);
            this.Name = "MaintenanceLogForm";
            this.Text = "MaintenanceLogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader MaintenanceID;
        private System.Windows.Forms.ColumnHeader VehicleID;
        private System.Windows.Forms.ColumnHeader MaintenanceDate;
        private System.Windows.Forms.ColumnHeader MaintenanceType;
        private System.Windows.Forms.ColumnHeader MaintenanceStatus;
    }
}