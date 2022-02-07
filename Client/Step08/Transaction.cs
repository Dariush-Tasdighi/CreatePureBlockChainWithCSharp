namespace Client.Step08
{
	public class Transaction : object
	{
		public Transaction
			(double fee,
			double amount,
			TransactionType type,
			string? senderAccountAddress = null,
			string? recipientAccountAddress = null) : base()
		{
			switch (type)
			{
				case TransactionType.Mining:
				case TransactionType.Charging:
				{
					senderAccountAddress = null;

					if (recipientAccountAddress == null)
					{
						throw new System.ArgumentNullException
							(paramName: nameof(recipientAccountAddress));
					}

					break;
				}

				case TransactionType.Withdrawing:
				{
					recipientAccountAddress = null;

					if (senderAccountAddress == null)
					{
						throw new System.ArgumentNullException
							(paramName: nameof(senderAccountAddress));
					}

					break;
				}

				case TransactionType.Transferring:
				{
					if (senderAccountAddress == null)
					{
						throw new System.ArgumentNullException
							(paramName: nameof(senderAccountAddress));
					}
					else
					{
						if (recipientAccountAddress == null)
						{
							throw new System.ArgumentNullException
								(paramName: nameof(recipientAccountAddress));
						}
					}

					break;
				}
			}

			Id =
				System.Guid.NewGuid();

			Timestamp =
				Infrastructure.Utility.Now;

			Fee = fee;
			Type = type;
			Amount = amount;
			SenderAccountAddress = senderAccountAddress;
			RecipientAccountAddress = recipientAccountAddress;
		}

		// **********
		public double Fee { get; }

		public double Amount { get; }
		// **********

		public System.Guid Id { get; }

		public TransactionType Type { get; }

		public System.DateTime Timestamp { get; }

		public string? SenderAccountAddress { get; }

		public string? RecipientAccountAddress { get; }

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
