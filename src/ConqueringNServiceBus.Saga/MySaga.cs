namespace ConqueringNServiceBus.Saga
{
	using ConqueringNServiceBus.SagaMessages;
	using NServiceBus;
	using NServiceBus.Saga;

	public class MySaga : Saga<MySagaData>
	                      , IAmStartedByMessages<BeginSagaMessage>
	                      , IHandleMessages<ContinueSagaMessage>
	                      , IHandleMessages<EndSagaMessage>
	{
		#region IAmStartedByMessages<BeginSagaMessage> Members

		public void Handle(BeginSagaMessage message)
		{
			Data.BeginDate = message.BeginDate;
			Data.SomeProcessId = message.SomeProcessId;
		}

		#endregion

		#region IHandleMessages<ContinueSagaMessage> Members

		public void Handle(ContinueSagaMessage message)
		{
			var child = new Child
			{
				Foo = message.Foo,
				Bar = message.Bar
			};
			Data.AddChild(child);
		}

		#endregion

		#region IHandleMessages<EndSagaMessage> Members

		public void Handle(EndSagaMessage message)
		{
			Data.CompletionMessage = message.Message;
			MarkAsComplete();
		}

		#endregion
	}
}