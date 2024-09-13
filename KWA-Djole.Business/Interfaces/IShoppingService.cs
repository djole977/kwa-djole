using KWA_Djole.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Interfaces
{
    public interface IShoppingService
    {
        Task<HomeDto> GetHomeData(string user);
        Task<ShoppingItemDto> GetShoppingItem(int id);
        Task<List<ShoppingItemDto>> GetShoppingItems();
        Task DeleteShoppingItem(int id);
        Task<List<ShoppingItemDto>> GetCustomerCart(string user);
        Task<int> GetCustomerCartCount(string user);
        Task<bool> AddShoppingItemToCart(string user, int itemId);
        Task<bool> RemoveShoppingItemFromCart(string user, int itemId, bool removeAllOfSameType = false);
        Task<List<ShoppingItemGenreDto>> GetAllGenres();
        Task<bool> AddUserGenres(string user, List<int> genreIds);
        Task<bool> AddProductToCart(string user, int productId);
        Task<bool> OrderItems(string user);
        Task<List<OrderDto>> GetCustomerOrders(string user);
        Task<bool> RateOrderItem(string user, int orderItemId, int rating, string comment);
        Task<List<ShoppingItemDto>> GetShoppingItemsFiltered(FilterDto filter);
    }
}