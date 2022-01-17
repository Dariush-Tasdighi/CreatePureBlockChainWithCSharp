namespace Client.Step04
{
	public class Transaction : object
	{
		public Transaction(int id, int amount,
			string recipientAccountAddress, string? senderAccountAddress = null) : base()
		{
			Id = id;
			Amount = amount;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		public int Id { get; protected set; }

		public int Amount { get; protected set; }

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
