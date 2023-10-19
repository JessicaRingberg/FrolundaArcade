using FrölundaArcade.Shared;

namespace FrölundaArcade.Client.Helpers
{
    public class GuestCart
    {
        private readonly List<CartGame> _cartGames;
        public GuestCart()
        {
            _cartGames = new List<CartGame>();
        }

        public List<CartGame> GetCart()
        {
            return _cartGames;
        }
        public void Add(CartGame game)
        {
            var existingGame = _cartGames.FirstOrDefault(g => g.GameId == game.GameId);
            if (existingGame != null && existingGame.StockQuantity < existingGame.Quantity)
            {
                existingGame.Quantity++;
            }
            else
            {
                _cartGames.Add(game);
            }
            
        }
        public void Delete(int id)
        {
            var removeGame = _cartGames.FirstOrDefault(g => g.GameId == id);
            if (removeGame != null)
            {
                if(removeGame.Quantity > 1)
                {
                    removeGame.Quantity--;
                }
                else
                {
                    _cartGames.Remove(removeGame);
                }
            }
        }
        public void DeleteCart()
        {
            _cartGames.Clear();
        }
    }
}
