using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Models;

namespace TMS.Nbrb.Core.Interfaces
{
    /// <summary>
    /// Сервис для отправки запросов.
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Получить валюту.
        /// </summary>
        /// <param name="code">Код валюты.</param>
        /// <returns>Валюта.</returns>
        Task<Currency> GetCurrencyAsync(string code);

        /// <summary>
        /// Получить список всех валют.
        /// </summary>
        /// <returns>Список всех валют.</returns>
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();

        /// <summary>
        /// Получить курс валюты.
        /// </summary>
        /// <param name="code">Код валюты.</param>
        /// <returns>Курс валюты.</returns>
        Task<Rate> GetRateAsync(string code);

        /// <summary>
        /// Получить список всех курсов валют.
        /// </summary>
        /// <returns>Список курсов валют.</returns>
        Task<IEnumerable<Rate>> GetAllRatesAsync();

        /// <summary>
        /// Получить курс валюты на определенную дату.
        /// </summary>
        /// <param name="code">Код валюты.</param>
        /// <param name="date">Дата.</param>
        /// <returns>Курс валюты.</returns>
        Task<Rate> GetRateByDateAsync(string code, DateTime date);

        /// <summary>
        /// Получить список всех курсов валют на определенную дату.
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <returns>Список курсов валют.</returns>
        Task<IEnumerable<Rate>> GetAllRatesByDateAsync(DateTime date);
    }
}