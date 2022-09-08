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
        public Projectile(Rectangle characterRec)
        {
            width = 5;
            height = 5;
            projRec = new Rectangle(x, y, width, height);
            x = characterRec.X + characterRec.Width / 2;
            y = characterRec.Y + characterRec.Height / 2;
        }


        public void Drawprojectile(Graphics g)
        {
           
        }
       public void Moveprojectile(string move, int speed)
        {
            if (move == "right")
            {
                x += speed;
               /* bulletr.Location = new Point(x, y);*/
            }
            if (move == "left")
            {
                x -= speed;
               /* character.Location = new Point(x, y);*/
            }
            if (move == "up")
            {
                y -= speed;
              /*  character.Location = new Point(x, y);*/
            }
            if (move == "down")
            {
                y += speed;
                /*character.Location = new Point(x, y);*/
            }
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
        }

    }
}

    

