using Microsoft.AspNetCore.Mvc;
using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;

namespace NorthwindAML.Web.Controllers.Api
{
    [ApiController]
    [Route("api/watchlist")]
    public class WatchlistApiController : ControllerBase
    {
        private readonly IWatchlistRepository _repo;

        public WatchlistApiController(IWatchlistRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] Watchlist watchlist)
        {
            _repo.Add(watchlist);
            return Ok("entity added to watchlist");
        }
    }
}