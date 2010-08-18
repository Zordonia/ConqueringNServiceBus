namespace ConqueringNserviceBus.Receiver
{
	using ConqueringNServiceBus.Messages;
	using NServiceBus;

	public class MyMessageHandler : IMessageHandler<OneMessage>
	{
		public void Handle(OneMessage message)
		{
			//Do something with arrived message
		}
	}
}