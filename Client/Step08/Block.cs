namespace Client.Step08
{
	public class Block : object
	{
		public Block(int blockNumber, int difficulty,
			decimal baseFeePerGas, string? parentHash = null) : base()
		{
			Difficulty = difficulty;
			ParentHash = parentHash;
			BlockNumber = blockNumber;
			BaseFeePerGas = baseFeePerGas;

			_transactions =
				new System.Collections.Generic.List<Transaction>();
		}

		// **********
		public int Difficulty { get; }

		public int BlockNumber { get; }

		public string? ParentHash { get; }

		public decimal BaseFeePerGas { get; }
		// **********

		// **********
		public int Nonce { get; protected set; }

		public string? MixHash { get; protected set; }

		public System.TimeSpan? Duration { get; protected set; }

		public System.DateTime? Timestamp { get; protected set; }
		// **********

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

		public bool AddTransaction(Transaction transaction)
		{
			if (transaction.FeePerGas < BaseFeePerGas)
			{
				return false;
			}

			_transactions.Add(transaction);

			return true;
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
			Timestamp =
				Infrastructure.Utility.Now;

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
				Infrastructure.Utility.Now;

			Duration =
				finishTime - startTime;
		}

		public string CalculateMixHash()
		{
			var transactionsString =
				Infrastructure.Utility
				.ConvertObjectToJson(Transactions);

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
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(Transactions)}:{transactionsString}");

			// **********
			stringBuilder.Append('|');
			stringBuilder.Append($"{nameof(BaseFeePerGas)}:{BaseFeePerGas}");
			// **********

			var text =
				stringBuilder.ToString();

			string result =
				Infrastructure.Utility.GetSha256(text: text);

			return result;
		}

		public decimal GetTotalGasFee()
		{
			var result =
				_transactions
				.Sum(current => current.FeePerGas)
				;

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
