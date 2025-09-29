namespace OpenFinanceWebApi.Custom
{
    public class BankData
    {
        public string? CCY { get; set; }
        public string? BankCode { get; set; }
        public string? GroupCode { get; set; }
        public string? OnBoardUploadPath { get; set; }
        public string? OnBoardCBPath { get; set; }
        public string? CoreBankSwiftCode { get; set; }
        public int RealTimeCreationTime { get; set; }
        public string? CBUAEBicCode { get; set; }
        public string? Mode { get; set; }
        public bool VIPFileEnabled { get; set; }
        public string? VIPBicCode { get; set; }
        public string? VIPIban {  get; set; }
        public string? Ustrd { get; set; }
        public bool Schema { get; set; }
        public bool ISSignEncrypt { get; set; }
        public string? ClearingSystemProprietary { get; set; }
    }
}
