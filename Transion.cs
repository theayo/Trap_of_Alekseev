using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCap_nte_framework_
{
    class transition
    {
        public void trans(int i)
        {
            switch (i)
            {
                case 0:
                    //Console.SetCursorPosition(0, 15);
                    Console.Clear();
                    Console.SetCursorPosition(15,15);
                    Console.WriteLine("\nВы покинули заведение благоухания и вышли на тропу ведущей к беспощадным страданиям.");
                    System.Threading.Thread.Sleep(6000);
                    Console.Clear();
                    System.Threading.Thread.Sleep(1000);
                    break;
                case 1:
                    Console.Clear();
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("\n Оставляя за горизонтом бывалого тестировщика, вы медленно спускаетесь в подвал...");
                    System.Threading.Thread.Sleep(6000);
                    Console.Clear();
                    System.Threading.Thread.Sleep(1000);
                    break;
                case 2:
                    Console.Clear();
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("\nПокидая шаловливый подвал, вы с уверенностью направляетесь к зданию с гордо надписью BSURA");
                    System.Threading.Thread.Sleep(6000);
                    Console.Clear();
                    System.Threading.Thread.Sleep(1000);
                    break;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("\nВы медленно открываете двери... Не самые приятные ощущения настегают вас при входе ");
                    System.Threading.Thread.Sleep(6000);
                    Console.Clear();
                    System.Threading.Thread.Sleep(1000);
                    break;
                default:
                    break;
            }
        }
    }
}
