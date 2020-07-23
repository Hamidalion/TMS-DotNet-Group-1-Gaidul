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

        public async Task<Rate> GetRateAsync(string code)
        {
            var response = await "https://www.nbrb.by/api/exrates/rates"
                .AppendPathSegment(code)
                .GetJsonAsync<Rate>();
            return response;
        }

        public async Task<IEnumerable<Rate>> GetAllRatesAsync()
        {
            var response = await "https://www.nbrb.by/api/exrates/rates"
                .GetJsonAsync<List<Rate>>();
            return response;
        }

        public async Task<Rate> GetRateByDateAsync(string code, DateTime date)
        {
            var response = await "https://www.nbrb.by/api/exrates/rates"
                .SetQueryParam("ondate", date.ToShortDateString())
                .AppendPathSegment(code)
                .GetJsonAsync<Rate>();
            return response;
        }

        public async Task<IEnumerable<Rate>> GetAllRatesByDateAsync(DateTime date)
        {
            var response = await "https://www.nbrb.by/api/exrates/rates"
                .SetQueryParam("ondate", date.ToShortDateString())
                .GetJsonAsync<List<Rate>>();
            return response;
        }
    }
}
