namespace ConqueringNServiceBus.Messages
{
	using NServiceBus;

	public class OneMessage : IMessage
	{
		public string Title { get; set; }
	}
}