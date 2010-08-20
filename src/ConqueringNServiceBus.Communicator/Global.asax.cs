namespace ConqueringNServiceBus.Communicator
{
	using System;
	using System.ServiceModel.Activation;
	using System.Web;
	using System.Web.Routing;
	using NServiceBus;

	public class Global : HttpApplication
	{
		public static IBus Bus { get; private set; }

		private void Application_Start(object sender, EventArgs e)
		{
			RegisterRoutes();
			Bus = Configure.WithWeb()
				.Log4Net().StructureMapBuilder()
				.XmlSerializer()
				.MsmqTransport()
				.IsTransactional(true)
				.UnicastBus()
				.LoadMessageHandlers()
				.CreateBus()
				.Start();
		}

		private void RegisterRoutes()
		{
			RouteTable.Routes.Add(new ServiceRoute("RestService", new WebServiceHostFactory(), typeof (RestService)));
		}
	}
}