using System.Reflection.Emit;
using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//create obj. to be scanned. define item prices
// loop -> scan mult. items on prompt. -> Enter item name -> scanned
// Calc. Total Price at the end.
//print the receipt using StringBuilder
decimal totalPrice = 0;
string item;
int n;
StringBuilder receipt = new StringBuilder();
SortedList<string, int> itemList = new SortedList<string, int>();
Dictionary<string, decimal> inventory = new Dictionary<string, decimal>()
{
    {"Apple", 1.99M},
    {"Banana", 0.70M},
    {"Pear", 1.50M},
    {"Watermelon", 5.50M},
    {"Cherries", 3.50M}
};

Console.WriteLine("Scan your items\n" +
                  "Apple: a | Banana: b | Pear: p | Watermelon: w | Cherries: c | Checkout: ch");

do
{
    item = Console.ReadLine().ToLower();
    if (item != "ch")
    {
        var selectedItem = inventory.Keys
            .Select(x => new { InitChar = x[0].ToString().ToLower(), Key = x, Value = inventory[x] })
            .Where(a => a.InitChar == item).FirstOrDefault() ;

        //n = Convert.ToInt32(Console.ReadLine());
        if (selectedItem != null)
        {
            Console.WriteLine("Quantity: [Enter a number]");
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (itemList.ContainsKey(selectedItem.Key))
                {
                    itemList[selectedItem.Key] += n;
                }
                else
                {
                    itemList.Add(selectedItem.Key, n);
                }
            }
            else
            {
                Console.WriteLine("not a valid number");
                continue;
            }
            totalPrice += selectedItem.Value * n;
            Console.WriteLine($"{selectedItem.Key} x {n} added.");
        }
        else {
            Console.WriteLine("Invalid item");
            Console.WriteLine("Apple: a | Banana: b | Pear: p | Watermelon: w | Cherries: c | Checkout: ch");
            continue;
        }
       
    }
    
}
while (item.ToLower() != "ch");


Console.WriteLine($"\nReceipt: ");
foreach (var i in itemList)
{
    receipt.AppendLine($"{i.Key} x {i.Value}: {inventory[i.Key]}");
}
Console.WriteLine(receipt.ToString());
Console.WriteLine($"Total Price: {totalPrice:c}");


