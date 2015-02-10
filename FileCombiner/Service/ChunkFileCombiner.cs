using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
		/// <returns>The collection of chunk files.</returns>
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
		/// <param name="progressIndicator">The progress indicator.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>
		/// The combined file.
		/// </returns>
		/// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
		public FileInfo CombineChunkFiles(IEnumerable<FileInfo> chunkFiles, string outputFilePath, IProgress<int> progressIndicator, CancellationToken cancellationToken)
		{
			int iteration = 0;
			int numberOfChunkFiles = chunkFiles.Count();

			foreach (FileInfo chunkFile in chunkFiles)
			{
				iteration++;

				if (cancellationToken.IsCancellationRequested)
				{
					cancellationToken.ThrowIfCancellationRequested();
				}

				using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Append))
				{
					byte[] chunkBytes = File.ReadAllBytes(chunkFile.FullName);

					fileStream.Write(chunkBytes, 0, chunkBytes.Length);
				}

				decimal percentDone = ((decimal)((decimal)iteration / (decimal)numberOfChunkFiles) * (decimal)100);
				progressIndicator.Report(Convert.ToInt32(percentDone));
			}

			progressIndicator.Report(100);
			return new FileInfo(outputFilePath);
		}

		#endregion IFileCombinerService Members
	}
}