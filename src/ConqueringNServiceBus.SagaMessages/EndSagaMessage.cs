namespace ConqueringNServiceBus.SagaMessages
{
	using NServiceBus;

	public class EndSagaMessage : IMessage
	{
		public int SomeProcessId { get; set; }
		public string Message { get; set; }
	}
}