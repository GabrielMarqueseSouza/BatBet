using BetSearchService.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BetSearchService.Services
{
    public class BetSvcHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _configuration = configuration;

        public async Task<List<Bets>> GetBetsForSearchDb()
        {
            string lastCreated = await DB.Find<Bets, string>()
                .Sort(x => x.Descending(x => x.CreatedAt))
                .Project(x => x.CreatedAt.ToString())
                .ExecuteFirstAsync();

            string requestUri = lastCreated is not null ?
                _configuration["BatBetServiceUrl"] + "/bets?date=" + lastCreated :
                _configuration["BatBetServiceUrl"] + "/bets";

            List<Bets> response = await _httpClient
            .GetFromJsonAsync<List<Bets>>(requestUri);

            return response;
        }
    }
}
