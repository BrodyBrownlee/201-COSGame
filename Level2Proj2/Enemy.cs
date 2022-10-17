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
        public Image enemy;
        public string Name = "Enemy";
        public int roomx = 3, roomy = 3;
        public int enemyhp;
        public int lspeed, rspeed, uspeed, dspeed;
        public Enemy(int xpos, int ypos, int enemywidth, int enemyheight)
        {
            lspeed = 2;
            rspeed = 2;
            uspeed = 2;
            dspeed = 2;
            x = xpos;
            y = ypos;
            width = enemywidth;
            height = enemyheight;
            enemy = Properties.Resources.enemy;
            enemyhp = 3;
            enemyRec = new Rectangle(xpos, ypos, enemywidth, enemyheight);
        }
        //drawing the enemy from the form function
        public void Drawenemy(Graphics g)
        {

            g.DrawImage(enemy, enemyRec);
        }
        public void eMove(bool eleft, bool eright, bool eup, bool edown)
        {
            foreach (Enemy O in GlobalVariables.enemies)
            {
                for (int i = 0; i < GlobalVariables.enemies.Count; i++)
                {
                    if (eleft)
                    {
                        GlobalVariables.enemies[i].enemyRec.X += lspeed;
                    }
                    if (eright)
                    {
                        GlobalVariables.enemies[i].enemyRec.X -= rspeed;
                    }
                    if (eup)
                    {
                        GlobalVariables.enemies[i].enemyRec.Y += dspeed;
                    }
                    if (edown)
                    {
                        GlobalVariables.enemies[i].enemyRec.Y -= uspeed;
                    }
                }
              

            }
          
        }
         public void eCollision(string move, bool upcollide, bool downcollide, bool leftcollide, bool rightcollide)
        {
        if (leftcollide)
        {
            rspeed = 0;
        }
        else if (rightcollide)
        {
            lspeed = 0;
        }
        else if (upcollide)
        {
            dspeed = 0;
        }
        else if (downcollide)
        {
            uspeed = 0;
        }
        else if (move == "none")
        {
            dspeed = 5;
            rspeed = 5;
            lspeed = 5;
            uspeed = 5;
        }
    }
}

}