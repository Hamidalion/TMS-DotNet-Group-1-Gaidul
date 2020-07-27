using System;
using TMS.Nbrb.Core.Service;

namespace TMS.Nbrb.ConsoleApp
{
    class Program
    {
        static void Main()
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
                            ProgrammActions.ShowAllCurrenciesAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 2:
                        {
                            ProgrammActions.ShowCurrencyAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 3:
                        {
                            ProgrammActions.ShowAllRatesToBynAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 4:
                        {
                            ProgrammActions.ShowBynRateAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 5:
                        {
                            ProgrammActions.ShowBynRateToDateAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 6:
                        {
                            ProgrammActions.ShowAllBynRatesToDateAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 7:
                        {
                            ProgrammActions.ShowRecordedDataAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 8:
                        {
                            ProgrammActions.ClearAllDataAsync().GetAwaiter().GetResult();
                            break;
                        }
                    case 9:
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
