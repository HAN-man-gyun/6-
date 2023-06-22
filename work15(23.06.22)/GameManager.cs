using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace work15_23._06._22_
{
    class GameManager
    {
        public bool battleOn;
        public int huntCount;
        public string input;
        public bool QuestSuccessCheck;
        public void Quest() // npc에게서 받는 퀘스트 
        {
            
            if (QuestSuccessCheck == true) // 퀘스트 성공여부 변수가 참이라면
            {
                Console.SetCursorPosition(70, 20);
                Console.WriteLine("몬스터들을 해치워주다니... 믿고있었다네!! 자네가 해낼줄알았어!");

                Console.SetCursorPosition(70, 21);
                Console.WriteLine("여기 보상을 받아가게나...");
                Task.Delay(3000).Wait();
            }
            else if (QuestSuccessCheck == false) // 퀘스트 성공여부 변수가 거짓이라면, 퀘스트완료를 못했다면
            {
                Console.SetCursorPosition(70, 16);
                Console.Write(" 몬스터 3마리를 잡아주세요 !!! 모험가여!!!!");
                Console.SetCursorPosition(70, 17);
                Console.WriteLine("Y 혹은 N을 입력해주세요"); 
                Console.SetCursorPosition(0, 27);
                input = Console.ReadLine(); // Y 혹은 N으로 수락이나 거절하기가능
                switch (input)
                {
                    case "Y":
                        Console.SetCursorPosition(70, 18);
                        Console.WriteLine("고맙네!!! 기대하고있겠네!"); // 수락한경우
                        Task.Delay(500).Wait();
                        break;

                    case "N":
                        Console.SetCursorPosition(70, 19);
                        Console.WriteLine("제발 우리를 버리지 말아주게나...."); //거절한경우
                        Task.Delay(500).Wait();
                        break;
                }
            }
        }
        public void Battle(ref Player player, ref Monster monster,ref Map background) //배틀 함수
        {
            while (true) //무한히 반복
            {
                Console.SetCursorPosition(50, 7);
                Console.Write("플레이어의 hp :{0,3}  몬스터의 hp :{1,3}    ", player.hp, monster.hp);
                Task.Delay(300).Wait();
                Console.SetCursorPosition(50, 8);
                Console.Write("플레이어가 몬스터를 공격했습니다!"); 
                Task.Delay(300).Wait();
                Console.SetCursorPosition(50, 9);
                Console.Write("플레이어가 30의 데미지를 줬습니다.");
                Task.Delay(1000).Wait();
                monster.hp = monster.hp - player.atk;  // 몬스터 hp가 플레이어의 atk만큼 감소
                if(monster.hp <= 0 ) // 만약 몬스터의 hp가 0과 같거나 0보다 작다면
                {
                    Console.SetCursorPosition(50, 15);
                    Console.WriteLine("몬스터사냥에 성공했습니다!");
                    monster.hp = 100;
                    player.hp = 150;
                    break;// 반복을 탈출
                }
                Console.SetCursorPosition(50, 10);
                Console.Write("몬스터가 플레이어를 공격했습니다!");
                Task.Delay(300).Wait();
                Console.SetCursorPosition(50, 11);
                Console.Write("몬스터가 10의 데미지를 줬습니다.");
                Task.Delay(300).Wait();
                Console.SetCursorPosition(50, 12);
                Task.Delay(1000).Wait();

                player.hp = player.hp - monster.atk; // 플레이어 ,hp가 몬스터의 atk만큼 감소
                
                if (monster.hp <= 0)
                {
                    Console.SetCursorPosition(50, 15);
                    Console.WriteLine("몬스터사냥에 성공했습니다!");
                    Task.Delay(1000).Wait();
                    monster.hp = 100;
                    player.hp = 150;
                    break; // 반복을 탈출
                }
            }
        }
    }
}
