using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.Domain
{
    public class LoanDecision
    {
        public bool Approved { get; set; }
        public decimal InterestRate { get; set; }
    }
}
