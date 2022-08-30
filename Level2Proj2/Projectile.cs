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
        string move, shoot;
        public Rectangle[] bulletl = new Rectangle[16];
        public Rectangle[] bulletr = new Rectangle[16];
        public Rectangle[] bulletu = new Rectangle[16];
        public Rectangle[] bulletd = new Rectangle[16];
        public Projectile()
        {
            x = 10;
            y = 360;
            width = 5;
            height = 5;

        }


        public void Drawprojectile(Graphics g)
        {
            for (int i = 0; i <= 15; i++)
            {

                g.FillRectangle(Brushes.Black, bulletd[i]);
                g.FillRectangle(Brushes.Black, bulletl[i]);
                g.FillRectangle(Brushes.Black, bulletr[i]);
                g.FillRectangle(Brushes.Black, bulletu[i]);

            }
        }
       public void Moveprojectile(string move)
        {
            if (move == "right")
            {
                x += 5;
               /* bulletr.Location = new Point(x, y);*/
            }
            if (move == "left")
            {
                x -= 5;
               /* character.Location = new Point(x, y);*/
            }
            if (move == "up")
            {
                y -= 5;
              /*  character.Location = new Point(x, y);*/
            }
            if (move == "down")
            {
                y += 5;
                /*character.Location = new Point(x, y);*/
            }
        }

        public void Shootprojectile(string shoot)
        {
            for (int i = 0; i <= 15; i++)
            {
                if (shoot == "right")
                {
                    bulletr[i] = new Rectangle(x + 5, y + 5,height, width);
                    i++;
                }
                if (shoot == "left")
                {
                    bulletl[i] = new Rectangle(x + 5, y + 5,height, width);
                    i++;
                }
                if (shoot == "up")
                {
                    bulletu[i] = new Rectangle(x + 5, y + 5,height, width);
                    i++;
                }
                if (shoot == "down")
                {
                    bulletd[i] = new Rectangle(x + 5, y + 5, height, width);
                    i++;
                }

            }
        }

    }
}

    

