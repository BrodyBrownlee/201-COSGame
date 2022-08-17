﻿using System;
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
        bool up, down, left, right, upshoot, downshoot, leftshoot, rightshoot;
        string move;



        Projectile[] bulletl = new Projectile[16];
        Projectile[] bulletr = new Projectile[16];
        Projectile[] bulletu = new Projectile[16];
        Projectile[] bulletd = new Projectile[16];


        Player Character = new Player();
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Down) { down = true; }
            if (e.KeyData == Keys.W) { upshoot = true; }
            if (e.KeyData == Keys.A) { leftshoot = true; }
            if (e.KeyData == Keys.S) { rightshoot = true; }
            if (e.KeyData == Keys.D) { downshoot = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Down) { down = false; }
            if (e.KeyData == Keys.W) { upshoot = false; }
            if (e.KeyData == Keys.A) { leftshoot = false; }
            if (e.KeyData == Keys.S) { rightshoot = false; }
            if (e.KeyData == Keys.D) { downshoot = false; }
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
          
        }

        private void Tmr_Movement_Tick(object sender, EventArgs e)
        {
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
            if (upshoot)
            {
                
            }
            if (downshoot)
            {

            }
            if (leftshoot)
            {

            }
            if (rightshoot)
            {

            }
        }
    }
}