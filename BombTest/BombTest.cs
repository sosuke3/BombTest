using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombTest
{
    public class BombTest
    {
        Random rand;
        int green_dagger = 3;
        int green_sword = 1;
        int blue_sword = 1;
        int rat = 4;
        int snake = 5;

        double seeds_to_run = 10000;
        double runs_per_seed = 10000;

        public BombTest(Random rand)
        {
            this.rand = rand;
        }

        List<byte> mt_shuffle(List<byte> array)
        {
            List<byte> ret = new List<byte>();

            while(array.Count > 0)
            {
                var pull_key = rand.Next(0, array.Count);
                ret.AddRange(array.Skip(pull_key).Take(1));
                array.RemoveAt(pull_key);
            }

            return ret;
            /*
function mt_shuffle(array $array) {
    $new_array = [];
    while(count($array)) {
        $pull_key = mt_rand(0, count($array) - 1);
        $new_array = array_merge($new_array, array_splice($array, $pull_key, 1));
    }
    return $new_array;
}
             */

        }

        bool isBomb(byte? id)
        {
            return (id == 0xDC || id == 0xDD || id == 0xDE);
        }

        Seed GenerateSeed()
        {
            // Pack shuffle
            byte[] prizes = new byte[] {
                    0xD8, 0xD8, 0xD8, 0xD8, 0xD9, 0xD8, 0xD8, 0xD9, // pack 1
                    0xDA, 0xD9, 0xDA, 0xDB, 0xDA, 0xD9, 0xDA, 0xDA, // pack 2
                    0xE0, 0xDF, 0xDF, 0xDA, 0xE0, 0xDF, 0xD8, 0xDF, // pack 3
                    0xDC, 0xDC, 0xDC, 0xDD, 0xDC, 0xDC, 0xDE, 0xDC, // pack 4
                    0xE1, 0xD8, 0xE1, 0xE2, 0xE1, 0xD8, 0xE1, 0xE2, // pack 5
                    0xDF, 0xD9, 0xD8, 0xE1, 0xDF, 0xDC, 0xD9, 0xD8, // pack 6
                    0xD8, 0xE3, 0xE0, 0xDB, 0xDE, 0xD8, 0xDB, 0xE2, // pack 7
                    0xD9, 0xDA, 0xDB, // from pull trees
                    0xD9, 0xDB, // from prize crab
                    0xD9, // stunned prize
                    0xDB, // saved fish prize
                };

            List<byte> shuffled = mt_shuffle(prizes.ToList());

            // None of these pops should actually be necessary, but we might as well.
            // account for trees
            shuffled.RemoveAt(shuffled.Count-1);
            shuffled.RemoveAt(shuffled.Count-1);
            shuffled.RemoveAt(shuffled.Count-1);
            // account for prize crab
            shuffled.RemoveAt(shuffled.Count-1);
            shuffled.RemoveAt(shuffled.Count-1);
            // account for stunned
            shuffled.RemoveAt(shuffled.Count-1);
            // account for saved fish
            shuffled.RemoveAt(shuffled.Count-1);

            List<Pack> packs = new List<Pack>();
            for(int i=0; i<=48; i+=8)
            {

                packs.Add(new Pack(this.rand, shuffled.Skip(i).Take(8).ToList()));
            }

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(new Enemy(packs[rand.Next(0, 7)], green_dagger));
            enemies.Add(new Enemy(packs[rand.Next(0, 7)], green_sword));
            enemies.Add(new Enemy(packs[rand.Next(0, 7)], blue_sword));
            enemies.Add(new Enemy(packs[rand.Next(0, 7)], rat));
            enemies.Add(new Enemy(packs[0], snake));

            return new Seed(packs, enemies);
        }

        public double CalculateAverage()
        {
            double overall_found_bombs = 0;
            double different_average = 0;

            Console.WriteLine("Start: {0}", DateTime.Now);

            for(int i=0; i < seeds_to_run; i++)
            {
                var seed = GenerateSeed();
                int numberOfBombsFound = 0;
                bool found_bomb = false;

                for(int j=0; j < runs_per_seed; j++)
                {
                    found_bomb = false;
                    seed.Reset();

                    for(int k=0; k<seed.GetEnemies().Count; k++)
                    {
                        var enemy = seed.GetEnemies()[k];

                        for(int l=0; l<enemy.GetKilled(); l++)
                        {
                            if(isBomb(enemy.GetPack().GetPrize()))
                            {
                                found_bomb = true;
                                break;
                            }
                        }
                        if(found_bomb)
                        {
                            break;
                        }
                    }
                    if(found_bomb)
                    {
                        numberOfBombsFound++;
                    }
                }

                overall_found_bombs += numberOfBombsFound;
                double p = (double)numberOfBombsFound / (double)runs_per_seed;
                double different = 2 * p * (1 - p); // for 2 players racing, the chances they get different results.
                different_average += different / (double)seeds_to_run;

                if (i % 100 == 0)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            Console.WriteLine("End: {0}", DateTime.Now);

            double average = overall_found_bombs / (seeds_to_run * runs_per_seed);

            Console.WriteLine("Average {0}", average);
            Console.WriteLine("Different Average {0}", different_average);

            return average;
        }
    }
}
