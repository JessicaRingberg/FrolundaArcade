namespace FrölundaArcade.Server.Interfaces
{
    public interface IGamesReadService
    {
        Task<IEnumerable<GameForList>> GetAllAsync(GameFilters filters);
        Task<GameDetails> GetGame(int gameId);

        Task<IEnumerable<GameUpsert>> GetAllUpsertAsync();
        Task<IEnumerable<GameForList>> GetProposals(string email);

    }
}
