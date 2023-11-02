// Step 1
using System.Data.SqlClient;
namespace DatabaseConnectivity
{
    internal class Program
    {
        static SqlConnection connection;
        static SqlCommand command;
        static void Main(string[] args)
        {// Step 2

            int c;
            Console.WriteLine("Enter choice");
            c = Byte.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    {
                        CreateRecord(); break;
                    }
                    case 2: {  EmployeesList(); break;}
                case 3: { EditRecord(); break; }
                case 4: { DeleteRecord (); break; }
            }



        }

        static string GetConnectionString()
        {
            return "data source=ANAMIKA\\SQLSERVER;initial catalog=Prcaticedb;integrated security=true";          
        }
        static SqlConnection GetConnection()
        {
            connection = new SqlConnection(GetConnectionString());
            return connection;


        }
        static void CreateRecord()
        {
           connection = GetConnection();
            //string connectionString = "data source=ANAMIKA\\SQLSERVER;initial catalog=Prcaticedb;integrated security=true";
            //connection.ConnectionString = connectionString;

            //Step 3

            SqlCommand command = new SqlCommand();
            command.CommandText = "Insert into Employee values(1, 'ajay', 'delhi', 20000)";
            command.Connection = connection;

            // Step 4

            connection.Open();

            // Step 5:

            command.ExecuteNonQuery();

            connection.Close();
            command.Dispose();
            connection.Dispose();

        }
        static void EmployeesList()
        {
            using (connection = GetConnection())
            {
                //SqlConnection connection = new SqlConnection();
                //string connectionString = "data source=ANAMIKA\\SQLSERVER;initial catalog=Prcaticedb;integrated security=true";
                //connection.ConnectionString = connectionString;

                //Step 3

                using (command = new SqlCommand())
                {
                    command.CommandText = "select * from employee";
                    command.Connection = connection;

                    // Step 4

                    connection.Open();

                    // Step 5:

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + " " + reader["name"] + " " + reader[2] + " " + reader[3]);


                        }
                    }
                    connection.Close();
                }
            }
                }


        static void DeleteRecord()
        {
            connection = GetConnection();
            //SqlConnection connection = new SqlConnection();
            //string connectionString = "data source=ANAMIKA\\SQLSERVER;initial catalog=Prcaticedb;integrated security=true";
            //connection.ConnectionString = connectionString;

            //Step 3

            SqlCommand command = new SqlCommand();
            command.CommandText = "delete from Employee where id=1";
            command.Connection = connection;

            // Step 4

            connection.Open();

            // Step 5:

            command.ExecuteNonQuery();

            connection.Close();

        }
        static void EditRecord()
        {
            connection = GetConnection();
            //SqlConnection connection = new SqlConnection();
            //string connectionString = "data source=ANAMIKA\\SQLSERVER;initial catalog=Prcaticedb;integrated security=true";
            //connection.ConnectionString = connectionString;

            //Step 3

            SqlCommand command = new SqlCommand();
            command.CommandText = "update Employee set address = 'N Delhi' where id=1";
            command.Connection = connection;

            // Step 4

            connection.Open();

            // Step 5:

            command.ExecuteNonQuery();

            connection.Close();

        }

    }
     
        }
    