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

			string mixHash;

			do
			{
				mixHash =
					CalculateMixHash();

				Nonce++;
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
			string text =
				$"{nameof(BlockNumber)}:{BlockNumber}" +
				"|" +
				$"{nameof(Timestamp)}:{Timestamp}" +
				"|" +
				$"{nameof(ParentHash)}:{ParentHash}" +
				"|" +
				$"{nameof(Transaction)}:{Transaction}" +
				// **********
				"|" +
				$"{nameof(Nonce)}:{Nonce}" +
				"|" +
				$"{nameof(Difficulty)}:{Difficulty}"
				// **********
				;

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
