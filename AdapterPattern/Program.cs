using System;
using System.Text.Json;
using System.Threading;
using AdapterPattern.Domain;
using AdapterPattern.Util;

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
                Console.Clear();

                Console.WriteLine("Adapter Pattern -- Lending Context");
                Console.WriteLine();

                Console.WriteLine("1) Create Loan Application");                
                Console.ReadKey();

                // 1)
                // Create application
                // - LoanApplication
                // Random data
                var application = new LoanApplication
                {
                    FirstName = RandomString.Create(RandomNumber.Create(2, 8)),
                    LastName = RandomString.Create(RandomNumber.Create(4, 10)),
                    Employed = RandomBool.Create(),
                    Income = RandomNumber.Create(15000, 55000),
                    LoanAmount = RandomNumber.Create(500, 2500)
                };

                // 2)
                // Display random application for confirmation
                Console.Clear();

                Console.WriteLine(JsonSerializer.Serialize(application));
                Console.WriteLine();

                Console.WriteLine("Any key to submit...");
                Console.ReadKey();

                // 3)
                // Submit application to lender
                // - Lender
                var lender = new Lender();
                lender.SubmitApplication(application);

                // 4) - No UI
                // Lender verifies customer
                // - New API <-> Legacy API                
                // Adapter submits individual data points                

                // 5) - No UI
                // Lender retrieves customer score
                // - New API <-> Legacy API                
                // Adapter retrieves individual data points

                // 6)
                // Lender returns decision
                // - Loan decision
                // Return interest rate and approved/declined based on risk score
                var decision = lender.MakeDecision();

                // 7)
                // Display decision             
                Spinner();
                Console.WriteLine(JsonSerializer.Serialize(decision));

                Console.WriteLine();
                Console.WriteLine("Menu ( M )");
                Console.WriteLine("Exit ( X )");

                keypress = Console.ReadKey().Key.ToString();
            } while (keypress.ToLower() != "x");
        }

        #region UI       

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
    }
}
