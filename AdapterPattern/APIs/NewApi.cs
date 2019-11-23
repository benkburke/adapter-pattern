using AdapterPattern.Domain;

namespace AdapterPattern
{
    public static class NewApi
    {
        public static bool Verify(LoanApplication application)
        {
            var verified = ApiAdapter.VerifyCustomer(application);

            return verified;
        }

        public static int Score(LoanApplication application)
        {
            var customerScore = ApiAdapter.ScoreCustomer(application);

            return customerScore;
        }
    }
}
