
using ConsoleApp1.DTO;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

string ConnectionString = @"Server=mssa23.database.windows.net; Authentication=Active Directory Password; Encrypt=True; Database=WideWorldImportersDW-Standard; User Id=student11@mssa2023outlook.onmicrosoft.com; Password=Pa55w.rd1234";

List<EmployeeDTO> empList = CreateListOfEmployee(ConnectionString);
List<EmployeeDTO> CreateListOfEmployeeUsingDapper(string ConnectionString)
{
    string sql = @"SELECT [Employee Key]
      ,[WWI Employee ID]
      ,[Employee]
      ,[Preferred Name]
      ,[Is Salesperson]
      ,[Photo]
      ,[Valid From]
      ,[Valid To]
      ,[Lineage Key]
  FROM [Dimension].[Employee]";

    List<EmployeeDTO> empListTwo = new List<EmployeeDTO>();

    using (SqlConnection conn = new SqlConnection(ConnectionString))
    {
        empListTwo = conn.Query<EmployeeDTO>(sql).ToList();
    }
    return empListTwo;
}

List<EmployeeDTO> CreateListOfEmployee(string connectionString)
{
    List<EmployeeDTO> empList = new List<EmployeeDTO>();
    string sql = @"SELECT [Employee Key]
      ,[WWI Employee ID]
      ,[Employee]
      ,[Preferred Name]
      ,[Is Salesperson]
      ,[Photo]
      ,[Valid From]
      ,[Valid To]
      ,[Lineage Key]
      FROM [Dimension].[Employee]";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var mem = new MemoryStream();
            reader.GetStream(5).CopyTo(mem);

            empList.Add(
                new EmployeeDTO(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetString(reader.GetOrdinal("Preferred Name")),
                    reader.GetBoolean(reader.GetOrdinal("Is Salesperson")),
                    mem.ToArray(),//see code above to deal with stream(varbinary,varchar(max), json, xml)
                    reader.GetDateTime(reader.GetOrdinal("Valid From")),
                    reader.GetDateTime(reader.GetOrdinal("Valid To")),
                    reader.GetInt32(reader.GetOrdinal("Lineage Key"))
                    )
                );
        }
    }
    return empList;
}

Console.WriteLine($"we have {empList.Count} employees");

ReadACustomer(ConnectionString);

static void ReadACustomer(string ConnectionString)
{
    Console.WriteLine("Please enter a postal code like 90005, 5 digits, followed by enter");
    string postalCode = Console.ReadLine();

    //quick check to confirm database access is possible
    using (var conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        string sql = "select [Customer Key], Customer, [Valid From] from Dimension.Customer where [postal code] = @postalcode";//@postalcode declares a parameter
                                                                                                                               //create an instance of SqlCommand Object, constructor of SqlCommand accepts sql and connection object-conn
        var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@postalcode", postalCode));

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int custKey = reader.GetInt32(0);
            string custName = reader.GetString(1);
            DateTime custValidFrom = reader.GetDateTime(2);

            Console.WriteLine($"{custName} has id:{custKey}. Active since {custValidFrom}");
            //for (int i = 0; i < reader.FieldCount; i++) {
            //    Console.Write(reader.GetName(i) + ":");
            //    Console.Write(reader.GetValue(i) + "\t");
            //}

            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
        }

        conn.Close();
    }
}

