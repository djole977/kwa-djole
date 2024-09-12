using AutoMapper;
using KWA_Djole.Business.Dtos;
using KWA_Djole.Business.Interfaces;
using KWA_Djole.Data;
using KWA_Djole.Data.Enums;
using KWA_Djole.Data.Models;
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
            return _mapper.Map<ShoppingItemDto>(await _db.ShoppingItems.Include(x => x.ShoppingItemGenre).FirstOrDefaultAsync(x => x.Id == id));
        }
        public async Task<List<ShoppingItemDto>> GetShoppingItems()
        {
            return _mapper.Map<List<ShoppingItemDto>>(await _db.ShoppingItems.Include(x => x.ShoppingItemGenre).ToListAsync());
        }
        public async Task DeleteShoppingItem(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ShoppingItemDto>> GetCustomerCart(string user)
        {
            return _mapper.Map<List<ShoppingItemDto>>(await _db.CustomerCarts.Include(x => x.Item).Where(x => x.UserId == user).Select(x => x.Item).ToListAsync());
        }
        public async Task<int> GetCustomerCartCount(string user)
        {
            return await _db.CustomerCarts.Where(x => x.UserId == user).CountAsync();
        }
        public async Task<bool> AddShoppingItemToCart(string user, int itemId)
        {
            CustomerCart customerCart = new CustomerCart
            {
                UserId = user,
                Item = await _db.ShoppingItems.FirstOrDefaultAsync(x => x.Id == itemId)
            };
            _db.CustomerCarts.Add(customerCart);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<List<ShoppingItemGenreDto>> GetAllGenres()
        {
            return _mapper.Map<List<ShoppingItemGenreDto>>(await _db.ShoppingItemGenres.ToListAsync());
        }
        public async Task<bool> AddUserGenres(string user, List<int> genreIds)
        {
            List<UserGenres> customerGenres = new List<UserGenres>();
            foreach (var genreId in genreIds)
            {
                customerGenres.Add(new UserGenres
                {
                    UserId = user,
                    GenreId = genreId
                });
            }
            _db.UserGenres.AddRange(customerGenres);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddProductToCart(string user, int productId)
        {
            try
            {
                CustomerCart customerCart = new CustomerCart
                {
                    UserId = user,
                    Item = await _db.ShoppingItems.FirstOrDefaultAsync(x => x.Id == productId)
                };
                _db.CustomerCarts.Add(customerCart);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> RemoveShoppingItemFromCart(string user, int itemId)
        {
            try
            {
                var item = await _db.CustomerCarts.FirstOrDefaultAsync(x => x.UserId == user && x.ItemId == itemId);
                _db.CustomerCarts.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> OrderItems(string user)
        {
            try
            {
                var items = await _db.CustomerCarts.Where(x => x.UserId == user).ToListAsync();
                Order order = new Order
                {
                    UserId = user,
                    Date = DateTime.Now,
                };
                _db.OrderItems.AddRange(items.Select(x => new OrderItem
                {
                    ShoppingItemId = x.ItemId,
                    Order = order,
                    Status = OrderStatus.U_toku
                }));
                _db.Orders.Add(order);
                _db.CustomerCarts.RemoveRange(items);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<OrderDto>> GetCustomerOrders(string user)
        {
            return _mapper.Map<List<OrderDto>>(await _db.Orders.Include(x => x.Items).ThenInclude(x => x.ShoppingItem).Where(x => x.UserId == user).ToListAsync());
        }
    }
}