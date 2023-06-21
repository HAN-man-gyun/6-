using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work14_23._06._21_
{
    public class Map
    {
        public string[,] map {get;set;}
        public int wallCount;
        public int wall_X;
        public int wall_Y;
        public string wall = "■";
        public string tile = "□";



        public void InitialMap()
        {
            for (int X = 0; X < map.GetLength(0); X++)
            {
                for (int Y = 0; Y < map.GetLength(1); Y++)
                {
                    map[X, Y] = tile;
                }
            }
        }
        public void CreateWall(int inputWall_X, int inputWall_Y)
        {
            wall_X = inputWall_X;
            wall_Y = inputWall_Y;
        }
     

    }
}
