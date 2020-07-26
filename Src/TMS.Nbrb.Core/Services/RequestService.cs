using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Services
{
    public class RequestService : IRequestService
    {
        public async Task<Currency> GetCurrencyAsync(string code)
        {
            try
            {
                var response = await "https://www.nbrb.by/api/exrates/currencies"
                                .AppendPathSegment(code)
                                .GetJsonAsync<Currency>();
                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IEnumerable<Currency>> GetAllCurrenciesAsync()
        {
            try
            {
                var response = await "https://www.nbrb.by/api/exrates/currencies"
                .GetJsonAsync<List<Currency>>();
                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }

        public async Task<Rate> GetRateAsync(string code)
        {
            try
            {
                var response = await "https://www.nbrb.by/api/exrates/rates"
                               .AppendPathSegment(code)
                               .GetJsonAsync<Rate>();
                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IEnumerable<Rate>> GetAllRatesAsync()
        {
            try
            {
                var response1 = await "https://www.nbrb.by/api/exrates/rates"
                                .SetQueryParam("periodicity", 0)
                                .GetJsonAsync<List<Rate>>();
                var response2 = await "https://www.nbrb.by/api/exrates/rates"
                    .SetQueryParam("periodicity", 1)
                    .GetJsonAsync<List<Rate>>();
                response1.AddRange(response2);
                return response1;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Rate> GetRateByDateAsync(string code, DateTime date)
        {
            try
            {
                var response = await "https://www.nbrb.by/api/exrates/rates"
               .AppendPathSegment(code)
               .SetQueryParam("ondate", date.ToString("yyyy-MM-dd"))
               .GetJsonAsync<Rate>();
                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IEnumerable<Rate>> GetAllRatesByDateAsync(DateTime date)
        {
            try
            {
                var response1 = await "https://www.nbrb.by/api/exrates/rates"
                                .SetQueryParams(new { ondate = date.ToString("yyyy-MM-dd"), periodicity = 0 })
                                .GetJsonAsync<List<Rate>>();
                var response2 = await "https://www.nbrb.by/api/exrates/rates"
                    .SetQueryParams(new { ondate = date.ToString("yyyy-MM-dd"), periodicity = 1 })
                    .GetJsonAsync<List<Rate>>();
                response1.AddRange(response2);
                return response1;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
