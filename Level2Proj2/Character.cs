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
                        GlobalVariables.roomChange = true;
                        x = 51;
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
                        GlobalVariables.roomChange = true;
                        x = pnlWidth - 91;
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
                        GlobalVariables.roomChange = true;
                        y = pnlHeight - 91;
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
                        GlobalVariables.roomChange = true;
                        y = 51;
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
        public void pCollision(string move, bool upcollide,bool downcollide,bool leftcollide,bool rightcollide)
        {
            if (leftcollide)
            {
                rspeed = 0;
            }
            else if (rightcollide)
            {
                lspeed = 0;
            }
            else if (upcollide)
            {
                dspeed = 0;
            }
            else if (downcollide)
            {
                uspeed = 0;
            }
            else if (move == "none")
            {
                dspeed = 5;
                rspeed = 5;
                lspeed = 5;
                uspeed = 5;
            }
        }
    }
}