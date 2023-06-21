using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work12_23._06._19_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //배열의 초기화 
            string[] nums = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9","10","J","Q","K" };//int형 배열과 
            string[] patterns = new string[4] { "♠", "◈", "♥", "♣" };// string형 배열을 선언하고
            int[] compareNums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; //nums배열의 요소들은 string이라 비교할수없기에 비교배열 compareNums를 선언함
            List<Cards> Deck = new List<Cards>(); // 전체 카드덱
            List<Cards> computerDeck = new List<Cards>();  //컴퓨터의 패
            List<Cards> playerDeck = new List<Cards>(); //플레이이어의 패
            Random rand = new Random();
            int playerScore = 0; //플레이어의 점수
            int computerScore = 0; //컴퓨터의 점수
            int money = 0; //초기자금
            int betmoney = 0; //배팅금액
            string inputReroll; //리롤여부 입력변수
            //자금입력받기
            Console.WriteLine("초기자금을 입력해주세요");
            money=int.Parse(Console.ReadLine());
            while (true)
            {
                //덱초기화
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        Cards card = new Cards();
                        card.pattern = patterns[i];
                        card.num = nums[j];
                        card.compareNum = compareNums[j];
                        Deck.Add(card);

                    }
                }
              
                //현재 머니 상태
                Console.WriteLine("현재 남은돈{0}",money);
                //배팅금액입력
                Console.WriteLine("베팅할 금액을 입력하세요");
                betmoney = int.Parse(Console.ReadLine());

                /* //전체 배열 출력문
                 for (int i = 0; i < 4; i++)
                 {
                     for (int j = 0; j < 13; j++)
                     {
                         Console.Write("{0,3},{1,3},{2,3}", Deck[i*13+j].pattern, Deck[i*13+j].num,Deck[i*13+j].compareNum);
                     }
                     Console.WriteLine();
                 }*/
                DrawingCard();
            
                //출력문
                PrintDeck();

                //리롤 확인문
                Console.WriteLine("리롤을 원하시면 R을 입력해주세요");
                inputReroll = Console.ReadLine();
                if (inputReroll == "R")
                {
                    Reroll();
                }

                //경우의수확인
                //playerScore = OnePairTwoPair(playerDeck);
                //computerScore = OnePairTwoPair(computerDeck);
                playerScore += Triple(playerDeck);
                computerScore += Triple(computerDeck);
                //playerScore += Straight(playerDeck);
                //computerScore += Straight(computerDeck);
                //playerScore += Flush(playerDeck);
                //computerScore += Flush(computerDeck);
                //playerScore += Poker(playerDeck);
                //computerScore += Poker(computerDeck);
                //playerScore += FullHouse(playerDeck);
                //computerScore += FullHouse(computerDeck);
                //플레이어의 점수와 컴퓨터의 점수출력
                Console.WriteLine("플레이어의 점수{0} ", playerScore);
                Console.WriteLine("컴퓨터의 점수  {0} ", computerScore);
                //승리 패배 확정
                if (playerScore > computerScore)
                {
                    Console.WriteLine("승리하였습니다!!!");
                    money *= 2;
                }
                else if (playerScore == computerScore)
                {
                    Console.WriteLine("비겼습니다!!!");
                    
                }
                else
                {
                    Console.WriteLine("패배하였습니다!!!");
                    money -= betmoney;
                }
                if(money < 0) 
                {
                    Console.WriteLine("모든 돈을 잃고 패배하였습니다!");
                    break;
                }

                //덱삭제
                Deck.Clear();
                //플레이어 삭제
                playerDeck.Clear();
                //컴퓨터 삭제
                computerDeck.Clear(); 
                //Console.Clear();
            }

            //카드뽑기
            void DrawingCard()
            {
                //컴퓨터의 카드뽑기
                for (int i = 0; i < 7; i++)
                {
                    int index = rand.Next(0, Deck.Count);
                    Cards card = new Cards();
                    card.pattern = Deck[index].pattern;
                    card.num = Deck[index].num;
                    card.compareNum = Deck[index].compareNum;
                    computerDeck.Add(card);
                    Deck.Remove(Deck[index]);
                }
                //플레이어의 카드뽑기
                for (int j = 0; j < 5; j++)
                {
                    int index = rand.Next(0, Deck.Count);
                    Cards card = new Cards();
                    card.pattern = Deck[index].pattern;
                    card.num = Deck[index].num;
                    card.compareNum = Deck[index].compareNum;
                    playerDeck.Add(card);
                    Deck.Remove(Deck[index]);
                }
            }

            //출력함수
            void PrintDeck()
            {
                Console.WriteLine("컴퓨터가 뽑은 카드들");
                for (int i = 0; i < 7; i++)
                {
                    Console.Write("{0,3}{1}\t", computerDeck[i].pattern, computerDeck[i].num);
                }
                Console.WriteLine();
                Console.WriteLine("플레이어가 뽑은 카드들");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("{0,3}{1}\t", playerDeck[i].pattern, playerDeck[i].num);
                }
                Console.WriteLine();
            }
            //리롤기능
            void Reroll()
            {
                Console.WriteLine("리롤하고자하는 카드들의 인덱스를 입력하세요");
                int input = int.Parse(Console.ReadLine());
                int input2 = int.Parse(Console.ReadLine());

                playerDeck.Remove(playerDeck[input]);
                if (input < input2)
                {
                    playerDeck.Remove(playerDeck[input2 - 1]);
                }
                else
                {
                    playerDeck.Remove(playerDeck[input2]);
                }


                //리롤
                for (int j = 0; j < 2; j++)
                {
                    int index = rand.Next(0, Deck.Count);
                    Cards card = new Cards();
                    card.pattern = Deck[index].pattern;
                    card.num = Deck[index].num;
                    card.compareNum = Deck[index].compareNum;
                    playerDeck.Add(card);
                    Deck.Remove(Deck[index]);
                }
                //리롤후 출력
                PrintDeck();
            }

            int OnePairTwoPair(List<Cards> deck)
            {
                //숫자를 출력해서 저장할 공간
                List<int> compare = new List<int>();
                //페어카운트
                int compareScore = 0;
                //숫자출력문
                for(int i=0; i<deck.Count; i++)
                {
                    compare.Add(deck[i].compareNum);
                }
                //비교문
                for(int i=0; i<compare.Count; i++)
                {
                    for (int j =0; j < compare.Count;j++)
                    {
                        if (compare[i] == compare[j] &&(i !=j))
                        {
                            if (i > j)
                            {
                                compare.RemoveAt(i);
                                compare.RemoveAt(j);
                                compareScore += 1;
                            }
                            else
                            {
                                compare.RemoveAt(j);
                                compare.RemoveAt(i);
                                compareScore += 1;
                            }
                        }
                    }
                }
                
                return compareScore;
            }
            
            //Console.WriteLine("플레이어의 점수{0} ",playerScore) ;
            //Console.WriteLine("컴퓨터의 점수  {0} ",ComputerScore) ;
            
            int Triple(List<Cards> deck)
            {
                //숫자를 출력해서 저장할 공간
                List<int> compare = new List<int>();
                //트리플카운트
                int trippleCount = 0;
                //memory 변수
                int memory=100;
                //숫자출력문
                for (int i = 0; i < deck.Count; i++)
                {
                    compare.Add(deck[i].compareNum);
                }
                compare.Sort();
                //비교문
                for (int i = 0; i < deck.Count-1; i++)
                {
                    if ((compare[i] == compare[i + 1]))
                    {
                        trippleCount+=1;

                        if (trippleCount == 3)
                        {
                            break;
                        }
                        if (memory != compare[i+1])
                        {
                            trippleCount = 0;
                        }
                        memory = compare[i + 1];
                    }
                }
                

                return trippleCount;
            }

            //Console.WriteLine("플레이어의 점수{0} ", playerScore);
            //Console.WriteLine("컴퓨터의 점수  {0} ", ComputerScore);

            int Straight(List<Cards> deck)
            {
                //숫자를 출력해서 저장할 공간
                List<int> compare = new List<int>();
                List<string> comparePattern = new List<string>();
                //트리플카운트
                int StraightCount = 0;
                //숫자출력문
                for (int i = 0; i < deck.Count; i++)
                {
                    compare.Add(deck[i].compareNum);
                    comparePattern.Add(deck[i].pattern);
                }
                compare.Sort();
                //비교문
                if ((compare[0] + 1 == compare[1]) && (compare[1] + 1 == compare[2]) && (compare[2] + 1 == compare[3]) && (compare[3] + 1 == compare[4]))
                {// 숫자가 연속되는경우
                    if ((comparePattern[0] == comparePattern[1]) && (comparePattern[1] == comparePattern[2]) &&
                        (comparePattern[2] == comparePattern[3]) && (comparePattern[3] == comparePattern[4]))
                    {// 문양이 같은경우
                        if ((compare[0] == 1) && (compare[1] == 10) && (compare[2] == 11) && (compare[3] == 12) && (compare[3]==13))
                        { //0이 A인경우이면서 1이 10인경우이면서 2가 11이면서..
                            StraightCount += 12;
                        }
                        else if((compare[0] == 1) && (compare[1] == 2) && (compare[2] == 3) && (compare[3] == 4) && (compare[3] == 5))
                        { // 백스트레이트 플레쉬인경우
                            StraightCount += 11;
                        }
                        else
                        { // 스트레이트 플러쉬인경우
                            StraightCount += 10;
                        }
                    }
                 }
                return StraightCount;
            }

            int Flush(List<Cards> deck)
            {
                //숫자를 출력해서 저장할 공간
                List<string> compare = new List<string>();
                //플러쉬카운트
                int FlushCount = 0;
                //숫자출력문
                for (int i = 0; i < deck.Count; i++)
                {
                    compare.Add(deck[i].pattern);
                }
                //비교문
                for (int j = 1; j < compare.Count; j++)
                {
                    if (compare[0] == compare[j])
                    {
                        FlushCount += 1;
                    }
                }
                if(FlushCount >=4)
                {
                    FlushCount = 7;
                }
                else
                {
                    FlushCount = 0;
                }
                return FlushCount;
            }

            //Console.WriteLine("플레이어의 점수{0} ", playerScore);
            //Console.WriteLine("컴퓨터의 점수  {0} ", ComputerScore);

            int Poker(List<Cards> deck)
            {
                //숫자를 출력해서 저장할 공간
                List<int> compare = new List<int>();
                //Poker카운트
                int PokerCount = 0;
                //숫자출력문
                for (int i = 0; i < deck.Count; i++)
                {
                    compare.Add(deck[i].compareNum);
                }
                compare.Sort();
                //비교문
                for (int j = 0; j < 2; j++)
                {
                    if ((compare[j] == compare[j + 1]) && (compare[j + 1] == compare[j + 2])
                        && (compare[j+2] == compare[j+3]))
                    {
                        PokerCount = 9;
                    }
                }
                return PokerCount;
            }
            //Console.WriteLine("플레이어의 점수{0} ", playerScore);
            //Console.WriteLine("컴퓨터의 점수  {0} ", ComputerScore);

            int FullHouse(List<Cards> deck)
            {
                //숫자를 출력해서 저장할 공간
                List<int> compare = new List<int>();
                //FullHouse카운트
                int FullHouseCount = 0;
                //숫자출력문
                for (int i = 0; i < deck.Count; i++)
                {
                    compare.Add(deck[i].compareNum);
                }
                compare.Sort();
                //비교문

                if ((compare[0] == compare[1]) && (compare[1] == compare[2])
                    && (compare[3] == compare[4]))
                {
                    FullHouseCount = 8;
                }
                else if ((compare[0] == compare[1]) && (compare[2] == compare[3]) && (compare[3] == compare[4]))
                {
                    FullHouseCount = 8;
                }

                return FullHouseCount;
            } 
           





        }
    }
}
