using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work15_23._06._22_
{
    internal class Map
    {
        public string[,] map; // 맵 변수

        public string tile = "□"; // 타일 변수
        public string forest = "▨"; //숲 변수
        public int start_xPos =3; // 숲이 시작할 x좌표
        public int start_yPos =12; //  숲이 시작할 y좌표
    }
}
