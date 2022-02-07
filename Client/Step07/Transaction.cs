namespace Client.Step07
{
	public class Transaction : object
	{
		public Transaction
			(int amount,
			TransactionType type,
			string? senderAccountAddress = null,
			string? recipientAccountAddress = null) : base()
		{
			// **********
			switch (type)
			{
				// گیرنده مهم است
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

				// فرستنده مهم است
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

				// هر دو مهم هستند
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
			// **********

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

		// **********
		public string? RecipientAccountAddress { get; }
		// **********

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
