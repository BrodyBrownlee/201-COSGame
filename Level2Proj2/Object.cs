using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2Proj2
{
    class Object
    {
        int x,y,width,height;
        public Rectangle wallRec;
        public Object(int xpos, int ypos, int wallwidth, int wallheight)
        {
            x = xpos;
            y = ypos;
            width = wallwidth;
            height = wallheight;
            wallRec = new Rectangle(xpos,ypos,wallwidth,wallheight);
        }
        public void drawObject(Graphics g)
        {
            g.FillRectangle(Brushes.Black,wallRec);
        }
    }
}
