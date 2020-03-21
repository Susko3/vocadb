using System.Linq;
using VocaDb.Model;
using VocaDb.Model.DataContracts;
using VocaDb.Model.DataContracts.Venues;
using VocaDb.Model.Domain;
using VocaDb.Model.Domain.Security;
using VocaDb.Model.Domain.Globalization;
using VocaDb.Web.Code;

namespace VocaDb.Web.Models.Venue {

	[PropertyModelBinder]
	public class VenueEditViewModel {

		public string Address { get; set; }

		public EntryStatus[] AllowedEntryStatuses { get; set; }

		[FromJson]
		public OptionalGeoPointContract Coordinates { get; set; }

		public ContentLanguageSelection DefaultNameLanguage { get; set; }

		public bool Deleted { get; set; }

		public string Description { get; set; }

		public int Id { get; set; }

		public string Name { get; set; }

		[FromJson]
		public LocalizedStringWithIdContract[] Names { get; set; }

		public string RegionCode { get; set; }

		public EntryStatus Status { get; set; }

		[FromJson]
		public WebLinkContract[] WebLinks { get; set; }

		public VenueEditViewModel() { }

		public VenueEditViewModel(VenueForEditContract contract, IUserPermissionContext permissionContext) {

			ParamIs.NotNull(() => contract);

			Address = contract.Address;
			Coordinates = contract.Coordinates;
			DefaultNameLanguage = contract.DefaultNameLanguage;
			Deleted = contract.Deleted;
			Description = contract.Description;
			Id = contract.Id;
			Name = contract.Name;
			Names = contract.Names;
			RegionCode = contract.RegionCode;
			Status = contract.Status;
			WebLinks = contract.WebLinks;

			AllowedEntryStatuses = EntryPermissionManager.AllowedEntryStatuses(permissionContext).ToArray();

		}

		public VenueForEditContract ToContract() => new VenueForEditContract {
			Address = Address,
			Coordinates = Coordinates,
			DefaultNameLanguage = DefaultNameLanguage,
			Description = Description ?? string.Empty,
			Id = Id,
			Name = Name,
			Names = Names,
			RegionCode = RegionCode,
			Status = Status,
			WebLinks = WebLinks
		};

	}

}