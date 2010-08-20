namespace ConqueringNServiceBus.Saga
{
	using NHibernate;
	using NServiceBus;
	using NServiceBus.Saga;
	using StructureMap;

	public static class Extensions
	{
		public static Configure SetSagaPersister(this Configure config, IContainer container)
		{
			config.Configurer.RegisterSingleton(typeof (ISagaPersister),
			                                    new MySagaPersister(container.GetInstance<ISessionFactory>()));

			return config;
		}
	}
}