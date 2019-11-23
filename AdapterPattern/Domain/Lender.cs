namespace AdapterPattern.Domain
{
    public class Lender
    {
        private int _customerScore;

        public void SubmitApplication(LoanApplication application)
        {
            var verified = NewApi.Verify(application);

            if (verified)
            {
                _customerScore = NewApi.Score(application);
            }
            else
            {
                // Do something else
            }
        }

        public LoanDecision MakeDecision()
        {
            var decision = new LoanDecision();

            if (_customerScore > 5)
            {
                decision.Approved = true;
                decision.InterestRate = 2.99M;
            }
            else if (_customerScore >= 3)
            {
                decision.Approved = true;
                decision.InterestRate = 4.99M;
            } else
            {
                decision.Approved = false;
            }

            return decision;
        }
    }
}
