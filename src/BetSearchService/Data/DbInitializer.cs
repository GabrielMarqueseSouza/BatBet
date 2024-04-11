using BetSearchServiceAPI.Services;
using BetSearchServiceAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BetSearchServiceAPI.Data
{
    public class DbInitializer
    {
        public static async Task DbInit(WebApplication app)
        {
            await DB.InitAsync("SearchBetDb",
                MongoClientSettings.FromConnectionString(
                    app.Configuration.GetConnectionString("MongoDbConnection")));

            await DB.Index<Bets>()
                 .Key(x => x.ID, KeyType.Text)
                 .Key(x => x.CreatedAt, KeyType.Text)
                 .Key(x => x.GameName, KeyType.Text)
                 .Key(x => x.UserName, KeyType.Text)
                 .CreateAsync();

            using IServiceScope scope = app.Services.CreateScope();

            BetSvcHttpClient httpClient = scope.ServiceProvider.GetRequiredService<BetSvcHttpClient>();

            List<Bets> items = await httpClient.GetBetsForSearchDb();

            if (items.Count > 0) { await DB.SaveAsync(items); }
        }
    }
}
