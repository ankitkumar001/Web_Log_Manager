using System;
using System.Net;
using System.Collections.Specialized;

namespace WSLA
{
	/// <summary>
	/// DecodeIPAddresses is used to decode IP Addresses into their
	/// textual equivalents.  Since this is a slow process the results
	/// are cached for subsequent use.
	/// </summary>
	public class DecodeIPAddresses
	{
		public DecodeIPAddresses()
		{
		}

		// Cache of IP addresses and the corresponding decoded values.
		private StringDictionary IPAddressCache = new StringDictionary();

		// Decode an IP Address (but use the cached value if one is
		// available).
		public String Decode(String IPAddress)
		{
			String Result = "";

			if (IPAddressCache.ContainsKey(IPAddress))
			{
				Result = IPAddressCache[IPAddress];
			}
			else
			{
				try
				{
                    Result = Dns.GetHostEntry(IPAddress).HostName;
				}
				catch
				{
					Result = IPAddress;
				}

				IPAddressCache.Add(IPAddress, Result);
			}

			return Result;
		}

	}
}
