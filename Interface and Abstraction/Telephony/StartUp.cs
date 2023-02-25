using System;
using System.Linq;
using System.Text;
namespace Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<numbers.Length;i++)
            {
                bool flag = true;

                string currentNumber = numbers[i];
                for(int j=0;j<currentNumber.Length;j++)
                {
                    if(char.IsDigit(currentNumber[j])!=true)
                    {
                        Console.WriteLine("Invalid number!");
                        flag = false;
                        break;
                    }
                }
                if(currentNumber.Length==10 &&flag==true)
                {
                    ICall smartphone = new Smartphone();
                    smartphone.Call(currentNumber);
                }
                if(currentNumber.Length==7 &&flag==true)
                {
                    ICall stationaryphone = new Stationaryphone();
                    stationaryphone.Call(currentNumber);
                }
            }
           
            for(int i=0;i<sites.Length;i++)
            {
                bool flag = true;
                string currentSite = sites[i];
                for (int j = 0; j < currentSite.Length; j++)
                {
                    if (char.IsDigit(currentSite[j])==true)
                    {
                        Console.WriteLine("Invalid URL!");
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    IBrowse smartphone = new Smartphone();
                    smartphone.Browse(currentSite);
                }
            }
        }
    }
}
