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

        private void lblData_Click(object sender, EventArgs e)
        {

        }

        Projectile[] Bulletl = new Projectile[16];
        Projectile[] Bulletr = new Projectile[16];
        Projectile[] Bulletu = new Projectile[16];
        Projectile[] Bulletd = new Projectile[16];
        List<Projectile> bullets = new List<Projectile>();
        Player Character = new Player();
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

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            
            Character.Drawplayer(g);
            for (int i = 0; i <= 15; i++)
            {
                Bulletd[i].Drawprojectile(g);
                Bulletu[i].Drawprojectile(g);
                Bulletr[i].Drawprojectile(g);
                Bulletl[i].Drawprojectile(g);
            }
              

        }

        private void Tmr_Movement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 15; i++)
            {
                if (right)
                {
                    move = "right";
                    Character.Movecharacter(move);
                    Bulletr[i].Moveprojectile(move);
                    Bulletl[i].Moveprojectile(move);
                    Bulletu[i].Moveprojectile(move);
                    Bulletd[i].Moveprojectile(move);

                }
         
            if (left)
            {
                move = "left";
                Character.Movecharacter(move);
                    Bulletr[i].Moveprojectile(move);
                    Bulletl[i].Moveprojectile(move);
                    Bulletu[i].Moveprojectile(move);
                    Bulletd[i].Moveprojectile(move);
                }
            if (up)
            {
                move = "up";
                Character.Movecharacter(move);
                    Bulletr[i].Moveprojectile(move);
                    Bulletl[i].Moveprojectile(move);
                    Bulletu[i].Moveprojectile(move);
                    Bulletd[i].Moveprojectile(move);
                }
            if (down)
            {
                move = "down";
                Character.Movecharacter(move);
                    Bulletr[i].Moveprojectile(move);
                    Bulletl[i].Moveprojectile(move);
                    Bulletu[i].Moveprojectile(move);
                    Bulletd[i].Moveprojectile(move);
                }
            }
            panel1.Invalidate();
        }
        private void Tmr_Proj_Tick(object sender, EventArgs e)
        {

            lblData.Text = NumberOfProjectiles + "";
            for (int i = 0; i <= 15; i++)
            {
                if (upshoot)
                {
                    NumberOfProjectiles--;
                    if (NumberOfProjectiles != 0)
                    {
                        shoot = "up";
                        Bulletu[i].Shootprojectile(shoot);
                        upshoot = false;
                        i++;
                    }
                    else
                    {
                        NumberOfProjectiles += 10;
                    }
                   
                   
                }
                if (downshoot)
                {
                    NumberOfProjectiles--;
                    if (NumberOfProjectiles != 0)
                    {
                        shoot = "down";
                        Bulletd[i].Shootprojectile(shoot);
                        downshoot = false;
                    }
                    else
                    {
                        NumberOfProjectiles += 10;
                    }
                }
                if (leftshoot)
                {
                    NumberOfProjectiles--;
                    if (NumberOfProjectiles != 0)
                    {
                        shoot = "left";
                        Bulletl[i].Shootprojectile(shoot);
                        leftshoot = false;
                    }
                    else
                    {
                        NumberOfProjectiles += 10;
                    }
                }
                if (rightshoot)
                {
                    NumberOfProjectiles--;
                    if (NumberOfProjectiles != 0)
                    {
                        shoot = "right";
                        Bulletr[i].Shootprojectile(shoot);
                        rightshoot = false;
                    }
                    else
                    {
                        NumberOfProjectiles += 10;
                    }
                }

                Bulletu[i].bulletu[i].Y -= 8;
                Bulletd[i].bulletd[i].Y += 8;
                Bulletr[i].bulletr[i].X += 8;
                Bulletl[i].bulletl[i].X -= 8;


            }
        }
    }
}
