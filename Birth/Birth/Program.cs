using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth
{
    class Program
    {
        static void Main(string[] args)
        {
            Birth birth = new Birth();

            //birth.SetDataFromCode();
            //birth.SetDataFromFile();
            birth.SetDataFromDB();

            string input = string.Empty;
            int curIndex = 0;
            if (birth.birthDic.Count <= 0)
            {
                Console.WriteLine("데이터가 잘못되었습니다.");
                return;
            }

            Console.WriteLine("==== 기념일 맞추기 퀴즈 =====");

            do
            {
                Console.WriteLine("");
                Console.WriteLine("정답이 궁금하면 'list'를 입력하세요.");
                Console.WriteLine("그만하려면 'exit'를 입력하세요.");
                Console.WriteLine("{0}의 기념일 이름은 무엇일까요?", birth.birthDic.ElementAt(curIndex).Value.birth);

                input = Console.ReadLine();

                // 정/오답 처리
                if (input == birth.birthDic.ElementAt(curIndex).Value.name)
                {
                    birth.successIndices.Add(curIndex);
                    Console.WriteLine("정답입니다!!");
                }
                else if (input == "list")
                {
                    foreach(KeyValuePair<string, BirthInfo> kvp in birth.birthDic)
                    {
                        Console.WriteLine("{0} : {1}", kvp.Value.birth, kvp.Value.name);
                    }
                }
                else if (input == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("아쉽지만 틀렸습니다.");
                }

                // 모두 맞추었는지 검사
                if (birth.successIndices.Count == birth.birthDic.Count)
                {
                    Console.WriteLine("\n모두 맞추셨습니다. 축하합니다^^");
                    break;
                }

                // 다음 문제로 넘어가기
                curIndex = birth.GetNextIndex(curIndex);
                if (curIndex == birth.birthDic.Count)
                    curIndex = 0;

            } while (input != "exit");

            Console.WriteLine("\nGood bye.");
        }
        
    }

    public class Birth
    {
        public Dictionary<string, BirthInfo> birthDic = new Dictionary<string, BirthInfo>();
        public List<int> successIndices = new List<int>();

        public void SetDataFromCode()
        {
            BirthInfo b1 = new BirthInfo("신정", "2018.1.1.월");
            BirthInfo b2 = new BirthInfo("설날", "2018.2.16.금");
            BirthInfo b3 = new BirthInfo("삼일절", "2018.3.1.목");
            BirthInfo b4 = new BirthInfo("어린이날", "2018.5.5.토");
            BirthInfo b5 = new BirthInfo("석가탄신일", "2018.5.22.화");
            BirthInfo b6 = new BirthInfo("현충일", "2018.6.6.수");
            BirthInfo b7 = new BirthInfo("지방선거", "2018.6.13.수");
            BirthInfo b8 = new BirthInfo("광복절", "2018.8.15.수");
            BirthInfo b9 = new BirthInfo("추석", "2018.9.24.월");
            BirthInfo b10 = new BirthInfo("개천절", "2018.10.3.수");
            BirthInfo b11 = new BirthInfo("한글날", "2018.10.9.화");
            BirthInfo b12 = new BirthInfo("성탄절", "2018.12.25.화");

            birthDic.Add("b1", b1);
            birthDic.Add("b2", b2);
            birthDic.Add("b3", b3);
            birthDic.Add("b4", b4);
            birthDic.Add("b5", b5);
            birthDic.Add("b6", b6);
            birthDic.Add("b7", b7);
            birthDic.Add("b8", b8);
            birthDic.Add("b9", b9);
            birthDic.Add("b10", b10);
            birthDic.Add("b11", b11);
            birthDic.Add("b12", b12);
        }

        public void SetDataFromFile()
        {
            BirthTable.Instance.Read("../../Table/BirthTable.xml");

            birthDic = BirthTable.birthDic;
        }

        public void SetDataFromDB()
        {
            BirthDB birthDB = new BirthDB();
            birthDB.Read();

            birthDic = BirthDB.birthDic;
        }

        public int GetNextIndex(int curIndex)
        {
            for (int i = curIndex + 1; i < successIndices.Count; i++)
            {
                if (successIndices.IndexOf(i) != -1)
                    continue;
                return i;
            }

            return curIndex + 1;
        }
    }
}
