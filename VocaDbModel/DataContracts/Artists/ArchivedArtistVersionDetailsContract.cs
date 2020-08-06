using System.Linq;
using VocaDb.Model.DataContracts.Versioning;
using VocaDb.Model.Domain.Artists;
using VocaDb.Model.Domain.Security;

namespace VocaDb.Model.DataContracts.Artists {

	public class ArchivedArtistVersionDetailsContract {

		public ArchivedArtistVersionDetailsContract() { }

		public ArchivedArtistVersionDetailsContract(ArchivedArtistVersion archived, ArchivedArtistVersion comparedVersion,
			IUserPermissionContext permissionContext) {

			ParamIs.NotNull(() => archived);

			ArchivedVersion = new ArchivedArtistVersionContract(archived);
			Artist = new ArtistContract(archived.Artist, permissionContext.LanguagePreference);
			ComparedVersion = comparedVersion != null ? new ArchivedArtistVersionContract(comparedVersion) : null;
			ComparedVersionId = comparedVersion != null ? comparedVersion.Id : 0;
			Name = Artist.Name;

			ComparableVersions = archived.Artist.ArchivedVersionsManager
				.GetPreviousVersions(archived, permissionContext)
				.Select(a => ArchivedObjectVersionWithFieldsContract.Create(a, a.Diff.ChangedFields.Value, a.Reason))
				.ToArray();

			Versions = ComparedArtistsContract.Create(archived, comparedVersion);

			ComparedVersionId = Versions.SecondId;

		}

		public ArchivedArtistVersionContract ArchivedVersion { get; set; }

		public ArtistContract Artist { get; set; }

		public bool CanBeReverted => ArchivedVersion.Version < Artist.Version - 1;

		public ArchivedObjectVersionWithFieldsContract<ArtistEditableFields, ArtistArchiveReason>[] ComparableVersions { get; set; }

		public ArchivedArtistVersionContract ComparedVersion { get; set; }

		public int ComparedVersionId { get; set; }

		public bool Hidden => ArchivedVersion.Hidden || (ComparedVersion != null && ComparedVersion.Hidden);

		public string Name { get; set; }

		public ComparedArtistsContract Versions { get; set; }

	}

}
