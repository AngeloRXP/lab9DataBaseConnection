using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab9DataBaseConnection
{
    public class Courses
    {
        private string connectionString = "Your_Connection_String_Here";

        public void DisplayAllCourses()
        {
            string query = "SELECT * FROM Courses";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"CourseId: {reader["CourseId"]}, Name: {reader["Name"]}, Credits: {reader["Credits"]}");
                    }
                }
            }
        }


        public void AddCourse(int courseId, string name, int credits)
        {
            string query = "INSERT INTO Courses (CourseId, Name, Credits) VALUES (@CourseId, @Name, @Credits)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Credits", credits);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(int courseId, string newName, int newCredits)
        {
            string query = "UPDATE Courses SET Name = @Name, Credits = @Credits WHERE CourseId = @CourseId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@Name", newName);
                command.Parameters.AddWithValue("@Credits", newCredits);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int courseId)
        {
            string query = "DELETE FROM Courses WHERE CourseId = @CourseId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
