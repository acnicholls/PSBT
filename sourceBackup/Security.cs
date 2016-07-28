using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace sourceBackup
{
	/// <summary>
	/// Summary description for Security.
	/// </summary>
	public class Security
	{
		public Security()
		{
		}
		public RijndaelManaged CreateCipher()
		{
			RijndaelManaged cipher = new RijndaelManaged();
			cipher.KeySize  = 256;
			cipher.BlockSize = 256;
			return cipher;
		}
		public RijndaelManaged InitCipher()
		{
			RijndaelManaged cipher = CreateCipher();
  
			cipher.GenerateKey();
  
			return cipher;
		}
		public RijndaelManaged InitCipher(byte[] key)
		{
			RijndaelManaged cipher = CreateCipher();
			cipher.Key = key;
  
			return cipher;
		}


		public byte[] GetSHA1Hash(byte[] inputKEY)
		{
			//HashAlgorithm returnHash = System.Security.Cryptography..HashAlgorithm();
			SHA1 returnHash = new SHA1CryptoServiceProvider();
			//returnHash.
			//returnHash.
			byte[] returnValue = returnHash.ComputeHash(inputKEY);
			return returnValue;
		}

		public byte[] ConvertKeyStringToByteArray(string inputKey)
		{
			// removes dashes, and converts all characters in key string to byte value.
			byte[] arrKEY = new byte[inputKey.Length];
			int i = 0;
			foreach(char c in inputKey)
			{
				int x  = Convert.ToByte(c);
				if(x!=45)
				{
					arrKEY[i] = Convert.ToByte(x);
					i++;
				}
			}
			return arrKEY;

		}
		public string ConvertByteArrayToKeyString(byte[] inputArray)
		{
			// returns the byte array to a string value
			string arrString = "";
			foreach(byte b in inputArray)
			{
				string x = Convert.ToString(Convert.ToChar(b));
				arrString += x;
			}
			return arrString;

		}

		public string CalculateSHA1(string text, Encoding enc)
		{  
			WriteLog("Hashing : " + text);
			byte[] buffer = enc.GetBytes(text);   
			SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();  
			string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");   
			return hash;
		}

//		public string CalculateRSA(string text, Encoding enc)
//		{  
//			byte[] buffer = enc.GetBytes(text);   
//			RSACryptoServiceProvider cryptoTransformRSA =     new RSACryptoServiceProvider();  
//			string hash = BitConverter.ToString(cryptoTransformRSA..ComputeHash(buffer))/*.Replace("-", "")*/;   
//			return hash;
//		}
//		public string CalculateRSA(string text, Encoding enc)
//		{  
//			byte[] buffer = enc.GetBytes(text); 
//			//System.Security.Cryptography.TripleDESCryptoServiceProvider
//			TripleDESCryptoServiceProvider cryptoTransformRSA =     new TripleDESCryptoServiceProvider();  
//			string hash = BitConverter.ToString(cryptoTransformRSA.  .ComputeHash(buffer))/*.Replace("-", "")*/;   
//			return hash;
//		}




		private static void WriteLog(string message)
		{
//			if(debugMode)
//			{
				// this function writes a log of important info and is useful for debugging
				StreamWriter logFile = new StreamWriter(System.Environment.CurrentDirectory + @"\debug.txt",true);
				logFile.WriteLine(DateTime.Now + "    " + message);
				logFile.Flush();
				logFile.Close();   
//			}
		}
	}
}
