namespace ConqueringNServiceBus.Saga
{
	using System;
	using System.Collections.Generic;
	using NServiceBus.Saga;

	public class MySagaData : IContainSagaData
	{
		public virtual int SomeProcessId { get; set; }
		public virtual DateTime BeginDate { get; set; }
		public virtual ICollection<Child> Children { get; set; }
		public virtual string CompletionMessage { get; set; }

		#region IContainSagaData Members

		/// <summary>
		/// 	The 3 last properties belong to the 
		/// 	SagaData and is intented for internal use 
		/// 	only
		/// </summary>
		public virtual Guid Id { get; set; }

		public virtual string Originator { get; set; }
		public virtual string OriginalMessageId { get; set; }

		#endregion

		public virtual void AddChild(Child child)
		{
			child.Parent = this;
			Children.Add(child);
		}
	}
}