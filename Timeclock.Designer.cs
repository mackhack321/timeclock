namespace Timeclock
{
    partial class Timeclock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timeclock));
            this.buttonClockIn = new System.Windows.Forms.Button();
            this.buttonClockOut = new System.Windows.Forms.Button();
            this.textBoxEmployeeID = new System.Windows.Forms.TextBox();
            this.labelEmployeeID = new System.Windows.Forms.Label();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.buttonNewID = new System.Windows.Forms.Button();
            this.labelOr = new System.Windows.Forms.Label();
            this.textBoxNewID = new System.Windows.Forms.TextBox();
            this.labelNewID = new System.Windows.Forms.Label();
            this.buttonCreateID = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClockIn
            // 
            this.buttonClockIn.Enabled = false;
            this.buttonClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 75F, System.Drawing.FontStyle.Bold);
            this.buttonClockIn.Location = new System.Drawing.Point(684, 12);
            this.buttonClockIn.Name = "buttonClockIn";
            this.buttonClockIn.Size = new System.Drawing.Size(500, 250);
            this.buttonClockIn.TabIndex = 0;
            this.buttonClockIn.Text = "Clock In";
            this.buttonClockIn.UseVisualStyleBackColor = true;
            // 
            // buttonClockOut
            // 
            this.buttonClockOut.Enabled = false;
            this.buttonClockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClockOut.Location = new System.Drawing.Point(684, 331);
            this.buttonClockOut.Name = "buttonClockOut";
            this.buttonClockOut.Size = new System.Drawing.Size(500, 250);
            this.buttonClockOut.TabIndex = 1;
            this.buttonClockOut.Text = "Clock Out";
            this.buttonClockOut.UseVisualStyleBackColor = true;
            // 
            // textBoxEmployeeID
            // 
            this.textBoxEmployeeID.Location = new System.Drawing.Point(239, 242);
            this.textBoxEmployeeID.Name = "textBoxEmployeeID";
            this.textBoxEmployeeID.Size = new System.Drawing.Size(140, 20);
            this.textBoxEmployeeID.TabIndex = 2;
            // 
            // labelEmployeeID
            // 
            this.labelEmployeeID.AutoSize = true;
            this.labelEmployeeID.Location = new System.Drawing.Point(251, 226);
            this.labelEmployeeID.Name = "labelEmployeeID";
            this.labelEmployeeID.Size = new System.Drawing.Size(118, 13);
            this.labelEmployeeID.TabIndex = 3;
            this.labelEmployeeID.Text = "Enter your Employee ID";
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(254, 268);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(108, 39);
            this.buttonLogIn.TabIndex = 4;
            this.buttonLogIn.Text = "Log In";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // buttonNewID
            // 
            this.buttonNewID.Location = new System.Drawing.Point(254, 362);
            this.buttonNewID.Name = "buttonNewID";
            this.buttonNewID.Size = new System.Drawing.Size(108, 39);
            this.buttonNewID.TabIndex = 4;
            this.buttonNewID.Text = "Make New ID";
            this.buttonNewID.UseVisualStyleBackColor = true;
            this.buttonNewID.Click += new System.EventHandler(this.buttonNewID_Click);
            // 
            // labelOr
            // 
            this.labelOr.AutoSize = true;
            this.labelOr.Location = new System.Drawing.Point(292, 331);
            this.labelOr.Name = "labelOr";
            this.labelOr.Size = new System.Drawing.Size(27, 13);
            this.labelOr.TabIndex = 3;
            this.labelOr.Text = "Or...";
            // 
            // textBoxNewID
            // 
            this.textBoxNewID.Location = new System.Drawing.Point(239, 432);
            this.textBoxNewID.Name = "textBoxNewID";
            this.textBoxNewID.Size = new System.Drawing.Size(140, 20);
            this.textBoxNewID.TabIndex = 2;
            this.textBoxNewID.Visible = false;
            // 
            // labelNewID
            // 
            this.labelNewID.AutoSize = true;
            this.labelNewID.Location = new System.Drawing.Point(243, 416);
            this.labelNewID.Name = "labelNewID";
            this.labelNewID.Size = new System.Drawing.Size(136, 13);
            this.labelNewID.TabIndex = 3;
            this.labelNewID.Text = "Enter the new Employee ID";
            this.labelNewID.Visible = false;
            // 
            // buttonCreateID
            // 
            this.buttonCreateID.Location = new System.Drawing.Point(269, 458);
            this.buttonCreateID.Name = "buttonCreateID";
            this.buttonCreateID.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateID.TabIndex = 5;
            this.buttonCreateID.Text = "Create";
            this.buttonCreateID.UseVisualStyleBackColor = true;
            this.buttonCreateID.Visible = false;
            // 
            // Timeclock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 649);
            this.Controls.Add(this.buttonCreateID);
            this.Controls.Add(this.buttonNewID);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.labelOr);
            this.Controls.Add(this.labelNewID);
            this.Controls.Add(this.labelEmployeeID);
            this.Controls.Add(this.textBoxNewID);
            this.Controls.Add(this.textBoxEmployeeID);
            this.Controls.Add(this.buttonClockOut);
            this.Controls.Add(this.buttonClockIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Timeclock";
            this.Text = "Timeclock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClockIn;
        private System.Windows.Forms.Button buttonClockOut;
        private System.Windows.Forms.TextBox textBoxEmployeeID;
        private System.Windows.Forms.Label labelEmployeeID;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.Button buttonNewID;
        private System.Windows.Forms.Label labelOr;
        private System.Windows.Forms.TextBox textBoxNewID;
        private System.Windows.Forms.Label labelNewID;
        private System.Windows.Forms.Button buttonCreateID;
    }
}

