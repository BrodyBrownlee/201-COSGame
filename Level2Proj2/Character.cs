using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace Level2Proj2
{

  


    class Player
    {
        private int x, y, width, height;
        public int speed;
        public Rectangle characterRec;
        public Image character;
        public string Name = "Character";
        public Player()
        {
            x = 10;
            y = 360;
            width = 40;
            height = 40;
            speed = 5;
            character = Properties.Resources.character;
            characterRec = new Rectangle(x, y, width, height);
            
        }
        public void Drawplayer(Graphics g)
        {
            g.DrawImage(character, characterRec);
        }

        public void Movecharacter(string move)
        {
            characterRec.Location = new Point(x, y);

            if (move == "right")
            {
                x += speed;
                characterRec.Location = new Point(x, y);
            }
            if (move == "left")
            {
                x -= speed;
                characterRec.Location = new Point(x, y);
            }
            if (move == "up")
            {
                y -= speed;
                characterRec.Location = new Point(x, y);
            }
            if (move == "down")
            {
                y += speed;
                characterRec.Location = new Point(x, y);
            }


        }

    }
}

  
