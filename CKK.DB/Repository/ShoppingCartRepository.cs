using CKK.DB.Interfaces;
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
            var sql = "INSERT INTO ShoppingCartItems (ShoppingCartId,ProductId,Quantity) VALUES (@ShoppingCartId,@ProductId,@Quantity)";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = connection.QuerySingleOrDefault(sql, new { ShoppingCartId = ShoppingCardId, ProductId = ProductId, Quantity = quantity });
                return result;
            }
        }

        public int ClearCart(int shoppingCartId)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = connection.QuerySingleOrDefault(sql, new { ShoppingCartId = shoppingCartId });
                return result;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
            using (var connection = _connectionFactory.GetConnection)
            {
                var result = connection.Query<ShoppingCartItem>(sql, new {ShoppingCartItem = shoppingCartId}).ToList();
                return result;
            }
        }

        public decimal GetTotal(int ShoppingCartId)
        {
            var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
            using (var connection = _connectionFactory.GetConnection)
            {
                var results = connection.Query(sql);
                decimal total = 0.0m;
                foreach(var item in results)
                {
                    var sql_get_price = $"SELECT Price FROM Products WHERE Id={item.Id}";
                    total += connection.QuerySingle<decimal>(sql_get_price);
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
    }
}
