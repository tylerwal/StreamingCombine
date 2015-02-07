using System.Collections.Generic;
using System.IO;

using FileCombiner.Contracts;

namespace FileCombiner.Service
{
	public class ChunkFileCombiner : IChunkFileCombiner
	{
		#region IFileCombinerService Members

		/// <summary>
		/// Gets the chunk file infos.
		/// </summary>
		/// <param name="chunkFileDirectory">The chunk file directory.</param>
		/// <returns></returns>
		public IEnumerable<FileInfo> GetChunkFileInfos(string chunkFileDirectory)
		{
			DirectoryInfo streamFileDirectory = new DirectoryInfo(chunkFileDirectory);

			return streamFileDirectory.GetFiles();
		}

		/// <summary>
		/// Combines the chunk files.
		/// </summary>
		/// <param name="chunkFiles">The chunk files.</param>
		/// <param name="outputFilePath">The output file path.</param>
		/// <returns></returns>
		public FileInfo CombineChunkFiles(IEnumerable<FileInfo> chunkFiles, string outputFilePath)
		{
			foreach (FileInfo chunkFile in chunkFiles)
			{
				using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Append))
				{
					byte[] chunkBytes = File.ReadAllBytes(chunkFile.FullName);

					fileStream.Write(chunkBytes, 0, chunkBytes.Length);
				}
			}

			return new FileInfo(outputFilePath);
		}

		#endregion IFileCombinerService Members
	}
}