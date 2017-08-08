using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombTest
{
    public class Seed
    {
        List<Pack> packs;
        List<Enemy> enemies;

        public Seed(List<Pack> packs, List<Enemy> enemies)
        {
            this.packs = packs;
            this.enemies = enemies;
        }

        public List<Pack> GetPacks()
        {
            return this.packs;
        }

        public List<Enemy> GetEnemies()
        {
            return this.enemies;
        }

        public void Reset()
        {
            foreach(var pack in packs)
            {
                pack.Reset();
            }
        }
    }
}
