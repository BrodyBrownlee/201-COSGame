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
        bool up, down, left, right, upshoot, downshoot, leftshoot, rightshoot;
        string move,shoot;
        int angle, pnlWidth, pnlHeight, NumberOfProjectiles, NumberOfEnemies;
        int[] enemyhp = new int[16];
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
            if (e.KeyData == Keys.W) { up = true; }
            if (e.KeyData == Keys.A) { left = true; }
            if (e.KeyData == Keys.D) { right = true; }
            if (e.KeyData == Keys.S) { down = true; }
            if (e.KeyData == Keys.Up) { upshoot = true; }
            if (e.KeyData == Keys.Left) { leftshoot = true; }
            if (e.KeyData == Keys.Down) { downshoot = true; }
            if (e.KeyData == Keys.Right) { rightshoot = true; }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W) { up = false; }
            if (e.KeyData == Keys.A) { left = false; }
            if (e.KeyData == Keys.D) { right = false; }
            if (e.KeyData == Keys.S) { down = false; }
            if (e.KeyData == Keys.Up) { upshoot = false; }
            if (e.KeyData == Keys.Left) { leftshoot = false; }
            if (e.KeyData == Keys.Down) { downshoot = false; }
            if (e.KeyData == Keys.Right) { rightshoot = false; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NumberOfProjectiles = 10;
            GlobalVariables.enemies.Add(new Enemy());
            NumberOfEnemies += 1;
        }
        private void Tmr_Movement_Tick(object sender, EventArgs e)
        {
            lblData.Text = Character.roomx + "," + Character.roomy + "";
            pnlWidth = panel1.Width;
            pnlHeight = panel1.Height;
            if (right)
            {
                move = "right";
                Character.Movecharacter(move, pnlHeight, pnlWidth);
            }
         
            if (left)
            {
                move = "left";
                Character.Movecharacter(move, pnlHeight, pnlWidth);
            }
            if (up)
            {
                move = "up";
                Character.Movecharacter(move, pnlHeight, pnlWidth);
                }
            if (down)
            {
                move = "down";
                Character.Movecharacter(move, pnlHeight, pnlWidth);
            }
            panel1.Invalidate();
        }
        private void Tmr_Proj_Tick(object sender, EventArgs e)
        {
            if (NumberOfProjectiles > 0)
            {       
                if (upshoot)
                {
                    angle = 0;
                    shoot = "up";
                    NumberOfProjectiles--;
                    GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
                    upshoot = false;
                }
                else if (downshoot)
                {
                    angle = 180;
                    NumberOfProjectiles--;
                    shoot = "down";
                    GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
                    downshoot = false;
                }
                else if (leftshoot)
                {
                    angle = 270;
                    shoot = "left";
                    NumberOfProjectiles--;
                    GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
                    leftshoot = false;
                }
                else if (rightshoot)
                {
                    angle = 90;
                    shoot = "right";
                    GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
                    rightshoot = false;
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
            foreach (Enemy O in GlobalVariables.enemies)
            {
                O.Drawenemy(g);
            }
            foreach (Projectile p in GlobalVariables.bullets)
            {
                p.Drawprojectile(g);
                p.Shootprojectile(shoot);
                if (p.projRec.X > ClientSize.Width || p.projRec.X < 0 || p.projRec.Y < 0 || p.projRec.Y > ClientSize.Height)
                {
                    GlobalVariables.bullets.Remove(p);
                    break;
                }
            }
            foreach (Projectile p in GlobalVariables.bullets) foreach (Enemy O in GlobalVariables.enemies)
                {
                    if (p.projRec.IntersectsWith(O.enemyRec))
                    {
                       
                    }
                }
        }
    }
}
