using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using FileCombiner.Contracts;

namespace FileCombiner
{
	public class FileCombiner : ICombiner
	{
		#region Fields
		
		private IParser _parser;

		#endregion Fields

		#region Constructor

		public FileCombiner(string directoryPath)
		{
			DirectoryPath = directoryPath;
		}		 

		#endregion Constructor

		#region Properties

		public string DirectoryPath
		{
			get;
			set;
		}

		#endregion Properties

		#region Methods

		public void SetParser(IParser parser)
		{
			_parser = parser;
		}		 

		#endregion Methods

		#region Helper Methods

		public void CombineStreamFiles(string outputFilePath)
		{
			if (!Directory.Exists(DirectoryPath))
			{
				throw new DirectoryNotFoundException();
			}

			DirectoryInfo streamFileDirectory = new DirectoryInfo(DirectoryPath);

			FileInfo[] streamFiles = streamFileDirectory.GetFiles();

			List<byte[]> byteArrays = new List<byte[]>(streamFiles.Count());

			foreach (FileInfo streamFile in streamFiles)
			{
				Console.WriteLine("Getting Bytes - {0}", streamFile.Name);
				byteArrays.Add(File.ReadAllBytes(streamFile.FullName));
			}

			Console.WriteLine("Creating concatenated file...");

			CombineByteArrays(byteArrays, outputFilePath);
			
			Console.WriteLine("File Done - {0}", outputFilePath);
		}		
 
		private void CombineByteArrays(List<byte[]> byteArrays, string outputFilePath)
		{
			
			foreach (byte[] byteArray in byteArrays)
			{
				using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Append))
				{
					fileStream.Write(byteArray, 0, byteArray.Length);
				}
			}
		}

		#endregion Helper Methods
	}
}