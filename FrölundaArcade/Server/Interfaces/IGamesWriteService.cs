namespace FrölundaArcade.Server.Interfaces
{
    public interface IGamesWriteService
    {
        Task<int> CreateAsync(GameUpsert game);
        Task UpdateAsync(GameUpsert game);
        Task DeleteAsync(int id);
    }
}
