namespace ConqueringNServiceBus.SagaMessages
{
	using System;
	using NServiceBus;

	public class BeginSagaMessage : IMessage
	{
		public int SomeProcessId { get; set; }
		public DateTime BeginDate { get; set; }
	}
}