using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work14_23._06._21_
{
    public class Enemy
    {

        public int pos_X { get;  set; }
        public int pos_Y { get;  set; }
        public string enemy = "＃";
        public void CreateEnemy( int intput_X, int input_Y)
        {
            pos_X = intput_X;
            pos_Y = input_Y;
        }
    }
}
