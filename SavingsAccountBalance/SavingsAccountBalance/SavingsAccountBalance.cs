using System;

namespace SavingsAccountBalance
{
    class SavingsAccountBalance
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Balance(10000, 1, 20000, 1, 2) == 10201);
            Console.WriteLine(Balance(25000, 2, 20000, 1, 2) == 25904.5);
            Console.WriteLine(Balance(19800, 2, 20000, 1, 2) == 20597.96);
        }

        public static double Balance(double openingSum, int interestRate, int taxFreeLimit, int taxRate, int numMonths)
        {
            double balance = openingSum;
            for(int count = 0; count < numMonths; count++)
            {
                double monthlyInterest = balance * interestRate / 100;
                double monthlyTax = 0;
                if (balance > taxFreeLimit)
                    monthlyTax = (balance - taxFreeLimit) * taxRate / 100;
                balance = balance + monthlyInterest - monthlyTax;
            }
            return balance;
        }
    }
}
