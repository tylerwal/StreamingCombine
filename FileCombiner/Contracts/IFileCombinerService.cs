﻿using System.Collections.Generic;
using System.IO;

namespace FileCombiner.Contracts
{
	public interface IFileCombinerService
	{
		IEnumerable<FileInfo> GetChunkFileInfos(string chunkFileDirectory);

		FileInfo CombineChunkFiles(IEnumerable<FileInfo> chunkFiles, string outputFilePath);
	}
}