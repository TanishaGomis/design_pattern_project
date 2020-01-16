using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Box : IFactory
    {
        public int bnum;
        public bool jail_box;
        public bool go_to_jail_box;

        // BUILDER
        public Box(int num)
        {
            this.bnum = num;
        }

        //The next three functions allows to define each box

        public void create_jail_box()
        {
            this.jail_box = true;
            this.go_to_jail_box = false;
        }

        public void create_go_to_jail_box()
        {
            this.jail_box = false;
            this.go_to_jail_box = true;
        }

        public void create_normal_box()
        {
            this.jail_box = false;
            this.go_to_jail_box = false;
        }
    }
}
