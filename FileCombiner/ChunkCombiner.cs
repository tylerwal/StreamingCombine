using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileCombiner
{
	public class ChunkCombiner
	{
		public string DirectoryPath
		{
			get;
			set;
		}

		public ChunkCombiner(string directoryPath)
		{
			DirectoryPath = directoryPath;
		}

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

			/*int sumeOfByteArraysLength = byteArrays.Sum(ba => ba.Length);

			int offset = 0;

			int iterator = 0;

			using (FileStream fileStream = File.Create(outputFilePath))
			{
				foreach (byte[] currentByteArray in byteArrays)
				{
					Console.WriteLine(iterator++);

					fileStream.Write(currentByteArray, offset, currentByteArray.Length);

					offset += currentByteArray.Length;
				}
			}*/

			/*byte[] combinedArray = new byte[sumeOfByteArraysLength];

			int offset = 0;

			foreach (byte[] currentByteArray in byteArrays)
			{
				Buffer.BlockCopy(currentByteArray, 0, combinedArray, offset, currentByteArray.Length);
				offset += currentByteArray.Length;
			}*/

			/*byte[] combinedArray = new byte[10];

			return combinedArray;*/
		}
	}
}