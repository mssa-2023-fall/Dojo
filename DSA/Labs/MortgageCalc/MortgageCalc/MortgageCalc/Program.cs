using MortgageCalc;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Mortgage Calculator:\n" +
                          "Enter the home's principal amount:");
        int principalAmt = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Will this be a 10, 15, or 30 year loan?");
        Duration duration;
        switch(int.Parse(Console.ReadLine()))
        {
            case 10:
                duration = Duration.TenYears;
                break;
            case 15:
                duration = Duration.FifteenYears;
                break;
            case 30:
                duration = Duration.ThirtyYears;
                break;
            default:
                Console.WriteLine("Invalid duration. Defaulting to 15 year loan.");
                duration = Duration.FifteenYears;
                break;
        }

        Console.WriteLine("When will the loan start? Format: mm/dd/yyyy");
        DateTime originationDate = DateTime.Parse(Console.ReadLine());
        
        Console.WriteLine("What is the interest rate? Format: 4.5 = 4.5%");
        double interestRate = double.Parse(Console.ReadLine());

        //list out the values
        Console.WriteLine("Inputs:" +
                          $"Principal Amount: {principalAmt}\n" +
                          $"Loan Length: {duration}\n" +
                          $"Loan Start Date: {originationDate}\n" +
                          $"Interest Rate: {interestRate}");
    }
}