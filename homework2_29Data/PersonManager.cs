using System.Data.SqlClient;

namespace homework2_29Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }

    public class PersonManager
    {
        private string _connectionString;
        public PersonManager(string connectionString)
        {
             _connectionString = connectionString;
        }

        public List<Person> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"SELECT * FROM People";
            connection.Open();
            List<Person> people = new List<Person>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person()
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });

            }
            return people;
            
        }
        public void AddPerson(Person person)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $@"INSERT INTO People (FirstName, LastName, Age)
                                VALUES(@firstname, @lastname, @age)";
            cmd.Parameters.AddWithValue("@firstname", person.FirstName);
            cmd.Parameters.AddWithValue("@lastname", person.LastName);
            cmd.Parameters.AddWithValue("@age", person.Age);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddPeople(List<Person> people)
        {
            if (people.Count == 0)
            { return; }
            foreach (Person person in people)
            {
                if(person.FirstName == null || person.LastName == null || person.Age == 0)
                {
                    return;
                }
                AddPerson(person);
            }
        }
    }

  
}