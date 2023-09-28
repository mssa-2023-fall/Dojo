//idk what to do tbh... umm using dapper, connect to server. On request, Make table, query,
// insert 100 random customers.

using Dapper;

class Program
{
    public static void Main()
    {
        string connectionString = @"Server=mssa23.database.windows.net";
        Console.WriteLine("Whatcha want to do?\n" + 
                          "1 - Create a Table\n" +
                          "2 - Insert 100 Randos\n" +
                          "3 - Display Table\n" +
                          "4 - Delete a certain customer\n" +
                          "5 - Display Customer Count\n" +
                          "6 - Quit");

    }
    public static int ProcessInput()
    {
        Console.ReadLine();
    }
}