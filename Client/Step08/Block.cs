namespace Client.Step08
{
	public class Block : object
	{
		public Block(int blockNumber,
			int difficulty, string? parentHash = null) : base()
		{
			Difficulty = difficulty;
			ParentHash = parentHash;
			BlockNumber = blockNumber;

			// **********
			_transactions =
				new System.Collections.Generic.List<Transaction>();
			// **********
		}

		public int Difficulty { get; }

		public int BlockNumber { get; }

		public string? ParentHash { get; }

		public int Nonce { get; protected set; }

		public string? MixHash { get; protected set; }

		public System.TimeSpan? Duration { get; protected set; }

		public System.DateTime? Timestamp { get; protected set; }

		// **********
		private readonly System.Collections.Generic.List<Transaction> _transactions;

		public System.Collections.Generic.IReadOnlyList<Transaction> Transactions
		{
			get
			{
				return _transactions;
			}
		}
		// **********

		public void AddTransaction(Transaction transaction)
		{
			_transactions.Add(transaction);
		}

		public bool IsMined()
		{
			if (string.IsNullOrWhiteSpace(MixHash))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public void Mine()
		{
			if (IsMined())
			{
				return;
			}

			Timestamp =
				Infrastructure.Utility.Now;

			var leadingZeros =
				new string(c: '0', count: Difficulty);

			var startTime =
				Infrastructure.Utility.Now;

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
				Infrastructure.Utility.Now;

			Duration =
				finishTime - startTime;
		}

		public string CalculateMixHash()
		{
			var stringBuilder =
				new System.Text.StringBuilder();

			var transactionsString =
				Infrastructure.Utility.ConvertObjectToJson(Transactions);

			stringBuilder.Append($"{nameof(Nonce)}:{Nonce}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Timestamp)}:{Timestamp}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Difficulty)}:{Difficulty}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(ParentHash)}:{ParentHash}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(BlockNumber)}:{BlockNumber}");
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Transactions)}:{transactionsString}");

			var text =
				stringBuilder.ToString();

			string result =
				Infrastructure.Utility.GetSha256(text: text);

			return result;
		}

		public override string ToString()
		{
			string result =
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
