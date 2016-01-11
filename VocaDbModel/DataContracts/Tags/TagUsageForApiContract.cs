﻿using System.Runtime.Serialization;
using VocaDb.Model.Domain.Globalization;
using VocaDb.Model.Domain.Tags;

namespace VocaDb.Model.DataContracts.Tags {

	[DataContract(Namespace = Schemas.VocaDb)]
	public class TagUsageForApiContract {

		public TagUsageForApiContract() { }

		public TagUsageForApiContract(TagUsage tagUsage, ContentLanguagePreference languagePreference) {
			Count = tagUsage.Count;
			Tag = new TagBaseContract(tagUsage.Tag, languagePreference, true);
		}

		[DataMember]
		public int Count { get; set; }

		[DataMember]
		public TagBaseContract Tag { get; set; }

	}

}
