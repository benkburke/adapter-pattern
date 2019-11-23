using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.Domain
{
    public class LoanApplication
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Employed { get; set; }
        public decimal Income { get; set; }
        public decimal LoanAmount { get; set; }
    }
}
