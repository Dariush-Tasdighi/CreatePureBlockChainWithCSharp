namespace Client.Step05
{
	public class Block : object
	{
		public Block(int blockNumber, Transaction transaction, string? parentHash = null) : base()
		{
			ParentHash = parentHash;
			BlockNumber = blockNumber;
			Transaction = transaction;
		}

		public string? MixHash { get; protected set; }

		public int BlockNumber { get; protected set; }

		public string? ParentHash { get; protected set; }

		public Transaction Transaction { get; protected set; }

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
			string text =
				$"{nameof(BlockNumber)}:{BlockNumber}" +
				"|" +
				$"{nameof(Timestamp)}:{Timestamp}" +
				"|" +
				$"{nameof(ParentHash)}:{ParentHash}" +
				"|" +
				$"{nameof(Transaction)}:{Transaction}"
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
