string startDirectory = args[0];



PrintDir(startDirectory);



static void PrintDir(string startDirectory)
{



    var allDir = Directory.EnumerateDirectories(startDirectory);



    foreach (var directory in allDir)
    {
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            Console.WriteLine($"Accessed directory: {directoryInfo.FullName}");
            PrintDir(directory);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Cannot access: {directory}");
            continue;
        }
    }



}