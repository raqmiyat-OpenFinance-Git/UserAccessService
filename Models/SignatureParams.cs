namespace Raqmiyat.Framework.Model
{
	public class SignatureParams
	{
		public string? PrivateCertificatepath { get; set; }
		public string? PrivateCertificatepassword { get; set; }
		public string? PublicCertificatepath { get; set; }
		public string? RSASize { get; set; }
		public string? PublickKeyFilePath { get; set; }
		public string? PrivateKeyFilePath { get; set; }
		public string? Passphrase { get; set; }
		public bool PreserveWhitespace { get; set; }
		public bool armor { get; set; }
		public bool withIntegrityCheck { get; set; }
		public bool Enabled { get; set; }

	}
}
