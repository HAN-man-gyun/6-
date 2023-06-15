using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace work8_23._06._14_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //item리스트
            List<KeyValuePair<string,int>> items = new List<KeyValuePair<string, int>>();
            items.Add(new KeyValuePair<string, int>("검",50));
            items.Add(new KeyValuePair<string, int>("방패",50));
            items.Add(new KeyValuePair<string, int>("상의",25));
            items.Add(new KeyValuePair<string, int>("하의",25));
            items.Add(new KeyValuePair<string, int>("귀환주문서",10));
            items.Add(new KeyValuePair<string, int>("hp포션",10));
            items.Add(new KeyValuePair<string, int>("mp포션",10));
            //인벤토리 리스트
            List<string> inventory = new List<string>();
            //보여줄 아이템 3가지.
            int item1Idx;
            int item2Idx;
            int item3Idx;
 ;
            //보여줄 3가지아이템이담긴 List
            List<KeyValuePair<string,int>> showItems = new List<KeyValuePair<string,int>>();
            //돈
            int money;

            //무엇을 살지 입력받는 변수 input
            string input;

            //money 입력받기
            Console.WriteLine("소지할골드를 입력하세요");
            money = int.Parse(Console.ReadLine());

            //구매
            while (money > 0)
            {
                //3가지 아이템 셔플
                while (true)
                {
                    item1Idx = rnd.Next(0, 7);
                    item2Idx = rnd.Next(0, 7);
                    item3Idx = rnd.Next(0, 7);

                    if ((item1Idx != item2Idx) && (item2Idx != item3Idx) && (item3Idx != item1Idx))
                    {
                        break;
                    }
                }
                //3가지 아이템을 보여줄리스트에 추가.
                showItems.Add(new KeyValuePair<string,int>(items[item1Idx].Key, items[item1Idx].Value));
                showItems.Add(new KeyValuePair<string,int>(items[item2Idx].Key, items[item2Idx].Value));
                showItems.Add(new KeyValuePair<string,int>(items[item3Idx].Key, items[item3Idx].Value));
                //보여줄리스트를 출력
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("{0} {1}원 ", showItems[i].Key, showItems[i].Value);
                }
                Console.WriteLine();

                //현재 인벤토리출력
                Console.WriteLine("현재 인벤토리");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.Write("{0} ", inventory[i]);
                }
                Console.WriteLine();
                //현재 남은돈 출력
                Console.WriteLine("현재 남은돈은 {0}입니다.",money);
                //무엇을살지 입력받기
                Console.WriteLine("무엇을 살지 입력하시오.");
                input = Console.ReadLine();
                //money와 inventory처리
                for (int i = 0; i < 7; i++)
                {
                    if (input == items[i].Key)
                    {
                        Console.WriteLine("{0}골드가 소모되었습니다.", items[i].Value);
                        money = money - (items[i].Value);
                        inventory.Add(items[i].Key);
                        break;
                    }
                }
                //보여줄리스트 초기화.
                showItems.Clear();
                //리스트내의 모든요소가지워짐.

                Console.WriteLine();
                Console.Clear();
            }
        }
    }
}
