using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Rebound.GlobalTrader.BuildSettingsCode;

namespace Rebound.GlobalTrader {

	/// <summary>
	/// Change this to set the build specific settings
	/// </summary>
	public class BuildSettings : IBuildSettings {

		//ReboundApplicationID (from ReboundApplicationControl database)
		public int ReboundApplicationID() {
			return 1;
		}

		public string MacAddress() {
			ManagementScope scp = new ManagementScope("\\\\" + Environment.MachineName);
			ManagementObjectSearcher sch = new ManagementObjectSearcher(scp, new ObjectQuery("SELECT MACAddress FROM Win32_NetworkAdapter"));
			ManagementObjectCollection col = sch.Get();
			string strMacAddress = "";
			foreach (ManagementObject obj in col) {
				if (obj["MACAddress"] != null) {
					strMacAddress = obj["MACAddress"].ToString();
					break;
				}
			}
			return strMacAddress;
		}

		//Client details (from ReboundApplicationControl database)
		//--------------------------------------------------------------------------------------------
		public ClientDetails ClientDetails() {
			return new ClientDetails(1, "Rebound UK");
		}

		//Client Application License ID (from ReboundApplicationControl database)
		//--------------------------------------------------------------------------------------------
		public Licence LicenceDetails() {
			return new Licence(1, 10000, new DateTime(2020, 12, 31));
		}

		//Allowed Site Languages
		//--------------------------------------------------------------------------------------------
		public List<Enumerations.SiteLanguage> AllowedSiteLanguages() {
			List<Enumerations.SiteLanguage> lst = new List<Enumerations.SiteLanguage>();
			lst.Add(Enumerations.SiteLanguage.English);
			return lst;
		}

		//Should Rebound print message be hidden?
		//--------------------------------------------------------------------------------------------
		public bool HideReboundPrintMessage() {
			return true;
		}
	}
}