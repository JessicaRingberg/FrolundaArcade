namespace FrölundaArcade.Server.Interfaces
{
	public interface IOrdersWriteService
	{
		Task CreateOrder(string userId);

        Task UpdateOrder(OrderDetails order);
		Task CreateGuestOrder(List<CartGame> games, GuestInfo guestInfo);
	}
}
