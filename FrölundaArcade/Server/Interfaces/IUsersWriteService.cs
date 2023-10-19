namespace FrölundaArcade.Server.Interfaces
{
    public interface IUsersWriteService
    {
        public Task UpdateAsync(UserDetails userDetails);
    }
}
