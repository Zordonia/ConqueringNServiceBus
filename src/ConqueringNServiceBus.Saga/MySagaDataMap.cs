namespace ConqueringNServiceBus.Saga
{
	using FluentNHibernate.Mapping;

	public class MySagaDataMap : ClassMap<MySagaData>
	{
		public MySagaDataMap()
		{
			Id(x => x.Id);
			Map(x => x.OriginalMessageId);
			Map(x => x.Originator);

			Map(x => x.SomeProcessId);
			Map(x => x.BeginDate);
			Map(x => x.CompletionMessage);

			HasMany(x => x.Children)
				.KeyColumn("SomeProcessId")
				.Cascade.All()
				.Inverse();
		}
	}
}