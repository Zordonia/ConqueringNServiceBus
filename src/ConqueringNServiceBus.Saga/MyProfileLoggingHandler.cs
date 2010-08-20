namespace ConqueringNServiceBus.Saga
{
	using NServiceBus;

	public class MyProfileLoggingHandler : IConfigureLoggingForProfile<MyProfile>
	{
		#region IConfigureLoggingForProfile<MyProfile> Members

		public void Configure(IConfigureThisEndpoint specifier)
		{
			SetLoggingLibrary.Log4Net();
		}

		#endregion
	}
}