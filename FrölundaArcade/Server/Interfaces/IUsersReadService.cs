namespace FrölundaArcade.Server.Interfaces
{
    public interface IUsersReadService
    {
        Task<IEnumerable<UserForList>> GetAllAsync();
        Task<UserDetails> GetUser(string userId);
    }
}
