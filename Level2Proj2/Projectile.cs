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
            // aligning the bullets within the characters 
            if (angle == 0)
            {
                width = 7;
                height = 16;
                x = characterRec.X + 17;
                y = characterRec.Y -16;
            }
            if (angle == 180)
            {
                width = 7;
                height = 16;
                x = characterRec.X + 17;
                y = characterRec.Y + 56;
            }
            if (angle == 90)
            {
                x = characterRec.X + 40; 
                y = characterRec.Y +20;
                width = 16;
                height = 7;
            }
            if (angle == 270)
            {
                x = characterRec.X; 
                y = characterRec.Y + 20;
                width = 16;
                height = 7;
            }
            //making the speed of the bullet based on it's angle 
            xSpeed = 10 * (Math.Cos((angle - 90) * Math.PI / 180));
            ySpeed = 10 * (Math.Sin((angle + 90) * Math.PI / 180));
        }


        public void Drawprojectile(Graphics g)
        {
            //drawing the projectiles onto the screen 
            projRec = new Rectangle(x, y , width, height);
            g.FillRectangle(Brushes.Black, projRec);
        }
        public void Shootprojectile(string shoot)
        {
            //applying the speed of the bullet once it is created 
            x += (int)xSpeed;
            y -= (int)ySpeed;
        }

    }
}

    

