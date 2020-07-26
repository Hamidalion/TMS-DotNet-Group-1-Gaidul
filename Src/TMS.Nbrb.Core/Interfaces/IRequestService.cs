using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Interfaces
{
    public interface IRequestService
    {
        Task<Currency> GetCurrencyAsync(string code);
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();
        Task<Rate> GetRateAsync(string code);
        Task<IEnumerable<Rate>> GetAllRatesAsync();
        Task<Rate> GetRateByDateAsync(string code, DateTime date);
        Task<IEnumerable<Rate>> GetAllRatesByDateAsync(DateTime date);
    }
}