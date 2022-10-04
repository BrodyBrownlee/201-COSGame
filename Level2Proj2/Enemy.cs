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
        public Rectangle[] enemyarray;
        public Image enemy;
        public string Name = "Character";
        public int roomx = 3, roomy = 3;
        public Enemy()
        {
            x = 250;
            y = 250;
            width = 40;
            height = 40;
            speed = 5;
          /*  character = Properties.Resources.character;*/
          for (int O = 1; O < 16; O++)
            {
                enemyarray[1] = new Rectangle(x, y, width, height);
                x += 40;
            }
        }
        public void Drawenemy(Graphics g)
        {
            for (int O = 1; O < 16; O++)
            {
                g.FillRectangle(Brushes.Blue, enemyarray[O]);
            }    
        }
    }
}
