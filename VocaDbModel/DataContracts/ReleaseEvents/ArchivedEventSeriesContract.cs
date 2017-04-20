﻿using System.Linq;
using System.Runtime.Serialization;
using VocaDb.Model.Domain.ReleaseEvents;

namespace VocaDb.Model.DataContracts.ReleaseEvents {

	[DataContract(Namespace = Schemas.VocaDb)]
	public class ArchivedEventSeriesContract {

		public ArchivedEventSeriesContract() { }

		public ArchivedEventSeriesContract(ReleaseEventSeries series, ReleaseEventSeriesDiff diff) {

			ParamIs.NotNull(() => series);

			Aliases = series.Aliases.Select(a => a.Value).ToArray();
			Category = series.Category;
			Description = series.Description;
			Id = series.Id;
			MainPictureMime = series.PictureMime;
			Name = series.Name;
			WebLinks = diff.IsIncluded(ReleaseEventSeriesEditableFields.WebLinks) ? series.WebLinks.Select(l => new ArchivedWebLinkContract(l)).ToArray() : null;

		}

		[DataMember]
		public string[] Aliases { get; set; }

		[DataMember]
		public EventCategory Category { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string MainPictureMime { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public ArchivedWebLinkContract[] WebLinks { get; set; }

	}

}
