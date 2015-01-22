using System;
using System.Reflection;

namespace MediaHandleUtilities
{
	public static class StringEnum
	{
		#region Methods

		public static string GetStringValue(Enum enumToRetrieve)
		{
			string output = null;

			Type type = enumToRetrieve.GetType();

			FieldInfo fieldInfo = type.GetField(enumToRetrieve.ToString());

			StringValueAttribute[] stringAttributes = (StringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false);

			if (stringAttributes.Length > 0)
			{
				output = stringAttributes[0].Value;
			}

			return output;
		}

		#endregion Methods
	}
}