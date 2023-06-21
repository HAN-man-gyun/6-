using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace work14_23._06._21_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Map background = new Map();
            Player player = new Player();
            Enemy enemy = new Enemy();
            int movingScore = 0;
            ConsoleKeyInfo input;
            List <Enemy> enemyList = new List<Enemy>();
            //맵을 15,15로 만들기
            background.map = new string[15, 15];

            //맵을 초기화하기
            background.InitialMap();
            //만들 벽의 갯수 구하기
            Console.WriteLine("벽의 갯수를 입력해주세요");
            background.wallCount = int.Parse(Console.ReadLine());
            //벽좌표 랜덤으로만들기
            for(int i = 0; i < background.wallCount; i++)
            {
                background.CreateWall(rand.Next(14),rand.Next(14));
                background.map[background.wall_X, background.wall_Y] = background.wall;
            }
            //플레이어 초기화
            player.CreatePlayer(rand.Next(14), rand.Next(14));
            
            //적 초기화
            enemy.CreateEnemy(rand.Next(14), rand.Next(14));

            while (true)
            {
                //맵 출력
                
                background.map[player.pos_X, player.pos_Y] = player.player;
                for (int i = 0; i < enemyList.Count; i++)
                {
                    background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = enemy.enemy;
                }
                for(int i=0; i < 17; i++)
                {
                    Console.Write("{0}", background.wall);
                }
                Console.WriteLine();
                for (int i = 0; i < 15; i++)
                {
                    Console.Write("{0}",background.wall);
                    for (int j = 0; j < 15; j++)
                    {
                        Console.Write("{0}", background.map[i, j]);
                    }
                    Console.Write("{0}",background.wall);
                    Console.WriteLine();
                }
                for (int i = 0; i < 17; i++)
                {
                    Console.Write("{0}",background.wall);
                }
                Console.WriteLine();
                //무빙
                Console.WriteLine("무빙스코어 : {0}", movingScore);
                if (background.map[player.pos_X, player.pos_Y] == enemy.enemy)
                {
                    break;
                }
                Console.WriteLine("움직일 방향키를 입력해주세요");
                input = Console.ReadKey();
                Console.WriteLine("TestY");
                

                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (player.pos_Y > 0)
                        {
                            if(background.map[player.pos_X,player.pos_Y-1] ==background.wall)
                            {

                            }
                            else
                            {
                                background.map[player.pos_X, player.pos_Y] = background.tile;
                                player.pos_Y--;
                            }
                          
                        }   
                        break;
                    case ConsoleKey.RightArrow:
                        if (player.pos_Y < 14)
                        {
                            if (background.map[player.pos_X, player.pos_Y +1] == background.wall)
                            {

                            }
                            else
                            {
                                background.map[player.pos_X, player.pos_Y] = background.tile;
                                player.pos_Y++;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (player.pos_Y > 0)
                        {
                            if (background.map[player.pos_X-1, player.pos_Y] == background.wall)
                            {

                            }
                            else
                            {
                                background.map[player.pos_X, player.pos_Y] = background.tile;
                                player.pos_X--;
                            }
                            
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (player.pos_Y <14)
                        {
                            if (background.map[player.pos_X+1, player.pos_Y] == background.wall)
                            {

                            }
                            else
                            {
                                background.map[player.pos_X, player.pos_Y] = background.tile;
                                player.pos_X++;
                            }
                        }
                        break;
                }
                movingScore++;

                if(movingScore %7 == 0)
                {
                    Enemy enemy1 = new Enemy();
                    
                    enemy1.CreateEnemy(rand.Next(14),rand.Next(14));
                    enemyList.Add(enemy1);
                }

                //적의 무빙
                for(int i=0; i<enemyList.Count;i++)
                {
                    if (enemyList[i].pos_X >player.pos_X) // 적의 x좌표가  플레이어의 x좌표보다 적을때
                    {
                        if (background.map[enemyList[i].pos_X - 1,enemyList[i].pos_Y] == background.wall ) //적이 가려는 곳에 벽있는경우 못감
                        {
                            if (enemyList[i].pos_Y > player.pos_Y) //적의 y좌표가 플레이어의 Y 좌표보다 클때
                            {
                                if (background.map[enemyList[i].pos_X, enemyList[i].pos_Y-1] == background.wall)//적이 왼쪽으로 가려고할때 왼쪽에 벽이있는 경우 못감
                                {
                                }
                                else// 벽이없다면
                                {
                                    background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵의 적의 위치의 x좌표와 y좌표를 tile로 변경함.
                                    enemyList[i].pos_Y--;// 적의 y좌표를 1낮춤
                                }
                            }
                            else if (enemyList[i].pos_Y <player.pos_Y)//적의 Y좌표가 플레이어의 Y좌표보다 작을때
                            {
                                if (background.map[enemyList[i].pos_X, enemyList[i].pos_Y +1] == background.wall)//적이 오른쪽으로 가려고할때 오른쪽에 벽이있는 경우 못감
                                {
                                }
                                else// 벽이없다면
                                {
                                    background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵의 적의 위치의 x좌표와 y좌표를 tile로 변경함.
                                    enemyList[i].pos_Y++;// 적의 y좌표를 1높힘
                                }
                            }

                        }
                        else 
                        {
                            background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵의 적의 위치의 x 좌표와 ,y좌표을 tile로 변경함
                            enemyList[i].pos_X--;// 적의 x좌표를 1낮춤
                        }
                    }
                    else if (enemyList[i].pos_X < player.pos_X)// 적의 x좌표가 플레이어의 x좌표보다 클때
                    {
                        if (background.map[enemyList[i].pos_X + 1, enemyList[i].pos_Y] == background.wall)//적이 가려는 곳에 벽있는경우 못감
                        {
                            if (enemyList[i].pos_Y> player.pos_Y) //적의 y좌표가 플레이어의 y좌표보다 클때
                            {
                                if (background.map[enemyList[i].pos_X, enemyList[i].pos_Y-1] == background.wall) // 왼쪽으로 가려는 적의 앞에 벽있는경우 못감.
                                {

                                }
                                else
                                {
                                    background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵의 적의 위치의 x 좌표와 ,y좌표을 tile로 변경함
                                    enemyList[i].pos_Y--;// 적의 y좌표를 1낮춤
                                }
                            }
                            else if (enemyList[i].pos_Y<player.pos_Y) //적의 y좌표가 플레이어의 y좌표보다 작을때
                            {
                                if (background.map[enemyList[i].pos_X, enemyList[i].pos_Y + 1] == background.wall) // 오른쪽으로 가려는 적의 앞에 벽있는경우 못감.
                                {

                                }
                                else
                                {
                                    background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵의 적의 위치의 x 좌표와 ,y좌표을 tile로 변경함
                                    enemyList[i].pos_Y++;// 적의 y좌표를 1낮춤
                                }
                            }
                            
                        }
                        else
                        {
                            background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵안의 적위치x좌표와 y좌표를 tile로 변경함.
                            enemyList[i].pos_X++;//적의 x좌표를 1높힘
                        }
                     
                    }
                    else //적의 x좌표와 플레이어의 x좌표가 같을때
                    {
                        if (enemyList[i].pos_Y > player.pos_Y) //적의 y좌표가 플레이어의 y좌표보다 클때
                        {
                            if (background.map[enemyList[i].pos_X, enemyList[i].pos_Y - 1] == background.wall) // 왼쪽으로 가려는 적의 앞에 벽있는경우 못감.
                            {

                            }
                            else
                            {
                                background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵안의 적위치x좌표와 y좌표를 tile로 변경함.
                                enemyList[i].pos_Y--;//적의 Y좌표를 1낮춤
                            }
                            
                        }
                        else if (enemyList[i].pos_Y < player.pos_Y) //적의 y좌표가 플레이어의 y좌표보다 작을때
                        {
                            if(background.map[enemyList[i].pos_X, enemyList[i].pos_Y + 1] == background.wall) //오른쪽으로 가려는 적의 앞에 벽있는경우 못감
                            {

                            }
                            else
                            {
                                background.map[enemyList[i].pos_X, enemyList[i].pos_Y] = background.tile; //맵안의 적위치x좌표와 y좌표를 tile로 변경함.
                                enemyList[i].pos_Y++;//적의 Y좌표를 1높힘
                            }
                        }
                    }
                }
                Console.Clear();
            }
            Console.WriteLine("게임오버!!!!1");
        }
    }
}
