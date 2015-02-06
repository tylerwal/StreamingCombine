using FileCombiner.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FileCombiner
{
	public class ChunkFileListService : IChunkFileListService
	{
		#region Fields

		private readonly WebClient _webClient; 

		#endregion Fields

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ChunkFileListService"/> class.
		/// </summary>
		/// <param name="webClient">The web client.</param>
		public ChunkFileListService(WebClient webClient)
		{
			_webClient = webClient;
		}
		
		#endregion Constructors
		
		#region Methods

		/// <summary>
		/// Gets the chunk file list.
		/// </summary>
		/// <param name="conversionMetaData">The conversion meta data.</param>
		/// <returns></returns>
		public async Task<Queue<Uri>> GetChunkFileList(IConversionMetaData conversionMetaData)
		{
			IParser chunklistFileParser = new ChunklistFileParser(conversionMetaData.ChunkListFileUrl, _webClient);
			
			return chunklistFileParser.GetChunksInOrder().Result;
		}
		
		#endregion Methods
	}
}
