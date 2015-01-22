using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MediaHandleUtilities
{
	public static class EnumUtilities
	{
		public static TEnum GetMatchingEnum<TEnum>(string text)
		{
			IEnumerable<TEnum> enumValues = GetEnumValueList<TEnum>();

			foreach (TEnum enumValue in enumValues)
			{
				string possibleMatch = GetStringValue(enumValue as Enum);

				if (possibleMatch == text)
				{
					return enumValue;
				}
			}

			return default(TEnum);
		}

		public static IEnumerable<TEnum> GetEnumValueList<TEnum>()
		{
			return Enum.GetValues(typeof(TEnum)).OfType<TEnum>();
		}

		public static IEnumerable<string> GetStringValues<TEnum>()
		{
			IEnumerable<Enum> enums = Enum.GetValues(typeof(TEnum)).OfType<Enum>();

			return enums.Select(GetStringValue).ToList();
		}
		
		public static List<string> GetStringValuesExceptNone<TEnum>()
		{
			return GetStringValues<TEnum>().Where(i => i != "None").ToList();
		}

		public static string GetStringValue(Enum value)
		{
			string output = null;

			Type type = value.GetType();

			FieldInfo fieldInfo = type.GetField(value.ToString());

			StringValueAttribute[] stringAttributes = (StringValueAttribute[])fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false);

			if (stringAttributes.Length > 0)
			{
				output = stringAttributes[0].Value;
			}

			return output;
		} 
	}
}