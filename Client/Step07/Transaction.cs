namespace Client.Step07
{
	public class Transaction : object
	{
		public Transaction(int id, TransactionType type,
			int amount, string recipientAccountAddress,
			string? senderAccountAddress = null) : base()
		{
			Id = id;
			Type = type;
			Amount = amount;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		public int Id { get; }

		public int Amount { get; }

		public TransactionType Type { get; }

		public string? SenderAccountAddress { get; }

		public string RecipientAccountAddress { get; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
