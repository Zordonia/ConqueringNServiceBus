namespace ConqueringNServiceBus.Saga
{
	using NHibernate;
	using NHibernate.Context;
	using NServiceBus;

	public class MyMessageModule : IMessageModule
	{
		public MyMessageModule(ISessionFactory sessionFactory)
		{
			SessionFactory = sessionFactory;
		}

		public ISessionFactory SessionFactory { get; set; }

		#region IMessageModule Members

		void IMessageModule.HandleBeginMessage()
		{
			var session = SessionFactory.OpenSession();
			CurrentSessionContext.Bind(session);
		}

		void IMessageModule.HandleEndMessage()
		{
			var session = CurrentSessionContext.Unbind(SessionFactory);
		}

		void IMessageModule.HandleError()
		{
		}

		#endregion
	}
}