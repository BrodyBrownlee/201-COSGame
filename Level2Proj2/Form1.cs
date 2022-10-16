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
        string move, shoot;
        int angle, pnlWidth, pnlHeight, NumberOfProjectiles, NumberOfEnemies;
        Player Character = new Player(); //making my player object
        Object[] Wall = new Object[16];
        Rectangle[] UpS = new Rectangle[20];
        Rectangle[] DownS = new Rectangle[20];
        Rectangle[] RightS = new Rectangle[20];
        Rectangle[] LeftS = new Rectangle[20];
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true }); // removing flickering from my panel
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
            enterRoom();
        }
        private void Tmr_Collision_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Character.characterRec.IntersectsWith(UpS[i]))
                {
                    move = "left";
                 Character.pCollision(move);
                }
                if (Character.characterRec.IntersectsWith(LeftS[i]))
                {
                    move = "right";
                    Character.pCollision(move);
                }
                if (Character.characterRec.IntersectsWith(DownS[i]))
                {
                    move = "up";
                    Character.pCollision(move);
                }
                if (Character.characterRec.IntersectsWith(UpS[i]))
                {
                    move = "down";
                    Character.pCollision(move);
                }   
            }


        }
        private void Tmr_Movement_Tick(object sender, EventArgs e)
        {
            lblData.Text = GlobalVariables.roomx + "," + GlobalVariables.roomy + "";
            lblRems.Text = NumberOfEnemies + "";
            pnlWidth = panel1.Width;
            try
            {
                lblEnemyHP.Text = "" + GlobalVariables.enemies[0].enemyhp;
                lblEnemyHP2.Text = "" + GlobalVariables.enemies[1].enemyhp;
            }
            catch (Exception)
            {
            }
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
            if (upshoot)
            {
                angle = 0;
                shoot = "up";
                GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
            }
            else if (downshoot)
            {
                angle = 180;
                shoot = "down";
                GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
            }
            else if (leftshoot)
            {
                angle = 270;
                shoot = "left";
                GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
            }
            else if (rightshoot)
            {
                angle = 90;
                shoot = "right";
                GlobalVariables.bullets.Add(new Projectile(Character.characterRec, angle));
            }
            panel1.Invalidate();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Character.Drawplayer(g);
            for (int i = 0; i < 8; i++)
            {
                Wall[i].drawObject(g);

            }
            for (int i = 0; i < 8; i++)
            {
                g.FillRectangle(Brushes.Red, UpS[i]);
                g.FillRectangle(Brushes.Green, LeftS[i]);
                g.FillRectangle(Brushes.Blue, RightS[i]);
                g.FillRectangle(Brushes.Yellow, DownS[i]);
            }
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
            foreach (Enemy O in GlobalVariables.enemies.ToList()) foreach (Projectile p in GlobalVariables.bullets.ToList())
                {

                    for (int i = 0; i < GlobalVariables.enemies.Count; i++)
                    {
                        if (p.projRec.IntersectsWith(GlobalVariables.enemies[i].enemyRec))
                        {
                            GlobalVariables.enemies[i].enemyhp -= 1;

                            if (GlobalVariables.enemies[i].enemyhp <= 0)
                            {
                                GlobalVariables.enemies.RemoveAt(i);
                                NumberOfEnemies -= 1;
                                break;
                            }
                            GlobalVariables.bullets.Remove(p);
                        }
                    }
                }
        }
        private void enterRoom()
        {
            Wall[0] = new Object(50, 0, 325, 50);
            Wall[1] = new Object(425, 0, 325, 50);
            Wall[2] = new Object(0, 0, 50, 225);
            Wall[3] = new Object(0, 275, 50, 200);
            Wall[4] = new Object(50, 400, 325, 50);
            Wall[5] = new Object(425, 400, 325, 50);
            Wall[6] = new Object(750, 50, 50, 150);
            Wall[7] = new Object(750, 250, 50, 200);
            NumberOfEnemies += 2;
            GlobalVariables.enemies.Add(new Enemy(200, 200, 40, 40));
            GlobalVariables.enemies.Add(new Enemy(250, 250, 40, 40));
            for (int i = 0;i < 8; i++)
            {
                UpS[i] = new Rectangle(Wall[i].wallRec.Left, Wall[i].wallRec.Top, Wall[i].wallRec.Width, 20);
                RightS[i] = new Rectangle(Wall[i].wallRec.Right - 5, Wall[i].wallRec.Top + 5, 10, Wall[i].wallRec.Height - 5);
                LeftS[i] = new Rectangle(Wall[i].wallRec.Left, Wall[i].wallRec.Top, 10, Wall[i].wallRec.Height);
                DownS[i] = new Rectangle(Wall[i].wallRec.Left, Wall[i].wallRec.Bottom, Wall[i].wallRec.Width, 5);
            }
        }
    }
}
