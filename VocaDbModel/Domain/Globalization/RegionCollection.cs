using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VocaDb.Model.Domain.Globalization {

	public class RegionCollection {

		public static readonly string[] RegionCodes = new string[]
		{
			"AL",
			"DZ",
			"AS",
			"AD",
			"AO",
			"AI",
			//"AQ",
			"AG",
			"AR",
			"AM",
			"AW",
			"AU",
			"AT",
			"AZ",
			"BS",
			"BH",
			"BD",
			"BB",
			"BY",
			"BE",
			"BZ",
			"BJ",
			"BM",
			"BT",
			"BO",
			"BQ",
			"BA",
			"BW",
			"BR",
			"IO",
			"BN",
			"BG",
			"BF",
			"BI",
			"KH",
			"CM",
			"CA",
			"CV",
			"KY",
			"CF",
			"TD",
			"CL",
			"CN",
			"CX",
			"CC",
			"CO",
			"KM",
			"CG",
			"CD",
			"CK",
			"CR",
			"CI",
			"HR",
			"CW",
			"CY",
			"CZ",
			"DK",
			"DJ",
			"DM",
			"DO",
			"EC",
			"EG",
			"SV",
			"GQ",
			"ER",
			"EE",
			"ET",
			"FK",
			"FO",
			"FJ",
			"FI",
			"FR",
			"GF",
			"PF",
			//"TF",
			"GA",
			"GM",
			"GE",
			"DE",
			"GH",
			"GI",
			"GR",
			"GL",
			"GD",
			"GP",
			"GU",
			"GT",
			"GN",
			"GW",
			"GY",
			"HT",
			"VA",
			"HN",
			"HK",
			"HU",
			"IS",
			"IN",
			"ID",
			"IE",
			"IL",
			"IT",
			"JM",
			"JP",
			"JO",
			"KZ",
			"KE",
			"KI",
			"KR",
			"XK",
			"KW",
			"KG",
			"LA",
			"LV",
			"LB",
			"LS",
			"LR",
			"LY",
			"LI",
			"LT",
			"LU",
			"MO",
			"MK",
			"MG",
			"MW",
			"MY",
			"MV",
			"ML",
			"MT",
			"MH",
			"MQ",
			"MR",
			"MU",
			"YT",
			"MX",
			"FM",
			"MD",
			"MC",
			"MN",
			"ME",
			"MS",
			"MA",
			"MZ",
			"MM",
			"NA",
			"NR",
			"NP",
			"NL",
			//"AN",
			"NC",
			"NZ",
			"NI",
			"NE",
			"NG",
			"NU",
			"NF",
			"MP",
			"NO",
			"OM",
			"PK",
			"PW",
			"PA",
			"PG",
			"PY",
			"PE",
			"PH",
			"PL",
			"PT",
			"PR",
			"QA",
			"RE",
			"RO",
			"RU",
			"RW",
			"KN",
			"LC",
			"PM",
			"VC",
			"WS",
			"SM",
			"ST",
			"SA",
			"SN",
			"RS",
			"SC",
			"SL",
			"SG",
			"SX",
			"SK",
			"SI",
			"SB",
			"SO",
			"ZA",
			//"GS",
			"ES",
			"LK",
			"SR",
			"SJ",
			"SZ",
			"SE",
			"CH",
			"TW",
			"TJ",
			"TZ",
			"TH",
			"TL",
			"TG",
			"TO",
			"TT",
			"TN",
			"TR",
			"TM",
			"TC",
			"TV",
			"UG",
			"UA",
			"AE",
			"GB",
			"US",
			"UM",
			"UY",
			"UZ",
			"VU",
			"VE",
			"VN",
			"VG",
			"VI",
			"WF",
			//"EH",
			"YE",
			"ZM",
			"ZW",
		};

		public RegionInfo[] Regions { get; }

		public RegionCollection(string[] regions) {
			Regions = regions.Select(r => new RegionInfo(r)).ToArray();
		}

		public Dictionary<string, string> ToDictionaryFull(string defaultName = null) {
			return Enumerable
				.Repeat(new KeyValuePair<string, string>(string.Empty, defaultName), defaultName != null ? 1 : 0)
				.Concat(Regions.Select(r => new KeyValuePair<string, string>(r.TwoLetterISORegionName, r.DisplayName))
					.OrderBy(k => k.Value))
				.ToDictionary(k => k.Key, k => k.Value);
		}

	}

}
