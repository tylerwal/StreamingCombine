using System.IO;
using System.Net;

namespace FileCombiner.Contracts
{
	public interface ICombiner
	{
		void Initialize(IParser parser, IConversionMetaData conversionMetaData, WebClient webClient);

		FileInfo CreateCombinedFile();
	}
}