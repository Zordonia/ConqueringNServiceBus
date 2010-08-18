using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ConqueringNServiceBus.Communicator
{
	using ConqueringNServiceBus.Messages;
	using NServiceBus;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class RestService
	{
		[WebInvoke(UriTemplate = "{message}", Method = "POST")]
		public void Delete(string message)
		{
			Global.Bus.Send(new OneMessage
			{
				Title = message
			});
		}
	}
}
