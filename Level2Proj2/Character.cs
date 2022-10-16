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
        public int lspeed,rspeed,uspeed,dspeed;
        public Rectangle characterRec;
        public Image character;
        public string Name = "Character";
        
        public Player()
        {
            x = 350;
            y = 200;
            width = 40;
            height = 40;
            lspeed = 5;
            rspeed = 5;
            uspeed = 5;
            dspeed = 5;
            character = Properties.Resources.character;
            characterRec = new Rectangle(x, y, width, height);
            GlobalVariables.roomy = 3;
            GlobalVariables.roomx = 3;
        }
        public void Drawplayer(Graphics g)
        {
            g.DrawImage(character, characterRec);
        }
        public void Movecharacter(string move, int pnlHeight, int pnlWidth)
        {
            characterRec.Location = new Point(x, y);
            if (x < pnlWidth - 40)
            {
                if (move == "right")
                { 
                    x += rspeed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (GlobalVariables.enemies.Count == 0)
                {
                    if (GlobalVariables.roomx <= 4)
                    {
                        x = 1;
                        GlobalVariables.roomx += 1;
                        foreach (Projectile p in GlobalVariables.bullets)
                        {
                            GlobalVariables.bullets.Remove(p);
                            break;
                        }
                    }
                }
            }
            if (x > 0)
            {
                if (move == "left")
                {
                    x -= lspeed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (GlobalVariables.enemies.Count == 0)
                {
                    if (GlobalVariables.roomx > 0)
                    {
                        x = pnlWidth - 41;
                        GlobalVariables.roomx -= 1;
                        foreach (Projectile p in GlobalVariables.bullets)
                        {
                            GlobalVariables.bullets.Remove(p);
                            break;
                        }
                    }
                }
            }
            if ( y > 0)
            {
                if (move == "up")
                {
                    y -= uspeed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (GlobalVariables.enemies.Count == 0)
                {
                    if (GlobalVariables.roomy <= 4)
                    {
                        y = pnlHeight - 41;
                        GlobalVariables.roomy += 1;
                        foreach (Projectile p in GlobalVariables.bullets)
                        {
                            GlobalVariables.bullets.Remove(p);
                            break;
                        }
                    }
                }
            }
            if (y < pnlHeight - 40)
            {
                if (move == "down")
                {
                    y += dspeed;
                    characterRec.Location = new Point(x, y);
                }
            }
            else
            {
                if (GlobalVariables.enemies.Count == 0)
                {
                    if (GlobalVariables.roomy > 0)
                    {
                        y = 1;
                        GlobalVariables.roomy -= 1;
                        foreach (Projectile p in GlobalVariables.bullets)
                        {
                            GlobalVariables.bullets.Remove(p);
                            break;
                        }
                    }
                }
            }
        }
        public void pCollision(string move)
        {
            if (move == "left" )
            {
                lspeed = 0;
                rspeed = 5;
                dspeed = 5;
                uspeed = 5;
            }
            else if (move == "right")
            {
                rspeed = 0;
                lspeed = 5;
                dspeed = 5;
                uspeed = 5;
            }
            else if (move == "up")
            {
                uspeed = 0;
                rspeed = 5;
                dspeed = 5;
                lspeed = 5;
            }
            else if (move == "down")
            {
                dspeed = 0;
                rspeed = 5;
                lspeed = 5;
                uspeed = 5;
            }
            else
            {
                dspeed = 5;
                rspeed = 5;
                lspeed = 5;
                uspeed = 5;
            }
        }
    }
}