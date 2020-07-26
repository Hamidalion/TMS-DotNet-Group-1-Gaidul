using System;
using System.Threading.Tasks;
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
                            var task = Task.Run(async () => { await ProgrammActions.ShowAllCurrencies(); });
                            task.Wait();
                            break;
                        }
                    case 2:
                        {
                            var task = Task.Run(async () => { await ProgrammActions.ShowCurrency(); });
                            task.Wait();
                            break;
                        }
                    case 3:
                        {
                            var task = Task.Run(async () => { await ProgrammActions.ShowAllRatesToBYN(); });
                            task.Wait();
                            break;
                        }
                    case 4:
                        {
                            var task = Task.Run(async () => { await ProgrammActions.ShowBYNRate(); });
                            task.Wait();
                            break;
                        }
                    case 5:
                        {
                            var task = Task.Run(async () => { await ProgrammActions.ShowBYNRateToData(); });
                            task.Wait();
                            break;
                        }
                    case 6:
                        {
                            var task = Task.Run(async () => { await ProgrammActions.ShowAllBYNRatesToData(); });
                            task.Wait();
                            break;
                        }
                    case 7:
                        {
                            ProgrammActions.ShowRecordedData();
                            break;
                        }
                    case 8:
                        {
                            ProgrammActions.ClearAllData();
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
