﻿using System.Collections.Generic;
using NLog;
using VocaDb.Model.Service.Security;

namespace VocaDb.Web.Code.Security {

	/// <summary>
	/// Manages IP rules. 
	/// Currently this means IPs banned through the admin or automatically.
	/// </summary>
	public class IPRuleManager {

		private static readonly Logger log = LogManager.GetCurrentClassLogger();

		public IPRuleManager(IEnumerable<string> ips) {
			PermBannedIPs = new HostCollection(ips);
		}

		public HostCollection PermBannedIPs { get; }

		/// <summary>
		/// Temporarily banned IPs. These are persisted in memory and are cleared on application restart.
		/// </summary>
		public HostCollection TempBannedIPs { get; } = new HostCollection();

		public void AddTempBannedIP(string host, string reason) {
			log.Info("Adding temp banned IP {0}. Reason: {1}", host, reason);
			TempBannedIPs.Add(host);
		}

		/// <summary>
		/// Tests whether a host address is allowed.
		/// Both permanent and temporary rules are checked.
		/// </summary>
		/// <param name="hostAddress">Host address (IP).</param>
		/// <returns>True if the host is allowed access (not banned).</returns>
		public bool IsAllowed(string hostAddress) {
			return !PermBannedIPs.Contains(hostAddress) && !TempBannedIPs.Contains(hostAddress);
		}

		public void Reset(IEnumerable<string> ips) {
			PermBannedIPs.Reset(ips);
		}

	}

}