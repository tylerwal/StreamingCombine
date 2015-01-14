using System.IO;
using System.Net;

namespace FileCombiner.Contracts
{
	public interface ICombiner
	{
		void Initialize(IParser parser, IMedia media, WebClient webClient);

		FileInfo CreateCombinedFile();
	}
}