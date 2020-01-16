using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Singleton_Board  // we define the board as a singleton to be sure that only one board is create during the game, and that all the players play on the same board
    {
        public List<Box> board = new List<Box>();
        private static Singleton_Board instance;

        // BUILDER
        public Singleton_Board()
        { }
        
        // Singleton BUILDER
        public static Singleton_Board getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton_Board();
            }
            return instance;
        }


        // Function which return the box of a int enter in parameter, according to the fact that the board is composed of only 40 boxes
        public Box get_box(int numcase)
        {
            if(numcase <= 39)
            {
                return board[numcase];
            }
            else
            {
                return board[numcase-40];
            }
        }



        // Function which add a box to the board
        public void add_box (Box newbox)
        {
            if(newbox.bnum==10)
            {
                newbox.create_jail_box();
            }
            else if (newbox.bnum == 30)
            {
                newbox.create_go_to_jail_box();
            }
            else
            {
                newbox.create_normal_box();
            }
            this.board.Add(newbox);
        }
    }
}
