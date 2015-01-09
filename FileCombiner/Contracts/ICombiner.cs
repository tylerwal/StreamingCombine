using System.Net;

namespace FileCombiner.Contracts
{
	public interface ICombiner
	{
		void Initialize(IParser parser, Media media, WebClient webClient);

		void CreateCombinedFile();
	}
}