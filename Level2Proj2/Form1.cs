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
        bool up, down, left, right, upshoot, downshoot, leftshoot, rightshoot,upcollide,downcollide,leftcollide,rightcollide,eup,edown,eleft,eright, start;
        string move, shoot, name;
        int angle, pnlWidth, pnlHeight, NumberOfProjectiles, NumberOfEnemies;
        Player Character = new Player(); //making my player object
        Object[] Wall = new Object[12];
        Rectangle[] UpS = new Rectangle[20];
        Rectangle[] DownS = new Rectangle[20];
        Rectangle[] RightS = new Rectangle[20];
        Rectangle[] LeftS = new Rectangle[20];
        /*Rectangle[] EnemyUpS = new Rectangle[20];
        Rectangle[] EnemyDownS = new Rectangle[20];
        Rectangle[] EnemyRightS = new Rectangle[20];
        Rectangle[] EnemyLeftS = new Rectangle[20];*/
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnl_Form, new object[] { true }); // removing flickering from my panel
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
            start = false;
            lblData.Visible = false;
            lblEnemyHP.Visible = false;
            lblEnemyHP2.Visible = false;
            lblRems.Visible = false;
            GlobalVariables.roomChange = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            btnStart.Visible = false;
            btnStart.Enabled = false;
            txtName.ReadOnly = true;
            txtName.Enabled = false;
            txtName.Visible = false;
            enterRoom();
        }
      private void txtName_KeyPress_1(object sender, KeyPressEventArgs e)
      {    
          if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
          {
              e.Handled = true;
          }
      }
          private void Tmr_Collision_Tick(object sender, EventArgs e)
      {
          move = "none";
          Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide);
          for (int i = 0; i < 12; i++)
          {
              if (Character.characterRec.IntersectsWith(RightS[i]))
              {
                  rightcollide = true;
                  Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide);
              }
              else
              {
                  rightcollide = false;
              }
              if (Character.characterRec.IntersectsWith(LeftS[i]))
              {
                  leftcollide = true;
                  Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide);
              }
              else
              {
                  leftcollide = false;
              }
              if (Character.characterRec.IntersectsWith(DownS[i]))
              {
                  downcollide = true;
                  Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide);
              }
              else
              {
                  downcollide = false;
              }
              if (Character.characterRec.IntersectsWith(UpS[i]))
              {
                  upcollide = true;
                  Character.pCollision(move,upcollide,downcollide,leftcollide,rightcollide);
              }
              else
              {
                  upcollide = false;
              }
          }
          rightcollide = false;
          upcollide = false;
          downcollide = false;
          leftcollide = false;
          move = "none";

          foreach (Enemy enemy in GlobalVariables.enemies)
          {
             /* enemy.eCollision(move, upcollide, downcollide, leftcollide, rightcollide);
              for (int i = 0; i < 12; i++)
              {
                  if (enemy.enemyRec.IntersectsWith(RightS[i]))
                  {
                      rightcollide = true;
                      enemy.eCollision(move, upcollide, downcollide, leftcollide, rightcollide);
                  }
                  if (enemy.enemyRec.IntersectsWith(LeftS[i]))
                  {
                      leftcollide = true;
                      enemy.eCollision(move, upcollide, downcollide, leftcollide, rightcollide);
                  }
                  if (enemy.enemyRec.IntersectsWith(DownS[i]))
                  {
                      downcollide = true;
                      enemy.eCollision(move, upcollide, downcollide, leftcollide, rightcollide);
                  }
                  if (enemy.enemyRec.IntersectsWith(UpS[i]))
                  {
                      upcollide = true;
                      enemy.eCollision(move, upcollide, downcollide, leftcollide, rightcollide);
                  }
              }*/
            foreach (Enemy enemy2 in GlobalVariables.enemies)
                {
                    enemy.eCollision(move, eup, edown, eleft, eright);
                    if (enemy2 != enemy)
                    {
                        if (enemy.enemyLeftRec.IntersectsWith(enemy2.enemyRightRec))
                        {
                            eleft = true;
                        }
                        else
                        {
                            eleft = false;
                        }

                        if (enemy.enemyTopRec.IntersectsWith(enemy2.enemyBottomRec))
                        {
                            edown = true;
                            enemy.eCollision(move, eup, edown, eleft, eright);
                        }
                        else
                        {
                            edown = false;
                        }
                        if (enemy.enemyRightRec.IntersectsWith(enemy2.enemyRightRec))
                        {
                            eright = true;
                            enemy.eCollision(move, eup, edown, eleft, eright);
                        }
                        else
                        {
                            eright = false;
                        }
                        if (enemy.enemyBottomRec.IntersectsWith(enemy2.enemyTopRec))
                        {
                            eup = true;
                            enemy.eCollision(move, eup, edown, eleft, eright);
                        }
                        else
                        {
                            eup = false;
                        }
                    }
                }
            }
        }
        private void Tmr_Movement_Tick(object sender, EventArgs e)
        {
            lblData.Text = GlobalVariables.roomx + "," + GlobalVariables.roomy + "";
            lblRems.Text = NumberOfEnemies + "";
            pnlWidth = pnl_Form.Width;
            try
            {
                lblEnemyHP.Text = "" + GlobalVariables.enemies[0].enemyhp;
                lblEnemyHP2.Text = "" + GlobalVariables.enemies[1].enemyhp;
            }
            catch (Exception)
            {
            }
            pnlHeight = pnl_Form.Height;
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
            pnl_Form.Invalidate();
        }
        private void Tmr_Proj_Tick(object sender, EventArgs e)
        {
            //logic for my projectiles shooting 
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
            pnl_Form.Invalidate();
        }
        private void Tmr_Door_Tick(object sender, EventArgs e)
        {
            if (GlobalVariables.roomChange == true)
            {
                enterRoom();
                GlobalVariables.roomChange = false;
            }
            //if all the enemies have been defeated then make the doors disapear
            if (GlobalVariables.enemies.Count() <= 0)
            {
                Wall[8].wallRec = Rectangle.Empty;
                Wall[9].wallRec = Rectangle.Empty;
                Wall[10].wallRec = Rectangle.Empty;
                Wall[11].wallRec = Rectangle.Empty;
                for (int i = 7; i < 12; i++)
                {
                    UpS[i] = Rectangle.Empty;
                    RightS[i] = Rectangle.Empty;
                    LeftS[i] = Rectangle.Empty;
                    DownS[i] = Rectangle.Empty;
                }
            }
            for (int i = 0; i < GlobalVariables.enemies.Count; i++)
            {
                if (GlobalVariables.enemies[i].enemyRec.X < Character.characterRec.X) //if the enemy is to the left of the character
                {
                    GlobalVariables.enemies[i].enemyRec.X += 1;
                    GlobalVariables.enemies[i].enemyBottomRec.X += 1;
                    GlobalVariables.enemies[i].enemyTopRec.X += 1;
                    GlobalVariables.enemies[i].enemyRightRec.X += 1;
                    GlobalVariables.enemies[i].enemyLeftRec.X += 1;

                }
                if (GlobalVariables.enemies[i].enemyRec.X > Character.characterRec.X)//if the enemy is to the right of the character
                {
                    GlobalVariables.enemies[i].enemyRec.X -= 1;
                    GlobalVariables.enemies[i].enemyBottomRec.X -= 1;
                    GlobalVariables.enemies[i].enemyTopRec.X -= 1;
                    GlobalVariables.enemies[i].enemyRightRec.X -= 1;
                    GlobalVariables.enemies[i].enemyLeftRec.X -= 1;
                }

                if (GlobalVariables.enemies[i].enemyRec.Y < Character.characterRec.Y)//if the enemy is above the player
                {
                    GlobalVariables.enemies[i].enemyRec.Y += 1;
                    GlobalVariables.enemies[i].enemyBottomRec.Y += 1;
                    GlobalVariables.enemies[i].enemyTopRec.Y += 1;
                    GlobalVariables.enemies[i].enemyRightRec.Y += 1;
                    GlobalVariables.enemies[i].enemyLeftRec.Y += 1;
                }
                if (GlobalVariables.enemies[i].enemyRec.Y > Character.characterRec.Y)//if the enemy is below the player
                {
                    GlobalVariables.enemies[i].enemyRec.Y -= 1;
                    GlobalVariables.enemies[i].enemyBottomRec.Y -= 1;
                    GlobalVariables.enemies[i].enemyTopRec.Y -= 1;
                    GlobalVariables.enemies[i].enemyRightRec.Y -= 1;
                    GlobalVariables.enemies[i].enemyLeftRec.Y -= 1;
                }
            }
        }
        private void pnl_Form_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            if (start)
            {
                Character.Drawplayer(g);
                for (int i = 0; i < 12; i++)
                {
                    Wall[i].drawObject(g);
                }
                //paints the sides of the walls for testing 
                /* for (int i = 0; i < 12; i++)
                 {
                     g.FillRectangle(Brushes.Red, UpS[i]);
                     g.FillRectangle(Brushes.Green, LeftS[i]);
                     g.FillRectangle(Brushes.Blue, RightS[i]);
                     g.FillRectangle(Brushes.Yellow, DownS[i]);
                 }*/
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
                foreach (Enemy O in GlobalVariables.enemies.ToList()) foreach (Projectile p in GlobalVariables.bullets.ToList()) //subracting hp from enemies as well as removing them once they have been defeated
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
        }
        public void enterRoom()
        {
            Tmr_Collision.Enabled = true;
            Tmr_Door.Enabled = true;
            Tmr_Movement.Enabled = true;
            Tmr_Proj.Enabled = true;
            lblData.Visible = true;
            lblEnemyHP.Visible = true;
            lblEnemyHP2.Visible = true;
            lblRems.Visible = true;
            start = true;
                
            Wall[0] = new Object(0, 0, 375, 50);//top left wall
            Wall[1] = new Object(425, 0, 325, 50);//top right wall
            Wall[2] = new Object(0, 0, 50, 225);//left top wall
            Wall[3] = new Object(0, 275, 50, 200);//left bottm wall
            Wall[4] = new Object(50, 400, 325, 50);//bottom left wall
            Wall[5] = new Object(425, 400, 325, 50);//bottom right wall
            Wall[6] = new Object(750, 0, 50, 225);//right top wall
            Wall[7] = new Object(750, 275, 50, 200);//right bottom wall
            Wall[8] = new Object(375,0,50,50);//top door
            Wall[9] = new Object(375,400,50,50);//bottom door
            Wall[10] = new Object(0,225,50,50);//left door
            Wall[11] = new Object(750,225,50,50);//right door
            spawnEnemy();
            for (int i = 0;i < 12; i++)
            {
                UpS[i] = new Rectangle(Wall[i].wallRec.Left + 5, Wall[i].wallRec.Top, Wall[i].wallRec.Width -5, 5);
                RightS[i] = new Rectangle(Wall[i].wallRec.Right, Wall[i].wallRec.Top + 5, 5, Wall[i].wallRec.Height - 10);
                LeftS[i] = new Rectangle(Wall[i].wallRec.Left, Wall[i].wallRec.Top + 10, 5, Wall[i].wallRec.Height - 10);
                DownS[i] = new Rectangle(Wall[i].wallRec.Left + 5, Wall[i].wallRec.Bottom, Wall[i].wallRec.Width -5, 5);
            }
        }
        private void spawnEnemy()
        {
            GlobalVariables.enemies.Add(new Enemy(200, 200, 40, 40));
            GlobalVariables.enemies.Add(new Enemy(250, 250, 40, 40));
            NumberOfEnemies += 2;
        }
    }
}
