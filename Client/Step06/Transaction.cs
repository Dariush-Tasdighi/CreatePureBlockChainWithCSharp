namespace Client.Step06
{
	public class Transaction : object
	{
		public Transaction(int amount,
			string recipientAccountAddress,
			string? senderAccountAddress = null) : base()
		{
			Id =
				System.Guid.NewGuid();

			Timestamp =
				Infrastructure.Utility.Now;

			Amount = amount;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		public int Amount { get; }

		public System.Guid Id { get; }

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
