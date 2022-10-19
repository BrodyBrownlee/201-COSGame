
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
            this.pnl_Form = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEnemyHP2 = new System.Windows.Forms.Label();
            this.lblRems = new System.Windows.Forms.Label();
            this.lblEnemyHP = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.Tmr_Movement = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Proj = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Collision = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Door = new System.Windows.Forms.Timer(this.components);
            this.pnl_Form.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Form
            // 
            this.pnl_Form.Controls.Add(this.btnStart);
            this.pnl_Form.Controls.Add(this.txtName);
            this.pnl_Form.Controls.Add(this.lblEnemyHP2);
            this.pnl_Form.Controls.Add(this.lblRems);
            this.pnl_Form.Controls.Add(this.lblEnemyHP);
            this.pnl_Form.Controls.Add(this.lblData);
            this.pnl_Form.Location = new System.Drawing.Point(0, 0);
            this.pnl_Form.Name = "pnl_Form";
            this.pnl_Form.Size = new System.Drawing.Size(800, 450);
            this.pnl_Form.TabIndex = 0;
            this.pnl_Form.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Form_Paint);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(309, 122);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 42);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(321, 189);
            this.txtName.MaxLength = 14;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 4;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress_1);
            // 
            // lblEnemyHP2
            // 
            this.lblEnemyHP2.AutoSize = true;
            this.lblEnemyHP2.Location = new System.Drawing.Point(40, 55);
            this.lblEnemyHP2.Name = "lblEnemyHP2";
            this.lblEnemyHP2.Size = new System.Drawing.Size(69, 13);
            this.lblEnemyHP2.TabIndex = 3;
            this.lblEnemyHP2.Text = "Enemy HP2: ";
            // 
            // lblRems
            // 
            this.lblRems.AutoSize = true;
            this.lblRems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRems.Location = new System.Drawing.Point(595, 44);
            this.lblRems.Name = "lblRems";
            this.lblRems.Size = new System.Drawing.Size(193, 24);
            this.lblRems.TabIndex = 2;
            this.lblRems.Text = "Enemies Remaning";
            // 
            // lblEnemyHP
            // 
            this.lblEnemyHP.AutoSize = true;
            this.lblEnemyHP.Location = new System.Drawing.Point(40, 29);
            this.lblEnemyHP.Name = "lblEnemyHP";
            this.lblEnemyHP.Size = new System.Drawing.Size(63, 13);
            this.lblEnemyHP.TabIndex = 1;
            this.lblEnemyHP.Text = "Enemy HP: ";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(616, 9);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(172, 24);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "RoomX + RoomY";
            // 
            // Tmr_Movement
            // 
            this.Tmr_Movement.Interval = 10;
            this.Tmr_Movement.Tick += new System.EventHandler(this.Tmr_Movement_Tick);
            // 
            // Tmr_Proj
            // 
            this.Tmr_Proj.Interval = 500;
            this.Tmr_Proj.Tick += new System.EventHandler(this.Tmr_Proj_Tick);
            // 
            // Tmr_Collision
            // 
            this.Tmr_Collision.Interval = 1;
            this.Tmr_Collision.Tick += new System.EventHandler(this.Tmr_Collision_Tick);
            // 
            // Tmr_Door
            // 
            this.Tmr_Door.Interval = 1;
            this.Tmr_Door.Tick += new System.EventHandler(this.Tmr_Door_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_Form);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.pnl_Form.ResumeLayout(false);
            this.pnl_Form.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Form;
        private System.Windows.Forms.Timer Tmr_Movement;
        private System.Windows.Forms.Timer Tmr_Proj;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblEnemyHP;
        private System.Windows.Forms.Label lblRems;
        private System.Windows.Forms.Label lblEnemyHP2;
        private System.Windows.Forms.Timer Tmr_Collision;
        private System.Windows.Forms.Timer Tmr_Door;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnStart;
    }
}

