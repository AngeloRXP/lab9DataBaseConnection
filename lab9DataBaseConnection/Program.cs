using System;
using MySql.Data.MySqlClient;

namespace lab9DataBaseConnection
{


    class Program
    {
        static void Main(string[] args)
        {
           
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "251119-Jp",
                Database = "curses" 
            };

            
            Console.WriteLine(builder.ConnectionString);

            
            CourseManager courseManager = new CourseManager(builder.ConnectionString);

            
            courseManager.DisplayAllCourses();
        }
    }

    public class CourseManager
    {
        private string connectionString;

        public CourseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void DisplayAllCourses()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();

                    
                    string query = "SELECT * FROM Courses";

                    
                    MySqlCommand command = new MySqlCommand(query, connection);

                    
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"CourseId: {reader["CourseId"]}, Name: {reader["Name"]}, Credits: {reader["Credits"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("An error has occurred: " + ex.Message);
                }
            }
        }
    }

}
