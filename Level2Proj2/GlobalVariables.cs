using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level2Proj2
{
    internal class GlobalVariables
    {
        private static List<Projectile> v_bullets = new List<Projectile>();
        private static List<Enemy> v_enemies = new List<Enemy>();
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
    }
}
