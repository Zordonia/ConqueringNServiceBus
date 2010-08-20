namespace ConqueringNServiceBus.Saga
{
	public class Child
	{
		public virtual int InternalId { get; set; }
		public virtual MySagaData Parent { get; set; }
		public virtual int Foo { get; set; }
		public virtual string Bar { get; set; }
	}
}