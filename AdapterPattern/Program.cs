using System;
using System.Threading;
using AdapterPattern.Domain;

namespace AdapterPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            string keypress;
            do
            {
                // 0)
                // Display starting menu
                LoanMenu();

                // 1)
                // Create application
                // - LoanApplication
                // Random data
                var application = CreateApplication();

                // 2)
                // Display application for confirmation
                DisplayApplication(application);

                // 3)
                // Submit application to lender
                // - Lender

                // 4)
                // Lender verifies customer
                // - New API <-> Legacy API
                // Submit customer in entirety (name, employment status, income)
                // Adapter submits individual data points

                // 5)
                // Lender retrieves customer score
                // - New API <-> Legacy API
                // Submit customer income
                // Adapter selects individual data points to return (suggested rate, customer risk)

                // 6)
                // Lender returns decision
                // - Loan decision
                // Return interest rate and approved/declined based on risk score

                // 7)
                // Display decision             

                Spinner();

                Console.WriteLine();
                Console.WriteLine("Menu ( M )");
                Console.WriteLine("Exit ( X )");

                keypress = Console.ReadKey().Key.ToString();
            } while (keypress.ToLower() != "x");
        }

        #region UI       

        private static void LoanMenu()
        {
            Console.Clear();

            Console.WriteLine("Adapter Pattern -- Lending Context");
            Console.WriteLine();

            Console.WriteLine("1) Create Loan Application");

            Console.WriteLine();
            Console.ReadKey();
        }

        private static void DisplayApplication(LoanApplication application)
        {
            Console.Clear();

            Console.WriteLine("New Application:");
            Console.WriteLine();
            Console.WriteLine($"First Name: {application.FirstName}");
            Console.WriteLine($"Last Name: {application.LastName}");
            Console.WriteLine($"Employed: {application.Employed}");
            Console.WriteLine($"Income: {application.Income}");
            Console.WriteLine($"Loan Amount: {application.LoanAmount}");

            Console.WriteLine();

            Console.WriteLine("Any key to submit...");

            Console.WriteLine();
            Console.ReadKey();
        }

        static int counter;

        private static void Spinner()
        {
            Console.WriteLine();
            Console.Write("Processing (simulated) ");

            int duration = 0;
            do
            {
                duration++;

                Spin();
            } while (duration < 30);

            Console.WriteLine();
        }

        private static void Spin()
        {
            counter++;

            switch (counter % 4)
            {
                case 0:
                    {
                        Console.Write("/");
                        counter = 0;
                        break;
                    }
                case 1:
                    {
                        Console.Write("-");
                        break;
                    }
                case 2:
                    {
                        Console.Write("\\");
                        break;
                    }
                case 3:
                    {
                        Console.Write("|");
                        break;
                    }
            }

            Thread.Sleep(100);

            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        #endregion

        #region Logic

        private static LoanApplication CreateApplication()
        {
            return new LoanApplication
            {
                FirstName = RandomString(RandomNumber(2, 10)),
                LastName = RandomString(RandomNumber(4, 15)),
                Employed = rng.NextDouble() >= 0.5,
                Income = RandomNumber(15000, 55000),
                LoanAmount = RandomNumber(500, 2500)
            };
        }

        #endregion

        #region Util

        // Random seed
        static readonly Random rng = new Random(Guid.NewGuid().GetHashCode());

        static string RandomString(int count)
        {
            string output = "";

            for (var i = 0; i <= count; i++)
            {
                output += (char)rng.Next('a', 'z');
            }

            return output;
        }

        static int RandomNumber(int min, int max)
        {
            return rng.Next(min, max);
        }

        #endregion
    }
}
