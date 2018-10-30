using System;
using Rebound.GlobalTrader.BuildSettingsCode;

namespace Rebound.GlobalTrader {
    interface IBuildSettings {
        int ReboundApplicationID();
        ClientDetails ClientDetails();
        Licence LicenceDetails();
        System.Collections.Generic.List<Enumerations.SiteLanguage> AllowedSiteLanguages();
        bool HideReboundPrintMessage();
        string MacAddress();
    }
}
