using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    interface IEqual //interface used for to know if the player did a double or not 
    {
        bool IsEqual(Dice d1);
    }
}
