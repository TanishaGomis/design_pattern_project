using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    interface IFactory // interface which contains the diffenrent function that can create a box
    {
        void create_jail_box();
        void create_go_to_jail_box();
        void create_normal_box();
    }
}
