namespace Raqmiyat.Framework.Model
{
    public class DataBaseConnectionParams
	{
		public string FrameworkDBConnection { get; set; }
		public string DBConnection { get; set; }
		public string AuditLogConnection { get; set; }
		public bool IsEncrypted { get; set; }
		public int CommandTimeout { get; set; }
	}
}
