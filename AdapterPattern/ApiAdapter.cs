using AdapterPattern.APIs;
using AdapterPattern.Domain;

namespace AdapterPattern
{
    public static class ApiAdapter
    {
        public static bool VerifyCustomer(LoanApplication application)
        {
            var customer = new LegacyCustomer
            {
                Name = $"{application.LastName}, {application.FirstName}",
                TotalIncome = application.Income
            };

            LegacyApi.CheckApplication(customer);

            return true;
        }

        public static int ScoreCustomer(LoanApplication application)
        {
            var customerToCheck = new LegacyCustomer { TotalIncome = application.Income };
            var legacyScore = LegacyApi.CheckScore(customerToCheck);

            return legacyScore.AbilityToPayScore;
        }
    }
}
