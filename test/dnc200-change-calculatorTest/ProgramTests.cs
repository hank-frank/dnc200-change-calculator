using System;
using Xunit;
using dnc200_change_calculator;

namespace dnc200_change_calculatorTest
{
    public class ProgramTests
    {
        [Fact]
        public void GetChange_NoChangeDue()
        {
            string expected = "No change is due";
            string actual = Program.GetChange(1m,  1m);
            Assert.Contains(expected, actual);
        }

        [Fact]
        public void GetChange_MoneyOwed()
        {
            string expected = "You are still owed";
            string actual = Program.GetChange(2m, 1m);
            Assert.Contains(expected, actual);
        }

        [Fact]
        public void GetChange_ChangeDue()
        {
            string expected = "The total change due is";
            string actual = Program.GetChange(1m, 2m);
            Assert.Contains(expected, actual);
        }

        [Fact]
        public void GetChange_ChangeDueExact1()
        {
            string[] expected = new string[]{
                "The total change due is",
                "0 dollars",
                "0 quarters",
                "0 dimes",
                "0 nickels",
                "1 penny"
            };
            string actual = Program.GetChange(2.34m, 2.35m);
            foreach (string value in expected)
            {
                Assert.Contains(value, actual);
            }
        }

        [Fact]
        public void GetChange_ChangeDueExact2()
        {
            string[] expected = new string[]{
                "The total change due is",
                "1 dollar",
                "1 quarter",
                "1 dime",
                "1 nickel",
                "0 pennies"
            };
            string actual = Program.GetChange(2.34m, 3.74m);
            foreach (string value in expected)
            {
                Assert.Contains(value, actual);
            }
        }

        [Fact]
        public void GetChange_MoneyOwedExact1()
        {
            string[] expected = new string[]{
                "You are still owed",
                "0 dollars",
                "1 quarter",
                "1 dime",
                "0 nickels",
                "0 pennies"
            };
            string actual = Program.GetChange(2.69m, 2.34m);
            foreach (string value in expected)
            {
                Assert.Contains(value, actual);
            }
        }

        [Fact]
        public void GetChange_MoneyOwedExact2()
        {
            string[] expected = new string[]{
                "You are still owed",
                "1 dollar",
                "0 quarters",
                "0 dimes",
                "1 nickel",
                "1 penny"
            };
            string actual = Program.GetChange(3.40m, 2.34m);
            foreach (string value in expected)
            {
                Assert.Contains(value, actual);
            }
        }
    }
}


//[Fact]
//public void GetChange_NoChangeDue()
//{
//  string[] expected = new string[] { "No change is due" };
//  string actual = Program.GetChange(1m, 1m);
//  Assert.Contains(expected, actual);
//}

//[Fact]
//public void GetChange_MoneyOwed()
//{
//  string[] expected = new string[] { "You are still owed" };
//  string actual = Program.GetChange(2m, 1m);
//  Assert.Contains(expected, actual);
//}

//[Fact]
//public void GetChange_ChangeDue()
//{
//  string[] expected = new string[] { "The total change due is" };
//  string actual = Program.GetChange(1m, 2m);
//  Assert.Contains(expected, actual);
//}