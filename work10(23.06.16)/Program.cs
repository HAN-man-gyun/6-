using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work10_23._06._16_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BackGround game = new BackGround();
            game.InitialMap();
            
            while (true)
            {
                game.CreateOne();
                game.PrintMap();
                game.CheckOne();
                game.Move();
                game.UpdateMap();
                Console.Clear();
            }
           
        }
    }
}
