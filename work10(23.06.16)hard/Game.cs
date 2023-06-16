using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work10_23._06._16_hard
{
    public class Game
    {
        string[,] map = new string[15, 15];
        int One1x, One1y, One2x, One2y, One3x, One3y;
        Random rand = new Random();
        //
        bool[] checkList1 = new bool[15]; //가로의 1존재유무를 파악하는 배열 
        int[] checkCountList1 = new int[15]; //가로에 존재하는 1의 갯수를 파악하는배열
        bool[] checkList2 = new bool[15]; //세로의 1존재유무를 파악하는 배열
        int[] checkCountList2 = new int[15]; //세로에 존재하는 1의 갯수를 파악하는배열

        ConsoleKeyInfo inputKey;


        public void InitialMap()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    map[i, j] = "*";
                }
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Console.Write($"{map[i, j],3}");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void CreateOne()
        {
            while (true)
            {
                One1x = rand.Next(0, 14);
                One1y = rand.Next(0, 14);
                One2x = rand.Next(0, 14);
                One2y = rand.Next(0, 14);
                One3x = rand.Next(0, 14);
                One3y = rand.Next(0, 14);

                map[One1x, One1y] = "1";
                map[One2x, One2y] = "1";
                map[One3x, One3y] = "1";

                if ((map[One1x, One1y] == map[One2x, One2y]) && (map[One2x, One2y] == map[One3x, One3y]))
                {
                    break;
                }
            }
        }


        public void CheckOne()  //
        {
            for (int i = 0; i < 14; i++) //세로 축
            {
                for (int j = 0; j < 14; j++) //가로 축
                {
                    if (map[i, j] == "1")  // 모든 배열을 보면서 "1" 이 있다면
                    {
                        checkList1[i] = true;// 그 "1" 이 있는 세로축을 체크하는 checkList 을 true로 바꿈.
                        checkCountList1[i] += 1; // 1이 몇개있는지 세로축 체크하는 checkCountList를 ++함
                        checkList2[j] = true;// 그 "1" 이 있는 가로축을 체크하는 checkList 을 true로 바꿈.
                        checkCountList2[j] += 1;// 1이 몇개있는지 가로축 체크하는 checkCountList를 ++함
                    }
                }
            }
        }
        public void Move()
        {
            Console.WriteLine("Press the Key"); // 키를 입력받고
            inputKey = Console.ReadKey();
            if (inputKey.KeyChar == 'd')// d를 입력받았을때 
            {
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++) //map을 하나하나 찾으면서
                    {
                        while (checkList1[i] == true) // 세로축의 1등장여부를 확인하는 checklist가 참일때
                        {
                            if (map[i, 14] == "*") // 맨끝칸이 빈칸이라면
                            {
                                if (checkCountList1[i] == 0) //체크카운트 리스트가  0이라면, 즉 더이상 이 줄에는 1이 남아있지 않을때는.
                                {
                                    checkList1[i] = false; // checkList를 거짓으로만들고
                                    Console.WriteLine("test1");
                                    break; // 탈출
                                }
                                else // 체크카운트 리스트가 0이 아니여서 아직 이줄에 1이 남아있을때는
                                {
                                    map[i, 14] = "1"; // 맨끝칸에 1을 추가하고
                                    checkCountList1[i] -= 1; // checkListCount를 1줄임 
                                    Console.WriteLine("test2");
                                }
                            }
                            else//맨끝칸이 빈칸이 아니라면
                            {
                                if (checkCountList1[i] == 0) //체크카운트 리스트가  0이라면.
                                {
                                    checkList1[i] = false; // checkList를 거짓으로만들고
                                    Console.WriteLine("test3");
                                    break; // 탈출
                                }
                                else //체크카운트 리스트가 0이 아니라면 
                                {
                                    map[i, 14] = (1 + int.Parse(map[i, 14])).ToString();  // map i의 14칸을 숫자로 바꾼후 1을 더하고 다시 문자로 치환
                                    checkCountList1[i] -= 1;// checkListCount 를 1줄임
                                    Console.WriteLine("test4");
                                }
                            }
                        }
                    }
                }
            }
            if (inputKey.KeyChar == 's')// d를 입력받았을때 
            {
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++) //map을 하나하나 찾으면서
                    {
                        while (checkList2[j] == true) // 가로축의 1등장여부를 확인하는 checklist가 참일때
                        {
                            if (map[14, j] == "*") // 맨끝칸이 빈칸이라면
                            {
                                if (checkCountList2[j] == 0) //체크카운트 리스트가  0이라면, 즉 더이상 이 줄에는 1이 남아있지 않을때는.
                                {
                                    checkList2[j] = false; // checkList를 거짓으로만들고
                                    Console.WriteLine("test5");
                                    break; // 탈출
                                }
                                else // 체크카운트 리스트가 0이 아니여서 아직 이줄에 1이 남아있을때는
                                {
                                    map[14, j] = "1"; // 맨끝칸에 1을 추가하고
                                    checkCountList2[j] -= 1; // checkListCount를 1줄임 
                                    Console.WriteLine("test6");
                                }
                            }
                            else//맨끝칸이 빈칸이 아니라면
                            {
                                if (checkCountList2[j] == 0) //체크카운트 리스트가  0이라면.
                                {
                                    checkList2[j] = false; // checkList를 거짓으로만들고
                                    Console.WriteLine("test7");
                                    break; // 탈출
                                }
                                else //체크카운트 리스트가 0이 아니라면 
                                {
                                    map[14, j] = (1 + int.Parse(map[14, j])).ToString();  // map i의 14칸을 숫자로 바꾼후 1을 더하고 다시 문자로 치환
                                    checkCountList2[j] -= 1;// checkListCount 를 1줄임
                                    Console.WriteLine("test8");
                                }
                            }
                        }
                    }
                }
               
            }
        }
        public void UpdateMap()
        {
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    map[i, j] = "*";
                }
            }
        }

    }
}
