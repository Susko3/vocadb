﻿using VocaDb.Model.Domain.Tags;

namespace VocaDb.Model.Domain {

	/// <summary>
	/// Do not change the numeric values here.
	/// At least <see cref="TagTargetTypes"/> is using the integer values.
	/// </summary>
	public enum EntryType {

		Undefined			= 0,

		Album				= 1,

		Artist				= 2,

		DiscussionTopic		= 4,

		PV					= 8,

		ReleaseEvent		= 16,

		ReleaseEventSeries	= 32,

		Song				= 64,

		SongList			= 128,

		Tag					= 256,

		User				= 512

	}
}
