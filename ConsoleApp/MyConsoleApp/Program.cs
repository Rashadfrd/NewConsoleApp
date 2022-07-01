using MyClassLibrary.Enum;
using MyClassLibrary.MyClasses;
using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            string input;

            do
            {
                Console.WriteLine("\n1.Tapsiriq yarat:");
                Console.WriteLine("2.Butun tapsiriqlara bax:");
                Console.WriteLine("3.Vaxti kecmis tapsiriqlara bax:");
                Console.WriteLine("4.Secilmis statuslu tapsiriqlara bax:");
                Console.WriteLine("5.Tarix intervalina gore axtar:");
                Console.WriteLine("6.Tapsirigin statusunu deyismek:");
                Console.WriteLine("7.Tapsirigi editlemek");
                Console.WriteLine("8.Tapsiriq silmek:");
                Console.WriteLine("9.Tapsiriqlarda axtaris:");
                Console.WriteLine("0.Cixis:");
                Console.WriteLine("\nSeciminizi daxil edin:");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        break; 
                    case "2":

                        break; 
                    case "3":

                        break; 
                    case "4":

                        break; 
                    case "5":

                        break; 
                    case "6":

                        break; 
                    case "7":

                        break; 
                    case "8":

                        break; 
                    case "9":

                        break;
                }
            } while (input!="0");




        }
    }
}
