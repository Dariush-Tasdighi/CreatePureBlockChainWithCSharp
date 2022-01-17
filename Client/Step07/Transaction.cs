namespace Client.Step07
{
	public class Transaction : object
	{
		public Transaction(int id, TransactionType type, int amount,
			string recipientAccountAddress, string? senderAccountAddress = null) : base()
		{
			Id = id;
			Type = type;
			Amount = amount;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		public int Id { get; protected set; }

		public int Amount { get; protected set; }

		public TransactionType Type { get; protected set; }

		public string? SenderAccountAddress { get; protected set; }

		public string RecipientAccountAddress { get; protected set; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
