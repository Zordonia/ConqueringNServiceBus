using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConqueringNserviceBus.Receiver
{
	using NServiceBus;

	public class ReceivingEndpointConfig :
		IConfigureThisEndpoint,
		AsA_Server { }
}
