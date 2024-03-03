namespace SQL_Project.Forms
{
    partial class PenaltiesLogForm
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
            this.PenaltyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReservationID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LateReturnTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PenaltyAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PenaltyID,
            this.CustomerID,
            this.ReservationID,
            this.LateReturnTimestamp,
            this.PenaltyAmount});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(718, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // PenaltyID
            // 
            this.PenaltyID.Text = "PenaltyID";
            this.PenaltyID.Width = 100;
            // 
            // CustomerID
            // 
            this.CustomerID.Text = "CustomerID";
            this.CustomerID.Width = 100;
            // 
            // ReservationID
            // 
            this.ReservationID.Text = "ReservationID";
            this.ReservationID.Width = 100;
            // 
            // LateReturnTimestamp
            // 
            this.LateReturnTimestamp.Text = "Late Return Timestamp";
            this.LateReturnTimestamp.Width = 200;
            // 
            // PenaltyAmount
            // 
            this.PenaltyAmount.Text = "Penalty Amount";
            this.PenaltyAmount.Width = 200;
            // 
            // PenaltiesLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 450);
            this.Controls.Add(this.listView1);
            this.Name = "PenaltiesLogForm";
            this.Text = "PenaltiesLogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader PenaltyID;
        private System.Windows.Forms.ColumnHeader CustomerID;
        private System.Windows.Forms.ColumnHeader ReservationID;
        private System.Windows.Forms.ColumnHeader LateReturnTimestamp;
        private System.Windows.Forms.ColumnHeader PenaltyAmount;
    }
}