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
        Task<CustomerCartDto> GetCustomerCart(string user);
    }
}