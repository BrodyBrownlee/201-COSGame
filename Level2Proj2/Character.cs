﻿using System;
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
        public int roomx = 3, roomy = 3;
        public Player()
        {
            x = 250;
            y = 250;
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

        public void Movecharacter(string move, int pnlHeight, int pnlWidth)
        {
            characterRec.Location = new Point(x, y);
            if ( x < pnlWidth - 40)
            {
                if (move == "right")
                {
                    x += speed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (roomx <= 4)
                {
                    x = 1;
                    roomx += 1;
                    foreach (Projectile p in GlobalVariables.bullets)
                    {
                        GlobalVariables.bullets.Remove(p);
                        break;
                    }
                }
            }

            if (x > 0)
            {
                if (move == "left")
                {
                    x -= speed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (roomx > 0)
                {
                    x = pnlWidth - 41;
                    roomx -= 1;
                    foreach (Projectile p in GlobalVariables.bullets)
                    {
                        GlobalVariables.bullets.Remove(p);
                        break;
                    }
                }
            }
            if ( y > 0)
            {
                if (move == "up")
                {
                    y -= speed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (roomy <= 4)
                {
                    y = pnlHeight - 41;
                    roomy += 1;
                    foreach (Projectile p in GlobalVariables.bullets)
                    {
                        GlobalVariables.bullets.Remove(p);
                        break;
                    }
                }
                
            }
            if (y < pnlHeight - 40)
            {
                if (move == "down")
                {
                    y += speed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (roomy > 0)
                {
                    y = 1;
                    roomy -= 1;
                    foreach (Projectile p in GlobalVariables.bullets)
                    {
                        GlobalVariables.bullets.Remove(p);
                        break;
                    }
                }
            }

        }

    }
}

  
