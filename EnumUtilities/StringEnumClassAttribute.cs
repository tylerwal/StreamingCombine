using System;
using System.Collections.Generic;

namespace MediaHandleUtilities
{
	public class StringEnumClassAttribute : Attribute
	{
		public List<string> Value
		{
			get
			{
				return new List<string>();
			}
		}
	}
}