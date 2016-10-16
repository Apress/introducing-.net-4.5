using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Win8ConventionBuilder
{
	public class Logger
	{
		/// <summary>
		/// Initializes a new instance of the Logger class.
		/// </summary>
		public Logger()
		{
		}
		public void LogMessage(string message)
		{
			Debug.WriteLine(message);
		}
	}
}
