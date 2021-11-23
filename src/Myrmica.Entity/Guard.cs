using System;
using System.Diagnostics;

namespace Myrmica.Entity
{
    public class Guard
    {
		internal const string AgainstMessage = "Assertion evaluation failed with 'false'.";
		internal const string ImplementsMessage = "Type '{0}' must implement type '{1}'.";
		internal const string InheritsFromMessage = "Type '{0}' must inherit from type '{1}'.";
		internal const string IsTypeOfMessage = "Type '{0}' must be of type '{1}'.";
		internal const string IsEqualMessage = "Compared objects must be equal.";
		internal const string IsPositiveMessage = "Argument '{0}' must be a positive value. Value: '{1}'.";
		internal const string IsTrueMessage = "True expected for '{0}' but the condition was False.";
		internal const string NotNegativeMessage = "Argument '{0}' cannot be a negative value. Value: '{1}'.";

		[DebuggerStepThrough]
		public static void NotNull(object arg, string argName)
		{
			if (arg == null)
				throw new ArgumentNullException(argName);
		}
		[DebuggerStepThrough]
		public static void NotNegative<T>(T arg, string argName, string message = NotNegativeMessage) where T : struct, IComparable<T>
		{
			if (arg.CompareTo(default(T)) < 0)
				throw new InvalidOperationException(message);
		}
		[DebuggerStepThrough]
		public static void IsPositive<T>(T arg, string argName, string message = IsPositiveMessage) where T : struct, IComparable<T>
		{
			if (arg.CompareTo(default(T)) < 1)
				throw new InvalidOperationException(message);
		}
		[DebuggerStepThrough]
		public static void PagingArgsValid(int indexArg, int sizeArg, string indexArgName, string sizeArgName)
		{
			NotNegative<int>(indexArg, indexArgName, "PageIndex cannot be below 0");

			if (indexArg > 0)
			{
				// if pageIndex is specified (> 0), PageSize CANNOT be 0 
				IsPositive<int>(sizeArg, sizeArgName, "PageSize cannot be below 1 if a PageIndex greater 0 was provided.");
			}
			else
			{
				// pageIndex 0 actually means: take all!
				NotNegative(sizeArg, sizeArgName);
			}
		}
	}
}
