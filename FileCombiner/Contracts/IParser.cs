using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileCombiner.Contracts
{
	public interface IParser
	{
		Task<Queue<Uri>> GetChunksInOrder();
	}
}