using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Interfaces
{
    interface IRequestService
    {
        Task<Currency> GetCurrencyAsync(string code);
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();
    }
}
