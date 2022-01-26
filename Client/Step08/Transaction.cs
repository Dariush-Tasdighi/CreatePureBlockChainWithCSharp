namespace Client.Step08
{
	public class Transaction : object
	{
		public Transaction(TransactionType type, decimal amount, decimal feePerGas,
			string recipientAccountAddress, string? senderAccountAddress = null) : base()
		{
			Id = System.Guid.NewGuid();
			Timestamp = Infrastructure.Utility.Now;

			Type = type;
			Amount = amount;
			FeePerGas = feePerGas;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		public System.Guid Id { get; }

		public decimal Amount { get; }

		public decimal FeePerGas { get; }

		public TransactionType Type { get; }

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
