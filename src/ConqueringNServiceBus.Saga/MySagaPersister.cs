namespace ConqueringNServiceBus.Saga
{
	using System;
	using NHibernate;
	using NHibernate.Criterion;
	using NServiceBus.Saga;

	public class MySagaPersister : ISagaPersister
	{
		public MySagaPersister(ISessionFactory sessionFactory)
		{
			SessionFactory = sessionFactory;
		}

		public ISessionFactory SessionFactory { get; set; }

		#region ISagaPersister Members

		public void Save(ISagaEntity saga)
		{
			var session = SessionFactory.GetCurrentSession();
			session.Save(saga);
		}

		public void Update(ISagaEntity saga)
		{
			var session = SessionFactory.GetCurrentSession();
			session.Merge(saga);
		}

		public T Get<T>(Guid sagaId) where T : ISagaEntity
		{
			return SessionFactory.GetCurrentSession().CreateCriteria(typeof (T), "b")
				.Add(Restrictions.Eq("b.SomeProcessId", sagaId))
				.SetFetchMode("b.Children", FetchMode.Eager)
				.SetCacheable(true)
				.SetCacheMode(CacheMode.Normal)
				.UniqueResult<T>();
		}

		public T Get<T>(string property, object value) where T : ISagaEntity
		{
			return SessionFactory.GetCurrentSession().CreateCriteria(typeof (T), "b")
				.Add(Restrictions.Eq("b." + property, value))
				.SetFetchMode("b.Children", FetchMode.Eager)
				.UniqueResult<T>();
		}

		public void Complete(ISagaEntity saga)
		{
			SessionFactory.GetCurrentSession().Delete(saga);
		}

		#endregion
	}
}