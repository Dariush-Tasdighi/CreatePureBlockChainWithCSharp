namespace Client.Step04
{
	public class Transaction : object
	{
		public Transaction(int id,
			int amount, string recipientAccountAddress,
			string? senderAccountAddress = null) : base()
		{
			Id = id;
			Amount = amount;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		public int Id { get; }

		//public int Amount { get; }
		public int Amount { get; set; }

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
