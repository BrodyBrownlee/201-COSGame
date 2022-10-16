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
        public Enemy(int xpos, int ypos, int enemywidth, int enemyheight)
        {
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
    }
}