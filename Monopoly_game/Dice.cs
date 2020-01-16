using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Dice : IEqual
    {
        public int value;

        public Dice (int val)
        {
            this.value = val;
        }

        public Dice()
        {
        }


        // Function which generates a random int between 1 and 6
        public void Throw(Random r)
        {
            this.value = r.Next(1, 7);
        }

        // Function which verify if we have a double
        public bool IsEqual(Dice d1)
        {
            if (d1.value == this.value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
