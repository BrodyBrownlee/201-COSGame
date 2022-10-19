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
        }
        //drawing the enemy from the form function
        public void Drawenemy(Graphics g)
        {
            g.DrawImage(enemy, enemyRec);
        }
        public void eMove(bool eleft, bool eright, bool eup, bool edown)
        {
                if (eleft)
                {
                    enemyRec.X += lspeed;
                }
                if (eright)
                {
                   enemyRec.X -= rspeed;
                }
                if (eup)
                {
                  enemyRec.Y += dspeed;
                }
                if (edown)
                {
                    enemyRec.Y -= uspeed;
                }
                enemyLeftRec = new Rectangle(enemyRec.Location.X, enemyRec.Location.Y, 5, enemyRec.Height);
        }
         public void eCollision(string move, bool eup, bool edown, bool eleft, bool eright)
        {
        if (eleft)
        {
               for (int i = 0; i < GlobalVariables.enemies.Count; i++)
                {
                    GlobalVariables.enemies[i].enemyRec.X -= 2;
                }
          
        }
        else if (eright)
        {
                for (int i = 0; i < GlobalVariables.enemies.Count; i++)
                {
                    GlobalVariables.enemies[i].enemyRec.X += 2;
                }
            }
        else if (eup)
        {
                for (int i = 0; i < GlobalVariables.enemies.Count; i++)
                {
                    GlobalVariables.enemies[i].enemyRec.Y += 2;
                }
            }
        else if (edown)
        {
                for (int i = 0; i < GlobalVariables.enemies.Count; i++)
                {
                    GlobalVariables.enemies[i].enemyRec.Y -= 2;
                }
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