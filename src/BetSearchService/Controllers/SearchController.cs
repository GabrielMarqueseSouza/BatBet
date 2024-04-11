using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BetSearchServiceAPI.Models;
using MongoDB.Entities;
using System;
using System.Linq;
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
            var bets = DB.PagedSearch<Bets>().Sort(x => x.Descending(x => x.CreatedAt));

            if (!string.IsNullOrEmpty(searchParams.SearchTerm))
            {
                bets.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();
            }

            bets = searchParams.OrderBy switch
            {
                "League of Legends" => bets.Sort(x => x.Descending(x => x.GameName == "League of Legends")),
                "Poker" => bets.Sort(x => x.Descending(x => x.GameName == "Poker")),
                _ => bets.Sort(x => x.Ascending(x => x.CreatedAt))
            };

            bets = searchParams.FilterBy switch
            {
                "Active" => bets.Match(x => x.Status == Status.Active),
                "Finished" => bets.Match(x => x.Status == Status.Finished),
                "Suspended" => bets.Match(x => x.Status == Status.Suspended),
                "Canceled" => bets.Match(x => x.Status == Status.Canceled),
                _ => bets
            };

            if (!string.IsNullOrEmpty(searchParams.UserName))
            {
                bets.Match(x => x.UserName.Contains(searchParams.UserName));
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
