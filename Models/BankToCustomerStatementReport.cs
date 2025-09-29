using Entities.General;
using Entities.GeneralModel;

namespace NPSS_Connect.Models
{
    public class BankToCustomerStatementReport
    {
        public List<BankToCustomerStatement>? BankToCustomerStatementDetail { get; set; }
        public List<BankToCustomerStatementSummary>? bankToCustomerStatementSummary { get; set; }
        public List<General>? reportTypeList { get; set; }
        public string? ReportType { get; set; }
        public List<BankSwiftCode>? bankSwiftCodeList { get; set; }
        public string? bankSwiftCode { get; set; }

    }
    public class BankToCustomerStatement
    {
        public string? EntryReference { get; set; }
        public string? EndToEndId { get; set; }
        public string? TxnId { get; set; }
        public string? Uetr { get; set; }
        public string? ClrSysRef { get; set; }
        public string? AcctSvcrRef { get; set; }
        public string? MsgId { get; set; }
        public string? InstrId { get; set; }
        public string? Bank_Txn_Cd { get; set; }
        public string? CdtDbtInd { get; set; }
        public string? Txn_Amt { get; set; }
        public string? Sts_Cd { get; set; }
        public string? Btch_MsgId { get; set; }
        public string? Btch_NbOfTxs { get; set; }
        public string? Btch_TtlAmt { get; set; }
        public string? Btch_CdtDbtInd { get; set; }
        public string? Value_DtTm { get; set; }
        public string? InstgAgt { get; set; }
        public string? InstdAgt { get; set; }
        public string? DbtrAgt { get; set; }
        public string? CdtrAgt { get; set; }
        public string? Stmt_Received_DtTm { get; set; }
        //public string? Message_Identification { get; set; }
        //public string? Name { get; set; }
        //public string? AccountId { get; set; }
        //public string? RelatedAccountId { get; set; }
        //public string? TotalNumberofEntries { get; set; }
        //public string? TotalCreditorEntries { get; set; }
        //public string? TotalDebitEntriesSum { get; set; }
        //public string? TransationMsgId { get; set; }
        //public string? PaymentInformationId { get; set; }
        //public string? InstructionId { get; set; }
        //public string? EndToEndId { get; set; }
        //public string? Debtor { get; set; }
        //public string? Creditor { get; set; }
        //public string? BalanceAmount { get; set; }
        //public string? BalanceDate { get; set; }
        //public string? Amount { get; set; }
        //public string? TotalcreditEntriesSum { get; set; }
        //public string? TotalDebitEntries { get; set; }
        //public string? TotalcreditEntries { get; set; }
        //public string? BeneficiaryBankName { get; set; }
        //public List<BankSwiftCode>? bankSwiftCodeList { get; set; }
    }
    public class BankToCustomerStatementSummary
    {
        public string? Stmt_Identification { get; set; }
        public string? Electro_Seq_Nbr { get; set; }
        public string? Account_Id { get; set; }
        public string? Related_Account_Id { get; set; }
        public string? TtlNoOfDbts { get; set; }
        public string? SumOfDbtAmt { get; set; }
        public string? TtlNoOfCrdts { get; set; }
        public string? SumOfCrdtAmt { get; set; }
        public string? TtlNoNetDbCdEntry { get; set; }
        public string? SumOfTtlNetDbCdAmt { get; set; }
        public string? TtlAmtOfNetAmt { get; set; }
        public string? CrDrIndicator { get; set; }
        public string? BalOpening { get; set; }
        public string? Bal_Opn_DtTm { get; set; }
        public string? Bal_Closing { get; set; }
        public string? Bal_Cls_DtTm { get; set; }
        public string? Stmt_Received_Dt { get; set; }

    }
}
