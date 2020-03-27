using System;
using System.Linq;
using System.Collections.Generic;

namespace dnc200_change_calculator
{
  public class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine($"How much does it all cost playboy?");
      decimal cost = Convert.ToDecimal(Console.ReadLine());

      Console.WriteLine($"And How much hot dirty cash are you handing over?");
      decimal cash = Convert.ToDecimal(Console.ReadLine());

      if (cost == cash)
      {
        Console.WriteLine("No Change Due");
      }


      string results = Program.GetChange(cost, cash);
      Console.WriteLine(results);

      //foreach (string message in results)
      //{
      //  Console.WriteLine(message);
      //}
    }


    static public string GetChange(decimal cost, decimal cash)
    {
      decimal changeDue = cost - cash;
      var final = new List<decimal>();
      var finalStrings = new List<string>();

      if (changeDue > 0)
      {
        string message = "You are still owed";
        finalStrings.Add(message);
      }

      if (changeDue == 0)
      {
        string message = "No change due";
        finalStrings.Add(message);
      }

      if (changeDue < 0)
      {
        changeDue = Math.Abs(changeDue);

        decimal[] amounts = { 1m, 0.25m, 0.10m, 0.05m, 0.01m };

        for (int i = 0; i < amounts.Length; i++)
        {
          decimal amount = Math.Floor(changeDue / amounts[i]);
          decimal remainder = (changeDue % amounts[i]);
          final.Add(amount);
          changeDue = remainder;
        }
      }

      decimal[] results = final.ToArray();

      if (results.Length > 1)
      {
        string[] units = { "dollars", "quarters", "dimes", "nickles", "pennies" };
        string preface = "The total change due is, \r\n";
        finalStrings.Add(preface);
        for (int i = 0; i < results.Length; i++)
        {
          string change = $"{results[i]} {units[i]},\r\n";
          finalStrings.Add(change);
        }
      }

      string[] resultArray = finalStrings.ToArray();
      string result = string.Join(" ", resultArray);
      Console.WriteLine($"result {result}");
      return result;
    }

  }
}
