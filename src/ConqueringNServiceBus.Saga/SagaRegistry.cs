namespace ConqueringNServiceBus.Saga
{
	using FluentNHibernate.Cfg;
	using FluentNHibernate.Cfg.Db;
	using NHibernate;
	using NHibernate.Cache;
	using NHibernate.Cfg;
	using NHibernate.Context;
	using StructureMap.Configuration.DSL;
	using Environment = System.Environment;

	public class SagaRegistry : Registry
	{
		public SagaRegistry()
		{
			Config = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey(Environment.MachineName))
				          	.Cache(c =>
				          	       c.UseQueryCache()
				          	       	.QueryCacheFactory<StandardQueryCacheFactory>()
				          	       	.ProviderClass<HashtableCacheProvider>()
				          	       	.UseMinimalPuts())
				          	.UseReflectionOptimizer()
				          	.MaxFetchDepth(2)
				          	.AdoNetBatchSize(24)
				          	.CurrentSessionContext<ThreadStaticSessionContext>()
				).Mappings(m => m.FluentMappings.AddFromAssemblyOf<MySagaDataMap>()).BuildConfiguration();
			Config.SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, "true");
			Config.SetProperty(NHibernate.Cfg.Environment.PropertyUseReflectionOptimizer, "true");

			ForSingletonOf<Configuration>()
				.Use(x => Config);

			Factory = Config.BuildSessionFactory();
			ForSingletonOf<ISessionFactory>()
				.Use(x => Factory)
				.WithName(Environment.MachineName);
		}

		public Configuration Config { get; set; }
		public ISessionFactory Factory { get; set; }
	}
}