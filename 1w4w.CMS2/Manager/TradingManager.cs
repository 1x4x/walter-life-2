using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class Trading
    {
        public int Id { get; set; }                  // Primary key
        public int UserId { get; set; }              // Reference to user
        public string Symbol { get; set; }           // e.g. "AAPL", "BTCUSD"
        public decimal Quantity { get; set; }        // Number of units
        public decimal Price { get; set; }           // Price per unit
        public string TradeType { get; set; }        // e.g. "BUY" or "SELL"
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }

    public class TradingManager
    {
        private readonly string _connectionString =
            "server=mysql525.loopia.se;database=walter_nu;Port=3306;User ID=mysqlusr@w382970;Password=Yellowfish2025!;";

        // 🟢 CREATE
        public void CreateTrade(Trading trade)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Tradings 
                               (UserId, Symbol, Quantity, Price, TradeType, CreatedDateTime, UpdatedDateTime)
                               VALUES (@UserId, @Symbol, @Quantity, @Price, @TradeType, @CreatedDateTime, @UpdatedDateTime)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", trade.UserId);
                    cmd.Parameters.AddWithValue("@Symbol", trade.Symbol);
                    cmd.Parameters.AddWithValue("@Quantity", trade.Quantity);
                    cmd.Parameters.AddWithValue("@Price", trade.Price);
                    cmd.Parameters.AddWithValue("@TradeType", trade.TradeType);
                    cmd.Parameters.AddWithValue("@CreatedDateTime", trade.CreatedDateTime);
                    cmd.Parameters.AddWithValue("@UpdatedDateTime", trade.UpdatedDateTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔵 READ BY ID
        public Trading GetTradeById(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Tradings WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Trading
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                Symbol = reader.GetString("Symbol"),
                                Quantity = reader.GetDecimal("Quantity"),
                                Price = reader.GetDecimal("Price"),
                                TradeType = reader.GetString("TradeType"),
                                CreatedDateTime = reader.GetDateTime("CreatedDateTime"),
                                UpdatedDateTime = reader.GetDateTime("UpdatedDateTime")
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 🔵 READ ALL
        public List<Trading> GetAllTrades()
        {
            var trades = new List<Trading>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Tradings ORDER BY CreatedDateTime DESC";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trades.Add(new Trading
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            Symbol = reader.GetString("Symbol"),
                            Quantity = reader.GetDecimal("Quantity"),
                            Price = reader.GetDecimal("Price"),
                            TradeType = reader.GetString("TradeType"),
                            CreatedDateTime = reader.GetDateTime("CreatedDateTime"),
                            UpdatedDateTime = reader.GetDateTime("UpdatedDateTime")
                        });
                    }
                }
            }
            return trades;
        }

        // 🟡 UPDATE
        public void UpdateTrade(Trading trade)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Tradings 
                               SET UserId = @UserId,
                                   Symbol = @Symbol,
                                   Quantity = @Quantity,
                                   Price = @Price,
                                   TradeType = @TradeType,
                                   UpdatedDateTime = @UpdatedDateTime
                               WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", trade.UserId);
                    cmd.Parameters.AddWithValue("@Symbol", trade.Symbol);
                    cmd.Parameters.AddWithValue("@Quantity", trade.Quantity);
                    cmd.Parameters.AddWithValue("@Price", trade.Price);
                    cmd.Parameters.AddWithValue("@TradeType", trade.TradeType);
                    cmd.Parameters.AddWithValue("@UpdatedDateTime", trade.UpdatedDateTime);
                    cmd.Parameters.AddWithValue("@Id", trade.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔴 DELETE
        public void DeleteTrade(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Tradings WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}