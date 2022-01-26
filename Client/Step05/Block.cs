namespace Client.Step05
{
	public class Block : object
	{
		public Block(int blockNumber,
			Transaction transaction, string? parentHash = null) : base()
		{
			ParentHash = parentHash;
			BlockNumber = blockNumber;
			Transaction = transaction;
		}

		public int BlockNumber { get; }

		public string? ParentHash { get; }

		public Transaction Transaction { get; }

		public string? MixHash { get; protected set; }

		public System.DateTime? Timestamp { get; protected set; }

		public void Mine()
		{
			Timestamp =
				System.DateTime.Now;

			MixHash =
				CalculateMixHash();
		}

		public string CalculateMixHash()
		{
			var stringBuilder =
				new System.Text.StringBuilder();

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
				Infrastructure.Utility
				.ConvertObjectToJson(theObject: this);

			return result;
		}
	}
}
