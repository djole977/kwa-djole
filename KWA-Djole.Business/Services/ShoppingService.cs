using AutoMapper;
using KWA_Djole.Business.Dtos;
using KWA_Djole.Business.Interfaces;
using KWA_Djole.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWA_Djole.Business.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ShoppingService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<HomeDto> GetHomeData(string user)
        {
            HomeDto homeDto = new HomeDto();
            homeDto.ShoppingItems = await GetShoppingItems();
            homeDto.TotalItems = await GetCustomerCartCount(user);

            return homeDto;
        }
        public async Task<ShoppingItemDto> GetShoppingItem(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ShoppingItemDto>> GetShoppingItems()
        {
            return _mapper.Map<List<ShoppingItemDto>>(await _db.ShoppingItems.ToListAsync());
        }
        public async Task DeleteShoppingItem(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<CustomerCartDto> GetCustomerCart(string user)
        {
            return _mapper.Map<CustomerCartDto>(await _db.CustomerCarts.Include(x => x.Item).Where(x => x.UserId == user).ToListAsync());
        }
        public async Task<int> GetCustomerCartCount(string user)
        {
            return await _db.CustomerCarts.Where(x => x.UserId == user).CountAsync();
        }
    }
}