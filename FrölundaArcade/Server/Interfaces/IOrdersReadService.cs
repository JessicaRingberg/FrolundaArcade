namespace FrölundaArcade.Server.Interfaces
{
	public interface IOrdersReadService
	{
		Task<IEnumerable<OrderDetails>> GetOrders(string email);
		Task<IEnumerable<OrderDetails>> GetAllOrders();
	}
}
