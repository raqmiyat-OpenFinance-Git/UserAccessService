using System;
using System.Collections.Generic;

namespace Entities.Master
{
    public class BankOnboardingModel
    {
        public List<BankOnboarding> bankOnboarding { get; set; }
        public List<BankOnboardingReject> bankOnboardingReject { get; set; }
    }
    public class BankOnboarding
    {
        public string BankId { get; set; }
        public string ID { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public bool IPP_Live { get; set; }
        public bool IPP_Real_Time { get; set; }

        public bool IPP_OverlayService { get; set; }
        public string Action { get; set; }
        public string Action_By { get; set; }
        public string Reject_Reason { get; set; }



    }
    public class BankOnboardingReject
    {
        public string BankId { get; set; }
        public string ID { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public bool IPP_Live { get; set; }
        public bool IPP_Real_Time { get; set; }

        public bool IPP_OverlayService { get; set; }
        public string Action { get; set; }
        public string Action_By { get; set; }
        public string Reject_Reason { get; set; }



    }
}
