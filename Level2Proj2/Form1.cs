using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace Level2Proj2
{
    public partial class Form1 : Form
    {
        Graphics g;
        
        int speed, roomx, roomy, x,y;
        int NumberOfProjectiles = 10;
        bool up, down, left, right, upshoot, downshoot, leftshoot, rightshoot;
        string move,shoot;
        int angle;
        int pnlWidth, pnlHeight; 

       
        List<Projectile> bullets = new List<Projectile>();
        Player Character = new Player(); //making my player object
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true }); // removing flickering from my panel
        }
       
        private void lblData_Click(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Down) { down = true; }
            if (e.KeyData == Keys.W) { upshoot = true; }
            if (e.KeyData == Keys.A) { leftshoot = true; }
            if (e.KeyData == Keys.S) { downshoot = true; }
            if (e.KeyData == Keys.D) { rightshoot = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Down) { down = false; }
            if (e.KeyData == Keys.W) { upshoot = false; }
            if (e.KeyData == Keys.A) { leftshoot = false; }
            if (e.KeyData == Keys.S) { downshoot = false; }
            if (e.KeyData == Keys.D) { rightshoot = false; }
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        
        private void Tmr_Movement_Tick(object sender, EventArgs e)
        {
            pnlWidth = panel1.Width;
            pnlHeight = panel1.Height;
            if (right)
                {
                    move = "right";
                    Character.Movecharacter(move);
                   

                }
         
            if (left)
            {
                move = "left";
                Character.Movecharacter(move);
              
            }
            if (up)
            {

                move = "up";
                Character.Movecharacter(move);
               
                }
            if (down)
            {
                move = "down";
                Character.Movecharacter(move);
            
            }
            
            panel1.Invalidate();
        }
        private void Tmr_Proj_Tick(object sender, EventArgs e)
        {
            lblData.Text = NumberOfProjectiles + "";

            if (NumberOfProjectiles > 0)
            {
                
                if (upshoot)
                {
                    NumberOfProjectiles--;
                    bullets.Add(new Projectile(Character.characterRec, angle));
                    shoot = "up";
                    upshoot = false;
                    angle = 0;
                }
                if (downshoot)
                {
                    NumberOfProjectiles--;
                
                        shoot = "down";
                    bullets.Add(new Projectile(Character.characterRec, angle));
                    downshoot = false;
                    angle = 180;


                }
                if (leftshoot)
                {
                    NumberOfProjectiles--;
                    bullets.Add(new Projectile(Character.characterRec, angle));
                    shoot = "left";
                    leftshoot = false;
                    angle = 270;
                }
                if (rightshoot)
                {
                   
                        shoot = "right";
                    bullets.Add(new Projectile(Character.characterRec, angle));
                        rightshoot = false;
                    angle = 90;
                    NumberOfProjectiles--;
                }
                if(NumberOfProjectiles == 0)
                {
                    NumberOfProjectiles += 10;
                }
                panel1.Invalidate();
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Character.Drawplayer(g);
            foreach (Projectile p in bullets)
            {
                p.Drawprojectile(g);
                p.Shootprojectile(shoot);
                if (p.projRec.X > ClientSize.Width || p.projRec.X < 0 || p.projRec.Y < 0 || p.projRec.Y > ClientSize.Height)
                {
                    bullets.Remove(p);
                    break;
                }
            }


        }

    }
}
