namespace Client.Step04
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

		/// <summary>
		/// Index
		/// </summary>
		public int BlockNumber { get; }

		/// <summary>
		/// PreviousHash
		/// </summary>
		public string? ParentHash { get; }

		/// <summary>
		/// Data
		/// </summary>
		public Transaction Transaction { get; }

		/// <summary>
		/// Hash
		/// </summary>
		public string? MixHash { get; protected set; }

		/// <summary>
		/// MineTime
		/// Note: Mine Time NOT Create Time!
		/// </summary>
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
			// **************************************************
			//string temp =
			//	"BlockNumber:" + BlockNumber; // "BlockNumber:1"

			//string temp =
			//	string.Format("BlockNumber:{0}", BlockNumber);

			//string temp =
			//	$"BlockNumber:{BlockNumber}";

			// اگر در نوشتن نام متغیر در رشته سوتی بدهیم، کامپایلر هیچ خطایی نمی‌دهد
			//string temp =
			//	$"BlackNamber:{BlockNumber}"; // "BlackNamber:1"

			//string temp =
			//	$"{nameof(BlockNumber)}:{BlockNumber}";

			//string temp =
			//	$"{nameof(BlackNamber)}:{BlockNumber}";
			// **************************************************

			// روش ایجاد یک رشته به شکل ذیل، کاملا غیرحرفه‌ای و احمقانه است
			// فقط برای خواناتر شدن سورس‌کد، در هنگام تدریس، به شکل ذیل نوشته شده است
			string text =
				$"{nameof(BlockNumber)}:{BlockNumber}" +
				"|" +
				$"{nameof(Timestamp)}:{Timestamp}" +
				"|" +
				$"{nameof(ParentHash)}:{ParentHash}" +
				"|" +
				$"{nameof(Transaction)}:{Transaction}"
				;

			//string text =
			//	$"{nameof(BlockNumber)}:{BlockNumber}|{nameof(Timestamp)}:{Timestamp}|{nameof(ParentHash)}:{ParentHash}|{nameof(Transaction)}:{Transaction}";

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
