using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombTest
{
    public class Pack
    {
        private int currentPrize = 0;
        List<byte> Prizes { get; set; }
        Random rand;

        public Pack(Random rand, List<byte> prizes)
        {
            this.rand = rand;
            Prizes = prizes;
        }

        public byte? GetPrize()
        {
            if(rand.Next(0, 2) == 1)
            {
                var ret = Prizes[currentPrize];

                if(currentPrize >= 7)
                {
                    currentPrize = 0;
                }
                else
                {
                    currentPrize++;
                }

                return ret;
            }

            return null;
        }

        public void Reset()
        {
            currentPrize = 0;
        }

        public int GetCurrentPrize()
        {
            return currentPrize;
        }

        public void Print()
        {
            // print implode(",", prizes);
            // print "\n";
        }
    }
}
