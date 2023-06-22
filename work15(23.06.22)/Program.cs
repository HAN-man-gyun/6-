using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace work15_23._06._22_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;  // 깜빡이지 않게 만드는 것.

            Random rnd = new Random(); //반복객체생성
            Player player = new Player(); // 플레이어 객체생성
            Map background = new Map(); // 맵객체 생성
            Npc npc = new Npc(); // NPC객체 생성
            Monster monster = new Monster(); //Monster 객체 생성
            GameManager manager = new GameManager(); //manager 객체 생성
            background.map = new string[20, 20]; // map 배열 초기화
            ConsoleKeyInfo input; // consoleKeyInfo input초기화
            int rndNum; // 랜덤한값을 저장할 변수 rndNum
            manager.battleOn = false; // 배틀진행여부 변수
            manager.huntCount = 0; // 몬스터사냥 횟수 변수
            manager.QuestSuccessCheck = false; // 퀘스트 성공 여부 변수
            //맵초기화
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    background.map[i, j] = background.tile;
                }
            }
            for(int i = 0; i< 20; i++)
            {
                for(int j = 20;j < 20; j++)
                {
                    background.map[i,j] = "　";
                }
            }
            //플레이어 초기화
            player.hp = 150;
            player.atk = 30;
            //몬스터 초기화
            monster.hp = 80;
            monster.atk = 30;

            while (true) // 무한히 반복
            {
                //풀숲초기화
                for (int i = background.start_xPos; i < background.start_yPos + 7; i++)
                {
                    for (int j = background.start_yPos; j < background.start_yPos + 7; j++)
                    {
                        
                        background.map[i, j] = background.forest;
                    }
                }
                //플레이어 초기화
                background.map[player.xPos, player.yPos] = player.pattern;

                //npc초기화
                for (int i = npc.xPos; i < npc.xPos + 2; i++)
                {
                    for (int j = npc.yPos; j < npc.yPos + 2; j++)
                    {
                        background.map[i, j] = npc.pattern;
                    }
                }
                //맵출력
                Console.SetCursorPosition(0, 0); // SetCursorPosition을 사용해서 0,0부터 출력하게만듬
                for(int i=0; i< 22; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("{0}", "▤");
                    Console.ResetColor();
                }
                Console.WriteLine();
                for (int i = 0; i < 20; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("{0}", "▥");
                    Console.ResetColor();
                    for (int j = 0; j < 20; j++)
                    {
                        if (background.map[i, j] == background.forest)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0}", background.map[i, j]);
                            Console.ResetColor();
                        }
                        else if(background.map[i, j] == npc.pattern)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("{0}", background.map[i, j]);
                            Console.ResetColor();
                        }
                        else if (background.map[i,j] == player.pattern)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("{0}", background.map[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("{0}", background.map[i, j]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("{0}", "▥");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                for (int i = 0; i < 22; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("{0}", "▤");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("현재 용사의 좌표 : {0} {1}",player.xPos,player.yPos);  //현재 플레이어의 좌표 출력

                Console.WriteLine("현재 헌트카운트 {0}", manager.huntCount); // 현재 몬스터사냥카운트 출력
                //무빙
                Console.WriteLine("움직일 방향키를 입력해주세요"); 
                input = Console.ReadKey(); // 방향키 입력


                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow: // 왼쪽일경우
                        if (player.yPos > 0) // y좌표가 0보다 클경우(왼쪽끝을 벗어나지 않기위한 조건문)
                        {
                            if (background.map[player.xPos,player.yPos-1] == background.forest) //  가려는 왼쪽 맵이 숲타일일경우
                            {
                                rndNum = rnd.Next(1, 101);// 1~100까지 랜덤한 수를뽑고                  
                                Console.WriteLine("{0}", rndNum); // 출력
                                if (rndNum >= 1 && rndNum <= 36) // 36퍼센트의 확률안에있다면
                                {
                                    manager.battleOn = true; // 배틀진행을 시키기위해 on
                                    manager.huntCount++; // 사냥 카운트 ++
                                    if (background.map[player.xPos, player.yPos] == background.forest) // 현재 플레이어 위치가 숲인경우
                                    {
                                        background.map[player.xPos, player.yPos] = background.forest; // 맵이 바뀌지 않기위해 숲으로 해놓음
                                    }
                                    else // 현재 플레이어 위치가 숲이 아닌경우 즉 타일인 경우
                                    {
                                        background.map[player.xPos, player.yPos] = background.tile; //  맵이 바뀌지 않기위해 타일로 해놓음
                                        player.yPos--;// 플레이어 위치를 움직임
                                    }
                                }
                                else // 전투를 하지 않게된경우 
                                {
                                    background.map[player.xPos, player.yPos] = background.tile; //현재 플레이어의 위치를 타일로 만들고
                                    player.yPos--; //플레이어의 위치를 움직임
                                }
                            }
                            else if(background.map[player.xPos, player.yPos - 1] == npc.pattern) // 가려는 왼쪽맵이 npc인경우 
                            {
                                background.map[player.xPos, player.yPos] = background.tile; // 현재있던곳을 tile로 만들고
                                player.yPos--;// 위치를 옮김
                            }
                            else // 가려는 맵이 타일인 경우
                            {
                                background.map[player.xPos, player.yPos] = background.tile; //현재위치를 tile로 만들고
                                player.yPos--; //위치를 옮김
                            }
                           
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if (player.yPos < 19)
                        {
                            if (background.map[player.xPos, player.yPos + 1] == background.forest)
                            {
                                rndNum = rnd.Next(1, 101);
                                Console.WriteLine("{0}", rndNum);
                                if (rndNum >= 1 && rndNum <= 36)
                                {                                 
                                    manager.battleOn = true;
                                    manager.huntCount++;
                                    if (background.map[player.xPos, player.yPos] == background.forest)
                                    {
                                        background.map[player.xPos, player.yPos] = background.forest;
                                    }
                                    else
                                    {
                                        background.map[player.xPos, player.yPos] = background.tile;
                                        player.yPos++;
                                    }
                                }
                                else
                                {
                                    background.map[player.xPos, player.yPos] = background.tile;
                                    player.yPos++;
                                }

                            }
                            else if (background.map[player.xPos, player.yPos + 1] == npc.pattern)
                            {
                                background.map[player.xPos, player.yPos] = background.tile;
                                player.yPos++;
                            }
                            else
                            {
                                background.map[player.xPos, player.yPos] = background.tile;
                                player.yPos++;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (player.xPos > 0)
                        {
                            if (background.map[player.xPos-1, player.yPos] == background.forest)
                            {
                                rndNum = rnd.Next(1, 101);
                                Console.WriteLine("{0}", rndNum);
                                if (rndNum >= 1 && rndNum <= 36)
                                { 
                                    manager.battleOn = true;
                                    manager.huntCount++;
                                    if (background.map[player.xPos,player.yPos] ==background.forest)
                                    {
                                        background.map[player.xPos, player.yPos] = background.forest;
                                    }
                                    else
                                    {
                                        background.map[player.xPos, player.yPos] = background.tile;
                                        player.xPos--;
                                    }
                                    

                                }
                                else
                                {
                                    background.map[player.xPos, player.yPos] = background.tile;
                                    player.xPos--;
                                }
                            }
                            else if(background.map[player.xPos-1, player.yPos] == npc.pattern)
                            {
                                background.map[player.xPos, player.yPos] = background.tile;
                                player.xPos--;
                            }
                            else
                            {
                                background.map[player.xPos, player.yPos] = background.tile;
                                player.xPos--;
                            }
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (player.xPos < 19)
                        {
                            if (background.map[player.xPos, player.yPos + 1] == background.forest)
                            {
                                rndNum = rnd.Next(1, 101);
                                Console.WriteLine("{0}", rndNum);
                                if (rndNum >= 1 && rndNum <= 36)
                                {
                                    manager.battleOn = true;
                                    manager.huntCount++;
                                    if (background.map[player.xPos, player.yPos] == background.forest)
                                    {
                                        background.map[player.xPos, player.yPos] = background.forest;
                                    }
                                    else
                                    {
                                        background.map[player.xPos, player.yPos] = background.tile;
                                        player.xPos++;
                                    }
                                    
                                }
                                else
                                {
                                    background.map[player.xPos, player.yPos] = background.tile;
                                    player.xPos++;
                                }
                            }
                            else if(background.map[player.xPos + 1, player.yPos] == npc.pattern)
                            {
                                background.map[player.xPos, player.yPos] = background.tile;
                                player.xPos++;
                            }
                            else
                            {
                                background.map[player.xPos, player.yPos] = background.tile;
                                player.xPos++;
                            }
                        }
                        break;
                }
                if (manager.battleOn) //만약  battleON 이 true여서 전투가 벌어져야한다면
                {
                    manager.Battle(ref player, ref monster, ref background); // 전투실행과
                    manager.battleOn = false; //battleOn을 다시 false로 만듬
                }
                if(manager.huntCount >3)  //만약 사냥 카운트가 3이상이라면
                {
                    manager.QuestSuccessCheck = true;//퀘스트 성공여부 변수는 true가됨
                }
                if (background.map[player.xPos,player.yPos] == npc.pattern) // 플레이어 위치가 npc에 있다면
                {
                    manager.Quest(); // quest가 실행됨
                }

                Console.Clear();
            }
        }
    }
}
