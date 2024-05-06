using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BetSearchServiceAPI.Models;
using MongoDB.Entities;
using BetSearchServiceAPI.RequestHelpers;

namespace BetSearchServiceAPI.Controllers
{
    [ApiController]
    [Route("search")]
    public class SearchController : ControllerBase
    {
        public SearchController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> SearchBets([FromQuery] SearchParams searchParams)
        {
            PagedSearch<Bets, Bets> bets = DB.PagedSearch<Bets>();

            if (!string.IsNullOrEmpty(searchParams.SearchTerm))
            {
                bets.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();
            }

            bets = searchParams.OrderBy switch
            {
                "Game" => bets.Sort(s => s.GameName, Order.Descending),
                "Oldest" => bets.Sort(x => x.CreatedAt, Order.Ascending),
                _ => bets.Sort(x => x.CreatedAt, Order.Descending)
            };

            bets = searchParams.FilterBy switch
            {
                "Active" => bets.Match(x => x.Status == Status.Active),
                "Finished" => bets.Match(x => x.Status == Status.Finished),
                "Suspended" => bets.Match(x => x.Status == Status.Suspended),
                "Canceled" => bets.Match(x => x.Status == Status.Canceled),
                _ => bets
            };

            if (!string.IsNullOrEmpty(searchParams.UserId))
            {
                bets.Match(x => x.UserId == searchParams.UserId);
            }

            bets.PageNumber(searchParams.PageNumber).PageSize(searchParams.PageSize);

            var (Results, TotalCount, PageCount) = await bets.ExecuteAsync();

            return Ok(new
            {
                results = Results,
                pageCount = PageCount,
                totalCount = TotalCount
            });
        }
    }
}
