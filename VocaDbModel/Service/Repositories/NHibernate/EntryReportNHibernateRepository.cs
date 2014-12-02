﻿using NHibernate;
using VocaDb.Model.Domain;
using VocaDb.Model.Domain.Security;

namespace VocaDb.Model.Service.Repositories.NHibernate {

	public class EntryReportNHibernateRepository : NHibernateRepository<EntryReport>, IEntryReportRepository {

		public EntryReportNHibernateRepository(ISessionFactory sessionFactory, IUserPermissionContext permissionContext) 
			: base(sessionFactory, permissionContext) {}

	}

}
