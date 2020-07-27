using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Helpers;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Services
{
    /// <inheritdoc cref="IRequestService"/>
    public class RequestService : IRequestService
    {
        public async Task<Currency> GetCurrencyAsync(string code)
        {
            try
            {
                var response = await Constants.UrlApi
                    .AppendPathSegments("exrates", "currencies", code)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<IEnumerable<Currency>> GetAllCurrenciesAsync()
        {
            try
            {
                var response = await Constants.UrlApi
                    .AppendPathSegments("exrates", "currencies")
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<Rate> GetRateAsync(string code)
        {
            try
            {
                var response = await Constants.UrlApi
                    .AppendPathSegments("exrates", "rates", code)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<IEnumerable<Rate>> GetAllRatesAsync()
        {
            try
            {
                var rates = new List<Rate>();

                static async Task<List<Rate>> SendRequestAsync(int periodicity)
                {
                    return await Constants.UrlApi
                        .AppendPathSegments("exrates", "rates")
                        .SetQueryParam("periodicity", periodicity)
                        .GetJsonAsync<List<Rate>>();
                }

                rates.AddRange(await SendRequestAsync(0));
                rates.AddRange(await SendRequestAsync(1));

                return rates;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<Rate> GetRateByDateAsync(string code, DateTime date)
        {
            try
            {
                var response = await Constants.UrlApi
                    .AppendPathSegments("exrates", "rates", code)
                    .SetQueryParam("ondate", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<IEnumerable<Rate>> GetAllRatesByDateAsync(DateTime date)
        {
            try
            {
                var rates = new List<Rate>();

                static async Task<List<Rate>> SendRequestAsync(DateTime date, int periodicity)
                {
                    return await Constants.UrlApi
                        .AppendPathSegments("exrates", "rates")
                        .SetQueryParams(new { ondate = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), periodicity })
                        .GetJsonAsync<List<Rate>>();
                }

                rates.AddRange(await SendRequestAsync(date, 0));
                rates.AddRange(await SendRequestAsync(date, 1));

                return rates;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
