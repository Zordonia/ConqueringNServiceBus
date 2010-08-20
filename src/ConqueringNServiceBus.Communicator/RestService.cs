namespace ConqueringNServiceBus.Communicator
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using ConqueringNServiceBus.Messages;
	using ConqueringNServiceBus.SagaMessages;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class RestService
	{
		[WebInvoke(UriTemplate = "begin/{id}", Method = "POST")]
		public void Begin(string id)
		{
			Global.Bus.Send(new BeginSagaMessage
			{
				BeginDate = DateTime.Now,
				SomeProcessId = int.Parse(id)
			});
		}

		[WebInvoke(UriTemplate = "continue/{id}", Method = "POST")]
		public void Continue(string id)
		{
			Global.Bus.Send(new ContinueSagaMessage
			{
				Bar = "Some message",
				Foo = 423,
				SomeProcessId = int.Parse(id)
			});
		}

		[WebInvoke(UriTemplate = "end/{id}", Method = "POST")]
		public void End(string id)
		{
			Global.Bus.Send(new EndSagaMessage
			{
				Message = "Time to end the darn thing",
				SomeProcessId = int.Parse(id)
			});
		}

		[WebInvoke(UriTemplate = "{message}", Method = "POST")]
		public void One(string message)
		{
			Global.Bus.Send(new OneMessage
			{
				Title = message
			});
		}
	}
}