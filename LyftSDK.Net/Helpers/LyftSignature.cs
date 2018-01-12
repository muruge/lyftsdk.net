using System;
using System.Security.Cryptography;
using System.Text;

namespace LyftSDK.Net.Helpers
{
	public class LyftSignature
	{
		public static bool IsSendedByLyft(string verificationToken, string payloadBody, string signature)
		{
			byte[] verificationTokenByte = EncodeAscii(verificationToken);
			byte[] stringToSign = EncodeUtf8(payloadBody);
			byte[] dig = HashHmac(verificationTokenByte, stringToSign);
			return Convert.ToBase64String(dig) == signature;
		}

		private static byte[] HashHmac(byte[] key, byte[] message)
		{
			var hash = new HMACSHA256(key);
			return hash.ComputeHash(message);
		}

		private static byte[] EncodeAscii(string dirty)
		{
			var encoding = new ASCIIEncoding();
			byte[] bytes = encoding.GetBytes(dirty);
			return bytes;
		}

		private static byte[] EncodeUtf8(string dirty)
		{
			var encoding = new UTF8Encoding();
			byte[] bytes = encoding.GetBytes(dirty);
			return bytes;
		}
	}
}