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
        private int killedCount;

        public Enemy(Pack pack, int killed)
        {
            this.pack = pack;
            this.killedCount = killed;
        }

        public Pack GetPack()
        {
            return this.pack;
        }

        public int GetKilled()
        {
            return this.killedCount;
        }
    }
}
