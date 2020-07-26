using System;
using System.Linq;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Services;

namespace TMS.Nbrb.Core.Service
{
    public static class ProgrammActions
    {
        private static readonly IRequestService requestService = new RequestService();
        private static readonly IFileService fileService = new FileService();
        public static void ShowMenu()
        {
            Console.WriteLine("Select the required action :");
            Console.WriteLine("1.Complete list of foreign currencies :");
            Console.WriteLine("2.Show one currency :");
            Console.WriteLine("3.Show all rates :");
            Console.WriteLine("4.Official exchange rate of the Belarusian ruble :");
            Console.WriteLine("5.Official exchange rate of the Belarusian ruble on some date :");
            Console.WriteLine("6.Official exchange rate of the Belarusian ruble on some date to all currencies :");
            Console.WriteLine("7.Show recorded data :");
            Console.WriteLine("8.Clear all data :");
            Console.WriteLine("9.Exit");
            Console.WriteLine();
        }
        public static async Task ShowAllCurrencies()
        {
            var data = await requestService.GetAllCurrenciesAsync();
            foreach (var currency in data)
            {
                Console.WriteLine($"ID of currency:{ currency.Cur_ID} Name of currency:{currency.Cur_Name}");
            }
        }
        public static async Task ShowCurrency()
        {
            Console.WriteLine("Enter Id of currency");
            var userinput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userinput))
            {
                var data = await requestService.GetCurrencyAsync(userinput);
                if (data != null)
                {
                    Console.WriteLine($"{ data.Cur_Name} Scale of currency:{data.Cur_Scale}");
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
        public static async Task ShowAllRatesToBYN()
        {
            var data = await requestService.GetAllRatesAsync();
            foreach (var rate in data)
            {
                Console.WriteLine($"{rate.Cur_Scale} {rate.Cur_Name} Rate to currency:{rate.Cur_OfficialRate} Date:{rate.Date}");
            }
        }
        public static async Task ShowBYNRate()
        {
            Console.WriteLine("Enter Id of currency");
            var userinput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userinput))
            {
                var data = await requestService.GetRateAsync(userinput);
                if (data != null)
                {
                    Console.WriteLine($"{data.Cur_Scale} {data.Cur_Name} Rate to currency:{data.Cur_OfficialRate} Date:{data.Date}");

                    Console.WriteLine("Do you wanna write this data to file?\n1:Write to file\n2:Do not write");
                    int.TryParse(Console.ReadLine(), out int decision);
                    switch (decision)
                    {
                        case 1:
                            {
                                fileService.WriteToFileAsync($"Scale: {data.Cur_Scale} {data.Cur_Name} Rate to currency:{data.Cur_OfficialRate} Date:{data.Date}");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("No data recorded");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Incorrect input");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
        public static async Task ShowBYNRateToData()
        {
            Console.WriteLine("Enter Id of currency");
            var userinput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userinput))
            {
                var data = await requestService.GetCurrencyAsync(userinput);
                if (data != null)
                {
                    Console.WriteLine($"Choosed currency: { data.Cur_Name}");
                    var usCulture = new System.Globalization.CultureInfo("ru-RU");
                    Console.WriteLine("Format: " + usCulture.DateTimeFormat.ShortDatePattern);
                    string dateString = Console.ReadLine();
                    if (DateTime.TryParse(dateString, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out DateTime userDate))
                        Console.WriteLine("Valid date entered:" + userDate.ToShortDateString());
                    else
                        Console.WriteLine("Invalid date specified!");
                    if (!string.IsNullOrEmpty(userinput) && (userDate <= DateTime.Today))
                    {
                        var dataRate = await requestService.GetRateByDateAsync(userinput, userDate);
                        if (dataRate != null)
                        {
                            Console.WriteLine($"{dataRate.Cur_Scale} {dataRate.Cur_Name} Rate to currency:{dataRate.Cur_OfficialRate} Date:{dataRate.Date}");
                            Console.WriteLine("Do you wanna write this data to file?\n1:Write to file\n2:Do not write");
                            int.TryParse(Console.ReadLine(), out int decision);
                            switch (decision)
                            {
                                case 1:
                                    {
                                        fileService.WriteToFileAsync($"Scale: {data.Cur_Scale} {dataRate.Cur_Name} Rate to currency:{dataRate.Cur_OfficialRate} Date:{dataRate.Date}");
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("No data recorded");
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Incorrect input");
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
        public static async Task ShowAllBYNRatesToData()
        {
            var usCulture = new System.Globalization.CultureInfo("ru-RU");
            Console.WriteLine("Please specify a date. Format: " + usCulture.DateTimeFormat.ShortDatePattern);
            string dateString = Console.ReadLine();
            if (DateTime.TryParse(dateString, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out DateTime userDate))
                Console.WriteLine("Valid date entered:" + userDate.ToShortDateString());
            else
                Console.WriteLine("Invalid date specified!");
            if (userDate <= DateTime.Today)
            {
                var data = await requestService.GetAllRatesByDateAsync(userDate);
                if (data != null && data.Count() != 0)
                {
                    foreach (var rate in data)
                    {
                        Console.WriteLine($"{rate.Cur_Scale} {rate.Cur_Name} Rate to currency:{rate.Cur_OfficialRate} Date:{rate.Date}");
                    }
                    Console.WriteLine("Do you wanna write this data to file?\n1:Write to file\n2:Do not write");
                    int.TryParse(Console.ReadLine(), out int decision);
                    switch (decision)
                    {
                        case 1:
                            {
                                foreach (var rate in data)
                                {
                                    fileService.WriteToFileAsync($"Scale: {rate.Cur_Name} Rate to currency:{rate.Cur_OfficialRate} Date:{rate.Date}");
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("No data recorded");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Incorrect input");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
        public static void ShowRecordedData()
        {
            fileService.ReadFile();
        }
        public static void ClearAllData()
        {
            fileService.ClearFile();
        }
    }
}
