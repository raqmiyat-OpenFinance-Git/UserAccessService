namespace Raqmiyat.Framework.Model
{
    public class RedHatMQParams
    {
        public int IdleTimeoutMilliSeconds { get; set; }
        public string? Url { get; set; }
        public string? InQueueName { get; set; }
        public string? OutQueueName { get; set; }
        public string? TrustStorePath { get; set; }
        public string? TrustStorePassword { get; set; }
        public string? KeyStorePath { get; set; }
        public string? KeyStorePassword { get; set; }
        public bool SSLEnabled { get; set; }
        public bool IsEncrypted { get; set; }

    }
}
