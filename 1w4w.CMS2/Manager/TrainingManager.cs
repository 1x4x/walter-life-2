using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class Training
    {
        public int Id { get; set; }                 // Primary Key
        public int UserId { get; set; }             // FK to Users table
        public int Pushups { get; set; }
        public int Situps { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }

    public class TrainingManager
    {
        private readonly string _connectionString = "server=mysql525.loopia.se;database=walter_nu;Port=3306;User ID=mysqlusr@w382970;Password=Yellowfish2025!;";

        public void CreateTableTraining()
        {
/*
CREATE TABLE Trainings (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    Pushups INT NOT NULL,
    Situps INT NOT NULL,
    CreatedDateTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDateTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
*/
        }
        // 🟢 CREATE
        public void CreateTraining(Training training)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Trainings (UserId, Pushups, Situps, CreatedDateTime, UpdatedDateTime)
                               VALUES (@UserId, @Pushups, @Situps, @CreatedDateTime, @UpdatedDateTime)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", training.UserId);
                    cmd.Parameters.AddWithValue("@Pushups", training.Pushups);
                    cmd.Parameters.AddWithValue("@Situps", training.Situps);
                    cmd.Parameters.AddWithValue("@CreatedDateTime", training.CreatedDateTime);
                    cmd.Parameters.AddWithValue("@UpdatedDateTime", training.UpdatedDateTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔵 READ by ID
        public Training GetTrainingById(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Trainings WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Training
                            {
                                Id = reader.GetInt32("Id"),
                                UserId = reader.GetInt32("UserId"),
                                Pushups = reader.GetInt32("Pushups"),
                                Situps = reader.GetInt32("Situps"),
                                CreatedDateTime = reader.GetDateTime("CreatedDateTime"),
                                UpdatedDateTime = reader.GetDateTime("UpdatedDateTime")
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 🔵 READ all
        public List<Training> GetAllTrainings()
        {
            var trainings = new List<Training>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Trainings ORDER BY CreatedDateTime DESC";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trainings.Add(new Training
                        {
                            Id = reader.GetInt32("Id"),
                            UserId = reader.GetInt32("UserId"),
                            Pushups = reader.GetInt32("Pushups"),
                            Situps = reader.GetInt32("Situps"),
                            CreatedDateTime = reader.GetDateTime("CreatedDateTime"),
                            UpdatedDateTime = reader.GetDateTime("UpdatedDateTime")
                        });
                    }
                }
            }
            return trainings;
        }

        // 🟡 UPDATE
        public void UpdateTraining(Training training)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Trainings 
                               SET UserId = @UserId, 
                                   Pushups = @Pushups, 
                                   Situps = @Situps,
                                   UpdatedDateTime = @UpdatedDateTime
                               WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", training.UserId);
                    cmd.Parameters.AddWithValue("@Pushups", training.Pushups);
                    cmd.Parameters.AddWithValue("@Situps", training.Situps);
                    cmd.Parameters.AddWithValue("@UpdatedDateTime", training.UpdatedDateTime);
                    cmd.Parameters.AddWithValue("@Id", training.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔴 DELETE
        public void DeleteTraining(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Trainings WHERE Id = @Id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}