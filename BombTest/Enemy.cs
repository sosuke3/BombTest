using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombTest
{
    public class Enemy
    {
        Pack pack;
        private int killCount;

        public Enemy(Pack pack, int killCount)
        {
            this.pack = pack;
            this.killCount = killCount;
        }

        public Pack GetPack()
        {
            return this.pack;
        }

        public int GetKilled()
        {
            return this.killCount;
        }
    }
}
