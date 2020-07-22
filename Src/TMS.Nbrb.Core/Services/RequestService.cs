using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Services
{
    class RequestService : IRequestService
    {
        public async Task<Currency> GetCurrencyAsync (string code)
        {
            var response = await "https://www.nbrb.by/api/exrates/currencies"
                .AppendPathSegment(code)
                .GetJsonAsync<Currency>();
            return response;
        }

        public async Task<IEnumerable<Currency>> GetAllCurrenciesAsync()
        {
            var response = await "https://www.nbrb.by/api/exrates/currencies"
                .GetJsonAsync<List<Currency>>();
            return response;
        }
    }
}
