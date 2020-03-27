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

      string results = Program.GetChange(cost, cash);
      Console.WriteLine(results);

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

      if (changeDue == 0)
      {
        string message = "No change is due";
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
        string[] units = { "dollars", "quarters", "dimes", "nickels", "pennies" };
        string[] unitsSingular = { "dollar", "quarter", "dime", "nickel", "penny" };
        string preface = "The total change due is, \r\n";
        finalStrings.Add(preface);
        for (int i = 0; i < results.Length; i++)
          if (results[i] == 1)
          {
            string change = $"{results[i]} {unitsSingular[i]},\r\n";
            finalStrings.Add(change);
          } else
          {
            string change = $"{results[i]} {units[i]},\r\n";
            finalStrings.Add(change);
          }
        
      }

      string[] resultArray = finalStrings.ToArray();
      string result = string.Join(" ", resultArray);

      return result;
    }

  }
}
