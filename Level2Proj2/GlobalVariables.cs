using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2Proj2
{
    internal class GlobalVariables
    {
        private static List<Projectile> v_bullets = new List<Projectile>();
        private static List<Enemy> v_enemies = new List<Enemy>();
        private static int v_roomx, v_roomy;
        private static bool v_roomChange;
        private static bool v_defeated;
        private static bool v_win;


        public static List<Projectile> bullets
        {
            get { return v_bullets; }
            set { v_bullets = value; }
        }
        public static List<Enemy> enemies
        {
            get { return v_enemies; }
            set { v_enemies = value; }
        }
        public static int roomx
        {
            get { return v_roomx; }
            set { v_roomx = value; }
        }
        public static int roomy
        {
            get { return v_roomy;}
            set { v_roomy = value;}
        }
        public static bool roomChange
        {
            get { return v_roomChange; }
            set { v_roomChange = value;}
        }
        public static bool defeated
        {
            get { return v_defeated; }
            set { v_defeated = value;}
        }
        public static bool win
        {
            get { return v_win; }
            set { v_win = value; }
        }
    }
}