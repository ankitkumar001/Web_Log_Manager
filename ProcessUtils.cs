using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace PU
{
	/// <summary>
	/// Summary description for ProcessUtils.
	/// </summary>
	public sealed class ProcessUtils
	{
		/// <summary>
		/// No need to instantiate objects of this class.
		/// </summary>
		private ProcessUtils()
		{
		}

		private static Mutex mutex = null;

		/// <summary>
		/// Determine if the current process is already running
		/// </summary>
		/// <returns>true if the current process is already running</returns>
		public static bool ThisProcessIsAlreadyRunning()
		{
			// Only want to call this method once, at startup.
			Debug.Assert(mutex == null);

            // createdNew needs to be false in .Net 2.0, otherwise, if another instance of
            // this program is running, the Mutex constructor will block, and then throw 
            // an exception if the other instance is shut down.
			bool createdNew = false;

			mutex = new Mutex(false, Application.ProductName, out createdNew);

			Debug.Assert(mutex != null);

			return !createdNew;
		}
	}
}
