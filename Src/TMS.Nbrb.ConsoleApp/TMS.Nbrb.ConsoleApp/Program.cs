using System;
using TMS.Nbrb.Core.Service;

namespace TMS.Nbrb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the app!");
            while (true)
            {
                ProgrammActions.ShowMenu();
                int.TryParse(Console.ReadLine(), out int userInput);
                switch (userInput)
                {
                    case 1:
                        {
                            ProgrammActions.();
                            break;
                        }
                    case 2:
                        {
                            ProgrammActions.();
                            break;
                        }
                    case 3:
                        {
                            ProgrammActions.();
                            break;
                        }
                    case 4:
                        {
                            ProgrammActions.();
                        }
                        break;
                    case 5:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Command doesn't exists:");
                        }
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
