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
        public Enemy()
        {
            x = 250;
            y = 250;
            width = 40;
            height = 40;
          /*  character = Properties.Resources.character;*/
        }
        //drawing the enemy from the form function
        public void Drawenemy(Graphics g)
        {
            enemyRec = new Rectangle(x, y, width, height);
            g.FillRectangle(Brushes.Blue, enemyRec);
        }
    }
}
