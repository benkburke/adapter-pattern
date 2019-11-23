using AdapterPattern.APIs;
using AdapterPattern.Util;

namespace AdapterPattern
{
    public static class LegacyApi
    {
        public static bool CheckApplication(LegacyCustomer customer)
        {
            return RandomBool.Create();
        }

        public static LegacyCustomerScore CheckScore(LegacyCustomer customer)
        {
            var customerScore = new LegacyCustomerScore
            {
                CreditScore = RandomNumber.Create(0, 10),
                AbilityToPayScore = RandomNumber.Create(0, 10),
                DefaultChanceScore = RandomNumber.Create(0, 10)
            };

            return customerScore;
        }
    }
}
