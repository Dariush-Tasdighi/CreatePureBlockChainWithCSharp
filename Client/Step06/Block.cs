namespace Client.Step06
{
	public class Block : object
	{
		public Block(int blockNumber, Transaction transaction,
			int difficulty = 0, string? parentHash = null) : base()
		{
			ParentHash = parentHash;
			BlockNumber = blockNumber;
			Transaction = transaction;

			// **********
			Difficulty = difficulty;
			// **********
		}

		public int BlockNumber { get; }

		public string? ParentHash { get; }

		public Transaction Transaction { get; }

		public string? MixHash { get; protected set; }

		public System.DateTime? Timestamp { get; protected set; }

		// **********
		public int Difficulty { get; }

		public int Nonce { get; protected set; }

		public System.TimeSpan? Duration { get; protected set; }
		// **********

		public void Mine()
		{
			Timestamp =
				System.DateTime.Now;

			var leadingZeros =
				"".PadLeft(totalWidth: Difficulty, paddingChar: '0');

			// **********
			var startTime =
				System.DateTime.Now;

			Nonce = -1;
			string mixHash;

			do
			{
				Nonce++;

				mixHash =
					CalculateMixHash();
			} while (mixHash.StartsWith(leadingZeros) == false);

			MixHash = mixHash;

			var finishTime =
				System.DateTime.Now;

			Duration =
				finishTime - startTime;
			// **********
		}

		public string CalculateMixHash()
		{
			var stringBuilder =
				new System.Text.StringBuilder();

			// **********
			stringBuilder.Append($"{nameof(Nonce)}:{Nonce}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Difficulty)}:{Difficulty}");
			stringBuilder.Append('|');
			// **********

			stringBuilder.Append($"{nameof(Timestamp)}:{Timestamp}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(ParentHash)}:{ParentHash}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(BlockNumber)}:{BlockNumber}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Transaction)}:{Transaction}");

			var text =
				stringBuilder.ToString();

			string result =
				Infrastructure.Utility.GetSha256(text: text);

			return result;
		}

		public override string ToString()
		{
			string result =
				Infrastructure.Utility.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
