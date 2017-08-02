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

        public void PrintPacks()
        {
            /*
    public function print_packs() {
        $packs_used = [];
        for ($j = 0; $j < count($this->enemies); $j++) {
            for ($k = 0; $k < count($this->packs); $k++) {
                if ($this->enemies[$j]->get_pack() === $this->packs[$k]) {
                    array_push($packs_used, $k);
                    break;
                }
            }
        }
        print implode(",", $packs_used);
        print "\n";
        for ($i = 0; $i < count($this->packs); $i++) {
            $this->packs[$i]->print();
        }
        print "\n";
    }
             */

        }
    }
}
