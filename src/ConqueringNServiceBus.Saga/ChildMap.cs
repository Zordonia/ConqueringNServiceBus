namespace ConqueringNServiceBus.Saga
{
	using FluentNHibernate.Mapping;

	public class ChildMap : ClassMap<Child>
	{
		public ChildMap()
		{
			Id(x => x.InternalId);
			Map(x => x.Foo);
			Map(x => x.Bar);

			References(x => x.Parent)
				.Column("SomeProcessId");
		}
	}
}