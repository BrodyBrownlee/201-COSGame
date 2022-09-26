
namespace Level2Proj2
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblData = new System.Windows.Forms.Label();
            this.Tmr_Movement = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Proj = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblData);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 451);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(535, 93);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(35, 13);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "label1";
            this.lblData.Click += new System.EventHandler(this.lblData_Click);
            // 
            // Tmr_Movement
            // 
            this.Tmr_Movement.Enabled = true;
            this.Tmr_Movement.Interval = 10;
            this.Tmr_Movement.Tick += new System.EventHandler(this.Tmr_Movement_Tick);
            // 
            // Tmr_Proj
            // 
            this.Tmr_Proj.Enabled = true;
            this.Tmr_Proj.Interval = 500;
            this.Tmr_Proj.Tick += new System.EventHandler(this.Tmr_Proj_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer Tmr_Movement;
        private System.Windows.Forms.Timer Tmr_Proj;
        private System.Windows.Forms.Label lblData;
    }
}

