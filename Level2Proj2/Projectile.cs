using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace Level2Proj2
{
    class Projectile
    {
        public Rectangle projRec;
        int x, y, height, width;
        public Rectangle[] bulletl = new Rectangle[16];
        public Rectangle[] bulletr = new Rectangle[16];
        public Rectangle[] bulletu = new Rectangle[16];
        public Rectangle[] bulletd = new Rectangle[16];
        public Projectile()
        {
            x = 10;
            y = 360;


        }


        public void Drawprojectile(Graphics g);
       

        public void Shootprojectile(string shoot)
        {
            for (int i = 0; i <= 15; i++)
            {
                if (shoot == "right")
                {
                    bulletr[i] = new Rectangle(x + 5, y + 5, 5, 5);
                }
                if (shoot == "left")
                {
                    bulletl[i] = new Rectangle(x + 5, y + 5, 5, 5);
                }
                if (shoot == "up")
                {
                    bulletu[i] = new Rectangle(x + 5, y + 5, 5, 5);
                }
                if (shoot == "down")
                {
                    bulletd[i] = new Rectangle(x + 5, y + 5, 5, 5);
                }
            }
        }

    }
}

    

