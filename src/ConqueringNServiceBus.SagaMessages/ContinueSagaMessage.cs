namespace ConqueringNServiceBus.SagaMessages
{
	using NServiceBus;

	public class ContinueSagaMessage : IMessage
	{
		public int SomeProcessId { get; set; }
		public int Foo { get; set; }
		public string Bar { get; set; }
	}
}