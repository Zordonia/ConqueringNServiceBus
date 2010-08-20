namespace ConqueringNServiceBus.Saga
{
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	using System.Transactions;
	using ConqueringNServiceBus.SagaMessages;
	using HibernatingRhinos.Profiler.Appender;
	using HibernatingRhinos.Profiler.Appender.NHibernate;
	using log4net.Config;
	using NServiceBus;
	using StructureMap;

	public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization
	{
		private readonly IEnumerable<Assembly> _assemblies = new List<Assembly>
		{
			typeof (BeginSagaMessage).Assembly,
			typeof (EndpointConfig).Assembly,
			Assembly.Load("NServiceBus"),
			Assembly.Load("NServiceBus.Core"),
			Assembly.Load("NServiceBus.Host")
		};

		private IContainer _container;

		#region IWantCustomInitialization Members

		public void Init()
		{
			var file = new FileInfo("log4net.config");
			if (file.Exists) {
				XmlConfigurator.Configure(file);
			}

			InitializeSagaConnection();
			InitializeNServiceBus();
		}

		#endregion

		private void InitializeSagaConnection()
		{
			NHibernateProfiler.Initialize();
			ObjectFactory.Initialize(x => x.AddRegistry<SagaRegistry>());
			_container = ObjectFactory.Container;
			ProfilerInfrastructure.FlushAllMessages();
		}

		private void InitializeNServiceBus()
		{
			Configure.With(_assemblies)
				.Synchronization()
				.StructureMapBuilder(_container)
				.Log4Net()
				.XmlSerializer()
				.MsmqTransport()
				.IsTransactional(true)
				.IsolationLevel(IsolationLevel.RepeatableRead)
				.UnicastBus()
				.LoadMessageHandlers()
				.Sagas()
				.SetSagaPersister(_container);
		}
	}
}