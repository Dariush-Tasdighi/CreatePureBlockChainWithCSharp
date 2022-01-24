namespace Client.Step07
{
	public class Block : object
	{
		public Block(int blockNumber,
			int difficulty, string? parentHash = null) : base()
		{
			Difficulty = difficulty;
			ParentHash = parentHash;
			BlockNumber = blockNumber;

			Transactions =
				new System.Collections.Generic.List<Transaction>();
		}

		public int BlockNumber { get; }

		public int Difficulty { get; }

		public string? ParentHash { get; }

		public int Nonce { get; protected set; }

		public string? MixHash { get; protected set; }

		public System.TimeSpan? Duration { get; protected set; }

		public System.DateTime? Timestamp { get; protected set; }

		// **********
		//public Transaction Transaction { get; }
		public System.Collections.Generic.IList<Transaction> Transactions { get; }
		// **********

		public bool IsMined()
		{
			var result =
				!string.IsNullOrWhiteSpace(MixHash);

			return result;
		}

		public void Mine()
		{
			Timestamp =
				System.DateTime.Now;

			var leadingZeros =
				"".PadLeft(totalWidth: Difficulty, paddingChar: '0');

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
		}

		public string CalculateMixHash()
		{
			var stringBuilder =
				new System.Text.StringBuilder();

			stringBuilder.Append($"{nameof(Nonce)}:{Nonce}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Timestamp)}:{Timestamp}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Difficulty)}:{Difficulty}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(ParentHash)}:{ParentHash}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(BlockNumber)}:{BlockNumber}");

			// **********
			var transactionsString =
				Infrastructure.Utility.ConvertObjectToJson(Transactions);

			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Transactions)}:{transactionsString}");
			// **********

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
