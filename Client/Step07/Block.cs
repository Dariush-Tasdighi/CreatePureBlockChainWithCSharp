namespace Client.Step07
{
	public class Block : object
	{
		public Block(int blockNumber, int difficulty, string? parentHash = null) : base()
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
		}

		public string CalculateMixHash()
		{
			string text =
				$"{nameof(Nonce)}:{Nonce}" +
				"|" +
				$"{nameof(Timestamp)}:{Timestamp}" +
				"|" +
				$"{nameof(Difficulty)}:{Difficulty}" +
				"|" +
				$"{nameof(ParentHash)}:{ParentHash}" +
				"|" +
				$"{nameof(BlockNumber)}:{BlockNumber}" +
				"|" +
				$"{nameof(Transactions)}:{Infrastructure.Utility.ConvertObjectToJson(Transactions)}"
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
