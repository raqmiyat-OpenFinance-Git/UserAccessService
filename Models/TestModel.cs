using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAEIPP_RealTime_RedHatMQ_Listener.Models
{
    public class TestModel
    {
        public string? RealInterBankStlDate { get; set; }
        public string? ProductType { get; set; }
        public string? Amount { get; set; }
        public string? IBAN { get; set; }
        public string? Ccy { get; set; }
        public string? AccountType { get; set; }
        public string? AccountNumbetIsClosed { get; set; }
        public string? DebtorName { get; set; }
        public string? CategoryPurposeCode { get; set; }
        public string? CreditorName { get; set; }
        public string? CreditorIsUnkown { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
