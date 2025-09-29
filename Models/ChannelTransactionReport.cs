namespace OpenFinanceWebApi.Models
{
    public class ChannelTransactionReport
    {
        public int RowNbr { get; set; }
        public string? Message_Format { get; set; }
        public string? Requestor_Channel_Id { get; set; }
        public string? Requestor_User_Id { get; set; }
        public string? Transaction_Reference { get; set; }
        public string? Requestor_Date_Time { get; set; }
        public string? Channel_Environment { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Category_Purpose_Code { get; set; }
        public decimal Transfer_Amount { get; set; }
        public string? Currency { get; set; }
        public string? ValueDate { get; set; }
        public string? Purpose_Of_Payment { get; set; }
        public string? Account_Type { get; set; }
        public string? Debtor_Account_Number { get; set; }
        public string? Debtor_Name { get; set; }
        public string? Birth_Date { get; set; }
        public string? City_Of_Birth { get; set; }
        public string? Country_Of_Birth { get; set; }
        public string? Emirate_ID { get; set; }
        public string? Passport_ID { get; set; }
        public string? Debtor_Identification_Type { get; set; }
        public string? Economic_Activity_Code { get; set; }
        public string? Emirate_Code { get; set; }
        public string? Issuer_Type_Code { get; set; }
        public string? Trade_Licence_Number { get; set; }
        public string? Email_ID { get; set; }
        public string? Mobile_No { get; set; }
        public string? Beneficiary_Account_Number { get; set; }
        public string? Beneficiary_Name { get; set; }
        public string? Beneficiary_Bank_Swift_Code { get; set; }
        public string? Transfer_Method { get; set; }
        public string? ValidationStatus { get; set; }
        public string? PostingStatus { get; set; }
        public string? CBStatus { get; set; }
    }
}
