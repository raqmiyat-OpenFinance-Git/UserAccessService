using DigitallySign;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NLog;
using NLog.Fluent;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Framework.Model;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace OpenFinanceWebApi
{
	public class SignatureXml
	{
        private readonly Logger _logger;
		private readonly IOptions<ServiceParams> _serviceParams;
		private readonly IOptions<SignatureParams> _signatureParams;
		public SignatureXml(Logger logger, IOptions<ServiceParams> serviceParams, IOptions<SignatureParams> signatureParams)
        {
			_logger = logger;
            _serviceParams = serviceParams;
			_signatureParams = signatureParams;
            
        }
		public async Task<string> GetEncryptedXmlAsync(string messageId, string xml)
		{
            string serviceParamsJson = JsonConvert.SerializeObject(_serviceParams.Value);
            _logger.Info(BaseLogger.FormStructuredLog($"ServiceParams: {serviceParamsJson}"));

            string signatureParamsJson = JsonConvert.SerializeObject(_signatureParams.Value);
            _logger.Info(BaseLogger.FormStructuredLog($"SignatureParams: {signatureParamsJson}"));

            string encryptedXml = string.Empty;

			try
			{
				string fileName = messageId + ".xml";
				string filePath = Path.Combine(_serviceParams.Value.StubPath!, _serviceParams.Value.StubOutPath!);

                _logger.Info(BaseLogger.FormStructuredLog($"Original XML Message: {xml}"));

                //Signature xml
                string signatureXmlPath = Path.Combine(filePath, "Signature");

				if (!Directory.Exists(signatureXmlPath))
				{
					Directory.CreateDirectory(signatureXmlPath);
				}

				string signatureXmlFilePath = Path.Combine(signatureXmlPath, fileName);
				if (File.Exists(signatureXmlFilePath))
				{
					File.Delete(signatureXmlFilePath);
				}

                _logger.Info(BaseLogger.FormStructuredLog($"Signature XML Path: {signatureXmlFilePath}"));

                var xResDoc = new XmlDocument();
				xResDoc.LoadXml(xml);

				Encoding encoding = Encoding.ASCII;
				byte[] byteArray = encoding.GetBytes(xResDoc.OuterXml);
				string xmlStringCTD = Encoding.ASCII.GetString(byteArray);
				Encoding outputEnc = Encoding.ASCII;

				using (StreamWriter sw = new StreamWriter(signatureXmlFilePath, false, outputEnc))  // Opening and Writing data's into the file using stream writer.
				{
					sw.WriteLine(xmlStringCTD);
				}

                _logger.Info(BaseLogger.FormStructuredLog($"Signature XML Content after writing: {xmlStringCTD}"));

                var signatureXml = await AddSignatureAsync(signatureXmlFilePath);

                _logger.Info(BaseLogger.FormStructuredLog($"Signature XML Content after processing: {signatureXml}"));

                if (File.Exists(signatureXmlFilePath))
				{
					File.Delete(signatureXmlFilePath);
				}
				xResDoc = new XmlDocument();
				xResDoc.LoadXml(signatureXml);

				encoding = Encoding.ASCII;
				byteArray = encoding.GetBytes(xResDoc.OuterXml);
				xmlStringCTD = Encoding.ASCII.GetString(byteArray);
				outputEnc = Encoding.ASCII;

				using (StreamWriter sw = new StreamWriter(signatureXmlFilePath, false, outputEnc))  // Opening and Writing data's into the file using stream writer.
				{
					sw.WriteLine(xmlStringCTD);
				}

                //Encrypted xml
                string encryptedXmlPath = Path.Combine(filePath, "Encrypted");

				if (!Directory.Exists(encryptedXmlPath))
				{
					Directory.CreateDirectory(encryptedXmlPath);
				}

				string encryptedXmlFilePath = Path.Combine(encryptedXmlPath, fileName);

                _logger.Info(BaseLogger.FormStructuredLog($"Encrypted XML Path: {encryptedXmlFilePath}"));

                if (File.Exists(encryptedXmlFilePath))
				{
					File.Delete(encryptedXmlFilePath);
				}

				await PgpEncryptionAsync(encryptedXmlFilePath, signatureXmlFilePath, _signatureParams.Value.PublickKeyFilePath!);

				StreamReader? streamReader = new StreamReader(encryptedXmlFilePath);
				encryptedXml = streamReader.ReadToEnd();
				streamReader.Close();
				streamReader.Dispose();

                _logger.Info(BaseLogger.FormStructuredLog($"Encrypted XML Content: {encryptedXml}"));
            }
			catch (Exception ex)
			{
                _logger.Error(BaseLogger.FormStructuredLog($"An error occurred in GetEncryptedXmlAsync(): {ex.Message}"));

                // Log the stack trace
                _logger.Error($"StackTrace: {ex.StackTrace}");

                // Check for inner exceptions
                Exception innerException = ex.InnerException;
                int innerExceptionCount = 1;

                while (innerException != null)
                {
                    // Log inner exception details
                    _logger.Error(BaseLogger.FormStructuredLog($"InnerException {innerExceptionCount}: {innerException.Message}"));
                    _logger.Error(BaseLogger.FormStructuredLog($"InnerException {innerExceptionCount} StackTrace: {innerException.StackTrace}"));

                    // Move to the next inner exception
                    innerException = innerException.InnerException;
                    innerExceptionCount++;
                }
            }
			return encryptedXml;
		}
		private async Task<string> AddSignatureAsync(string xmlFilePath)
		{
			string? result = string.Empty;
			try
			{
				_logger.Info(BaseLogger.FormStructuredLog("AddSignatureAsync is invoked."));
				X509Certificate2 certificate = new X509Certificate2(_signatureParams.Value.PrivateCertificatepath!, _signatureParams.Value.PrivateCertificatepassword!);
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.PreserveWhitespace = _signatureParams.Value.PreserveWhitespace;
				using (XmlTextReader xmlTextReader = new XmlTextReader(xmlFilePath))
				{
					xmlDoc.Load(xmlTextReader);
					await SignXmlAsync(xmlDoc, certificate);
					if (xmlDoc != null)
					{
						result = xmlDoc.InnerXml.ToString();
						_logger.Info(BaseLogger.FormStructuredLog($"signature added successfully:  {result}."));
					}
				}
				_logger.Info(BaseLogger.FormStructuredLog("AddSignatureAsync is done."));
			}
			catch (Exception ex)
			{
				_logger.Error(BaseLogger.FormStructuredLog($"Error occured in AddSignature:{ex.Message}"));
			}
			return result;
		}
		private async Task SignXmlAsync(XmlDocument xmlDoc, X509Certificate2 certificate)
		{
			await Task.Run(() =>
			{
				try
				{
					_logger.Info(BaseLogger.FormStructuredLog("SignXmlAsync is invoked."));
					SignedXml signedXml = new SignedXml(xmlDoc)
					{
						SigningKey = certificate.PrivateKey
					};
					Reference reference = new Reference();
					reference.Uri = "";
					reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
					signedXml.AddReference(reference);

					KeyInfo keyInfo1 = new KeyInfo();

					KeyInfoX509Data keyinfox509data = new KeyInfoX509Data(certificate);
					keyinfox509data.AddSubjectName(certificate.Subject);
					keyInfo1.AddClause(keyinfox509data);
					signedXml.KeyInfo = keyInfo1;
					signedXml.ComputeSignature();
					XmlElement xmlSig = signedXml.GetXml();

					xmlDoc.DocumentElement!.AppendChild(xmlDoc.ImportNode(xmlSig, true));
					_logger.Info(BaseLogger.FormStructuredLog("SignXmlAsync is done."));
				}
				catch (Exception ex)
				{
					_logger.Error(BaseLogger.FormStructuredLog($"Error occured in SignXml:{ex.Message}"));
				}
			});
		}
		private async Task PgpEncryptionAsync(string outputFileName, string inputFileName, string encKeyFileName)
		{
			await Task.Run(() =>
			{
				try
				{
					_logger.Info(BaseLogger.FormStructuredLog("PgpEncryptionAsync is invoked."));
					Pgp.EncryptFile(outputFileName, inputFileName, encKeyFileName, _signatureParams.Value.armor, _signatureParams.Value.withIntegrityCheck);
					_logger.Info(BaseLogger.FormStructuredLog($"file encrypted successfully:  {outputFileName}."));
					_logger.Info(BaseLogger.FormStructuredLog("PgpEncryptionAsync is done."));
				}
				catch (Exception ex)
				{
					_logger.Error(BaseLogger.FormStructuredLog($"Error occured in PgpEncryption:{ ex.Message}"));
				}
			});
		}
	}
}
