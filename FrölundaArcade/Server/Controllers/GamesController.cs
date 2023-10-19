using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrölundaArcade.Server.Controllers
{
    public class GamesController : ApiControllerBase
    {
        private readonly IGamesReadService _gamesReadService;
        private readonly IGamesWriteService _gamesWriteService;

        public GamesController(IGamesReadService gamesReadService, IGamesWriteService gamesWriteService)
        {
            _gamesReadService = gamesReadService;
            _gamesWriteService = gamesWriteService;
        }

        [HttpGet]
        public async Task<IEnumerable<GameForList>> GetAll([FromQuery] GameFilters filters)
        {
            var games = await _gamesReadService.GetAllAsync(filters);
            
            return games;
        }
        [Route("[Action]")]
        [HttpGet]
        public async Task<IEnumerable<GameUpsert>> GetAllUpsert()
        {
            var games = await _gamesReadService.GetAllUpsertAsync();
            return games;
        }

        [HttpGet("{gameId}", Name = nameof(GetGame))]
        public async Task<GameDetails> GetGame(int gameId)
        {
            var game = await _gamesReadService.GetGame(gameId);
            return game;
        }

        [Authorize(Policy = Constants.Admin)]
        [HttpPost]
        public async Task<IActionResult> PostGame(GameUpsert game)
        {
            var gameId = await _gamesWriteService.CreateAsync(game);
            return CreatedAtRoute(nameof(GetGame), new {gameId} ,gameId);
        }

        [Authorize(Policy = Constants.Admin)]
        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeleteGame(int gameId)
        { 
            await _gamesWriteService.DeleteAsync(gameId);
            return NoContent();
        }

        [Authorize(Policy = Constants.Admin)]
        [HttpPut("{gameId}")]
        public async Task<IActionResult> UpdateGame(GameUpsert game, int gameId)
        {
            game.Id = gameId;
            await _gamesWriteService.UpdateAsync(game);
            return NoContent();
        }
    }
}