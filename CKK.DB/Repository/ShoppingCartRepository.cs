using CKK.DB.Interfaces;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            _connectionFactory = Conn;
        }

        public ShoppingCartItem AddToCart(int ShoppingCardId, int ProductId, int quantity)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                ProductRepository _productRepository = new ProductRepository(_connectionFactory);
                var item = _productRepository.GetById(ProductId);
                var ProductItems = GetProducts(ShoppingCardId).Find(x => x.ProductId == ProductId);

                var shopItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCardId,
                    ProductId = ProductId,
                    Quantity = quantity
                };

                if(item.Quantity >= quantity)
                {
                    if(ProductItems != null)
                    {
                        if (quantity <= 0)
                        {
                            var test = Delete(ProductItems.ProductId);
                        }
                        else
                        {
                            var test = Update(shopItem);
                        }
                    }
                    else
                    {
                        var test = Add(shopItem);
                    }
                }

                return shopItem;
            }
        }

        public int ClearCart(int shoppingCartId)
        {
            var sql = $"DELETE FROM ShoppingCartItems WHERE ShoppingCartId = {shoppingCartId}";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = connection.Execute(sql);
                return result;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            var sql = $"SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = {shoppingCartId}";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = connection.Query<ShoppingCartItem>(sql).ToList();
                return result;
            }
        }

        public decimal GetTotal(int ShoppingCartId)
        {
            var sql = $"SELECT ProductId FROM ShoppingCartItems WHERE ShoppingCartId = {ShoppingCartId}";
            using (var connection = _connectionFactory.GetConnection)
            {
                var results = connection.Query<int>(sql).ToList();
                decimal total = 0.0m;
                foreach (int item in results)
                {
                    var sql_get_price = $"SELECT Price FROM Products WHERE Id={item}";
                    var item_price = connection.QuerySingleOrDefault<decimal>(sql_get_price);
                    total += item_price;
                }

                return total;
            }
        }

        public void Ordered(int shoppingCartId)
        {
            var order_number = "this_is_a_placeholder";
            var customer_id = 1;
            var sql = "INSERT INTO Orders (OrderNumber, CustomerId, ShoppingCartId) VALUES (@OrderNumber, @CustomerId, @ShoppingCartId)";
            using ( var connection = _connectionFactory.GetConnection)
            {
                var result = connection.Execute(sql, new {OrderNumber = order_number, CustomerId = customer_id, ShoppingCartId = shoppingCartId});
            }
        }

        public int Add(ShoppingCartItem entity)
        {
            var sql = "INSERT INTO ShoppingCartItems (ShoppingCartId,ProductId,Quantity) VALUES (@ShoppingCartId,@ProductId,@Quantity)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault(sql, entity);
                return result;
            }
        }

        public int Update(ShoppingCartItem entity)
        {
            var sql = "UPDATE ShoppingCartItems SET ShoppingCartId=@ShoppingCartId, ProductId=@ProductId, Quantity=@Quantity WHERE ProductId=@ProductId";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault(sql, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            var sql = $"DELETE FROM ShoppingCartItems WHERE ProductId={id}";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault(sql);
                return result;
            }
        }
    }
}
