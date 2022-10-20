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
        int angle, pnlWidth, pnlHeight, NumberOfEnemies;
        Player Character = new Player(); //making my player object
        Object[] Wall = new Object[12];//making the wall and door objects
        Rectangle[] UpS = new Rectangle[20];//making the top sides of the wall and enemies
        Rectangle[] DownS = new Rectangle[20];//making the down sides of the wall and enemies
        Rectangle[] RightS = new Rectangle[20];//making the right sides of the wall and enemies
        Rectangle[] LeftS = new Rectangle[20];//making the left sides of the wall and enemies
        Rectangle win = new Rectangle();//adding the golden trophy rectangle (the objective)
        Random pos = new Random();//adding a random to create random x and y values as well as a varying number of enemies
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnl_Form, new object[] { true }); // removing flickering from my panel
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e) //key being pressed
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
        private void Form1_KeyUp(object sender, KeyEventArgs e)//key not being pressed
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
        private void Form1_Load(object sender, EventArgs e) //when the form starts, setting variables and removing
        {
            start = false;
            lblData.Visible = false;
            lblEnemyHP.Visible = false;
            lblEnemyHP2.Visible = false;
            lblRems.Visible = false;
            GlobalVariables.roomChange = false;
            GlobalVariables.roomy = 3;
            GlobalVariables.roomx = 3;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                name = txtName.Text;
                btnStart.Visible = false;
                btnStart.Enabled = false;
                txtName.ReadOnly = true;
                txtName.Enabled = false;
                txtName.Visible = false;
                btnInstructions.Visible = false;
                btnInstructions.Enabled = false;
                pnl_Form.Focus();//removes annoying sound from the invisible buttons and removes their functionality
                enterRoom();//begins the game
           
            }
            else
            {
                MessageBox.Show("Please enter a name to begin"); //requiring the player to enter text before beginning
            }
           
        }
        private void btnInstructions_Click(object sender, EventArgs e) //showing the instructions to the player
        {
            MessageBox.Show("Your Goal is to search through the rooms of the Dungeon in order to find a Golden Tropy, use WASD to move and the Arrow Keys to Shoot");
        }

        private void txtName_KeyPress_1(object sender, KeyPressEventArgs e) //making sure the user can only enter text into the text box
        {    
          if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
          {
              e.Handled = true;
          }
         }

        private void tmr_Invincibilty_Tick(object sender, EventArgs e) //beginning a timer that gives the player 1 second of invcibility when hit
        {
            Character.characterDamage();
            tmr_Invincibilty.Enabled = false;
        }
        private void tmr_Collision_Tick(object sender, EventArgs e)
         {
            if (GlobalVariables.defeated == true) //if the player is defeated then end the game
            {
                start = false;
                lblData.Visible = false;
                lblEnemyHP.Visible = false;
                lblEnemyHP2.Visible = false;
                lblRems.Visible = false;
                tmr_Collision.Enabled = false;
                tmr_Door.Enabled = false;
                tmr_Movement.Enabled = false;
                tmr_Proj.Enabled = false;
                tmr_Invincibilty.Enabled = false;
            }
            move = "none";//sets collision to none (fixed bug where player couldn't move in the direction they have just collided with)
          Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide); //runs the collision function
          for (int i = 0; i < 12; i++)
          {
              if (Character.characterRec.IntersectsWith(RightS[i]))//if colliding to the left with a right wall
              {
                  rightcollide = true;
                  Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide);
              }
              else
              {
                  rightcollide = false;
              }
              if (Character.characterRec.IntersectsWith(LeftS[i]))//if colliding to the right with a left wall
                {
                  leftcollide = true;
                  Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide);
              }
              else
              {
                  leftcollide = false;
              }
              if (Character.characterRec.IntersectsWith(DownS[i]))//if colliding upwards with a bottom wall
              {
                  downcollide = true;
                  Character.pCollision(move, upcollide, downcollide, leftcollide, rightcollide);
              }
              else
              {
                  downcollide = false;
              }
              if (Character.characterRec.IntersectsWith(UpS[i]))//if colliding downwards with a bottom wall
              {
                  upcollide = true;
                  Character.pCollision(move,upcollide,downcollide,leftcollide,rightcollide);
              }
              else
              {
                  upcollide = false;
              }
          }
          //setting each value to false so you can move
          rightcollide = false
          upcollide = false;
          downcollide = false;
          leftcollide = false;
          move = "none";
          foreach (Enemy enemy in GlobalVariables.enemies)//function to damage the player
          {
                if (Character.characterRec.IntersectsWith(enemy.enemyRec))//if any enemy is colliding with the player
                    {
                        tmr_Invincibilty.Enabled = true;//begins invincibility timer
                    }
            foreach (Enemy enemy2 in GlobalVariables.enemies)//enemy collision with other enemies (works the same as player collision with walls so no bother commenting it)
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
        private void tmr_Movement_Tick(object sender, EventArgs e)//timer for player and enemy movement 
        {
            //lables used for testing values
           /* lblData.Text = GlobalVariables.roomx + "," + GlobalVariables.roomy + "";
            lblRems.Text = NumberOfEnemies + "";
            try
            {
                lblEnemyHP.Text = "" + GlobalVariables.enemies[0].enemyhp;
                lblEnemyHP2.Text = "" + GlobalVariables.enemies[1].enemyhp;
            }
            catch (Exception)
            {
            }*/
            pnlHeight = pnl_Form.Height;
            pnlWidth = pnl_Form.Width;
            //player movement function using strings 
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
            for (int i = 0; i < GlobalVariables.enemies.Count; i++)//enemy movement functions
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
            if (Character.characterRec.IntersectsWith(win))//if the player collides with the trophy
            {
                GlobalVariables.win = true;
            }
            if (GlobalVariables.win)// if the player wins then end the game 
            {
                start = false;
                lblData.Visible = false;
                lblEnemyHP.Visible = false;
                lblEnemyHP2.Visible = false;
                lblRems.Visible = false;
                tmr_Collision.Enabled = false;
                tmr_Door.Enabled = false;
                tmr_Movement.Enabled = false;
                tmr_Proj.Enabled = false;
                tmr_Invincibilty.Enabled = false;
                win = Rectangle.Empty;
                MessageBox.Show("You found the treasure!");
            }
            pnl_Form.Invalidate();
        }
        private void tmr_Proj_Tick(object sender, EventArgs e)
        {
            //logic for my projectiles shooting using strings and angles
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
        private void tmr_Door_Tick(object sender, EventArgs e)//opening the door once the enemies have been defeating timer
        {
            if (GlobalVariables.roomChange == true)//adding enemies once the player changes rooms
            {
                enterRoom();
                GlobalVariables.roomChange = false;
            }
            //if all the enemies have been defeated then make the doors disapear
            if (GlobalVariables.enemies.Count() <= 0)
            {
                //specifically keeping specific doors closed if they are at the edge of the map
                if (GlobalVariables.roomy != 5)
                {
                    Wall[8].wallRec = Rectangle.Empty;
                    UpS[8] = Rectangle.Empty;
                    RightS[8] = Rectangle.Empty;
                    LeftS[8] = Rectangle.Empty;
                    DownS[8] = Rectangle.Empty;
                }
                if (GlobalVariables.roomy != 0)
                {
                    Wall[9].wallRec = Rectangle.Empty;
                    UpS[9] = Rectangle.Empty;
                    RightS[9] = Rectangle.Empty;
                    LeftS[9] = Rectangle.Empty;
                    DownS[9] = Rectangle.Empty;
                }
                if (GlobalVariables.roomx != 0)
                {
                    Wall[10].wallRec = Rectangle.Empty;
                    UpS[10] = Rectangle.Empty;
                    RightS[10] = Rectangle.Empty;
                    LeftS[10] = Rectangle.Empty;
                    DownS[10] = Rectangle.Empty;
                }
                if (GlobalVariables.roomx != 5)
                {

                    Wall[11].wallRec = Rectangle.Empty;
                    UpS[11] = Rectangle.Empty;
                    RightS[11] = Rectangle.Empty;
                    LeftS[11] = Rectangle.Empty;
                    DownS[11] = Rectangle.Empty;
                }
            }
            if (GlobalVariables.enemies.Count() <= 0)//checking if all the enemies are dead in room 4,5 as this is the room the trophy is stored in
            {
                if (GlobalVariables.roomx == 4 && GlobalVariables.roomy == 5)
                {
                    win = new Rectangle(380, 210, 40, 40);//trophy rectangle called win(self explanatory)
                }
            }
        }
        private void pnl_Form_Paint(object sender, PaintEventArgs e)//painting the form
        {
            g = e.Graphics;
            if (start)//if the player has started the game
            {
                Character.Drawplayer(g);//player drawing function
                for (int i = 0; i < 12; i++)
                {
                    Wall[i].drawObject(g);//drawing the walls for each of the objects
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
                    O.Drawenemy(g);//drawing each enemy 
                }
                foreach (Projectile p in GlobalVariables.bullets)//drawing and then shooting the projectiles
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
            if (GlobalVariables.enemies.Count() <= 0)
            {
                if (GlobalVariables.roomx == 4 && GlobalVariables.roomy == 5)
                {
                    g.FillRectangle(Brushes.Gold, win);
                }
            }
        }
        public void enterRoom() //when the player enters a room
        {
            tmr_Collision.Enabled = true;
            tmr_Door.Enabled = true;
            tmr_Movement.Enabled = true;
            tmr_Proj.Enabled = true;
            //labels used for testing
       /*     lblData.Visible = true;
            lblEnemyHP.Visible = true;
            lblEnemyHP2.Visible = true;
            lblRems.Visible = true;*/
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
            for (int i = 0;i < 12; i++)
            {
                UpS[i] = new Rectangle(Wall[i].wallRec.Left + 5, Wall[i].wallRec.Top, Wall[i].wallRec.Width -5, 5);
                RightS[i] = new Rectangle(Wall[i].wallRec.Right, Wall[i].wallRec.Top + 5, 5, Wall[i].wallRec.Height - 10);
                LeftS[i] = new Rectangle(Wall[i].wallRec.Left, Wall[i].wallRec.Top + 10, 5, Wall[i].wallRec.Height - 10);
                DownS[i] = new Rectangle(Wall[i].wallRec.Left + 5, Wall[i].wallRec.Bottom, Wall[i].wallRec.Width -5, 5);
            }
            if (GlobalVariables.roomx == 3 && GlobalVariables.roomy == 3)
            {
            }
            else 
            {
                spawnEnemy();
            }
            
        }
        private void spawnEnemy()
        {
            for (int i = 0 ; i < pos.Next(1, 4); i++)
            {
                GlobalVariables.enemies.Add(new Enemy(pos.Next(60, 740), pos.Next(60, 350), 40, 40));
                NumberOfEnemies++; 
            }
          
        }
    }
}