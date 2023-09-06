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
    item = Console.ReadLine();
    foreach (var i in inventory)
    {
        if (i.Key.ToLower().StartsWith(item.ToLower()) && item.ToLower() != "ch" && item != "")
        {
            start:
            Console.WriteLine("Quantity: [Enter a number]");
            try
            {
               n = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                goto start;
            }

            // Add new Key, Value or change value of itemList SortedList
            if (itemList.ContainsKey(i.Key))
            {
                itemList[i.Key] += 1;
            }
            else
            {
                itemList.Add(i.Key, n);
            }
            totalPrice += i.Value * n;
            Console.WriteLine($"{i.Key} x {n} added.");
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


