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

            birth.SetDataFromCode();
            //birth.SetDataFromFile();
            //birth.SetDataFromDB();

            Console.Write("해당일은 무슨 기념일일까요? 기념일의 이름을 맞춰보세요.");
            Console.Write("정답이 궁금하면 'list'를 입력하세요.");
            //snum = Console.ReadLine();
        }

        
    }

    public class Birth
    {
        Dictionary<string, BirthInfo> birthDic = new Dictionary<string, BirthInfo>();

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

            birthDic.Add(b1.ToString(), b1);
            birthDic.Add(b2.ToString(), b2);
            birthDic.Add(b3.ToString(), b3);
            birthDic.Add(b4.ToString(), b4);
            birthDic.Add(b5.ToString(), b5);
            birthDic.Add(b6.ToString(), b6);
            birthDic.Add(b7.ToString(), b7);
            birthDic.Add(b8.ToString(), b8);
            birthDic.Add(b9.ToString(), b9);
            birthDic.Add(b10.ToString(), b10);
            birthDic.Add(b11.ToString(), b11);
            birthDic.Add(b12.ToString(), b12);
        }

        public void SetDataFromFile()
        {
            BirthTable.Instance.Read("../../Table/BirthTable.xml");
        }

        public void SetDataFromDB()
        {

        }
    }
}
