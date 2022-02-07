using System.Linq;

namespace Client.Step07
{
	public class Contract : object
	{
		public Contract(int initialDifficulty = 0) : base()
		{
			CurrentDifficulty = initialDifficulty;

			_blocks =
				new System.Collections.Generic.List<Block>();

			// **********
			_pendingTransactions =
				new System.Collections.Generic.List<Transaction>();
			// **********
		}

		public int CurrentDifficulty { get; set; }

		// **********
		private readonly System.Collections.Generic.List<Block> _blocks;

		public System.Collections.Generic.IReadOnlyList<Block> Blocks
		{
			get
			{
				return _blocks.AsReadOnly();
			}
		}
		// **********

		// **********
		private System.Collections.Generic.List<Transaction> _pendingTransactions;

		/// <summary>
		/// Memory Pool = MemPool
		/// </summary>
		public System.Collections.Generic.IReadOnlyList<Transaction> PendingTransactions
		{
			get
			{
				return _pendingTransactions.AsReadOnly();
			}
		}
		// **********

		public void AddTransaction(Transaction transaction)
		{
			// **********
			switch (transaction.Type)
			{
				case TransactionType.Withdrawing:
				case TransactionType.Transferring:
				{
					int senderBalance =
							GetAccountBalance(accountAddress: transaction.SenderAccountAddress!);

					if (senderBalance < transaction.Amount)
					{
						return;
					}

					break;
				}
			}
			// **********

			_pendingTransactions.Add(transaction);
		}

		// **********
		private Block GetNewBlock()
		{
			Block? parentBlock = null;
			int blockNumber = Blocks.Count;

			if (blockNumber != 0)
			{
				parentBlock =
					Blocks[blockNumber - 1];
			}

			var newBlock =
				new Block(blockNumber: blockNumber,
				difficulty: CurrentDifficulty, parentHash: parentBlock?.MixHash);

			return newBlock;
		}
		// **********

		// **********
		public Block Mine()
		{
			var block =
				GetNewBlock();

			foreach (var transaction in PendingTransactions)
			{
				block.AddTransaction(transaction);
			}

			_pendingTransactions =
				new System.Collections.Generic.List<Transaction>();

			block.Mine();

			_blocks.Add(block);

			return block;
		}
		// **********

		public bool IsValid()
		{
			for (int index = 1; index <= _blocks.Count - 1; index++)
			{
				var currentBlock = _blocks[index];
				var parentBlock = _blocks[index - 1];

				var currentMixHash =
					currentBlock.CalculateMixHash();

				if (currentBlock.MixHash != currentMixHash)
				{
					return false;
				}

				if (currentBlock.ParentHash != parentBlock.MixHash)
				{
					return false;
				}
			}

			return true;
		}

		public int GetAccountBalance(string accountAddress)
		{
			if (IsValid() == false)
			{
				return 0;
			}

			int balance = 0;

			foreach (var block in _blocks)
			{
				foreach (var transaction in block.Transactions)
				{
					if (transaction.RecipientAccountAddress == accountAddress)
					{
						balance +=
							transaction.Amount;
					}

					if (transaction.SenderAccountAddress == accountAddress)
					{
						balance -=
							transaction.Amount;
					}
				}
			}

			// **********
			// مهم
			// **********
			foreach (var transaction in _pendingTransactions)
			{
				if (transaction.SenderAccountAddress == accountAddress)
				{
					balance -=
						transaction.Amount;
				}
			}
			// **********

			return balance;
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
