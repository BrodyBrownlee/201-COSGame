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
        public double xSpeed, ySpeed;
        int x, y, height, width;
        string move, shoot;
        Point centerProj;
        public Projectile(Rectangle characterRec, int angle)
        {
            if (angle == 0)
            {
                width = 14;
                height = 32;
                x = characterRec.X + 18;
                y = characterRec.Y - 28;
            }
            if (angle == 180)
            {
                width = 14;
                height = 32;
                x = characterRec.X + 16;
                y = characterRec.Y + 28;
            }
            if (angle == 90)
            {
                x = characterRec.X + 38; // move bullet to middle of player
                y = characterRec.Y + 7;
                width = 32;
                height = 14;
            }
            if (angle == 270)
            {
                x = characterRec.X - 16; // move bullet to middle of player
                y = characterRec.Y + 7;
                width = 32;
                height = 14;
            }
            xSpeed = 30 * (Math.Cos((angle - 90) * Math.PI / 180));
            ySpeed = 30 * (Math.Sin((angle + 90) * Math.PI / 180));
        }


        public void Drawprojectile(Graphics g)
        {
            projRec = new Rectangle(x, y , width, height);
            g.FillRectangle(Brushes.Black, projRec);
        }
        public void Shootprojectile(string shoot)
        {
                if (shoot == "right")
                {
                 
                }
                if (shoot == "left")
                {
              
                }
                if (shoot == "up")
                {
                   
                }
                if (shoot == "down")
                {
                 
                }
            x += (int)xSpeed;
            y -= (int)ySpeed;
        }

    }
}

    

