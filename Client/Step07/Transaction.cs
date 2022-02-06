namespace Client.Step07
{
	public class Transaction : object
	{
		public Transaction(TransactionType type,
			int amount, string recipientAccountAddress,
			string? senderAccountAddress = null) : base()
		{
			Id =
				System.Guid.NewGuid();

			Timestamp =
				Infrastructure.Utility.Now;

			Type = type;
			Amount = amount;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		public int Amount { get; }

		public System.Guid Id { get; }

		// **********
		public TransactionType Type { get; }
		// **********

		public System.DateTime Timestamp { get; }

		public string? SenderAccountAddress { get; }

		public string RecipientAccountAddress { get; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
