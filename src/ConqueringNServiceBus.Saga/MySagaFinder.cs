namespace ConqueringNServiceBus.Saga
{
	using ConqueringNServiceBus.SagaMessages;
	using log4net;
	using NHibernate;
	using NServiceBus.Saga;

	public class MySagaFinder :
		IFindSagas<MySagaData>.Using<ContinueSagaMessage>
		, IFindSagas<MySagaData>.Using<EndSagaMessage>
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (MySagaFinder));

		public MySagaFinder(ISessionFactory sessionFactory)
		{
			SessionFactory = sessionFactory;
		}

		public ISessionFactory SessionFactory { get; set; }

		#region Using<ContinueSagaMessage> Members

		public MySagaData FindBy(ContinueSagaMessage message)
		{
			return FindBy(message.SomeProcessId);
		}

		#endregion

		#region Using<EndSagaMessage> Members

		public MySagaData FindBy(EndSagaMessage message)
		{
			return FindBy(message.SomeProcessId);
		}

		#endregion

		public MySagaData FindBy(int id)
		{
			return SessionFactory.GetCurrentSession().QueryOver<MySagaData>()
				.Where(x => x.SomeProcessId == id)
				.Fetch(x => x.Children).Eager
				.SingleOrDefault();
		}

		public MySagaData FindBy(BeginSagaMessage message)
		{
			return FindBy(message.SomeProcessId);
		}
	}
}