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

        public Rectangle character;
        public string Name = "Character";
        public Player()
        {
            x = 10;
            y = 360;
            width = 40;
            height = 40;
            character = new Rectangle(x, y, width, height);
        }
        public void Drawplayer(Graphics g)
        {
            g.FillRectangle(Brushes.Red, character);
        }

        public void Movecharacter(string move)
        {
            character.Location = new Point(x, y);

            if (move == "right")
            {
                x += 5;
                character.Location = new Point(x, y);
            }
            if (move == "left")
            {
                x -= 5;
                character.Location = new Point(x, y);
            }
            if (move == "up")
            {
                y -= 5;
                character.Location = new Point(x, y);
            }
            if (move == "down")
            {
                y += 5;
                character.Location = new Point(x, y);
            }


        }

    }
}

  
