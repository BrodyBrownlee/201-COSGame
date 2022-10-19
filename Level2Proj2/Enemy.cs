using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2Proj2
{
    class Enemy
    {
        private int x, y, width, height;
        public int speed;
        public Rectangle enemyRec;
        public Rectangle enemyLeftRec;
        public Rectangle enemyRightRec;
        public Rectangle enemyTopRec;
        public Rectangle enemyBottomRec;
        public Image enemy;
        public string Name = "Enemy";
        public int roomx = 3, roomy = 3;
        public int enemyhp;
        public int lspeed, rspeed, uspeed, dspeed;
        public Enemy(int xpos, int ypos, int enemywidth, int enemyheight)
        {
            lspeed = 1;
            rspeed = 1;
            uspeed = 1;
            dspeed = 1;
            x = xpos;
            y = ypos;
            width = enemywidth;
            height = enemyheight;
            enemy = Properties.Resources.enemy;
            enemyhp = 3;
            enemyRec = new Rectangle(xpos, ypos, enemywidth, enemyheight);
            enemyLeftRec = new Rectangle(xpos, ypos, 5, enemyheight);
            enemyRightRec = new Rectangle(xpos + enemywidth, ypos, 5, enemyheight);
            enemyTopRec = new Rectangle(xpos, ypos, enemywidth, 5);
            enemyBottomRec = new Rectangle(xpos, ypos + enemyheight, enemywidth, 5);
        }
        //dealing with collison of enemies
        public void eCollision(string move, bool eup, bool edown, bool eleft, bool eright)
        {
        if (eleft)
        {
                 enemyRec.X -= 2;
                enemyLeftRec.X -= 2;
                enemyRightRec.X -= 2;
                enemyTopRec.X -= 2;
                enemyBottomRec.X -= 2;


            }
        else if (eright)
        {
                enemyRec.X += 2;
                enemyLeftRec.X += 2;
                enemyRightRec.X += 2;
                enemyTopRec.X += 2;
                enemyBottomRec.X += 2;

            }
        else if (eup)
        {
                enemyRec.Y -= 2;
                enemyLeftRec.Y -= 2;
                enemyRightRec.Y -= 2;
                enemyTopRec.Y -= 2;
                enemyBottomRec.Y -= 2;

            }
        else if (edown)
        {
                enemyRec.Y += 2;
                enemyLeftRec.Y += 2;
                enemyRightRec.Y += 2;
                enemyTopRec.Y += 2;
                enemyBottomRec.Y += 2;

            }
        }
        //drawing the enemy from the form function
        public void Drawenemy(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, enemyRec);
            //shows the enemy sides for testing
         /*    g.FillRectangle(Brushes.Red,enemyTopRec);
             g.FillRectangle(Brushes.Green, enemyLeftRec);
             g.FillRectangle(Brushes.Blue, enemyRightRec);
             g.FillRectangle(Brushes.Yellow, enemyBottomRec);*/
        }
    }
}