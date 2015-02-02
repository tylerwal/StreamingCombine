using System;

namespace Utilities
{
// attribute that allows an enum to have an associated string
	public class StringValueAttribute : Attribute
	{
		#region Fields

		private readonly string _value;

		#endregion Fields

		#region Constructor

		public StringValueAttribute(string value)
		{
			_value = value;
		}

		#endregion Constructor

		#region Properties

		public string Value
		{
			get { return _value; }
		}

		#endregion Properties
	}
}
