using System;
using System.Collections.Generic;

namespace FileCombiner.Contracts
{
	public interface IParser
	{
		Queue<Uri> StreamingFileUris
		{
			get;
			set;
		}
	}
}